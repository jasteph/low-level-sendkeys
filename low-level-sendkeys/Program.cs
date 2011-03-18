//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;

//namespace low_level_sendkeys
//{
//    static class Program
//    {
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Form1());
//        }
//    } 
//}

using System;
using System.Threading;
using System.Windows.Forms;
using CommandLine;
using low_level_sendkeys.Comunnication;
using low_level_sendkeys.Comunnication.Sockets;
using low_level_sendkeys.Comunnication.Win32Api;
using low_level_sendkeys.Keys;

namespace low_level_sendkeys
{
    static class Program
    {
        ///
        /// The main entry point for the application.
        ///
        [STAThread]
        static void Main(string[] args)
        {
            var options = new CommandLineOptions();

            ICommandLineParser parser = new CommandLineParser(new CommandLineParserSettings(Console.Error));
            if (!parser.ParseArguments(args, options))
            {
                Environment.Exit(1);
            }


            bool firstInstance;
            //Nós podemos colocar a palavra Local\\ antes do nome do mutex para permitir uma instancia por usuário.
            //Não é o caso aqui, mas vale a dica.
            var mutex = new Mutex(false, "low-level-sendkeys-mutex", out firstInstance);

            if (!options.Quit && firstInstance)
            {
                StartMainInstance(options);
            }
            else
            {
                // initialize console handles
                ConsoleHandling.InitConsoleHandles();
                if (!firstInstance)
                {
                    StartedAsAnotherInstance(options);
                }
                else
                {
                    // to demonstrate where the console output is going
                    StartedInCommandLineMode(options);
                }
                ConsoleHandling.ReleaseConsoleHandles();
            }

            mutex.Close();
            Application.Exit();
        }

        private static void StartMainInstance(CommandLineOptions options)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new MainForm();
            CommunicationBridge.SetMainWindow(mainForm);

            KeyManager.LoadKeyListFromDisk();

            KeyboardManager.RefreshFirstActiveKeyboard();
            SendRawKeys.StartService();

            Win32Connection.StartService();
            if (options.StartSocketServer) SocketConnection.StartSocketServer();

            if (options.Minimized)
            {
                mainForm.MinimizeToTray();
            }
            Application.Run(mainForm);

            SocketConnection.StopSocketServer();
            Win32Connection.StopService();
            KeyManager.SaveKeyListToDisk();
            SendRawKeys.StopService();
        }

        private static void StartedAsAnotherInstance(CommandLineOptions options)
        {
            const string mainContainrName = "low-levelkeys-main";

            var messageContainer = new MessageManager("low-levelkeys-second-instance");
            var exists = messageContainer.CheckMessageContainer(mainContainrName);
            if (exists)
            {
                if (!string.IsNullOrEmpty(options.SendKeys))
                {
                    var result = messageContainer.SendMessageAndWaitResponse(mainContainrName, "SENDKEYS " + options.SendKeys);
                    Console.WriteLine(result == CommunicationBridge.ResponseOk ? "Keys sent sucefully" : result);
                }

                if (options.ListKeys)
                {
                    var result = messageContainer.SendMessageAndWaitResponse(mainContainrName, "LISTKEYS");
                    Console.WriteLine("ListKeys response:");
                    Console.WriteLine(result);
                }

                if (options.Minimized)
                {
                    var result = messageContainer.SendMessageAndWaitResponse(mainContainrName, "SENDTOTRAY");
                    Console.WriteLine(result == CommunicationBridge.ResponseOk ? "Application minimized to tray." : result);
                }

                if (options.Restore)
                {
                    var result = messageContainer.SendMessageAndWaitResponse(mainContainrName, "RESTOREWINDOW");
                    Console.WriteLine(result == CommunicationBridge.ResponseOk ? "Application main window restored." : result);
                }

                if (options.StartSocketServer)
                {
                    var result = messageContainer.SendMessageAndWaitResponse(mainContainrName, "STARTSOCKETSERVER");
                    Console.WriteLine(result == CommunicationBridge.ResponseOk ? "Socket server started." : result);
                }

                if (options.StopSocketServer)
                {
                    var result = messageContainer.SendMessageAndWaitResponse(mainContainrName, "STOPSOCKETSERVER");
                    Console.WriteLine(result == CommunicationBridge.ResponseOk ? "Socket server stopped." : result);
                }

                if (options.Quit)
                {
                    var result = messageContainer.SendMessageAndWaitResponse(mainContainrName, "UNLOADAPPLICATION");
                    Console.WriteLine(result == CommunicationBridge.ResponseOk ? "Application unloaded." : result);
                }

            }
            else
            {
                Console.WriteLine("Another instance of this application is running, but a message container named 'low-levelkeys-main' was not found.");
                Console.WriteLine("No message could be sent to the another instance.");
            }
        }

        private static void StartedInCommandLineMode(CommandLineOptions options)
        {
            Console.WriteLine("\n\n\n************Console Application Starting!!!*************");

            Console.WriteLine("*************Console Application Ended!***********");
        }
    }

}

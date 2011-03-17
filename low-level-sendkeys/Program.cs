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
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                KeyManager.LoadKeyListFromDisk();
                SocketConnection.StartSocketServer();

                Application.Run(new MainForm());

                KeyManager.SaveKeyListToDisk();
                SocketConnection.StopSocketServer();
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

        private static void StartedAsAnotherInstance(CommandLineOptions options)
        {
            const string mainContainrName = "low-levelkeys-main";

            var messageContainer = new MessageManager("teste");
            var exists = messageContainer.CheckMessageContainer(mainContainrName);
            if (exists)
            {
                Console.WriteLine("Já está executando. Enviando mensagens");

                if (!string.IsNullOrEmpty(options.SendKeys))
                {
                    var result = messageContainer.SendMessage(mainContainrName, "SENDKEYS " + options.SendKeys);
                    Console.WriteLine("Mensagem enviada. Resposta: {0}", result);
                }

                if (options.ListKeys)
                {
                    var result = messageContainer.SendMessageAndWaitResponse(mainContainrName, "LISTKEYS");
                    Console.WriteLine("ListKeys enviado. Resposta: {0}", result);
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

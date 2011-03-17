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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using low_level_sendkeys.Comunnication;
using low_level_sendkeys.Comunnication.Sockets;
using low_level_sendkeys.Comunnication.Win32Api;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
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
            bool NoGui = false;
            string name = "";
            int number = 0;

            for (int i = 0; i != args.Length; ++i)
            {
                switch (args[i])
                {
                    case "/NoGui": NoGui = true; break;
                    case "/name": name = args[++i]; break;
                    case "/number": number = int.Parse(args[++i]); break;
                    default: Console.WriteLine("Invalid args!"); return;
                }

            }


            bool firstInstance;
            //Nós podemos colocar a palavra Local\\ antes do nome do mutex para permitir uma instancia por usuário.
            //Não é o caso aqui, mas vale a dica.
            var mutex = new Mutex(false, "low-level-sendkeys-mutex", out firstInstance);

            if (!NoGui && firstInstance)
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
                    StartedAsAnotherInstance();
                }
                else
                {
                    // to demonstrate where the console output is going
                    StartedInCommandLineMode(args);
                }
                ConsoleHandling.ReleaseConsoleHandles();
            }

            mutex.Close();
            Application.Exit();
        }

        private static void StartedAsAnotherInstance()
        {
            var messageContainer = new MessageManager("teste");
            var exists = messageContainer.CheckMessageContainer("low-levelkeys-main");
            if (exists)
            {
                Console.WriteLine("Já está executando. Enviando mensagem TESTE");
                var result = messageContainer.SendMessage("low-levelkeys-main", "TESTE");
                Console.WriteLine("Mensagem enviada. Resposta: {0}", result);
            }
            else
            {
                Console.WriteLine("Another instance of this application is running, but a message container named 'low-levelkeys-main' was not found.");
                Console.WriteLine("No message could be sent to the another instance.");
            }
        }

        private static void StartedInCommandLineMode(string[] args)
        {
            int argCount = args == null ? 0 : args.Length;
            Console.WriteLine("\n\n\n************Console Application Starting!!!*************");
            Console.WriteLine("You specified {0} arguments:", argCount);
            Console.Error.WriteLine("This is the error channel");
            for (int i = 0; i < argCount; i++)
            {
                Console.WriteLine(" {0}", args[i]);
            }
            Console.WriteLine("*************Console Application Ended!***********");
        }
    }

}

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
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;

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

            if (!NoGui)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                Application.Exit();
            }
            else
            {
                // initialize console handles
                ConsoleHandling.InitConsoleHandles();
                // to demonstrate where the console output is going
                int argCount = args == null ? 0 : args.Length;
                Console.WriteLine("\n\n\n************Console Application Starting!!!*************");
                Console.WriteLine("You specified {0} arguments:", argCount);
                Console.Error.WriteLine("This is the error channel");
                for (int i = 0; i < argCount; i++)
                {
                    Console.WriteLine(" {0}", args[i]);
                }
                Console.WriteLine("*************Console Application Ended!***********");
                ConsoleHandling.ReleaseConsoleHandles();

            }
        }
    }

}

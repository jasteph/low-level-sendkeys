using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace low_level_sendkeys.Comunnication.Win32Api
{

    public static class Win32Connection
    {
        private static MessageManager MessageManager;

        public static void StartService()
        {
            MessageManager = new MessageManager("low-levelkeys-main");
            MessageManager.MessageReceived += MessageManagerMessageReceived;
        }
        public static void StopService()
        {
            if (MessageManager != null)
            {
                MessageManager.MessageReceived -= MessageManagerMessageReceived;
                MessageManager.Close();
                MessageManager.Dispose();
                MessageManager = null;
            }
        }

        static void MessageManagerMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string[] tokens = e.Message.Split(' ');
            bool hasParans = tokens.Length > 1;
            CommandMap.Commands command = CommandMap.FindCommand(tokens[0]);

            switch (command)
            {
                case CommandMap.Commands.Help:
                case CommandMap.Commands.Loadfile:
                    e.Response = CommunicationBridge.ResponseError + " Not implemented yet";
                    break;

                case CommandMap.Commands.Quit:
                    e.Response = CommunicationBridge.ResponseError + " Command invalid on this context.";
                    break;
                case CommandMap.Commands.UnloadApplication:
                    e.Response = CommunicationBridge.UnloadApplication();
                    break;
                case CommandMap.Commands.Sendkeys:
                    if (hasParans)
                    {
                        e.Response = CommunicationBridge.SendKeys(string.Join(" ", tokens.Skip(1).ToArray()));
                    }
                    break;
                case CommandMap.Commands.SendMacro:
                    if (hasParans)
                    {
                        e.Response = CommunicationBridge.SendMacro(string.Join(" ", tokens.Skip(1).ToArray()));
                    }
                    break;
                case CommandMap.Commands.ListKeys:
                    e.Response = CommunicationBridge.ListKeys();
                    return;
                case CommandMap.Commands.SendToTray:
                    e.Response = CommunicationBridge.SendMainWindowToTray();
                    return;
                case CommandMap.Commands.RestoreWindow:
                    e.Response = CommunicationBridge.RestoreMainWindowsFromTray();
                    return;
                case CommandMap.Commands.StartSocketServer:
                    e.Response = CommunicationBridge.StartSocketServer();
                    return;
                case CommandMap.Commands.StopSocketServer:
                    e.Response = CommunicationBridge.StopSocketServer();
                    return;
                default:
                    e.Response = CommunicationBridge.ResponseError + " Unknow command: " + tokens[0];
                    break;
            }
        }
    }
}

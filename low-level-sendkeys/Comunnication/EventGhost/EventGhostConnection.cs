using System;
using System.Configuration;

namespace low_level_sendkeys.Comunnication.EventGhost
{
    public static class EventGhostConnection
    {
        private static EG_Network_Event_Receiver_Sender _eventGhostCommunication;
        private static string _eventGhostSendAddress;
        private static string _eventGhostSendPort;
        private static string _eventGhostSendPassword;

        public static void StartEventGhostServer()
        {
            _eventGhostSendAddress = ConfigurationManager.AppSettings["EventGhostSendAddress"];
            _eventGhostSendPort = ConfigurationManager.AppSettings["EventGhostSendPort"];
            _eventGhostSendPassword = ConfigurationManager.AppSettings["EventGhostSendPassword"];

            string eventGhostServerPort = ConfigurationManager.AppSettings["EventGhostServerPort"];
            string eventGhostServerPassword = ConfigurationManager.AppSettings["EventGhostServerPassword"];

            _eventGhostCommunication = new EG_Network_Event_Receiver_Sender("*:" + eventGhostServerPort, eventGhostServerPassword, false);
            _eventGhostCommunication.Event_FromNetworkEventSender += EventGhostCommunicationEventFromNetworkEventSender;

            _eventGhostCommunication.StartLocalNetworkEventReceiver();
        }

        public static void StopEventGhostServer()
        {
            if (_eventGhostCommunication != null)
            {
                _eventGhostCommunication.StopLocalNetworkEventReceiver();
                _eventGhostCommunication = null;
            }
        }


        private static void EventGhostCommunicationEventFromNetworkEventSender(object sender, NetWorkEventReceiver_EventArgs e)
        {
            string[] aTokens = e.name.Split(' ');

            CommandMap.Commands command = CommandMap.FindCommand(aTokens[0]);
            if (command == CommandMap.Commands.None)
            {
                //For eventghost, if omited, SENDKEYS command is assumed.
                DispatchCommand(CommandMap.Commands.Sendkeys, String.Join(" ", aTokens, 0, aTokens.Length));
            }
            else
            {
                DispatchCommand(command, String.Join(" ", aTokens, 1, aTokens.Length - 1));
            }

        }

        private static void RespondToEventGhost(string command, string message)
        {
            if (string.IsNullOrEmpty(_eventGhostSendAddress)) return;
            _eventGhostCommunication.SendEventToNetworkEventReceiver(string.Format("{0}:{1}", _eventGhostSendAddress, _eventGhostSendPort), _eventGhostSendPassword, command, new[] { message });
        }

        private static void DispatchCommand(CommandMap.Commands command, string parameters)
        {
            string result;
            switch (command)
            {
                case CommandMap.Commands.None:
                    break;
                case CommandMap.Commands.ListKeys:
                    result = CommunicationBridge.ListKeys();
                    RespondToEventGhost("LISTKEYS", result);
                    break;

                case CommandMap.Commands.Sendkeys:
                    result = CommunicationBridge.SendKeys(GetParams(parameters, ' ', 1)[0]);
                    RespondToEventGhost("SENDKEYS", result);
                    break;

                case CommandMap.Commands.ListMacros:
                    result = CommunicationBridge.ListMacros();
                    RespondToEventGhost("LISTMACROS", result);
                    break;

                case CommandMap.Commands.SendMacro:
                    result = CommunicationBridge.SendMacro(GetParams(parameters, ' ', 1)[0]);
                    RespondToEventGhost("SENDMACRO", result);
                    break;

                case CommandMap.Commands.Loadfile:
                    break;

                case CommandMap.Commands.RemapKey:
                    result = CommunicationBridge.ResponseError + " This command if not implemented yet";
                    RespondToEventGhost("REMAPKEYS", result);
                    break;

                case CommandMap.Commands.UnloadApplication:
                    var resp = CommunicationBridge.UnloadApplication();
                    if (resp == CommunicationBridge.ResponseOk)
                    {
                        RespondToEventGhost("UNLOADAPPLICATION", resp);
                        StopEventGhostServer();
                    }
                    RespondToEventGhost("UNLOADAPPLICATION", resp);
                    break;

                case CommandMap.Commands.SendToTray:
                    result = CommunicationBridge.SendMainWindowToTray();
                    RespondToEventGhost("SENDTOTRAY", result);
                    break;

                case CommandMap.Commands.RestoreWindow:
                    result = CommunicationBridge.RestoreMainWindowsFromTray();
                    RespondToEventGhost("RESTOREWINDOW", result);
                    break;

                case CommandMap.Commands.StartSocketServer:
                    result = CommunicationBridge.StartSocketServer();
                    RespondToEventGhost("STARTSOCKETSERVER", result);
                    break;

                case CommandMap.Commands.StopSocketServer:
                    result = CommunicationBridge.StopSocketServer();
                    RespondToEventGhost("STOPSOCKETSERVER", result);
                    break;

                case CommandMap.Commands.Quit:
                    RespondToEventGhost("QUIT", "Command invalid on eventghost");
                    break;

                case CommandMap.Commands.Help:
                    RespondToEventGhost("HELP", "Command invalid on eventghost. See application for help.");
                    break;
            }
        }

        private static string[] GetParams(string parameterString, char delimiter, int requiredParams)
        {
            string[] asRet = parameterString.Split(delimiter);
            if (asRet.Length < requiredParams)
                throw new ArgumentException("Missing Parameters");
            return asRet;
        }
    }
}
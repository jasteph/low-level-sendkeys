using System;
using System.Text;
using System.Windows.Forms;

namespace low_level_sendkeys.Comunnication
{
    public static class CommunicationBridge
    {
        public const string ResponseOk = "OK";
        public const string ResponseError = "#ERROR#";
        private static MainForm _mainWindow;

        public static string SendKeys(string keys)
        {
            return SendRawKeys.SendKeys(keys);
        }

        public static void SetMainWindow(MainForm mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public static string UnloadApplication()
        {
            if (_mainWindow != null)
            {
                _mainWindow.Close();
            }
            Application.Exit();

            return ResponseOk;
        }

        public static string ListKeys()
        {
            var sb = new StringBuilder();
            Keys.KeyManager.Keys.ForEach(k => sb.AppendLine(k.Name));

            sb.AppendLine(ResponseOk);
            return sb.ToString();
        }

        public static string StartSocketServer()
        {
            if (Sockets.SocketConnection.IsSocketServerRunnig())
            {
                return ResponseError + " socket server already running at port " + Sockets.SocketConnection.ServerPort;
            }

            Sockets.SocketConnection.StartSocketServer();

            return ResponseOk;
        }

        public static string StopSocketServer()
        {
            if (!Sockets.SocketConnection.IsSocketServerRunnig())
            {
                return ResponseError + " Server was not running";
            }

            Sockets.SocketConnection.StopSocketServer();
            return ResponseOk;
        }

        public static string SendMainWindowToTray()
        {
            if (_mainWindow == null)
            {
                return ResponseError + " MainWindow not found.";
            }
            _mainWindow.MinimizeToTray();
            return ResponseOk;
        }

        public static string RestoreMainWindowsFromTray()
        {
            if (_mainWindow == null)
            {
                return ResponseError + " MainWindow not found.";
            }
            _mainWindow.RestoreWindow();
            return ResponseOk;
        }

        public static string SendMacro(string macroName)
        {
            return SendRawKeys.SendMacro(macroName);
        }

        public static string ListMacros()
        {
            var sb = new StringBuilder();
            Macros.MacroManager.Macros.ForEach(k => sb.AppendLine(k.Name));

            sb.AppendLine(ResponseOk);
            return sb.ToString();
        }

        public static string StartEventGhostServer()
        {
            EventGhost.EventGhostConnection.StartEventGhostServer();
            return ResponseOk;
        }

        public static string StopEventGhostServer()
        {
            EventGhost.EventGhostConnection.StopEventGhostServer();
            return ResponseOk;
        }
    }

}
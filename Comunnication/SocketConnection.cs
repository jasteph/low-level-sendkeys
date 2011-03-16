using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace low_level_sendkeys.Comunnication
{
    public static class SocketConnection
    {
        private static Thread _threadSocket;

        static SocketConnection()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
        }

        public static void StartSocketServer()
        {
            StartSocketServer(2005);
        }
        public static void StartSocketServer(int port)
        {
            if (IsSocketServerRunnig()) return;

            var mainSocket = new MainSocket(port);
            _threadSocket = new Thread(mainSocket.WaitForConnections);
            _threadSocket.Name = "LowLevelKeys Socket Server #" + port;
            _threadSocket.Start();
        }

        public static void StopSocketServer()
        {
            if (_threadSocket != null && _threadSocket.IsAlive)
            {
                _threadSocket.Abort();
            }
        }

        public static bool IsSocketServerRunnig()
        {
            return (_threadSocket != null && _threadSocket.IsAlive);
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (!(e.ExceptionObject is ThreadAbortException))
            {
                System.Diagnostics.EventLog.WriteEntry("low-level-sendkeys", "Unhandled Exception at socket-server: " + e.ToString());
            }
        }

    }
}

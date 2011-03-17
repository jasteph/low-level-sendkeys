using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace low_level_sendkeys.Comunnication.Sockets
{
    public class MainSocket
    {
        private readonly string _endLine;
        private readonly int _socketPort;

        public MainSocket(int socketPort, string endLine)
        {
            _endLine = endLine;
            _socketPort = socketPort;
        }

        public MainSocket(int socketPort)
            : this(socketPort, Environment.NewLine)
        {
        }



        public void WaitForConnections()
        {
            Socket serverSocket = null;
            try
            {
                serverSocket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, _socketPort));
                serverSocket.Listen(5);
                while (true)
                {
                    try
                    {
                        IAsyncResult res = serverSocket.BeginAccept(null, null);
                        Socket client = serverSocket.EndAccept(res);
                        var ct = new ClienteTcp(client, _endLine);
                        var t = new Thread(ct.TreatClient);
                        t.Name = "Socket treatClient";
                        t.Start();
                    }
                    catch (ThreadAbortException)
                    {
                        serverSocket.Close();
                        break;
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("low-level-sendkeys", string.Format("low-level-sendkeys error loop:\n{0}", ex), EventLogEntryType.Error);
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (ThreadAbortException)
            {
                if (serverSocket != null) serverSocket.Close();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("low-level-sendkeys", string.Format("low-level-sendkeys error:\n{0}", ex), EventLogEntryType.Error);
                throw;
            }
        }
    }
}
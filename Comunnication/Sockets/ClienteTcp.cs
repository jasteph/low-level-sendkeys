using System;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace low_level_sendkeys.Comunnication.Sockets
{
    public class ClienteTcp
    {
        static readonly Encoding Encoding;
        private readonly Socket _clientSocket;
        private readonly string _endLine;

        static ClienteTcp()
        {
            string encod = ConfigurationManager.AppSettings["ENCODING"];
            Encoding = encod == null ? Encoding.Default : Encoding.GetEncoding(encod);
        }

        public ClienteTcp(Socket clientSocket, string endLine)
        {
            _clientSocket = clientSocket;
            _endLine = endLine;
        }

        public void TreatClient()
        {
            try
            {
                using (var networkStream = new NetworkStream(_clientSocket))
                {
                    using (TextReader sockerReader = new StreamReader(networkStream, Encoding))
                    {
                        using (TextWriter socketWriter = new NewLineReplaceStreamWriter(networkStream, Encoding))
                        {
                            var st = new SocketCommandsStream(sockerReader, socketWriter);

                            socketWriter.NewLine = _endLine;

                            socketWriter.WriteLine("Welcome to low-level-sendkey socket server.");
                            socketWriter.WriteLine();
                            st.ShowHelp();
                            socketWriter.Flush();
                            st.ListenCommands();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("low-level-sendkeys", ex.ToString());
            }
            finally
            {
                _clientSocket.Close();
            }
        }

        public bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 & part2)
            {//connection is closed
                return false;
            }
            return true;
        }

    }
}
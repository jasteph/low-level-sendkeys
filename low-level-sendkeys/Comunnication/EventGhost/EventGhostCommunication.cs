using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace low_level_sendkeys.Comunnication.EventGhost
{
    internal class EG_Network_Event_Receiver_Sender
    {
        #region Delegates

        public delegate void EnduringEvent_FromNetworkEventSender_End_Handler(object sender, NetWorkEventReceiver_EventArgs e);
        public delegate void EnduringEvent_FromNetworkEventSender_Start_Handler(object sender, NetWorkEventReceiver_EventArgs e);
        public delegate void Event_FromNetworkEventSender_Handler(object sender, NetWorkEventReceiver_EventArgs e);

        #endregion

        private readonly bool enduringEvents;

        private readonly Dictionary<string, List<string>> eventsReceived;

        private readonly string localNetworkEventReceiverAddress;
        private readonly int localNetworkEventReceiverPort;
        private readonly string localPassword;
        private readonly object locker;
        private string lastEventReceived;

        private Thread localNetworkEventReceiverThread;
        private string stopCook;
        private bool stopFlag_for_localNetworkEventReceiverThread;

        public EG_Network_Event_Receiver_Sender(string localNerAddr, string localPW, bool generateEnduringEvents)
        {
            if (localNerAddr != "")
            {
                localNetworkEventReceiverAddress = localNerAddr.Substring(0, localNerAddr.IndexOf(":"));
                if (localNetworkEventReceiverAddress == "*") localNetworkEventReceiverAddress = "0.0.0.0";
                localNetworkEventReceiverPort = Convert.ToInt32(localNerAddr.Substring(localNerAddr.IndexOf(":") + 1));
                eventsReceived = new Dictionary<string, List<string>>();
                lastEventReceived = "";
                locker = new object();
            }
            else
            {
                localNetworkEventReceiverAddress = "";
                localNetworkEventReceiverPort = 0;
            }
            localPassword = localPW;
            stopCook = new Random().Next(65536).ToString("X8").Substring(4, 4);
            enduringEvents = generateEnduringEvents;
        }

        private bool Request_StopLocalNetworkEventReceiver
        {
            get
            {
                lock (locker)
                {
                    return stopFlag_for_localNetworkEventReceiverThread;
                }
            }
            set
            {
                lock (locker)
                {
                    stopFlag_for_localNetworkEventReceiverThread = value;
                }
            }
        }

        public event EnduringEvent_FromNetworkEventSender_Start_Handler EnduringEvent_FromNetworkEventSender_Start;

        public event EnduringEvent_FromNetworkEventSender_End_Handler EnduringEvent_FromNetworkEventSender_End;

        public event Event_FromNetworkEventSender_Handler Event_FromNetworkEventSender;


        public string SendEventToNetworkEventReceiver(string remoteAddress, string pwd, string eventString,
                                                      string[] payload)
        {
            string status = "";
            string result = "";
            Socket socket;
            string remoteIP = "";
            int remotePort = 0;
            if (remoteAddress != "")
            {
                remoteIP = remoteAddress.Substring(0, remoteAddress.IndexOf(":"));
                remotePort = Convert.ToInt32(remoteAddress.Substring(remoteAddress.IndexOf(":") + 1));
            }
            else
            {
                remoteIP = "";
                remotePort = 0;
            }

            try
            {
                status = "trying to create the socket";
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (remotePort == 0)
                {
                    status = "trying to connect remote host because address not provided.";
                }
                else
                {
                    status = "trying to connect to " + remoteIP + ":" + remotePort;
                }
                socket.Connect(remoteIP, remotePort);

                status = "trying to send the magic word";
                socket.Send(Encoding.ASCII.GetBytes("quintessence\n\r"));

                status = "trying to receive the cookie";
                var buff = new byte[128];
                socket.Receive(buff);
                string cookie = Encoding.ASCII.GetString(buff);
                cookie = cookie.Substring(0, cookie.IndexOf("\n"));

                status = "trying to compute the digest";
                string token = cookie + ":" + pwd;
                string digest = HashString(token) + "\n";

                status = "trying to send the digest";
                socket.Send(Encoding.ASCII.GetBytes(digest));

                status = "trying to receive the \"accept\"";
                buff = new byte[512];
                socket.Receive(buff);
                string answer = Encoding.ASCII.GetString(buff);
                answer = answer.Substring(0, answer.IndexOf("\n"));
                if (answer == "accept")
                {
                    if (payload != null && payload.Length > 0)
                    {
                        for (int count = 0; count < payload.Length; count++)
                        {
                            status = "trying to send payload[" + count + "]";
                            socket.Send(Encoding.ASCII.GetBytes("payload " + payload[count] + "\n"));
                        }
                    }
                    status = "trying to send the default payload";
                    socket.Send(Encoding.ASCII.GetBytes("payload withoutRelease\n"));

                    status = "trying to send the eventString";
                    socket.Send(Encoding.ASCII.GetBytes(eventString + "\n"));

                    status = "trying to send the \"close\" (event and payload have been successfully sent)";
                    socket.Send(Encoding.ASCII.GetBytes("close\n"));

                    status = "trying to close the connection (event and payload have been successfully sent)";
                    socket.Close();
                    status = "success";
                }
                else
                {
                    status = "trying to receive \"accept\" (received \"" + answer + "\")";
                    socket.Close();
                }
            }
            catch
            {
                status = "Error while " + status;
            }
            if (status != "success")
            {
                if (!status.StartsWith("Error")) status = "Error while " + status;
            }
            result = status;
            return result;
        }

        public void StartLocalNetworkEventReceiver()
        {
            if (localNetworkEventReceiverThread == null)
            {
                stopFlag_for_localNetworkEventReceiverThread = false;
                localNetworkEventReceiverThread = new Thread(LocalNetworkEventReceiver);
                localNetworkEventReceiverThread.Start();
            }
        }

        public void StopLocalNetworkEventReceiver()
        {
            string status = "";
            Socket socket;

            lock (locker)
            {
                stopCook = new Random().Next(65536).ToString("X8").Substring(4, 4);
            }

            Request_StopLocalNetworkEventReceiver = true;
            try
            {
                status = "trying to create the socket";
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (localNetworkEventReceiverPort == 0)
                    status = "trying to connect remote host because address not provided.";
                else
                    status = "trying to connect to " + localNetworkEventReceiverAddress + ":" +
                             localNetworkEventReceiverPort;

                if (localNetworkEventReceiverAddress != "0.0.0.0")
                    socket.Connect(localNetworkEventReceiverAddress, localNetworkEventReceiverPort);
                else socket.Connect("127.0.0.1", localNetworkEventReceiverPort);

                status = "trying to send the magic word";
                socket.Send(Encoding.ASCII.GetBytes(stopCook + "\n"));
                status = "trying to close the socket";
                socket.Close();
            }
            catch
            {
                Console.WriteLine("Error while " + status);
            }
            localNetworkEventReceiverThread.Join(5000);

            if (localNetworkEventReceiverThread.IsAlive) localNetworkEventReceiverThread.Abort();
        }

        private void LocalNetworkEventReceiver()
        {
            string status = "";
            IPEndPoint ep;
            Socket socket;
            Socket client;
            byte[] buff;
            string magicWord;
            string cook;
            string token;
            string digest;
            string remoteDigest;
            string data;
            List<string> payload;
            string receiveBuff;
            int receivedBytes;
            string stopKey;

            try
            {
                ep = new IPEndPoint(IPAddress.Parse(localNetworkEventReceiverAddress), localNetworkEventReceiverPort);
                status = "trying to create the socket";
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                status = "trying to bind on " + localNetworkEventReceiverAddress + ":" + localNetworkEventReceiverPort;
                socket.Bind(ep);

                status = "trying to listen";
                socket.Listen(10);

                while (!Request_StopLocalNetworkEventReceiver)
                {
                    status = "waiting for new connection";
                    client = socket.Accept();
                    lock (locker)
                    {
                        stopKey = stopCook;
                    }
                    client.ReceiveTimeout = 10000;
                    client.SendTimeout = 10000;

                    status = "trying to receive the magic word";
                    buff = new byte[128];
                    client.Receive(buff);
                    magicWord = Encoding.ASCII.GetString(buff);
                    magicWord = magicWord.Substring(0, magicWord.IndexOf("\n"));
                    if (magicWord == "quintessence")
                    {
                        status = "trying to generate the cookie";
                        cook = new Random().Next(65536).ToString("X8").Substring(4, 4);

                        status = "trying to send the cookie";
                        client.Send(Encoding.ASCII.GetBytes(cook + "\n"));

                        status = "trying to compute the digest";
                        token = cook + ":" + localPassword;
                        digest = HashString(token);

                        status = "trying to get the digest from client";
                        buff = new byte[128];
                        client.Receive(buff);
                        remoteDigest = Encoding.ASCII.GetString(buff);
                        remoteDigest = remoteDigest.Substring(0, remoteDigest.IndexOf("\n"));
                        if (remoteDigest.ToUpper() == digest.ToUpper())
                        {
                            status = "trying to send \"accept\"";
                            client.Send(Encoding.ASCII.GetBytes("accept\n"));

                            data = "";
                            payload = new List<string>();
                            receiveBuff = "";
                            receivedBytes = 0;
                            while (data != "close")
                            {
                                status = "trying to receive eventData";
                                while (receiveBuff.IndexOf("\n") < 0 && receivedBytes < 32768)
                                {
                                    buff = new byte[128];
                                    receivedBytes += client.Receive(buff);
                                    data = Encoding.ASCII.GetString(buff);
                                    data = data.Trim(new[] {'\0'});
                                    receiveBuff += data;
                                }
                                data = receiveBuff.Substring(0, receiveBuff.IndexOf("\n"));
                                receiveBuff = receiveBuff.Substring(receiveBuff.IndexOf("\n") + 1);
                                if (data == "close")
                                {
                                    status = "trying to close the connection (requested by client)";
                                    try
                                    {
                                        client.Send(Encoding.ASCII.GetBytes("close\n"));
                                    }
                                    catch
                                    {
                                    }
                                    client.Close();
                                    status = "success";
                                    EndLastEvent();
                                }
                                else if (data.StartsWith("payload ")) payload.Add(data.Substring(data.IndexOf(" ") + 1));
                                else
                                {
                                    if (data == "ButtonReleased") EndLastEvent();
                                    else
                                    {
                                        if (payload.Count > 0 && payload[payload.Count - 1] == "withoutRelease")
                                            TriggerEnduringEvent(data, payload);
                                        else TriggerEvent(data, payload);
                                    }
                                }
                            }
                        }
                        else status = "trying to close the client connection (digests don't match)";
                    }
                    else if (magicWord == stopKey)
                    {
                        status = "success";
                        Request_StopLocalNetworkEventReceiver = true;
                        Console.WriteLine("Ending Local Network Event Receiver");
                    }
                    else status = "trying to close the client connection (magic word not received)";
                    client.Close();
                }

                socket.Close();
            }
            catch
            {
                status = "Error while " + status + ".";
            }
            if (status != "success") Console.WriteLine(status);
        }

        private void TriggerEvent(string eventName, List<string> payload)
        {
            Fire_Event_FromNetworkEventSender(eventName, payload);
        }

        private void TriggerEnduringEvent(string eventName, List<string> payload)
        {
            if (enduringEvents)
            {
                eventsReceived.Add(eventName, payload);
                lastEventReceived = eventName;
                Fire_EnduringEvent_FromNetworkEventSender_Start(eventName, payload);
            }
            else TriggerEvent(eventName, payload);
        }

        private void EndLastEvent()
        {
            if (eventsReceived.Count > 0 && lastEventReceived != "" && enduringEvents)
            {
                Fire_EnduringEvent_FromNetworkEventSender_End(lastEventReceived, eventsReceived[lastEventReceived]);
                eventsReceived.Remove(lastEventReceived);
                lastEventReceived = "";
            }
        }

        private void Fire_EnduringEvent_FromNetworkEventSender_Start(string name, List<string> payload)
        {
            if (EnduringEvent_FromNetworkEventSender_Start != null)
            {
                EnduringEvent_FromNetworkEventSender_Start(this, new NetWorkEventReceiver_EventArgs(name, payload));
            }
        }

        private void Fire_EnduringEvent_FromNetworkEventSender_End(string name, List<string> payload)
        {
            if (EnduringEvent_FromNetworkEventSender_End != null)
            {
                EnduringEvent_FromNetworkEventSender_End(this, new NetWorkEventReceiver_EventArgs(name, payload));
            }
        }

        private void Fire_Event_FromNetworkEventSender(string name, List<string> payload)
        {
            if (Event_FromNetworkEventSender != null)
                Event_FromNetworkEventSender(this, new NetWorkEventReceiver_EventArgs(name, payload));
        }

        private static string HashString(string value)
        {
            byte[] data = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(value));

            var hashedString = new StringBuilder();

            for (int i = 0; i < data.Length; i++)

                hashedString.Append(data[i].ToString("X2"));

            return hashedString.ToString();
        }
    }

    public class NetWorkEventReceiver_EventArgs : EventArgs
    {
        public string name;
        public List<string> payload;

        public NetWorkEventReceiver_EventArgs(string name, List<string> payload)
        {
            this.name = name;
            this.payload = payload;
        }
    }
}
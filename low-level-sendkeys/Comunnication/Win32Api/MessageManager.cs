using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace low_level_sendkeys.Comunnication.Win32Api
{
    public sealed partial class MessageManager : Form
    {
        private readonly string _managerName;
        private string _messageReceived;
        private readonly Timer _timeOut;
        private bool _waitingResponse = false;
        private string _responseReceived = string.Empty;

        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);
        public event MessageReceivedEventHandler MessageReceived;

        public MessageManager(string managerName)
        {
            InitializeComponent();

            _managerName = managerName;
            Text = managerName;

            _timeOut = new Timer();
            _timeOut.Enabled = true;
            _timeOut.AutoReset = false;
            _timeOut.Stop();
            _timeOut.Elapsed += TimeoutWaitingResponse;

            Size = new Size(0, 0);
            Show();
            Hide();
        }

        private void TimeoutWaitingResponse(object sender, ElapsedEventArgs e)
        {
            _responseReceived = CommunicationBridge.ResponseError + " Timeout waiting for a response";
            _waitingResponse = false;
            _timeOut.Stop();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32SupportCode.WM_COPYDATA:
                    Win32SupportCode.CopyDataStruct st = (Win32SupportCode.CopyDataStruct)Marshal.PtrToStructure(m.LParam, typeof(Win32SupportCode.CopyDataStruct));
                    string strData = Marshal.PtrToStringUni(st.lpData);
                    _messageReceived = strData;


                    if (!string.IsNullOrEmpty(_messageReceived))
                    {
                        int i = _messageReceived.IndexOf("#");
                        bool requestResponse = _messageReceived.Substring(i + 1, 1) == "0" ? false : true;
                        string sourceMessageManager = _messageReceived.Substring(0, i);
                        string message = _messageReceived.Substring(i + 2);

                        if (_waitingResponse)
                        {
                            _timeOut.Stop();
                            _responseReceived = message;
                            _waitingResponse = false;
                        }
                        else
                        {
                            var messageReceivedEventArgs = new MessageReceivedEventArgs(sourceMessageManager, message);

                            if (MessageReceived != null) MessageReceived(this, messageReceivedEventArgs);

                            if (requestResponse)
                            {
                                SendMessage(sourceMessageManager, messageReceivedEventArgs.Response);
                            }
                        }
                    }
                    break;
                default:
                    // let the base class deal with it
                    base.WndProc(ref m);
                    break;
            }
        }


        public bool SendMessage(string destinyMessageManager, string message)
        {
            //Get a handle for the Calculator Application main window
            int hwnd = Win32SupportCode.FindWindow(null, destinyMessageManager);
            if (hwnd != 0)
            {
                return SendSingleLine((IntPtr)hwnd, _managerName + "#0" + message);
            }
            return false;
        }


        public string SendMessageAndWaitResponse(string destinyMessageManager, string message)
        {
            return SendMessageAndWaitResponse(destinyMessageManager, message, 10000);
        }
        public string SendMessageAndWaitResponse(string destinyMessageManager, string message, int timeOut)
        {
            //Get a handle for the Calculator Application main window
            int hwnd = Win32SupportCode.FindWindow(null, destinyMessageManager);
            if (hwnd != 0)
            {
                _waitingResponse = true;
                bool sendMessageAndWaitResponse = SendSingleLine((IntPtr)hwnd, _managerName + "#1" + message);
                if (!sendMessageAndWaitResponse)
                {
                    _waitingResponse = false;
                    return CommunicationBridge.ResponseError + " Message could not be delivered";
                }

                _responseReceived = string.Empty;
                _timeOut.Interval = timeOut;
                _timeOut.Start();
                while (_waitingResponse)
                {
                    Thread.Sleep(100);
                }
                return _responseReceived;
            }
            return CommunicationBridge.ResponseError + " Message could not be delivered";
        }


        public bool CheckMessageContainer(string messageContainerName)
        {
            int hwnd = Win32SupportCode.FindWindow(null, messageContainerName);
            return hwnd != 0;
        }

        private bool SendSingleLine(IntPtr targetHWnd, string args)
        {
            var cds = new Win32SupportCode.CopyDataStruct();
            try
            {
                cds.cbData = (args.Length + 1) * 2;
                cds.lpData = Win32SupportCode.LocalAlloc(0x40, cds.cbData);
                Marshal.Copy(args.ToCharArray(), 0, cds.lpData, args.Length);
                cds.dwData = (IntPtr)1;
                Win32SupportCode.SendMessage(targetHWnd, Win32SupportCode.WM_COPYDATA, IntPtr.Zero, ref cds);
            }
            finally
            {
                cds.Dispose();
            }

            return true;
        }
    }

    public class MessageReceivedEventArgs
    {
        private readonly string _sourceContainer;
        private readonly string _message;

        internal MessageReceivedEventArgs(string sourceContainer, string message)
        {
            _sourceContainer = sourceContainer;
            _message = message;
        }
        public string SourceContainer
        {
            get { return _sourceContainer; }
        }

        public string Message
        {
            get { return _message; }
        }

        public string Response { get; set; }

    }


}

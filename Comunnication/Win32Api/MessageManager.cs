using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace low_level_sendkeys.Comunnication.Win32Api
{
    public sealed partial class MessageManager : Form
    {
        private readonly string _managerName;
        private string _messageReceived;
        private System.Timers.Timer _timeOut;

        public delegate void MessageReceivedEventHandler(object sender, string message);
        public event MessageReceivedEventHandler MessageReceived;

        public MessageManager(string managerName)
        {
            InitializeComponent();

            _managerName = managerName;
            Text = managerName;

            _timeOut = new Timer();


            Size = new Size(0, 0);
            Show();
            Hide();
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case Win32SupportCode.WM_COPYDATA:
                    Win32SupportCode.CopyDataStruct st = (Win32SupportCode.CopyDataStruct)Marshal.PtrToStructure(m.LParam, typeof(Win32SupportCode.CopyDataStruct));
                    string strData = Marshal.PtrToStringUni(st.lpData);
                    _messageReceived = strData;

                    if (MessageReceived != null)
                    {
                        MessageReceived(this, _messageReceived);
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
            int hwnd;

            //Get a handle for the Calculator Application main window
            hwnd = Win32SupportCode.FindWindow(null, destinyMessageManager);
            if (hwnd != 0)
            {
                return SendSingleLine((IntPtr)hwnd, message);
            }
            else
            {
                return false;
            }
        }

        public bool CheckMessageContainer(string messageContainerName)
        {
            int hwnd = Win32SupportCode.FindWindow(null, messageContainerName);
            return hwnd != 0;
        }

        private bool SendSingleLine(IntPtr targetHWnd, string args)
        {
            Win32SupportCode.CopyDataStruct cds = new Win32SupportCode.CopyDataStruct();
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


}

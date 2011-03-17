using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using low_level_sendkeys.KernelHotkey;
using low_level_sendkeys.Keys;
using System.Diagnostics;
using System.Threading;

namespace low_level_sendkeys
{
    public partial class MapKey : Form
    {
        private bool _autoClose;
        private Key _newKey;
        private readonly System.Timers.Timer _timerKeyUp;
        private bool timerRunnig;

        private string _keyName;

        private KeyboardManager _keyManager = new KeyboardManager();
        public MapKey()
        {
            InitializeComponent();

            _timerKeyUp = new System.Timers.Timer(200)
                              {
                                  AutoReset = false
                              };

            _timerKeyUp.Elapsed += TimerKeyUpTick;
        }


        private void MapKey_Load(object sender, EventArgs e)
        {
            Thread.Sleep(300);
            StartMapKey();
        }

        private void TimerKeyUpTick(object sender, EventArgs e)
        {
            Debug.WriteLine("TIMER OK!");

            var invoker1 = new MethodInvoker(FinishMapKey);
            this.BeginInvoke(invoker1);
            timerRunnig = false;
        }

        private void StartMapKey()
        {
            keyUpCommands.Text = string.Empty;
            keyDownCommands.Text = string.Empty;

            AcceptCommand.Enabled = false;
            RepeatCommand.Enabled = false;
            CancelCommand.Enabled = false;

            PressAndRelease.Visible = true;

            _newKey = new Key(_keyName);

            _keyManager.KeyStrokeReceivedEvent += ListenKeyboard;
            _keyManager.ListenKeyBoard();
        }

        private void FinishMapKey()
        {
            _keyManager.StopListenKeyBoard();
            _keyManager.KeyStrokeReceivedEvent -= ListenKeyboard;

            var stringBuilder = new StringBuilder();
            _newKey.KeyDownStrokes.ForEach(k => stringBuilder.AppendLine(string.Format("Code: 0x{0}, Info: {1}, State: {2}", k.code.ToString("X"), k.information, k.state)));
            keyDownCommands.Text = stringBuilder.ToString();

            stringBuilder = new StringBuilder();
            _newKey.KeyUpStrokes.ForEach(k => stringBuilder.AppendLine(string.Format("Code: 0x{0}, Info: {1}, State: {2}", k.code.ToString("X"), k.information, k.state)));
            keyUpCommands.Text = stringBuilder.ToString();

            AcceptCommand.Enabled = true;
            RepeatCommand.Enabled = true;
            CancelCommand.Enabled = true;

            PressAndRelease.Visible = false;

            if (_autoClose)
            {
                DialogResult = DialogResult.OK;
                Close();
            }

        }

        private void ListenKeyboard(KeystrokeReceivedEventArgs e)
        {
            KeyStroke keyStroke = e.KeyStroke;

            Debug.WriteLine(string.Format("Code: 0x{0}, Info: {1}, State: {2}", keyStroke.code.ToString("X"), keyStroke.information, keyStroke.state));
            
            if ((keyStroke.state & Keyboard.States.BREAK) == Keyboard.States.BREAK)
            {
                if (!_newKey.KeyUpStrokes.Contains(keyStroke))
                {
                    _newKey.KeyUpStrokes.Add(keyStroke);
                    Debug.WriteLine("KEY UP");
                }

                if (!timerRunnig)
                {
                    Debug.WriteLine("TIMER ACIONADO");
                    timerRunnig = true;
                    _timerKeyUp.Start();
                }
            }
            else
            {
                if (!_newKey.KeyDownStrokes.Contains(keyStroke))
                {
                    _newKey.KeyDownStrokes.Add(keyStroke);
                    Debug.WriteLine("KEY DOWN");
                }
            }
        }

        private void RepeatCommand_Click(object sender, EventArgs e)
        {
            StartMapKey();
        }

        public Key ShowDialog(IWin32Window owner, string KeyName, Boolean AutoClose)
        {
            _keyName = KeyName;
            _autoClose = AutoClose;

            ShowDialog(owner);
            if (DialogResult == DialogResult.OK)
            {
                return _newKey;
            }
            return null;
        }

        private void AcceptCommand_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelCommand_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

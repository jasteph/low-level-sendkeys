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

namespace low_level_sendkeys
{
    public partial class MapKey : Form
    {
        private Key _newKey;
        private readonly System.Timers.Timer _timerKeyUp;
        private bool timerRunnig;

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

            _newKey = new Key("TESTE");

            KeyboardManager.KeyStrokeReceivedEvent += ListenKeyboard;
            KeyboardManager.ListenKeyBoard();
        }

        private void FinishMapKey()
        {
            KeyboardManager.StopListenKeyBoard();
            KeyboardManager.KeyStrokeReceivedEvent -= ListenKeyboard;

            var stringBuilder = new StringBuilder();
            _newKey.KeyDownStrokes.ForEach(k => stringBuilder.AppendLine(string.Format("Code: {0}, Info: {1}, State: {2}", k.code, k.information, k.state)));
            keyDownCommands.Text = stringBuilder.ToString();

            stringBuilder = new StringBuilder();
            _newKey.KeyUpStrokes.ForEach(k => stringBuilder.AppendLine(string.Format("Code: {0}, Info: {1}, State: {2}", k.code, k.information, k.state)));
            keyUpCommands.Text = stringBuilder.ToString();

            AcceptCommand.Enabled = true;
            RepeatCommand.Enabled = true;
            CancelCommand.Enabled = true;

            PressAndRelease.Visible = false;

        }

        private void ListenKeyboard(KeystrokeReceivedEventArgs e)
        {
            foreach (var keyStroke in e.KeyboardStrokes)
            {
                Debug.WriteLine(string.Format("Code: {0}, Info: {1}, State: {2}", keyStroke.code, keyStroke.information, keyStroke.state));

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
        }

        private void RepeatCommand_Click(object sender, EventArgs e)
        {
            StartMapKey();
        }
    }
}

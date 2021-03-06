﻿using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using low_level_sendkeys.KernelHotkey;

namespace low_level_sendkeys
{

    internal class KeyboardManager
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        public delegate void KeyStrokeReceivedEventHandler(KeystrokeReceivedEventArgs e);
        public event KeyStrokeReceivedEventHandler KeyStrokeReceivedEvent;

        private KeystrokeReceivedEventArgs _eventArgs = new KeystrokeReceivedEventArgs();

        private Keyboard[] keyboards;
        public bool KeyboardListening { get; private set; }
        private Thread _threadKeyboardListen;

        private static int _firstKeyboardActive = 0;

        public KeyboardManager()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            keyboards = new Keyboard[10];
        }

        public void ListenKeyBoard()
        {
            if (KeyboardListening) return;

            for (int i = 0; i < 10; i++)
            {
                keyboards[i] = new Keyboard(i);
                keyboards[i].Filter = Keyboard.Filters.ALL;//Keyboard.Filters.MAKE | Keyboard.Filters.BREAK; // filtering only key-down and key-up
            }

            _threadKeyboardListen = new Thread(ListenKeyBoardExecute);
            _threadKeyboardListen.Start();

            while (!KeyboardListening) { }
        }

        public void StopListenKeyBoard()
        {
            if (!KeyboardListening) return;

            KeyboardListening = false;

            if (_threadKeyboardListen.IsAlive)
            {
                _threadKeyboardListen.Join(500);
            }

            if (_threadKeyboardListen.IsAlive)
            {
                _threadKeyboardListen.Abort();
            }

            for (int i = 0; i < 10; i++)
            {
                keyboards[i].FreeResources();
                keyboards[i] = null;
            }
        }

        private void ListenKeyBoardExecute()
        {
            KeyboardListening = true;

            Keyboard kbd;
            KeyStroke keystroke;


            while (KeyboardListening)
            {
                kbd = Keyboard.Wait(keyboards);
                if (kbd == null || !KeyboardListening) break;

                keystroke = kbd.Read();

                //Console.WriteLine("Code: 0x{0}, Information: {1}, State: {2}\n", keystroke.code.ToString("X"), keystroke.information, keystroke.state);
                _eventArgs.KeyBoardNumber = kbd.ID;
                _eventArgs.KeyStroke = keystroke;

                if (KeyStrokeReceivedEvent != null) KeyStrokeReceivedEvent(_eventArgs);

                if (_eventArgs.Handled)
                {
                    Keyboard localKbd = kbd;
                    _eventArgs.ReturnedKeystrokes.ForEach(ks => localKbd.Write(ks));
                    _eventArgs.ReturnedKeystrokes.Clear();
                }
                else
                {
                    kbd.Write(keystroke);
                }

                //if (keystroke.code == 0x2D)
                //{
                //    keystroke.code = 0x2A; // x becomes DOWN
                //    keystroke.information = 0;
                //    keystroke.state = keystroke.state = (Keyboard.States)3; //Keyboard.States.MAKE ? Keyboard.States.E0 : (Keyboard.States.BREAK + (ushort) Keyboard.States.E0);

                //    kbd.Write(keystroke);
                //    keystroke.code = 0x48; // x becomes DOWN
                //    kbd.Write(keystroke);
                //}
                //else
                //{
                //    kbd.Write(keystroke);
                //}
            }
        }

        public static void RefreshFirstActiveKeyboard()
        {
            GetConnectedKeyboard();
        }

        public static BitArray GetConnectedKeyboard()
        {
            var anyActive = false;

            var keyboardsStatus = new BitArray(10, false);

            var km = new KeyboardManager();
            var keyStroke = new KeyStroke();

            km.ListenKeyBoard();
            for (int i = 0; i < keyboardsStatus.Length; i++)
            {
                keyStroke.code = 42;
                keyStroke.state = Keyboard.States.MAKE;

                if (km.SendKeystroke(keyStroke, i))
                {
                    if (!anyActive)
                    {
                        anyActive = true;
                        _firstKeyboardActive = i;
                    }
                    //finish the keystroke
                    keyStroke.state = Keyboard.States.BREAK;
                    km.SendKeystroke(keyStroke, i);

                    keyboardsStatus[i] = true;
                }

            }
            km.StopListenKeyBoard();
            return keyboardsStatus;
        }

        public static bool NumLockOn()
        {
            return (((ushort)GetKeyState(0x90)) & 0xffff) != 0;
        }
        public static bool CapsLockOn()
        {
            return (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
        }
        public static bool ScrollLockOn()
        {
            return (((ushort)GetKeyState(0x91)) & 0xffff) != 0;
        }

        public bool SendKeystroke(KeyStroke keyStroke, int keyboardNumber)
        {
            bool result = keyboards[keyboardNumber].Write(keyStroke);
            Console.WriteLine("Enviei keystroke: {0}, id {1}, OK: {2}", keyStroke.ToString(), keyboardNumber, result);

            return result;
        }

        public static int FirstActiveKeyboard
        {
            get
            {
                return _firstKeyboardActive;
            }
        }
    }
}

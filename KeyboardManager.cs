using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using low_level_sendkeys.KernelHotkey;
using low_level_sendkeys.Keys;

namespace low_level_sendkeys
{

    internal static class KeyboardManager
    {
        public delegate void KeyStrokeReceivedEventHandler(KeystrokeReceivedEventArgs e);
        public static event KeyStrokeReceivedEventHandler KeyStrokeReceivedEvent;

        private static Keyboard[] keyboards;

        public static bool KeyboardListening { get; private set; }

        private static Thread _threadKeyboardListen;

        public static Keys.KeysList Keys = new KeysList();

        static KeyboardManager()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            keyboards = new Keyboard[10];

            for (int i = 0; i < 10; i++)
            {
                keyboards[i] = new Keyboard(i);
                keyboards[i].Filter = Keyboard.Filters.ALL;//Keyboard.Filters.MAKE | Keyboard.Filters.BREAK; // filtering only key-down and key-up
            }
        }

        public static void ListenKeyBoard()
        {
            if (KeyboardListening || KeyStrokeReceivedEvent == null) return;

            _threadKeyboardListen = new Thread(ListenKeyBoardExecute);
            _threadKeyboardListen.Start();
        }

        public static void StopListenKeyBoard()
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
        }

        public static void ListenKeyBoardExecute()
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
                var eventArgs = new KeystrokeReceivedEventArgs(kbd.ID, keystroke);
                KeyStrokeReceivedEvent(eventArgs);

                if (eventArgs.Handled)
                {
                    Keyboard localKbd = kbd;
                    eventArgs.KeyboardStrokes.ForEach(ks => localKbd.Write(ks));
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

        private static string GetDefaultKeysFileName()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;

            string fullPath = Path.GetDirectoryName(assemblyName);
            string fileName = Path.GetFileNameWithoutExtension(assemblyName);

            return Path.Combine(fullPath, fileName + ".keys");

        }

        public static void SaveKeyListToDisk()
        {
            SaveKeyListToDisk(GetDefaultKeysFileName());
        }
        public static void SaveKeyListToDisk(string fullPath)
        {
            using (var w = new StreamWriter(fullPath))
            {
                var s = new XmlSerializer(Keys.GetType());
                s.Serialize(w, Keys);
                w.Close();
            }
        }

        public static void LoadKeyListFromDisk()
        {
            LoadKeyListFromDisk(GetDefaultKeysFileName());
        }
        public static void LoadKeyListFromDisk(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                using (var sr = new StreamReader(fullPath))
                {
                    using (var xr = new XmlTextReader(sr))
                    {
                        var xs = new XmlSerializer(Keys.GetType());
                        if (xs.CanDeserialize(xr))
                        {
                            Keys = (KeysList)xs.Deserialize(xr);
                        }
                        xr.Close();
                    }
                    sr.Close();
                }
            }
        }
    }
}

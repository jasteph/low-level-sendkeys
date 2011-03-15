using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using low_level_sendkeys.KernelHotkey;
using low_level_sendkeys.Keys;

namespace low_level_sendkeys
{

    internal class KeyboardManager
    {
        public delegate void KeyStrokeReceivedEventHandler(KeystrokeReceivedEventArgs e);
        public  event KeyStrokeReceivedEventHandler KeyStrokeReceivedEvent;

        private KeystrokeReceivedEventArgs _eventArgs = new KeystrokeReceivedEventArgs();

        private  Keyboard[] keyboards;
        public  bool KeyboardListening { get; private set; }
        private  Thread _threadKeyboardListen;
        public static KeysList Keys = new KeysList();

        public KeyboardManager()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            keyboards = new Keyboard[10];
        }

        public void ListenKeyBoard()
        {
            if (KeyboardListening || KeyStrokeReceivedEvent == null) return;

            for (int i = 0; i < 10; i++)
            {
                keyboards[i] = new Keyboard(i);
                keyboards[i].Filter = Keyboard.Filters.ALL;//Keyboard.Filters.MAKE | Keyboard.Filters.BREAK; // filtering only key-down and key-up
            }

            _threadKeyboardListen = new Thread(ListenKeyBoardExecute);
            _threadKeyboardListen.Start();
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

        public void ListenKeyBoardExecute()
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
                    
                KeyStrokeReceivedEvent(_eventArgs);

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

        private string GetDefaultKeysFileName()
        {
            string assemblyName = Assembly.GetExecutingAssembly().Location;

            string fullPath = Path.GetDirectoryName(assemblyName);
            string fileName = Path.GetFileNameWithoutExtension(assemblyName);

            return Path.Combine(fullPath, fileName + ".keys");

        }

        public void SaveKeyListToDisk()
        {
            SaveKeyListToDisk(GetDefaultKeysFileName());
        }
        public void SaveKeyListToDisk(string fullPath)
        {
            using (var w = new StreamWriter(fullPath))
            {
                var s = new XmlSerializer(Keys.GetType());
                s.Serialize(w, Keys);
                w.Close();
            }
        }

        public void LoadKeyListFromDisk()
        {
            LoadKeyListFromDisk(GetDefaultKeysFileName());
        }
        public void LoadKeyListFromDisk(string fullPath)
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

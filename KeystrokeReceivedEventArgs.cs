using System.Collections.Generic;
using low_level_sendkeys.KernelHotkey;

namespace low_level_sendkeys
{
    public class KeystrokeReceivedEventArgs
    {
        public int KeyBoardNumber { get; internal set; }
        public KeyStroke KeyStroke { get; internal set; }

        public List<KeyStroke> ReturnedKeystrokes { get; internal set; }
        public bool Handled { get; set; }

        internal KeystrokeReceivedEventArgs()
        {
            ReturnedKeystrokes = new List<KeyStroke>();
        }

        //internal KeystrokeReceivedEventArgs(int keyboardNum, KeyStroke keyStroke)
        //{
        //    KeyBoardNumber = keyboardNum;
        //    ReturnedKeystrokes = new List<KeyStroke>(new[] { keyStroke });
        //}

    }
}
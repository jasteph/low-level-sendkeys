using System.Collections.Generic;
using low_level_sendkeys.KernelHotkey;

namespace low_level_sendkeys
{
    public class KeystrokeReceivedEventArgs
    {
        public int KeyBoardNumber { get; private set; }
        public List<KeyStroke> KeyboardStrokes { get; private set; }
        public bool Handled { get; set; }

        internal KeystrokeReceivedEventArgs(int keyboardNum, KeyStroke keyStroke)
        {
            KeyBoardNumber = keyboardNum;
            KeyboardStrokes = new List<KeyStroke>(new[] { keyStroke });
        }

    }
}
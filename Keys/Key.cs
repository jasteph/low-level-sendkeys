using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using low_level_sendkeys.KernelHotkey;

namespace low_level_sendkeys.Keys
{
    [Serializable]
    public class Key : ISerializable
    {
        public string Name { get; set; }
        public readonly List<KeyStroke> KeyDownStrokes;
        public readonly List<KeyStroke> KeyUpStrokes;

        public Key(string keyName)
        {
            Name = keyName;
            KeyDownStrokes = new List<KeyStroke>();
            KeyUpStrokes = new List<KeyStroke>();
        }

        private Key(SerializationInfo info, StreamingContext context)
        {
            KeyDownStrokes = new List<KeyStroke>();
            KeyUpStrokes = new List<KeyStroke>();

            Name = info.GetString("keyName");

            int totalKeyDown = info.GetInt32("TotalKeyDown");
            for (int i = 0; i < totalKeyDown; i++)
            {
                var ks = new KeyStroke();
                ks.code = info.GetUInt16("kd_c_" + i);
                ks.information = info.GetUInt32("kd_i_" + i);
                ks.state = (Keyboard.States)info.GetUInt16("kd_s_" + i);

                KeyDownStrokes.Add(ks);
            }

            int totalKeyUp = info.GetInt32("TotalKeyUp");
            for (int i = 0; i < totalKeyUp; i++)
            {
                var ks = new KeyStroke();
                ks.code = info.GetUInt16("ku_c_" + i);
                ks.information = info.GetUInt32("ku_i_" + i);
                ks.state = (Keyboard.States)info.GetUInt16("ku_s_" + i);

                KeyUpStrokes.Add(ks);
            }

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("keyName", Name);

            info.AddValue("TotalKeyDown", KeyDownStrokes.Count);
            for (int i = 0; i < KeyDownStrokes.Count; i++)
            {
                info.AddValue("kd_c_" + i, KeyDownStrokes[i].code, typeof(ushort));
                info.AddValue("kd_i_" + i, KeyDownStrokes[i].information, typeof(uint));
                info.AddValue("kd_s_" + i, KeyDownStrokes[i].state, typeof(ushort));
            }

            info.AddValue("TotalKeyUp", KeyUpStrokes.Count);
            for (int i = 0; i < KeyUpStrokes.Count; i++)
            {
                info.AddValue("ku_c_" + i, KeyUpStrokes[i].code, typeof(ushort));
                info.AddValue("ku_i_" + i, KeyUpStrokes[i].information, typeof(uint));
                info.AddValue("ku_s_" + i, KeyUpStrokes[i].state, typeof(ushort));
            }
        }
    }
}

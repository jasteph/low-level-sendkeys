using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using low_level_sendkeys.KernelHotkey;

namespace low_level_sendkeys.Keys
{
    [Serializable]
    public class Key : ISerializable, IComparable
    {
        public string Name { get; set; }
        public string InfoWindowsKeys { get; set; }
        public readonly List<KeyStroke> KeyDownStrokes;
        public readonly List<KeyStroke> KeyUpStrokes;

        public Key(string keyName)
        {
            Name = keyName;
            InfoWindowsKeys = string.Empty;
            KeyDownStrokes = new List<KeyStroke>();
            KeyUpStrokes = new List<KeyStroke>();
        }

        private Key(SerializationInfo info, StreamingContext context)
        {
            KeyDownStrokes = new List<KeyStroke>();
            KeyUpStrokes = new List<KeyStroke>();

            //int version = info.GetInt32("Version");

            Name = info.GetString("keyName");

            InfoWindowsKeys = info.GetString("InfoWindowsKeys");

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
            info.AddValue("Version", 1);
            info.AddValue("keyName", Name);
            info.AddValue("InfoWindowsKeys", InfoWindowsKeys);

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

        public int CompareTo(object obj)
        {
            var compareKey = obj as Key;
            if (compareKey == null) throw new ArgumentException("Object is not of 'Key' type");

            return Name.CompareTo(compareKey.Name);
        }
    }
}

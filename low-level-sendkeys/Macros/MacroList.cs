using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using low_level_sendkeys.Keys;

namespace low_level_sendkeys.Macros
{
    [Serializable]
    public class MacroList : List<Macro>, ISerializable
    {
        public MacroList() { }
        public MacroList(IEnumerable<Macro> initialList)
        {
            this.AddRange(initialList);
        }
        public MacroList(SerializationInfo info, StreamingContext context)
        {
            int totalKeyUp = info.GetInt32("TotalItens");
            for (int i = 0; i < totalKeyUp; i++)
            {
                Add((Macro)info.GetValue("macro" + i, typeof(Macro)));
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Version", 1);

            info.AddValue("TotalItens", this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                info.AddValue("macro" + i, this[i], typeof(Macro));
            }
        }
    }
}
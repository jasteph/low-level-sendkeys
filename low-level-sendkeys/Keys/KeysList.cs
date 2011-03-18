using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace low_level_sendkeys.Keys
{
    [Serializable]
    public class KeysList : List<Key>, ISerializable
    {
        public KeysList() { }
        public KeysList(IEnumerable<Key> initialList)
        {
            this.AddRange(initialList);
        }
        public KeysList(SerializationInfo info, StreamingContext context)
        {
            try
            {
                ConfiugurationName = info.GetString("ConfigurationName");
            }
            catch (SerializationException)
            {

            }

            int totalKeyUp = info.GetInt32("TotalItens");
            for (int i = 0; i < totalKeyUp; i++)
            {
                Add((Key)info.GetValue("key" + i, typeof(Key)));
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Version", 1);
            info.AddValue("ConfigurationName", ConfiugurationName);

            info.AddValue("TotalItens", this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                info.AddValue("key" + i, this[i], typeof(Key));
            }
        }

        public string ConfiugurationName { get; set; }
    }
}

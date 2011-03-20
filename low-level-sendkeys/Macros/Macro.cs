using System;
using System.Runtime.Serialization;

namespace low_level_sendkeys.Macros
{
    [Serializable]
    public class Macro : ISerializable
    {
        public string Name { get; set; }
        public string MacroCommand { get; set; }


        public Macro(string keyName)
        {
            Name = keyName;
        }

        private Macro(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("keyName");
            MacroCommand = info.GetString("macroCommand");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("version", 1);

            info.AddValue("keyName", Name);
            info.AddValue("macroCommand", MacroCommand);
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Macro: {1}", Name, MacroCommand);
        }

        public bool Equals(Macro other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && Equals(other.MacroCommand, MacroCommand);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Macro)) return false;
            return Equals((Macro) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.ToLower().GetHashCode() : 0) * 397) ^ (MacroCommand != null ? MacroCommand.ToLower().GetHashCode() : 0);
            }
        }
    }
}
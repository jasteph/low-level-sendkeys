using System.Text;

namespace low_level_sendkeys.KernelHotkey
{
    public class KeyStroke
    {
        public ushort code;
        public uint information;
        public Keyboard.States state;

        #region Equality Comparer

        public bool Equals(KeyStroke other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.code == code && other.information == information && Equals(other.state, state);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(KeyStroke)) return false;
            return Equals((KeyStroke)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = code.GetHashCode();
                result = (result * 397) ^ information.GetHashCode();
                result = (result * 397) ^ state.GetHashCode();
                return result;
            }
        } 

        #endregion

        public KeyStroke Clone()
        {
            var newKey = new KeyStroke()
                             {
                                 code = this.code,
                                 information = this.information,
                                 state = this.state
                             };

            return newKey;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Code: " + code);
            sb.Append(", Infomation: " + information);
            sb.Append(", State: ");

            if ((state & Keyboard.States.BREAK) == Keyboard.States.BREAK) sb.Append("BREAK, "); 
            if ((state & Keyboard.States.E0) == Keyboard.States.E0) sb.Append("E0, "); 
            if ((state & Keyboard.States.E1) == Keyboard.States.E1) sb.Append("E1, "); 
            if ((state & Keyboard.States.MAKE) == Keyboard.States.MAKE) sb.Append("MAKE, "); 
            if ((state & Keyboard.States.TERMSRV_SET_LED) == Keyboard.States.TERMSRV_SET_LED) sb.Append("TERMSRV_SET_LED, "); 
            if ((state & Keyboard.States.TERMSRV_SHADOW) == Keyboard.States.TERMSRV_SHADOW) sb.Append("TERMSRV_SHADOW, "); 
            if ((state & Keyboard.States.TERMSRV_VKPACKET) == Keyboard.States.TERMSRV_VKPACKET) sb.Append("TERMSRV_VKPACKET, ");

            return sb.ToString(0, sb.Length - 2);
        }
    }
}
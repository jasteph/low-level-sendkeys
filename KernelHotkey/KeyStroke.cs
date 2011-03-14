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
    }
}
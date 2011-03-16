using System.IO;
using System.Text;

namespace low_level_sendkeys.Comunnication
{
    public class NewLineReplaceStreamWriter : StreamWriter
    {

        public NewLineReplaceStreamWriter(Stream s)
            : base(s)
        { }

        public NewLineReplaceStreamWriter(Stream s, Encoding e)
            : base(s, e)
        { }
        public NewLineReplaceStreamWriter(Stream s, Encoding e, int i)
            : base(s, e, i)
        { }
        public NewLineReplaceStreamWriter(string s)
            : base(s)
        { }
        public NewLineReplaceStreamWriter(string s, bool b)
            : base(s, b)
        { }
        public NewLineReplaceStreamWriter(string s, bool b, Encoding e)
            : base(s, b, e)
        { }
        public NewLineReplaceStreamWriter(string s, bool b, Encoding e, int i)
            : base(s, b, e, i)
        { }

        public override void WriteLine(string value)
        {
            base.WriteLine(value.Replace("\n", base.NewLine));
        }

        public override void Write(string value)
        {
            base.Write(value.Replace("\n", base.NewLine));
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using low_level_sendkeys.KernelHotkey;

namespace low_level_sendkeys
{
    public partial class MakeCodeDialog : Form
    {
        public MakeCodeDialog()
        {
            InitializeComponent();

            MakeCodeStates.Items.Add(new ListItem(Keyboard.States.MAKE, "Pressed (MAKE)"));
            MakeCodeStates.Items.Add(new ListItem(Keyboard.States.BREAK, "Released (BREAK)"));
            MakeCodeStates.Items.Add(new ListItem(Keyboard.States.E0, "Extended 0 (E0)"));
            MakeCodeStates.Items.Add(new ListItem(Keyboard.States.E1, "Extended 1 (E1)"));
            MakeCodeStates.Items.Add(new ListItem(Keyboard.States.TERMSRV_SET_LED, "Set LED (TERMSRV_SET_LED)"));
            MakeCodeStates.Items.Add(new ListItem(Keyboard.States.TERMSRV_SHADOW, "Shadow (TERMSRV_SHADOW)"));
            MakeCodeStates.Items.Add(new ListItem(Keyboard.States.TERMSRV_VKPACKET, "VirtalKey Packet (TERMSRV_VKPACKET)"));

            FillFields();
        }

        private void OkCommand_Click(object sender, EventArgs e)
        {
            if (code.Text.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase))
            {
                KeyStroke.code = UInt16.Parse(code.Text.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            else
            {
                KeyStroke.code = UInt16.Parse(code.Text);
            }
            KeyStroke.information = Convert.ToUInt32(information.Text);
            KeyStroke.state = 0;

            for (int i = 0; i < MakeCodeStates.Items.Count; i++)
            {
                if (MakeCodeStates.GetItemChecked(i))
                {
                    var item = (ListItem)MakeCodeStates.Items[i];
                    _keyStroke.state = _keyStroke.state | item.State;
                }
            }


            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelCommand_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private KeyStroke _keyStroke = new KeyStroke();
        public KeyStroke KeyStroke
        {
            get { return _keyStroke; }
            set
            {
                _keyStroke = value;
                FillFields();
            }
        }

        private void FillFields()
        {
            code.Text = _keyStroke.code.ToString();
            information.Text = _keyStroke.information.ToString();


            if (_keyStroke.state == Keyboard.States.MAKE)
            {
                MakeCodeStates.SetItemChecked(0, true);
            }
            else
            {
                MakeCodeStates.SetItemChecked(0, false);

                for (int i = 1; i < MakeCodeStates.Items.Count; i++)
                {
                    var item = (ListItem)MakeCodeStates.Items[i];
                    MakeCodeStates.SetItemChecked(i, (_keyStroke.state & item.State) == item.State);
                }
            }



            //if (state == Keyboard.States.MAKE) sb.Append("MAKE, ");
            //if ((state & Keyboard.States.BREAK) == Keyboard.States.BREAK) sb.Append("BREAK, ");
            //if ((state & Keyboard.States.E0) == Keyboard.States.E0) sb.Append("E0, ");
            //if ((state & Keyboard.States.E1) == Keyboard.States.E1) sb.Append("E1, ");
            //if ((state & Keyboard.States.TERMSRV_SET_LED) == Keyboard.States.TERMSRV_SET_LED) sb.Append("TERMSRV_SET_LED, ");
            //if ((state & Keyboard.States.TERMSRV_SHADOW) == Keyboard.States.TERMSRV_SHADOW) sb.Append("TERMSRV_SHADOW, ");
            //if ((state & Keyboard.States.TERMSRV_VKPACKET) == Keyboard.States.TERMSRV_VKPACKET) sb.Append("TERMSRV_VKPACKET, ");
        }

        private class ListItem
        {
            public Keyboard.States State { get; private set; }
            public string DisplayName { get; private set; }

            public ListItem(Keyboard.States state, string displayName)
            {
                State = state;
                DisplayName = displayName;
            }
            public override string ToString()
            {
                return DisplayName;
            }
        }
    }
}

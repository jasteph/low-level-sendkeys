using System;
using System.Windows.Forms;

namespace low_level_sendkeys
{
    public partial class InputKeyName : Form
    {
        public InputKeyName()
        {
            InitializeComponent();
        }

        private void OkCommand_Click(object sender, EventArgs e)
        {
            ConfirmDialog();
        }

        private void ConfirmDialog()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelCommand_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void KeyName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void WindowsKeysDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                ConfirmDialog();
            }
        }
    }
}
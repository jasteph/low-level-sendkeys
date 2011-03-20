using System;
using System.Windows.Forms;

namespace low_level_sendkeys.Macros
{
    public partial class ConfigureMacro : Form
    {
        public ConfigureMacro()
        {
            InitializeComponent();
        }

        private void OkCommand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MacroName.Text))
            {
                MessageBox.Show(this,"Macro name not set","Configure Macro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(MacroCommand.Text))
            {
                MessageBox.Show(this, "Macro command not set", "Configure Macro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelCommand_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }


}

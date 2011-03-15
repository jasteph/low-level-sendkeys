using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using low_level_sendkeys.Keys;
using low_level_sendkeys.Properties;

namespace low_level_sendkeys
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = new MapKey();
            x.ShowDialog(this);
        }

        private void AddKeyCommand_Click(object sender, EventArgs e)
        {
            var inputKeyName = new InputKeyName();
            inputKeyName.ShowDialog(this);
            if (inputKeyName.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(inputKeyName.KeyName.Text))
            {
                if (KeyboardManager.Keys.Exists(k => k.Name.Equals(inputKeyName.KeyName.Text, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show(Texts.KeyNameAlreadyExists);
                }
                else
                {

                    var configureKeyDialog = new MapKey();
                    var newKey = configureKeyDialog.ShowDialog(this, inputKeyName.KeyName.Text);
                    if (newKey != null)
                    {
                        KeyboardManager.Keys.Add(newKey);
                        AddOrUpdateKeyNode(newKey);
                    }
                }
            }
        }

        private void AddOrUpdateKeyNode(Key key)
        {
            TreeNode treeNode = treeKeys.Nodes.OfType<TreeNode>().Where(k => k.Name.Equals(key.Name, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            if (treeNode == null)
            {
                treeNode = BuildNodeFromKey(key);
                treeKeys.Nodes.Add(treeNode);
            }
            else
            {
                var oldIndex = treeNode.Index;
                treeNode = BuildNodeFromKey(key);
                treeKeys.Nodes.RemoveAt(oldIndex);
                treeKeys.Nodes.Insert(oldIndex, treeNode);
            }

        }

        private TreeNode BuildNodeFromKey(Key key)
        {
            var treeNode = new TreeNode(key.Name)
                                    {
                                        Name = key.Name
                                    };

            var treeDown = new TreeNode("Pressed")
                               {
                                   Name = key.Name + "_Down"
                               };

            for (int i = 0; i < key.KeyDownStrokes.Count; i++)
            {
                var treeKeyStroke = new TreeNode(key.KeyDownStrokes[i].ToString());
                treeKeyStroke.Name = key.Name + "_Down" + i.ToString("00");
                treeDown.Nodes.Add(treeKeyStroke);
            }
            treeNode.Nodes.Add(treeDown);

            var treeUp = new TreeNode("Released")
                             {
                                 Name = key.Name + "_Up"
                             };
            for (int i = 0; i < key.KeyDownStrokes.Count; i++)
            {
                var treeKeyStroke = new TreeNode(key.KeyUpStrokes[i].ToString());
                treeKeyStroke.Name = key.Name + "_Up" + i.ToString("00");
                treeUp.Nodes.Add(treeKeyStroke);
            }
            treeNode.Nodes.Add(treeUp);

            return treeNode;
        }
    }
}

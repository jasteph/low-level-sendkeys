using System;
using System.Linq;
using System.Windows.Forms;
using low_level_sendkeys.Keys;
using low_level_sendkeys.Properties;
using low_level_sendkeys.KernelHotkey;

namespace low_level_sendkeys
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            KeyManager.Keys.ForEach(AddKeyNode);

            EnableButtons();
        }

        private void AddKeyCommand_Click(object sender, EventArgs e)
        {
            var inputKeyName = new InputKeyName();
            inputKeyName.ShowDialog(this);
            if (inputKeyName.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(inputKeyName.KeyName.Text))
            {
                if (KeyManager.Keys.Exists(k => k.Name.Equals(inputKeyName.KeyName.Text, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show(Texts.KeyNameAlreadyExists);
                }
                else
                {
                    var configureKeyDialog = new MapKey();
                    var newKey = configureKeyDialog.ShowDialog(this, inputKeyName.KeyName.Text, true);
                    if (newKey != null)
                    {
                        KeyManager.Keys.Add(newKey);
                        AddKeyNode(newKey);
                    }
                }
            }
        }

        private void UpdateKeyNode(Key key, string oldKeyName)
        {
            TreeNode treeNode = treeKeys.Nodes.OfType<TreeNode>().Where(k => k.Name.Equals(oldKeyName, StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();

            bool wasSelected = treeNode.IsSelected;
            bool wasExpanded = treeNode.IsExpanded;

            var oldIndex = treeNode.Index;
            treeNode = BuildNodeFromKey(key);

            if (wasExpanded) treeNode.Expand();

            treeKeys.Nodes.RemoveAt(oldIndex);
            treeKeys.Nodes.Insert(oldIndex, treeNode);
            if (wasSelected)
            {
                treeKeys.SelectedNode = treeNode;
            }
        }

        private void AddKeyNode(Key key)
        {
            TreeNode treeNode = BuildNodeFromKey(key);
            treeKeys.Nodes.Add(treeNode);
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
            treeDown.Expand();

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
            treeUp.Expand();

            for (int i = 0; i < key.KeyDownStrokes.Count; i++)
            {
                var treeKeyStroke = new TreeNode(key.KeyUpStrokes[i].ToString());
                treeKeyStroke.Name = key.Name + "_Up" + i.ToString("00");
                treeUp.Nodes.Add(treeKeyStroke);
            }
            treeNode.Nodes.Add(treeUp);

            return treeNode;
        }

        private void SaveAsCommand_Click(object sender, EventArgs e)
        {
            var x = new SaveFileDialog();
            x.Title = @"Export KeyList";
            x.Filter = @"KeyList files (*.keys)|*.keys";
            DialogResult result = x.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                KeyManager.SaveKeyListToDisk(x.FileName);
                MessageBox.Show(this, Texts.KeysExported);
            }
        }

        private void LoadCommand_Click(object sender, EventArgs e)
        {
            var x = new OpenFileDialog();
            x.Title = @"Import KeyList";
            x.Filter = @"KeyList files (*.keys)|*.keys";
            DialogResult result = x.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                KeyManager.LoadKeyListFromDisk(x.FileName);

                treeKeys.Nodes.Clear();
                KeyManager.Keys.ForEach(AddKeyNode);

                MessageBox.Show(this, Texts.KeysImported);
            }
        }

        private void treeKeys_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EnableButtons();
        }

        private void EnableButtons()
        {
            if (treeKeys.SelectedNode == null)
            {
                RemoveKeyCommand.Enabled = false;
                UpdateKeyCommand.Enabled = false;
                RenameKeyCommand.Enabled = false;
            }
            else
            {
                if (treeKeys.SelectedNode.Level == 0)
                {
                    RemoveKeyCommand.Enabled = true;
                    UpdateKeyCommand.Enabled = true;
                    RenameKeyCommand.Enabled = true;
                }
                else
                {
                    RemoveKeyCommand.Enabled = false;
                    UpdateKeyCommand.Enabled = false;
                    RenameKeyCommand.Enabled = false;
                }

                if (treeKeys.SelectedNode.Level == 1)
                {
                    AddMakeCommand.Enabled = true;
                    RemoveMakeCommand.Enabled = false;
                    ChangeMakeCommand.Enabled = false;
                }
                else if (treeKeys.SelectedNode.Level == 2)
                {
                    AddMakeCommand.Enabled = false;
                    RemoveMakeCommand.Enabled = true;
                    ChangeMakeCommand.Enabled = true;
                }
                else
                {
                    AddMakeCommand.Enabled = false;
                    RemoveMakeCommand.Enabled = false;
                    ChangeMakeCommand.Enabled = false;
                }
            }
        }

        private void RenameKeyCommand_Click(object sender, EventArgs e)
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 0)
            {
                EnableButtons();
                return;
            }

            string oldKeyName = treeKeys.SelectedNode.Name;

            var inputKeyName = new InputKeyName();

            inputKeyName.KeyName.Text = oldKeyName;

            inputKeyName.ShowDialog(this);
            string newKeyName = inputKeyName.KeyName.Text;

            if (inputKeyName.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(newKeyName) && newKeyName != oldKeyName)
            {
                if (KeyManager.Keys.Exists(k => k.Name.Equals(newKeyName, StringComparison.InvariantCultureIgnoreCase)))
                {
                    MessageBox.Show(string.Format("A key with a name '{0}' already exists.", newKeyName));
                }
                else
                {
                    var key = KeyManager.Keys.Single(k => k.Name.Equals(oldKeyName, StringComparison.InvariantCultureIgnoreCase));
                    key.Name = newKeyName;

                    UpdateKeyNode(key, oldKeyName);
                }

            }
        }

        private void UpdateKeyCommand_Click(object sender, EventArgs e)
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 0)
            {
                EnableButtons();
                return;
            }

            var configureKeyDialog = new MapKey();
            var newKey = configureKeyDialog.ShowDialog(this, treeKeys.SelectedNode.Name, false);
            if (newKey != null)
            {
                int index = KeyManager.Keys.IndexOf(KeyManager.Keys.Single(k => k.Name.Equals(treeKeys.SelectedNode.Name)));

                KeyManager.Keys.RemoveAt(index);
                KeyManager.Keys.Insert(index, newKey);
                UpdateKeyNode(newKey, newKey.Name);
            }

        }

        private void ChangeMakeCommand_Click(object sender, EventArgs e)
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 2)
            {
                EnableButtons();
                return;
            }

            int codeIndex = Convert.ToInt32(treeKeys.SelectedNode.Name.Substring(treeKeys.SelectedNode.Name.Length - 2, 2));
            bool isPressed = treeKeys.SelectedNode.Parent.Text.Equals("Pressed");
            string keyName = treeKeys.SelectedNode.Parent.Parent.Name;
            Key currentKey = KeyManager.Keys.Single(k => k.Name.Equals(keyName));

            KeyStroke ks;
            if (isPressed)
            {
                ks = currentKey.KeyDownStrokes[codeIndex];
            }
            else
            {
                ks = currentKey.KeyUpStrokes[codeIndex];
            }
            
            var configureKeyCode = new MakeCodeDialog();
            configureKeyCode.KeyStroke = ks;

            configureKeyCode.ShowDialog(this);

            if (configureKeyCode.DialogResult == DialogResult.OK)
            {
                treeKeys.SelectedNode.Text = configureKeyCode.KeyStroke.ToString();
            }
        }
    }
}

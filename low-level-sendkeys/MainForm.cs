using System;
using System.Linq;
using System.Windows.Forms;
using low_level_sendkeys.Keys;
using low_level_sendkeys.Macros;
using low_level_sendkeys.Properties;
using low_level_sendkeys.KernelHotkey;
using low_level_sendkeys.Comunnication;

namespace low_level_sendkeys
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            ConfigureMainForm();
        }

        public void ConfigureMainForm()
        {
            KeyManager.Keys.ForEach(AddKeyNode);
            RefreshMacrosList();

            EnableKeyButtons();
            EnableMacroButtons();
            FillConnectedKeyaboards();
        }

        private void RemoveKeyCommand_Click(object sender, EventArgs e)
        {
            RemoveSelectedKey();
        }

        private void RemoveSelectedKey()
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 0)
            {
                EnableKeyButtons();
                return;
            }

            KeyManager.Keys.Remove(KeyManager.Keys.Single(k => k.Name.Equals(treeKeys.SelectedNode.Name)));
            treeKeys.Nodes.RemoveByKey(treeKeys.SelectedNode.Name);
        }

        private void AddKeyCommand_Click(object sender, EventArgs e)
        {
            AddNewKey();
        }

        private void AddNewKey()
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
                    newKey.InfoWindowsKeys = inputKeyName.WindowsKeysDescription.Text;
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

            //treeNode.Expand();
            treeKeys.Nodes.Add(treeNode);
        }

        private static TreeNode BuildNodeFromKey(Key key)
        {
            var treeNode = new TreeNode(key.Name)
                                    {
                                        Name = key.Name,
                                        Text = string.Format("{0}{1}", key.Name, string.IsNullOrEmpty(key.InfoWindowsKeys) ? string.Empty : string.Format("      Description: {0}", key.InfoWindowsKeys))
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

            for (int i = 0; i < key.KeyUpStrokes.Count; i++)
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

        private void TreeKeysAfterSelect(object sender, TreeViewEventArgs e)
        {
            EnableKeyButtons();
        }

        private void EnableMacroButtons()
        {
            if (ListMacros.SelectedItem == null)
            {
                RemoveMacroCommand.Enabled = false;
                ChangeMacroCommand.Enabled = false;
                ExecuteSelectedMacroCommand.Enabled = false;
            }
            else
            {
                RemoveMacroCommand.Enabled = true;
                ChangeMacroCommand.Enabled = true;
                ExecuteSelectedMacroCommand.Enabled = true;
            }
        }

        private void EnableKeyButtons()
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
            RenameSelectedKey();
        }

        private void RenameSelectedKey()
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 0)
            {
                EnableKeyButtons();
                return;
            }

            var currentKey = KeyManager.Keys.Single(k => k.Name.Equals(treeKeys.SelectedNode.Name));

            var inputKeyName = new InputKeyName
                                   {
                                       KeyName = { Text = currentKey.Name },
                                       WindowsKeysDescription = { Text = currentKey.InfoWindowsKeys }
                                   };

            inputKeyName.ShowDialog(this);
            string newKeyName = inputKeyName.KeyName.Text;
            string newWindowsKeysDescription = inputKeyName.WindowsKeysDescription.Text;

            if (inputKeyName.DialogResult == DialogResult.OK && !string.IsNullOrEmpty(newKeyName) && (newKeyName != currentKey.Name || newWindowsKeysDescription != currentKey.InfoWindowsKeys))
            {
                if (KeyManager.Keys.Exists(k => !k.Equals(currentKey) && k.Name.Equals(newKeyName, StringComparison.InvariantCultureIgnoreCase)))
                {
                    MessageBox.Show(string.Format("A key with a name '{0}' already exists.", newKeyName));
                }
                else
                {
                    var oldKeyName = currentKey.Name;
                    currentKey.Name = newKeyName;
                    currentKey.InfoWindowsKeys = newWindowsKeysDescription;

                    UpdateKeyNode(currentKey, oldKeyName);
                }

            }
        }

        private void UpdateKeyCommand_Click(object sender, EventArgs e)
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 0)
            {
                EnableKeyButtons();
                return;
            }

            var configureKeyDialog = new MapKey();
            var newKey = configureKeyDialog.ShowDialog(this, treeKeys.SelectedNode.Name, false);
            if (newKey != null)
            {
                int index = KeyManager.Keys.IndexOf(KeyManager.Keys.Single(k => k.Name.Equals(treeKeys.SelectedNode.Name)));

                newKey.InfoWindowsKeys = KeyManager.Keys[index].InfoWindowsKeys;
                KeyManager.Keys.RemoveAt(index);
                KeyManager.Keys.Insert(index, newKey);
                UpdateKeyNode(newKey, newKey.Name);
            }

        }

        private void ChangeMakeCommand_Click(object sender, EventArgs e)
        {
            ChangeSelectedMakeCommand();
        }

        private void ChangeSelectedMakeCommand()
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 2)
            {
                EnableKeyButtons();
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

        private void AddMakeCommand_Click(object sender, EventArgs e)
        {
            AddMakeCommandToSelectedKey();
        }

        private void AddMakeCommandToSelectedKey()
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 1)
            {
                EnableKeyButtons();
                return;
            }

            bool isPressed = treeKeys.SelectedNode.Text.Equals("Pressed");
            string keyName = treeKeys.SelectedNode.Parent.Name;
            Key currentKey = KeyManager.Keys.Single(k => k.Name.Equals(keyName));


            var configureKeyCode = new MakeCodeDialog();
            configureKeyCode.KeyStroke = new KeyStroke();

            configureKeyCode.ShowDialog(this);

            if (configureKeyCode.DialogResult == DialogResult.OK)
            {

                if (isPressed)
                {
                    currentKey.KeyDownStrokes.Add(configureKeyCode.KeyStroke.Clone());
                }
                else
                {
                    currentKey.KeyUpStrokes.Add(configureKeyCode.KeyStroke.Clone());
                }
                UpdateKeyNode(currentKey, currentKey.Name);
            }
        }

        private void RemoveMakeCommand_Click(object sender, EventArgs e)
        {
            RemoveMakeCommandFromSelectedKey();
        }

        private void RemoveMakeCommandFromSelectedKey()
        {
            if (treeKeys.SelectedNode == null || treeKeys.SelectedNode.Level != 2)
            {
                EnableKeyButtons();
                return;
            }

            int codeIndex = Convert.ToInt32(treeKeys.SelectedNode.Name.Substring(treeKeys.SelectedNode.Name.Length - 2, 2));
            bool isPressed = treeKeys.SelectedNode.Parent.Text.Equals("Pressed");
            string keyName = treeKeys.SelectedNode.Parent.Parent.Name;
            Key currentKey = KeyManager.Keys.Single(k => k.Name.Equals(keyName));

            if (isPressed)
            {
                currentKey.KeyDownStrokes.RemoveAt(codeIndex);
            }
            else
            {
                currentKey.KeyUpStrokes.RemoveAt(codeIndex);
            }

            UpdateKeyNode(currentKey, currentKey.Name);
        }

        private void TreeKeysDoubleClick(object sender, EventArgs e)
        {
            if (treeKeys.SelectedNode != null && treeKeys.SelectedNode.Level == 2)
            {
                ChangeSelectedMakeCommand();
            }
        }

        private void TreeKeysKeyUp(object sender, KeyEventArgs e)
        {
            if (treeKeys.SelectedNode == null) return;

            if (e.KeyCode == System.Windows.Forms.Keys.F2)
            {
                switch (treeKeys.SelectedNode.Level)
                {
                    case 0:
                        RenameSelectedKey();
                        break;
                    case 2:
                        ChangeSelectedMakeCommand();
                        break;
                }
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Insert)
            {
                switch (treeKeys.SelectedNode.Level)
                {
                    case 0:
                        AddNewKey();
                        break;
                    case 1:
                        AddMakeCommandToSelectedKey();
                        break;
                }
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Delete)
            {
                switch (treeKeys.SelectedNode.Level)
                {
                    case 0:
                        RemoveSelectedKey();
                        break;
                    case 2:
                        RemoveMakeCommandFromSelectedKey();
                        break;
                }
            }
        }

        private void Button1Click(object sender, EventArgs e)
        {
            SendRawKeys.SendKeys(SendCommands.Text, false);
        }

        private void CheckKeyboardsCommand_Click(object sender, EventArgs e)
        {
            KeyboardManager.RefreshFirstActiveKeyboard();
            FillConnectedKeyaboards();
        }

        private void FillConnectedKeyaboards()
        {
            var keyboardStatus = KeyboardManager.GetConnectedKeyboard();

            for (int i = 0; i < keyboardStatus.Count; i++)
            {
                tabPage2.Controls["Keyboard" + i].Text = string.Format("Keyboard {0}: {1}", i, keyboardStatus[i] ? "Connected" : "Disconnected");
                tabPage2.Controls["Keyboard" + i].ForeColor = keyboardStatus[i] ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RestoreWindow();
        }

        private void TrayIconContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "CloseApplicationContextMenu")
            {
                CommunicationBridge.UnloadApplication();
            }
        }

        private void MinimizeToTrayCommand_Click(object sender, EventArgs e)
        {
            MinimizeToTray();
        }

        public void RestoreWindow()
        {
            TrayIcon.Visible = false;
            Show();
        }

        public void MinimizeToTray()
        {
            TrayIcon.Visible = true;
            Hide();
        }

        protected override void SetVisibleCore(bool value)
        {
            if (TrayIcon.Visible) value = false;
            base.SetVisibleCore(value);
        }

        private void AddMacroCommand_Click(object sender, EventArgs e)
        {
            var configureMacro = new ConfigureMacro();
            configureMacro.ShowDialog(this);
            if (configureMacro.DialogResult == DialogResult.OK)
            {
                if (MacroManager.Macros.Exists(m => m.Name.Equals(configureMacro.MacroName.Text, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show(string.Format("Macro with name {0} already exists", configureMacro.MacroName.Text));
                }
                else
                {
                    var newMacro = new Macro(configureMacro.MacroName.Text)
                    {
                        MacroCommand = configureMacro.MacroCommand.Text
                    };
                    MacroManager.Macros.Add(newMacro);
                    RefreshMacrosList();
                }
            }
        }

        private void RemoveMacroCommand_Click(object sender, EventArgs e)
        {
            if (ListMacros.SelectedItem == null)
            {
                EnableMacroButtons();
                return;
            }
            MacroManager.Macros.Remove((Macro)ListMacros.SelectedItem);
        }

        private void ListMacros_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableMacroButtons();
        }

        private void ChangeMacroCommand_Click(object sender, EventArgs e)
        {
            ChangeMacro();
        }

        private void ChangeMacro()
        {
            if (ListMacros.SelectedItem == null)
            {
                EnableMacroButtons();
                return;
            }

            var changeMacro = (Macro)ListMacros.SelectedItem;

            var configureMacro = new ConfigureMacro
                                     {
                                         MacroName = { Text = changeMacro.Name },
                                         MacroCommand = { Text = changeMacro.MacroCommand }
                                     };


            configureMacro.ShowDialog(this);
            if (configureMacro.DialogResult == DialogResult.OK)
            {
                if (MacroManager.Macros.Exists(m => !m.Equals(changeMacro) && m.Name.Equals(configureMacro.MacroName.Text, StringComparison.CurrentCultureIgnoreCase)))
                {
                    MessageBox.Show(string.Format("Macro with name {0} already exists", configureMacro.MacroName.Text));
                }
                else
                {
                    changeMacro.Name = configureMacro.MacroName.Text;
                    changeMacro.MacroCommand = configureMacro.MacroCommand.Text;
                }
            }

            RefreshMacrosList();
        }

        private void RefreshMacrosList()
        {
            var selectedMacro = (Macro)ListMacros.SelectedItem;
            ListMacros.Items.Clear();
            MacroManager.Macros.ForEach(m => ListMacros.Items.Add(m));
            ListMacros.SelectedItem = selectedMacro;
        }

        private void ExportMacrosCommand_Click(object sender, EventArgs e)
        {
            var x = new SaveFileDialog();
            x.Title = @"Export Macros";
            x.Filter = @"KeyMacros files (*.macros)|*.macros";
            DialogResult result = x.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                MacroManager.SaveMacroListToDisk(x.FileName);
                MessageBox.Show(this, Texts.MacrosExported);
            }
        }

        private void ImportMacrosCommand_Click(object sender, EventArgs e)
        {
            var x = new OpenFileDialog();
            x.Title = @"Import Macros";
            x.Filter = @"KeyMacros files (*.macros)|*.macros";
            DialogResult result = x.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                MacroManager.LoadMacroListFromDisk(x.FileName);

                RefreshMacrosList();

                MessageBox.Show(this, Texts.MacrosImported);
            }
        }


        private void ListMacros_DoubleClick(object sender, EventArgs e)
        {
            ChangeMacro();
        }

        private void SortKeys_Click(object sender, EventArgs e)
        {
            KeyManager.Keys.Sort();

            treeKeys.Nodes.Clear();
            KeyManager.Keys.ForEach(AddKeyNode);
        }

        private void ExecuteSelectedMacroCommand_Click(object sender, EventArgs e)
        {
            if (ListMacros.SelectedItem == null)
            {
                EnableMacroButtons();
                return;
            }

            SendRawKeys.SendMacro(((Macro)ListMacros.SelectedItem).Name);
        }

        private void TestSendKeysCommand_Click(object sender, EventArgs e)
        {
            SendRawKeys.SendKeys(SendCommands.Text, false);
        }
    }
}
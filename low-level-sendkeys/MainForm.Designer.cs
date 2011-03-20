namespace low_level_sendkeys
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UpdateKeyCommand = new System.Windows.Forms.Button();
            this.treeKeys = new System.Windows.Forms.TreeView();
            this.AddKeyCommand = new System.Windows.Forms.Button();
            this.SaveAsCommand = new System.Windows.Forms.Button();
            this.LoadCommand = new System.Windows.Forms.Button();
            this.RemoveKeyCommand = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RenameKeyCommand = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChangeMakeCommand = new System.Windows.Forms.Button();
            this.AddMakeCommand = new System.Windows.Forms.Button();
            this.RemoveMakeCommand = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ExportMacrosCommand = new System.Windows.Forms.Button();
            this.ImportMacrosCommand = new System.Windows.Forms.Button();
            this.AddMacroCommand = new System.Windows.Forms.Button();
            this.RemoveMacroCommand = new System.Windows.Forms.Button();
            this.ListMacros = new System.Windows.Forms.ListBox();
            this.ChangeMacroCommand = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CheckKeyboardsCommand = new System.Windows.Forms.Button();
            this.Keyboard9 = new System.Windows.Forms.Label();
            this.Keyboard8 = new System.Windows.Forms.Label();
            this.Keyboard7 = new System.Windows.Forms.Label();
            this.Keyboard6 = new System.Windows.Forms.Label();
            this.Keyboard5 = new System.Windows.Forms.Label();
            this.Keyboard4 = new System.Windows.Forms.Label();
            this.Keyboard3 = new System.Windows.Forms.Label();
            this.Keyboard2 = new System.Windows.Forms.Label();
            this.Keyboard1 = new System.Windows.Forms.Label();
            this.Keyboard0 = new System.Windows.Forms.Label();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CloseApplicationContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeToTrayCommand = new System.Windows.Forms.Button();
            this.SortKeys = new System.Windows.Forms.Button();
            this.TestSendKeysCommand = new System.Windows.Forms.Button();
            this.SendCommands = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ExecuteSelectedMacroCommand = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TrayIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateKeyCommand
            // 
            this.UpdateKeyCommand.Location = new System.Drawing.Point(6, 54);
            this.UpdateKeyCommand.Name = "UpdateKeyCommand";
            this.UpdateKeyCommand.Size = new System.Drawing.Size(79, 29);
            this.UpdateKeyCommand.TabIndex = 0;
            this.UpdateKeyCommand.Text = "UpdateKey";
            this.UpdateKeyCommand.UseVisualStyleBackColor = true;
            this.UpdateKeyCommand.Click += new System.EventHandler(this.UpdateKeyCommand_Click);
            // 
            // treeKeys
            // 
            this.treeKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeKeys.HideSelection = false;
            this.treeKeys.Location = new System.Drawing.Point(6, 6);
            this.treeKeys.Name = "treeKeys";
            this.treeKeys.Size = new System.Drawing.Size(522, 383);
            this.treeKeys.TabIndex = 1;
            this.treeKeys.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeKeysAfterSelect);
            this.treeKeys.DoubleClick += new System.EventHandler(this.TreeKeysDoubleClick);
            this.treeKeys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TreeKeysKeyUp);
            // 
            // AddKeyCommand
            // 
            this.AddKeyCommand.Location = new System.Drawing.Point(6, 19);
            this.AddKeyCommand.Name = "AddKeyCommand";
            this.AddKeyCommand.Size = new System.Drawing.Size(79, 29);
            this.AddKeyCommand.TabIndex = 2;
            this.AddKeyCommand.Text = "Add Key";
            this.AddKeyCommand.UseVisualStyleBackColor = true;
            this.AddKeyCommand.Click += new System.EventHandler(this.AddKeyCommand_Click);
            // 
            // SaveAsCommand
            // 
            this.SaveAsCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveAsCommand.Location = new System.Drawing.Point(442, 420);
            this.SaveAsCommand.Name = "SaveAsCommand";
            this.SaveAsCommand.Size = new System.Drawing.Size(86, 23);
            this.SaveAsCommand.TabIndex = 3;
            this.SaveAsCommand.Text = "Export KeyList";
            this.SaveAsCommand.UseVisualStyleBackColor = true;
            this.SaveAsCommand.Click += new System.EventHandler(this.SaveAsCommand_Click);
            // 
            // LoadCommand
            // 
            this.LoadCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadCommand.Location = new System.Drawing.Point(442, 452);
            this.LoadCommand.Name = "LoadCommand";
            this.LoadCommand.Size = new System.Drawing.Size(86, 23);
            this.LoadCommand.TabIndex = 4;
            this.LoadCommand.Text = "Import KeyList";
            this.LoadCommand.UseVisualStyleBackColor = true;
            this.LoadCommand.Click += new System.EventHandler(this.LoadCommand_Click);
            // 
            // RemoveKeyCommand
            // 
            this.RemoveKeyCommand.Location = new System.Drawing.Point(91, 19);
            this.RemoveKeyCommand.Name = "RemoveKeyCommand";
            this.RemoveKeyCommand.Size = new System.Drawing.Size(80, 29);
            this.RemoveKeyCommand.TabIndex = 5;
            this.RemoveKeyCommand.Text = "Remove Key";
            this.RemoveKeyCommand.UseVisualStyleBackColor = true;
            this.RemoveKeyCommand.Click += new System.EventHandler(this.RemoveKeyCommand_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.RenameKeyCommand);
            this.groupBox1.Controls.Add(this.AddKeyCommand);
            this.groupBox1.Controls.Add(this.RemoveKeyCommand);
            this.groupBox1.Controls.Add(this.UpdateKeyCommand);
            this.groupBox1.Location = new System.Drawing.Point(6, 395);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 90);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Keys Commands";
            // 
            // RenameKeyCommand
            // 
            this.RenameKeyCommand.Location = new System.Drawing.Point(92, 54);
            this.RenameKeyCommand.Name = "RenameKeyCommand";
            this.RenameKeyCommand.Size = new System.Drawing.Size(79, 29);
            this.RenameKeyCommand.TabIndex = 6;
            this.RenameKeyCommand.Text = "Rename Key";
            this.RenameKeyCommand.UseVisualStyleBackColor = true;
            this.RenameKeyCommand.Click += new System.EventHandler(this.RenameKeyCommand_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.ChangeMakeCommand);
            this.groupBox2.Controls.Add(this.AddMakeCommand);
            this.groupBox2.Controls.Add(this.RemoveMakeCommand);
            this.groupBox2.Location = new System.Drawing.Point(189, 395);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 90);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Make Commands";
            // 
            // ChangeMakeCommand
            // 
            this.ChangeMakeCommand.Location = new System.Drawing.Point(6, 54);
            this.ChangeMakeCommand.Name = "ChangeMakeCommand";
            this.ChangeMakeCommand.Size = new System.Drawing.Size(114, 29);
            this.ChangeMakeCommand.TabIndex = 9;
            this.ChangeMakeCommand.Text = "Change Command";
            this.ChangeMakeCommand.UseVisualStyleBackColor = true;
            this.ChangeMakeCommand.Click += new System.EventHandler(this.ChangeMakeCommand_Click);
            // 
            // AddMakeCommand
            // 
            this.AddMakeCommand.Location = new System.Drawing.Point(6, 19);
            this.AddMakeCommand.Name = "AddMakeCommand";
            this.AddMakeCommand.Size = new System.Drawing.Size(114, 29);
            this.AddMakeCommand.TabIndex = 7;
            this.AddMakeCommand.Text = "Add Command";
            this.AddMakeCommand.UseVisualStyleBackColor = true;
            this.AddMakeCommand.Click += new System.EventHandler(this.AddMakeCommand_Click);
            // 
            // RemoveMakeCommand
            // 
            this.RemoveMakeCommand.Location = new System.Drawing.Point(126, 19);
            this.RemoveMakeCommand.Name = "RemoveMakeCommand";
            this.RemoveMakeCommand.Size = new System.Drawing.Size(114, 29);
            this.RemoveMakeCommand.TabIndex = 8;
            this.RemoveMakeCommand.Text = "Remove Command";
            this.RemoveMakeCommand.UseVisualStyleBackColor = true;
            this.RemoveMakeCommand.Click += new System.EventHandler(this.RemoveMakeCommand_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 550);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TestSendKeysCommand);
            this.tabPage1.Controls.Add(this.SendCommands);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SortKeys);
            this.tabPage1.Controls.Add(this.treeKeys);
            this.tabPage1.Controls.Add(this.SaveAsCommand);
            this.tabPage1.Controls.Add(this.LoadCommand);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(534, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Key Configuration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ExecuteSelectedMacroCommand);
            this.tabPage3.Controls.Add(this.ExportMacrosCommand);
            this.tabPage3.Controls.Add(this.ImportMacrosCommand);
            this.tabPage3.Controls.Add(this.AddMacroCommand);
            this.tabPage3.Controls.Add(this.RemoveMacroCommand);
            this.tabPage3.Controls.Add(this.ListMacros);
            this.tabPage3.Controls.Add(this.ChangeMacroCommand);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(534, 524);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Macro Configuration";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ExportMacrosCommand
            // 
            this.ExportMacrosCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportMacrosCommand.Location = new System.Drawing.Point(442, 454);
            this.ExportMacrosCommand.Name = "ExportMacrosCommand";
            this.ExportMacrosCommand.Size = new System.Drawing.Size(86, 29);
            this.ExportMacrosCommand.TabIndex = 9;
            this.ExportMacrosCommand.Text = "Export Macros";
            this.ExportMacrosCommand.UseVisualStyleBackColor = true;
            this.ExportMacrosCommand.Click += new System.EventHandler(this.ExportMacrosCommand_Click);
            // 
            // ImportMacrosCommand
            // 
            this.ImportMacrosCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportMacrosCommand.Location = new System.Drawing.Point(442, 489);
            this.ImportMacrosCommand.Name = "ImportMacrosCommand";
            this.ImportMacrosCommand.Size = new System.Drawing.Size(86, 29);
            this.ImportMacrosCommand.TabIndex = 10;
            this.ImportMacrosCommand.Text = "Import Macros";
            this.ImportMacrosCommand.UseVisualStyleBackColor = true;
            this.ImportMacrosCommand.Click += new System.EventHandler(this.ImportMacrosCommand_Click);
            // 
            // AddMacroCommand
            // 
            this.AddMacroCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddMacroCommand.Location = new System.Drawing.Point(6, 489);
            this.AddMacroCommand.Name = "AddMacroCommand";
            this.AddMacroCommand.Size = new System.Drawing.Size(92, 29);
            this.AddMacroCommand.TabIndex = 2;
            this.AddMacroCommand.Text = "Add Macro";
            this.AddMacroCommand.UseVisualStyleBackColor = true;
            this.AddMacroCommand.Click += new System.EventHandler(this.AddMacroCommand_Click);
            // 
            // RemoveMacroCommand
            // 
            this.RemoveMacroCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveMacroCommand.Location = new System.Drawing.Point(6, 454);
            this.RemoveMacroCommand.Name = "RemoveMacroCommand";
            this.RemoveMacroCommand.Size = new System.Drawing.Size(92, 29);
            this.RemoveMacroCommand.TabIndex = 5;
            this.RemoveMacroCommand.Text = "Remove Macro";
            this.RemoveMacroCommand.UseVisualStyleBackColor = true;
            this.RemoveMacroCommand.Click += new System.EventHandler(this.RemoveMacroCommand_Click);
            // 
            // ListMacros
            // 
            this.ListMacros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ListMacros.FormattingEnabled = true;
            this.ListMacros.Location = new System.Drawing.Point(6, 6);
            this.ListMacros.Name = "ListMacros";
            this.ListMacros.Size = new System.Drawing.Size(522, 446);
            this.ListMacros.TabIndex = 8;
            this.ListMacros.SelectedIndexChanged += new System.EventHandler(this.ListMacros_SelectedIndexChanged);
            this.ListMacros.DoubleClick += new System.EventHandler(this.ListMacros_DoubleClick);
            // 
            // ChangeMacroCommand
            // 
            this.ChangeMacroCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChangeMacroCommand.Location = new System.Drawing.Point(104, 477);
            this.ChangeMacroCommand.Name = "ChangeMacroCommand";
            this.ChangeMacroCommand.Size = new System.Drawing.Size(95, 29);
            this.ChangeMacroCommand.TabIndex = 0;
            this.ChangeMacroCommand.Text = "Change Macro";
            this.ChangeMacroCommand.UseVisualStyleBackColor = true;
            this.ChangeMacroCommand.Click += new System.EventHandler(this.ChangeMacroCommand_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CheckKeyboardsCommand);
            this.tabPage2.Controls.Add(this.Keyboard9);
            this.tabPage2.Controls.Add(this.Keyboard8);
            this.tabPage2.Controls.Add(this.Keyboard7);
            this.tabPage2.Controls.Add(this.Keyboard6);
            this.tabPage2.Controls.Add(this.Keyboard5);
            this.tabPage2.Controls.Add(this.Keyboard4);
            this.tabPage2.Controls.Add(this.Keyboard3);
            this.tabPage2.Controls.Add(this.Keyboard2);
            this.tabPage2.Controls.Add(this.Keyboard1);
            this.tabPage2.Controls.Add(this.Keyboard0);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(534, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Keyboard Information";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CheckKeyboardsCommand
            // 
            this.CheckKeyboardsCommand.Location = new System.Drawing.Point(220, 20);
            this.CheckKeyboardsCommand.Name = "CheckKeyboardsCommand";
            this.CheckKeyboardsCommand.Size = new System.Drawing.Size(110, 23);
            this.CheckKeyboardsCommand.TabIndex = 10;
            this.CheckKeyboardsCommand.Text = "Detect Keyboards";
            this.CheckKeyboardsCommand.UseVisualStyleBackColor = true;
            this.CheckKeyboardsCommand.Click += new System.EventHandler(this.CheckKeyboardsCommand_Click);
            // 
            // Keyboard9
            // 
            this.Keyboard9.AutoSize = true;
            this.Keyboard9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard9.Location = new System.Drawing.Point(17, 233);
            this.Keyboard9.Name = "Keyboard9";
            this.Keyboard9.Size = new System.Drawing.Size(157, 13);
            this.Keyboard9.TabIndex = 9;
            this.Keyboard9.Text = "Keyboard 0: Disconnected";
            // 
            // Keyboard8
            // 
            this.Keyboard8.AutoSize = true;
            this.Keyboard8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard8.Location = new System.Drawing.Point(17, 209);
            this.Keyboard8.Name = "Keyboard8";
            this.Keyboard8.Size = new System.Drawing.Size(157, 13);
            this.Keyboard8.TabIndex = 8;
            this.Keyboard8.Text = "Keyboard 0: Disconnected";
            // 
            // Keyboard7
            // 
            this.Keyboard7.AutoSize = true;
            this.Keyboard7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard7.Location = new System.Drawing.Point(17, 185);
            this.Keyboard7.Name = "Keyboard7";
            this.Keyboard7.Size = new System.Drawing.Size(157, 13);
            this.Keyboard7.TabIndex = 7;
            this.Keyboard7.Text = "Keyboard 0: Disconnected";
            // 
            // Keyboard6
            // 
            this.Keyboard6.AutoSize = true;
            this.Keyboard6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard6.Location = new System.Drawing.Point(17, 161);
            this.Keyboard6.Name = "Keyboard6";
            this.Keyboard6.Size = new System.Drawing.Size(157, 13);
            this.Keyboard6.TabIndex = 6;
            this.Keyboard6.Text = "Keyboard 0: Disconnected";
            // 
            // Keyboard5
            // 
            this.Keyboard5.AutoSize = true;
            this.Keyboard5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard5.Location = new System.Drawing.Point(17, 136);
            this.Keyboard5.Name = "Keyboard5";
            this.Keyboard5.Size = new System.Drawing.Size(157, 13);
            this.Keyboard5.TabIndex = 5;
            this.Keyboard5.Text = "Keyboard 0: Disconnected";
            // 
            // Keyboard4
            // 
            this.Keyboard4.AutoSize = true;
            this.Keyboard4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard4.Location = new System.Drawing.Point(17, 113);
            this.Keyboard4.Name = "Keyboard4";
            this.Keyboard4.Size = new System.Drawing.Size(157, 13);
            this.Keyboard4.TabIndex = 4;
            this.Keyboard4.Text = "Keyboard 0: Disconnected";
            // 
            // Keyboard3
            // 
            this.Keyboard3.AutoSize = true;
            this.Keyboard3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard3.Location = new System.Drawing.Point(17, 91);
            this.Keyboard3.Name = "Keyboard3";
            this.Keyboard3.Size = new System.Drawing.Size(157, 13);
            this.Keyboard3.TabIndex = 3;
            this.Keyboard3.Text = "Keyboard 0: Disconnected";
            // 
            // Keyboard2
            // 
            this.Keyboard2.AutoSize = true;
            this.Keyboard2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard2.Location = new System.Drawing.Point(17, 68);
            this.Keyboard2.Name = "Keyboard2";
            this.Keyboard2.Size = new System.Drawing.Size(157, 13);
            this.Keyboard2.TabIndex = 2;
            this.Keyboard2.Text = "Keyboard 1: Disconnected";
            // 
            // Keyboard1
            // 
            this.Keyboard1.AutoSize = true;
            this.Keyboard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard1.Location = new System.Drawing.Point(17, 44);
            this.Keyboard1.Name = "Keyboard1";
            this.Keyboard1.Size = new System.Drawing.Size(157, 13);
            this.Keyboard1.TabIndex = 1;
            this.Keyboard1.Text = "Keyboard 1: Disconnected";
            // 
            // Keyboard0
            // 
            this.Keyboard0.AutoSize = true;
            this.Keyboard0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Keyboard0.Location = new System.Drawing.Point(17, 20);
            this.Keyboard0.Name = "Keyboard0";
            this.Keyboard0.Size = new System.Drawing.Size(157, 13);
            this.Keyboard0.TabIndex = 0;
            this.Keyboard0.Text = "Keyboard 0: Disconnected";
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayIconContextMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Low Level SendKeys";
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // TrayIconContextMenu
            // 
            this.TrayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseApplicationContextMenu});
            this.TrayIconContextMenu.Name = "TrayIconContextMenu";
            this.TrayIconContextMenu.Size = new System.Drawing.Size(167, 26);
            this.TrayIconContextMenu.Text = "Teste";
            this.TrayIconContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TrayIconContextMenu_ItemClicked);
            // 
            // CloseApplicationContextMenu
            // 
            this.CloseApplicationContextMenu.Name = "CloseApplicationContextMenu";
            this.CloseApplicationContextMenu.Size = new System.Drawing.Size(166, 22);
            this.CloseApplicationContextMenu.Text = "Close Application";
            // 
            // MinimizeToTrayCommand
            // 
            this.MinimizeToTrayCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MinimizeToTrayCommand.Location = new System.Drawing.Point(438, 568);
            this.MinimizeToTrayCommand.Name = "MinimizeToTrayCommand";
            this.MinimizeToTrayCommand.Size = new System.Drawing.Size(116, 22);
            this.MinimizeToTrayCommand.TabIndex = 15;
            this.MinimizeToTrayCommand.Text = "Minimize to Tray";
            this.MinimizeToTrayCommand.UseVisualStyleBackColor = true;
            this.MinimizeToTrayCommand.Click += new System.EventHandler(this.MinimizeToTrayCommand_Click);
            // 
            // SortKeys
            // 
            this.SortKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortKeys.Location = new System.Drawing.Point(479, 16);
            this.SortKeys.Name = "SortKeys";
            this.SortKeys.Size = new System.Drawing.Size(26, 25);
            this.SortKeys.TabIndex = 8;
            this.SortKeys.TabStop = false;
            this.SortKeys.Text = "A-Z";
            this.SortKeys.UseVisualStyleBackColor = true;
            this.SortKeys.Click += new System.EventHandler(this.SortKeys_Click);
            // 
            // TestSendKeysCommand
            // 
            this.TestSendKeysCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TestSendKeysCommand.Location = new System.Drawing.Point(455, 496);
            this.TestSendKeysCommand.Name = "TestSendKeysCommand";
            this.TestSendKeysCommand.Size = new System.Drawing.Size(73, 22);
            this.TestSendKeysCommand.TabIndex = 15;
            this.TestSendKeysCommand.Text = "SendKeys";
            this.TestSendKeysCommand.UseVisualStyleBackColor = true;
            // 
            // SendCommands
            // 
            this.SendCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SendCommands.Location = new System.Drawing.Point(43, 498);
            this.SendCommands.Name = "SendCommands";
            this.SendCommands.Size = new System.Drawing.Size(406, 20);
            this.SendCommands.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Test:";
            // 
            // ExecuteSelectedMacroCommand
            // 
            this.ExecuteSelectedMacroCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExecuteSelectedMacroCommand.Location = new System.Drawing.Point(251, 477);
            this.ExecuteSelectedMacroCommand.Name = "ExecuteSelectedMacroCommand";
            this.ExecuteSelectedMacroCommand.Size = new System.Drawing.Size(132, 29);
            this.ExecuteSelectedMacroCommand.TabIndex = 11;
            this.ExecuteSelectedMacroCommand.Text = "EXECUTE SELECTED";
            this.ExecuteSelectedMacroCommand.UseVisualStyleBackColor = true;
            this.ExecuteSelectedMacroCommand.Click += new System.EventHandler(this.ExecuteSelectedMacroCommand_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 600);
            this.Controls.Add(this.MinimizeToTrayCommand);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(573, 1280);
            this.MinimumSize = new System.Drawing.Size(573, 462);
            this.Name = "MainForm";
            this.Text = "Low Level SendKeys And Keyboard Hook";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.TrayIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UpdateKeyCommand;
        private System.Windows.Forms.TreeView treeKeys;
        private System.Windows.Forms.Button AddKeyCommand;
        private System.Windows.Forms.Button SaveAsCommand;
        private System.Windows.Forms.Button LoadCommand;
        private System.Windows.Forms.Button RemoveKeyCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RenameKeyCommand;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ChangeMakeCommand;
        private System.Windows.Forms.Button AddMakeCommand;
        private System.Windows.Forms.Button RemoveMakeCommand;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button CheckKeyboardsCommand;
        private System.Windows.Forms.Label Keyboard9;
        private System.Windows.Forms.Label Keyboard8;
        private System.Windows.Forms.Label Keyboard7;
        private System.Windows.Forms.Label Keyboard6;
        private System.Windows.Forms.Label Keyboard5;
        private System.Windows.Forms.Label Keyboard4;
        private System.Windows.Forms.Label Keyboard3;
        private System.Windows.Forms.Label Keyboard2;
        private System.Windows.Forms.Label Keyboard1;
        private System.Windows.Forms.Label Keyboard0;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem CloseApplicationContextMenu;
        private System.Windows.Forms.Button MinimizeToTrayCommand;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button AddMacroCommand;
        private System.Windows.Forms.Button RemoveMacroCommand;
        private System.Windows.Forms.ListBox ListMacros;
        private System.Windows.Forms.Button ChangeMacroCommand;
        private System.Windows.Forms.Button ExportMacrosCommand;
        private System.Windows.Forms.Button ImportMacrosCommand;
        private System.Windows.Forms.Button SortKeys;
        private System.Windows.Forms.Button TestSendKeysCommand;
        private System.Windows.Forms.TextBox SendCommands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ExecuteSelectedMacroCommand;
    }
}


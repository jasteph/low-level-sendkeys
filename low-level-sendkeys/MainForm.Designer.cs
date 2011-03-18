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
            this.SendCommands = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TestSendKeysCommand = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.treeKeys.Size = new System.Drawing.Size(522, 390);
            this.treeKeys.TabIndex = 1;
            this.treeKeys.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeKeys_AfterSelect);
            this.treeKeys.DoubleClick += new System.EventHandler(this.treeKeys_DoubleClick);
            this.treeKeys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeKeys_KeyUp);
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
            this.SaveAsCommand.Location = new System.Drawing.Point(442, 430);
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
            this.LoadCommand.Location = new System.Drawing.Point(442, 459);
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
            this.groupBox1.Location = new System.Drawing.Point(6, 402);
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
            this.groupBox2.Location = new System.Drawing.Point(189, 402);
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
            // SendCommands
            // 
            this.SendCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SendCommands.Location = new System.Drawing.Point(78, 542);
            this.SendCommands.Name = "SendCommands";
            this.SendCommands.Size = new System.Drawing.Size(390, 20);
            this.SendCommands.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Comandos:";
            // 
            // TestSendKeysCommand
            // 
            this.TestSendKeysCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TestSendKeysCommand.Location = new System.Drawing.Point(481, 540);
            this.TestSendKeysCommand.Name = "TestSendKeysCommand";
            this.TestSendKeysCommand.Size = new System.Drawing.Size(73, 22);
            this.TestSendKeysCommand.TabIndex = 12;
            this.TestSendKeysCommand.Text = "SendKeys";
            this.TestSendKeysCommand.UseVisualStyleBackColor = true;
            this.TestSendKeysCommand.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(542, 524);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeKeys);
            this.tabPage1.Controls.Add(this.SaveAsCommand);
            this.tabPage1.Controls.Add(this.LoadCommand);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(534, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Text = "tabPage2";
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
            this.TrayIconContextMenu.Size = new System.Drawing.Size(168, 26);
            this.TrayIconContextMenu.Text = "Teste";
            this.TrayIconContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TrayIconContextMenu_ItemClicked);
            // 
            // CloseApplicationContextMenu
            // 
            this.CloseApplicationContextMenu.Name = "CloseApplicationContextMenu";
            this.CloseApplicationContextMenu.Size = new System.Drawing.Size(167, 22);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 600);
            this.Controls.Add(this.MinimizeToTrayCommand);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TestSendKeysCommand);
            this.Controls.Add(this.SendCommands);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(573, 1280);
            this.MinimumSize = new System.Drawing.Size(573, 462);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.TrayIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox SendCommands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TestSendKeysCommand;
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
    }
}


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
            this.label1 = new System.Windows.Forms.Label();
            this.StartTimeout = new System.Windows.Forms.TextBox();
            this.SendCommands = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TestSendKeysCommand = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.treeKeys.Location = new System.Drawing.Point(12, 12);
            this.treeKeys.Name = "treeKeys";
            this.treeKeys.Size = new System.Drawing.Size(524, 433);
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
            this.SaveAsCommand.Location = new System.Drawing.Point(448, 470);
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
            this.LoadCommand.Location = new System.Drawing.Point(448, 499);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 451);
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
            this.groupBox2.Location = new System.Drawing.Point(195, 451);
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 555);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Start Timeout:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // StartTimeout
            // 
            this.StartTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartTimeout.Location = new System.Drawing.Point(99, 552);
            this.StartTimeout.Name = "StartTimeout";
            this.StartTimeout.Size = new System.Drawing.Size(100, 20);
            this.StartTimeout.TabIndex = 9;
            this.StartTimeout.Text = "3000";
            // 
            // SendCommands
            // 
            this.SendCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SendCommands.Location = new System.Drawing.Point(99, 580);
            this.SendCommands.Name = "SendCommands";
            this.SendCommands.Size = new System.Drawing.Size(437, 20);
            this.SendCommands.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 583);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Comandos:";
            // 
            // TestSendKeysCommand
            // 
            this.TestSendKeysCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TestSendKeysCommand.Location = new System.Drawing.Point(205, 552);
            this.TestSendKeysCommand.Name = "TestSendKeysCommand";
            this.TestSendKeysCommand.Size = new System.Drawing.Size(79, 22);
            this.TestSendKeysCommand.TabIndex = 12;
            this.TestSendKeysCommand.Text = "SendKeys";
            this.TestSendKeysCommand.UseVisualStyleBackColor = true;
            this.TestSendKeysCommand.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 610);
            this.Controls.Add(this.TestSendKeysCommand);
            this.Controls.Add(this.SendCommands);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartTimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoadCommand);
            this.Controls.Add(this.SaveAsCommand);
            this.Controls.Add(this.treeKeys);
            this.MaximumSize = new System.Drawing.Size(564, 1280);
            this.MinimumSize = new System.Drawing.Size(564, 462);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StartTimeout;
        private System.Windows.Forms.TextBox SendCommands;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TestSendKeysCommand;
    }
}


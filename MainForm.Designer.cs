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
            this.treeKeys.Size = new System.Drawing.Size(490, 313);
            this.treeKeys.TabIndex = 1;
            this.treeKeys.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeKeys_AfterSelect);
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
            this.SaveAsCommand.Location = new System.Drawing.Point(12, 427);
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
            this.LoadCommand.Location = new System.Drawing.Point(104, 427);
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
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.RenameKeyCommand);
            this.groupBox1.Controls.Add(this.AddKeyCommand);
            this.groupBox1.Controls.Add(this.RemoveKeyCommand);
            this.groupBox1.Controls.Add(this.UpdateKeyCommand);
            this.groupBox1.Location = new System.Drawing.Point(13, 331);
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
            this.groupBox2.Location = new System.Drawing.Point(205, 331);
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
            // 
            // RemoveMakeCommand
            // 
            this.RemoveMakeCommand.Location = new System.Drawing.Point(126, 19);
            this.RemoveMakeCommand.Name = "RemoveMakeCommand";
            this.RemoveMakeCommand.Size = new System.Drawing.Size(114, 29);
            this.RemoveMakeCommand.TabIndex = 8;
            this.RemoveMakeCommand.Text = "Remove Command";
            this.RemoveMakeCommand.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 459);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoadCommand);
            this.Controls.Add(this.SaveAsCommand);
            this.Controls.Add(this.treeKeys);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
    }
}


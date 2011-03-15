﻿namespace low_level_sendkeys
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
            this.button1 = new System.Windows.Forms.Button();
            this.treeKeys = new System.Windows.Forms.TreeView();
            this.AddKeyCommand = new System.Windows.Forms.Button();
            this.SaveAsCommand = new System.Windows.Forms.Button();
            this.LoadCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(382, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeKeys
            // 
            this.treeKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeKeys.Location = new System.Drawing.Point(12, 12);
            this.treeKeys.Name = "treeKeys";
            this.treeKeys.Size = new System.Drawing.Size(518, 233);
            this.treeKeys.TabIndex = 1;
            // 
            // AddKeyCommand
            // 
            this.AddKeyCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddKeyCommand.Location = new System.Drawing.Point(12, 251);
            this.AddKeyCommand.Name = "AddKeyCommand";
            this.AddKeyCommand.Size = new System.Drawing.Size(87, 29);
            this.AddKeyCommand.TabIndex = 2;
            this.AddKeyCommand.Text = "Add Key";
            this.AddKeyCommand.UseVisualStyleBackColor = true;
            this.AddKeyCommand.Click += new System.EventHandler(this.AddKeyCommand_Click);
            // 
            // SaveAsCommand
            // 
            this.SaveAsCommand.Location = new System.Drawing.Point(12, 286);
            this.SaveAsCommand.Name = "SaveAsCommand";
            this.SaveAsCommand.Size = new System.Drawing.Size(86, 23);
            this.SaveAsCommand.TabIndex = 3;
            this.SaveAsCommand.Text = "Export KeyList";
            this.SaveAsCommand.UseVisualStyleBackColor = true;
            this.SaveAsCommand.Click += new System.EventHandler(this.SaveAsCommand_Click);
            // 
            // LoadCommand
            // 
            this.LoadCommand.Location = new System.Drawing.Point(104, 286);
            this.LoadCommand.Name = "LoadCommand";
            this.LoadCommand.Size = new System.Drawing.Size(86, 23);
            this.LoadCommand.TabIndex = 4;
            this.LoadCommand.Text = "Import KeyList";
            this.LoadCommand.UseVisualStyleBackColor = true;
            this.LoadCommand.Click += new System.EventHandler(this.LoadCommand_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 318);
            this.Controls.Add(this.LoadCommand);
            this.Controls.Add(this.SaveAsCommand);
            this.Controls.Add(this.AddKeyCommand);
            this.Controls.Add(this.treeKeys);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeKeys;
        private System.Windows.Forms.Button AddKeyCommand;
        private System.Windows.Forms.Button SaveAsCommand;
        private System.Windows.Forms.Button LoadCommand;
    }
}


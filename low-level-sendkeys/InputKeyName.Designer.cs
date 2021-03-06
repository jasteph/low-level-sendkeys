﻿namespace low_level_sendkeys
{
    partial class InputKeyName
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
            this.KeyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OkCommand = new System.Windows.Forms.Button();
            this.CancelCommand = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.WindowsKeysDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KeyName
            // 
            this.KeyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyName.Location = new System.Drawing.Point(12, 40);
            this.KeyName.Name = "KeyName";
            this.KeyName.Size = new System.Drawing.Size(267, 20);
            this.KeyName.TabIndex = 1;
            this.KeyName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyName_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Define the new key name:";
            // 
            // OkCommand
            // 
            this.OkCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkCommand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkCommand.Location = new System.Drawing.Point(124, 127);
            this.OkCommand.Name = "OkCommand";
            this.OkCommand.Size = new System.Drawing.Size(75, 23);
            this.OkCommand.TabIndex = 4;
            this.OkCommand.Text = "&OK";
            this.OkCommand.UseVisualStyleBackColor = true;
            this.OkCommand.Click += new System.EventHandler(this.OkCommand_Click);
            // 
            // CancelCommand
            // 
            this.CancelCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelCommand.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelCommand.Location = new System.Drawing.Point(205, 127);
            this.CancelCommand.Name = "CancelCommand";
            this.CancelCommand.Size = new System.Drawing.Size(75, 23);
            this.CancelCommand.TabIndex = 5;
            this.CancelCommand.Text = "&Cancel";
            this.CancelCommand.UseVisualStyleBackColor = true;
            this.CancelCommand.Click += new System.EventHandler(this.CancelCommand_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Windows Keys description (OPTIONAL):";
            // 
            // WindowsKeysDescription
            // 
            this.WindowsKeysDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowsKeysDescription.Location = new System.Drawing.Point(9, 95);
            this.WindowsKeysDescription.Name = "WindowsKeysDescription";
            this.WindowsKeysDescription.Size = new System.Drawing.Size(267, 20);
            this.WindowsKeysDescription.TabIndex = 3;
            this.WindowsKeysDescription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WindowsKeysDescription_KeyUp);
            // 
            // InputKeyName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelCommand;
            this.ClientSize = new System.Drawing.Size(292, 164);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WindowsKeysDescription);
            this.Controls.Add(this.CancelCommand);
            this.Controls.Add(this.OkCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InputKeyName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Define KeyName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox KeyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OkCommand;
        private System.Windows.Forms.Button CancelCommand;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox WindowsKeysDescription;
    }
}
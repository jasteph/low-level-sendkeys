namespace low_level_sendkeys
{
    partial class MapKey
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
            this.PressAndRelease = new System.Windows.Forms.Label();
            this.RepeatCommand = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.keyDownCommands = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.keyUpCommands = new System.Windows.Forms.TextBox();
            this.AcceptCommand = new System.Windows.Forms.Button();
            this.CancelCommand = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PressAndRelease
            // 
            this.PressAndRelease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PressAndRelease.AutoSize = true;
            this.PressAndRelease.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PressAndRelease.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressAndRelease.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PressAndRelease.Location = new System.Drawing.Point(7, 18);
            this.PressAndRelease.Name = "PressAndRelease";
            this.PressAndRelease.Size = new System.Drawing.Size(372, 33);
            this.PressAndRelease.TabIndex = 0;
            this.PressAndRelease.Text = "Please, press and release a key";
            // 
            // RepeatCommand
            // 
            this.RepeatCommand.Enabled = false;
            this.RepeatCommand.Location = new System.Drawing.Point(41, 252);
            this.RepeatCommand.Name = "RepeatCommand";
            this.RepeatCommand.Size = new System.Drawing.Size(117, 29);
            this.RepeatCommand.TabIndex = 1;
            this.RepeatCommand.Text = "&Repeat";
            this.RepeatCommand.UseVisualStyleBackColor = true;
            this.RepeatCommand.Click += new System.EventHandler(this.RepeatCommand_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.keyDownCommands);
            this.groupBox1.Location = new System.Drawing.Point(7, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 176);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "KeyDown Commands";
            // 
            // keyDownCommands
            // 
            this.keyDownCommands.Location = new System.Drawing.Point(7, 20);
            this.keyDownCommands.Multiline = true;
            this.keyDownCommands.Name = "keyDownCommands";
            this.keyDownCommands.ReadOnly = true;
            this.keyDownCommands.Size = new System.Drawing.Size(179, 150);
            this.keyDownCommands.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.keyUpCommands);
            this.groupBox2.Location = new System.Drawing.Point(205, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 176);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "KeyUp Commands";
            // 
            // keyUpCommands
            // 
            this.keyUpCommands.Location = new System.Drawing.Point(6, 19);
            this.keyUpCommands.Multiline = true;
            this.keyUpCommands.Name = "keyUpCommands";
            this.keyUpCommands.ReadOnly = true;
            this.keyUpCommands.Size = new System.Drawing.Size(179, 150);
            this.keyUpCommands.TabIndex = 1;
            // 
            // AcceptCommand
            // 
            this.AcceptCommand.Enabled = false;
            this.AcceptCommand.Location = new System.Drawing.Point(164, 252);
            this.AcceptCommand.Name = "AcceptCommand";
            this.AcceptCommand.Size = new System.Drawing.Size(113, 29);
            this.AcceptCommand.TabIndex = 4;
            this.AcceptCommand.Text = "&Accept";
            this.AcceptCommand.UseVisualStyleBackColor = true;
            this.AcceptCommand.Click += new System.EventHandler(this.AcceptCommand_Click);
            // 
            // CancelCommand
            // 
            this.CancelCommand.Enabled = false;
            this.CancelCommand.Location = new System.Drawing.Point(283, 252);
            this.CancelCommand.Name = "CancelCommand";
            this.CancelCommand.Size = new System.Drawing.Size(113, 29);
            this.CancelCommand.TabIndex = 5;
            this.CancelCommand.Text = "&Cancel";
            this.CancelCommand.UseVisualStyleBackColor = true;
            this.CancelCommand.Click += new System.EventHandler(this.CancelCommand_Click);
            // 
            // MapKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 290);
            this.Controls.Add(this.CancelCommand);
            this.Controls.Add(this.AcceptCommand);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RepeatCommand);
            this.Controls.Add(this.PressAndRelease);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MapKey";
            this.Load += new System.EventHandler(this.MapKey_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PressAndRelease;
        private System.Windows.Forms.Button RepeatCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox keyDownCommands;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox keyUpCommands;
        private System.Windows.Forms.Button AcceptCommand;
        private System.Windows.Forms.Button CancelCommand;
    }
}
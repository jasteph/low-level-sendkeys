namespace low_level_sendkeys.Macros
{
    partial class ConfigureMacro
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
            this.label1 = new System.Windows.Forms.Label();
            this.MacroName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MacroCommand = new System.Windows.Forms.TextBox();
            this.OkCommand = new System.Windows.Forms.Button();
            this.CancelCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // MacroName
            // 
            this.MacroName.Location = new System.Drawing.Point(74, 26);
            this.MacroName.Name = "MacroName";
            this.MacroName.Size = new System.Drawing.Size(219, 20);
            this.MacroName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // MacroCommand
            // 
            this.MacroCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MacroCommand.Location = new System.Drawing.Point(74, 70);
            this.MacroCommand.Name = "MacroCommand";
            this.MacroCommand.Size = new System.Drawing.Size(368, 20);
            this.MacroCommand.TabIndex = 3;
            // 
            // OkCommand
            // 
            this.OkCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkCommand.Location = new System.Drawing.Point(286, 111);
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
            this.CancelCommand.Location = new System.Drawing.Point(367, 111);
            this.CancelCommand.Name = "CancelCommand";
            this.CancelCommand.Size = new System.Drawing.Size(75, 23);
            this.CancelCommand.TabIndex = 5;
            this.CancelCommand.Text = "&Cancel";
            this.CancelCommand.UseVisualStyleBackColor = true;
            this.CancelCommand.Click += new System.EventHandler(this.CancelCommand_Click);
            // 
            // ConfigureMacro
            // 
            this.AcceptButton = this.OkCommand;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelCommand;
            this.ClientSize = new System.Drawing.Size(454, 147);
            this.Controls.Add(this.CancelCommand);
            this.Controls.Add(this.OkCommand);
            this.Controls.Add(this.MacroCommand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MacroName);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(5000, 181);
            this.MinimumSize = new System.Drawing.Size(462, 181);
            this.Name = "ConfigureMacro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Macro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OkCommand;
        private System.Windows.Forms.Button CancelCommand;
        public System.Windows.Forms.TextBox MacroName;
        public System.Windows.Forms.TextBox MacroCommand;
    }
}
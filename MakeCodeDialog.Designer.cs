namespace low_level_sendkeys
{
    partial class MakeCodeDialog
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
            this.code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.information = new System.Windows.Forms.TextBox();
            this.MakeCodeStates = new System.Windows.Forms.CheckedListBox();
            this.CancelCommand = new System.Windows.Forms.Button();
            this.OkCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(122, 16);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(210, 20);
            this.code.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code.......:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Information:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "State......:";
            // 
            // information
            // 
            this.information.Location = new System.Drawing.Point(122, 53);
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(210, 20);
            this.information.TabIndex = 4;
            this.information.Text = "0";
            // 
            // MakeCodeStates
            // 
            this.MakeCodeStates.FormattingEnabled = true;
            this.MakeCodeStates.Location = new System.Drawing.Point(122, 95);
            this.MakeCodeStates.Name = "MakeCodeStates";
            this.MakeCodeStates.Size = new System.Drawing.Size(210, 139);
            this.MakeCodeStates.TabIndex = 6;
            // 
            // CancelCommand
            // 
            this.CancelCommand.Location = new System.Drawing.Point(219, 246);
            this.CancelCommand.Name = "CancelCommand";
            this.CancelCommand.Size = new System.Drawing.Size(113, 29);
            this.CancelCommand.TabIndex = 8;
            this.CancelCommand.Text = "&Cancel";
            this.CancelCommand.UseVisualStyleBackColor = true;
            this.CancelCommand.Click += new System.EventHandler(this.CancelCommand_Click);
            // 
            // OkCommand
            // 
            this.OkCommand.Location = new System.Drawing.Point(100, 246);
            this.OkCommand.Name = "OkCommand";
            this.OkCommand.Size = new System.Drawing.Size(113, 29);
            this.OkCommand.TabIndex = 7;
            this.OkCommand.Text = "&OK";
            this.OkCommand.UseVisualStyleBackColor = true;
            this.OkCommand.Click += new System.EventHandler(this.OkCommand_Click);
            // 
            // MakeCodeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 287);
            this.Controls.Add(this.CancelCommand);
            this.Controls.Add(this.OkCommand);
            this.Controls.Add(this.MakeCodeStates);
            this.Controls.Add(this.information);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MakeCodeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Make Code Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox information;
        private System.Windows.Forms.CheckedListBox MakeCodeStates;
        private System.Windows.Forms.Button CancelCommand;
        private System.Windows.Forms.Button OkCommand;
    }
}
namespace DesktopAPP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusSignalR = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // statusSignalR
            // 
            statusSignalR.AutoSize = true;
            statusSignalR.Location = new Point(12, 426);
            statusSignalR.Name = "statusSignalR";
            statusSignalR.Size = new Size(38, 15);
            statusSignalR.TabIndex = 0;
            statusSignalR.Text = "label1";
            statusSignalR.Click += statusSignalR_Click;
            // 
            // button1
            // 
            button1.Location = new Point(422, 361);
            button1.Name = "button1";
            button1.Size = new Size(355, 62);
            button1.TabIndex = 1;
            button1.Text = "COMPLETE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(statusSignalR);
            Name = "Form1";
            Text = "Desktop App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label statusSignalR;
        private Button button1;
    }
}

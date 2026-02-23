namespace Mahesh.Chandigarh.University.Capegemini.WinFormsApp
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
            connectButtonName = new Button();
            SuspendLayout();
            // 
            // connectButtonName
            // 
            connectButtonName.Location = new Point(305, 90);
            connectButtonName.Name = "connectButtonName";
            connectButtonName.Size = new Size(395, 223);
            connectButtonName.TabIndex = 0;
            connectButtonName.Text = "connectButtonText";
            connectButtonName.UseVisualStyleBackColor = true;
            connectButtonName.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(connectButtonName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button connectButtonName;
    }
}

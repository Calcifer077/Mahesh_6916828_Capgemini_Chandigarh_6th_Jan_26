namespace WinFormsApp1
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
            dataGridView1 = new DataGridView();
            add_button = new Button();
            delete_button = new Button();
            update_button = new Button();
            email_textBox = new TextBox();
            firstName_textBox = new TextBox();
            lastName_textBox = new TextBox();
            email_add_label = new Label();
            firstName_label = new Label();
            lastName_label = new Label();
            idToDelete_textBox = new TextBox();
            lastNameUpdate_textBox = new TextBox();
            firstNameUpdate_textBox = new TextBox();
            emailUpdate_textBox = new TextBox();
            idUpdate_textBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(457, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(674, 272);
            dataGridView1.TabIndex = 8;
            // 
            // add_button
            // 
            add_button.Location = new Point(241, 479);
            add_button.Name = "add_button";
            add_button.Size = new Size(516, 34);
            add_button.TabIndex = 9;
            add_button.Text = "Add";
            add_button.UseVisualStyleBackColor = true;
            add_button.Click += add_button_Click;
            // 
            // delete_button
            // 
            delete_button.Location = new Point(457, 565);
            delete_button.Name = "delete_button";
            delete_button.Size = new Size(112, 34);
            delete_button.TabIndex = 10;
            delete_button.Text = "Delete";
            delete_button.UseVisualStyleBackColor = true;
            delete_button.Click += delete_button_Click;
            // 
            // update_button
            // 
            update_button.Location = new Point(39, 694);
            update_button.Name = "update_button";
            update_button.Size = new Size(993, 34);
            update_button.TabIndex = 11;
            update_button.Text = "Update";
            update_button.UseVisualStyleBackColor = true;
            update_button.Click += update_button_Click;
            // 
            // email_textBox
            // 
            email_textBox.Location = new Point(241, 337);
            email_textBox.Name = "email_textBox";
            email_textBox.Size = new Size(150, 31);
            email_textBox.TabIndex = 12;
            email_textBox.Text = "Your Email";
            // 
            // firstName_textBox
            // 
            firstName_textBox.Location = new Point(421, 337);
            firstName_textBox.Name = "firstName_textBox";
            firstName_textBox.Size = new Size(150, 31);
            firstName_textBox.TabIndex = 13;
            firstName_textBox.Text = "Your FirstName";
            // 
            // lastName_textBox
            // 
            lastName_textBox.Location = new Point(607, 337);
            lastName_textBox.Name = "lastName_textBox";
            lastName_textBox.Size = new Size(150, 31);
            lastName_textBox.TabIndex = 14;
            lastName_textBox.Text = "Your LastName";
            // 
            // email_add_label
            // 
            email_add_label.AutoSize = true;
            email_add_label.Location = new Point(241, 396);
            email_add_label.Name = "email_add_label";
            email_add_label.Size = new Size(54, 25);
            email_add_label.TabIndex = 15;
            email_add_label.Text = "Email";
            // 
            // firstName_label
            // 
            firstName_label.AutoSize = true;
            firstName_label.Location = new Point(421, 396);
            firstName_label.Name = "firstName_label";
            firstName_label.Size = new Size(92, 25);
            firstName_label.TabIndex = 16;
            firstName_label.Text = "FirstName";
            // 
            // lastName_label
            // 
            lastName_label.AutoSize = true;
            lastName_label.Location = new Point(607, 396);
            lastName_label.Name = "lastName_label";
            lastName_label.Size = new Size(90, 25);
            lastName_label.TabIndex = 17;
            lastName_label.Text = "LastName";
            // 
            // idToDelete_textBox
            // 
            idToDelete_textBox.Location = new Point(241, 565);
            idToDelete_textBox.Name = "idToDelete_textBox";
            idToDelete_textBox.Size = new Size(150, 31);
            idToDelete_textBox.TabIndex = 18;
            idToDelete_textBox.Text = "ID to delete";
            // 
            // lastNameUpdate_textBox
            // 
            lastNameUpdate_textBox.Location = new Point(685, 633);
            lastNameUpdate_textBox.Name = "lastNameUpdate_textBox";
            lastNameUpdate_textBox.Size = new Size(150, 31);
            lastNameUpdate_textBox.TabIndex = 21;
            lastNameUpdate_textBox.Text = "Updated LastName";
            // 
            // firstNameUpdate_textBox
            // 
            firstNameUpdate_textBox.Location = new Point(457, 633);
            firstNameUpdate_textBox.Name = "firstNameUpdate_textBox";
            firstNameUpdate_textBox.Size = new Size(150, 31);
            firstNameUpdate_textBox.TabIndex = 20;
            firstNameUpdate_textBox.Text = "Updated FirstName";
            // 
            // emailUpdate_textBox
            // 
            emailUpdate_textBox.Location = new Point(237, 633);
            emailUpdate_textBox.Name = "emailUpdate_textBox";
            emailUpdate_textBox.Size = new Size(150, 31);
            emailUpdate_textBox.TabIndex = 19;
            emailUpdate_textBox.Text = "Updated Email";
            // 
            // idUpdate_textBox
            // 
            idUpdate_textBox.Location = new Point(39, 633);
            idUpdate_textBox.Name = "idUpdate_textBox";
            idUpdate_textBox.Size = new Size(150, 31);
            idUpdate_textBox.TabIndex = 26;
            idUpdate_textBox.Text = "ID to Update";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1556, 849);
            Controls.Add(idUpdate_textBox);
            Controls.Add(lastNameUpdate_textBox);
            Controls.Add(firstNameUpdate_textBox);
            Controls.Add(emailUpdate_textBox);
            Controls.Add(idToDelete_textBox);
            Controls.Add(lastName_label);
            Controls.Add(firstName_label);
            Controls.Add(email_add_label);
            Controls.Add(lastName_textBox);
            Controls.Add(firstName_textBox);
            Controls.Add(email_textBox);
            Controls.Add(update_button);
            Controls.Add(delete_button);
            Controls.Add(add_button);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "V";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button add_button;
        private Button delete_button;
        private Button update_button;
        private TextBox email_textBox;
        private TextBox firstName_textBox;
        private TextBox lastName_textBox;
        private Label email_add_label;
        private Label firstName_label;
        private Label lastName_label;
        private TextBox idToDelete_textBox;
        private TextBox lastNameUpdate_textBox;
        private TextBox firstNameUpdate_textBox;
        private TextBox emailUpdate_textBox;
        private TextBox idUpdate_textBox;
    }
}

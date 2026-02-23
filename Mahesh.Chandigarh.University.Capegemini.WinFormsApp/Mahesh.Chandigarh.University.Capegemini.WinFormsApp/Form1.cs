using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;


namespace Mahesh.Chandigarh.University.Capegemini.WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=PC\\SQLEXPRESS;Initial Catalog=emp;TrustServerCertificate=True;Integrated Security=True;";

            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                MessageBox.Show("Connection Successfull");
            }catch (Exception err)
            {
                MessageBox.Show("Connection Failed: " + err.ToString());
            }
        }
    }
}

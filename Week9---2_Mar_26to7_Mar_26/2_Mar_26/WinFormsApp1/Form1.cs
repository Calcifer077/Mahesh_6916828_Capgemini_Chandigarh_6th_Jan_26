using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=PC\\SQLEXPRESS;Initial Catalog=EmployeeDB;TrustServerCertificate=True;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadEmployee();
        }

        public void LoadEmployee()
        {
            using var con = new SqlConnection(connectionString);
            using var da = new SqlDataAdapter("SELECT EmployeeID, FirstName, LastName, Email FROM Employee order by EmployeeID", con);

            var dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        public void AddEmployee()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CreateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", email_textBox.Text);
                command.Parameters.AddWithValue("@FirstName", firstName_textBox.Text);
                command.Parameters.AddWithValue("@LastName", lastName_textBox.Text);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
                connection.Close();
            }

            LoadEmployee();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }

        public void DeleteEmployee()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", idToDelete_textBox.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            LoadEmployee();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            DeleteEmployee();
        }

        public void UpdateEmployee() {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", idUpdate_textBox.Text);
                command.Parameters.AddWithValue("@FirstName", firstNameUpdate_textBox.Text);
                command.Parameters.AddWithValue("@LastName", lastNameUpdate_textBox.Text);
                command.Parameters.AddWithValue("@Email", emailUpdate_textBox.Text);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            LoadEmployee();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
        }
    }
}

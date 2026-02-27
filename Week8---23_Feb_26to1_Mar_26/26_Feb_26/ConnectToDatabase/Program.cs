using System.Data;
using Microsoft.Data.SqlClient;

namespace ConnectToDatabase;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            string connectionString = "Data Source=PC\\SQLEXPRESS;Initial Catalog=EmployeeDB;TrustServerCertificate=True;Integrated Security=True;";

            GetAllEmployees(connectionString);

            int EmployeeId = 1;
            GetEmployeeById(connectionString, EmployeeId);

            string firstName = "Ramesh";
            string lastName = "Sharma";
            string email = "ramesh@mail.com";
            string street = "123 Patia";
            string city = "BBSR";
            string state = "India";
            string postalCode = "755019";

            CreateEmployeeWIthAddress(connectionString, firstName, lastName, email, street, city, state, postalCode);

            int employeeID = 3;
            firstName = "Rakesh";
            lastName = "Sharma";
            email = "rakesh@mail.com";
            street = "3456 Patia";
            city = "CTC";
            state = "India";
            postalCode = "755024";

            UpdateEmployeeWithAdress(connectionString, employeeID, firstName, lastName, email, street, city, state, postalCode, 3);

            employeeID = 3;
            DeleteEmployee(connectionString, employeeID);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        static void GetAllEmployees(string connectionString)
        {
            Console.WriteLine("GetAllEmployees stored procedure called");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetAllEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"EmployeeID: {reader["EmployeeID"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, Email: {reader["Email"]}");
                }

                reader.Close();
                connection.Close();
            }
        }

        static void GetEmployeeById(string connectionString, int employeeId)
        {
            Console.WriteLine("GetEmployeeById stored procedure called");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetEmployeeByID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", employeeId);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"EmployeeID: {reader["EmployeeID"]}, FirstName: {reader["FirstName"]}, LastName: {reader["LastName"]}, Email: {reader["Email"]}");
                }

                reader.Close();
                connection.Close();
            }
        }

        static void CreateEmployeeWIthAddress(string connectionString, string firstName, string lastName, string email, string street, string city, string state, string postalCode)
        {
            Console.WriteLine("CreateEmployeeWithAddress stored procedure called");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("CreateEmployeeWithAddress", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@PostalCode", postalCode);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
                connection.Close();
            }
        }

        static void UpdateEmployeeWithAdress(string connectionString, int employeeId, string firstName, string lastName, string email, string street, string city, string state, string postalCode, int addressId)
        {
            Console.WriteLine("UpdateEmployeeWithAddress stored procedure called");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateEmployeeWithAdress", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", employeeId);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@PostalCode", postalCode);
                command.Parameters.AddWithValue("@AdressID", addressId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
                connection.Close();
            }
        }

        static void DeleteEmployee(string connectionString, int employeeId)
        {
            Console.WriteLine("DeleteEmployee stored procedure called");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeID", employeeId);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {rowsAffected}");
                connection.Close();
            }
        }
    }
}
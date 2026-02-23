namespace PatientsList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Patient> patientList = new List<Patient>();
            PatientBO bo = new PatientBO();

            Console.WriteLine("Enter the number of patients");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter patient {i + 1} details:");
                Console.WriteLine("Enter the name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the illness");
                string illness = Console.ReadLine();
                Console.WriteLine("Enter the city");
                string city = Console.ReadLine();

                patientList.Add(new Patient(name, age, illness, city));
            }

            string continueChoice;
            do
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1)Display Patient Details" +
                    "2)Display Youngest Patient Details" +
                    "3)Display Patients from City");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter patient name:");
                        string searchName = Console.ReadLine();
                        bo.DisplayPatientDetails(patientList, searchName);
                        break;
                    case 2:
                        bo.DisplayYoungestPatientDetails(patientList);
                        break;
                    case 3:
                        Console.WriteLine("Enter city");
                        string searchCity = Console.ReadLine();
                        bo.DisplayPatientsFromCity(patientList, searchCity);
                        break;
                }

                Console.WriteLine("Do you want to continue(Yes/No)?");
                continueChoice = Console.ReadLine();
            } while (continueChoice.Equals("Yes", StringComparison.OrdinalIgnoreCase));
        }
    }
}
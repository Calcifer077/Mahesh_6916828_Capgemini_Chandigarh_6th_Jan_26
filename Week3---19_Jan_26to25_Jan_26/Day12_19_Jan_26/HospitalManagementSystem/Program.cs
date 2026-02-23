namespace HospitalManagementSystem
{
    internal class Program
    {

        class Person
        {
            public string name { get; set; }
            public int age { get; set; }
            public string role { get; set; }

            public Person(string name, int age, string role)
            {
                this.name = name;
                this.age = age;
                this.role = role;
            }
        }

        class Patient : Person
        {
            public string[] medicine;
            public int[] medicineCost;

            public Patient(string name, int age, string[] medicine, int[] medicineCost) : base(name, age, "Patient")
            {
                this.medicine = medicine;
                this.medicineCost = medicineCost;
            }

            public void DispInfo()
            {
                Console.WriteLine($"Name: {name}, Age: {age}, Role: {role}");
            }
        }
        class Doctor : Person
        {

            public Doctor(string name, int age) : base(name, age, "Doctor") { }

            public void DispInfo()
            {
                Console.WriteLine($"Name: {name}, Age: {age}, Role: {role}");
            }
        }
        class Nurse : Person
        {
            public Nurse(string name, int age) : base(name, age, "Nurse") { }

            public void DispInfo()
            {
                Console.WriteLine($"Name: {name}, Age: {age}, Role: {role}");
            }
        }

        class Appointment
        {
            public Patient pat { get; set; }
            public Doctor dct { get; set; }
            public Nurse nur { get; set; }
            public string time { get; set; }

            public Appointment(Patient pat, Doctor dct, Nurse nur, string time)
            {
                this.pat = pat;
                this.dct = dct;
                this.nur = nur;
                this.time = time;
            }

            public void DispInfo()
            {
                Console.WriteLine("Appointment Details: ");
                Console.WriteLine($"Patient name: {pat.name}, Doctor name: {dct.name}, Nurse name: {nur.name}, Timing: {time}");
            }
        }

        class MedicalRecord { 
            public Patient pat { get; set; }
            public int totalCost;

            public MedicalRecord(Patient pat)
            {
                this.pat = pat;
            }

            public void dispInfo()
            {
                for(int i = 0; i < pat.medicine.Length; i++)
                {
                    Console.WriteLine($"Medicine name: {pat.medicine[i]}, Medicine cost: {pat.medicineCost[i]}");
                    totalCost += pat.medicineCost[i];
                }

                Console.WriteLine($"Total cost: {totalCost}");
            }
        }

        static void Main(string[] args)
        {
            Patient pat = new Patient("Mahesh", 92, new string[] { "Paracetamol", "Ibuprofen", "Tylenol" }, new int[] { 50, 100, 200 });

            Doctor dct = new Doctor("Dr. Mahesh", 45);
            
            Nurse nur = new Nurse("Nurse ajay", 30);

            Appointment app = new Appointment(pat, dct, nur, "10:00 AM");
            
            MedicalRecord mr = new MedicalRecord(pat);

            pat.DispInfo();
            dct.DispInfo();
            nur.DispInfo();
            app.DispInfo();
            mr.dispInfo();
        }
    }
}
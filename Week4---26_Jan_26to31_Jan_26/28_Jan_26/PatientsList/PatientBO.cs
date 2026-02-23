namespace PatientsList
{
    public class PatientBO
    {
        public void DisplayPatientDetails(List<Patient> patientList, string name)
        {
            bool found = false;
            foreach (var p in patientList)
            {
                if (p.Name.Equals(name))
                {
                    if (!found) Console.WriteLine("{0,-21}{1,-6}{2,-17}{3,-20}", "Name", "Age", "Illness", "City");
                    Console.WriteLine(p.ToString());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine($"Patient named {name} not found");
            }
        }

        public void DisplayYoungestPatientDetails(List<Patient> patientList)
        {
            if (patientList.Count == 0) return;

            Patient youngest = patientList[0];
            foreach (var p in patientList)
            {
                if (p.Age < youngest.Age)
                {
                    youngest = p;
                }
            }
            Console.WriteLine("The Youngest Patient Details");
            Console.WriteLine("{0,-21}{1,-6}{2,-17}{3,-20}", "Name", "Age", "Illness", "City");
            Console.WriteLine(youngest.ToString());
        }

        public void DisplayPatientsFromCity(List<Patient> patientList, string cname)
        {
            bool found = false;
            foreach (var p in patientList)
            {
                if (p.City.Equals(cname, StringComparison.OrdinalIgnoreCase))
                {
                    if (!found) Console.WriteLine("{0,-21}{1,-6}{2,-17}{3,-20}", "Name", "Age", "Illness", "City");
                    Console.WriteLine(p.ToString());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine($"City named {cname} not found");
            }
        }
    }
}
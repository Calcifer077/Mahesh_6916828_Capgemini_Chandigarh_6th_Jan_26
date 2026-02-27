namespace Project_Almanac
{
   
        class Alamanac
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            public void AssignProject(string name, string project)
            {
                if (dict.ContainsKey(name))
                {
                    dict[name].Add(project);
                }
                else
                {
                    dict.Add(name, new List<string>());
                    dict[name].Add(project);
                }
            }

            public List<string> CurrentProjects(string name)
            {
                return dict[name];
            }

            public string FinishProject(string name, string project)
            {
                if (dict.ContainsKey(name))
                {
                    dict[name].Remove(project);
                }
                else
                {
                    return "Invalid Name";
                }

                return "Operation Completed Successfully";
            }
        }

    
        class Program
        {
            static void Main(string[] args)
            {
                Alamanac almanac = new Alamanac();

                // Assign projects
                almanac.AssignProject("Alice", "Cyber Security Audit");
                almanac.AssignProject("Alice", "AI Surveillance System");
                almanac.AssignProject("Bob", "Database Optimization");

                // Display current projects of Alice
                Console.WriteLine("Alice's Projects:");
                List<string> aliceProjects = almanac.CurrentProjects("Alice");
                foreach (var project in aliceProjects)
                {
                    Console.WriteLine(project);
                }

                Console.WriteLine();

                // Display current projects of Bob
                Console.WriteLine("Bob's Projects:");
                List<string> bobProjects = almanac.CurrentProjects("Bob");
                foreach (var project in bobProjects)
                {
                    Console.WriteLine(project);
                }

                Console.WriteLine();

                // Finish a project
                Console.WriteLine(almanac.FinishProject("Alice", "Cyber Security Audit"));

                Console.WriteLine();

                // Display Alice's projects after finishing one
                Console.WriteLine("Alice's Projects After Completion:");
                aliceProjects = almanac.CurrentProjects("Alice");
                foreach (var project in aliceProjects)
                {
                    Console.WriteLine(project);
                }

                Console.ReadLine();
            }
        }
    }


namespace LambdaExpressions
{
    internal class Program{

        class Employee
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }


        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            // var squares = numbers.Select(n => n * n);
            
            // foreach (var s in squares)
                // Console.WriteLine(s);

            // var evens = numbers.Where(n => n % 2 == 0);
            // foreach (var s in evens)
            //     Console.WriteLine(s);

            var employees = new List<Employee>
            {
                new Employee { Name = "Alice", Age = 25 },
                new Employee { Name = "Bob", Age = 32 },
                new Employee { Name = "Charlie", Age = 28 }
            };

            // Find employees older than 30
            var result = employees.Where(emp => emp.Age > 30);

            // foreach (var e in result)
            //     Console.WriteLine(e.Name); // Output: Bob

            var names = employees.Select(emp => emp.Name);

            // foreach (var n in names)
            //     Console.WriteLine(n); 

            var sorted = employees.OrderBy(emp => emp.Age);

            // foreach (var e in sorted)
            //     Console.WriteLine($"{e.Name} - {e.Age}");

            var grouped = employees.GroupBy(emp => emp.Age > 30 ? "Senior" : "Junior");

            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var e in group)
                    Console.WriteLine($"  {e.Name}");
            }

        }
    }
}
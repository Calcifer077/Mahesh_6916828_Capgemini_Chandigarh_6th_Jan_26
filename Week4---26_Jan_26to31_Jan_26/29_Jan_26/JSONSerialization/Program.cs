using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JSONSerialization
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Optional: helps with debugging/printing
        public override string ToString() => $"Student {{ Id = {Id}, Name = {Name} }}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Create sample data
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "John Doe" },
                new Student { Id = 2, Name = "Alice Smith" },
                new Student { Id = 3, Name = "Bob Johnson" },
                new Student { Id = 4, Name = "Charlie Brown" }
            };

            string filePath = "students.json";

            // 2. Serialize (save) to file
            SaveStudentsToFile(students, filePath);
            Console.WriteLine($"Saved {students.Count} students to {filePath}");

            // 3. Deserialize (load) from file
            var loadedStudents = LoadStudentsFromFile(filePath);

            // 4. Show what we loaded
            Console.WriteLine("\nLoaded students from file:");
            foreach (var student in loadedStudents)
            {
                Console.WriteLine(student);
            }
        }

        // Helper: Save list to JSON file (pretty-printed)
        static void SaveStudentsToFile(List<Student> students, string filePath)
        {
            // Optional: nicer formatting (indented)
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,           // makes JSON human-readable
                // PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  // ← uncomment if you want camelCase
            };

            string json = JsonSerializer.Serialize(students, options);

            // Write to file (creates or overwrites)
            File.WriteAllText(filePath, json);
        }

        // Helper: Load list from JSON file
        static List<Student> LoadStudentsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return new List<Student>();
            }

            string json = File.ReadAllText(filePath);

            // Important: tell serializer we expect List<Student>, not single Student
            var students = JsonSerializer.Deserialize<List<Student>>(json);

            return students ?? new List<Student>();
        }
    }
}
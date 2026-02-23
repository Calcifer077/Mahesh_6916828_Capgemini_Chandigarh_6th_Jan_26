using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XMLSerialization
{
    [Serializable]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Parameterless constructor recommended for XmlSerializer
        public Student() { }
    }

    // Wrapper class becomes the root element
    [Serializable]
    [XmlRoot("Students")]           // optional: custom root name
    public class StudentList
    {
        [XmlElement("Student")]     // each item will be <Student>
        public List<Student> Items { get; set; } = new List<Student>();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new StudentList
            {
                Items = new List<Student>
                {
                    new Student { Id = 2, Name = "Alice" },
                    new Student { Id = 3, Name = "Bob" },
                    new Student { Id = 4, Name = "Charlie" }
                }
            };

            var xs = new XmlSerializer(typeof(StudentList));

            // Serialize
            using (var tw = new StreamWriter("students.xml"))
            {
                xs.Serialize(tw, students);
            }

            Console.WriteLine("Saved to students.xml");

            // Deserialize
            using (var tr = new StreamReader("students.xml"))
            {
                var loaded = (StudentList)xs.Deserialize(tr);

                Console.WriteLine("\nDeserialized students:");
                foreach (var s in loaded.Items)
                {
                    Console.WriteLine($"  ID: {s.Id,-2}  Name: {s.Name}");
                }
            }
        }
    }
}
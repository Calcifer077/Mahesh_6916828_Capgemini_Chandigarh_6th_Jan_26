namespace UniversityEnrollmentSystem
{
    internal class Program
    {
        static int id = 1;
        class Person { 
            public int Id { get; set; }
            public string Name { get; set; }

            public Person(int Id, string name)
            {
                this.Id = Id;
                Name = name;
            }
        }

        interface Course { 
            string CourseName { get; set; }
        }

        interface Department { 
            string DepartmentName { get; set; }
        }

        class Student : Person, Course, Department {
            public string CourseName { get; set; }
            public string DepartmentName { get; set; }

            Person obj;

            public Student(int Id, string Name, string DepartmentName, string courseName): base(Id, Name)
            {
                obj = new Person(Id, Name);
                this.CourseName = courseName;
                this.DepartmentName = DepartmentName;
            }

            public void DisplayDetail()
            {
                Console.WriteLine("Student Id is: stu" + obj.Id);
                Console.WriteLine("Student Name is: " + obj.Name);
                Console.WriteLine("Student assigned course is: " + CourseName);
                Console.WriteLine("Student Department is: " + DepartmentName);
            }
        }
        class Professor: Person, Course, Department {
            public string CourseName { get; set; }
            public string DepartmentName { get; set; }

            public string AvailTime;

            Person obj;

            public Professor(int Id, string Name, string DepartmentName, string courseName, string availTime) : base(Id, Name)
            {
                obj = new Person(Id, Name);
                this.CourseName = courseName;
                this.DepartmentName = DepartmentName;
                AvailTime = availTime;
            }

            public void DisplayDetail()
            {
                Console.WriteLine("Professor Id is: prof" + obj.Id);
                Console.WriteLine("Professor Name is: " + obj.Name);
                Console.WriteLine("Professor assigned course is: " + CourseName);
                Console.WriteLine("Professor Department is: " + DepartmentName);
                Console.WriteLine("Professor Available time is: " + AvailTime);
            }
        }

        class Staff: Person, Department {
            public string DepartmentName { get; set; }

            Person obj;
            public Staff(int Id, string Name, string DepartmentName) : base(Id, Name)
            {
                obj = new Person(Id, Name);
                this.DepartmentName = DepartmentName;
            }

            public void DisplayDetail()
            {
                Console.WriteLine("Staff Id is: stf" + obj.Id);
                Console.WriteLine("Staff Name is: " + obj.Name);
                Console.WriteLine("Staff Department is: " + DepartmentName);
            }
        }

        static void Main(string[] args)
        {
            Student st = new Student(id++, "Mahesh", "BTECH", "CSE");
            Professor prof = new Professor(id++, "Dr. Mahesh", "BTECH", "CSE", "9:00 to 12:00");
            Staff staff = new Staff(id++, "Uncle Mahesh", "BTECH");

            st.DisplayDetail();
            prof.DisplayDetail();
            staff.DisplayDetail();
        }
    }
}
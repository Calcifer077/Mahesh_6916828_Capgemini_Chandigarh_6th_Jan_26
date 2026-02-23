namespace StudentGrading
{
    internal class Program{
        public static void dispDict(Dictionary<int, int> dict)
        {
            foreach (var item in dict.Keys)
            {
                Console.WriteLine(item + " " + dict[item]);
            }
        }

        public static int calcAverage(Dictionary<int, int> dict)
        {
            int avg = 0;
            foreach (var item in dict.Keys)
            {
                avg += dict[item];
            }

            return avg / dict.Count;
        }

        public static void stuAtRisk(Dictionary<int, int> dict, int thres)
        {
            Predicate<int> isGreater = delegate (int i)
            {
                return i < thres;
            };

            List<int> list = dict.Where(kvp => isGreater(kvp.Value)).Select(kvp => kvp.Key).ToList();

            if (list.Count > 0)
            {
                Console.WriteLine("\nStudents at risk (below threshold):");
                foreach (var rollNo in list)
                {
                    Console.WriteLine($"Roll No: {rollNo}, Grade: {dict[rollNo]}");
                }
            }
            else
            {
                Console.WriteLine("\nNo students at risk.");
            }
        }

        public static void updateStuGrade(Dictionary<int, int> dict, int roll, int grade, int thres)
        {
            dict[roll] = grade;

            stuAtRisk(dict, thres);
        }

        static void Main(string[] args)
        {
            // roll no, grade
            Dictionary<int, int> dict =new Dictionary<int, int>();
            dict.Add(1, 92);
            dict.Add(2, 43);
            dict.Add(3, 56);
            dict.Add(4, 87);
            dict.Add(5, 34);

        
            dispDict(dict);

            Console.WriteLine("Average is : " + calcAverage(dict));

            stuAtRisk(dict, 50);

            updateStuGrade(dict, 2, 51, 50);
                    }
    }
}
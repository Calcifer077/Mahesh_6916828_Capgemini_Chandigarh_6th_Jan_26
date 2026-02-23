using System.Runtime.CompilerServices;

namespace AreAllCharactersDistinct
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string s = "hithisismybook";

            HashSet<char> set = new HashSet<char>();

            foreach(var item in s) set.Add(item);

            if(set.Count != s.Length)
            {
                set.Clear();
                string st = "";
                foreach(var item in s)
                {
                    if (set.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        set.Add(item);
                        st += item;
                    }
                }

                Console.WriteLine(st);
            }
            else
            {
                Console.WriteLine(s);
            }
        }
    }
}
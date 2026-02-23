namespace ContainsOnlyNumbers
{
    internal class Program
    {
        public static int ContainsOnlyNumbersMeth(string[] arr)
        {
            foreach (string s in arr)
            {
                foreach(var item in s)
                {
                    if(!char.IsDigit(item)){ return -1;}
                }
            }
            return 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ContainsOnlyNumbersMeth(new string[]{"00", "11"}));
        }
    }
}
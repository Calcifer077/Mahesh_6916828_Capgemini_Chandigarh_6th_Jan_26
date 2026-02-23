namespace MultitaskDelegate
{
    internal class Program
    {

        public delegate void Math(int x, int y);

        class MultiClass
        {
            public void add(int x, int y)
            {
                Console.WriteLine("Addition is: " + (x + y));
            }

            public void sub(int x, int y)
            {
                Console.WriteLine("Subtraction is: " + (x - y));
            }

            public void mul(int x, int y)
            {
                Console.WriteLine("Multiplication is: " + (x * y));
            }

            public void div(int x, int y)
            {
                Console.WriteLine("Division is: " + (x / y));
            }
        }

        static void Main(string[] args)
        {
            MultiClass obj = new MultiClass();
            Math m = new Math(obj.add);
            m += obj.sub; m += obj.mul; m += obj.div;

            m(100, 100);

            m -= obj.div;

            m(50, 20);
        }
    }
}
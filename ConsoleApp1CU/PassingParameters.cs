using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1CU
{
    
    internal class PassingParameters
    {
        void TestOne()
        {
            Console.WriteLine("This is first method.");
        }

        void TestTwo(int x)
        {
            Console.WriteLine("This is second method. " + x);
        }

        string TestThree()
        {
            return "This is the third method.";
        }

        string TestFour(string name)
        {
            return "Hello " + name;
        }

        // method returning multiple values
        void math1(int x, int y, ref int a, ref int b)
        {
            a = x + y;
            b = x * y;
        }

        void math2(int x, int y, out int a, out int b)
        {
            a = x - y;
            b = x / y;
        }

        static void Maint()
        {
            PassingParameters p = new PassingParameters();
            p.TestOne(); p.TestTwo(100);
            Console.WriteLine(p.TestThree());
            Console.WriteLine(p.TestFour("mah"));

            int m = 0, n = 0;
            p.math1(100, 50, ref m, ref n);
            Console.WriteLine(m + " " + n);

            int q, r;
            p.math2(100, 50, out q, out r);
            Console.WriteLine(q + "  " + r);
            Console.ReadLine();
        }
    }
}

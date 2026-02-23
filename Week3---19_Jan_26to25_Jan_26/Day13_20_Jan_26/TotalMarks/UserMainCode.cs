using System;
using System.Collections.Generic;
using System.Text;

namespace TotalMarks
{
    internal class UserMainCode
    {
        public static void solve(int x, int y, int n1, int n2, int m)
        {

            int resx = 0, resy = 0;
            for(int i = 1; i <= n1; i++)
            {
                for(int j = 1; j <= n2; j++)
                {
                    if((i * x) + (j * y) == m)
                    {
                        if (resx < i)
                        {
                            resx = i;
                            resy = j;
                        }
                    }
                }
            }

            if(resx != 0 && resy != 0)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(resx * x + " " + resy * y);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyString
{
    internal class UserMainCode
    {
        public static void solve(int n, string str)
        {
            if(n > str.Length)
            {
                Console.WriteLine("Invalid");
                return;
            }

            int required = n / 2;
            
            for (int i = 0; i <= str.Length - n; i++)
            {
                int consecutiveCount = 1;

                for (int j = i; j < i + n; j++)
                {
                    if (str[j] != 'P' && str[j] != 'S' && str[j] != 'G')
                    {
                        break;
                    }

                    if (j > i && str[j] == str[j - 1])
                    {
                        consecutiveCount++;
                        if (consecutiveCount >= required)
                        {
                            Console.WriteLine("Yes");
                            return;
                        }
                    }
                    else
                    {
                        consecutiveCount = 1;
                    }
                }
            }

            Console.WriteLine("No");

        }
    }
}

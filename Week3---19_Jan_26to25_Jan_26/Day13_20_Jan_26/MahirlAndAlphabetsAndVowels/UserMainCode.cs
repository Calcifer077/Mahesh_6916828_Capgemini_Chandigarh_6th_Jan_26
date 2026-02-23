using System;
using System.Collections.Generic;
using System.Text;

namespace MahirlAndAlphabetsAndVowels
{
    internal class UserMainCode
    {
        public bool isVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }

        public static void solve(string s1, string s2)
        {
            UserMainCode code = new UserMainCode();
            HashSet<Char> s = new HashSet<Char>();

            for (int i = 0; i < s2.Length; i++)
            {
                if (!code.isVowel(s2[i]))
                {
                    s.Add(s2[i]);
                }
            }

            string news = "";

            for (int i = 0; i < s1.Length; i++)
            {
                if (!s.Contains(s1[i]))
                {
                    news += s1[i];
                }
            }

            Stack<Char> st = new Stack<Char>();

            for(int i = 0; i < news.Length; i++)
            {
                if(st.Count > 0)
                {
                    if(st.Peek() == news[i])
                    {
                        continue;
                    }
                    else
                    {
                        st.Push(news[i]);
                    }
                }
                else
                {
                    st.Push(news[i]);
                }
            }

            string newss = "";
            while(st.Count > 0)
            {
                newss += st.Pop();
            }

            char[] charArray = newss.ToCharArray();
            Array.Reverse(charArray);

            Console.WriteLine(new String(charArray));
        }
    }
}

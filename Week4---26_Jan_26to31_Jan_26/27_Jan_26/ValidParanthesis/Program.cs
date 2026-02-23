namespace ValidParanthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "{[(])}";
            bool output = true;
            
            Stack<char> st = new Stack<char>();

            for(int i =0; i<input.Length; i++)
            {
                char c = input[i];

                if(c == '(' || c == '[' || c == '{')
                {
                    st.Push(c);
                }else
                {
                    if(c == ')')
                    {
                        if(st.Count > 0 && st.Peek() == '(')
                        {
                            st.Pop();
                        }
                        else
                        {
                            output = false;
                            
                            break;
                        }
                    }else if(c == ']')
                    {
                        if(st.Count > 0 && st.Peek() == '[')
                        {
                            st.Pop();
                        }
                        else
                        {
                            output = false;
                            
                            break;
                        }
                    }else if(c == '}')
                    {
                        if(st.Count > 0 && st.Peek() == '{')
                        {
                            st.Pop();
                        }
                        else
                        {
                            output = false;
                            
                            break;
                        }
                    }
                }
            }

            if(st.Count != 0) output = false;

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);

        }
    }
}
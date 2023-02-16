namespace CorrectBracketSequence;

class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        Stack<char> stack = new Stack<char>();
        
        foreach (char c in input)
        {
            if (c == '(' | c == '['|  c == '{')
            {
                stack.Push(c);
                continue;
            }
            
            if (c == ')')
            {
                if (stack.Count == 0)
                    stack.Push(c);

                char peek = stack.Peek();
                if (peek == '(')
                {
                    stack.Pop();
                    continue;
                }
                stack.Push(c);
            }
            
            if (c == '}')
            {
                if (stack.Count == 0)
                    stack.Push(c);
                    
                char peek = stack.Peek();
                if (peek == '{')
                {
                    stack.Pop();
                    continue;
                }
                stack.Push(c);
            }
            
            
            if (c == ']')
            {
                if (stack.Count == 0)
                    stack.Push(c);

                char peek = stack.Peek();
                if (peek == '[')
                {
                    stack.Pop();
                    continue;
                }
                stack.Push(c);
            }
        }

        if (stack.Count == 0)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
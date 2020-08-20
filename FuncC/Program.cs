using System;

namespace FuncCConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var y = F.ToString2(123);

            Console.WriteLine(y);
        }

    }

    public static class F
    {
        public static readonly Func<int, string> ToString2 = i => i.ToString();

        public static readonly Func<int, Func<int, int>> Add = a => b => a + b;
    }

}
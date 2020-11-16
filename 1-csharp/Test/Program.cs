using System;

namespace Test.ConsoleApp
{
    class Program
    {
        internal Action<int> UpdateCapturedLocalVariable;
        internal Func<int, bool> IsEqualToCapturedLocalVariable;

        public void Run(int input)
        {
            int j = 0;

            UpdateCapturedLocalVariable = x =>
            {
                j = x;
                bool result = j > input;
                Console.WriteLine($"{j} is greater than {input}: {result}");
            };

            IsEqualToCapturedLocalVariable = x => x == j;
        }


        static void Main(string[] args)
        {
            Greet(GetName());
        }

        public static Func<string> GetName = () =>
        {
            Console.Write("What is your name? ");
            return Console.ReadLine();
        };

        public static Action<string> Greet = (name) => { Console.WriteLine($"Hello, {name}!"); };
    }
}

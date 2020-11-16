using System;

namespace Prime.Service
{
    public class Program
    {
		public static void Main()
		{
			Console.WriteLine(IsPrime(5));
		}
        public static bool IsPrime(int candidate)
        {
            if (candidate <= 1)
            {
                return false;
            }
            bool IsPrime = true;
            int i = 2;
            while(IsPrime && i < candidate)
            {
                if(candidate % i == 0)
                    IsPrime = false;
                else
                    i++;
            }

            return IsPrime;
        }
    }
}

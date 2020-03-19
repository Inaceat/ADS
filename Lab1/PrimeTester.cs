using System;
using System.Timers;

namespace Lab1
{
    public class PrimeTester
    {
        public enum PrimeTestType
        {
            TrialDivision,
            EratosthenesSieve
        }
        

        public static bool IsPrime(uint n, PrimeTestType testType)
        {
            switch (testType)
            {
            case PrimeTestType.TrialDivision:
                return IsTrialPrime(n);

            case PrimeTestType.EratosthenesSieve:
                return IsEratosthenesPrime(n);

            default:
                throw new ArgumentOutOfRangeException(nameof(testType), testType, "Unknown test specified!");
            }
        }

        private static bool IsTrialPrime(uint n)
        {
            if (2 > n)
                return false;

            var sqrt = (uint)Math.Sqrt(n) + 1;

            for (var i = 2; i < sqrt; ++i)
            {
                if ((n / i) * i == n)
                    return false;
            }

            return true;
        }
        private static bool IsEratosthenesPrime(uint n)
        {
            return false;
        }


        private static readonly string[] MenuVariants =
        {
            "Exit",
            "Trial division",
            "Eratosthenes sieve"
        };

        static void Main(string[] args)
        {
            while (true)
            {
                var menuChoice = ReadVariantFromConsole(MenuVariants);

                if (0 == menuChoice)
                    return;

                PrimeTestType.TryParse(MenuVariants[menuChoice], out PrimeTestType testType);
                
                uint n;
                do
                {
                    Console.Write("N = ");

                } while (!uint.TryParse(Console.ReadLine(), out n));


                var isNPrime = IsPrime(n, testType);


                Console.WriteLine("{0} is {1}prime", n, isNPrime ? "" : "not ");
            }
        }


        private static int ReadVariantFromConsole(string[] variants)
        {
            while (true)
            {
                for (var i = 0; i < variants.Length; ++i)
                    Console.WriteLine("{0}. {1}", i + 1, variants[i]);

                var userInput = Console.ReadLine();
                int choice;
                try
                {
                    choice = int.Parse(userInput);
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong input, try again");
                    continue;
                }

                if (0 < choice && choice <= variants.Length)
                    return choice - 1;

                Console.WriteLine("Wrong input, try again");
            }
        }
    }
}

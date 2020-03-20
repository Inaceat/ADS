using System;
using System.Collections;
using System.Linq;
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
        

        public static bool IsPrime(int n, PrimeTestType testType)
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

        private static bool IsTrialPrime(int n)
        {
            if (2 > n)
                return false;

            var sqrt = (int)Math.Sqrt(n) + 1;

            for (var i = 2; i < sqrt; i += 2)
            {
                if ((n / i) * i == n)
                    return false;
            }

            return true;
        }
        private static bool IsEratosthenesPrime(int n)
        {
            if (2 > n)
                return false;

            var isPrime = new BitArray(n + 1, true);

            for (var i = 2; i < (int)Math.Sqrt(n) + 1; ++i)
            {
                if (!isPrime[i])
                    continue;

                for (var j = i*2; j <= n; j+=i)
                    isPrime[j] = false;
            }

            return isPrime[n]; 
        }


        private static readonly string[] MenuVariants =
        {
            "Exit",
            PrimeTestType.TrialDivision.ToString(),
            PrimeTestType.EratosthenesSieve.ToString()
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

                    var isValid = uint.TryParse(Console.ReadLine(), out n);

                    if (isValid && n < 1000000)
                        break;

                    if (!isValid)
                        Console.WriteLine("Invalid number");

                    if (n >= 1000000)
                        Console.WriteLine("Number is too big");

                } while (true);


                var isNPrime = IsPrime((int)n, testType);


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

using System;

namespace Lab3
{
    class Program
    {
        private static void DoStockExchangeCheating()
        {

        }

        private static void DoMaxFind()
        {
            var finder = new ExpressionMaxFinder
            (
                new[] {1, 2, -4, 5}, 
                new[] {'+', '*', '+'}
            );

            finder.Find();
            
            Console.WriteLine("{0} = {1}", finder.Expression(), finder.Result());
        }
        

        static void Main(string[] args)
        {
            while (true)
            {
                var choice = 2;/*ReadVariantFromConsole(new[]
                {
                    "Exit",
                    "Stock exchange cheat",
                    "Expression max"
                });*/

                switch (choice)
                {
                case 0:
                    return;

                case 1:
                    DoStockExchangeCheating();
                    break;

                case 2:
                    DoMaxFind();
                    return;//break;
                }
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

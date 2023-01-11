using System;

namespace Lab9
{
    public class Program
    {

        public static Money FindMinBank(MoneyArray banks)
        {
            Money minimum = new Money(1000, 99);
            bool isFound = false;
            for (int i = 0; i < banks.getBanks.Length; i++)
                if (minimum > banks[i])
                {
                    minimum = banks[i];
                    isFound = true;
                }
             Console.WriteLine($"Сумма {minimum} минимальна");
             return minimum;
        }

        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Menu();
        }
    }
}

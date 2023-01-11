using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    public class MoneyArray
    {
        static int GetInt(string message)
        {
            int key = 0;
            bool isCorrect;
            do
            {
                Console.WriteLine(message);
                isCorrect = int.TryParse(Console.ReadLine(), out key) && key >= 0;
                if (!isCorrect)
                    Console.WriteLine("Введено недопустимое значение!");
            } while (!isCorrect);
            return key;
        }
        private Money[] banks;
        public MoneyArray()
        {
            banks = new Money[1];
            banks[0] = new Money();
        }
        public MoneyArray(int number, int min, int max)
        {
            banks = new Money[number];
            Random rand = new Random();
            for (int i = 0; i < number; i++)
                banks[i] = new Money(rand.Next(min, max + 1), rand.Next(0, 100));
        }
        public MoneyArray(int number)
        {
            banks = new Money[number];
            for (int i = 0; i < number; i++)
            {
                int Rub = GetInt($"Введите количество рублей для {i + 1} объекта: ");
                int Kop = GetInt($"Введите количество копеек для {i + 1} объекта: ");
                while (Kop > 99)
                {
                    Console.WriteLine("Копеек не может быть более 99!");
                    Kop = GetInt($"Введите количество копеек для {i + 1} объекта: ");
                }
                banks[i] = new Money(Rub, Kop);
            }
        }
        public override string ToString()
        {
            string result = "{ ";
            for (int i = 0; i < banks.Length; i++)
            {
                result += banks[i];
                result += ";";
            }
            result += " }";
            return result;
        }

        public Money this[int index]
        {
            get
            {
                if (index >= 0 && index < banks.Length)
                    return banks[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < banks.Length)
                    banks[index] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public Money[] getBanks
        {
            get
            {
                return banks;
            }
            set
            {
                banks = value;
            }
        }
    }
}

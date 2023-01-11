using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    public class Money
    {
        private static int counter = 0;
        private int rubles;
        private int kopeks;
        public Money()
        {
            rubles = 0;
            kopeks = 0;
            ++counter;
        }
        public Money(int rubles, int kopeks)
        {
            if (rubles < 0 || (kopeks < 0 || kopeks > 99))
            {
                Console.WriteLine("Некорректное значение рублей или копеек!");
                return;
            }
            else
            {
                this.rubles = rubles;
                this.kopeks = kopeks;
                ++counter;
            }
        }
        public Money(Money bank)
        {
            rubles = bank.rubles;
            kopeks = bank.kopeks;
        }
        public override string ToString()
        {
            return $"{rubles}.{kopeks:00}";
        }

        public int Rub
        {
            get
            {
                return rubles;
            }
            set
            {
                if (rubles < 0)
                    Console.WriteLine("Некорректное значение рублей!");
                else
                    rubles = value;
            }
        }
        public int Kop
        {
            get
            {
                return kopeks;
            }
            set
            {
                if (kopeks < 0 || kopeks > 99)
                    Console.WriteLine("Некорректное значение копеек!");
                else
                    kopeks = value;
            }
        }
        public static int count
        {
            get
            {
                return counter;
            }
        }
        public Money AddKopeks(int addKopeks)
        {
            this.rubles = rubles + (kopeks + addKopeks) / 100;
            this.kopeks = (kopeks + addKopeks) % 100;
            return this;
        }
        public static Money operator ++(Money bank)
        {
            bank.rubles = bank.rubles + (bank.kopeks + 1) / 100;
            bank.kopeks = (bank.kopeks + 1) % 100;
            Console.WriteLine("Инкрементирование выполнено");
            return bank;
        }
        public static Money operator --(Money bank)
        {
            if (bank.kopeks < 1)
                if (bank.rubles < 1)
                    Console.WriteLine("Недостаточно средств!");
                else
                {
                    --bank.rubles;
                    bank.kopeks = 99;
                    Console.WriteLine("Декрементирование выполнено");
                }
            else
            {
                --bank.kopeks;
                Console.WriteLine("Декрементирование выполнено");
            }
                return bank;
        }
        public static Money operator +(Money bank, int kop)
        {
            bank.AddKopeks(kop);
            return bank;
        }
        public static Money operator +(int kop, Money bank)
        {
            bank.AddKopeks(kop);
            return bank;
        }
        public static Money operator -(Money bank, int kop)
        {
            if ((bank.rubles * 100 + bank.kopeks) < kop)
                Console.WriteLine("Недостаточно средств!");
            else
            {
                int kopeks = bank.rubles * 100 + bank.kopeks;
                bank.rubles = 0;
                bank.kopeks = 0;
                kopeks -= kop;
                bank.AddKopeks(kopeks);
            }
            return bank;
        }
        public static Money operator -(int kop, Money bank)
        {
            if ((bank.rubles * 100 + bank.kopeks) > kop)
                Console.WriteLine("Результат меньше 0!");
            else
            {
                int kopeks = bank.rubles * 100 + bank.kopeks;
                bank.rubles = 0;
                bank.kopeks = 0;
                kopeks -= kop;
                bank.AddKopeks(kopeks);
            }
            return bank;
        }
        public static bool operator <(Money one, Money two)
        {
            int kopeksMin = one.rubles * 100 + one.kopeks;
            int kopeksBank = two.rubles * 100 + two.kopeks;
            return kopeksMin < kopeksBank;
        }
        public static bool operator >(Money one, Money two)
        {
            int kopeksMin = one.rubles * 100 + one.kopeks;
            int kopeksBank = two.rubles * 100 + two.kopeks;
            return kopeksMin > kopeksBank;
        }
        public static explicit operator int(Money bank)
        {
            return bank.rubles;
        }
        public static implicit operator double(Money bank)
        {
            return (double)bank.kopeks / 100.0;
        }
    }
}

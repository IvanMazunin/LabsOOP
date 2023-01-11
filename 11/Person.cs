using System;
using System.Collections;
using System.Text;

namespace Lab11
{
    public class Person : IRandomInit, IComparable, ICloneable
    {
        protected readonly string[] firstNames = new string[] { "Avery", "Max", "Sam", "Reagan", "Karter", "Charlie", "Casey", "Bobbie", "Morgan", "Remy" };
        protected readonly string[] lastNames = new string[] { "Alford", "Barnes", "Carter", "Derrick", "Evans", "Ford", "Green", "Harrison", "Jenkins", "Kendal" };
        protected readonly string[] genders = new string[] { "Мужчина", "Женщина" };
        private string firstName;
        private string lastName;
        private string gender;
        private int age;

        public Person()
        {
            this.RandomInit();
        }
        public Person(string firstName, string lastName, string gender, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
        }
        public Person(Person copyPerson)
        {
            firstName = copyPerson.firstName;
            lastName = copyPerson.lastName;
            gender = copyPerson.gender;
            age = copyPerson.age;
        }
        public static Person InputPerson()
        {
            string firstName, lastName, gender;
            int age;
            Console.Write("Введите имя: ");
            firstName = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            lastName = Console.ReadLine();
            Console.Write("Введите пол: ");
            gender = Console.ReadLine();
            Console.Write("Введите возраст: ");
            age = int.Parse(Console.ReadLine());
            return new Person(firstName, lastName, gender, age);
        }
        public override string ToString()
        {
            return $"Full name: {firstName} {lastName}\n Gender: {gender}\n Age: {age}";
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        virtual public void RandomInit()
        {
            Random rand = new Random();
            firstName = firstNames[rand.Next(0, 10)];
            System.Threading.Thread.Sleep(15);
            lastName = lastNames[rand.Next(0, 10)];
            System.Threading.Thread.Sleep(15);
            age = rand.Next(18, 71);
            gender = genders[rand.Next(0, 2)];
        }
        virtual public int CompareTo(object obj)
        {
            Person tmp = (Person)obj;
            if (this.age > tmp.age)
                return 1;
            else if (this.age < tmp.age)
                return -1;
            else
                return 0;
        }
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }
        public object Clone()
        {
            return new Person(this.firstName, this.lastName, this.gender, this.age);
        }
        public override bool Equals(object obj)
        {
            return (obj is Person && ((Person)obj).firstName == this.firstName && ((Person)obj).lastName == this.lastName);
        }
    }
    public class SortByType : IComparer
    {
        int IComparer.Compare(object objFirst, object objSecond)
        {
            Person tmpFirst = (Person)objFirst;
            Person tmpSecond = (Person)objSecond;
            return String.Compare(tmpFirst.FirstName, tmpFirst.FirstName);
        }
    }
}
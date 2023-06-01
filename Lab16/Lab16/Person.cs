using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Lab16.MainMenu;
namespace Lab10
{
    [Serializable]
    public class Person : IRandomInit, IComparable, ICloneable
    {
        protected readonly string[] firstNames = new string[] { "Avery", "Max", "Sam", "Reagan", "Karter", "Charlie", "Casey", "Bobbie", "Morgan", "Remy" };
        protected readonly string[] lastNames = new string[] { "Alford", "Barnes", "Carter", "Derrick", "Evans", "Ford", "Green", "Harrison", "Jenkins", "Kendal" };
        protected readonly string[] genders = new string[] { "Мужчина", "Женщина" };
        private string firstName;
        private string lastName;
        private string gender;
        private int age;
        public Person next;
        protected static Random rnd = new Random();

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public Person()
        {
            this.RandomInit();
            next = null;
        }

        public Person(string firstName, string lastName, int age, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }
        public Person(Person s)
        {
            FirstName = s.FirstName;
            LastName = s.LastName;
            Age = s.Age;
            Gender = s.Gender;
        }
        public virtual void Show()
        {
            Console.WriteLine(
                $"Тип: Человек\n" +
                $"Имя: {FirstName} {LastName}\n" +
                $"Возраст: {Age} $\n" +
                $"Порт: {Gender}\n");
        }

        virtual public void RandomInit()
        {
            Random rand = new Random();
            firstName = firstNames[rand.Next(0, 10)];
            lastName = lastNames[rand.Next(0, 10)];
            age = rand.Next(18, 71);
            gender = genders[rand.Next(0, 2)];
        }
        public virtual int CompareTo(object obj)
        {
            string firstName = "";
            firstName = ((Person)obj).FirstName;
            return String.Compare(this.FirstName, firstName);
        }
        public virtual object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        public virtual object Clone()
        {
            return new Person("Клон" + this.firstName, this.lastName, this.age, this.gender);
        }
        public override bool Equals(object obj)
        {
            if (this == null) return false;
            if (obj is Person s)
                return s.FirstName == this.FirstName && s.Age == this.Age && s.Gender == this.Gender;
            else return false;
        }
        public override string ToString()
        {
            return $"Человек: {FirstName} {LastName} " + $"Возраст: {Age} " + $"Пол: {Gender}\n";
        }
        public override int GetHashCode()
        {
            int code = 0;
            string str = FirstName + LastName + Age + Gender;
            foreach (char c in str)
            {
                code += (int)c;
            }
            return code;
        }

    }
}

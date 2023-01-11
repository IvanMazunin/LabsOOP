using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    public class Student : Person
    {
        private int year;
        public Student()
        {
            this.RandomInit();
        }
        public Student(string firstName, string lastName, string gender, int age, int year) : base(firstName, lastName, gender, age)
        {
            this.year = year;
        }
        public Student(Student copyStudent)
        {
            this.FirstName = copyStudent.FirstName;
            this.LastName = copyStudent.LastName;
            this.Gender = copyStudent.Gender;
            this.Age = copyStudent.Age;
            this.year = copyStudent.year;
        }
        public Person BasePerson
        {
            get
            {
                return new Person(this.FirstName, this.LastName, this.Gender, this.Age);
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public override string ToString()
        {
            return $"Студент: {this.FirstName} {this.LastName}\n Пол: {this.Gender}\n Возраст: {this.Age}\n Курс: {this.year}";
        }
        public override void RandomInit()
        {
            string[] firstNames = new string[] { "Avery", "Max", "Sam", "Reagan", "Karter", "Charlie", "Casey", "Bobbie", "Morgan", "Remy" };
            string[] lastNames = new string[] { "Alford", "Barnes", "Carter", "Derrick", "Evans", "Ford", "Green", "Harrison", "Jenkins", "Kendal" };
            string[] genders = new string[] { "Мужчина", "Женщина" };
            Random rand = new Random();
            this.FirstName = firstNames[rand.Next(0, 10)];
            this.LastName = lastNames[rand.Next(0, 10)];
            this.Gender = genders[rand.Next(0, 2)];
            this.Age = rand.Next(18, 71);
            year = rand.Next(1, 7);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    public class Employee : Person, IRandomInit
    {
        private string jobTitle;
        protected readonly string[] jobTitles = new string[] { "Охранник", "Вахтёр", "Преподаватель", "Лаборант", "Уборщик" };
        public Employee() : base()
        {
            jobTitle = "ПУСТО";
        }
        public Employee(string firstName, string lastName, string gender, int age, string jobTitle) : base(firstName, lastName, gender, age)
        {
            this.jobTitle = jobTitle;
        }
        public Employee(Employee copyEmployee)
        {
            this.FirstName = copyEmployee.FirstName;
            this.LastName = copyEmployee.LastName;
            this.Gender = copyEmployee.Gender;
            this.Age = copyEmployee.Age;
            this.jobTitle = copyEmployee.jobTitle;
        }
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
            set
            {
                jobTitle = value;
            }
        }
        public override void VirtualShow()
        {
            Console.WriteLine($"Сотрудник: {this.FirstName} {this.LastName}\n Пол: {this.Gender}\n Возраст: {this.Age}\n Должность: {this.jobTitle}");
        }
        public void Show()
        {
            Console.WriteLine($"Сотрудник: {this.FirstName} {this.LastName}\n Пол: {this.Gender}\n Возраст: {this.Age}\n Должность: {this.jobTitle}");
        }
        public override void RandomInit()
        {
            Random rand = new Random();
            this.FirstName = firstNames[rand.Next(0, 10)];
            this.LastName = lastNames[rand.Next(0, 10)];
            this.Gender = genders[rand.Next(0, 2)];
            this.Age = rand.Next(18, 71);
            jobTitle = jobTitles[rand.Next(0, 5)];
        }
    }
}
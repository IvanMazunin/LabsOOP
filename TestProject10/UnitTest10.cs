namespace TestProject10
{
    [TestClass]
    public class UnitTest10
    {
        [TestMethod]
        public void TestProfessorRandom()
        {
            Professor professor = new Professor();
            professor.RandomInit();
            Assert.IsNotNull(professor);
        }
        [TestMethod]
        public void TestProfessorConstructor()
        {
            List<string>subjects = new List<string>();
            subjects.Add("ООП");
            Professor professor = new Professor("Иван", "Иван", "Иван", 35, "Иван", subjects);
            Assert.IsNotNull(professor);
            Professor copyProfessor = new Professor(professor);
            Assert.IsNotNull(copyProfessor);
            professor.RandomInit();
            Assert.IsNotNull(professor);
        }
        [TestMethod]
        public void TestProfessorSubjects()
        {
            List<string> subjects = new List<string>();
            subjects.Add("ООП");
            Professor professor = new Professor("Иван", "Иван", "Иван", 35, "Иван", subjects);
            Assert.AreEqual(professor.Subjects[0], subjects[0]);
            subjects[0] = "Теорвер";
            professor.Subjects = subjects;
            Assert.AreEqual(professor.Subjects[0], "Теорвер");
        }
        [TestMethod]
        public void TestIndex()
        {
            List<string> subjects = new List<string>();
            subjects.Add("ООП");
            Professor professor = new Professor("Иван", "Иван", "Иван", 35, "Иван", subjects);
            Assert.AreEqual(professor.Subjects[0], subjects[0]);
            subjects[0] = "Теорвер";
            professor.Subjects = subjects;
            Assert.AreEqual(professor[0], "Теорвер");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => professor[-1] = "Теорвер");
            professor[0] = "ООП";
            Assert.AreEqual(professor[0], "ООП");
        }
        [TestMethod]
        public void TestPersonRandomInit()
        {
            Person person = new Person();
            person.RandomInit();
            Assert.IsNotNull(person);
        }
        [TestMethod]
        public void TestEmployeeRandomInit()
        {
            Employee employee = new Employee();
            employee.RandomInit();
            Assert.IsNotNull(employee);
        }
        [TestMethod]
        public void TestStudentRandomInit()
        {
            Student student = new Student();
            student.RandomInit();
            Assert.IsNotNull(student);
        }
        [TestMethod]
        public void TestCopyPerson()
        {
            Person person1 = new Person();
            person1.RandomInit();
            Person person2 = new Person(person1);
            Assert.AreEqual(person1, person2);
        }
        [TestMethod]
        public void TestCopyEmployee()
        {
            Employee person1 = new Employee();
            person1.RandomInit();
            Employee person2 = new Employee(person1);
            Assert.AreEqual(person1, person2);
        }
        [TestMethod]
        public void TestCopyStudent()
        {
            Student person1 = new Student();
            person1.RandomInit();
            Student person2 = new Student(person1);
            Assert.AreEqual(person1, person2);
        }
        [TestMethod]
        public void TestYearStudent()
        {
            Student person1 = new Student("Иван", "Иванов", "мужчина", 19, 1);
            Assert.AreEqual(person1.Year, 1);
            person1.Year = 2;
            Assert.AreEqual(person1.Year, 2);
        }
        [TestMethod]
        public void TestPerson()
        {
            Person p = new Person("Антон", "Антонов", "Мужчина", 22);
            Person p1 = new Person();
            Person p2 = new Person("Антон", "Антонов", "Мужчина", 22);
            Person p3 = new Person("А", "А", "А", 1);
            Person p4 = new Person("Б", "Б", "Б", 1);
            Person p_clone = (Person)p.Clone();
            Assert.IsInstanceOfType(p, typeof(Person));
            Assert.IsInstanceOfType(p1, typeof(Person));
            Assert.IsInstanceOfType(p.ToString(), typeof(string));
            Assert.AreNotSame(p, p_clone);
            Assert.AreEqual(p, p_clone);
            Assert.IsTrue(p.Equals(p2));
            Assert.IsFalse(p.Equals(p3));
            Assert.AreEqual(p3.CompareTo(p4), -1);
            Assert.AreEqual(p4.CompareTo(p3), 1);
            Assert.AreEqual(p.CompareTo(p2), 0);
        }
        [TestMethod]
        public void TestPerson()
        {
        }
}
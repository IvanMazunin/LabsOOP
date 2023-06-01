using Lab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Lab16
{
    public class MainMenu
    {
        private IDictionary<int, Person> personDictionary;
        private IMenu<int> mainMenu;
        private bool isEnd;
        private string folderName = "Файлы";
        private PersonSave personSave;
        private PersonLoad personLoad;
        private PersonJsonSerializer personJsonSerializer;
        private PersonJsonDeserializer personJsonDeserializer;
        private PersonXMLSerializer personXMLSerializer;
        private PersonXMLDeserializer personXMLDeserializer;
        private BinaryFormatter personBinary;
        public MainMenu()
        {
            personDictionary = new Dictionary<int, Person>();
            isEnd = false;
            CreateMenu();
            personSave = new PersonSave();
            personLoad = new PersonLoad();
            personJsonSerializer = new PersonJsonSerializer();
            personJsonDeserializer = new PersonJsonDeserializer();
            personXMLSerializer = new PersonXMLSerializer();
            personXMLDeserializer = new PersonXMLDeserializer();
            personBinary = new BinaryFormatter();
        }
        public void Run()
        {
            int key;
            while (!isEnd)
            {
                Console.WriteLine(mainMenu);
                Console.Write("Ожидание команды: ");
                string input = Console.ReadLine();
                key = Int32.Parse(input);
                mainMenu.Execute(key);

            }
        }
        public static int GetInt(string errMsg, int min = int.MinValue, int max = int.MaxValue)
        {
            int result = 0;
            bool isConvert = false;
            do
            {
                isConvert = false;
                while (!isConvert)
                {
                    string buffer = Console.ReadLine();
                    isConvert = int.TryParse(buffer, out result);
                    if (!isConvert) Console.WriteLine("Неверный символ");
                    else if (result > max || result < min) Console.WriteLine(errMsg);
                }
            } while (result > max || result < min);
            return result;
        }
        private void CreateMenu()
        {
            mainMenu = new Menu();
            for (int i = 1; i < 12; i++)
            {
                mainMenu.AddKey(i);
            }
            mainMenu.SetDescription(1, "Добавить элемент");
            mainMenu.SetDescription(2, "Добавить случайный элемент");
            mainMenu.SetDescription(3, "Удалить элемент");
            mainMenu.SetDescription(4, "Вывод элементов");
            mainMenu.SetDescription(5, "Бинарная сериализация");
            mainMenu.SetDescription(6, "Бинарная десериализация");
            mainMenu.SetDescription(7, "Сериализация в JSON");
            mainMenu.SetDescription(8, "Десериализация JSON");
            mainMenu.SetDescription(9, "Cериализация XML");
            mainMenu.SetDescription(10, "Десериализация XML");
            mainMenu.SetDescription(11, "Выход");
            mainMenu.OnKeySetAction(1, AddPerson);
            mainMenu.OnKeySetAction(2, AddRandomPerson);
            mainMenu.OnKeySetAction(3, RemovePerson);
            mainMenu.OnKeySetAction(4, PrintDictionary);
            mainMenu.OnKeySetAction(5, SaveBinary);
            mainMenu.OnKeySetAction(6, LoadBinary);
            mainMenu.OnKeySetAction(7, SaveJSON);
            mainMenu.OnKeySetAction(8, LoadJSON);
            mainMenu.OnKeySetAction(9, SaveXML);
            mainMenu.OnKeySetAction(10, LoadXML);
        }
        private void AddPerson()
        {
            string firstName;
            string lastName;
            int age;
            string gender;
            int key;
            Console.Write("Ключ: ");
            key = GetInt("Ошибка ввода", 0);
            Console.Write("Имя: ");
            firstName = Console.ReadLine();
            Console.Write("Фамилия: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Возраст: ");
            age = GetInt("Ошибка ввода", 0);
            Console.WriteLine("Пол: ");
            gender = Console.ReadLine();
            Person p = new Person(firstName, lastName, age, gender);
            personDictionary.Add(key, p);
        }
        private void AddRandomPerson()
        {

            Console.Write("Ключ: ");
            int key = GetInt("Ошибка ввода", 0);
            Person p = new Person();
            p.RandomInit();
            personDictionary.Add(key, p);
        }
        private void RemovePerson()
        {
            int key;
            Console.WriteLine($"Ключ: ");
            key = GetInt("Ошибка ввода", 0);
            if (!personDictionary.ContainsKey(key))
            {
                Console.WriteLine("Такого ключа не существует");
            }
            else
            {
                personDictionary.Remove(key);
            }
        }
        private void PrintDictionary()
        {
            foreach (var kvp in personDictionary)
            {
                Console.WriteLine($" Ключ {kvp.Key}:\n {kvp.Value}");
            }
        }
        private string CreateFolder(string newFolderName)
        {
            string filePath = System.Reflection.Assembly.GetExecutingAssembly().Location; //строка пути файла
            string informationFolder = System.IO.Path.GetDirectoryName(filePath); //сведенья о каталоге для указанного пути
            string fullFolderNamePath = System.IO.Path.Combine(informationFolder, newFolderName); //полный путь к папке
            if (!System.IO.Directory.Exists(fullFolderNamePath)) //если такая папка не существует
            {
                System.IO.Directory.CreateDirectory(fullFolderNamePath);
            }
            return fullFolderNamePath;
        }
        private void SaveBinary()
        {
            string content = CreateFolder(folderName);
            string filename;
            Console.WriteLine("Введите имя файла: ");
            filename = Console.ReadLine();
            Console.WriteLine(content);
            string fileNamePath = System.IO.Path.Combine(content, filename);
            FileStream f = new FileStream(fileNamePath, FileMode.Create);
            personBinary.Serialize(f, personDictionary);
            f.Close();
        }
        private void LoadBinary()
        {
            string content = CreateFolder(folderName);
            string filename;
            Console.WriteLine("Введите имя файла: ");
            filename = Console.ReadLine();
            string fileNamePath = System.IO.Path.Combine(content, filename);
            FileStream fileStream = new FileStream(fileNamePath, FileMode.Open);
            personDictionary = (Dictionary<int, Person>)personBinary.Deserialize(fileStream);
            fileStream.Close();
            if (personDictionary == null) return;
            foreach (var item in personDictionary)
                Console.WriteLine(item.ToString());
            Console.WriteLine("Загрузка завершена!");
        }
        private void SaveJSON()
        {
            string content = CreateFolder(folderName);
            string filename;
            Console.WriteLine("Введите имя файла: ");
            filename = Console.ReadLine();
            Console.WriteLine(content);
            string fileNamePath = System.IO.Path.Combine(content, filename);
            personSave.Save(personJsonSerializer, fileNamePath, personDictionary);
        }

        private void LoadJSON()
        {
            string content = CreateFolder(folderName);
            string filename;
            Console.WriteLine("Введите имя файла: ");
            filename = Console.ReadLine();
            string fileNamePath = System.IO.Path.Combine(content, filename);
            personDictionary = personLoad.Load(personJsonDeserializer, fileNamePath);
            if (personDictionary == null) return;
            Console.WriteLine("Загрузка завершена!");
            PrintDictionary();
        }
        private void SaveXML()
        {
            string content = CreateFolder(folderName);
            string filename;
            Console.WriteLine("Введите имя файла: ");
            filename = Console.ReadLine();
            Console.WriteLine(content);
            string fileNamePath = System.IO.Path.Combine(content, filename);
            personSave.Save(personXMLSerializer, fileNamePath, personDictionary);
        }
        private void LoadXML()
        {
            string content = CreateFolder(folderName);
            string filename;
            Console.WriteLine("Введите имя файла: ");
            filename = Console.ReadLine();
            Console.WriteLine(content);
            string fileNamePath = System.IO.Path.Combine(content, filename);
            personLoad.Load(personXMLDeserializer, fileNamePath);
            if (personDictionary == null) return;
            Console.WriteLine("Загрузка завершена!");
        }
    }
}

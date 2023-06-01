using Lab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Lab16
{
    public class PersonXMLSerializer : ISerializer
    {
        public void Serialize<T>(Stream stream, IDictionary<T, Person> persons)
        {
            XElement root = new XElement("Коллекция");
            foreach (KeyValuePair<T, Person> kvp in persons)
            {
                T key = kvp.Key;
                string firstName = kvp.Value.FirstName;
                string lastName = kvp.Value.LastName;
                int age = kvp.Value.Age;
                string gender = kvp.Value.Gender;
                XElement person = new XElement("Человек");
                person.Add(new XElement("Имя", firstName));
                person.Add(new XElement("Фамилия", lastName));
                person.Add(new XElement("Возраст", age));
                person.Add(new XElement("Пол", gender));
                XElement element = new XElement("Ключ" + key.ToString(), person);
                root.Add(element);
            }

            XDocument document = new XDocument();
            document.Add(root);
            document.Save(stream);
        }
    }
    public class PersonXMLDeserializer : IDeserializer
    {
        public Dictionary<int, Person> Deserialize<T>(Stream stream)
        {
            XElement root = XDocument.Load(stream).Element("Коллекция");
            Dictionary<int, Person> dict = new Dictionary<int, Person>();
            foreach (var element in root.Elements())
            {
                int key = Convert.ToInt32(element.Name.LocalName.Last());
                Person person = new Person();
                foreach (var e in element.Elements().First().Elements())
                {
                    switch (e.Name.LocalName)
                    {
                        case "Имя":
                            person.FirstName = e.Value;
                            break;
                        case "Фамилия":
                            person.FirstName = e.Value;
                            break;
                        case "Возраст":
                            person.Age = Convert.ToInt32(e.Value);
                            break;
                        case "Пол":
                            person.Gender = e.Value;
                            break;
                    }
                }
                dict.Add(key, person);
            }
            foreach (var item in dict)
                Console.WriteLine(item.ToString());
            return dict;
        }
    }
}

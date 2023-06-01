using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10;
using System.IO;
using System.Security;

namespace Lab16
{
    public class PersonSave
    {
        public void Save(ISerializer serializer, string fileNamePath, IDictionary<int, Person> persons)
        {
            using FileStream stream = new FileStream(fileNamePath, FileMode.Create);
            serializer.Serialize(stream, persons);
            stream.Close();
        }
    }
    public class PersonLoad
    {
        public IDictionary<int, Person>? Load(IDeserializer deserializer, string fileNamePath)
        {
            try
            {
                using FileStream stream = new FileStream(fileNamePath, FileMode.Open);
                return deserializer.Deserialize<Dictionary<int, Person>>(stream);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл не существует");
                return null;
            }
        }
    }
}

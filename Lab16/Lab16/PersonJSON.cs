using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10;
using System.Text.Json;
namespace Lab16
{
    public class PersonJsonSerializer : ISerializer
    {
        public void Serialize<T>(Stream stream, IDictionary<T, Person> persons)
        {
            JsonSerializer.Serialize(stream, persons);
        }
    }
    public class PersonJsonDeserializer : IDeserializer
    {
        public Dictionary<int, Person> Deserialize<T>(Stream stream)
        {
            try
            {
                return JsonSerializer.Deserialize<Dictionary<int, Person>>(stream);
            }
            catch (JsonException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

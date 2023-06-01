using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10;
namespace Lab16
{
    public interface IDeserializer
    {
        Dictionary<int, Person> Deserialize<T>(Stream stream);
    }
}

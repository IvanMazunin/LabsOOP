using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Lab10;
namespace Lab16
{
    public interface ISerializer
    {
        void Serialize<T>(Stream stream, IDictionary<T, Person> dictionary);
    }
}

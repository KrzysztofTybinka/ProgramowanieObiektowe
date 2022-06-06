using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    public class MyFileWriter
    {
        public static void GuestsToXml<T>(T[] obj, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T[]));
                xml.Serialize(stream, obj);
            }
        }
    }
}

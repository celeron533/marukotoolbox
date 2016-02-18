using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace mp4box.Configurations
{
    public class PersistableObject
    {
        public static T Load<T>(string fileName) where T : PersistableObject, new()
        {
            T result = default(T);

            using (XmlReader xmlReader = XmlReader.Create(fileName))
            {
                result = new XmlSerializer(typeof(T)).Deserialize(xmlReader) as T;
            }
            return result;
        }



        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = false,
            Encoding = Encoding.UTF8
        };

        public void Save<T>(string fileName) where T : PersistableObject
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(fileName, xmlWriterSettings))
            {
                new XmlSerializer(typeof(T)).Serialize(xmlWriter, this);
            }
        }
    }
}

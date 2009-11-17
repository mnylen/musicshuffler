using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace MusicShuffler
{
    public static class XmlSerializationTool<T>
    {
        public static void Save(T obj, string fileName)
        {
            // Create the file
            FileInfo file = new FileInfo(fileName);

            if (!file.Directory.Exists)
                file.Directory.Create();

            if (file.Exists)
                file.Delete();

            using (FileStream stream = file.Create())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);

                // Serialize the object to the writer
                serializer.Serialize(writer, obj);
            }
        }


        public static T Load(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName);
            
            using (FileStream stream = File.OpenRead(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextReader reader = new XmlTextReader(stream);

                // Deserialize the object from the reader
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}

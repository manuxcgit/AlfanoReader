using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AlfanoReader
{
    public static class paramApplication
    {
        static string _fileName;

        public static void setFileName(string fileName)
        {
            string v_AdresseBase = new FileInfo(System.Windows.Forms.Application.ExecutablePath).DirectoryName + "\\";
            _fileName = v_AdresseBase + fileName;
        }

        public static object LoadFromXML (System.Type type)
        {
            if (File.Exists(_fileName))
            {
                object result;

                XmlReader r = XmlReader.Create(new StreamReader(_fileName));

                XmlSerializer s = new XmlSerializer(type);
                result = s.Deserialize(r);
                r.Close();

                return result;
            }
            return null;
        }

        public static void SaveToXml(object o, System.Type type)
        {
            XmlSerializer s = new XmlSerializer(type);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = ("\t");
            using (XmlWriter w = XmlWriter.Create(_fileName, settings))
            {
                s.Serialize(w, o);
                w.Flush();
            }
        }
    }
}

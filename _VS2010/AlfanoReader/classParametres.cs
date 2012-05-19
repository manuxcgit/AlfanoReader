using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml.Linq;

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

        public static T LoadFromXML<T>(T o)
        {
            if (File.Exists(_fileName + "." + o.GetType().Name + ".xml"))
            {
                T result;

                StreamReader r = new StreamReader(_fileName + "." + o.GetType().Name + ".xml");
                try
                {
                    XmlSerializer s = new XmlSerializer(typeof(classParamSerial));
                    result = (T) s.Deserialize(r);
                }
                finally { r.Close(); }

                return result;
            }
            return default(T);
        }

        public static void SaveToXml(object o)
        {
            XmlSerializer s = new XmlSerializer(o.GetType());
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = ("\t");


            using (StreamWriter w = new StreamWriter(_fileName + "." + o.GetType().Name + ".xml"))
            {
                s.Serialize(w, o);
                //  xs.Serialize(w, p);
                w.Flush();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace MaximusParserX.Serialization
{
    public class Serializer
    {
        public static string TargetNamespace
        {
            get
            {
                return "http://www.w3.org/2001/XMLSchema";
            }
        }

        public static XmlSerializerNamespaces GetNamespaces(bool supportnamespaces)
        {
            var ns = new XmlSerializerNamespaces();
            if (!supportnamespaces)
            {
                ns.Add(string.Empty, string.Empty);
            }
            return ns;
        }

        private static bool DoesSuportNamespaces(System.Type type)
        {
            var attr = (System.Xml.Serialization.XmlTypeAttribute)Attribute.GetCustomAttribute(type, typeof(System.Xml.Serialization.XmlTypeAttribute));
            return attr != null;
        }

        private static bool prettyprint = true;

        public static bool PrettyPrint
        {
            get
            {
                return Serializer.prettyprint;
            }
            set
            {
                Serializer.prettyprint = value;
            }
        }

        public static string ToXml(object obj)
        {
            var type = obj.GetType();
            var supportnamespaces = DoesSuportNamespaces(type);
            var xsr = new XmlSerializer(type);

            using (var ms = new MemoryStream())
            using (var xtw = new XmlTextWriter(ms, Encoding.Unicode))
            {
                if (Serializer.PrettyPrint)
                {
                    xtw.Formatting = Formatting.Indented;
                    xtw.Indentation = 1;
                    xtw.IndentChar = Convert.ToChar(9);
                }

                xtw.Namespaces = true;

                xsr.Serialize(xtw, obj, Serializer.GetNamespaces(supportnamespaces));

                xtw.Close();
                ms.Close();

                var xml = Encoding.Unicode.GetString(ms.GetBuffer());
                xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
                return xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));
            }
        }

        public static void WriteObjectToXmlFileUnicode(object pObj, string filename)
        {
            WriteObjectToXmlFile(pObj, filename, Encoding.Unicode);
        }

        public static void WriteObjectToXmlFileASCII(object pObj, string filename)
        {
            WriteObjectToXmlFile(pObj, filename, Encoding.ASCII);
        }

        public static void WriteObjectToXmlFile(object pObj, string filename, Encoding pEncoding)
        {
            using (var xtw = new System.Xml.XmlTextWriter(filename, pEncoding))
            {
                var xsr = new System.Xml.Serialization.XmlSerializer(pObj.GetType());
                xsr.Serialize((System.Xml.XmlWriter)xtw, pObj);
                xtw.Close();
            }
        }

        public static T ReadObjectFromXmlFileUnicode<T>(string filename, Type obj)
        {
            return ReadObjectFromXmlFile<T>(filename, obj, Encoding.Unicode);
        }

        public static T ReadObjectFromXmlFileASCII<T>(string filename, Type obj)
        {
            return ReadObjectFromXmlFile<T>(filename, obj, Encoding.ASCII);
        }

        public static T ReadObjectFromXmlFile<T>(string filename, Type obj, Encoding pEncoding)
        {
            using (var sr = new System.IO.StreamReader(filename, pEncoding))
            using (var xtr = new System.Xml.XmlTextReader(sr))
            {
                var xsr = new System.Xml.Serialization.XmlSerializer(obj);
                var result = xsr.Deserialize(xtr);
                xtr.Close();
                sr.Close();
                return (T)result;
            }
        }

        public static object FromXml(string xml, System.Type obj)
        {
            var xsr = new XmlSerializer(obj);

            using (var sr = new StringReader(xml))
            using (var xtr = new XmlTextReader(sr))
            {
                if (xsr.CanDeserialize(xtr))
                {
                    var result = xsr.Deserialize(xtr);
                    xtr.Close();
                    sr.Close();
                    return result;
                }

            }

            return null;
        }
    }
}



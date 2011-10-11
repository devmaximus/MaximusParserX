using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximusParserX
{
    public static class SerializationExt
    {
        public static T Clone<T>(this T obj)
        {
            if (obj == null) return obj;
            return (T)Serialization.Serializer.FromXml(Serialization.Serializer.ToXml(obj), typeof(T));
        }

        public static T FromXML<T>(this string xml)
        {
            return (T)Serialization.Serializer.FromXml(xml, typeof(T));
        }

        public static string ToXml<T>(this T obj)
        {
            if (obj == null) return null;
            return Serialization.Serializer.ToXml(obj);
        }

        public static void SaveObject<T>(this T obj, string fileName)
        {
            System.IO.File.WriteAllText(fileName, obj.ToXml());
        }
    }
}

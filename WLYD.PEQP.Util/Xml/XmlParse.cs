using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace Compeng.PEQP.Util.Xml
{
    /// <summary>
    /// XML响应通用解释器。
    /// </summary>
    public static class XmlParser
    {
        //private static readonly Regex regex = new Regex("<(\\w+?)[ >]", RegexOptions.Compiled);

        private static readonly ConcurrentDictionary<string, XmlSerializer> Parsers =
            new ConcurrentDictionary<string, XmlSerializer>();


        public static T Deserialize<T>(string body) where T : class
        {
            var type = typeof(T);
            var key = type.FullName;

            var serializer = Parsers.GetOrAdd(key, _ => new XmlSerializer(type));
            object obj;
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(body)))
            {
                obj = serializer.Deserialize(stream);
            }

            var rsp = (T) obj;
            return rsp;
        }

        public static string Serializer<T>(T obj, bool isOmitXmlDeclaration = true)
        {
            var type = obj.GetType();
            var key = type.FullName;

            var serializer = Parsers.GetOrAdd(key, _ => new XmlSerializer(type));
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                // 不生成声明头 
                OmitXmlDeclaration = isOmitXmlDeclaration
            };
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            using (var memoryStream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(memoryStream, settings))
                {
                    serializer.Serialize(xmlWriter, obj, ns);
                    xmlWriter.Flush();
                    xmlWriter.Close();
                    var result = Encoding.UTF8.GetString(memoryStream.ToArray());
                    result = Regex.Replace(result, "^[^<]", "");
                    return result;
                }
            }
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Examen
{
    internal class Convert
    {
        public string ConvertDictionaryToString(Dictionary<string, string> dictionary)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pair in dictionary)
            {
                sb.Append(pair.Key);
                sb.Append(":");
                sb.Append(pair.Value);
                sb.Append(", ");
            }

            if (sb.Length > 0)
            {
                // Remove the trailing comma and space
                sb.Length -= 2;
            }

            return sb.ToString();
        }
        public string ConvertDictionaryToJson(Dictionary<string, string> dictionary)
        {
            string json = JsonConvert.SerializeObject(dictionary);
            return json;
        }
        public string ConvertDictionaryToXml(Dictionary<string, string> dictionary)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("Dictionary");

            foreach (var pair in dictionary)
            {
                XmlElement keyElement = xmlDoc.CreateElement("Key");
                keyElement.InnerText = pair.Key;

                XmlElement valueElement = xmlDoc.CreateElement("Value");
                valueElement.InnerText = pair.Value;

                XmlElement entryElement = xmlDoc.CreateElement("Entry");
                entryElement.AppendChild(keyElement);
                entryElement.AppendChild(valueElement);

                rootElement.AppendChild(entryElement);
            }

            xmlDoc.AppendChild(rootElement);
            return xmlDoc.OuterXml;
        }

    }
}

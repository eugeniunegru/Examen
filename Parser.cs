using Newtonsoft.Json;
using System.Xml;

namespace Examen
{
    internal class Parser
    { 
        public Parser() { }
        public Dictionary<string, string> ConvertToDictionary(string text)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            string[] keyValuePairs = text.Split(new[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < keyValuePairs.Length - 1; i += 2)
            {
                string key = keyValuePairs[i];
                string value = keyValuePairs[i + 1];
                dictionary[key] = value;
            }
            return dictionary;
        }
        public Dictionary<string, string> ParseJsonToDictionary(string json)
        {
            Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dictionary;
        }
        public Dictionary<string, string> ParseXmlToDictionary(string xml)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList nodes = xmlDoc.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                string key = node.Name;
                string value = node.InnerText;
                dictionary[key] = value;
            }

            return dictionary;
        }
    }
}

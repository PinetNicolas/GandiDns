using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ApiCdc
{
    /// <summary>
    /// Class containing useful tools 
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Convert dateTime to string for cdc
        /// </summary>
        /// <param name="date">DateTime to convert</param>
        /// <returns>string formated</returns>
        public static string convertToCdcDateTime(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Calculation of hash of byte array
        /// </summary>
        /// <param name="tohash">by array to hash</param>
        /// <returns>a hash string</returns>
        public static string CalculHash(byte[] tohash)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] haschage = mySHA256.ComputeHash(tohash);
                return Convert.ToBase64String(haschage);
            }
        }

        /// <summary>
        /// Calculation of hash of string
        /// </summary>
        /// <param name="tohash">string to hash</param>
        /// <returns>a hash string</returns>
        public static string CalculHash(string tohash)
        {
            return CalculHash(Encoding.UTF8.GetBytes(tohash));
        }

        /// <summary>
        /// Function to remove xmlns attribute in xml data
        /// </summary>
        /// <param name="xmldata">xmldata in string format</param>
        /// <returns>the xml without xmlns attributes</returns>
        public static string RemoveNamespaceXml (string xmldata)
        {
            string pattern = @"(</?)(\w+:)";

            string output = Regex.Replace(xmldata, pattern, "$1");

            Regex reg = new Regex(@"xmlns(:\w+)*=""[^""]*""");
            return reg.Replace(output, string.Empty);
        }

        public static string SerializeObjectToXmlString(object toSerialize)
        {
            if (toSerialize == null)
                return "";

            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }

        public static object DeserializeXmlString(Type type, string toUnserialize)
        {
            if (string.IsNullOrEmpty(toUnserialize))
                return null;

            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (MemoryStream textWriter = new MemoryStream(Encoding.UTF8.GetBytes(toUnserialize)))
            {
                return xmlSerializer.Deserialize(textWriter);
            }
        }
    }
}

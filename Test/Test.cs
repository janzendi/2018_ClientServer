using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Test
{
    class Test
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            serialnumbertest();
        }

        public void xmltest()
        {

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("users");
            xmlDoc.AppendChild(rootNode);

            XmlNode userNode = xmlDoc.CreateElement("user");
            XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "42";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "John Doe";
            rootNode.AppendChild(userNode);

            userNode = xmlDoc.CreateElement("user");
            attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "39";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "Jane Doe";
            rootNode.AppendChild(userNode);

            xmlDoc.Save("test-doc.xml");
        }

        public static void serialnumbertest()
        {
            System.IO.TextWriter txtFile = new System.IO.StreamWriter("SERIALNUMBERS.txt");
            Random random = new Random();
            string tmp = "";
            for (int i = 0; i < 20000; i++)
            {
                tmp += random.Next(1000000, 2147483647).ToString() + ", ";
            }
            txtFile.Write(tmp);
            txtFile.Close();
        }
    }
}

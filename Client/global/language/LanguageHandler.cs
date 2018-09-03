using System.Collections.Generic;
using System.Xml;

namespace Client.global.language
{
    public class LanguageHandler
    {
        private static LanguageHandler instance;
        private LanguageHandler() { }

        /// <summary>
        /// Sinleton-Pattern Eigenschaft
        /// </summary>
        /// <created>janzen_d,2018-09-03</created>
        public static LanguageHandler INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new LanguageHandler();
                }
                return instance;
            }
        }

        /// <summary>
        /// Dictonary für alle textids.
        /// </summary>
        /// <created>janzen_d,2018-09-03</created>
        private static Dictionary<string, Dictionary<int, ObjWord>> dictLanguage = new Dictionary<string, Dictionary<int, ObjWord>>();
        /// <summary>
        /// XmlDocument zum Zugriff auf die Language Datei.
        /// </summary>
        /// <created>janzen_d,2018-09-03</created>
        private XmlDocument xmlDocumentLanguage;

        /// <summary>
        /// Zur einfachen Prüfung ob die Sprachendatei eingelesen wurde.
        /// </summary>
        /// <created>janzen_d,2018-09-03</created>
        private static bool boolXmlReadIsFinish = true;
        /// <summary>
        /// Zur einfachen Prüfung ob die Sprachendatei eingelesen wurde.
        /// </summary>
        /// <created>janzen_d,2018-09-03</created>
        public static bool XMLREADISFINISH
        {
            get { return boolXmlReadIsFinish; }
        }

        /// <summary>
        /// Read language file and setup Language Handler with data.
        /// </summary>
        /// <param name="path">Pfad der language.xml Datei.</param>
        /// <created>janzen_d,2018-09-03</created>
        public void ReadXml(string path)
        {
            try
            {
                xmlDocumentLanguage = new XmlDocument();
                xmlDocumentLanguage.Load(path);
                // Lese alle Sprachennodes ein.
                foreach (XmlNode nodelanguage in xmlDocumentLanguage.SelectNodes("languages/language")) // äusere Schleife die alle Sprachen einliest.
                {
                    global.log.MetroLog.INSTANCE.DebugWriteLine("Add new language to LanguageHandler: " + nodelanguage.Attributes["text"].Value);
                    dictLanguage.Add(nodelanguage.Attributes["text"].Value, new Dictionary<int, ObjWord>()); // neue Sprache anlegen.
                    foreach (XmlNode nodetextid in nodelanguage.SelectNodes("text")) // innere Schleife die alle textids einliest.
                    {
                        if (System.Int32.TryParse(nodetextid.Attributes["id"].Value, out int id))
                        {
                            if (!dictLanguage[nodelanguage.Attributes["text"].Value].ContainsKey(id))
                            {
                                global.log.MetroLog.INSTANCE.DebugWriteLine("Info. Add to "+ nodelanguage.Attributes["text"].Value+ " new textid: " + nodetextid.OuterXml);
                                dictLanguage[nodelanguage.Attributes["text"].Value].Add(id, new ObjWord(nodetextid.Attributes["tooltip"].Value, nodetextid.Attributes["objecttype"].Value, nodetextid.InnerText, id));
                            }
                            else
                            {
                                global.log.MetroLog.INSTANCE.DebugWriteLine("Error. Textid [" + id + "] twice in \"config\\language.xml\"");
                                System.Windows.Forms.MessageBox.Show("Error. Textid [" + id + "] twice in \"config\\language.xml\"");
                            }
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                global.log.MetroLog.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
            }
            boolXmlReadIsFinish = false;
        }

        public List<string> LISTOFLANGUAGE
        {
            get
            {
                List<string> strlancount = new List<string>();
                foreach (string item in dictLanguage.Keys)
                    strlancount.Add(item);
                return strlancount;
            }
        }
    }
}

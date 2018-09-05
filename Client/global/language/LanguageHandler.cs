using System.Collections.Generic;
using System.Xml;

namespace Client.global.language
{
    public class LanguageHandler
    {
        private static LanguageHandler instance;
        private static string strlanguage; // aktuelle Sprache
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
                    global.log.MetroLog.INSTANCE.DebugWriteLine("Add new language to LanguageHandler: " + nodelanguage.Attributes["text"].Value, global.log.MetroLog.LogType.INFO);
                    dictLanguage.Add(nodelanguage.Attributes["text"].Value, new Dictionary<int, ObjWord>()); // neue Sprache anlegen.
                    foreach (XmlNode nodetextid in nodelanguage.SelectNodes("text")) // innere Schleife die alle textids einliest.
                    {
                        if (System.Int32.TryParse(nodetextid.Attributes["id"].Value, out int id))
                        {
                            if (!dictLanguage[nodelanguage.Attributes["text"].Value].ContainsKey(id))
                            {
                                global.log.MetroLog.INSTANCE.DebugWriteLine("Add to "+ nodelanguage.Attributes["text"].Value+ " new textid: " + nodetextid.OuterXml, global.log.MetroLog.LogType.INFO);
                                dictLanguage[nodelanguage.Attributes["text"].Value].Add(id, new ObjWord(nodetextid.Attributes["tooltip"].Value, nodetextid.Attributes["objecttype"].Value, nodetextid.InnerText, id));
                            }
                            else
                            {
                                global.log.MetroLog.INSTANCE.DebugWriteLine("Textid [" + id + "] twice in \"config\\language.xml\"", global.log.MetroLog.LogType.ERROR);
                                System.Windows.Forms.MessageBox.Show("Error. Textid [" + id + "] twice in \"config\\language.xml\"");
                            }
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                global.log.MetroLog.INSTANCE.WriteLine("Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
            }
            boolXmlReadIsFinish = false;
        }

        /// <summary>
        /// Eigenschaft Zugriff auf Liste der Sprachen
        /// </summary>
        /// <created>janzen_d,2018-09-04</created>
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

        /// <summary>
        /// Methode um aktuelle textids zu bekommen.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="id"></param>
        /// <returns>Gibt ein string array[3] zurück mit {tooltip, type, text}</returns>
        /// <created>janzen_d,2018-09-04</created>
        public string[] GETOBJWORD(string language, int id)
        {
            if (strlanguage != language) strlanguage = language;
            string[] objword = new string[3] { id.ToString() + " " + dictLanguage[language][1].TOOLTIP, "", id.ToString() + " " + dictLanguage[language][1].TEXT };
            try
            {
                if (dictLanguage.TryGetValue(language, out Dictionary<int,ObjWord> tmpDict))
                {
                    if (dictLanguage[language].TryGetValue(id, out ObjWord tmpObjWord))
                    {
                        return new string[3] { dictLanguage[language][id].TOOLTIP, dictLanguage[language][id].OBJTYPE, dictLanguage[language][id].TEXT };
                    }
                }
            }
            catch (System.Exception e)
            {
                global.log.MetroLog.INSTANCE.WriteLine("Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
            }
            return null;
        }

        /// <summary>
        /// Methode wurde hinzugefügt um Fehlermeldungen mit der aktuellsten Sprache auszugeben.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="id"></param>
        /// <returns>Gibt ein string array[3] zurück mit {tooltip, type, text}</returns>
        /// <created>janzen_d,2018-09-05</created>
        public string[] GETOBJWORD(int id)
        {
            string[] objword = new string[3] { id.ToString() + " " + dictLanguage[strlanguage][1].TOOLTIP, "", id.ToString() + " " + dictLanguage[strlanguage][1].TEXT };
            try
            {
                if (dictLanguage.TryGetValue(strlanguage, out Dictionary<int, ObjWord> tmpDict))
                {
                    if (dictLanguage[strlanguage].TryGetValue(id, out ObjWord tmpObjWord))
                    {
                        return new string[3] { dictLanguage[strlanguage][id].TOOLTIP, dictLanguage[strlanguage][id].OBJTYPE, dictLanguage[strlanguage][id].TEXT };
                    }
                }
            }
            catch (System.Exception e)
            {
                global.log.MetroLog.INSTANCE.WriteLine("Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
            }
            return null;
        }
    }
}

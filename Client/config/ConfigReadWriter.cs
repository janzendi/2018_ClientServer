using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Client.config
{
    static class ConfigReadWriter
    {
        private static XmlDocument xmldocConfg = new XmlDocument();

        /// <summary>
        /// Return the file path for the languagefile, depending from configuration in confif file.
        /// </summary>
        /// /// <created>janzen_d,2018-09-02</created>
        public static string LANGUAGEPATH
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    return xmldocConfg.SelectSingleNode("config/languagefilepath").Value.ToString();
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not read the language file path in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
                }
                return null;
            }
        }

        /// <summary>
        /// Return the file path for the logfile, depending from configuration in config file.
        /// </summary>
        /// /// <created>janzen_d,2018-09-02</created>
        public static string LOGPATH
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    return xmldocConfg.SelectSingleNode("config/logfilepath").InnerText;
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not read the log file path in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
                }
                return null;
            }
        }

        /// <summary>
        /// Get and set the Debugmode, depending on configuration in config file.
        /// </summary>
        /// /// <created>janzen_d,2018-09-02</created>
        public static bool DEBUGENABLED
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    switch (xmldocConfg.SelectSingleNode("config/debugmode").InnerText)
                    {
                        case "1":
                        case "true":
                        case "TRUE":
                        case "True":
                        case "yes":
                            return true;
                        case "0":
                        case "false":
                        case "FALSE":
                        case "False":
                        case "no":
                            return false;
                        default:
                            break;
                    }
                    return false;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            set
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    xmldocConfg.SelectSingleNode("config/debugmode").InnerText = value.ToString();
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not read the debug mode in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
                }
            }
        }
    }
}

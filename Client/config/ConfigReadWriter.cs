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
        private static bool debugenabled;

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
                    return xmldocConfg.SelectSingleNode("config/logfilepath").Value.ToString();
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not read the log file path in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
                }
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
                    if (debugenabled == null)
                    {
                        xmldocConfg.Load("config/config.xml");
                        switch (xmldocConfg.SelectSingleNode("config/debugmode").Value.ToString())
                        {
                            case "1":
                            case "true":
                            case  "TRUE":
                            case "True":
                            case "yes":
                                debugenabled = true;
                                break;
                            case "0":
                            case "false":
                            case "FALSE":
                            case "False":
                            case "no":
                                debugenabled = false;
                                break;
                            default:
                                break;
                        }
                    }
                    return debugenabled;
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
                    debugenabled = value;
                    xmldocConfg.Load("config/config.xml");
                    xmldocConfg.SelectSingleNode("config/debugmode").Value = value.ToString();
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

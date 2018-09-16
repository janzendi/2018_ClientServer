using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;

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
                    return xmldocConfg.SelectSingleNode("config/languagefilepath").InnerText.ToString();
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not read the language file path in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(),global.log.MetroLog.LogType.ERROR);
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
                    global.log.MetroLog.INSTANCE.WriteLine("Config file could not read the log file path in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
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
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not read the debug mode in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
            }
        }

        /// <summary>
        /// Eigenschaft Zugriff auf Sprache die im config file hinterlegt ist.
        /// GGf später noch eine Abhilfe schreiben falls Sprache im file nicht hinterlegt ist.
        /// </summary>
        /// <created>janzen_d,2018-09-04</created>
        public static string LANGUAGE
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    return xmldocConfg.SelectSingleNode("config/language").InnerText;
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Language tag could not be read" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
                return null;
            }
            set
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    xmldocConfg.SelectSingleNode("config/language").InnerText = value;
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Language tag could not be write" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
            }
        }

        /// <summary>
        /// Eigenschaft Zugriff auf Einstellung wie viele Tage die logfiles gültig sind. 0 = unendlich
        /// </summary>
        /// <created>janzen_d,2018-09-06</created>
        public static int KEEPLOGFILESFORXDAYS
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    System.Int32.TryParse(xmldocConfg.SelectSingleNode("config/keeplogfileforxdays").InnerText, out int result);
                    return result;
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Language tag could not be read" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
                return 0;
            }
        }

        /// <summary>
        /// Eigenschaft Zugriff auf Einstellung Fenstergröße
        /// </summary>
        /// <created>janzen_d,2018-09-10</created>
        public static int WINDOWWIDTH
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    System.Int32.TryParse(xmldocConfg.SelectSingleNode("config/windowwidth").InnerText, out int result);
                    if (result == 0)
                        return 500;
                    return result;
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Window width tag could not be read" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
                return 0;
            }
            set
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    xmldocConfg.SelectSingleNode("config/windowwidth").InnerText = value.ToString();
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not write the windowslength in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
            }
        }

        /// <summary>
        /// Eigenschaft Zugriff auf Einstellung Fenstergröße
        /// </summary>
        /// <created>janzen_d,2018-09-10</created>
        public static int WINDOWLENGTH
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    System.Int32.TryParse(xmldocConfg.SelectSingleNode("config/windowlength").InnerText, out int result);
                    if (result == 0)
                        return 500;
                    return result;
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Window width tag could not be read" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
                return 0;
            }
            set
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    xmldocConfg.SelectSingleNode("config/windowlength").InnerText = value.ToString();
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not write the windowslength in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
            }
        }


        /// <summary>
        /// Get and set the Fullscreen, depending on configuration in config file.
        /// </summary>
        /// /// <created>janzen_d,2018-09-10</created>
        public static bool FULLSCREEN
        { 
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    switch (xmldocConfg.SelectSingleNode("config/fullscreen").InnerText)
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
                    xmldocConfg.SelectSingleNode("config/fullscreen").InnerText = value.ToString();
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("ERROR: Config file could not write the full screen tag in class: ConfigReadWriter" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
            }
        }

        /// <summary>
        /// Filepath of license information
        /// </summary>
        /// /// <created>janzen_d,2018-09-12</created>
        public static string PATHMETROUILICENSEREADME
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    return xmldocConfg.SelectSingleNode("config/metrouilicensereadme").InnerText;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Filepath of icon picture
        /// </summary>
        /// /// <created>janzen_d,2018-09-12</created>
        public static string PATHICON
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    return xmldocConfg.SelectSingleNode("config/icon").InnerText;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Metro theme
        /// </summary>
        /// /// <created>janzen_d,2018-09-12</created>
        public static MetroFramework.MetroThemeStyle METROTHEME
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    switch (xmldocConfg.SelectSingleNode("config/metrotheme").InnerText)
                    {
                        case "dark":
                            return MetroFramework.MetroThemeStyle.Dark;
                        case "light":
                            return MetroFramework.MetroThemeStyle.Light;
                        default:
                            return MetroFramework.MetroThemeStyle.Light;
                    }
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
                    switch (value)
                    {
                        case MetroFramework.MetroThemeStyle.Default | MetroFramework.MetroThemeStyle.Light:
                            xmldocConfg.SelectSingleNode("config/metrotheme").InnerText = "light";
                            break;
                        case MetroFramework.MetroThemeStyle.Dark:
                            xmldocConfg.SelectSingleNode("config/metrotheme").InnerText = "dark";
                            break;
                        default:
                            xmldocConfg.SelectSingleNode("config/metrotheme").InnerText = "light";
                            break;
                    }
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception)
                {

                    throw; //TODO
                }
            }
        }

        /// <summary>
        /// Metro Style
        /// </summary>
        /// /// <created>janzen_d,2018-09-12</created>
        public static MetroFramework.MetroColorStyle METROSTYLE
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    switch (xmldocConfg.SelectSingleNode("config/metrostyle").InnerText)
                    {
                        case "0":
                            return MetroFramework.MetroColorStyle.Default;
                        case "1":
                            return MetroFramework.MetroColorStyle.Black;
                        case "2":
                            return MetroFramework.MetroColorStyle.White;
                        case "3":
                            return MetroFramework.MetroColorStyle.Silver;
                        case "4":
                            return MetroFramework.MetroColorStyle.Blue;
                        case "5":
                            return MetroFramework.MetroColorStyle.Green;
                        case "6":
                            return MetroFramework.MetroColorStyle.Lime;
                        case "7":
                            return MetroFramework.MetroColorStyle.Teal;
                        case "8":
                            return MetroFramework.MetroColorStyle.Orange;
                        case "9":
                            return MetroFramework.MetroColorStyle.Brown;
                        case "10":
                            return MetroFramework.MetroColorStyle.Pink;
                        case "11":
                            return MetroFramework.MetroColorStyle.Magenta;
                        case "12":
                            return MetroFramework.MetroColorStyle.Purple;
                        case "13":
                            return MetroFramework.MetroColorStyle.Red;
                        case "14":
                            return MetroFramework.MetroColorStyle.Yellow;
                        default:
                            break;
                    }
                    return MetroFramework.MetroColorStyle.Default;
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
                    switch (value)
                    {
                        case MetroFramework.MetroColorStyle.Default:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "0";
                            break;
                        case MetroFramework.MetroColorStyle.Black:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "1";
                            break;
                        case MetroFramework.MetroColorStyle.White:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "2";
                            break;
                        case MetroFramework.MetroColorStyle.Silver:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "3";
                            break;
                        case MetroFramework.MetroColorStyle.Blue:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "4";
                            break;
                        case MetroFramework.MetroColorStyle.Green:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "5";
                            break;
                        case MetroFramework.MetroColorStyle.Lime:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "6";
                            break;
                        case MetroFramework.MetroColorStyle.Teal:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "7";
                            break;
                        case MetroFramework.MetroColorStyle.Orange:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "8";
                            break;
                        case MetroFramework.MetroColorStyle.Brown:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "9";
                            break;
                        case MetroFramework.MetroColorStyle.Pink:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "10";
                            break;
                        case MetroFramework.MetroColorStyle.Magenta:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "11";
                            break;
                        case MetroFramework.MetroColorStyle.Purple:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "12";
                            break;
                        case MetroFramework.MetroColorStyle.Red:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "13";
                            break;
                        case MetroFramework.MetroColorStyle.Yellow:
                            xmldocConfg.SelectSingleNode("config/metrostyle").InnerText = "14";
                            break;
                        default:
                            break;
                    }
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Überprüft die Lizenz
        /// </summary>
        /// <created>janzen_d,2018-09-13</created>
        public static bool VALIDLICENSE
        {
            get
            {
                try
                {
                    if (LICENSESOFTWAREIDCRYPT.Length > 5 && LICENSEACTIVATIONKEY.Length > 5)
                        return global.readme.license.LicenseHandler.ActivationKeyIsValid(LICENSESOFTWAREIDCRYPT,LICENSESOFTWAREIDCLEAR, LICENSEACTIVATIONKEY);
                    return false;
                }
                catch (Exception ex)
                {
                    global.log.MetroLog.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: ConfigReadWriter, METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + ex.ToString(), global.log.MetroLog.LogType.ERROR);
                    return false;
                }
            }
        }

        /// <summary>
        /// Seriennummer wird zur Verschlüsselung genutzt
        /// </summary>
        /// <created>janzen_d,2018-09-15</created>
        public static string LICENSESN
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    return xmldocConfg.SelectSingleNode("config/license/sn").InnerText;
                }
                catch (Exception)
                {

                    throw; //TODO
                }
            }
            set
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    xmldocConfg.SelectSingleNode("config/license/sn").InnerText = value;
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Softwareid wird zur zur Hardwareerkennung genutzt
        /// </summary>
        /// <created>janzen_d,2018-09-15</created>
        public static string LICENSESOFTWAREIDCRYPT
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    if (xmldocConfg.SelectSingleNode("config/license/id").InnerText.Length > 5)
                        return global.readme.license.Crypt.DecryptString(xmldocConfg.SelectSingleNode("config/license/id").InnerText, LICENSESN);
                    return "";
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
                    string strtmp = global.readme.license.Crypt.EncryptString(value, LICENSESN);
                    xmldocConfg.SelectSingleNode("config/license/id").InnerText = strtmp;
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Softwareid wird zur zur Hardwareerkennung genutzt
        /// </summary>
        /// <created>janzen_d,2018-09-16</created>
        public static string LICENSESOFTWAREIDCLEAR
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    return xmldocConfg.SelectSingleNode("config/license/id").InnerText;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Aktivierungskey auslesen
        /// </summary>
        /// <created>janzen_d,2018-09-15</created>
        public static string LICENSEACTIVATIONKEY
        {
            get
            {
                try
                {
                    xmldocConfg.Load("config/config.xml");
                    return xmldocConfg.SelectSingleNode("config/license/activation").InnerText;
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
                    xmldocConfg.SelectSingleNode("config/license/activation").InnerText = value;
                    xmldocConfg.Save("config/config.xml");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}

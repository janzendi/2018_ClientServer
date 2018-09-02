using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using Client.Log;

namespace Client.Config.XML
{
    /// <summary>
    /// 
    /// </summary>
    /// <pattern>Singleton</pattern>
    /// <created>janzen_d,2017-12-29</created>
    internal class SaveAndLoadConfig
    {
        private static SaveAndLoadConfig instance;
        private XmlDocument xmldocConfg;
        private XmlNode nodeMachines;
        //private List<XMLNetworkConnection> listNetwork; not in use yet
        private string xmlServiceToolVersion;

        private SaveAndLoadConfig()
        {
            try
            {
                //listNetwork = new List<XMLNetworkConnection>(); //TODO
                string xmlpath = Client.Properties.Settings.CONFIGFILEDEFAULT;
                xmldocConfg = new XmlDocument();

                if (System.IO.File.Exists(xmlpath))
                {
                    Log.LogFile.INSTANCE.DebugWriteLine("Load default config file. Filename: " + xmlpath);
                    xmldocConfg.Load(xmlpath);
                }
                else
                {
                    Log.LogFile.INSTANCE.DebugWriteLine("Default config file does not exist. Filename: " + xmlpath);
                    //TODO Create folder and file
                }
                
                Log.LogFile.INSTANCE.DebugWriteLine("Default config file " + xmldocConfg.DocumentElement.Attributes[0].Name + ": " + xmldocConfg.DocumentElement.Attributes[0].Value);
                xmlServiceToolVersion = xmldocConfg.DocumentElement.Attributes[0].Value;
                if (xmlServiceToolVersion != null || xmlServiceToolVersion != String.Empty)
                {
                    SetXmlNodes(xmldocConfg.DocumentElement.ChildNodes, xmlServiceToolVersion);
                    if (nodeMachines == null)
                        CreateEmptyXmlNodeNetwork(xmldocConfg);
                }
            }
            catch (Exception e)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
            }
        }

        public static SaveAndLoadConfig INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new SaveAndLoadConfig();
                }
                return instance;
            }
        }

        private void SetXmlNodes(XmlNodeList list, String version)
        {
            switch (version)
            {
                case "1.0":
                    foreach (XmlNode item in list)
                    {
                        Log.LogFile.INSTANCE.DebugWriteLine("Methode Client.Config.XML.SaveAndLoadConfig.GetXmlNodeNetwork(XmlNodeList list). ChildNode item: " + item.Name);
                        if (item.Name == "machines")
                            nodeMachines = item;
                    }
                    break;
                default:
                    break;
            }
        }

        private void CreateEmptyXmlHeader(XmlDocument xmldocument)
        {
            //TODO
        }
        private void CreateEmptyXmlNodeNetwork(XmlDocument xmldocument)
        {
            //TODO
        }

        public List<XMLNetworkConnection> GetXmlNetworkList()
        {
            List<XMLNetworkConnection> templist = new List<XMLNetworkConnection>();
            try
            {
                switch (xmlServiceToolVersion)
                {
                    case "1.0":
                        foreach (XmlNode item in nodeMachines.ChildNodes)
                        {
                            foreach (XmlNode machineitem in item)
                            {
                                if (machineitem.Name == "connection")
                                {
                                    Log.LogFile.INSTANCE.DebugWriteLine("Methode GetXmlNetworkList. Add network to list:    description: \t" + machineitem.Attributes[0].InnerText.ToString() + " letter: \t" + machineitem.Attributes[1].InnerText.ToString() + " user: \t" + machineitem.Attributes[2].InnerText.ToString() + " password: \t" + machineitem.Attributes[3].InnerText.ToString() + " network path: \t" + machineitem.InnerText.ToString());
                                    templist.Add(new XMLNetworkConnection(machineitem.Attributes[0].InnerText, machineitem.Attributes[1].InnerText, machineitem.Attributes[2].InnerText, machineitem.Attributes[3].InnerText, machineitem.InnerText));
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
            }
            return templist;
        }
    }
}

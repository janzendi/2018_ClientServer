using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace Client.Layout.Layout_TWizard
{
    /// <summary>
    /// Singleton Pattern
    /// </summary>
    class TCWizardStandardOPC_FileHandler
    {
        private List<XmlDocument> list_pvprocess;
        private bool pvprocessChanged = false;
        private List<XmlDocument> list_pvequipment;
        private bool pvequipmentChanged = false;
        private List<XmlDocument> list_equipment;
        private bool equipmentChanged = false;
        private List<XmlDocument> list_pvbatch;
        private bool pvbatchChanged = false;
        private string modulename;
        public string MODULENAME
        {
            get
            { return modulename; }
        }

        public TCWizardStandardOPC_FileHandler(string modulename)
        {
            list_pvprocess = new List<XmlDocument>();
            list_pvequipment = new List<XmlDocument>();
            list_equipment = new List<XmlDocument>();
            list_pvbatch = new List<XmlDocument>();
            this.modulename = modulename;
        }

        public bool AddEquipment(string path)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.XmlResolver = null;
                xmlDocument.Load(path);
                if (xmlDocument.HasChildNodes)
                {
                    list_equipment.Add(xmlDocument);
                }
                else
                    return false;
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return false;
        }

        public bool AddPvEquipment(string path)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.XmlResolver = null;
                xmlDocument.Load(path);
                if (xmlDocument.HasChildNodes)
                {
                    list_pvequipment.Add(xmlDocument);
                }
                else
                    return false;
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return false;
        }

        public bool AddPvProcess(string path)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.XmlResolver = null;
                xmlDocument.Load(path);
                if (xmlDocument.HasChildNodes)
                {
                    list_pvprocess.Add(xmlDocument);
                }
                else
                    return false;
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return false;
        }

        public bool AddPvBatch(string path)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.XmlResolver = null;
                xmlDocument.Load(path);
                if (xmlDocument.HasChildNodes)
                {
                    list_pvbatch.Add(xmlDocument);
                }
                else
                    return false;
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return false;
        }

        public List<object[]> GetListObjArrayOfPDAVariables(int listid)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            List<object[]> temp_list = new List<object[]>();
            bool pdavarfound;
            try
            {
                if (list_pvprocess.Count != 0 || list_pvprocess != null)
                {
                    //PV_Process auslesen
                    foreach (XmlDocument xmldocs in list_pvprocess)
                    {
                        foreach (XmlNode xmlnode in xmldocs.SelectNodes("/PPVS/PPV"))
                        {
                            pdavarfound = false;
                            object[] temp_array = new object[20];
                            temp_array[0] = listid;
                            temp_array[1] = modulename;
                            if (xmlnode.NodeType == XmlNodeType.Element)
                            {
                                XmlElement xmlElement = ToXmlElement(xmlnode);
                                if (xmlElement.HasAttribute("pdaCounterType") && xmlElement.HasAttribute("name"))
                                {
                                    if (xmlElement.Attributes["pdaCounterType"].Value != "2" && xmlElement.Attributes["pdaCounterType"].Value.All(char.IsDigit))
                                    {
                                        pvprocessChanged = true;
                                        temp_array[2] = xmldocs.BaseURI.Replace("file:///", String.Empty);
                                        temp_array[3] = xmlElement.Attributes["name"].Value;
                                        temp_array[4] = xmlElement.Attributes["pdaCounterType"].Value;
                                        temp_array[5] = xmlElement.Attributes["varTxt"].Value;
                                        temp_array[6] = xmlElement.Attributes["cmt"].Value;

                                        if (!xmlElement.HasAttribute("opcDataType"))
                                        {
                                            //Create a new attribute
                                            XmlAttribute attr = xmldocs.CreateAttribute("opcDataType");
                                            attr.Value = "STRING";
                                            xmlnode.Attributes.SetNamedItem(attr);
                                        }
                                        temp_array[7] = xmlElement.Attributes["opcDataType"].Value;
                                        if (!xmlElement.HasAttribute("opcRwu"))
                                        {
                                            //Create a new attribute
                                            XmlAttribute attr = xmldocs.CreateAttribute("opcRwu");
                                            attr.Value = "0";
                                            xmlnode.Attributes.SetNamedItem(attr);
                                        }
                                        temp_array[8] = xmlElement.Attributes["opcRwu"].Value;
                                        if (!xmlElement.HasAttribute("opcAlias"))
                                        {
                                            //Create a new attribute
                                            XmlAttribute attr = xmldocs.CreateAttribute("opcAlias");
                                            attr.Value = xmlElement.Attributes["cmt"].Value;
                                            xmlnode.Attributes.SetNamedItem(attr);
                                        }
                                        temp_array[9] = xmlElement.Attributes["opcAlias"].Value;
                                        if (!xmlElement.HasAttribute("opcActive"))
                                        {
                                            //Create a new attribute
                                            XmlAttribute attr = xmldocs.CreateAttribute("opcActive");
                                            attr.Value = "1";
                                            xmlnode.Attributes.SetNamedItem(attr);
                                        }
                                        temp_array[10] = xmlElement.Attributes["opcActive"].Value;

                                        pdavarfound = true;
                                    }
                                }

                                if (pdavarfound)
                                {
                                    foreach (XmlDocument xmldocsPVEquipment in list_pvequipment)
                                    {
                                        foreach (XmlNode xmlnode_pvEquipment in xmldocsPVEquipment.SelectNodes("/EPVS/EPV"))
                                        {
                                            if (xmlnode_pvEquipment.Attributes["name"].Value == xmlElement.Attributes["name"].Value)
                                            {
                                                XmlElement xmlPVEElement = ToXmlElement(xmlnode);
                                                if (!xmlPVEElement.HasAttribute("size"))
                                                {
                                                    pvequipmentChanged = true;
                                                    //Create a new attribute
                                                    XmlAttribute attr = xmldocs.CreateAttribute("size");
                                                    attr.Value = "1";
                                                    xmlnode_pvEquipment.Attributes.SetNamedItem(attr);
                                                }
                                                temp_array[11] = xmldocsPVEquipment.BaseURI.Replace("file:///", String.Empty);
                                                temp_array[12] = xmlnode_pvEquipment.Attributes["size"].Value;
                                            }
                                        }
                                    }
                                }
                            }
                            if (pdavarfound)
                                temp_list.Add(temp_array);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return temp_list;
        }

        public List<object[]> GetListObjArrayOfAnalogVariables(int listid)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            List<object[]> temp_list = new List<object[]>();
            bool pdavarfound;
            try
            {
                if (list_pvprocess.Count != 0 || list_pvprocess != null)
                {
                    //PV_Process auslesen
                    foreach (XmlDocument xmldocs in list_pvprocess)
                    {
                        foreach (XmlNode xmlnode in xmldocs.SelectNodes("/PPVS/PPV"))
                        {
                            pdavarfound = false;
                            object[] temp_array = new object[20];
                            temp_array[0] = listid;
                            temp_array[1] = modulename;

                            if (xmlnode.NodeType == XmlNodeType.Element)
                            {
                                XmlElement xmlElement = ToXmlElement(xmlnode);
                                if (xmlElement.HasAttribute("semantic") && Contains_ValueContainsInList(xmlElement.Attributes["semantic"].Value, Client.Properties.Settings.DCANALOGSEMANTIC))
                                {
                                    pvprocessChanged = true;
                                    temp_array[2] = xmldocs.BaseURI.Replace("file:///", String.Empty);
                                    temp_array[3] = xmlElement.Attributes["name"].Value;
                                    // pdacountervar gibt es nicht bei Analog Werten
                                    temp_array[5] = xmlElement.Attributes["varTxt"].Value;
                                    temp_array[6] = xmlElement.Attributes["cmt"].Value;

                                    // OPC Interface
                                    if (!xmlElement.HasAttribute("opcDataType"))
                                    {
                                        //Create a new attribute
                                        XmlAttribute attr = xmldocs.CreateAttribute("opcDataType");
                                        attr.Value = "STRING";
                                        xmlnode.Attributes.SetNamedItem(attr);
                                    }
                                    temp_array[7] = xmlElement.Attributes["opcDataType"].Value;
                                    if (!xmlElement.HasAttribute("opcRwu"))
                                    {
                                        //Create a new attribute
                                        XmlAttribute attr = xmldocs.CreateAttribute("opcRwu");
                                        attr.Value = "0";
                                        xmlnode.Attributes.SetNamedItem(attr);
                                    }
                                    temp_array[8] = xmlElement.Attributes["opcRwu"].Value;
                                    if (!xmlElement.HasAttribute("opcAlias"))
                                    {
                                        //Create a new attribute
                                        XmlAttribute attr = xmldocs.CreateAttribute("opcAlias");
                                        attr.Value = xmlElement.Attributes["cmt"].Value;
                                        xmlnode.Attributes.SetNamedItem(attr);
                                    }
                                    temp_array[9] = xmlElement.Attributes["opcAlias"].Value;
                                    if (!xmlElement.HasAttribute("opcActive"))
                                    {
                                        //Create a new attribute
                                        XmlAttribute attr = xmldocs.CreateAttribute("opcActive");
                                        attr.Value = "1";
                                        xmlnode.Attributes.SetNamedItem(attr);
                                    }
                                    temp_array[10] = xmlElement.Attributes["opcActive"].Value;

                                    // Analog OPC Interface
                                    if (xmlElement.HasAttribute("semantic"))
                                        temp_array[13] = xmlElement.Attributes["semantic"].Value;
                                    if (xmlElement.HasAttribute("dcReadPeriod"))
                                        temp_array[14] = xmlElement.Attributes["dcReadPeriod"].Value;
                                    if (xmlElement.HasAttribute("dcLogThreshold"))
                                        temp_array[15] = xmlElement.Attributes["dcLogThreshold"].Value;
                                    if (xmlElement.HasAttribute("dcMaxPersistence"))
                                        temp_array[16] = xmlElement.Attributes["dcMaxPersistence"].Value;

                                    // pdavarfound setzen, damit sichtbar ist, dass neue Variable gefunden wurden.
                                    pdavarfound = true;
                                }

                                //pv_equipment durchsuchen
                                if (pdavarfound)
                                {
                                    foreach (XmlDocument xmldocsPVEquipment in list_pvequipment)
                                    {
                                        foreach (XmlNode xmlnode_pvEquipment in xmldocsPVEquipment.SelectNodes("/EPVS/EPV"))
                                        {
                                            if (xmlnode_pvEquipment.Attributes["name"].Value == xmlElement.Attributes["name"].Value)
                                            {
                                                XmlElement xmlPVEElement = ToXmlElement(xmlnode);
                                                if (!xmlPVEElement.HasAttribute("size"))
                                                {
                                                    pvequipmentChanged = true;
                                                    //Create a new attribute
                                                    XmlAttribute attr = xmldocs.CreateAttribute("size");
                                                    attr.Value = "1";
                                                    xmlnode_pvEquipment.Attributes.SetNamedItem(attr);
                                                }
                                                temp_array[11] = xmldocsPVEquipment.BaseURI.Replace("file:///", String.Empty);
                                                temp_array[12] = xmlnode_pvEquipment.Attributes["size"].Value;
                                            }
                                        }
                                    }
                                }
                            }

                            if (pdavarfound)
                                temp_list.Add(temp_array);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return temp_list;
        }

        private bool Contains_ValueContainsInList(string value, string[] list)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                foreach (string item in list) // Es wird geprüft ob ein Objekt in der Liste, im string 
                {
                    if (value.Contains(item))
                        return true;
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return false;
        }

        private static XmlElement ToXmlElement(XmlNode node)
        {
            return node as XmlElement; // returns null if node is not an XElement
        }

        public void SaveConfiguration()
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                if (equipmentChanged)
                {
                    foreach (XmlDocument item in list_equipment)
                    {
                        if (item.DocumentType != null)
                        {
                            item.ReplaceChild(item.CreateDocumentType(item.DocumentType.Name, item.DocumentType.PublicId, item.DocumentType.SystemId, string.IsNullOrEmpty(item.DocumentType.InternalSubset) ? null : item.DocumentType.InternalSubset), item.DocumentType);
                        }
                        item.Save(item.BaseURI.Replace("file:///", String.Empty));
                    }
                    equipmentChanged = false;
                }
                if (pvequipmentChanged)
                {
                    foreach (XmlDocument item in list_pvequipment)
                    {
                        if (item.DocumentType != null)
                        {
                            item.ReplaceChild(item.CreateDocumentType(item.DocumentType.Name, item.DocumentType.PublicId, item.DocumentType.SystemId, string.IsNullOrEmpty(item.DocumentType.InternalSubset) ? null : item.DocumentType.InternalSubset), item.DocumentType);
                        }
                        item.Save(item.BaseURI.Replace("file:///", String.Empty));
                    }
                    pvequipmentChanged = false;
                }
                if (pvprocessChanged)
                {
                    foreach (XmlDocument item in list_pvprocess)
                    {
                        if (item.DocumentType != null)
                        {
                            item.ReplaceChild(item.CreateDocumentType(item.DocumentType.Name, item.DocumentType.PublicId, item.DocumentType.SystemId, string.IsNullOrEmpty(item.DocumentType.InternalSubset) ? null : item.DocumentType.InternalSubset), item.DocumentType);
                        }
                        item.Save(item.BaseURI.Replace("file:///", String.Empty));
                    }
                    pvprocessChanged = false;
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        #region Alle restlichen OPC Variablen hinzufügen.
        public List<object[]> GetListObjArrayOfRestOPCVariables(int listid, List<string> list_activeVariables)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            List<object[]> temp_list = new List<object[]>();
            bool varfound;
            try
            {
                if (list_pvprocess.Count != 0 || list_pvprocess != null)
                {
                    //PV_Process auslesen
                    foreach (XmlDocument xmldocs in list_pvprocess)
                    {
                        foreach (XmlNode xmlnode in xmldocs.SelectNodes("/PPVS/PPV"))
                        {
                            varfound = false;
                            XmlElement xmlElement = null;
                            object[] temp_array = new object[20];
                            temp_array[0] = listid;
                            temp_array[1] = modulename;
                            if (xmlnode.NodeType == XmlNodeType.Element)
                            {
                                xmlElement = ToXmlElement(xmlnode);
                                if (xmlElement.HasAttribute("opcActive") && (xmlElement.Attributes["opcActive"].Value == "1" || xmlElement.Attributes["opcActive"].Value == "0"))
                                {
                                    if (xmlElement.HasAttribute("name") && !list_activeVariables.Contains(xmlElement.Attributes["name"].Value))
                                    {
                                        temp_array[2] = xmldocs.BaseURI.Replace("file:///", String.Empty);
                                        if (xmlElement.HasAttribute("name"))
                                            temp_array[3] = xmlElement.Attributes["name"].Value;
                                        if (xmlElement.HasAttribute("pdaCounterType"))
                                            temp_array[4] = xmlElement.Attributes["pdaCounterType"].Value;
                                        if (xmlElement.HasAttribute("varTxt"))
                                            temp_array[5] = xmlElement.Attributes["varTxt"].Value;
                                        if (xmlElement.HasAttribute("cmt"))
                                            temp_array[6] = xmlElement.Attributes["cmt"].Value;

                                        if (!xmlElement.HasAttribute("opcDataType"))
                                        {
                                            //Create a new attribute
                                            XmlAttribute attr = xmldocs.CreateAttribute("opcDataType");
                                            attr.Value = "STRING";
                                            xmlnode.Attributes.SetNamedItem(attr);
                                        }
                                        temp_array[7] = xmlElement.Attributes["opcDataType"].Value;
                                        if (!xmlElement.HasAttribute("opcRwu"))
                                        {
                                            //Create a new attribute
                                            XmlAttribute attr = xmldocs.CreateAttribute("opcRwu");
                                            attr.Value = "0";
                                            xmlnode.Attributes.SetNamedItem(attr);
                                        }
                                        temp_array[8] = xmlElement.Attributes["opcRwu"].Value;
                                        if (!xmlElement.HasAttribute("opcAlias"))
                                        {
                                            //Create a new attribute
                                            XmlAttribute attr = xmldocs.CreateAttribute("opcAlias");
                                            attr.Value = xmlElement.Attributes["cmt"].Value;
                                            xmlnode.Attributes.SetNamedItem(attr);
                                        }
                                        temp_array[9] = xmlElement.Attributes["opcAlias"].Value;
                                        if (!xmlElement.HasAttribute("opcActive"))
                                        {
                                            //Create a new attribute
                                            XmlAttribute attr = xmldocs.CreateAttribute("opcActive");
                                            attr.Value = "1";
                                            xmlnode.Attributes.SetNamedItem(attr);
                                        }
                                        temp_array[10] = xmlElement.Attributes["opcActive"].Value;

                                        varfound = true;
                                    }
                                }
                            }
                            //pv_euqipment
                            if (varfound)
                            {
                                foreach (XmlDocument xmldocsPVEquipment in list_pvequipment)
                                {
                                    foreach (XmlNode xmlnode_pvEquipment in xmldocsPVEquipment.SelectNodes("/EPVS/EPV"))
                                    {
                                        if (xmlnode_pvEquipment.Attributes["name"].Value == xmlElement.Attributes["name"].Value)
                                        {
                                            XmlElement xmlPVEElement = ToXmlElement(xmlnode);
                                            if (!xmlPVEElement.HasAttribute("size"))
                                            {
                                                pvequipmentChanged = true;
                                                //Create a new attribute
                                                XmlAttribute attr = xmldocs.CreateAttribute("size");
                                                attr.Value = "1";
                                                xmlnode_pvEquipment.Attributes.SetNamedItem(attr);
                                            }
                                            temp_array[11] = xmldocsPVEquipment.BaseURI.Replace("file:///", String.Empty);
                                            temp_array[12] = xmlnode_pvEquipment.Attributes["size"].Value;
                                        }
                                    }
                                }
                            }
                            if (varfound)
                                temp_list.Add(temp_array);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return temp_list;
        }
        #endregion

        #region BatchVariablen generieren
        public List<object[]> GetListObjArrayOfBatchOPCVariables(int listid)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            List<object[]> temp_list = new List<object[]>();
            if (list_pvbatch.Count > 0)
            {
                bool varfound = false;
                try
                {
                    //PV_Batch auslesen
                    foreach (XmlDocument xmldocs in list_pvbatch)
                    {
                        foreach (XmlNode xmlnode in xmldocs.SelectNodes("/APVS/APV"))
                        {
                            varfound = false;
                            temp_list.Add(new object[20]);
                            temp_list[temp_list.Count - 1][0] = listid;
                            temp_list[temp_list.Count - 1][1] = modulename;
                            if (xmlnode.NodeType == XmlNodeType.Element)
                            {
                                XmlElement xmlElement = ToXmlElement(xmlnode);
                                if (xmlElement.HasAttribute("name"))
                                {
                                    if (!(xmlElement.Attributes["name"].Value == "" || xmlElement.Attributes["name"].Value == String.Empty || xmlElement.Attributes["name"].Value == null))
                                    {
                                        temp_list[temp_list.Count - 1][17] = xmldocs.BaseURI.Replace("file:///", String.Empty);
                                        temp_list[temp_list.Count - 1][18] = xmlElement.Attributes["name"].Value;
                                        varfound = true;
                                        continue;
                                    }
                                }
                                if (xmlElement.HasAttribute("batchName") && !varfound)
                                {
                                    if (!(xmlElement.Attributes["batchName"].Value == "" || xmlElement.Attributes["batchName"].Value == String.Empty || xmlElement.Attributes["batchName"].Value == null))
                                    {
                                        temp_list[temp_list.Count - 1][17] = xmldocs.BaseURI.Replace("file:///", String.Empty);
                                        temp_list[temp_list.Count - 1][18] = xmlElement.Attributes["batchName"].Value;

                                    }
                                }
                            }
                        }
                    }
                    //copy of list, to make it more simple to work with
                    string[] temp_list_simple = new string[temp_list.Count];
                    for (int i_temp_list = 0; i_temp_list < temp_list.Count; i_temp_list++)
                        temp_list_simple[i_temp_list] = temp_list[i_temp_list][18].ToString();
                    //PV_Process auslesen
                    if (temp_list.Count > 0)
                    {
                        foreach (XmlDocument xmldocs in list_pvprocess)
                        {
                            foreach (XmlNode xmlnode in xmldocs.SelectNodes("/PPVS/PPV"))
                            {
                                if (xmlnode.NodeType == XmlNodeType.Element)
                                {
                                    XmlElement xmlElement = ToXmlElement(xmlnode);
                                    if (xmlElement.HasAttribute("name"))
                                    {
                                        int temp_listid = BMTVariableExistInList(xmlElement.Attributes["name"].Value, temp_list_simple, Client.Properties.Settings.BATCHVARPREFIX);
                                        if (temp_listid >= 0)
                                        {
                                            temp_list[temp_listid][2] = xmldocs.BaseURI.Replace("file:///", String.Empty);
                                            temp_list[temp_listid][3] = xmlElement.Attributes["name"].Value;
                                            if (xmlElement.HasAttribute("varTxt"))
                                                temp_list[temp_listid][5] = xmlElement.Attributes["varTxt"].Value;
                                            if (xmlElement.HasAttribute("cmt"))
                                                temp_list[temp_listid][6] = xmlElement.Attributes["cmt"].Value;

                                            if (!xmlElement.HasAttribute("opcDataType"))
                                            {
                                                //Create a new attribute
                                                XmlAttribute attr = xmldocs.CreateAttribute("opcDataType");
                                                attr.Value = "STRING";
                                                xmlnode.Attributes.SetNamedItem(attr);
                                            }
                                            temp_list[temp_listid][7] = xmlElement.Attributes["opcDataType"].Value;
                                            if (!xmlElement.HasAttribute("opcRwu"))
                                            {
                                                //Create a new attribute
                                                XmlAttribute attr = xmldocs.CreateAttribute("opcRwu");
                                                attr.Value = "0";
                                                xmlnode.Attributes.SetNamedItem(attr);
                                            }
                                            temp_list[temp_listid][8] = xmlElement.Attributes["opcRwu"].Value;
                                            if (!xmlElement.HasAttribute("opcAlias"))
                                            {
                                                //Create a new attribute
                                                XmlAttribute attr = xmldocs.CreateAttribute("opcAlias");
                                                attr.Value = xmlElement.Attributes["name"].Value;
                                                xmlnode.Attributes.SetNamedItem(attr);
                                            }
                                            temp_list[temp_listid][9] = xmlElement.Attributes["opcAlias"].Value;
                                            if (!xmlElement.HasAttribute("opcActive"))
                                            {
                                                //Create a new attribute
                                                XmlAttribute attr = xmldocs.CreateAttribute("opcActive");
                                                attr.Value = "1";
                                                xmlnode.Attributes.SetNamedItem(attr);
                                            }
                                            temp_list[temp_listid][10] = xmlElement.Attributes["opcActive"].Value;
                                            
                                            pvprocessChanged = true;
                                        }
                                    }
                                }
                            }
                        }
                        //PV_Equipment auslesen
                        if (temp_list.Count > 0)
                        {

                        }
                        //Templist aufräumen
                        if (varfound)
                        {
                            for (int i = temp_list.Count-1; i >= 0 && temp_list.Count >0; i--)
                            {
                                    if (temp_list[i][18] == null)
                                        temp_list.RemoveAt(i++);
                            }
                        }
                        else
                        {
                            temp_list.Clear();
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
                }
            }
            return temp_list;
        }

        private int BMTVariableExistInList(string value, string[] array, string prefix)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                for (int i = 0; i < array.Count(); i++)
                {
                    if (value.StartsWith(prefix))
                    {
                        if (array[i].Equals(value.Remove(0,prefix.Count())))
                            return i;
                    }
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return -1;
        }
        #endregion
    }
}

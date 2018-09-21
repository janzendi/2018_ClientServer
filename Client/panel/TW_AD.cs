using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Fonts;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Threading;

namespace Client.panel
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TW_AD : MetroUserControl
    {

        private System.Collections.Generic.List<XmlDocument> listXmlEquipment;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        /// <param name="metroStyleManager"></param>
        public TW_AD(MetroFramework.Components.MetroStyleManager metroStyleManager)
        {
            InitializeComponent();
            this.CustomInitializeComponent(metroStyleManager); // deklariert im *.Designer.cs

            // objects
            listXmlEquipment = new List<XmlDocument>();

            // Ordner aus der History laden
            mtxtBox_TWPath_1038.Text = global.config.ConfigReadWriter.TWADPREPATH;

            // Save button deaktivieren
            mbtnSave_1040.Enabled = false;

            metroGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        /// <summary>
        /// Event um Ordner zu öffnen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <created>janzen_d,2018-09-17</created>
        /// <modified>janzen_d,2018-09-18: Logik weitergearbeitet</modified>
        private void mbtnSelectFolder_1039_Click(object sender, EventArgs e)
        {
            global.log.MetroLog.INSTANCE.WriteLine("", global.log.MetroLog.LogType.INFO, 1041);
            folderBrowserDialog.SelectedPath = mtxtBox_TWPath_1038.Text; // versuchen Ordner aus der Textbox setzen
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK) // Ordner öffnen
            {
                if (System.IO.Directory.Exists(folderBrowserDialog.SelectedPath + "\\platform\\fm") && System.IO.File.Exists(folderBrowserDialog.SelectedPath + "\\build\\version_1\\process.xml"))
                {
                    //Alte Daten löschen
                    metroGrid.Rows.Clear();
                    listXmlEquipment.Clear();

                    //
                    // Ordner gefunden
                    //
                    mtxtBox_TWPath_1038.Text = folderBrowserDialog.SelectedPath;
                    global.config.ConfigReadWriter.TWADPREPATH = folderBrowserDialog.SelectedPath;
                    global.log.MetroLog.INSTANCE.WriteLine("", global.log.MetroLog.LogType.INFO, 1053);

                    //
                    // Temp Liste erstellen
                    //
                    List<string> activemodules = new List<string>();

                    // \\build\\version_1\\process.xml durchsuchen auf aktive Module
                    XmlDocument xmlDocumentProcessXML = new XmlDocument();
                    xmlDocumentProcessXML.XmlResolver = null;
                    xmlDocumentProcessXML.Load(folderBrowserDialog.SelectedPath + "\\build\\version_1\\process.xml");
                    foreach (XmlNode fmNode in xmlDocumentProcessXML.SelectNodes("/PROCESS/PM/FLOW/FM"))
                    {
                        try
                        {
                            if (fmNode.Attributes["act"].Value == "1" && fmNode.Attributes["dir"].Value != null && fmNode.Attributes["dir"].Value != String.Empty && fmNode.Attributes["dir"].Value != "")
                                activemodules.Add(fmNode.Attributes["dir"].Value);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    global.log.MetroLog.INSTANCE.WriteLine(" " + activemodules.Count.ToString(), global.log.MetroLog.LogType.INFO, 1054);

                    //
                    // Alle euqipment Dateien durchsuchen
                    //
                    DirectoryInfo dcPlattform = new DirectoryInfo(folderBrowserDialog.SelectedPath + "\\platform\\fm");
                    int directoryCount = dcPlattform.GetDirectories().Length;
                    int i = 0;
                    foreach (DirectoryInfo directory in dcPlattform.GetDirectories())
                    {
                        if (activemodules.Contains(directory.Name))
                        {
                            // Log Informationen
                            global.log.MetroLog.INSTANCE.DebugWriteLine(" " + directory.FullName, global.log.MetroLog.LogType.INFO, 1055);

                            //
                            // Für jedes equipmentfile ein Thread starten
                            //
                            if (Directory.Exists(directory.FullName + "\\uhlmann\\tc\\equipment"))
                            {
                                foreach (string stritem in Directory.GetFiles(directory.FullName + "\\uhlmann\\tc\\equipment"))
                                {
                                    string extension = Path.GetExtension(stritem);
                                    if (extension == ".xml" || extension == ".XML")
                                    {
                                        // Thread starten
                                        Thread thread = new Thread(new ParameterizedThreadStart(ThreadTWEquipmentCheck));
                                        thread.Start(stritem);
                                    }
                                }
                            }
                        }
                        global.log.MetroLog.INSTANCE.ProgressBar((decimal)(++i) / (decimal)directoryCount, directory.Name);
                    }

                    // Save button aktivieren
                    mbtnSave_1040.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Multithread Methode um Dateien zu analisieren
        /// </summary>
        /// <param name="directory"></param>
        /// <created>janzen_d,2018-09-18</created>
        private void ThreadTWEquipmentCheck(object directory)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.XmlResolver = null;
            xmlDocument.Load(directory.ToString());
            if (xmlDocument != null)
            {
                XmlNode xmlNodeAcc = xmlDocument.SelectSingleNode("EQUIPMENT/ACC_CONF/acc[@mainAppPrefix]");
                if (xmlNodeAcc != null)
                {
                    string[] strRow = new string[11];
                    listXmlEquipment.Add(xmlDocument);
                    strRow[3] = directory.ToString();
                    strRow[4] = listXmlEquipment.IndexOf(xmlDocument).ToString();
                    strRow[5] = xmlNodeAcc.Attributes["mainAppPrefix"].Value.ToString();

                    XmlNodeList xmlNodeLvls = xmlDocument.SelectNodes("//groups/*[@name]");
                    XmlNodeList xmlNodeAuth = xmlDocument.SelectNodes("//groups/*[@authorityValue]");
                    if (xmlNodeLvls.Count > 0) // Mit Gruppen suffix
                    {
                        foreach (XmlNode xmlNodeLvl in xmlNodeLvls)
                        {
                            string tmp = null;
                            try
                            {
                                tmp = xmlNodeLvl.Attributes["name"].Value;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                            if (tmp != null)
                            {
                                switch (xmlNodeLvl.Name)
                                {
                                    case "Level2":
                                        strRow[6] = tmp;
                                        break;
                                    case "Level3":
                                        strRow[7] = tmp;
                                        break;
                                    case "Level4":
                                        strRow[8] = tmp;
                                        break;
                                    case "Level11":
                                        strRow[9] = tmp;
                                        break;
                                    case "Level15":
                                        strRow[10] = tmp;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    else if (xmlNodeAuth.Count > 0) // Keine Gruppen Suffix konfiguriert
                    {
                        foreach (XmlNode xmlNodeLvl in xmlNodeAuth)
                        {
                            string tmp = null;
                            try
                            {
                                tmp = xmlNodeLvl.Attributes["authorityValue"].Value;
                            }
                            catch (Exception) // TODO
                            {
                                throw;
                            }
                            if (tmp != null)
                            {
                                switch (xmlNodeLvl.Name)
                                {
                                    case "Level2":
                                        strRow[6] = xmlNodeLvl.Name;
                                        break;
                                    case "Level3":
                                        strRow[7] = xmlNodeLvl.Name;
                                        break;
                                    case "Level4":
                                        strRow[8] = xmlNodeLvl.Name;
                                        break;
                                    case "Level11":
                                        strRow[9] = xmlNodeLvl.Name;
                                        break;
                                    case "Level15":
                                        strRow[10] = xmlNodeLvl.Name;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    this.AddRow(strRow);
                }
            }
        }

        private delegate void dgAddRow(string[] gridrow);
        /// <summary>
        /// Thread Eine Zeile im DataGrid hinzufügen.
        /// </summary>
        /// <param name="gridrow"></param>
        /// <created>janzen_d,2018-09-18</created>
        private void AddRow(string[] gridrow)
        {
            try
            {
                if (metroGrid.InvokeRequired) //Threadprogrammierung um zu verhindern, das ein anderer Prozess gleichzeitig auf das Objekt zugreift.
                {
                    metroGrid.BeginInvoke(new dgAddRow(AddRow), new object[] { gridrow });
                }
                else
                {
                    metroGrid.Rows.Add(gridrow);
                    for (int i = 5; i < 11; i++)
                    {
                        if (gridrow[i] != null)
                            metroGrid.Rows[metroGrid.Rows.Count - 2].Cells[i].ReadOnly = false; // -2 da ein datagrid immer eine zusatzzeile besitzt.
                        else
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                string tmp = "ERROR: Log data could not be written. Please contact the developer and forward file \"LOGEXCEPTION.txt\" in the main application folder." + " Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString();
                MessageBox.Show(tmp);
                TextWriter txtFile = new StreamWriter("LOGEXCEPTION.txt");
                txtFile.Write(tmp);
                txtFile.Close();
            }
        }

        /// <summary>
        /// Event um Config zu speichern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <created>janzen_d,2018-09-17</created>
        /// <modified>janzen_d,2018-09-19</modified>
        /// <modified>janzen_d,2018-09-21: Bracket Logik in Threads ausgelagert</modified>
        private void mbtnSave_1040_Click(object sender, EventArgs e)
        {
            global.log.MetroLog.INSTANCE.DebugWriteLine(this.ToString() + " - " + System.Reflection.MethodBase.GetCurrentMethod(), global.log.MetroLog.LogType.INFO, 1056);
            int iProgress = 0;
            foreach (DataGridViewRow dataRow in metroGrid.Rows)
            {
                if (dataRow.Cells[4].Value == null || dataRow.Cells[4].Value.ToString() == String.Empty || dataRow.Cells[4].Value.ToString() == "") // [4] = gridListequipmentid_1046
                    continue;
                else
                {
                    // Group prefix
                    try { listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc").Attributes["mainAppPrefix"].Value = dataRow.Cells[5].Value.ToString(); } // [5] = gridADGroupprefix_1047                   
                    catch (Exception ex) { global.log.MetroLog.INSTANCE.DebugWriteLine(ex.ToString(), global.log.MetroLog.LogType.ERROR, 1057); }

                    // [6] = gridLvl2_1048
                    try
                    {
                        if (dataRow.Cells[6].Value != null && dataRow.Cells[6].Value.ToString().Length > 2)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level2").Attributes["name"].Value = dataRow.Cells[6].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        XmlNode xmlNode = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level2");
                        XmlAttribute typeAttr = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].CreateAttribute("name");
                        typeAttr.Value = dataRow.Cells[6].Value.ToString();
                        xmlNode.Attributes.Append(typeAttr);
                        global.log.MetroLog.INSTANCE.DebugWriteLine(ex.ToString(), global.log.MetroLog.LogType.WARNING, 1057);
                    }

                    // [7] = gridLvl3_1049
                    try
                    {
                        if (dataRow.Cells[7].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level3").Attributes["name"].Value = dataRow.Cells[7].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        XmlNode xmlNode = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level3");
                        XmlAttribute typeAttr = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].CreateAttribute("name");
                        typeAttr.Value = dataRow.Cells[7].Value.ToString();
                        xmlNode.Attributes.Append(typeAttr);
                        global.log.MetroLog.INSTANCE.DebugWriteLine(ex.ToString(), global.log.MetroLog.LogType.WARNING, 1057);
                    }

                    // [8] = gridLvl4_1050
                    try
                    {
                        if (dataRow.Cells[8].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level4").Attributes["name"].Value = dataRow.Cells[8].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        XmlNode xmlNode = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level4");
                        XmlAttribute typeAttr = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].CreateAttribute("name");
                        typeAttr.Value = dataRow.Cells[8].Value.ToString();
                        xmlNode.Attributes.Append(typeAttr);
                        global.log.MetroLog.INSTANCE.DebugWriteLine(ex.ToString(), global.log.MetroLog.LogType.WARNING, 1057);
                    }

                    // [9] = gridLvl11_1051
                    try
                    {
                        if (dataRow.Cells[9].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level11").Attributes["name"].Value = dataRow.Cells[9].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        XmlNode xmlNode = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level11");
                        XmlAttribute typeAttr = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].CreateAttribute("name");
                        typeAttr.Value = dataRow.Cells[9].Value.ToString();
                        xmlNode.Attributes.Append(typeAttr);
                        global.log.MetroLog.INSTANCE.DebugWriteLine(ex.ToString(), global.log.MetroLog.LogType.WARNING, 1057);
                    }

                    // [10] = gridLvl15_1052
                    try
                    {
                        if (dataRow.Cells[10].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level15").Attributes["name"].Value = dataRow.Cells[10].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        XmlNode xmlNode = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level15");
                        XmlAttribute typeAttr = listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].CreateAttribute("name");
                        typeAttr.Value = dataRow.Cells[10].Value.ToString();
                        xmlNode.Attributes.Append(typeAttr);
                        global.log.MetroLog.INSTANCE.DebugWriteLine(ex.ToString(), global.log.MetroLog.LogType.WARNING, 1057);
                    }

                    try
                    {
                        listXmlEquipment[Convert.ToInt32(dataRow.Cells[4].Value)].Save(dataRow.Cells[3].Value.ToString()); // [3] = gridTwequipmentfilepath_1045
                        // Thread starten
                        Thread thread = new Thread(new ParameterizedThreadStart(DeleteBracketsInDOCTYPE));
                        thread.Start(dataRow.Cells[3].Value.ToString());
                        global.log.MetroLog.INSTANCE.WriteLine(dataRow.Cells[3].Value.ToString(), global.log.MetroLog.LogType.INFO, 1058);
                        global.log.MetroLog.INSTANCE.ProgressBar((decimal)(++iProgress) / ((decimal)metroGrid.Rows.Count-1), dataRow.Cells[3].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        global.log.MetroLog.INSTANCE.DebugWriteLine(ex.ToString(), global.log.MetroLog.LogType.ERROR, 1057);
                    }
                }
            }
        }

        /// <summary>
        /// Thread Methode um im DOCTYPE [] zu löschen.
        /// </summary>
        /// <param name="filepath"></param>
        /// <created>janzen_d,2018-09-21</created>
        private void DeleteBracketsInDOCTYPE(object filepath)
        {
            try
            {
                string[] file = File.ReadAllLines(filepath.ToString());
                string line = null;
                for (int i = 0; i < file.Length; i++)
                {
                    line = file[i];
                    int firstBracket = line.IndexOf('[');
                    int secondBracket = line.IndexOf(']');
                    if ((secondBracket - firstBracket) == 1)
                    {
                        file[i] = file[i].Replace('[', ' ');
                        file[i] = file[i].Replace(']', ' ');
                        break;
                    }
                }
                File.WriteAllLines(filepath.ToString(), file);
            }
            catch (Exception)
            {

                throw;
            }
        }
  
    }
}
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
        }

        /// <summary>
        /// Event um Ordner zu öffnen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <created>janzen_d,2018-09-17</created>
        /// <modified>janzen_d,2018-09-18: Logik weitergearbeitet</modified>
        private void mbtnSelectFolder_1039_Click(object sender, EventArgs e) //TODO
        {
            global.log.MetroLog.INSTANCE.WriteLine("", global.log.MetroLog.LogType.INFO,1041);
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
                            global.log.MetroLog.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)directoryCount, directory.Name);

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
                    }
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
                    listXmlEquipment.Add(xmlDocument);
                    string[] strRow = new string[11];
                    strRow[3] = directory.ToString();
                    strRow[4] = listXmlEquipment.IndexOf(xmlDocument).ToString();
                    strRow[5] = xmlNodeAcc.Attributes["mainAppPrefix"].Value.ToString();

                    XmlNode xmlNodeLvl2 = xmlDocument.SelectSingleNode("//Level2");
                    if (xmlNodeLvl2 != null)
                    {

                    }
                    XmlNode xmlNodeLvl3 = xmlDocument.SelectSingleNode("//Level3");
                    XmlNode xmlNodeLvl4 = xmlDocument.SelectSingleNode("//Level4");
                    XmlNode xmlNodeLvl11 = xmlDocument.SelectSingleNode("//Level11");
                    XmlNode xmlNodeLvl15 = xmlDocument.SelectSingleNode("//Level15");

                    XmlNodeList xmlNodetmp = xmlDocument.SelectNodes("//groups/*[@name]");
                    if (xmlNodetmp.Count > 0)
                    {
                        global.log.MetroLog.INSTANCE.WriteLine("test:\t" + xmlNodetmp.ToString(), global.log.MetroLog.LogType.ERROR);

                    }                    
                }
            }
        }

        /// <summary>
        /// Event um Config zu speichern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <created>janzen_d,2018-09-17</created>
        private void mbtnSave_1040_Click(object sender, EventArgs e)
        {

        }
    }
}

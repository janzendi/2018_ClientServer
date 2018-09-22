using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Controls;
using Client.global.objects.twizard;
using System.IO;
using System.Threading;
using System.Xml;

namespace Client.panel
{
    /// <summary>
    /// User Control für Standard OPC Interface
    /// </summary>
    /// <created>janzen_d,2018-09-21</created>
    public partial class TW_STOPC : MetroUserControl
    {
        private List<OPCTag> listOpcTags;
        private List<Thread> listThreads;

        public TW_STOPC(MetroFramework.Components.MetroStyleManager metroStyleManager)
        {
            InitializeComponent();
            this.CustomInitializeComponent(metroStyleManager); // deklariert im *.Designer.cs

            listOpcTags = new List<OPCTag>();
            listThreads = new List<Thread>();
        }

        public void Close()
        {
            global.config.ConfigReadWriter.TWOPCPATH=this.mtxtBox_TWPath_1038.Text;
        }

        /// <summary>
        /// Event um Twizard einzulesen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <created>janzen_d,2018-09-21</created>
        private void MbtnSelectFolder_1039_Click(object sender, System.EventArgs e)
        {
            global.log.MetroLog.INSTANCE.WriteLine("", global.log.MetroLog.LogType.INFO, 1041);
            folderBrowserDialog.SelectedPath = mtxtBox_TWPath_1038.Text; // versuchen Ordner aus der Textbox setzen
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK) // Ordner öffnen
            {
                if (Directory.Exists(folderBrowserDialog.SelectedPath + "\\platform\\fm") && File.Exists(folderBrowserDialog.SelectedPath + "\\build\\version_1\\process.xml"))
                {
                    //Alte Daten löschen
                    metroGrid.Rows.Clear();
                    listOpcTags.Clear();
                    listThreads.Clear();

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
                    System.Xml.XmlDocument xmlDocumentProcessXML = new System.Xml.XmlDocument();
                    xmlDocumentProcessXML.XmlResolver = null;
                    xmlDocumentProcessXML.Load(folderBrowserDialog.SelectedPath + "\\build\\version_1\\process.xml");
                    foreach (System.Xml.XmlNode fmNode in xmlDocumentProcessXML.SelectNodes("/PROCESS/PM/FLOW/FM"))
                    {
                        try
                        {
                            if (fmNode.Attributes["act"].Value == "1" && fmNode.Attributes["dir"].Value != null && fmNode.Attributes["dir"].Value != System.String.Empty && fmNode.Attributes["dir"].Value != "")
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
                            if (Directory.Exists(directory.FullName + "\\uhlmann\\tc\\pv_equipment") && Directory.Exists(directory.FullName + "\\uhlmann\\tc\\pv_process"))
                            {
                                // Thread starten
                                Thread thread = new Thread(new ParameterizedThreadStart(ThreadAnalyzeTWOPC));
                                listThreads.Add(thread);
                                thread.Start(directory.FullName);
                            }
                        }
                        global.log.MetroLog.INSTANCE.ProgressBar((decimal)(++i) / (decimal)directoryCount, directory.Name);
                    }

                    //
                    // prüfen ob alle Threads fertig sind
                    //
                    bool finishloop = false;
                    while (finishloop)
                    {
                        int finishcount = 0;
                        for (int icount = 0; i < listThreads.Count; i++)
                        {
                            if (!listThreads[icount].IsAlive)
                                finishcount++;
                        }
                        if (finishcount == (listThreads.Count - 1))
                            finishloop = true;
                    }
                    // Save button aktivieren
                    mbtnSave_1040.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Thread um Twizard analisieren
        /// </summary>
        /// <param name="twizardpath"></param>
        /// <created>janzen_d,2018-09-21</created>
        private void ThreadAnalyzeTWOPC(object twizardpath)
        {
            if (twizardpath != null && twizardpath.ToString().Length > 3)
            {
                //
                // analyze pv_process
                //
                if (Directory.Exists(twizardpath.ToString() + "\\uhlmann\\tc\\pv_process"))
                {
                    string[] paths_pv_process = Directory.GetFiles(twizardpath.ToString() + "\\uhlmann\\tc\\pv_process");
                    foreach (string item in paths_pv_process)
                    {
                        string extension = Path.GetExtension(item);
                        if (extension == ".xml" || extension == ".XML")
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.XmlResolver = null;
                            xmlDocument.Load(item);
                            foreach (XmlNode xmlNode in xmlDocument.SelectNodes("PPVS/PPV[@name]"))
                            {
                                try
                                {
                                    OPCTag oPCTag = new OPCTag(xmlNode.Attributes["name"].Value);
                                    if (!listOpcTags.Contains(oPCTag))
                                    {
                                        listOpcTags.Add(oPCTag);
                                        oPCTag.LISTID = listOpcTags.IndexOf(oPCTag);
                                        oPCTag.MODULENAME = twizardpath.ToString();
                                        oPCTag.PVPROCESSPATH = item;
                                        foreach (XmlAttribute xmlAttribute in xmlNode.Attributes)
                                        {
                                            switch (xmlAttribute.Name)
                                            {
                                                case "varTxt":  // Text-ID
                                                    oPCTag.TEXTID = xmlAttribute.Value;
                                                    break;
                                                case "cmt":     // Kommentar
                                                    oPCTag.COMMENT = xmlAttribute.Value;
                                                    break;
                                                case "opcActive":
                                                    oPCTag.OPCACTIVE = xmlAttribute.Value;
                                                    break;
                                                case "opcDataType":
                                                    oPCTag.OPCDATATYPE = xmlAttribute.Value;
                                                    break;
                                                case "opcRwu":
                                                    oPCTag.OPCRWU = xmlAttribute.Value;
                                                    break;
                                                case "opcAlias":
                                                    oPCTag.OPCALIAS = xmlAttribute.Value;
                                                    break;
                                                case "semantic":
                                                    oPCTag.SEMANTIC = xmlAttribute.Value;
                                                    break;
                                                case "dcReadPeriod":
                                                    oPCTag.DCREADPERIOD = xmlAttribute.Value;
                                                    break;
                                                case "dcLogThreshold":
                                                    oPCTag.LOGTHRESHOLD = xmlAttribute.Value;
                                                    break;
                                                case "dcMaxPersistence":
                                                    oPCTag.DCMAXPERSISTENCE = xmlAttribute.Value;
                                                    break;
                                                case "pdaCounterType":
                                                    oPCTag.PDACOUNTERTYPE = xmlAttribute.Value;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }

                //
                // pv_equipment analysieren
                //
                if (Directory.Exists(twizardpath.ToString() + "\\uhlmann\\tc\\pv_equipment"))
                {

                    string[] paths_pv_equipment = Directory.GetFiles(twizardpath.ToString() + "\\uhlmann\\tc\\pv_process");
                    foreach (string path in paths_pv_equipment)
                    {
                        string extension = Path.GetExtension(path);
                        if (extension == ".xml" || extension == ".XML")
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.XmlResolver = null;
                            xmlDocument.Load(path);
                            foreach (XmlNode xmlNode in xmlDocument.SelectNodes("EPVS/EPV[@name]"))
                            {
                                try
                                {
                                    OPCTag oPCTag = new OPCTag(xmlNode.Attributes["name"].Value);
                                    if (listOpcTags.Contains(oPCTag))
                                    {
                                        int index = listOpcTags.IndexOf(oPCTag);
                                        foreach (XmlAttribute xmlAttribute in xmlNode.Attributes)
                                        {
                                            switch (xmlAttribute.Name)
                                            {
                                                case "size":
                                                    listOpcTags[index].ARRAYSIZE = xmlAttribute.Value;
                                                    listOpcTags[index].PVEQUIPMENTPATH = path;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event um Änderungen zu speichern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <created>janzen_d,2018-09-21</created>
        private void MbtnSave_1040_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

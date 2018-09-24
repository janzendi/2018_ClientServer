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
    /// 
    ///TW_OPC
    ///gridlistid_1060                  0		-
    ///gridmodulename_1044				1		-
    ///gridvariablename_1061			2		-
    ///gridpvbatchvariable_1062		    3		-
    ///gridpdacountertype_1063			4		-
    ///gridtextid_1064					5		-
    ///gridcomment_1065				    6		-
    ///gridopcdatatype_1066			    7		-
    ///gridopcrwu_1067					8		-
    ///gridopcalias_1068				9		-
    ///gridopcactive_1069				10		-
    ///gridarrysize_1070				11		-
    ///gridsemantic_1071				12		-
    ///griddcreadperiod_1072			13		-
    ///griddclogthreshold_1073			14		-
    ///griddcmaxpersistence_1074		15		-
    ///gridpathpvbatch_1075			    16		-
    ///gridpathpvequipment_1076		    17		-
    ///gridpathpvprocess_1077			18		-
    ///
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
            global.config.ConfigReadWriter.TWOPCPATH = this.mtxtBox_TWPath_1038.Text;
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

                    Thread threadShowData = new Thread(new ThreadStart(AddData));
                    threadShowData.Start();
                }
            }
        }

        /// <summary>
        /// Methode um Grid zu befüllen
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        private void AddData()
        {
            global.log.MetroLog.INSTANCE.ProgressBar(1 / 2, global.language.LanguageHandler.INSTANCE.GETOBJWORD(1086)[2].ToString());
            //
            // prüfen ob alle Threads fertig sind
            //
            while (true)
            {
                int finishcount = 0;
                for (int icount = 0; icount < listThreads.Count; icount++)
                {
                    if (!listThreads[icount].IsAlive)
                        finishcount++;
                }
                if (finishcount == listThreads.Count)
                    break;
            }

            //
            // Threads starten
            //
            listThreads.Clear();
            listThreads.Add(new Thread(new ThreadStart(ThreadStandardVariablen)));
            listThreads.Add(new Thread(new ThreadStart(ThreadBatchVariablen)));
            listThreads.Add(new Thread(new ThreadStart(ThreadAnalogVariables)));
            listThreads.Add(new Thread(new ThreadStart(ThreadCounterVariables)));
            for (int i = 0; i < listThreads.Count; i++)
                listThreads[i].Start();

            //
            // prüfen ob alle Threads fertig sind
            //
            while (true)
            {
                int finishcount = 0;
                for (int icount = 0; icount < listThreads.Count; icount++)
                {
                    if (!listThreads[icount].IsAlive)
                        finishcount++;
                }
                if (finishcount == listThreads.Count)
                    break;
            }

            //TODO löschen
            /*for (int icount = 0; icount < listOpcTags.Count; icount++)
            {
                AddRow(listOpcTags[icount].GetGridRow);
                global.log.MetroLog.INSTANCE.ProgressBar((decimal)(icount+1) / (decimal)listOpcTags.Count, listOpcTags[icount].VARIABLENAME);
            }*/

            // Save button aktivieren
            EnableSaveButton(true);
            global.log.MetroLog.INSTANCE.ProgressBar(1, global.language.LanguageHandler.INSTANCE.GETOBJWORD(1086)[2].ToString());
        }

        /// <summary>
        /// Thread um alle Analog Variablen hinzuzufügen
        /// </summary>
        /// <created>janzen_d,2018-09-23</created>
        private void ThreadAnalogVariables()
        {
            try
            {
                List<int> tmpListid = new List<int>();
                for (int i = 0; i < listOpcTags.Count; i++)
                {
                    if (((listOpcTags[i].DCREADPERIOD != null && listOpcTags[i].DCREADPERIOD.Length > 0) || (listOpcTags[i].SEMANTIC != null && anlvarContainsSemantic(listOpcTags[i].SEMANTIC))) && listOpcTags[i].INTPDACOUNTERTYPE == 0)
                    {
                        tmpListid.Add(i);
                        global.log.MetroLog.INSTANCE.DebugWriteLine(listOpcTags[i].VARIABLENAME, global.log.MetroLog.LogType.INFO, 1082);
                    }
                }
                if (tmpListid.Count > 0)
                    AddListids(tmpListid.ToArray(), 1083);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// LogikMethode für ThreadAnalogVariables()
        /// </summary>
        /// <param name="analogvariable"></param>
        /// <returns></returns>
        /// <created>janzen_d,2018-09-24</created>
        private bool anlvarContainsSemantic(string analogvariable)
        {
            if (analogvariable != null)
            {
                try
                {
                    List<string> tmpListanlvar = global.config.ConfigReadWriter.GetANALOGSEMANTIC;
                    foreach (string item in tmpListanlvar)
                    {
                        if (analogvariable.Contains(item))
                            return true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }

        /// <summary>
        /// Thread um alle Counter Variablen hinzuzufügen
        /// </summary>
        /// <created>janzen_d,2018-09-23</created>
        private void ThreadCounterVariables()
        {
            try
            {
                List<int> tmpListid = new List<int>();
                for (int i = 0; i < listOpcTags.Count; i++)
                {
                    if (listOpcTags[i].INTPDACOUNTERTYPE > 0)
                    {
                        tmpListid.Add(i);
                        global.log.MetroLog.INSTANCE.DebugWriteLine(listOpcTags[i].VARIABLENAME, global.log.MetroLog.LogType.INFO, 1085);
                    }
                }
                if (tmpListid.Count > 0)
                    AddListids(tmpListid.ToArray(), 1084);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thread um alle Standardvariablen hinzuzufügen
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        private void ThreadStandardVariablen()
        {
            try
            {
                List<string> tmpListstdvar = global.config.ConfigReadWriter.GetSTDVARIABLES;
                List<int> tmpListid = new List<int>();
                if (tmpListstdvar.Count > 0)
                {
                    foreach (string stritem in tmpListstdvar)
                    {
                        OPCTag oPCTag = new OPCTag(stritem);
                        if (listOpcTags.Contains(oPCTag))
                        {
                            tmpListid.Add(listOpcTags.IndexOf(oPCTag));
                        }
                    }

                    AddListids(tmpListid.ToArray(), 1078);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thread Batch Variable durchsuchen
        /// </summary>
        /// <created>janzen_d,2018-09-23</created>
        /// <modified>janzen_d,2018-09-24: fertiggestellt</modified>
        private void ThreadBatchVariablen()
        {
            try
            {
                List<string> tmpListbmtprefix = global.config.ConfigReadWriter.GetBMTPREFIX;
                List<int> tmpListid = new List<int>();
                Dictionary<string, string> tmpdictBatchvars = new Dictionary<string, string>();
                if (tmpListbmtprefix.Count > 0) // wenn ein prefix konfiguriert ist
                {
                    for (int i = 0; i < listOpcTags.Count; i++) // eine Liste der BatchVariablen erstellen -> tmpdictBatchvars<batch variable, pv_batch path>
                    {
                        if (listOpcTags[i].BATCHVARIABLE != null && listOpcTags[i].PVBATCHPATH != null)
                        {
                            tmpdictBatchvars.Add(listOpcTags[i].BATCHVARIABLE, listOpcTags[i].PVBATCHPATH);
                            global.log.MetroLog.INSTANCE.DebugWriteLine(listOpcTags[i].BATCHVARIABLE, global.log.MetroLog.LogType.INFO, 1080);
                        }
                    }

                    if (tmpdictBatchvars.Count > 0)
                    {
                        for (int iinner = 0; iinner < listOpcTags.Count; iinner++) // alle Variablen durchgehen
                        {
                            for (int iprefix = 0; iprefix < tmpListbmtprefix.Count; iprefix++) // jeden bmt prefix prüfen
                            {
                                foreach (string key in tmpdictBatchvars.Keys) // mit jeder gefundenen batchvariable vergleichen
                                {
                                    if (listOpcTags[iinner].VARIABLENAME == (tmpListbmtprefix[iprefix] + key))
                                    {
                                        listOpcTags[iinner].BATCHVARIABLE = key;
                                        listOpcTags[iinner].PVBATCHPATH = tmpdictBatchvars[key];
                                        tmpListid.Add(iinner);
                                        global.log.MetroLog.INSTANCE.DebugWriteLine(listOpcTags[iinner].VARIABLENAME, global.log.MetroLog.LogType.INFO, 1081);
                                    }
                                }
                            }
                        }
                    }
                    AddListids(tmpListid.ToArray(), 1079);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private delegate void dgEnableSaveButton(bool value);
        /// <summary>
        /// Multithread Save button aktivieren
        /// </summary>
        /// <param name="value"></param>
        /// <created>janzen_d,2018-09-22</created>
        private void EnableSaveButton(bool value)
        {
            try
            {
                if (mbtnSave_1040.InvokeRequired)
                    mbtnSave_1040.BeginInvoke(new dgEnableSaveButton(EnableSaveButton), new object[] { value });
                else
                    mbtnSave_1040.Enabled = value;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private delegate void dgAddRow(string[] gridrow);
        /// <summary>
        /// Thread Eine Zeile im DataGrid hinzufügen.
        /// </summary>
        /// <param name="gridrow"></param>
        /// <created>janzen_d,2018-09-22</created>
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
                    for (int i = 7; i < 12; i++)
                    {
                        metroGrid.Rows[metroGrid.Rows.Count - 2].Cells[i].ReadOnly = false; // -2 da ein datagrid immer eine zusatzzeile besitzt.
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

        private delegate void dgAddListids(int[] listids, int headeartextid);
        /// <summary>
        /// Thread Eine Gruppe im DataGrid hinzufügen.
        /// </summary>
        /// <param name="gridrow"></param>
        /// <created>janzen_d,2018-09-23</created>
        private void AddListids(int[] listids, int headeartextid)
        {
            try
            {
                if (metroGrid.InvokeRequired) //Threadprogrammierung um zu verhindern, das ein anderer Prozess gleichzeitig auf das Objekt zugreift.
                {
                    metroGrid.BeginInvoke(new dgAddListids(AddListids), new object[] { listids, headeartextid });
                }
                else
                {
                    for (int i = 0; i < listids.Length; i++)
                    {
                        string[] gridrow = listOpcTags[listids[i]].GetGridRow;
                        metroGrid.Rows.Add(gridrow);
                        for (int inner = 7; inner < 12; inner++)
                        {
                            metroGrid.Rows[metroGrid.Rows.Count - 2].Cells[inner].ReadOnly = false; // -2 da ein datagrid immer eine zusatzzeile besitzt.
                        }
                        metroGrid.Rows[metroGrid.Rows.Count - 2].HeaderCell.Value = global.language.LanguageHandler.INSTANCE.GETOBJWORD(headeartextid)[2].ToString();
                        metroGrid.Rows[metroGrid.Rows.Count - 2].HeaderCell.ToolTipText = global.language.LanguageHandler.INSTANCE.GETOBJWORD(headeartextid)[0].ToString();
                        global.log.MetroLog.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)listids.Length, listOpcTags[listids[i]].VARIABLENAME);
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
                                            if ("Sealing_TMP_Heating.CurrentTemp" == xmlNode.Attributes["name"].Value)
                                            {

                                            }
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
                    string[] paths_pv_equipment = Directory.GetFiles(twizardpath.ToString() + "\\uhlmann\\tc\\pv_equipment");
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

                //
                // pv_equipment analysieren
                //
                if (Directory.Exists(twizardpath.ToString() + "\\uhlmann\\tc\\pv_batch"))
                {

                    string[] paths_pv_equipment = Directory.GetFiles(twizardpath.ToString() + "\\uhlmann\\tc\\pv_batch");
                    foreach (string path in paths_pv_equipment)
                    {
                        string extension = Path.GetExtension(path);
                        if (extension == ".xml" || extension == ".XML")
                        {
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.XmlResolver = null;
                            xmlDocument.Load(path);
                            foreach (XmlNode xmlNode in xmlDocument.SelectNodes("APVS/APV[@name]"))
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
                                                case "name":
                                                    listOpcTags[index].BATCHVARIABLE = xmlAttribute.Value;
                                                    listOpcTags[index].PVBATCHPATH = path;
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

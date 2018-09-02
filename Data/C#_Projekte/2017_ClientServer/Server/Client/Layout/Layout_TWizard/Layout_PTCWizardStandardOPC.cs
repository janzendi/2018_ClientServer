using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Xml;

namespace Client.Layout.Layout_TWizard
{
    public partial class Layout_PTCWizardStandardOPC : UserControl
    {
        private TableLayoutPanel tblPanel;
        private FlowLayoutPanel flowpnl_firstRow;
        private Label lblFolder;
        private Button btnSelectFolder;
        private Button btnSaveSetting;
        private Button btnCreateOPCInterface;
        private DataGridView dataGridView;
        private FolderBrowserDialog folderBrowserDialog;
        private List<TCWizardStandardOPC_FileHandler> list_TCWizardModule;

        public Layout_PTCWizardStandardOPC()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select root TWizard folder";
            folderBrowserDialog.ShowNewFolderButton = false;

            list_TCWizardModule = new List<TCWizardStandardOPC_FileHandler>();

            tblPanel = new TableLayoutPanel();
            tblPanel.Dock = DockStyle.Fill;
            if (Client.Properties.Settings.DEBUGENABLED)
                tblPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            this.Controls.Add(tblPanel);
            Log.LogFile.INSTANCE.DebugWriteLine("Test -> tblPanel.RowCount.ToString(): " + tblPanel.RowCount.ToString() + ", tblPanel.ColumnCount.ToString(): " + tblPanel.ColumnCount.ToString());
            // add row
            tblPanel.RowCount = 2;
            tblPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            tblPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            lblFolder = new Label();
            lblFolder.Anchor = AnchorStyles.Left;
            lblFolder.AutoSize = true;
            lblFolder.Text = "No folder selcted";

            btnSelectFolder = new Button();
            btnSelectFolder.Text = "Open";
            btnSelectFolder.Click += BtnSelectFolder_Click;

            btnSaveSetting = new Button();
            btnSaveSetting.Text = "Save Setup";
            btnSaveSetting.Enabled = false;
            btnSaveSetting.Click += BtnSaveSetting_Click;

            btnCreateOPCInterface = new Button();
            btnCreateOPCInterface.Text = "Create Standard OPC";
            btnCreateOPCInterface.Enabled = false;
            btnCreateOPCInterface.Click += BtnCreateOPCInterface_Click;

            //Add items to first Row
            flowpnl_firstRow = new FlowLayoutPanel();
            tblPanel.Controls.Add(flowpnl_firstRow, 0, 0);
            tblPanel.Controls[0].Dock = DockStyle.Fill;
            flowpnl_firstRow.Controls.Add(btnCreateOPCInterface);
            flowpnl_firstRow.Controls.Add(btnSaveSetting);
            flowpnl_firstRow.Controls.Add(btnSelectFolder);
            flowpnl_firstRow.Controls.Add(lblFolder);

            //Add items to second Row (table)
            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            tblPanel.Controls.Add(dataGridView, 0, 1);
            // Setup datagrid
            //dataGridView.ColumnCount = 11;
            dataGridView.ColumnHeadersVisible = true;
            // Set the column header names.
            dataGridView.Columns.Add("listid", "listid");
            dataGridView.Columns["listid"].ReadOnly = true;
            dataGridView.Columns.Add("modulename", "module name");
            dataGridView.Columns["modulename"].ReadOnly = true;
            dataGridView.Columns.Add("pv_process_path", "pv process path");
            dataGridView.Columns["pv_process_path"].ReadOnly = true;
            dataGridView.Columns.Add("variablename", "variable name");
            dataGridView.Columns["variablename"].ReadOnly = true;
            dataGridView.Columns.Add("pdaCounterType", "pdaCounterType"); // [4]
            dataGridView.Columns["pdaCounterType"].ReadOnly = true;
            dataGridView.Columns.Add("textid", "textid");
            dataGridView.Columns["textid"].ReadOnly = true;
            dataGridView.Columns.Add("cmt", "Kommentar");
            dataGridView.Columns["cmt"].ReadOnly = true;
            dataGridView.Columns.Add("opcDataType", "opcDataType");
            dataGridView.Columns["opcDataType"].ReadOnly = true;
            dataGridView.Columns.Add("opcRwu", "opcRwu");
            dataGridView.Columns["opcRwu"].ReadOnly = true;
            dataGridView.Columns.Add("opcAlias", "opcAlias"); // [9]
            dataGridView.Columns["opcAlias"].ReadOnly = true;
            dataGridView.Columns.Add("opcActive", "opcActive");
            dataGridView.Columns["opcActive"].ReadOnly = true;
            dataGridView.Columns.Add("pv_equipment_path", "pv equipment path");
            dataGridView.Columns["pv_equipment_path"].ReadOnly = true;
            dataGridView.Columns.Add("arraysize", "array size"); // [12]
            dataGridView.Columns["arraysize"].ReadOnly = true;
            //analog values
            dataGridView.Columns.Add("semantic", "semantic"); // [13]
            dataGridView.Columns["semantic"].ReadOnly = true;
            dataGridView.Columns.Add("dcReadPeriod", "dcReadPeriod");
            dataGridView.Columns["dcReadPeriod"].ReadOnly = true;
            dataGridView.Columns.Add("dcLogThreshold", "dcLogThreshold");
            dataGridView.Columns["dcLogThreshold"].ReadOnly = true;
            dataGridView.Columns.Add("dcMaxPersistence", "dcMaxPersistence"); // [16]
            dataGridView.Columns["dcMaxPersistence"].ReadOnly = true;
            dataGridView.Columns.Add("pv_batch_path", "pv_batch_path"); // [17]
            dataGridView.Columns["pv_batch_path"].ReadOnly = true;
            dataGridView.Columns.Add("pv_batch_variablename", "pv_batch_variablename"); // [18]
            dataGridView.Columns["pv_batch_variablename"].ReadOnly = true;
        }

        private void BtnCreateOPCInterface_Click(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {

            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            List<string> activemodules = new List<string>();
            btnSelectFolder.Enabled = false;
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    lblFolder.Text = folderBrowserDialog.SelectedPath;
                    if (Directory.Exists(lblFolder.Text + "\\platform\\fm") && File.Exists(lblFolder.Text + "\\build\\version_1\\process.xml"))
                    {
                        Log.LogFile.INSTANCE.WriteLine("INFO -> TWizard folder detected.");

                        // \\build\\version_1\\process.xml durchsuchen auf aktive Module
                        XmlDocument xmlDocumentProcessXML = new XmlDocument();
                        xmlDocumentProcessXML.XmlResolver = null;
                        xmlDocumentProcessXML.Load(lblFolder.Text + "\\build\\version_1\\process.xml");
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
                        Log.LogFile.INSTANCE.WriteLine("INFO -> Analyze TWizard process.xml \"activemodules.Count\": " + activemodules.Count);
                    }

                    #region plattform fm analyisieren
                    // \\platform\\fm analisieren
                    dataGridView.Rows.Clear();
                    list_TCWizardModule.Clear();
                    StringComparer comparer = StringComparer.Ordinal;
                    //btnSaveSetting.Enabled = true; //TODO
                    //btnCreateOPCInterface.Enabled = true; //TODO
                    DirectoryInfo dcPlattform = new DirectoryInfo(lblFolder.Text + "\\platform\\fm");
                    //Vorbereitung für Ladebalken
                    int directoryCount = dcPlattform.GetDirectories().Length;
                    int i = 0;
                    //Pfad durchsuchen
                    foreach (DirectoryInfo directories in dcPlattform.GetDirectories("*", SearchOption.TopDirectoryOnly)) // \\platform\\fm"
                    {
                        Log.LogFile.INSTANCE.WriteLine("INFO -> Analyze directory: " + directories.FullName);
                        Log.LogFile.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)directoryCount, directories.Name);
                        TCWizardStandardOPC_FileHandler tCWizardStandardOPC_FileHandler = new TCWizardStandardOPC_FileHandler(directories.Name);


                        if (activemodules.Contains(directories.Name))
                        {
                            //analyze equipment
                            if (Directory.Exists(directories.FullName + "\\uhlmann\\tc\\equipment"))
                            {
                                string[] paths_equipment = Directory.GetFiles(directories.FullName + "\\uhlmann\\tc\\equipment");
                                foreach (string item in paths_equipment)
                                {
                                    tCWizardStandardOPC_FileHandler.AddEquipment(item);
                                }
                            }

                            //analyze pv_process
                            if (Directory.Exists(directories.FullName + "\\uhlmann\\tc\\pv_process"))
                            {
                                string[] paths_pv_process = Directory.GetFiles(directories.FullName + "\\uhlmann\\tc\\pv_process");
                                foreach (string item in paths_pv_process)
                                {
                                    tCWizardStandardOPC_FileHandler.AddPvProcess(item);
                                }
                            }

                            //analyze pv_equipment
                            if (Directory.Exists(directories.FullName + "\\uhlmann\\tc\\pv_equipment"))
                            {
                                string[] paths_pv_equipment = Directory.GetFiles(directories.FullName + "\\uhlmann\\tc\\pv_equipment");
                                foreach (string item in paths_pv_equipment)
                                {
                                    tCWizardStandardOPC_FileHandler.AddPvEquipment(item);
                                }
                            }

                            //analyze pv_batch
                            if (Directory.Exists(directories.FullName + "\\uhlmann\\tc\\pv_batch"))
                            {
                                string[] paths_pv_batch = Directory.GetFiles(directories.FullName + "\\uhlmann\\tc\\pv_batch");
                                foreach (string item in paths_pv_batch)
                                {
                                    tCWizardStandardOPC_FileHandler.AddPvBatch(item);
                                }
                            }

                            list_TCWizardModule.Add(tCWizardStandardOPC_FileHandler);
                        }
                        i++;
                    }
                    #endregion

                    #region PDA Variablen der View hinzufügen
                    //Vorbereitung für Ladebalken 
                    int listCount = list_TCWizardModule.Count;
                    AddRow(new object[] {"--","Zähler" }); // Header
                    for (i = 0; i < list_TCWizardModule.Count; i++)
                    {
                        // Progressbar
                        Log.LogFile.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)listCount, list_TCWizardModule[i].MODULENAME);

                        List<object[]> list = new List<object[]>();
                        list = list_TCWizardModule[i].GetListObjArrayOfPDAVariables(i);
                        foreach (object[] item in list)
                            AddRow(item);
                    }
                    #endregion

                    #region PDA Analog-Variablen der View hinzufügen
                    AddRow(new object[] { "--", "Analogwerte" }); // Header
                    for (i = 0; i < listCount; i++)
                    {
                        // Progressbar
                        Log.LogFile.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)listCount, list_TCWizardModule[i].MODULENAME);
                        // Temp Liste erstellen
                        List<object[]> list = new List<object[]>();
                        list = list_TCWizardModule[i].GetListObjArrayOfAnalogVariables(i);
                        foreach (object[] item in list)
                            AddRow(item);
                    }
                    #endregion
                    
                    #region Auftrags (batch) Variablen hinzufügen
                    AddRow(new object[] { "--", "Batch OPC Variablen" }); // Header
                    for (i = 0; i < listCount; i++)
                    {
                        // Progressbar
                        Log.LogFile.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)listCount, list_TCWizardModule[i].MODULENAME);
                        // Temp Liste erstellen
                        List<object[]> list = new List<object[]>();
                        list = list_TCWizardModule[i].GetListObjArrayOfBatchOPCVariables(i);
                        foreach (object[] item in list)
                            AddRow(item);
                    }
                    #endregion

                    #region Standardvariablen hinzufügen
                    AddRow(new object[] { "--", "Standard OPC Variablen" }); // Header
                    #endregion
                    
                    #region Restliche OPC Variablen hinzufügen
                    //Create Active list.
                    List<string> list_activeVariables = new List<string>();
                    foreach (DataGridViewRow item in dataGridView.Rows)
                    {
                        if (item.Cells["opcActive"].Value != null)
                            list_activeVariables.Add(item.Cells["variablename"].Value.ToString());
                    }
                    // End Create Active list.
                    AddRow(new object[] { "--", "Restliche OPC Variablen" }); // Header
                    for (i = 0; i < listCount; i++)
                    {
                        // Progressbar
                        Log.LogFile.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)listCount, list_TCWizardModule[i].MODULENAME);
                        // Temp Liste erstellen
                        List<object[]> list = new List<object[]>();
                        list = list_TCWizardModule[i].GetListObjArrayOfRestOPCVariables(i, list_activeVariables);
                        foreach (object[] item in list)
                            AddRow(item);
                    }
                    #endregion

                    btnSaveSetting.Enabled = true;
                }
                else
                {
                    Log.LogFile.INSTANCE.WriteLine("ERROR -> No TWizard folder found.");
                }

            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            btnSelectFolder.Enabled = true;
        }
        

        private void AddRow(object[] obj)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                if (obj != null)
                {
                    dataGridView.Rows.Add(obj);
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        private void BtnSaveSetting_Click(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                for (int i = 0; i < list_TCWizardModule.Count; i++)
                {
                    // Progressbar
                    Log.LogFile.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)list_TCWizardModule.Count, list_TCWizardModule[i].MODULENAME);
                    list_TCWizardModule[i].SaveConfiguration();
                }
                btnSaveSetting.Enabled = false;
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }
    }
}

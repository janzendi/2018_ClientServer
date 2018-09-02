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
    public partial class Layout_TCWizardDomain : UserControl
    {
        private TableLayoutPanel tblPanel;
        private FlowLayoutPanel flowpnl_firstRow;
        private Label lblFolder;
        private Button btnSelectFolder;
        private Button btnSaveSetting;
        private DataGridView dataGridView;
        private List<XmlDocument> listXmlEquipment;

        public Layout_TCWizardDomain()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            folderBrowserDialog.Description = "Select root TWizard folder";
            folderBrowserDialog.ShowNewFolderButton = false;

            tblPanel = new TableLayoutPanel();
            tblPanel.Dock = DockStyle.Fill;
            if (Client.Properties.Settings.DEBUGENABLED)
                tblPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            this.Controls.Add(tblPanel);
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

            //Add items to first Row
            flowpnl_firstRow = new FlowLayoutPanel();
            tblPanel.Controls.Add(flowpnl_firstRow, 0, 0);
            tblPanel.Controls[0].Dock = DockStyle.Fill;
            flowpnl_firstRow.Controls.Add(btnSaveSetting);
            flowpnl_firstRow.Controls.Add(btnSelectFolder);
            flowpnl_firstRow.Controls.Add(lblFolder);

            //Add items to second Row (table)
            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            tblPanel.Controls.Add(dataGridView, 0, 1);
            // Setup datagrid
            dataGridView.ColumnCount = 11;
            dataGridView.ColumnHeadersVisible = true;
            //dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically; //TODO Falls über eingabefeld geändert wird.
            // Set the column header names.
            dataGridView.Columns[0].Name = "Module ID";
            dataGridView.Columns[0].Width = 35;
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns[1].Name = "Full directory";
            dataGridView.Columns[1].ReadOnly = true;
            dataGridView.Columns[2].Name = "Modulename";
            dataGridView.Columns[2].Width = 140;
            dataGridView.Columns[2].ReadOnly = true;
            dataGridView.Columns[3].Name = "Equipment file";
            dataGridView.Columns[3].ReadOnly = true;
            dataGridView.Columns[4].Name = "List equipment id";
            dataGridView.Columns[4].Width = 35;
            dataGridView.Columns[4].ReadOnly = true;
            dataGridView.Columns[5].Name = "Group prefix";
            dataGridView.Columns[5].Width = 160;
            dataGridView.Columns[5].ReadOnly = false;
            dataGridView.Columns[6].Name = "Level2";
            dataGridView.Columns[6].ReadOnly = true;
            dataGridView.Columns[7].Name = "Level3";
            dataGridView.Columns[7].ReadOnly = true;
            dataGridView.Columns[8].Name = "Level4";
            dataGridView.Columns[8].ReadOnly = true;
            dataGridView.Columns[9].Name = "Level11";
            dataGridView.Columns[9].ReadOnly = true;
            dataGridView.Columns[10].Name = "Level15";
            dataGridView.Columns[10].ReadOnly = true;

            //Setup objects
            listXmlEquipment = new List<XmlDocument>();
        }

        private void BtnSaveSetting_Click(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                foreach (DataGridViewRow dataRow in dataGridView.Rows)
                {
                    if (dataRow.Cells["List equipment id"].Value == null || dataRow.Cells["List equipment id"].Value.ToString() == String.Empty)
                        continue;
                    else
                    {
                        listXmlEquipment[Convert.ToInt32(dataRow.Cells["List equipment id"].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc").Attributes["mainAppPrefix"].Value = dataRow.Cells["Group prefix"].Value.ToString();
                        if (dataRow.Cells["Level2"].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells["List equipment id"].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level2").Attributes["name"].Value = dataRow.Cells["Level2"].Value.ToString();
                        if (dataRow.Cells["Level3"].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells["List equipment id"].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level3").Attributes["name"].Value = dataRow.Cells["Level3"].Value.ToString();
                        if (dataRow.Cells["Level4"].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells["List equipment id"].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level4").Attributes["name"].Value = dataRow.Cells["Level4"].Value.ToString();
                        if (dataRow.Cells["Level11"].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells["List equipment id"].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level11").Attributes["name"].Value = dataRow.Cells["Level11"].Value.ToString();
                        if (dataRow.Cells["Level15"].Value != null)
                            listXmlEquipment[Convert.ToInt32(dataRow.Cells["List equipment id"].Value)].SelectSingleNode("EQUIPMENT/ACC_CONF/acc/groups/Level15").Attributes["name"].Value = dataRow.Cells["Level15"].Value.ToString();
                        listXmlEquipment[Convert.ToInt32(dataRow.Cells["List equipment id"].Value)].Save(dataRow.Cells["Full directory"].Value.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    lblFolder.Text = folderBrowserDialog.SelectedPath;
                    if (Directory.Exists(lblFolder.Text + "\\platform\\fm") && File.Exists(lblFolder.Text + "\\build\\version_1\\process.xml"))
                    {
                        Log.LogFile.INSTANCE.WriteLine("INFO -> TWizard folder detected.");
                        List<string> activemodules = new List<string>();

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

                        // Analyze "\\platform\\fm"
                        dataGridView.Rows.Clear();
                        btnSaveSetting.Enabled = true;
                        DirectoryInfo dcPlattform = new DirectoryInfo(lblFolder.Text + "\\platform\\fm");
                        int directoryCount = dcPlattform.GetDirectories().Length;
                        int i = 0;
                        foreach (DirectoryInfo directories in dcPlattform.GetDirectories())
                        {
                            Log.LogFile.INSTANCE.WriteLine("INFO -> Analyze directory: " + directories.FullName);
                            Log.LogFile.INSTANCE.ProgressBar((decimal)(i + 1) / (decimal)directoryCount, directories.Name);

                            if (activemodules.Contains(directories.Name))
                            {
                                if (Directory.Exists(directories.FullName + "\\uhlmann\\tc\\equipment"))
                                {
                                    string[] files = Directory.GetFiles(directories.FullName + "\\uhlmann\\tc\\equipment");
                                    foreach (string path in files)
                                    {
                                        string extension = Path.GetExtension(path);
                                        if (extension == ".xml" || extension == ".XML")
                                        {
                                            Log.LogFile.INSTANCE.DebugWriteLine("INFO -> Analyze TWizard equipment.xml file: " + path);
                                            XmlDocument xmlDocument = GetXmlDocument(path);
                                            if (xmlDocument != null)
                                            {
                                                foreach (XmlNode xmlNode1 in xmlDocument.ChildNodes)
                                                {
                                                    if (xmlNode1.Name == "EQUIPMENT")
                                                    {
                                                        foreach (XmlNode xmlNode2 in xmlNode1.ChildNodes)
                                                        {
                                                            if (xmlNode2.Name == "ACC_CONF")
                                                            {
                                                                foreach (XmlNode xmlNode3 in xmlNode2.ChildNodes)
                                                                {
                                                                    string tempGroupPrefix = String.Empty;
                                                                    string name = String.Empty;
                                                                    if (xmlNode3.Name == "acc")
                                                                    {
                                                                        Log.LogFile.INSTANCE.DebugWriteLine("INFO -> Analyze TWizard equipment.xml file: foreach (XmlNode xmlNode in xmlDocument.ChildNodes)" + xmlNode2.Name);
                                                                        foreach (XmlAttribute xmlAttribute in xmlNode3.Attributes)
                                                                        {
                                                                            if (xmlAttribute.Name == "mainAppPrefix")
                                                                                tempGroupPrefix = xmlAttribute.Value;

                                                                        }
                                                                        listXmlEquipment.Add(xmlDocument);
                                                                        AddRow(i, path, directories.Name, Path.GetFileName(path), listXmlEquipment.Count - 1, tempGroupPrefix);
                                                                        //read groups
                                                                        foreach (XmlNode xmlNode4 in xmlNode3.ChildNodes)
                                                                        {
                                                                            if (xmlNode4.Name == "groups")
                                                                            {
                                                                                foreach (XmlNode xmlNode5 in xmlNode4.ChildNodes)
                                                                                {
                                                                                    switch (xmlNode5.Name)
                                                                                    {
                                                                                        case "Level2":
                                                                                            name = GetAttribute(xmlNode5, "name");
                                                                                            if (name != null || name != String.Empty)
                                                                                                DataGridViewEditLastRow("Level2", name);
                                                                                            break;
                                                                                        case "Level3":
                                                                                            name = GetAttribute(xmlNode5, "name");
                                                                                            if (name != null || name != String.Empty)
                                                                                                DataGridViewEditLastRow("Level3", name);
                                                                                            break;
                                                                                        case "Level4":
                                                                                            name = GetAttribute(xmlNode5, "name");
                                                                                            if (name != null || name != String.Empty)
                                                                                                DataGridViewEditLastRow("Level4", name);
                                                                                            break;
                                                                                        case "Level11":
                                                                                            name = GetAttribute(xmlNode5, "name");
                                                                                            if (name != null || name != String.Empty)
                                                                                                DataGridViewEditLastRow("Level11", name);
                                                                                            break;
                                                                                        case "Level15":
                                                                                            name = GetAttribute(xmlNode5, "name");
                                                                                            if (name != null || name != String.Empty)
                                                                                                DataGridViewEditLastRow("Level15", name);
                                                                                            break;
                                                                                        default:
                                                                                            break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                            else
                                Log.LogFile.INSTANCE.WriteLine("INFO -> Analyze directory (module is not active): " + directories.FullName);
                            i++;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        private string GetAttribute(XmlNode xmlNode, string AttributeName)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                foreach (XmlAttribute item in xmlNode.Attributes)
                {
                    if (item.Name == AttributeName)
                        return item.Value;
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return String.Empty;
        }

        private void AddRow(int id, string fullPath, string modulname, string filename, int listId, string tempGroupPrefix)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                object[] temp = new object[] { id.ToString(), fullPath, modulname, filename, listId.ToString(), tempGroupPrefix };
                dataGridView.Rows.Add(temp);
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        private void DataGridViewEditLastRow(string coloumn, string value)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                if (coloumn == "Level2" || coloumn == "Level3" || coloumn == "Level4" || coloumn == "Level11" || coloumn == "Level15")
                {
                    dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[coloumn].Value = value;
                    dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[coloumn].ReadOnly = false;
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        private XmlDocument GetXmlDocument(string path)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.XmlResolver = null;
                xmldoc.Load(path);
                Log.LogFile.INSTANCE.DebugWriteLine("TEST -> xmldoc.DocumentElement.Name" + xmldoc.DocumentElement.Name);
                return xmldoc;
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            return null;
        }

        private string MakeRelative(string filePath, string referencePath)
        {
            var fileUri = new Uri(filePath);
            var referenceUri = new Uri(referencePath);
            return referenceUri.MakeRelativeUri(fileUri).ToString();
        }
    }
}

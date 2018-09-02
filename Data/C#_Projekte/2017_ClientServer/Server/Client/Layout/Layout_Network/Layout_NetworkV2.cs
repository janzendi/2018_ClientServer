using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Config.XML;

namespace Client.Layout.Layout_Network
{
    public partial class Layout_NetworkV2 : UserControl
    {
        private TableLayoutPanel tblPanel;
        private FlowLayoutPanel flowpnl_firstRow;
        private Button btnSaveSetting;

        private DataGridView dataGridView;
        private DataGridViewComboBoxColumn cmbLetterSource;
        private DataGridViewButtonColumn btnConnect;

        private object[] datasource;

        public Layout_NetworkV2()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            // Objects
            btnSaveSetting = new Button();
            btnSaveSetting.Text = "Save Setup";
            btnSaveSetting.Enabled = false;
            btnSaveSetting.Click += BtnSaveSetting_Click;

            // Tablelayout
            tblPanel = new TableLayoutPanel();
            tblPanel.Dock = DockStyle.Fill;
            if (Client.Properties.Settings.DEBUGENABLED)
                tblPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            this.Controls.Add(tblPanel);
            // add row
            tblPanel.RowCount = 2;
            tblPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            tblPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Flowlayout first row in Tablelayout
            flowpnl_firstRow = new FlowLayoutPanel();
            tblPanel.Controls.Add(flowpnl_firstRow, 0, 0);
            tblPanel.Controls[0].Dock = DockStyle.Fill;
            //add control to flow layout
            flowpnl_firstRow.Controls.Add(btnSaveSetting);

            //Add items to second Row (table)
            dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            tblPanel.Controls.Add(dataGridView, 0, 1);
            // Setup datagrid
            //dataGridView.ColumnCount = 5;
            dataGridView.ColumnHeadersVisible = true;
            dataGridView.CellClick += DataGridView_CellClick;
            dataGridView.DefaultValuesNeeded += DataGridView_DefaultValuesNeeded;
            
            // Set the column header names.
            dataGridView.Columns.Add("volumename", "Volume name");
            //Combobox
            cmbLetterSource = new DataGridViewComboBoxColumn();
            cmbLetterSource.Name = "letter";
            cmbLetterSource.FlatStyle = FlatStyle.Flat;
            cmbLetterSource.DataPropertyName = "letter"; 
            datasource = Client.Network.InterfaceNetUse.INSTANCE.DRIVELETTERS;
            cmbLetterSource.DataSource = datasource;
            dataGridView.Columns.Add(cmbLetterSource);
            dataGridView.Columns[1].Name = "Drive letter";
            dataGridView.Columns[1].Width = 60;
            // Normal Text
            dataGridView.Columns.Add("user", "User name");
            dataGridView.Columns.Add("password", "Password");
            dataGridView.Columns.Add("path", "Network path");
            // Button Connect
            btnConnect = new DataGridViewButtonColumn();
            //btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.HeaderText = "Connect";
            btnConnect.Text = "Connect";
            dataGridView.Columns.Add(btnConnect);
                        
        }

        private void StartUpAddRow()
        {
            try
            {
                List<XMLNetworkConnection> listNetwork = Config.XML.SaveAndLoadConfig.INSTANCE.GetXmlNetworkList();
                if (listNetwork.Count > 0)
                {
                    foreach (XMLNetworkConnection item in listNetwork)
                    {
                        
                    }
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        private void DataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                e.Row.Cells["user"].Value = "uhlmann";
                e.Row.Cells["password"].Value = "winlauph";
                e.Row.Cells[5].Value = "Connect";
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        /// <summary>
        /// Event um Netzlaufwerk zu verbinden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
                try
                {
                    if (dataGridView.Rows.Count > 1)
                    {
                        if (dataGridView.Rows[e.RowIndex].ReadOnly) // true = verbunden; Laufwirk wird getrennt
                        {
                            switch (Client.Network.InterfaceNetUse.INSTANCE.DisconnectDrive(dataGridView.Rows[e.RowIndex].Cells["letter"].Value.ToString(), dataGridView.Rows[e.RowIndex].Cells["path"].Value.ToString()))
                            {
                                case 0:
                                    dataGridView.Rows[e.RowIndex].Cells[5].Value = "Disconnect";
                                    dataGridView.Rows[e.RowIndex].ReadOnly = !dataGridView.Rows[e.RowIndex].ReadOnly;
                                    break;
                                case 1000:
                                    break;
                                case 1001:
                                    break;
                                case 1002:
                                    break;
                                default:
                                    break;
                            }
                        }
                        else // false = nicht verbunden; Laufwirk wird verbunden
                        {
                            switch (Client.Network.InterfaceNetUse.INSTANCE.ConnectDrive(dataGridView.Rows[e.RowIndex].Cells["volumename"].Value.ToString(), dataGridView.Rows[e.RowIndex].Cells["letter"].Value.ToString(), dataGridView.Rows[e.RowIndex].Cells["user"].Value.ToString(), dataGridView.Rows[e.RowIndex].Cells["password"].Value.ToString(), dataGridView.Rows[e.RowIndex].Cells["path"].Value.ToString()))
                            {
                                case 0:
                                    dataGridView.Rows[e.RowIndex].Cells[5].Value = "Disconnect";
                                    dataGridView.Rows[e.RowIndex].ReadOnly = !dataGridView.Rows[e.RowIndex].ReadOnly;
                                    break;
                                case 1000:
                                    break;
                                case 1001:
                                    break;
                                case 1002:
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
                }
            }
        }

        private void BtnSaveSetting_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

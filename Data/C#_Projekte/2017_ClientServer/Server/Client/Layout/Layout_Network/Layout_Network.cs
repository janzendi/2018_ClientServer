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
using Client.Object;

namespace Client.Layout.Layout_Network
{
    public partial class Layout_Network : UserControl
    {
        private List<RowFlowLayouForNetworkTableLayout> listRows;
        private Button btnAddRow;
        private Button btnDelRow;
        private RowStyle rowStyle;
        public Layout_Network() :base()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            
            //private objects
            rowStyle = new RowStyle(SizeType.Absolute, 40);
            listRows = new List<RowFlowLayouForNetworkTableLayout>();

            //Erste Zeile mit add & delete button
            btnAddRow = new Button();
            btnAddRow.Text = "Add row";
            btnAddRow.Click += BtnAddRow_Click;
            btnDelRow = new Button();
            btnDelRow.Text = "Delete last row";
            btnDelRow.Click += BtnDelRow_Click;
            btnDelRow.AutoSize = true;
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Controls.Add(btnAddRow);
            flowLayoutPanel.Controls.Add(btnDelRow);
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;

            tblLayoutPanel.Controls.Add(flowLayoutPanel, 0, 0);
            tblLayoutPanel.Dock = DockStyle.Fill;
            tblLayoutPanel.RowStyles[0] = new RowStyle(rowStyle.SizeType,rowStyle.Height);
            
            List<XMLNetworkConnection> listNetwork = Config.XML.SaveAndLoadConfig.INSTANCE.GetXmlNetworkList();
            if (listNetwork.Count>0)
            {
                foreach (XMLNetworkConnection item in listNetwork)
                {
                    AddRow(item);
                }
            }
        }
        

        private void BtnDelRow_Click(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                if (tblLayoutPanel.RowCount > 1)
                {
                    var control = tblLayoutPanel.GetControlFromPosition(0, tblLayoutPanel.RowCount - 1);
                    tblLayoutPanel.Controls.Remove(control);
                    tblLayoutPanel.RowStyles.RemoveAt(tblLayoutPanel.RowCount - 1);
                    listRows.RemoveAt(listRows.Count - 1);
                    tblLayoutPanel.RowCount--;
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            AddRow(null);
        }
        private void AddRow(XMLNetworkConnection network)
        {
            try
            {
                Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
                if (network == null)
                    listRows.Add(new RowFlowLayouForNetworkTableLayout());
                else
                    listRows.Add(new RowFlowLayouForNetworkTableLayout(network.DESCRIPTION, network.LETTER, network.USER, network.PASSWORD, network.NETWORKPATH));

                tblLayoutPanel.RowCount++;
                if (tblLayoutPanel.RowCount > 2)
                    tblLayoutPanel.RowStyles[tblLayoutPanel.RowCount - 2] = new RowStyle(rowStyle.SizeType, rowStyle.Height);

                if (tblLayoutPanel.RowCount> tblLayoutPanel.RowStyles.Count)
                    tblLayoutPanel.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
                else
                    tblLayoutPanel.RowStyles[tblLayoutPanel.RowCount-1] = new RowStyle(rowStyle.SizeType, rowStyle.Height);

                tblLayoutPanel.Controls.Add(listRows[listRows.Count - 1], 0, listRows.Count);

            }
            catch (Exception e)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
            }
        }
    }
}

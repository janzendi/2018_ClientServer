using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Client.Object;
using Client.Network;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

namespace Client.Layout.Layout_Network
{
    class RowFlowLayouForNetworkTableLayout : FlowLayoutPanel
    {
        private GroupLblTxt grpVolumename;
        private GroupLblTxt grpDriveletter;
        private GroupLblTxt grpNetworkPath;
        private GroupLblTxt grpUsername;
        private GroupLblTxt grpPassword;

        private Button btnConnect;
        private bool sharenotconnected;
        private Button btnDeleteRow;

        private Regex regexIP = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
        private const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

        public RowFlowLayouForNetworkTableLayout() : base()
        {
            this.init("", "--", "uhlmann", "winlauph", "\\\\");
        }

        //TODO
        public void RowFlowLayouForNetworkTableLayout_HandleDestroyed()
        {
            if (!sharenotconnected)
            {
                try
                {
                    //InterfaceNetUse.INSTANCE.UnMapDrive(this.grpDriveletter.GetTEXT, true, false, this.grpNetworkPath.GetTEXT);
                }
                catch (Exception)
                {
                    throw new NotImplementedException();
                }
            }
        }

        public RowFlowLayouForNetworkTableLayout(string description, string driveletter, string username, string password, string networkpath) : base()
        {
            this.init(description, driveletter, username, password, networkpath);
        }

        private void init(string volumeName, string letter, string username, string password, string networkpath)
        {
            this.Dock = DockStyle.Fill;
            grpVolumename = new GroupLblTxtVolumeName("Volumename:", volumeName, null, true, 90);
            this.Controls.Add(grpVolumename);

            grpDriveletter = new GroupLblTxtDriveLetter("Driveletter:", letter, Client.Network.InterfaceNetUse.INSTANCE.DRIVELETTERS);
            this.Controls.Add(grpDriveletter);


            grpNetworkPath = new GroupLblTxtNetworkPath("Network path:", networkpath);
            this.Controls.Add(grpNetworkPath);

            grpUsername = new GroupLblTxtUsername("Login username:", username);
            this.Controls.Add(grpUsername);

            grpPassword = new GroupLblTxtPassword("Password:", password);
            this.Controls.Add(grpPassword);

            btnConnect = new Button();
            btnConnect.Anchor = AnchorStyles.Left;
            btnConnect.Text = "Connect";
            btnConnect.Click += BtnConnect_Click;
            this.Controls.Add(btnConnect);

            btnDeleteRow = new Button();
            btnDeleteRow.Enabled = false;
            btnDeleteRow.Anchor = AnchorStyles.Left;
            btnDeleteRow.Text = "Delete Row";
            this.Controls.Add(btnDeleteRow);
            
            disAndEnableControls(true);
        }

        private void disAndEnableControls(bool enable)
        {
            sharenotconnected = enable;
            btnDeleteRow.Enabled = false; //TODO
            grpVolumename.Enabled = enable;
            grpDriveletter.Enabled = enable;
            grpNetworkPath.Enabled = enable;
            grpUsername.Enabled = enable;
            grpPassword.Enabled = enable;
            if (enable)
                btnConnect.Text = "Connect";
            else
                btnConnect.Text = "Disconnect";
        }
        private void BtnConnect_Click(object sender=null, EventArgs e=null)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            btnConnect.Enabled = false;
            try
            {
                if (sharenotconnected) // try to connect
                {
                    int i;
                    if (this.grpVolumename.GetTEXT.Length > 3)
                        i = InterfaceNetUse.INSTANCE.MapDrive(this.grpDriveletter.GetTEXT.Replace("\\", String.Empty), this.grpUsername.GetTEXT, this.grpPassword.GetTEXT, this.grpNetworkPath.GetTEXT, false, false, false, false,this.grpVolumename.GetTEXT);
                    else
                        i = InterfaceNetUse.INSTANCE.MapDrive(this.grpDriveletter.GetTEXT.Replace("\\", String.Empty), this.grpUsername.GetTEXT, this.grpPassword.GetTEXT, this.grpNetworkPath.GetTEXT, false, false, false, false);

                    if (i == 0 || i == 85)
                    {
                        Log.LogFile.INSTANCE.DebugWriteLine("Result -> " + System.Reflection.MethodBase.GetCurrentMethod() + ", InterfaceNetUse.INSTANCE.MapDrive() result = ok");
                        disAndEnableControls(false);
                        //RegexEntry
                        if (!(regexIP.Match(this.grpNetworkPath.GetTEXT).Success && InterfaceNetUse.INSTANCE.SendPing(regexIP.Match(this.grpNetworkPath.GetTEXT).ToString())))
                            Log.LogFile.INSTANCE.DebugWriteLine("Result -> " + System.Reflection.MethodBase.GetCurrentMethod() + ", send ping: " + this.grpNetworkPath.GetTEXT + " not successfull");
                        else
                            Log.LogFile.INSTANCE.DebugWriteLine("Result -> " + System.Reflection.MethodBase.GetCurrentMethod() + ", send ping: " + this.grpNetworkPath.GetTEXT + " successfull");

                    }
                    else
                    {
                        Log.LogFile.INSTANCE.DebugWriteLine("Result -> " + System.Reflection.MethodBase.GetCurrentMethod() + ", InterfaceNetUse.INSTANCE.MapDrive() result = " + new System.ComponentModel.Win32Exception(i));    
                    }
                }
                else // try to disconnect
                {
                    InterfaceNetUse.INSTANCE.UnMapDrive(this.grpDriveletter.GetTEXT, true, false, this.grpNetworkPath.GetTEXT);
                    disAndEnableControls(true);
                }            
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
            btnConnect.Enabled = true;
        }
    }
}

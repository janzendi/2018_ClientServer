using SimpleTCP;
using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Client.Layout.Layout_Network;
using Client.Layout.Layout_TWizard;
using System.Drawing;

//main
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
using System.Collections;

namespace Client
{
    public partial class ClientForm : Form
    {
        //client.WriteLineAndGetReply("Send from Client", TimeSpan.FromSeconds(3));

        private Layout_Network layout_Network;
        private Layout_NetworkV2 layout_NetworkV2;
        private Layout_TCWizardDomain layout_TCWizardDomain;
        private Layout_PTCWizardStandardOPC layout_tabPTCWizardStandardOPC;
        public ClientForm()
        {
            InitializeComponent();

            //init Singleton Pattern classes
            Log.LogFile.INSTANCE.SetConsole(richTextBox_Info,toolStripStatusLabel2, toolStripProgressBar1);
            Client.Network.InterfaceNetUse.INSTANCE.ToString();
            

            //Layout
            layout_Network = new Layout_Network();
            tabPNetwork.Controls.Add(layout_Network);

            layout_NetworkV2 = new Layout_NetworkV2();
            tabPNetworkV2.Controls.Add(layout_NetworkV2);

            layout_TCWizardDomain = new Layout_TCWizardDomain();
            tabPTCWizardDomain.Controls.Add(layout_TCWizardDomain);

            layout_tabPTCWizardStandardOPC = new Layout_PTCWizardStandardOPC();
            tabPTCWizardStandardOPC.Controls.Add(layout_tabPTCWizardStandardOPC);

            //Menu
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            try
            {
                saveToolStripMenuItem.Image = Image.FromFile("icons\\if_safe_64608.ico");
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());

            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {

            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
       {
            if (false) //TODO if (!IsRunAsAdmin()) 
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().CodeBase;

                foreach (string arg in args)
                {
                    proc.Arguments += String.Format("\"{0}\" ", arg);
                }

                proc.Verb = "runas";

                try
                {
                    Process.Start(proc);
                }
                catch
                {
                    MessageBox.Show("This application requires elevated credentials in order to operate correctly!");
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ClientForm());
            }
        }
        static bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

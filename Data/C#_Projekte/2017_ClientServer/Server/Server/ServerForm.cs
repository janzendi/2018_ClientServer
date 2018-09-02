using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;
using SimpleTCP.Server;


namespace Server
{
    public partial class ServerForm : Form
    {
        private SimpleTcpServer server;
        //private System.Net.IPAddress ip = new System.Net.IPAddress(long.Parse("127.0.0.1"));

        public ServerForm()
        {
            InitializeComponent();
            Log.LogFile.INSTANCE.SetListBox(listBox_Info);

            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

            
        }
        ~ServerForm()
        {
            if (server.IsStarted)
                server.Stop();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Log.LogFile.INSTANCE.WriteLine(server.ToString());
            
            server.Start(8910);
            Log.LogFile.INSTANCE.WriteLine(server.ToString());
            Log.LogFile.INSTANCE.WriteLine(server.IsStarted.ToString());
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            Log.LogFile.INSTANCE.WriteLine(e.MessageString);
            e.ReplyLine(string.Format("You said: {0}", e.MessageString));
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm());
        }
    }
}

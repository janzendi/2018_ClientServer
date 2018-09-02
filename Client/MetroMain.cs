using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Fonts;
using System.Threading;

namespace Client
{

    public partial class MetroMain : MetroForm
    {
        public MetroMain()
        {
            InitializeComponent();
            global.log.MetroLog.INSTANCE.SetConsole(richTextBox_Info, statusprgtxt, statusprgbar);
        }
        
    }

    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MetroMain());
        }
    }
}

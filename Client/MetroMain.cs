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
        /// <summary>
        /// Konstruktor der MetroMain Klasse.
        /// </summary>
        /// /// <created>janzen_d,2018-09-03</created>
        public MetroMain()
        {
            // Thread start for subroutine
            //Thread threadLanguage = new Thread(new ThreadStart(global.language.LanguageHandler.INSTANCE.ReadXml(config.ConfigReadWriter.LANGUAGEPATH)));
            global.language.LanguageHandler languageHandler = global.language.LanguageHandler.INSTANCE;

            Thread threadLanguage = new Thread(new ThreadStart(languageHandler.ReadXml));
            //init
            InitializeComponent();
            global.log.MetroLog.INSTANCE.SetConsole(richTextBox_Info, statusprgtxt, statusprgbar);
        }

        ~MetroMain()
        {

        }
    }

    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// /// <created>janzen_d,2018-09-03</created>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MetroMain());
        }
    }
}

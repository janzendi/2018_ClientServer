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
        private static string strActualLanguage;

        #region Konstruktoren
        /// <summary>
        /// Konstruktor der MetroMain Klasse.
        /// </summary>
        /// <created>janzen_d,2018-09-03</created>
        public MetroMain()
        {
            
            //init
            InitializeComponent();
            global.log.MetroLog.INSTANCE.SetConsole(richTextBox_Info, statusprgtxt, statusprgbar);
            // Thread start for subroutine
            Thread threadLanguage = new Thread(new ThreadStart(MetroMain.ReadXml));
            threadLanguage.Start();
            global.log.MetroLog.INSTANCE.WriteLine("Get Language data from file.");

            //TODO

            // Sprachen aufbauen
            while (global.language.LanguageHandler.XMLREADISFINISH)
            {
                // warten bis Lesevorgang abgeschlossen ist.
            }
            global.log.MetroLog.INSTANCE.WriteLine("Get Language data from file finalized.");
            foreach (string strlanguage in global.language.LanguageHandler.INSTANCE.LISTOFLANGUAGE)
            {
                languageToolStripMenuItem.DropDownItems.Add(strlanguage);

            }
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Tag != null)
                {
                    if (System.Int32.TryParse(this.Controls[i].Tag.ToString(), out int textid))
                    {

                    }
                }
            }
        }

        ~MetroMain()
        {

        }
        #endregion

        #region threads
        private static void ReadXml()
        {
            global.language.LanguageHandler.INSTANCE.ReadXml(config.ConfigReadWriter.LANGUAGEPATH);
        }
        #endregion

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

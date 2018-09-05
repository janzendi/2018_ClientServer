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


        #region Konstruktoren
        /// <summary>
        /// Konstruktor der MetroMain Klasse.
        /// </summary>
        /// <created>janzen_d,2018-09-03</created>
        public MetroMain()
        {
            InitializeComponent();
            this.CustomInitializeComponent(); // deklariert im MetroMain.Designer.cs

        }

        ~MetroMain() { }
        #endregion



        #region clickEvents
        /// <summary>
        /// Klick Event um Sprache umzustellen.
        /// </summary>
        /// <created>janzen_d,2018-09-04</created>
        private void Click_ChangeLanguage(object sender, EventArgs e)
        {
            try
            {
                global.log.MetroLog.INSTANCE.DebugWriteLine(sender.ToString()); // TODO delete
                strActualLanguage = sender.ToString();
                //siehe Designer
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Klick Event um Status zu speichern.
        /// </summary>
        /// <created>janzen_d,2018-09-04</created>
        private void ToolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
            }
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

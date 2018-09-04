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
   
        }

        ~MetroMain() { }
        #endregion

        

        #region clickEvents
        private void Click_ChangeLanguage(object sender, EventArgs e)
        {
            try
            {
                global.log.MetroLog.INSTANCE.DebugWriteLine(sender.ToString()); // TODO delete
                strActualLanguage = sender.ToString();
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
            catch (Exception)
            {
            }
        }

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

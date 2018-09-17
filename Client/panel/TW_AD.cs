using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Fonts;
using System.Xml;

namespace Client.panel
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TW_AD : MetroUserControl
    {

        private System.Collections.Generic.List<XmlDocument> listXmlEquipment;

        public TW_AD(MetroFramework.Components.MetroStyleManager metroStyleManager)
        {
            InitializeComponent();
            listXmlEquipment = new List<XmlDocument>();
            this.CustomInitializeComponent(metroStyleManager); // deklariert im *.Designer.cs
            
            // Ordner aus der History laden
            mtxtBox_TWPath_1038.Text = global.config.ConfigReadWriter.TWADPREPATH;

        }

        /// <summary>
        /// Event um Ordner zu öffnen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <created>janzen_d,2018-09-17</created>
        private void mbtnSelectFolder_1039_Click(object sender, EventArgs e) //TODO
        {
            global.log.MetroLog.INSTANCE.WriteLine("", global.log.MetroLog.LogType.INFO,1041);
            folderBrowserDialog.SelectedPath = mtxtBox_TWPath_1038.Text; // versuchen Ordner aus der Textbox setzen
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK) // Ordner öffnen
            {
                if (System.IO.Directory.Exists(folderBrowserDialog.SelectedPath + "\\platform\\fm") && System.IO.File.Exists(folderBrowserDialog.SelectedPath + "\\build\\version_1\\process.xml"))
                {
                    mtxtBox_TWPath_1038.Text = folderBrowserDialog.SelectedPath;
                    global.config.ConfigReadWriter.TWADPREPATH = folderBrowserDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Event um Config zu speichern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <created>janzen_d,2018-09-17</created>
        private void mbtnSave_1040_Click(object sender, EventArgs e)
        {

        }
    }
}

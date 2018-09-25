using MetroFramework.Forms;

namespace Client.global.readme.metroui
{
    /// <summary>
    /// Form für LizenzInfo
    /// </summary>
    /// <created>janzen_d,2018-09-11</created>
    public partial class LicenseMetroUI : MetroForm
    {
        /// <summary>
        /// Konstruktor der MetroUI Lizenz Form.
        /// </summary>
        /// <created>janzen_d,2018-09-11</created>
        public LicenseMetroUI()
        {
            InitializeComponent();
            this.CustomInitializeComponent(); // deklariert im MetroMain.Designer.cs

        }
    }
}

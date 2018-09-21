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

namespace Client.panel
{
    /// <summary>
    /// User Control für Standard OPC Interface
    /// </summary>
    /// <created>janzen_d,2018-09-21</created>
    public partial class TW_STOPC : MetroUserControl
    {
        public TW_STOPC(MetroFramework.Components.MetroStyleManager metroStyleManager)
        {
            InitializeComponent();
            this.CustomInitializeComponent(metroStyleManager); // deklariert im *.Designer.cs
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Components;

namespace Client.forms
{
    /// <summary>
    /// Form für SQL Verbindungseinstellungen
    /// </summary>
    /// <created>janzen_d,2018-09-25</created>
    public partial class Form_SQLConnection : MetroForm
    {
        /// <summary>
        /// Konstruktor der MetroUI SQL Form.
        /// </summary>
        /// <created>janzen_d,2018-09-25</created>
        public Form_SQLConnection(MetroStyleManager metroStyleManager)
        {
            InitializeComponent();
            this.CustomInitializeComponent(metroStyleManager); // deklariert im MetroMain.Designer.cs
        }
    }
}

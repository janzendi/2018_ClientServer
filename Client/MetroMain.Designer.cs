using MetroFramework.Controls;

namespace Client
{
    partial class MetroMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetroMain));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.statusStripbtm = new System.Windows.Forms.StatusStrip();
            this.statuslbl_copyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusprgbar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusprgtxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabNetwork = new System.Windows.Forms.TabPage();
            this.richTextBox_Info = new System.Windows.Forms.RichTextBox();
            this.statusStripbtm.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            resources.ApplyResources(this.menuBar, "menuBar");
            this.menuBar.Name = "menuBar";
            // 
            // statusStripbtm
            // 
            resources.ApplyResources(this.statusStripbtm, "statusStripbtm");
            this.statusStripbtm.BackColor = System.Drawing.Color.Transparent;
            this.statusStripbtm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslbl_copyright,
            this.statusprgbar,
            this.statusprgtxt});
            this.statusStripbtm.Name = "statusStripbtm";
            // 
            // statuslbl_copyright
            // 
            resources.ApplyResources(this.statuslbl_copyright, "statuslbl_copyright");
            this.statuslbl_copyright.Name = "statuslbl_copyright";
            this.statuslbl_copyright.Tag = "1000";
            this.statuslbl_copyright.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // statusprgbar
            // 
            resources.ApplyResources(this.statusprgbar, "statusprgbar");
            this.statusprgbar.Name = "statusprgbar";
            this.statusprgbar.Tag = "1002";
            // 
            // statusprgtxt
            // 
            resources.ApplyResources(this.statusprgtxt, "statusprgtxt");
            this.statusprgtxt.Name = "statusprgtxt";
            this.statusprgtxt.Tag = "1001";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox_Info, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabNetwork);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.UseSelectable = true;
            // 
            // tabNetwork
            // 
            resources.ApplyResources(this.tabNetwork, "tabNetwork");
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.Tag = "1006";
            this.tabNetwork.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Info
            // 
            resources.ApplyResources(this.richTextBox_Info, "richTextBox_Info");
            this.richTextBox_Info.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_Info.Name = "richTextBox_Info";
            this.richTextBox_Info.ReadOnly = true;
            // 
            // MetroMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStripbtm);
            this.Controls.Add(this.menuBar);
            this.Name = "MetroMain";
            this.Tag = "1007";
            this.statusStripbtm.ResumeLayout(false);
            this.statusStripbtm.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region customInit
        private void CustomInitializeComponent()
        {
            try
            {
                // init logger
                global.log.MetroLog.INSTANCE.SetConsole(richTextBox_Info, statusprgtxt, statusprgbar);

                // Thread start for subroutine
                System.Threading.Thread threadLanguage = new System.Threading.Thread(new System.Threading.ThreadStart(MetroMain.ReadXml));
                threadLanguage.Start();
                global.log.MetroLog.INSTANCE.WriteLine("Get Language data from file.", global.log.MetroLog.LogType.INFO);

                // Menubar aufbauen
                toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem("Datei_1002");
                toolStripMenuItemFile.Tag = 1002;
                toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem("Speichern_1004");
                toolStripMenuItemSave.Tag = 1004;
                toolStripMenuItemSave.Click += ToolStripMenuItemSave_Click;
                toolStripMenuItemFile.DropDownItems.Add(toolStripMenuItemSave);
                menuBar.Items.Add(toolStripMenuItemFile);
                toolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem("Optionen_1003");
                toolStripMenuItemOptions.Tag = 1003;
                toolStripMenuItemLanguage = new System.Windows.Forms.ToolStripMenuItem("Sprachen_1005");
                toolStripMenuItemLanguage.Tag = 1005;
                toolStripMenuItemOptions.DropDownItems.Add(toolStripMenuItemLanguage);

                menuBar.Items.Add(toolStripMenuItemOptions);
                // Menubar Sprachen aufbauen
                while (global.language.LanguageHandler.XMLREADISFINISH) { } // warten bis Lesevorgang abgeschlossen ist.
                global.log.MetroLog.INSTANCE.WriteLine("Get Language data from file finalized.", global.log.MetroLog.LogType.INFO);
                foreach (string strlanguage in global.language.LanguageHandler.INSTANCE.LISTOFLANGUAGE)
                {
                    System.Windows.Forms.ToolStripMenuItem tmp_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem(strlanguage);
                    tmp_toolStripMenuItem.Click += Click_ChangeLanguage;
                    toolStripMenuItemLanguage.DropDownItems.Add(tmp_toolStripMenuItem);
                }
                ChangeLanguage(config.ConfigReadWriter.LANGUAGE); // Sprache aus config file lesen.
                // Form Größe anpassen.
                if (this.Size.Width < System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width && this.Size.Height < System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
                {
                    this.Size = new System.Drawing.Size(config.ConfigReadWriter.WINDOWWIDTH, config.ConfigReadWriter.WINDOWLENGTH);
                    if (config.ConfigReadWriter.FULLSCREEN)
                        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    else
                        this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                    global.log.MetroLog.INSTANCE.DebugWriteLine(this.Size.Width.ToString() + " x " + this.Size.Height.ToString() + " " + this.WindowState.ToString(), global.log.MetroLog.LogType.INFO, 1011);

                }
                this.SizeChanged += MetroMain_SizeChanged;
            }
            catch (System.Exception)
            {
                throw; //TODO
            }
        }


        /// <summary>
        /// Event tritt ein sobald Fenstergroeße angepasst wird. 
        /// Leider kann ResizeEnd nicht verwendet werden, da es bei Fullscreen nicht angepasst wird.
        /// </summary>
        /// <created>janzen_d,2018-09-10</created>
        private void MetroMain_SizeChanged(object sender, System.EventArgs e)
        {
            try
            {
                config.ConfigReadWriter.WINDOWWIDTH = this.Size.Width;
                config.ConfigReadWriter.WINDOWLENGTH = this.Size.Height;
                config.ConfigReadWriter.FULLSCREEN = (this.WindowState == System.Windows.Forms.FormWindowState.Maximized);
                global.log.MetroLog.INSTANCE.DebugWriteLine(this.Size.Width.ToString() + " x " + this.Size.Height.ToString() + " " + this.WindowState.ToString(), global.log.MetroLog.LogType.INFO, 1011);

            }
            catch (System.Exception)
            {
                throw; //TODO    
            }
        }
        

        /// <summary>
        /// Methode um Sprache umzustellen.
        /// </summary>
        /// <created>janzen_d,2018-09-05</created>
        private void ChangeLanguage(string language)
        {
            try
            {
                strActualLanguage = language;
                config.ConfigReadWriter.LANGUAGE = language;
                if (this.Tag != null && System.Int32.TryParse(this.Tag.ToString(), out int resulttextid2))
                {
                    string[] arytmp2 = global.language.LanguageHandler.INSTANCE.GETOBJWORD(strActualLanguage, resulttextid2);
                    this.Text = arytmp2[2];
                }
                // alle tags lesen und mit den richtigen Sprachen beschreiben.
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    if (control is System.Windows.Forms.MenuStrip)
                    {
                        // Eine Liste erstellen.
                        System.Collections.Generic.List<System.Windows.Forms.ToolStripMenuItem> list = new System.Collections.Generic.List<System.Windows.Forms.ToolStripMenuItem>();
                        // nach allen Menüs Items suchen
                        foreach (System.Windows.Forms.ToolStripMenuItem toolStripMenuItem in ((System.Windows.Forms.MenuStrip)control).Items)
                        {
                            list.Add(toolStripMenuItem);
                            GetAllMenuItems(toolStripMenuItem, list);
                        }
                        // Menü Items mit text-ids aktualisieren
                        foreach (System.Windows.Forms.ToolStripMenuItem toolStripMenuItem in list)
                        {
                            if (toolStripMenuItem.Tag != null && System.Int32.TryParse(toolStripMenuItem.Tag.ToString(), out int resulttextid))
                            {
                                string[] arytmp = global.language.LanguageHandler.INSTANCE.GETOBJWORD(strActualLanguage, resulttextid);
                                toolStripMenuItem.Text = arytmp[2];
                                toolStripMenuItem.ToolTipText = arytmp[0];
                            }
                        }
                    }
                    else if (control is System.Windows.Forms.StatusStrip)
                    {
                        foreach (System.Windows.Forms.ToolStripItem toolstripitem in ((System.Windows.Forms.StatusStrip)control).Items)
                        {
                            if (toolstripitem.Tag != null && System.Int32.TryParse(toolstripitem.Tag.ToString(), out int resulttextid))
                            {
                                string[] arytmp = global.language.LanguageHandler.INSTANCE.GETOBJWORD(strActualLanguage, resulttextid);
                                toolstripitem.Text = arytmp[2];
                                toolstripitem.ToolTipText = arytmp[0];
                            }
                        }
                    }
                    else
                    {
                        System.Collections.Generic.List<System.Windows.Forms.Control> list = new System.Collections.Generic.List<System.Windows.Forms.Control>();
                        GetAllControls(this, list);
                        foreach (System.Windows.Forms.Control itemcontrol in list)
                        {
                            if (itemcontrol.Tag != null && System.Int32.TryParse(itemcontrol.Tag.ToString(), out int resulttextid))
                            {
                                string[] arytmp = global.language.LanguageHandler.INSTANCE.GETOBJWORD(strActualLanguage, resulttextid);
                                itemcontrol.Text = arytmp[2];
                                (new System.Windows.Forms.ToolTip()).SetToolTip(itemcontrol, arytmp[0]);
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        
        /// <summary>
        /// To get ALL child controls of a Windows Forms form of a specific type (Button/Textbox)
        /// </summary>
        /// <param name="container">grundellement</param>
        /// <param name="list">Rückgabeliste zur iteration</param>
        /// <source>https://stackoverflow.com/questions/3419159/how-to-get-all-child-controls-of-a-windows-forms-form-of-a-specific-type-button</source>
        /// <returns>List<System.Windows.Forms.Control> of all controls</returns>
        /// /// <created>janzen_d,2018-09-03</created>
        private System.Collections.Generic.List<System.Windows.Forms.Control> GetAllControls(System.Windows.Forms.Control container, System.Collections.Generic.List<System.Windows.Forms.Control> list)
        {
            foreach (System.Windows.Forms.Control c in container.Controls)
            {
                if (c is System.Windows.Forms.TabPage 
                    || c is MetroLabel) list.Add(c); // TODO or all controls.
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
            }
            return list;
        }

        /// <summary>
        /// To get ALL child controls of a Windows Forms form of a menubar
        /// </summary>
        /// <param name="container">grundellement</param>
        /// <param name="list">Rückgabeliste zur iteration</param>
        /// <source>https://stackoverflow.com/questions/3419159/how-to-get-all-child-controls-of-a-windows-forms-form-of-a-specific-type-button</source>
        /// <returns>List<System.Windows.Forms.Control> of all controls</returns>
        /// <created>janzen_d,2018-09-03</created>
        private System.Collections.Generic.List<System.Windows.Forms.ToolStripMenuItem> GetAllMenuItems(System.Windows.Forms.ToolStripMenuItem container, System.Collections.Generic.List<System.Windows.Forms.ToolStripMenuItem> list)
        {
            foreach (System.Windows.Forms.ToolStripMenuItem c in container.DropDownItems)
            {
                if (c is System.Windows.Forms.ToolStripMenuItem) list.Add(c);
                if (c.DropDownItems.Count > 0)
                    list = GetAllMenuItems(c, list);
            }
            return list;
        }

        #region threads
        private static void ReadXml()
        {
            global.language.LanguageHandler.INSTANCE.ReadXml(config.ConfigReadWriter.LANGUAGEPATH);
        }
        #endregion

        private static string strActualLanguage;
        //Menu1
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        //Menu2
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLanguage;
        //Menu3
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLicenseMetroDesignS;
        #endregion


        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.StatusStrip statusStripbtm;
        private System.Windows.Forms.ToolStripStatusLabel statuslbl_copyright;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroTabControl tabControl;
        private System.Windows.Forms.TabPage tabNetwork;
        private System.Windows.Forms.RichTextBox richTextBox_Info;
        private System.Windows.Forms.ToolStripProgressBar statusprgbar;
        private System.Windows.Forms.ToolStripStatusLabel statusprgtxt;
    }
}
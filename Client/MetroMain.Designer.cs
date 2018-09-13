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
            this.components = new System.ComponentModel.Container();
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
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.statusStripbtm.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            resources.ApplyResources(this.menuBar, "menuBar");
            this.menuBar.Name = "menuBar";
            // 
            // statusStripbtm
            // 
            this.statusStripbtm.BackColor = System.Drawing.Color.Transparent;
            this.statusStripbtm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslbl_copyright,
            this.statusprgbar,
            this.statusprgtxt});
            resources.ApplyResources(this.statusStripbtm, "statusStripbtm");
            this.statusStripbtm.Name = "statusStripbtm";
            // 
            // statuslbl_copyright
            // 
            this.statuslbl_copyright.Name = "statuslbl_copyright";
            resources.ApplyResources(this.statuslbl_copyright, "statuslbl_copyright");
            this.statuslbl_copyright.Tag = "1000";
            this.statuslbl_copyright.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // statusprgbar
            // 
            this.statusprgbar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusprgbar.Name = "statusprgbar";
            resources.ApplyResources(this.statusprgbar, "statusprgbar");
            this.statusprgbar.Step = 1;
            this.statusprgbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.statusprgbar.Tag = "1002";
            // 
            // statusprgtxt
            // 
            this.statusprgtxt.Name = "statusprgtxt";
            resources.ApplyResources(this.statusprgtxt, "statusprgtxt");
            this.statusprgtxt.Tag = "1001";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox_Info, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabNetwork);
            resources.ApplyResources(this.tabControl, "tabControl");
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
            this.richTextBox_Info.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.richTextBox_Info, "richTextBox_Info");
            this.richTextBox_Info.Name = "richTextBox_Info";
            this.richTextBox_Info.ReadOnly = true;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
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
            this.StyleManager = this.metroStyleManager;
            this.Tag = "1007";
            this.statusStripbtm.ResumeLayout(false);
            this.statusStripbtm.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
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

                //
                // Tooltip
                //
                metroToolTip = new MetroFramework.Components.MetroToolTip();
                metroToolTip.StyleManager = this.StyleManager;

                // Thread start for subroutine
                System.Threading.Thread threadLanguage = new System.Threading.Thread(new System.Threading.ThreadStart(MetroMain.ReadXml));
                threadLanguage.Start();
                global.log.MetroLog.INSTANCE.WriteLine("Get Language data from file.", global.log.MetroLog.LogType.INFO);

                // Menubar aufbauen
                toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
                //Menu1
                toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem("Datei_1002");
                toolStripMenuItemFile.Tag = 1002;
                menuBar.Items.Add(toolStripMenuItemFile);
                toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem("Speichern_1004");
                toolStripMenuItemSave.Tag = 1004;
                toolStripMenuItemFile.DropDownItems.Add(toolStripMenuItemSave);
                toolStripMenuItemSave.Click += ToolStripMenuItemSave_Click;
                //Menu2
                toolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem("Optionen_1003");
                toolStripMenuItemOptions.Tag = 1003;
                menuBar.Items.Add(toolStripMenuItemOptions);
                toolStripMenuItemLanguage = new System.Windows.Forms.ToolStripMenuItem("Sprachen_1005");
                toolStripMenuItemLanguage.Tag = 1005;
                toolStripMenuItemOptions.DropDownItems.Add(toolStripMenuItemLanguage);
                toolStripMenuItemDesign = new System.Windows.Forms.ToolStripMenuItem("Design_1016");
                toolStripMenuItemDesign.Tag = 1016;
                toolStripMenuItemOptions.DropDownItems.Add(toolStripMenuItemDesign);
                toolStripMenuItemStyle = new System.Windows.Forms.ToolStripMenuItem("Style_1017");
                toolStripMenuItemStyle.Tag = 1017;
                toolStripMenuItemDesign.DropDownItems.Add(toolStripMenuItemStyle);
                toolStripMenuItemStyle.Click += ToolStripMenuItemStyle_Click;
                toolStripMenuItemTheme = new System.Windows.Forms.ToolStripMenuItem("Theme_1018");
                toolStripMenuItemTheme.Tag = 1018;
                toolStripMenuItemDesign.DropDownItems.Add(toolStripMenuItemTheme);
                toolStripMenuItemTheme.Click += ToolStripMenuItemTheme_Click;

                //Menu3
                toolStripMenuItemInfo = new System.Windows.Forms.ToolStripMenuItem("Info_1012");
                toolStripMenuItemInfo.Tag = 1012;
                menuBar.Items.Add(toolStripMenuItemInfo);
                toolStripMenuItemLicense = new System.Windows.Forms.ToolStripMenuItem("Lizenzen_1013");
                toolStripMenuItemLicense.Tag = 1013;
                toolStripMenuItemInfo.DropDownItems.Add(toolStripMenuItemLicense);
               //TODO toolStripMenuItemInfo.DropDownItems.Add(toolStripSeparator);
                toolStripMenuItemLicenseMetroDesignS = new System.Windows.Forms.ToolStripMenuItem("MetroUI_1014");
                toolStripMenuItemLicenseMetroDesignS.Tag = 1014;
                toolStripMenuItemLicense.DropDownItems.Add(toolStripMenuItemLicenseMetroDesignS);
                toolStripMenuItemLicenseMetroDesignS.Click += ToolStripMenuItemLicenseMetroDesignS_Click;
                toolStripMenuItemRegisterierung = new System.Windows.Forms.ToolStripMenuItem("Register_1019");
                toolStripMenuItemRegisterierung.Tag = 1019;
                toolStripMenuItemRegisterierung.Click += ToolStripMenuItemRegisterierung_Click;
                toolStripMenuItemInfo.DropDownItems.Add(toolStripMenuItemRegisterierung);

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
                this.FormClosing += MetroMain_FormClosing;

                //Icon definieren
                this.Icon = new System.Drawing.Icon(config.ConfigReadWriter.PATHICON);
                
                //Panel Transparent gestalten damit Metro design angezeigt wird.
                tabNetwork.BackColor = System.Drawing.Color.Transparent;
                tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
                this.statuslbl_copyright.Font = this.tabNetwork.Font;
                this.statuslbl_copyright.ForeColor = MetroFramework.MetroColors.Black;
                this.statusprgtxt.Font = this.tabNetwork.Font;
                this.statusprgtxt.ForeColor = MetroFramework.MetroColors.Black;
                this.statusprgbar.BackColor = MetroFramework.MetroColors.Silver;
                this.richTextBox_Info.Font = MetroLabel.DefaultFont;
                this.richTextBox_Info.ForeColor = MetroLabel.DefaultForeColor;
                this.richTextBox_Info.BackColor = MetroFramework.MetroColors.White;
                this.richTextBox_Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
                metroStyleManager.Theme = config.ConfigReadWriter.METROTHEME;
                metroStyleManager.Style = config.ConfigReadWriter.METROSTYLE;
                
            }
            catch (System.Exception)
            {
                throw; //TODO
            }
        }

        /// <summary>
        /// Lizenzschlüssel eintragen und die jeweilige Form aufrufen.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        /// </summary>
        /// <created>janzen_d,2018-09-13</created>
        private void ToolStripMenuItemRegisterierung_Click(object sender, System.EventArgs e)
        {
            try
            {
                global.readme.license.Register register = new global.readme.license.Register(this.StyleManager);
                register.ShowDialog();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metro Theme ändern                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        /// </summary>
        /// <created>janzen_d,2018-09-12</created>
        private void ToolStripMenuItemTheme_Click(object sender, System.EventArgs e)
        {
            try
            {
                metroStyleManager.Theme = metroStyleManager.Theme == MetroFramework.MetroThemeStyle.Light ? MetroFramework.MetroThemeStyle.Dark : MetroFramework.MetroThemeStyle.Light;
                this.richTextBox_Info.BackColor = this.richTextBox_Info.BackColor == MetroFramework.MetroColors.White ? MetroFramework.MetroColors.Silver : MetroFramework.MetroColors.White;
                this.statuslbl_copyright.ForeColor = this.statuslbl_copyright.ForeColor == MetroFramework.MetroColors.Black ? MetroFramework.MetroColors.Silver : MetroFramework.MetroColors.Black;
                this.statusprgtxt.ForeColor = this.statusprgtxt.ForeColor == MetroFramework.MetroColors.Black ? MetroFramework.MetroColors.Silver : MetroFramework.MetroColors.Black;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metro stil ändern                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
        /// </summary>
        /// <created>janzen_d,2018-09-12</created>
        private void ToolStripMenuItemStyle_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (metroStyleManager.Style == MetroFramework.MetroColorStyle.Yellow) metroStyleManager.Style = MetroFramework.MetroColorStyle.Black;
                else metroStyleManager.Style = metroStyleManager.Style + 1;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lizenz Info                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        /// </summary>
        /// <created>janzen_d,2018-09-11</created>
        private void ToolStripMenuItemLicenseMetroDesignS_Click(object sender, System.EventArgs e)
        {
            try
            {
                global.readme.metroui.LicenseMetroUI licenseMetroUI = new global.readme.metroui.LicenseMetroUI();
                licenseMetroUI.StyleManager = this.StyleManager;
                licenseMetroUI.ShowDialog();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Doing beim schließen.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        /// </summary>
        /// <created>janzen_d,2018-09-10</created>
        /// <modified>janzen_d,2018-09-12: Metro Stil und Theme hinzugefügt</modified>
        private void MetroMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                config.ConfigReadWriter.WINDOWWIDTH = this.Size.Width;
                config.ConfigReadWriter.WINDOWLENGTH = this.Size.Height;
                config.ConfigReadWriter.FULLSCREEN = (this.WindowState == System.Windows.Forms.FormWindowState.Maximized);
                global.log.MetroLog.INSTANCE.DebugWriteLine(this.Size.Width.ToString() + " x " + this.Size.Height.ToString() + " " + this.WindowState.ToString(), global.log.MetroLog.LogType.INFO, 1011);
                config.ConfigReadWriter.METROTHEME = metroStyleManager.Theme;
                config.ConfigReadWriter.METROSTYLE = metroStyleManager.Style;
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
                                metroToolTip.SetToolTip(itemcontrol, arytmp[0]);
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
        //MenuSeperator
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        //Menu1
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        //Menu2
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLanguage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDesign;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStyle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTheme;
        //Menu3
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLicense;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLicenseMetroDesignS;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRegisterierung;
        //Tooltip
        private MetroFramework.Components.MetroToolTip metroToolTip;
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
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
    }
}
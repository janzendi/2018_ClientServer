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
            this.tabPTCWizardStandardOPC = new System.Windows.Forms.TabPage();
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
            this.tabControl.Controls.Add(this.tabPTCWizardStandardOPC);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.UseSelectable = true;
            // 
            // tabPTCWizardStandardOPC
            // 
            resources.ApplyResources(this.tabPTCWizardStandardOPC, "tabPTCWizardStandardOPC");
            this.tabPTCWizardStandardOPC.Name = "tabPTCWizardStandardOPC";
            this.tabPTCWizardStandardOPC.UseVisualStyleBackColor = true;
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
            // init logger
            global.log.MetroLog.INSTANCE.SetConsole(richTextBox_Info, statusprgtxt, statusprgbar);

            // Thread start for subroutine
            System.Threading.Thread threadLanguage = new System.Threading.Thread(new System.Threading.ThreadStart(MetroMain.ReadXml));
            threadLanguage.Start();
            global.log.MetroLog.INSTANCE.WriteLine("Get Language data from file.");
            
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
            global.log.MetroLog.INSTANCE.WriteLine("Get Language data from file finalized.");
            strActualLanguage = config.ConfigReadWriter.LANGUAGE; // Sprache aus config file lesen.
            foreach (string strlanguage in global.language.LanguageHandler.INSTANCE.LISTOFLANGUAGE)
            {
                System.Windows.Forms.ToolStripMenuItem tmp_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem(strlanguage);
                tmp_toolStripMenuItem.Click += Click_ChangeLanguage;
                toolStripMenuItemLanguage.DropDownItems.Add(tmp_toolStripMenuItem);
            }
            // alle tags lesen und mit den richtigen Sprachen beschreiben.
            for (int i = 0; i < this.Controls.Count; i++)
            {
                switch (this.Controls[i].GetType())
                {
                    case types["TableLayoutPanel"]:
                    default:
                        break;
                }
                if (this.Controls[i].Tag != null)
                {
                    if (System.Int32.TryParse(this.Controls[i].Tag.ToString(), out int textid))
                    {
                        string[] tmpTextID = global.language.LanguageHandler.INSTANCE.GETOBJWORD(strActualLanguage, textid);
                        this.Controls[i].Text = tmpTextID[2];
                        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                        toolTip.SetToolTip(this.Controls[i], tmpTextID[0]);
                    }
                }
            }
        }

        public System.Collections.Generic.IEnumerable<System.Windows.Forms.Control> GetAll(System.Windows.Forms.Control control, System.Type type)
        {
            //var controls = control.Controls.Cast<System.Windows.Forms.Control>();

            //return controls.SelectMany(ctrl => GetAll(ctrl, type))
            //                        .Concat(controls)
            //                      .Where(c => c.GetType() == type);
            return null;
        }

        #region threads
        private static void ReadXml()
        {
            global.language.LanguageHandler.INSTANCE.ReadXml(config.ConfigReadWriter.LANGUAGEPATH);
        }
        #endregion

        private static string strActualLanguage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLanguage;
        private System.Collections.Generic.Dictionary<string, System.Type> types = new System.Collections.Generic.Dictionary<string, System.Type>() {
            { "TableLayoutPanel", typeof(System.Windows.Forms.TableLayoutPanel) }
            , { "StatusStrip", typeof(System.Windows.Forms.StatusStrip) }
            , { "MenuStrip", typeof(System.Windows.Forms.MenuStrip) }
        };// TODO https://stackoverflow.com/questions/3419159/how-to-get-all-child-controls-of-a-windows-forms-form-of-a-specific-type-button

        #endregion


        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.StatusStrip statusStripbtm;
        private System.Windows.Forms.ToolStripStatusLabel statuslbl_copyright;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroTabControl tabControl;
        private System.Windows.Forms.TabPage tabPTCWizardStandardOPC;
        private System.Windows.Forms.RichTextBox richTextBox_Info;
        private System.Windows.Forms.ToolStripProgressBar statusprgbar;
        private System.Windows.Forms.ToolStripStatusLabel statusprgtxt;
        
    }
}
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
            this.tODOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tODOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripbtm = new System.Windows.Forms.StatusStrip();
            this.statuslbl_copyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusprgbar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusprgtxt = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabPTCWizardStandardOPC = new System.Windows.Forms.TabPage();
            this.richTextBox_Info = new System.Windows.Forms.RichTextBox();
            this.menuBar.SuspendLayout();
            this.statusStripbtm.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            resources.ApplyResources(this.menuBar, "menuBar");
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tODOToolStripMenuItem,
            this.tODOToolStripMenuItem1});
            this.menuBar.Name = "menuBar";
            // 
            // tODOToolStripMenuItem
            // 
            resources.ApplyResources(this.tODOToolStripMenuItem, "tODOToolStripMenuItem");
            this.tODOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.tODOToolStripMenuItem.Name = "tODOToolStripMenuItem";
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            // 
            // tODOToolStripMenuItem1
            // 
            resources.ApplyResources(this.tODOToolStripMenuItem1, "tODOToolStripMenuItem1");
            this.tODOToolStripMenuItem1.Name = "tODOToolStripMenuItem1";
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
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.statusStripbtm.ResumeLayout(false);
            this.statusStripbtm.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem tODOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tODOToolStripMenuItem1;
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
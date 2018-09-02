namespace Client
{
    partial class ClientForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tODOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tODOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statuslbl_copyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPNetwork = new System.Windows.Forms.TabPage();
            this.tabPNetworkV2 = new System.Windows.Forms.TabPage();
            this.tabPAcronis = new System.Windows.Forms.TabPage();
            this.tabPSystem = new System.Windows.Forms.TabPage();
            this.tabPTCWizardDomain = new System.Windows.Forms.TabPage();
            this.tabPTCWizardStandardOPC = new System.Windows.Forms.TabPage();
            this.richTextBox_Info = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tODOToolStripMenuItem,
            this.tODOToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1172, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tODOToolStripMenuItem
            // 
            this.tODOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.tODOToolStripMenuItem.Name = "tODOToolStripMenuItem";
            this.tODOToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.tODOToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // tODOToolStripMenuItem1
            // 
            this.tODOToolStripMenuItem1.Name = "tODOToolStripMenuItem1";
            this.tODOToolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.tODOToolStripMenuItem1.Text = "TODO";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslbl_copyright,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1172, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuslbl_copyright
            // 
            this.statuslbl_copyright.Name = "statuslbl_copyright";
            this.statuslbl_copyright.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statuslbl_copyright.Size = new System.Drawing.Size(92, 17);
            this.statuslbl_copyright.Text = "©Dimitri Janzen";
            this.statuslbl_copyright.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "TODO";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox_Info, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.74517F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.25483F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1172, 636);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPNetwork);
            this.tabControl.Controls.Add(this.tabPNetworkV2);
            this.tabControl.Controls.Add(this.tabPAcronis);
            this.tabControl.Controls.Add(this.tabPSystem);
            this.tabControl.Controls.Add(this.tabPTCWizardDomain);
            this.tabControl.Controls.Add(this.tabPTCWizardStandardOPC);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1166, 463);
            this.tabControl.TabIndex = 1;
            // 
            // tabPNetwork
            // 
            this.tabPNetwork.AutoScroll = true;
            this.tabPNetwork.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPNetwork.Location = new System.Drawing.Point(4, 22);
            this.tabPNetwork.Name = "tabPNetwork";
            this.tabPNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.tabPNetwork.Size = new System.Drawing.Size(1158, 437);
            this.tabPNetwork.TabIndex = 2;
            this.tabPNetwork.Text = "tabPNetwork";
            this.tabPNetwork.UseVisualStyleBackColor = true;
            // 
            // tabPNetworkV2
            // 
            this.tabPNetworkV2.Location = new System.Drawing.Point(4, 22);
            this.tabPNetworkV2.Name = "tabPNetworkV2";
            this.tabPNetworkV2.Size = new System.Drawing.Size(1158, 437);
            this.tabPNetworkV2.TabIndex = 5;
            this.tabPNetworkV2.Text = "tabPNetworkV2";
            this.tabPNetworkV2.UseVisualStyleBackColor = true;
            // 
            // tabPAcronis
            // 
            this.tabPAcronis.AutoScroll = true;
            this.tabPAcronis.Location = new System.Drawing.Point(4, 22);
            this.tabPAcronis.Name = "tabPAcronis";
            this.tabPAcronis.Padding = new System.Windows.Forms.Padding(3);
            this.tabPAcronis.Size = new System.Drawing.Size(1158, 437);
            this.tabPAcronis.TabIndex = 0;
            this.tabPAcronis.Text = "tabPAcronis";
            this.tabPAcronis.UseVisualStyleBackColor = true;
            // 
            // tabPSystem
            // 
            this.tabPSystem.Location = new System.Drawing.Point(4, 22);
            this.tabPSystem.Name = "tabPSystem";
            this.tabPSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPSystem.Size = new System.Drawing.Size(1158, 437);
            this.tabPSystem.TabIndex = 1;
            this.tabPSystem.Text = "tabPSystem";
            this.tabPSystem.UseVisualStyleBackColor = true;
            // 
            // tabPTCWizardDomain
            // 
            this.tabPTCWizardDomain.Location = new System.Drawing.Point(4, 22);
            this.tabPTCWizardDomain.Name = "tabPTCWizardDomain";
            this.tabPTCWizardDomain.Size = new System.Drawing.Size(1158, 437);
            this.tabPTCWizardDomain.TabIndex = 3;
            this.tabPTCWizardDomain.Text = "tabPTCWizardDomain";
            this.tabPTCWizardDomain.UseVisualStyleBackColor = true;
            // 
            // tabPTCWizardStandardOPC
            // 
            this.tabPTCWizardStandardOPC.Location = new System.Drawing.Point(4, 22);
            this.tabPTCWizardStandardOPC.Name = "tabPTCWizardStandardOPC";
            this.tabPTCWizardStandardOPC.Size = new System.Drawing.Size(1158, 437);
            this.tabPTCWizardStandardOPC.TabIndex = 4;
            this.tabPTCWizardStandardOPC.Text = "tabPTCWizardStandardOPC";
            this.tabPTCWizardStandardOPC.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Info
            // 
            this.richTextBox_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Info.Location = new System.Drawing.Point(3, 472);
            this.richTextBox_Info.Name = "richTextBox_Info";
            this.richTextBox_Info.ReadOnly = true;
            this.richTextBox_Info.Size = new System.Drawing.Size(1166, 161);
            this.richTextBox_Info.TabIndex = 2;
            this.richTextBox_Info.Text = "";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 682);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientForm";
            this.Text = "Client";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tODOToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPAcronis;
        private System.Windows.Forms.TabPage tabPSystem;
        private System.Windows.Forms.RichTextBox richTextBox_Info;
        private System.Windows.Forms.TabPage tabPNetwork;
        private System.Windows.Forms.ToolStripStatusLabel statuslbl_copyright;
        private System.Windows.Forms.TabPage tabPTCWizardDomain;
        private System.Windows.Forms.TabPage tabPTCWizardStandardOPC;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tODOToolStripMenuItem1;
        private System.Windows.Forms.TabPage tabPNetworkV2;
    }
}


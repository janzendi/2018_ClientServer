namespace Client.panel
{
    partial class TW_AD
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mtxtBox_TWPath_1038 = new MetroFramework.Controls.MetroTextBox();
            this.mbtnSelectFolder_1039 = new MetroFramework.Controls.MetroButton();
            this.mbtnSave_1040 = new MetroFramework.Controls.MetroButton();
            this.metroGrid = new MetroFramework.Controls.MetroGrid();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.metroGrid, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(680, 425);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.mtxtBox_TWPath_1038);
            this.flowLayoutPanel1.Controls.Add(this.mbtnSelectFolder_1039);
            this.flowLayoutPanel1.Controls.Add(this.mbtnSave_1040);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(674, 44);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // mtxtBox_TWPath_1038
            // 
            // 
            // 
            // 
            this.mtxtBox_TWPath_1038.CustomButton.Image = null;
            this.mtxtBox_TWPath_1038.CustomButton.Location = new System.Drawing.Point(206, 2);
            this.mtxtBox_TWPath_1038.CustomButton.Name = "";
            this.mtxtBox_TWPath_1038.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.mtxtBox_TWPath_1038.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtBox_TWPath_1038.CustomButton.TabIndex = 1;
            this.mtxtBox_TWPath_1038.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtBox_TWPath_1038.CustomButton.UseSelectable = true;
            this.mtxtBox_TWPath_1038.CustomButton.Visible = false;
            this.mtxtBox_TWPath_1038.Lines = new string[] {
        "mtxtBox_TWPath_1038"};
            this.mtxtBox_TWPath_1038.Location = new System.Drawing.Point(3, 3);
            this.mtxtBox_TWPath_1038.MaxLength = 32767;
            this.mtxtBox_TWPath_1038.Name = "mtxtBox_TWPath_1038";
            this.mtxtBox_TWPath_1038.PasswordChar = '\0';
            this.mtxtBox_TWPath_1038.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtBox_TWPath_1038.SelectedText = "";
            this.mtxtBox_TWPath_1038.SelectionLength = 0;
            this.mtxtBox_TWPath_1038.SelectionStart = 0;
            this.mtxtBox_TWPath_1038.ShortcutsEnabled = true;
            this.mtxtBox_TWPath_1038.Size = new System.Drawing.Size(238, 34);
            this.mtxtBox_TWPath_1038.TabIndex = 0;
            this.mtxtBox_TWPath_1038.Tag = "1038";
            this.mtxtBox_TWPath_1038.Text = "mtxtBox_TWPath_1038";
            this.mtxtBox_TWPath_1038.UseSelectable = true;
            this.mtxtBox_TWPath_1038.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtBox_TWPath_1038.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtnSelectFolder_1039
            // 
            this.mbtnSelectFolder_1039.Location = new System.Drawing.Point(247, 3);
            this.mbtnSelectFolder_1039.Name = "mbtnSelectFolder_1039";
            this.mbtnSelectFolder_1039.Size = new System.Drawing.Size(140, 34);
            this.mbtnSelectFolder_1039.TabIndex = 1;
            this.mbtnSelectFolder_1039.Tag = "1039";
            this.mbtnSelectFolder_1039.Text = "mbtnSelectFolder_1039";
            this.mbtnSelectFolder_1039.UseSelectable = true;
            this.mbtnSelectFolder_1039.Click += new System.EventHandler(this.mbtnSelectFolder_1039_Click);
            // 
            // mbtnSave_1040
            // 
            this.mbtnSave_1040.Location = new System.Drawing.Point(393, 3);
            this.mbtnSave_1040.Name = "mbtnSave_1040";
            this.mbtnSave_1040.Size = new System.Drawing.Size(140, 34);
            this.mbtnSave_1040.TabIndex = 2;
            this.mbtnSave_1040.Tag = "1040";
            this.mbtnSave_1040.Text = "mbtnSave_1040";
            this.mbtnSave_1040.UseSelectable = true;
            this.mbtnSave_1040.Click += new System.EventHandler(this.mbtnSave_1040_Click);
            // 
            // metroGrid
            // 
            this.metroGrid.AllowUserToResizeRows = false;
            this.metroGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.metroGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid.DefaultCellStyle = dataGridViewCellStyle11;
            this.metroGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGrid.EnableHeadersVisualStyles = false;
            this.metroGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid.Location = new System.Drawing.Point(3, 53);
            this.metroGrid.Name = "metroGrid";
            this.metroGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.metroGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid.Size = new System.Drawing.Size(674, 369);
            this.metroGrid.TabIndex = 1;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Tag = "1036";
            // 
            // TW_AD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "TW_AD";
            this.Size = new System.Drawing.Size(680, 425);
            this.tableLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region customInit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="metroStyleManager"></param>
        /// <created>janzen_d,2018-09-17</created>
        private void CustomInitializeComponent(MetroFramework.Components.MetroStyleManager metroStyleManager)
        {
            //
            // Form Einstellungen
            //
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderBrowserDialog.ShowNewFolderButton = false;

            //
            // StyleManager setzen
            //
            this.StyleManager = metroStyleManager;

            //
            // Tooltip
            //
            metroToolTip = new MetroFramework.Components.MetroToolTip();
            metroToolTip.StyleManager = this.StyleManager;

        }

        /// <summary>
        /// Methode um Sprache umzustellen.
        /// </summary>
        /// <created>janzen_d,2018-09-17</created>
        public void ChangeLanguage(string language)
        {
            try
            {
                // folderDialog
                if (this.folderBrowserDialog.Tag != null && System.Int32.TryParse(this.folderBrowserDialog.Tag.ToString(), out int resulttextid3))
                {
                    string[] arytmp2 = global.language.LanguageHandler.INSTANCE.GETOBJWORD(language, resulttextid3);
                    this.folderBrowserDialog.Description = arytmp2[2];
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        
        //Tooltip
        private MetroFramework.Components.MetroToolTip metroToolTip;
        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroTextBox mtxtBox_TWPath_1038;
        private MetroFramework.Controls.MetroButton mbtnSelectFolder_1039;
        private MetroFramework.Controls.MetroButton mbtnSave_1040;
        private MetroFramework.Controls.MetroGrid metroGrid;
    }
}
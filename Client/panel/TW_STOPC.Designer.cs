namespace Client.panel
{
    partial class TW_STOPC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroGrid = new MetroFramework.Controls.MetroGrid();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mtxtBox_TWPath_1038 = new MetroFramework.Controls.MetroTextBox();
            this.mbtnSelectFolder_1039 = new MetroFramework.Controls.MetroButton();
            this.mbtnSave_1040 = new MetroFramework.Controls.MetroButton();
            this.gridlistid_1060 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridmodulename_1044 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridvariablename_1061 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridpvbatchvariable_1062 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridpdacountertype_1063 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridtextid_1064 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcomment_1065 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridopcdatatype_1066 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridopcrwu_1067 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridopcalias_1068 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridopcactive_1069 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridarrysize_1070 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridsemantic_1071 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.griddcreadperiod_1072 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.griddclogthreshold_1073 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.griddcmaxpersistence_1074 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridpathpvbatch_1075 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridpathpvequipment_1076 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridpathpvprocess_1077 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Tag = "1036";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.metroGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(663, 345);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // metroGrid
            // 
            this.metroGrid.AllowUserToResizeRows = false;
            this.metroGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.metroGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridlistid_1060,
            this.gridmodulename_1044,
            this.gridvariablename_1061,
            this.gridpvbatchvariable_1062,
            this.gridpdacountertype_1063,
            this.gridtextid_1064,
            this.gridcomment_1065,
            this.gridopcdatatype_1066,
            this.gridopcrwu_1067,
            this.gridopcalias_1068,
            this.gridopcactive_1069,
            this.gridarrysize_1070,
            this.gridsemantic_1071,
            this.griddcreadperiod_1072,
            this.griddclogthreshold_1073,
            this.griddcmaxpersistence_1074,
            this.gridpathpvbatch_1075,
            this.gridpathpvequipment_1076,
            this.gridpathpvprocess_1077});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGrid.EnableHeadersVisualStyles = false;
            this.metroGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid.Location = new System.Drawing.Point(3, 53);
            this.metroGrid.MultiSelect = false;
            this.metroGrid.Name = "metroGrid";
            this.metroGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid.Size = new System.Drawing.Size(657, 289);
            this.metroGrid.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.mtxtBox_TWPath_1038);
            this.flowLayoutPanel1.Controls.Add(this.mbtnSelectFolder_1039);
            this.flowLayoutPanel1.Controls.Add(this.mbtnSave_1040);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(657, 44);
            this.flowLayoutPanel1.TabIndex = 1;
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
            // 
            // gridlistid_1060
            // 
            this.gridlistid_1060.HeaderText = "gridlistid_1060";
            this.gridlistid_1060.Name = "gridlistid_1060";
            this.gridlistid_1060.ReadOnly = true;
            // 
            // gridmodulename_1044
            // 
            this.gridmodulename_1044.HeaderText = "gridmodulename_1044";
            this.gridmodulename_1044.MinimumWidth = 100;
            this.gridmodulename_1044.Name = "gridmodulename_1044";
            this.gridmodulename_1044.ReadOnly = true;
            this.gridmodulename_1044.Width = 140;
            // 
            // gridvariablename_1061
            // 
            this.gridvariablename_1061.HeaderText = "gridvariablename_1061";
            this.gridvariablename_1061.Name = "gridvariablename_1061";
            this.gridvariablename_1061.ReadOnly = true;
            // 
            // gridpvbatchvariable_1062
            // 
            this.gridpvbatchvariable_1062.HeaderText = "gridpvbatchvariable_1062";
            this.gridpvbatchvariable_1062.Name = "gridpvbatchvariable_1062";
            this.gridpvbatchvariable_1062.ReadOnly = true;
            // 
            // gridpdacountertype_1063
            // 
            this.gridpdacountertype_1063.HeaderText = "gridpdacountertype_1063";
            this.gridpdacountertype_1063.Name = "gridpdacountertype_1063";
            this.gridpdacountertype_1063.ReadOnly = true;
            // 
            // gridtextid_1064
            // 
            this.gridtextid_1064.HeaderText = "gridtextid_1064";
            this.gridtextid_1064.Name = "gridtextid_1064";
            this.gridtextid_1064.ReadOnly = true;
            // 
            // gridcomment_1065
            // 
            this.gridcomment_1065.HeaderText = "gridcomment_1065";
            this.gridcomment_1065.Name = "gridcomment_1065";
            this.gridcomment_1065.ReadOnly = true;
            // 
            // gridopcdatatype_1066
            // 
            this.gridopcdatatype_1066.HeaderText = "gridopcdatatype_1066";
            this.gridopcdatatype_1066.Name = "gridopcdatatype_1066";
            this.gridopcdatatype_1066.ReadOnly = true;
            // 
            // gridopcrwu_1067
            // 
            this.gridopcrwu_1067.HeaderText = "gridopcrwu_1067";
            this.gridopcrwu_1067.Name = "gridopcrwu_1067";
            this.gridopcrwu_1067.ReadOnly = true;
            // 
            // gridopcalias_1068
            // 
            this.gridopcalias_1068.HeaderText = "gridopcalias_1068";
            this.gridopcalias_1068.Name = "gridopcalias_1068";
            this.gridopcalias_1068.ReadOnly = true;
            // 
            // gridopcactive_1069
            // 
            this.gridopcactive_1069.HeaderText = "gridopcactive_1069";
            this.gridopcactive_1069.Name = "gridopcactive_1069";
            this.gridopcactive_1069.ReadOnly = true;
            // 
            // gridarrysize_1070
            // 
            this.gridarrysize_1070.HeaderText = "gridarrysize_1070";
            this.gridarrysize_1070.Name = "gridarrysize_1070";
            this.gridarrysize_1070.ReadOnly = true;
            // 
            // gridsemantic_1071
            // 
            this.gridsemantic_1071.HeaderText = "gridsemantic_1071";
            this.gridsemantic_1071.Name = "gridsemantic_1071";
            this.gridsemantic_1071.ReadOnly = true;
            // 
            // griddcreadperiod_1072
            // 
            this.griddcreadperiod_1072.HeaderText = "griddcreadperiod_1072";
            this.griddcreadperiod_1072.Name = "griddcreadperiod_1072";
            this.griddcreadperiod_1072.ReadOnly = true;
            // 
            // griddclogthreshold_1073
            // 
            this.griddclogthreshold_1073.HeaderText = "griddclogthreshold_1073";
            this.griddclogthreshold_1073.Name = "griddclogthreshold_1073";
            this.griddclogthreshold_1073.ReadOnly = true;
            // 
            // griddcmaxpersistence_1074
            // 
            this.griddcmaxpersistence_1074.HeaderText = "griddcmaxpersistence_1074";
            this.griddcmaxpersistence_1074.Name = "griddcmaxpersistence_1074";
            this.griddcmaxpersistence_1074.ReadOnly = true;
            // 
            // gridpathpvbatch_1075
            // 
            this.gridpathpvbatch_1075.HeaderText = "gridpathpvbatch_1075";
            this.gridpathpvbatch_1075.Name = "gridpathpvbatch_1075";
            this.gridpathpvbatch_1075.ReadOnly = true;
            // 
            // gridpathpvequipment_1076
            // 
            this.gridpathpvequipment_1076.HeaderText = "gridpathpvequipment_1076";
            this.gridpathpvequipment_1076.Name = "gridpathpvequipment_1076";
            this.gridpathpvequipment_1076.ReadOnly = true;
            // 
            // gridpathpvprocess_1077
            // 
            this.gridpathpvprocess_1077.HeaderText = "gridpathpvprocess_1077";
            this.gridpathpvprocess_1077.Name = "gridpathpvprocess_1077";
            this.gridpathpvprocess_1077.ReadOnly = true;
            // 
            // TW_STOPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TW_STOPC";
            this.Size = new System.Drawing.Size(663, 345);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
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

            //
            // Textbox
            //
            this.mtxtBox_TWPath_1038.Text = global.config.ConfigReadWriter.TWOPCPATH;

            //
            // Button
            //
            this.mbtnSave_1040.Click += MbtnSave_1040_Click;
            this.mbtnSave_1040.Enabled = false;
            this.mbtnSelectFolder_1039.Click += MbtnSelectFolder_1039_Click;
            // 
            // gridlistid_1060
            // 
            this.gridlistid_1060.Tag = 1060;
            // 
            // gridmodulename_1044
            // 
            this.gridmodulename_1044.Tag = 1044;
            // 
            // gridvariablename_1061
            // 
            this.gridvariablename_1061.Tag = 1061;
            // 
            // gridpvbatchvariable_1062
            // 
            this.gridpvbatchvariable_1062.Tag = 1062;
            // 
            // gridpdacountertype_1063
            // 
            this.gridpdacountertype_1063.Tag = 1063;
            // 
            // gridtextid_1064
            // 
            this.gridtextid_1064.Tag = 1064;
            // 
            // gridcomment_1065
            // 
            this.gridcomment_1065.Tag = 1065;
            // 
            // gridopcdatatype_1066
            // 
            this.gridopcdatatype_1066.Tag = 1066;
            // 
            // gridopcrwu_1067
            // 
            this.gridopcrwu_1067.Tag = 1067;
            // 
            // gridopcalias_1068
            // 
            this.gridopcalias_1068.Tag = 1068;
            // 
            // gridopcactive_1069
            // 
            this.gridopcactive_1069.Tag = 1069;
            // 
            // gridarrysize_1070
            // 
            this.gridarrysize_1070.Tag = 1070;
            // 
            // gridsemantic_1071
            // 
            this.gridsemantic_1071.Tag = 1071;
            // 
            // griddcreadperiod_1072
            // 
            this.griddcreadperiod_1072.Tag = 1072;
            // 
            // griddclogthreshold_1073
            // 
            this.griddclogthreshold_1073.Tag = 1073;
            // 
            // griddcmaxpersistence_1074
            // 
            this.griddcmaxpersistence_1074.Tag = 1074;
            // 
            // gridpathpvbatch_1075
            // 
            this.gridpathpvbatch_1075.Tag = 1075;
            // 
            // gridpathpvequipment_1076
            // 
            this.gridpathpvequipment_1076.Tag = 1076;
            // 
            // gridpathpvprocess_1077
            // 
            this.gridpathpvprocess_1077.Tag = 1077;

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

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroTextBox mtxtBox_TWPath_1038;
        private MetroFramework.Controls.MetroButton mbtnSelectFolder_1039;
        private MetroFramework.Controls.MetroButton mbtnSave_1040;
        private MetroFramework.Controls.MetroGrid metroGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridlistid_1060;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridmodulename_1044;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridvariablename_1061;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridpvbatchvariable_1062;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridpdacountertype_1063;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridtextid_1064;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcomment_1065;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridopcdatatype_1066;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridopcrwu_1067;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridopcalias_1068;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridopcactive_1069;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridarrysize_1070;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridsemantic_1071;
        private System.Windows.Forms.DataGridViewTextBoxColumn griddcreadperiod_1072;
        private System.Windows.Forms.DataGridViewTextBoxColumn griddclogthreshold_1073;
        private System.Windows.Forms.DataGridViewTextBoxColumn griddcmaxpersistence_1074;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridpathpvbatch_1075;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridpathpvequipment_1076;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridpathpvprocess_1077;
    }
}

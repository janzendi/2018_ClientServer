namespace Client.forms
{
    partial class Form_SQLConnection
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mlblConnect_1098 = new MetroFramework.Controls.MetroLabel();
            this.mtxtDbPassword_1097 = new MetroFramework.Controls.MetroTextBox();
            this.mtxtDbUser_1096 = new MetroFramework.Controls.MetroTextBox();
            this.mtxtbDbTable_1095 = new MetroFramework.Controls.MetroTextBox();
            this.mlblServer_1090 = new MetroFramework.Controls.MetroLabel();
            this.mlblDbTable_1091 = new MetroFramework.Controls.MetroLabel();
            this.mlblDbUser_1092 = new MetroFramework.Controls.MetroLabel();
            this.mlblDbPassword_1093 = new MetroFramework.Controls.MetroLabel();
            this.mtxtbServer_1094 = new MetroFramework.Controls.MetroTextBox();
            this.mbtnConnect_1099 = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.mlblConnect_1098, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.mtxtDbPassword_1097, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.mtxtDbUser_1096, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.mtxtbDbTable_1095, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mlblServer_1090, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mlblDbTable_1091, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mlblDbUser_1092, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.mlblDbPassword_1093, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.mtxtbServer_1094, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mbtnConnect_1099, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 370);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mlblConnect_1098
            // 
            this.mlblConnect_1098.AutoSize = true;
            this.mlblConnect_1098.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlblConnect_1098.Location = new System.Drawing.Point(3, 120);
            this.mlblConnect_1098.Name = "mlblConnect_1098";
            this.mlblConnect_1098.Size = new System.Drawing.Size(222, 30);
            this.mlblConnect_1098.TabIndex = 8;
            this.mlblConnect_1098.Tag = "1098";
            this.mlblConnect_1098.Text = "mlblConnect_1098";
            // 
            // mtxtDbPassword_1097
            // 
            // 
            // 
            // 
            this.mtxtDbPassword_1097.CustomButton.Image = null;
            this.mtxtDbPassword_1097.CustomButton.Location = new System.Drawing.Point(504, 2);
            this.mtxtDbPassword_1097.CustomButton.Name = "";
            this.mtxtDbPassword_1097.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mtxtDbPassword_1097.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtDbPassword_1097.CustomButton.TabIndex = 1;
            this.mtxtDbPassword_1097.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtDbPassword_1097.CustomButton.UseSelectable = true;
            this.mtxtDbPassword_1097.CustomButton.Visible = false;
            this.mtxtDbPassword_1097.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtxtDbPassword_1097.Lines = new string[] {
        "mtxtDbPassword_1097"};
            this.mtxtDbPassword_1097.Location = new System.Drawing.Point(231, 93);
            this.mtxtDbPassword_1097.MaxLength = 32767;
            this.mtxtDbPassword_1097.Name = "mtxtDbPassword_1097";
            this.mtxtDbPassword_1097.PasswordChar = '*';
            this.mtxtDbPassword_1097.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtDbPassword_1097.SelectedText = "";
            this.mtxtDbPassword_1097.SelectionLength = 0;
            this.mtxtDbPassword_1097.SelectionStart = 0;
            this.mtxtDbPassword_1097.ShortcutsEnabled = true;
            this.mtxtDbPassword_1097.Size = new System.Drawing.Size(526, 24);
            this.mtxtDbPassword_1097.TabIndex = 7;
            this.mtxtDbPassword_1097.Tag = "1097";
            this.mtxtDbPassword_1097.Text = "mtxtDbPassword_1097";
            this.mtxtDbPassword_1097.UseSelectable = true;
            this.mtxtDbPassword_1097.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtDbPassword_1097.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxtDbUser_1096
            // 
            // 
            // 
            // 
            this.mtxtDbUser_1096.CustomButton.Image = null;
            this.mtxtDbUser_1096.CustomButton.Location = new System.Drawing.Point(504, 2);
            this.mtxtDbUser_1096.CustomButton.Name = "";
            this.mtxtDbUser_1096.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mtxtDbUser_1096.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtDbUser_1096.CustomButton.TabIndex = 1;
            this.mtxtDbUser_1096.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtDbUser_1096.CustomButton.UseSelectable = true;
            this.mtxtDbUser_1096.CustomButton.Visible = false;
            this.mtxtDbUser_1096.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtxtDbUser_1096.Lines = new string[] {
        "mtxtDbUser_1096"};
            this.mtxtDbUser_1096.Location = new System.Drawing.Point(231, 63);
            this.mtxtDbUser_1096.MaxLength = 32767;
            this.mtxtDbUser_1096.Name = "mtxtDbUser_1096";
            this.mtxtDbUser_1096.PasswordChar = '\0';
            this.mtxtDbUser_1096.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtDbUser_1096.SelectedText = "";
            this.mtxtDbUser_1096.SelectionLength = 0;
            this.mtxtDbUser_1096.SelectionStart = 0;
            this.mtxtDbUser_1096.ShortcutsEnabled = true;
            this.mtxtDbUser_1096.Size = new System.Drawing.Size(526, 24);
            this.mtxtDbUser_1096.TabIndex = 6;
            this.mtxtDbUser_1096.Tag = "1096";
            this.mtxtDbUser_1096.Text = "mtxtDbUser_1096";
            this.mtxtDbUser_1096.UseSelectable = true;
            this.mtxtDbUser_1096.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtDbUser_1096.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtxtbDbTable_1095
            // 
            // 
            // 
            // 
            this.mtxtbDbTable_1095.CustomButton.Image = null;
            this.mtxtbDbTable_1095.CustomButton.Location = new System.Drawing.Point(504, 2);
            this.mtxtbDbTable_1095.CustomButton.Name = "";
            this.mtxtbDbTable_1095.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mtxtbDbTable_1095.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtbDbTable_1095.CustomButton.TabIndex = 1;
            this.mtxtbDbTable_1095.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtbDbTable_1095.CustomButton.UseSelectable = true;
            this.mtxtbDbTable_1095.CustomButton.Visible = false;
            this.mtxtbDbTable_1095.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtxtbDbTable_1095.Lines = new string[] {
        "mtxtbDbTable_1095"};
            this.mtxtbDbTable_1095.Location = new System.Drawing.Point(231, 33);
            this.mtxtbDbTable_1095.MaxLength = 32767;
            this.mtxtbDbTable_1095.Name = "mtxtbDbTable_1095";
            this.mtxtbDbTable_1095.PasswordChar = '\0';
            this.mtxtbDbTable_1095.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtbDbTable_1095.SelectedText = "";
            this.mtxtbDbTable_1095.SelectionLength = 0;
            this.mtxtbDbTable_1095.SelectionStart = 0;
            this.mtxtbDbTable_1095.ShortcutsEnabled = true;
            this.mtxtbDbTable_1095.Size = new System.Drawing.Size(526, 24);
            this.mtxtbDbTable_1095.TabIndex = 5;
            this.mtxtbDbTable_1095.Tag = "1095";
            this.mtxtbDbTable_1095.Text = "mtxtbDbTable_1095";
            this.mtxtbDbTable_1095.UseSelectable = true;
            this.mtxtbDbTable_1095.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtbDbTable_1095.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mlblServer_1090
            // 
            this.mlblServer_1090.AutoSize = true;
            this.mlblServer_1090.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlblServer_1090.Location = new System.Drawing.Point(3, 0);
            this.mlblServer_1090.Name = "mlblServer_1090";
            this.mlblServer_1090.Size = new System.Drawing.Size(222, 30);
            this.mlblServer_1090.TabIndex = 0;
            this.mlblServer_1090.Tag = "1090";
            this.mlblServer_1090.Text = "mlblServer_1090";
            // 
            // mlblDbTable_1091
            // 
            this.mlblDbTable_1091.AutoSize = true;
            this.mlblDbTable_1091.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlblDbTable_1091.Location = new System.Drawing.Point(3, 30);
            this.mlblDbTable_1091.Name = "mlblDbTable_1091";
            this.mlblDbTable_1091.Size = new System.Drawing.Size(222, 30);
            this.mlblDbTable_1091.TabIndex = 1;
            this.mlblDbTable_1091.Tag = "1091";
            this.mlblDbTable_1091.Text = "mlblDbTable_1091";
            // 
            // mlblDbUser_1092
            // 
            this.mlblDbUser_1092.AutoSize = true;
            this.mlblDbUser_1092.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlblDbUser_1092.Location = new System.Drawing.Point(3, 60);
            this.mlblDbUser_1092.Name = "mlblDbUser_1092";
            this.mlblDbUser_1092.Size = new System.Drawing.Size(222, 30);
            this.mlblDbUser_1092.TabIndex = 2;
            this.mlblDbUser_1092.Tag = "1092";
            this.mlblDbUser_1092.Text = "mlblDbUser_1092";
            // 
            // mlblDbPassword_1093
            // 
            this.mlblDbPassword_1093.AutoSize = true;
            this.mlblDbPassword_1093.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlblDbPassword_1093.Location = new System.Drawing.Point(3, 90);
            this.mlblDbPassword_1093.Name = "mlblDbPassword_1093";
            this.mlblDbPassword_1093.Size = new System.Drawing.Size(222, 30);
            this.mlblDbPassword_1093.TabIndex = 3;
            this.mlblDbPassword_1093.Tag = "1093";
            this.mlblDbPassword_1093.Text = "mlblDbPassword_1093";
            // 
            // mtxtbServer_1094
            // 
            // 
            // 
            // 
            this.mtxtbServer_1094.CustomButton.Image = null;
            this.mtxtbServer_1094.CustomButton.Location = new System.Drawing.Point(504, 2);
            this.mtxtbServer_1094.CustomButton.Name = "";
            this.mtxtbServer_1094.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.mtxtbServer_1094.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtxtbServer_1094.CustomButton.TabIndex = 1;
            this.mtxtbServer_1094.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtxtbServer_1094.CustomButton.UseSelectable = true;
            this.mtxtbServer_1094.CustomButton.Visible = false;
            this.mtxtbServer_1094.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mtxtbServer_1094.Lines = new string[] {
        "mtxtbServer_1094"};
            this.mtxtbServer_1094.Location = new System.Drawing.Point(231, 3);
            this.mtxtbServer_1094.MaxLength = 32767;
            this.mtxtbServer_1094.Name = "mtxtbServer_1094";
            this.mtxtbServer_1094.PasswordChar = '\0';
            this.mtxtbServer_1094.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtxtbServer_1094.SelectedText = "";
            this.mtxtbServer_1094.SelectionLength = 0;
            this.mtxtbServer_1094.SelectionStart = 0;
            this.mtxtbServer_1094.ShortcutsEnabled = true;
            this.mtxtbServer_1094.Size = new System.Drawing.Size(526, 24);
            this.mtxtbServer_1094.TabIndex = 4;
            this.mtxtbServer_1094.Tag = "1094";
            this.mtxtbServer_1094.Text = "mtxtbServer_1094";
            this.mtxtbServer_1094.UseSelectable = true;
            this.mtxtbServer_1094.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtxtbServer_1094.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbtnConnect_1099
            // 
            this.mbtnConnect_1099.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mbtnConnect_1099.Location = new System.Drawing.Point(231, 123);
            this.mbtnConnect_1099.Name = "mbtnConnect_1099";
            this.mbtnConnect_1099.Size = new System.Drawing.Size(526, 24);
            this.mbtnConnect_1099.TabIndex = 9;
            this.mbtnConnect_1099.Tag = "1099";
            this.mbtnConnect_1099.Text = "mbtnConnect_1099";
            this.mbtnConnect_1099.UseSelectable = true;
            this.mbtnConnect_1099.Click += new System.EventHandler(this.mbtnConnect_1099_Click);
            // 
            // Form_SQLConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_SQLConnection";
            this.Tag = "1089";
            this.Text = "Form_SQLConnection_1089";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        #region customInit

        private void CustomInitializeComponent(MetroFramework.Components.MetroStyleManager metroStyleManager)
        {
            // FORM
            this.StyleManager = metroStyleManager;

            //
            // Stylemanager
            //
            this.mlblConnect_1098.StyleManager = metroStyleManager;
            this.mlblDbPassword_1093.StyleManager = metroStyleManager;
            this.mlblDbTable_1091.StyleManager = metroStyleManager;
            this.mlblDbUser_1092.StyleManager = metroStyleManager;
            this.mlblServer_1090.StyleManager = metroStyleManager;
            
            this.mtxtbDbTable_1095.StyleManager = metroStyleManager;
            this.mtxtbServer_1094.StyleManager = metroStyleManager;
            this.mtxtDbPassword_1097.StyleManager = metroStyleManager;
            this.mtxtDbUser_1096.StyleManager = metroStyleManager;

            this.mbtnConnect_1099.StyleManager = metroStyleManager;

            //
            // Tooltip
            //
            metroToolTip = new MetroFramework.Components.MetroToolTip();
            metroToolTip.StyleManager = metroStyleManager;
                        
            //Icon definieren
            this.Icon = new System.Drawing.Icon(global.config.ConfigReadWriter.PATHICON);

            //
            // Metro Textbox aus config laden
            //
            mtxtbServer_1094.Text = global.config.ConfigReadWriter.SQLSERVER;
            mtxtbDbTable_1095.Text = global.config.ConfigReadWriter.SQLTABLENAME;
            mtxtDbUser_1096.Text = global.config.ConfigReadWriter.SQLUSERID;
            mtxtDbPassword_1097.Text = global.config.ConfigReadWriter.SQLPASSWORD;
        }


        /// <summary>
        /// Methode um Sprache umzustellen.
        /// </summary>
        /// <created>janzen_d,2018-09-11</created>
        public void ChangeLanguage(string language)
        {
            try
            {
                //Main GUI anpassen
                if (this.Tag != null && System.Int32.TryParse(this.Tag.ToString(), out int resulttextid2))
                {
                    this.Text = global.language.LanguageHandler.INSTANCE.GETOBJWORD(language, resulttextid2)[2];
                }
                global.windows.forms.FormMethods.ChangeLanguage(this.Controls, metroToolTip, language);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        //Tooltip
        private MetroFramework.Components.MetroToolTip metroToolTip;

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroTextBox mtxtDbPassword_1097;
        private MetroFramework.Controls.MetroTextBox mtxtDbUser_1096;
        private MetroFramework.Controls.MetroTextBox mtxtbDbTable_1095;
        private MetroFramework.Controls.MetroLabel mlblServer_1090;
        private MetroFramework.Controls.MetroLabel mlblDbTable_1091;
        private MetroFramework.Controls.MetroLabel mlblDbUser_1092;
        private MetroFramework.Controls.MetroLabel mlblDbPassword_1093;
        private MetroFramework.Controls.MetroTextBox mtxtbServer_1094;
        private MetroFramework.Controls.MetroLabel mlblConnect_1098;
        private MetroFramework.Controls.MetroButton mbtnConnect_1099;
    }
}
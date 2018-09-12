namespace Client.global.readme.metroui
{
    partial class LicenseMetroUI
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
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(20, 60);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(972, 370);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            this.richTextBox.WordWrap = false;
            // 
            // LicenseMetroUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 450);
            this.Controls.Add(this.richTextBox);
            this.Name = "LicenseMetroUI";
            this.Tag = "1015";
            this.Text = "MetroUI_1015";
            this.ResumeLayout(false);

        }

        #endregion

        #region customInit

        private void CustomInitializeComponent()
        {
            richTextBox.ReadOnly = true;
            richTextBox.LoadFile(config.ConfigReadWriter.PATHMETROUILICENSEREADME);
            ChangeLanguage(config.ConfigReadWriter.LANGUAGE); // Sprache aus config file lesen.
            
            //Icon definieren
            this.Icon = new System.Drawing.Icon(config.ConfigReadWriter.PATHICON);
        }


        /// <summary>
        /// Methode um Sprache umzustellen.
        /// </summary>
        /// <created>janzen_d,2018-09-11</created>
        private void ChangeLanguage(string language)
        {
            try
            {
                //Main GUI anpassen
                if (this.Tag != null && System.Int32.TryParse(this.Tag.ToString(), out int resulttextid2))
                {
                    string[] arytmp2 = global.language.LanguageHandler.INSTANCE.GETOBJWORD(language, resulttextid2);
                    this.Text = arytmp2[2];
                }
                // alle tags lesen und mit den richtigen Sprachen beschreiben.
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                        System.Collections.Generic.List<System.Windows.Forms.Control> list = new System.Collections.Generic.List<System.Windows.Forms.Control>();
                        GetAllControls(this, list);
                        foreach (System.Windows.Forms.Control itemcontrol in list)
                        {
                            if (itemcontrol.Tag != null && System.Int32.TryParse(itemcontrol.Tag.ToString(), out int resulttextid))
                            {
                                string[] arytmp = global.language.LanguageHandler.INSTANCE.GETOBJWORD(language, resulttextid);
                                itemcontrol.Text = arytmp[2];
                                (new System.Windows.Forms.ToolTip()).SetToolTip(itemcontrol, arytmp[0]);
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
        /// /// <created>janzen_d,2018-09-11</created>
        private System.Collections.Generic.List<System.Windows.Forms.Control> GetAllControls(System.Windows.Forms.Control container, System.Collections.Generic.List<System.Windows.Forms.Control> list)
        {
            foreach (System.Windows.Forms.Control c in container.Controls)
            {
                if (c is System.Windows.Forms.TabPage
                    || c is MetroFramework.Controls.MetroLabel) list.Add(c); // TODO or all controls.
                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
            }
            return list;
        }
        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
    }
}
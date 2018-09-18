
namespace Client.global.windows.forms
{
    static class FormMethods
    {
        /// <summary>
        /// Methode wurde in global verschoben um es zu vereinheitlichen.
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="metroToolTip"></param>
        /// <param name="language"></param>
        /// <created>janzen_d,2018-09-13</created>
        public static void ChangeLanguage(System.Windows.Forms.Control.ControlCollection controls, MetroFramework.Components.MetroToolTip metroToolTip, string language)
        {
            try
            {
                // alle tags lesen und mit den richtigen Sprachen beschreiben.
                foreach (System.Windows.Forms.Control control in controls)
                {
                    System.Collections.Generic.List<System.Windows.Forms.Control> list = new System.Collections.Generic.List<System.Windows.Forms.Control>();
                    GetAllControls(control, list);
                    foreach (System.Windows.Forms.Control itemcontrol in list)
                    {
                        if (itemcontrol.Tag != null && System.Int32.TryParse(itemcontrol.Tag.ToString(), out int resulttextid))
                        {
                            string[] arytmp = global.language.LanguageHandler.INSTANCE.GETOBJWORD(language, resulttextid);
                            if (arytmp[2] != null || arytmp[2] != "")
                            {
                                if (itemcontrol is panel.TW_AD)
                                    ((panel.TW_AD)itemcontrol).ChangeLanguage(language);
                                if (arytmp[2].Length > 2)
                                    itemcontrol.Text = arytmp[2];
                                global.log.MetroLog.INSTANCE.DebugWriteLine("Set control text: " + itemcontrol.Name.ToString() + " = " + arytmp[2], global.log.MetroLog.LogType.INFO);
                                if (arytmp[0] != null || arytmp[0] != "")
                                {
                                    metroToolTip.SetToolTip(itemcontrol, arytmp[0]);
                                    global.log.MetroLog.INSTANCE.DebugWriteLine("Set control tool tip text: " + itemcontrol.Name.ToString() + " = " + arytmp[0], global.log.MetroLog.LogType.INFO);
                                }
                            }
                        }
                        else if(itemcontrol is MetroFramework.Controls.MetroGrid)
                        {
                            foreach (System.Windows.Forms.DataGridViewColumn itemcolumn in ((MetroFramework.Controls.MetroGrid)itemcontrol).Columns)
                            {
                                if (itemcolumn.Tag != null && System.Int32.TryParse(itemcolumn.Tag.ToString(), out int resultcolumntextid))
                                {
                                    string[] arytmp = global.language.LanguageHandler.INSTANCE.GETOBJWORD(language, resultcolumntextid);
                                    if (arytmp[2] != null || arytmp[2] != "")
                                    {
                                        if (arytmp[2].Length > 2)
                                            itemcolumn.HeaderText = arytmp[2];
                                        global.log.MetroLog.INSTANCE.DebugWriteLine("Set control text: " + itemcolumn.Name.ToString() + " = " + arytmp[2], global.log.MetroLog.LogType.INFO);
                                        if (arytmp[0] != null || arytmp[0] != "")
                                        {
                                            itemcolumn.ToolTipText = arytmp[0];
                                            global.log.MetroLog.INSTANCE.DebugWriteLine("Set control tool tip text: " + itemcolumn.Name.ToString() + " = " + arytmp[0], global.log.MetroLog.LogType.INFO);
                                        }
                                    }
                                }
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
        /// <created>janzen_d,2018-09-11</created>
        /// <modified>janzen_d,2018-09-13: Nach global verschoben</modified>
        private static System.Collections.Generic.List<System.Windows.Forms.Control> GetAllControls(System.Windows.Forms.Control c, System.Collections.Generic.List<System.Windows.Forms.Control> list)
        {
            if (c.Controls.Count == 0 || c is MetroFramework.Controls.MetroTextBox || c is MetroFramework.Controls.MetroGrid) //
            {
                if (c is System.Windows.Forms.TabPage
                    || c is MetroFramework.Controls.MetroLabel
                    || c is MetroFramework.Controls.MetroTextBox
                    || c is MetroFramework.Controls.MetroButton
                    || c is MetroFramework.Controls.MetroGrid
                    || c is MetroFramework.Controls.MetroTile
                    || c is panel.TW_AD) list.Add(c); // TODO or all controls.
            }
            else
            {
                if (c.Tag != null) list.Add(c);
                foreach (System.Windows.Forms.Control control in c.Controls)
                    list = GetAllControls(control, list);
            }
            return list;
        }
    }
}

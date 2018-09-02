using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Object
{
    #region base
    abstract class GroupLblTxt : FlowLayoutPanel
    {
        private Label lbl;
        private ComboBox cmbBox;

        public string GetTEXT
        {
            get
            {
                return cmbBox.Text.ToString();
            }
        }

        protected string CMBBOXTEXT
        {
            set
            {
                if (this.CMBBOXNOTEDITABLE)
                    cmbBox.Items.Add(value);
                int i = cmbBox.Items.IndexOf(value);
                if (i == -1)
                    cmbBox.SelectedIndex = 0;
                else
                    cmbBox.SelectedIndex = i;
            }
        }

        protected bool CMBBOXNOTEDITABLE
        {
            set
            {
                if (value)
                    cmbBox.DropDownStyle = ComboBoxStyle.DropDown; 
                else
                    cmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            get
            {
                if (cmbBox.DropDownStyle == ComboBoxStyle.DropDownList)
                    return false;
                return true;
            }
        }

        protected GroupLblTxt(string lblText, string selectedText, string[] listInput_optional = null, bool cmbEditable_optional = true, int cmbWidth_optional = 0)
        {
            AutoSize = true;

            lbl = new Label();
            lbl.Text = lblText;
            lbl.AutoSize = true;
            lbl.Anchor = AnchorStyles.Left;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Controls.Add(lbl);
            cmbBox = new ComboBox();
            CMBBOXNOTEDITABLE = cmbEditable_optional;
            if (cmbWidth_optional != 0)
                cmbBox.Width = cmbWidth_optional;
            //cmbBox.SelectedIndexChanged += CmbBox_SelectedIndexChanged; //TODO to update the config files
            if (listInput_optional != null)
                cmbBox.Items.AddRange(listInput_optional);
            CMBBOXTEXT = selectedText;
           // if (cmbBox.Items.Count > 0) //TODO kann ggf. gelöscht werden wenn die Zeile oben drüber funktioniert.
             //   cmbBox.SelectedIndex = 0;
            Controls.Add(cmbBox);
        }
    }
    #endregion

    #region GroupLblTxtVolumeName
    class GroupLblTxtVolumeName : GroupLblTxt
    {
        public GroupLblTxtVolumeName(string lblText, string selectedText, string[] listInput_optional = null, bool cmbEditable_optional = true, int cmbWidth_optional = 0) :base(lblText, selectedText, listInput_optional, cmbEditable_optional, cmbWidth_optional) {}
    }
    #endregion

    #region GroupLblTxtDriveLetter
    class GroupLblTxtDriveLetter : GroupLblTxt
    {
        public GroupLblTxtDriveLetter(string lblText, string selectedText, string[] listInput) : base(lblText, selectedText, listInput, false, 45) {}
    }
    #endregion

    #region GroupLblTxtNetworkPath
    class GroupLblTxtNetworkPath : GroupLblTxt
    {
        public GroupLblTxtNetworkPath(string lblText, string selectedText) : base(lblText, selectedText) { }
    }
    #endregion

    #region GroupLblTxtUsername
    class GroupLblTxtUsername : GroupLblTxt
    {
        public GroupLblTxtUsername(string lblText, string selectedText) : base(lblText, selectedText) { }
    }
    #endregion

    #region GroupLblTxtPassword
    class GroupLblTxtPassword : GroupLblTxt
    {
        public GroupLblTxtPassword(string lblText, string selectedText) : base(lblText, selectedText) { }
    }
    #endregion
}

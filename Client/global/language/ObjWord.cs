using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.global.language
{
    class ObjWord
    {
        private List<string> lstToolTip;
        private List<string> lstObjType;
        private List<string> lstText;

        public ObjWord(string de_ToolTip, string de_ObjType, string de_Text, string en_ToolTip, string en_ObjType, string en_Text)
        {
            lstToolTip = new List<string>() { de_ToolTip, en_ToolTip };
            lstObjType = new List<string>() { de_ObjType, en_ObjType };
            lstText = new List<string>() { de_Text, en_Text };
        }
        
    }
}

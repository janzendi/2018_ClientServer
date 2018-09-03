using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.global.language
{
    class ObjWord
    {
        private string strToolTip;
        private string strObjType;
        private string strText;
        private int id;

        public ObjWord(string strToolTip, string strObjType, string strText, int id)
        {
            this.strObjType = strObjType;
            this.strText = strText;
            this.strToolTip = strToolTip;
            this.id = id;
        }
    }
}

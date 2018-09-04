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

        /// <summary>
        /// Eigenschaft Zugriff auf Tooltip
        /// </summary>
        /// <created>janzen_d,2018-09-04</created>
        public string TOOLTIP
        {
            get { return strToolTip; }
        }

        /// <summary>
        /// Eigenschaft Zugriff auf object type
        /// </summary>
        /// <created>janzen_d,2018-09-04</created>
        public string OBJTYPE
        {
            get { return strObjType; }
        }

        /// <summary>
        /// Eigenschaft Zugriff auf Text
        /// </summary>
        /// <created>janzen_d,2018-09-04</created>
        public string TEXT
        {
            get { return strText; }
        }

        /// <summary>
        /// Eigenschaft Zugriff auf ID
        /// </summary>
        /// <created>janzen_d,2018-09-04</created>
        public int ID
        {
            get { return id; }
        }
    }
}

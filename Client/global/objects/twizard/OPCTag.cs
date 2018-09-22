using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.global.objects.twizard
{
    class OPCTag
    {
        #region Konstruktoren
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public OPCTag()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variablename"></param>
        /// <created>janzen_d,2018-09-22</created>
        public OPCTag(string variablename)
        {
            this.strvariablename = variablename;
        }
        #endregion

        #region Variablen mit Setter Eigenschalften
        private int listid;
        /// <summary>
        /// List ID
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public int LISTID
        {
            set
            {
                this.listid = value;
            }
        }

        private string strmodulename;
        /// <summary>
        /// Modulname setzen. Es muss der komplette Pfad übergeben werden und es wird der letzte Ordner als Modulname benutzt
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public object MODULENAME
        {
            set
            {
                string[] arrPathSplit = value.ToString().Split(new Char[] { '\\' });
                this.strmodulename = arrPathSplit[arrPathSplit.Length - 1];
            }
        }

        private string strvariablename;
        /// <summary>
        /// Variablenname aus pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string VARIABLENAME
        {
            set
            {
                this.strvariablename = value;
            }
            get
            {
                if (strvariablename != null)
                    return strvariablename;
                return String.Empty;
            }
        }

        private string strcmt;
        /// <summary>
        /// Kommentar aus pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string COMMENT
        {
            set
            {
                this.strcmt = value;
            }
        }

        private int inttextid;
        /// <summary>
        /// TextID aus pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string TEXTID
        {
            set
            {
                if (System.Int32.TryParse(value, out int result))
                    this.inttextid = result;
                else
                    this.inttextid = 0;
            }
        }

        private bool opcactive;
        /// <summary>
        /// OPC aktiviert aus pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string OPCACTIVE
        {
            set
            {
                switch (value)
                {
                    case "0":
                        this.opcactive = false;
                        break;
                    case "1":
                        this.opcactive = true;
                        break;
                    default:
                        this.opcactive = false;
                        break;
                }
            }
            get
            {
                if (opcactive)
                    return "1";
                else
                    return "0";
            }
        }

        private string stropcDataType;
        /// <summary>
        /// OPC Datentyp aus pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string OPCDATATYPE
        {
            set
            {
                this.stropcDataType = value;
            }
        }

        private int intopcrwu;
        /// <summary>
        /// Schreib Leserechte für OPC Server in pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string OPCRWU
        {
            set
            {
                if (System.Int32.TryParse(value, out int result))
                    this.intopcrwu = result;
                else
                    this.intopcrwu = 0;
            }
        }

        private string stropcalias;
        /// <summary>
        /// OPC alias in pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string OPCALIAS
        {
            set
            {
                this.stropcalias = value;
            }
        }

        private string strsemantic;
        /// <summary>
        /// OPC semantic in pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string SEMANTIC
        {
            set
            {
                this.strsemantic = value;
            }
        }

        private string strdcreadperiod;
        /// <summary>
        /// datacollector read period in pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string DCREADPERIOD
        {
            set
            {
                this.strdcreadperiod = value;
            }
        }

        private string strlogthreshold;
        /// <summary>
        /// datacollector log threshold in pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string LOGTHRESHOLD
        {
            set
            {
                this.strlogthreshold = value;
            }
        }

        private string strdcmaxpersistence;
        /// <summary>
        /// Data Collector max persistence in pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string DCMAXPERSISTENCE
        {
            set
            {
                this.strdcmaxpersistence = value;
            }
        }

        private string strpvprocesspath;
        /// <summary>
        /// pv_process Pfad
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string PVPROCESSPATH
        {
            set
            {
                this.strpvprocesspath = value;
            }
        }

        private int intpdacountertype;
        /// <summary>
        /// BDE Counter Typ aus pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string PDACOUNTERTYPE
        {
            set
            {
                if (System.Int32.TryParse(value, out int result))
                    this.intpdacountertype = result;
                else
                    this.intpdacountertype = 0;
            }
        }

        private int intarrysize;
        /// <summary>
        /// BDE Counter Typ aus pv_process
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string ARRAYSIZE
        {
            set
            {
                if (System.Int32.TryParse(value, out int result))
                    this.intarrysize = result;
                else
                    this.intarrysize = 1;
            }
        }

        private string strpvequipmentpath;
        /// <summary>
        /// pv_process Pfad
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string PVEQUIPMENTPATH
        {
            set
            {
                this.strpvequipmentpath = value;
            }
        }
        #endregion

        #region Rückgabe Methoden und Eigenschaften
        /// <summary>
        /// Gibt eine Zeile zurück.
        /// </summary>
        /// <created>janzen_d,2018-09-22</created>
        public string[] GetGridRow
        {
            get
            {
                try
                {
                    return new string[] { listid.ToString(),
                        strmodulename,
                        strvariablename,
                        null,
                        intpdacountertype.ToString(),
                        inttextid.ToString(),
                        strcmt,
                        stropcDataType,
                        intopcrwu.ToString(),
                        stropcalias,
                        OPCACTIVE,
                        intarrysize.ToString(),
                        strsemantic,
                        strdcreadperiod,
                        strlogthreshold,
                        strdcmaxpersistence,
                        null,
                        strpvequipmentpath,
                        strpvprocesspath};
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Überschreibt die Equals Methode damit List<>.contains anhand von dem Variablennamen funktioniert.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true = falls Variablennamen übereinstimmt</returns>
        /// <created>janzen_d,2018-09-22</created>
        public override bool Equals(object obj)
        {
            if (obj is OPCTag)
            {
                if (((OPCTag)obj).strvariablename == this.strvariablename)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Wird benötigt, da Equals überschrieben wird.
        /// </summary>
        /// <returns></returns>
        /// <created>janzen_d,2018-09-22</created>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}

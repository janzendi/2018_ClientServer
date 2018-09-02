using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Config.XML.Language
{
    class XMLLanguage :XMLBASE
    {
        public XMLLanguage() : base(Client.Properties.Settings.LANGUAGEFILE)
        {

        }
    }
}

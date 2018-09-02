using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace Client.Config.XML.Alarms
{
    class XMLAlarms :XMLBASE
    {
        private static XMLBASE instance;

        private XMLAlarms() :base(Client.Properties.Settings.ALARMFILE)
        {
            
        }
    }
}

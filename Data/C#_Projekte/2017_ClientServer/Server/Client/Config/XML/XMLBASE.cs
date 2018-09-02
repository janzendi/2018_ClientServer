using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace Client.Config.XML
{
    class XMLBASE
    {
        protected XmlDocument xmldoc;
        protected string fileversion;

        protected XMLBASE(string filepath)
        {
            xmldoc = new XmlDocument();
            xmldoc.Load(filepath);

        }


    }
}

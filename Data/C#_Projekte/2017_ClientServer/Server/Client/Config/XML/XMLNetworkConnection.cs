using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Config.XML
{
    class XMLNetworkConnection
    {
        private string description;
        private string letter;
        private string user;
        private string password;
        private string networkpath;

        public XMLNetworkConnection(string description, string letter, string user, string password, string networkpath)
        {
            this.description = description;
            this.letter = letter;
            this.user = user;
            this.password = password;
            this.networkpath = networkpath;
        }

        public string DESCRIPTION
        {
            get
            {
                return description;
            }
        }
        public string LETTER
        {
            get
            {
                return letter;
            }
        }
        public string USER
        {
            get
            {
                return user;
            }
        }
        public string PASSWORD
        {
            get
            {
                return password;
            }
        }
        public string NETWORKPATH
        {
            get
            {
                return networkpath;
            }
        }
    }
}

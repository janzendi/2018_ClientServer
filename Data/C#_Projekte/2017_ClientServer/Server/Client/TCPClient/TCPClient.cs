using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTCP;

namespace Client.TCPClient
{
    class TCPClient
    {
        private SimpleTcpClient client;
        public TCPClient()
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataRecieved;

            // try to connect to server
            try
            {
                client.Connect(Client.Properties.Settings.SERVERIPADDRESS, Client.Properties.Settings.SERVERPORT);
                Log.LogFile.INSTANCE.WriteLine(Client.Properties.Settings.SERVERIPADDRESS + ":" + Client.Properties.Settings.SERVERPORT);
                Log.LogFile.INSTANCE.WriteLine(client.TcpClient.Connected.ToString());
            }
            catch (System.Net.Sockets.SocketException)
            {
                Log.LogFile.INSTANCE.WriteLine("Not possible connect to " + Client.Properties.Settings.SERVERIPADDRESS + ":" + Client.Properties.Settings.SERVERPORT);
            }
        }

        private void Client_DataRecieved(object sender, SimpleTCP.Message e)
        {
            Log.LogFile.INSTANCE.WriteLine(e.MessageString);
        }
    }
}

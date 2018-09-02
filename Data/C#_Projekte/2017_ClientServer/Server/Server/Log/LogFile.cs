using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Log
{
    class LogFile
    {
        private static LogFile instance;
        private ListBox listBox_Info;

        private LogFile() { }
        public void SetListBox(ListBox listBox)
        {
            listBox_Info = listBox;
            instance = LogFile.INSTANCE;
        }

        public static LogFile INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogFile();
                }
                return instance;
            }
        }

        public delegate void dgWriteLine(String value);
        public void WriteLine(String value)
        {
            if (listBox_Info.InvokeRequired)
            {
                listBox_Info.BeginInvoke(new dgWriteLine(WriteLine), new object[] { value });
            }
            else
            {
                listBox_Info.Items.Add(value);
                if (listBox_Info.Items.Count > 200)
                {
                    listBox_Info.Items.RemoveAt(
                                      listBox_Info.Items.Count - 1);
                }
            }
        }

        public delegate void dgDebugWriteLine(String value);
        public void DebugWriteLine(String value)
        {
            
            if (listBox_Info.InvokeRequired)
            {
                listBox_Info.BeginInvoke(new dgDebugWriteLine(WriteLine), new object[] { value });
            }
            else
            {
                listBox_Info.Items.Add(value);
                if (listBox_Info.Items.Count > 200)
                {
                    listBox_Info.Items.RemoveAt(
                                      listBox_Info.Items.Count - 1);
                }
            }
        }
    }
}

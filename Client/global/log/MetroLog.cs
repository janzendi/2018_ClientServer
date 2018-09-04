using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Client.global.log
{
    /// <summary>
    /// LogFile Klasse übernimmt die Aufgabe Informationen in einem zentralisiertem Textfeld auszugeben und eine logdatei zu schreiben.
    /// </summary>
    /// <pattern>Singleton</pattern>
    /// <created>janzen_d,2018-09-02</created>
    class MetroLog
    {
        private static MetroLog instance;
        private RichTextBox Console_Info;
        private static XmlDocument xmlDoc;
        private static XmlNode rootNode;
        private static string xmltimestamp;

        //Tool Strip
        private ToolStripStatusLabel lblProgessBar;
        private ToolStripProgressBar pBarProgress;

        private MetroLog() { }

        /// <summary>
        /// Sinleton-Pattern Eigenschaft
        /// </summary>
        /// <created>janzen_d,2018-09-02</created>
        public static MetroLog INSTANCE
        {
            get
            {
                if (instance == null)
                {
                    instance = new MetroLog();
                    xmltimestamp = "\\log_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xml";
                    xmlDoc = new XmlDocument();
                    rootNode = xmlDoc.CreateElement("logifle");
                    xmlDoc.AppendChild(rootNode);
                }
                return instance;
            }
        }

        /// --------------------------------------------------------------------------------
        /// <summary>
        /// SetConsole() dient dazu ein Objekt zu übergeben, um die Textausgabe zentralisiert zu bedienen.
        /// </summary>
        /// <param name="listBox">Objekt RichTextBox muss übergeben werden.</param>
        /// <created>janzen_d,2018-09-02</created>
        /// --------------------------------------------------------------------------------
        public void SetConsole(RichTextBox listBox, ToolStripStatusLabel lblProgessBar, ToolStripProgressBar pBarProgress)
        {
            try
            {
                if (Console_Info == null)
                {
                    Console_Info = listBox;
                    Console_Info.Multiline = true;
                    Console_Info.WordWrap = false;
                    Console_Info.AppendText(Environment.NewLine); // Wegen der Architektur von der Methode Write(string) muss eine Zeile hinzugefügt werden.
                    instance = MetroLog.INSTANCE;
                    Console_Info.Multiline = true;
                    Console_Info.AcceptsTab = true;

                    if (!System.IO.Directory.Exists(config.ConfigReadWriter.LOGPATH))
                        System.IO.Directory.CreateDirectory(config.ConfigReadWriter.LOGPATH);
                    WriteLine("LogFile-System initialized");

                    this.lblProgessBar = lblProgessBar;
                    lblProgessBar.Text = "Ready";
                    this.pBarProgress = pBarProgress;
                }
            }
            catch (Exception e)
            {
                if (Console_Info != null)
                    DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
                else
                {
                    string tmp = "ERROR: Class LogFile could not create. Please contact the developer and forward file \"LOGEXCEPTION.txt\" in the main application folder." + " EXCEPTION INFORMATION: " + e.ToString();
                    MessageBox.Show(tmp);
                    TextWriter txtFile = new StreamWriter("LOGEXCEPTION.txt");
                    txtFile.Write(tmp);
                    txtFile.Close();
                }
            }
        }

        /// <summary>
        /// Destuktor der Klasse LogFile
        /// Er schreib ein logfile im definiertem log Ordner.
        /// </summary>
        /// <created>janzen_d,2018-09-02</created>
        ~MetroLog()
        {
            try
            {
                xmlDoc.Save(config.ConfigReadWriter.LOGPATH + xmltimestamp);
            }
            catch (Exception e)
            {
                string tmp = "ERROR: Class LogFile could not destruct and log file could not be saved. Please contact the developer and forward file \"LOGEXCEPTION.txt\" in the main application folder." + " EXCEPTION INFORMATION: " + e.ToString();
                //MessageBox.Show(tmp);
                TextWriter txtFile = new StreamWriter("LOGEXCEPTION.txt");
                txtFile.Write(tmp);
                txtFile.Close();
            }
        }

        public delegate void dgWriteLine(String value);
        /// <summary>
        /// Öffetliche Methode zur Textausgabe.
        /// </summary>
        /// <param name="value">String zur Textausgabe.</param>
        /// <created>janzen_d,2017-12-28</created>
        public void WriteLine(String value)
        {
            try
            {
                if (Console_Info.InvokeRequired) //Threadprogrammierung um zu verhindern, das ein anderer Prozess gleichzeitig auf das Objekt zugreift.
                {
                    Console_Info.BeginInvoke(new dgWriteLine(WriteLine), new object[] { value });
                }
                else
                    Write(value, true);
            }
            catch (Exception e)
            {
                string tmp = "ERROR: Log data could not be written. Please contact the developer and forward file \"LOGEXCEPTION.txt\" in the main application folder." + " Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString();
                MessageBox.Show(tmp);
                TextWriter txtFile = new StreamWriter("LOGEXCEPTION.txt");
                txtFile.Write(tmp);
                txtFile.Close();
            }
        }

        public delegate void dgDebugWriteLine(String value);
        /// <summary>
        /// Öffetliche Methode zur zusätzlichen Textausgabe.
        /// </summary>
        /// <param name="value">String zur Textausgabe.</param>
        /// <created>janzen_d,2017-12-28</created>
        public void DebugWriteLine(String value)
        {
            try
            {
                if (Console_Info.InvokeRequired) //Threadprogrammierung um zu verhindern, das ein anderer Prozess gleichzeitig auf das Objekt zugreift.
                {
                    Console_Info.BeginInvoke(new dgDebugWriteLine(DebugWriteLine), new object[] { value });
                }
                else
                    Write(value, config.ConfigReadWriter.DEBUGENABLED);
            }
            catch (Exception e)
            {
                string tmp = "ERROR: Log data could not be written. Please contact the developer and forward file \"LOGEXCEPTION.txt\" in the main application folder." + " Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString();
                MessageBox.Show(tmp);
                TextWriter txtFile = new StreamWriter("LOGEXCEPTION.txt");
                txtFile.Write(tmp);
                txtFile.Close();
            }
        }

        /// <summary>
        /// Private Methode zur einheitlichen Textausgabe.
        /// </summary>
        /// <param name="value">String zur Textausgabe.</param>
        /// <created>janzen_d,2017-12-28</created>
        private void Write(string value, bool onlyLogFile)
        {

            if (Console_Info.Text[Console_Info.Text.Length - 1] != '\n')
            {
                if (onlyLogFile)
                    Console_Info.AppendText(Environment.NewLine);
            }
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //write to xml
            XmlNode userNode = xmlDoc.CreateElement("log");
            XmlAttribute attribute = xmlDoc.CreateAttribute("timestamp");
            attribute.Value = timestamp;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = value;
            rootNode.AppendChild(userNode);

            timestamp += ":\t";
            if (onlyLogFile)
            {
                Console_Info.SelectionColor = Color.Blue;
                Console_Info.AppendText(timestamp);
                Console_Info.SelectionColor = Color.Black;
                Console_Info.AppendText(value);
            }
            Console_Info.ScrollToCaret();
        }

        public void ProgressBar(decimal divident, string text)
        {
            try
            {
                lblProgessBar.Text = text;
                int temp = (int)(divident * 100);
                pBarProgress.Value = temp;
                if (pBarProgress.Value == 100)
                {
                    pBarProgress.Value = 0;
                    lblProgessBar.Text = "Ready";
                }
            }
            catch (Exception exception)
            {
                global.log.MetroLog.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }
    }
}

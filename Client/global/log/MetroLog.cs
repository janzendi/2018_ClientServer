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
        public enum LogType
        {
            ERROR = 0,
            WARNING = 1,
            INFO = 2
        }
        private static MetroLog instance;
        private RichTextBox Console_Info;
        private static XmlDocument xmlDoc;
        private static XmlNode rootNode;
        private static string xmltimestamp;

        //Tool Strip
        private ToolStripStatusLabel lblProgessBar;
        private ToolStripProgressBar pBarProgress;

        private MetroLog()
        {
            DeleteFiles(config.ConfigReadWriter.LOGPATH, config.ConfigReadWriter.KEEPLOGFILESFORXDAYS);
        }

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
                    WriteLine("LogFile-System initialized", LogType.INFO);

                    this.lblProgessBar = lblProgessBar;
                    lblProgessBar.Text = "Ready";
                    this.pBarProgress = pBarProgress;
                }
            }
            catch (Exception e)
            {
                if (Console_Info != null)
                    DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), LogType.ERROR);
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

        public delegate void dgWriteLine(String value, LogType logType, [System.Runtime.InteropServices.Optional] int textid);
        /// <summary>
        /// Öffetliche Methode zur Textausgabe.
        /// Eine übergabe einer textid wurde hinzugefügt um Fehlermeldungen in verschiedenen Sprachen auszugeben.
        /// </summary>
        /// <param name="value">String zur Textausgabe.</param>
        /// <created>janzen_d,2017-12-28</created>
        /// <modified>janzen_d,2018-09-05</modified>
        public void WriteLine(String value, LogType logType, [System.Runtime.InteropServices.Optional] int textid)
        {
            try
            {
                if (Console_Info.InvokeRequired) //Threadprogrammierung um zu verhindern, das ein anderer Prozess gleichzeitig auf das Objekt zugreift.
                {
                    Console_Info.BeginInvoke(new dgWriteLine(WriteLine), new object[] { value, logType, textid });
                }
                else
                    Write(value, true, logType, textid);
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

        public delegate void dgDebugWriteLine(String value, LogType logType, [System.Runtime.InteropServices.Optional] int textid);
        /// <summary>
        /// Öffetliche Methode zur zusätzlichen Textausgabe.
        /// Eine übergabe einer textid wurde hinzugefügt um Fehlermeldungen in verschiedenen Sprachen auszugeben.
        /// </summary>
        /// <param name="value">String zur Textausgabe.</param>
        /// <created>janzen_d,2017-12-28</created>
        /// <modified>janzen_d,2018-09-05</modified>
        public void DebugWriteLine(String value, LogType logType, [System.Runtime.InteropServices.Optional] int textid)
        {
            try
            {
                if (Console_Info.InvokeRequired) //Threadprogrammierung um zu verhindern, das ein anderer Prozess gleichzeitig auf das Objekt zugreift.
                {
                    Console_Info.BeginInvoke(new dgDebugWriteLine(DebugWriteLine), new object[] { value, logType, textid });
                }
                else
                    Write(value, config.ConfigReadWriter.DEBUGENABLED, logType, textid);
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
        /// enum type wurde hinzugefügt im Meldungen zu unterscheiden.
        /// Eine übergabe einer textid wurde hinzugefügt um Fehlermeldungen in verschiedenen Sprachen auszugeben.
        /// </summary>
        /// <param name="value">String zur Textausgabe.</param>
        /// <created>janzen_d,2017-12-28</created>
        /// <modified>janzen_d,2018-09-05</modified>
        private void Write(string value, bool onlyLogFile, LogType logType, [System.Runtime.InteropServices.Optional] int textid) // LogType hinzugefügt
        {
            //endTMP
            if (Console_Info.Text[Console_Info.Text.Length - 1] != '\n')
            {
                if (onlyLogFile || logType == LogType.ERROR)
                    Console_Info.AppendText(Environment.NewLine);
            }
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //write to xml
            XmlNode userNode = xmlDoc.CreateElement("log");
            XmlAttribute attribute = xmlDoc.CreateAttribute("timestamp");
            attribute.Value = timestamp;
            XmlAttribute attribute2 = xmlDoc.CreateAttribute("type");
            attribute2.Value = logType.ToString();
            userNode.Attributes.Append(attribute);
            userNode.Attributes.Append(attribute2);
            if (textid != 0) userNode.InnerText = global.language.LanguageHandler.INSTANCE.GETOBJWORD(textid)[2] + value;
            else userNode.InnerText = value;
            rootNode.AppendChild(userNode);

            timestamp += ":\t";
            if (onlyLogFile || logType == LogType.ERROR)
            {
                Console_Info.SelectionColor = Color.Blue;
                Console_Info.AppendText(timestamp);
                switch (logType)
                {
                    case LogType.ERROR:
                        Console_Info.SelectionColor = Color.Red;
                        Console_Info.AppendText(logType.ToString() + "\t");
                        break;
                    case LogType.WARNING:
                        Console_Info.SelectionColor = Color.OrangeRed;
                        Console_Info.AppendText(logType.ToString() + "\t");
                        break;
                    case LogType.INFO:
                        Console_Info.SelectionColor = Color.Green;
                        Console_Info.AppendText(logType.ToString() + "\t");
                        break;
                    default:
                        break;
                }
                //Console_Info.SelectionColor = Color.Black;
                Console_Info.SelectionColor = MetroFramework.MetroColors.Black;
                if (textid != 0) Console_Info.AppendText(global.language.LanguageHandler.INSTANCE.GETOBJWORD(textid)[2] + value);
                else Console_Info.AppendText(value);

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
                global.log.MetroLog.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString(), LogType.ERROR);
            }
        }

        /// <summary>
        /// Methode um Dateien zu löschen
        /// </summary>
        /// <param name="sDirectory">Pfad vom Ordner</param>
        /// <param name="iTage">Wenn Dateien älter iTage alt sind, werden diese gelöscht.</param>
        /// <created>janzen_d,2018-09-06</created>
        private void DeleteFiles(string sDirectory, int iTage)
        {
            if (iTage > 0)
            {
                DirectoryInfo di;
                FileInfo[] files;
                try
                {
                    //ermittel das Verzeichnis
                    di = new DirectoryInfo(sDirectory);

                    //existiert das Verzeichnis?
                    if (Directory.Exists(sDirectory))
                    {
                        //files = di.GetFiles("*txt");
                        files = di.GetFiles("*");

                        foreach (FileInfo fi in files)
                        {
                            //fi.CreationTime; CreationTime klappt nicht bei kopierten Dateien!
                            DateTime dtFile = fi.LastWriteTime;
                            TimeSpan t = DateTime.Now - dtFile;
                            double NrOfDays = t.TotalDays;
                            int iAlter = Convert.ToInt32(NrOfDays);

                            // Lösche die Dateien
                            if (iAlter >= iTage)
                                fi.Delete();
                        }
                    }
                    else WriteLine("(" + sDirectory + ")", LogType.ERROR, 1009);
                }
                catch (Exception e)
                {
                    global.log.MetroLog.INSTANCE.WriteLine("Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString(), global.log.MetroLog.LogType.ERROR);
                }
            }
        }
    }
}

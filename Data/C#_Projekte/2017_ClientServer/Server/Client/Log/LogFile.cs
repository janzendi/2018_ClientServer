using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Client.Log
{
    /// <summary>
    /// LogFile Klasse übernimmt die Aufgabe Informationen in einem zentralisiertem Textfeld auszugeben und eine logdatei zu schreiben.
    /// </summary>
    /// <pattern>Singleton</pattern>
    /// <created>janzen_d,2017-12-28</created>
    internal class LogFile
    {
        private static LogFile instance;
        private RichTextBox Console_Info;
        private string tempLog = "";

        //Tool Strip
        private ToolStripStatusLabel lblProgessBar;
        private ToolStripProgressBar pBarProgress;

        private LogFile() { }

        /// --------------------------------------------------------------------------------
        /// <summary>
        /// SetConsole() dient dazu ein Objekt zu übergeben, um die Textausgabe zentralisiert zu bedienen.
        /// </summary>
        /// <param name="listBox">Objekt RichTextBox muss übergeben werden.</param>
        /// <created>janzen_d,2017-12-28</created>
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
                    instance = LogFile.INSTANCE;
                    Console_Info.Multiline = true;
                    Console_Info.AcceptsTab = true;
                    
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
                    MessageBox.Show("ERROR: Class LogFile could not create. Please contact the developer." + " EXCEPTION INFORMATION: " + e.ToString());
                    tempLog += "ERROR: Class LogFile could not create. Please contact the developer." + " EXCEPTION INFORMATION: " + e.ToString() + Environment.NewLine;
                }
            }
        }

        /// <summary>
        /// Destuktor der Klasse LogFile
        /// Er schreib ein logfile im definiertem log Ordner.
        /// </summary>
        /// <created>janzen_d,2017-12-28</created>
        ~LogFile()
        {
            try
            {
                tempLog += Environment.NewLine + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ":\t" + "Try to save log.txt" + Environment.NewLine;
                if (!System.IO.Directory.Exists("log"))
                    System.IO.Directory.CreateDirectory("log");
                TextWriter txtFile = new StreamWriter("log/log.txt");
                txtFile.Write(tempLog);
                txtFile.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Class LogFile could not create. Please contact the developer." + " EXCEPTION INFORMATION: " + e.ToString());
                tempLog += "ERROR: Class LogFile could not create. Please contact the developer." + " EXCEPTION INFORMATION: " + e.ToString() + Environment.NewLine;
            }
        }

        /// <summary>
        /// Sinleton-Pattern Eigenschaft
        /// </summary>
        /// <created>janzen_d,2017-12-28</created>
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
                MessageBox.Show("ERROR: Log data could not be written." + " Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
                tempLog += "ERROR: Log data could not be written." + " Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString();
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
                        Console_Info.BeginInvoke(new dgDebugWriteLine(WriteLine), new object[] { value });
                    }
                    else
                        Write(value, Client.Properties.Settings.DEBUGENABLED);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR: Log data could not be written." + " Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
                tempLog += "ERROR: Log data could not be written." + " Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString();
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
                if(onlyLogFile)
                    Console_Info.AppendText(Environment.NewLine);
                tempLog += Environment.NewLine;
            }
            string timestamp = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            timestamp += ":\t";
            tempLog += timestamp;
            tempLog += value;
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
                int temp = (int)(divident*100);
                pBarProgress.Value = temp;
                if (pBarProgress.Value == 100)
                {
                    pBarProgress.Value = 0;
                    lblProgessBar.Text = "Ready";
                }
            }
            catch (Exception exception)
            {
                Log.LogFile.INSTANCE.WriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + exception.ToString());
            }
        }

    }
}
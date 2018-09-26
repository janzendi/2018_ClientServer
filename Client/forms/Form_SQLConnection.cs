using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Components;
using System.Data.SqlClient;
using System.Threading;

namespace Client.forms
{
    /// <summary>
    /// Form für SQL Verbindungseinstellungen
    /// </summary>
    /// <created>janzen_d,2018-09-25</created>
    public partial class Form_SQLConnection : MetroForm
    {
        private SqlConnection sqlConnection;
        private Thread thread;

        /// <summary>
        /// Konstruktor der MetroUI SQL Form.
        /// </summary>
        /// <created>janzen_d,2018-09-25</created>
        public Form_SQLConnection(MetroStyleManager metroStyleManager)
        {
            InitializeComponent();
            this.CustomInitializeComponent(metroStyleManager); // deklariert im MetroMain.Designer.cs
        }

        ~Form_SQLConnection()
        {
            if (sqlConnection != null)
            {

            }
        }

        public void Closing()
        {
            try
            {
                global.config.ConfigReadWriter.SQLSERVER = mtxtbServer_1094.Text;
                global.config.ConfigReadWriter.SQLTABLENAME = mtxtbDbTable_1095.Text;
                global.config.ConfigReadWriter.SQLUSERID = mtxtDbUser_1096.Text;
                global.config.ConfigReadWriter.SQLPASSWORD = mtxtDbPassword_1097.Text;
            }
            catch (Exception ex)
            {
                //TODO
                MetroFramework.MetroMessageBox.Show(this, ex.ToString(), ex.Source, System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void mbtnConnect_1099_Click(object sender, EventArgs e)
        {
            if (thread == null || thread.ThreadState != ThreadState.Running)
            {
                global.config.ConfigReadWriter.SQLSERVER = mtxtbServer_1094.Text;
                global.config.ConfigReadWriter.SQLTABLENAME = mtxtbDbTable_1095.Text;
                global.config.ConfigReadWriter.SQLUSERID = mtxtDbUser_1096.Text;
                global.config.ConfigReadWriter.SQLPASSWORD = mtxtDbPassword_1097.Text;

                thread = new Thread(new ParameterizedThreadStart(ThreadSyncDB));
                thread.Start("Data Source = " + mtxtbServer_1094.Text + ";Initial Catalog = " + mtxtbDbTable_1095.Text + "; User ID = " + mtxtDbUser_1096.Text + "; Password = " + mtxtDbPassword_1097.Text);
            }
        }

        private void ThreadSyncDB(object connectionstring)
        {

            try
            {
                using (sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = connectionstring.ToString();
                    sqlConnection.Open();

                    using (SqlConnection sqlLocalConnection = global.config.LocalDB.GetLocalConnection())
                    {


                        global.log.MetroLog.INSTANCE.WriteLine("TODO Db Verbindung konnte aufegbaut werden", global.log.MetroLog.LogType.INFO);

                        // Create the command
                        SqlCommand command = new SqlCommand("SELECT * FROM dbo.ENGLISCH", sqlConnection);
                        // Add the parameters.
                        //command.Parameters.Add(new SqlParameter("0", 1));

                        /* Get the rows and display on the screen! 
                         * This section of the code has the basic code
                         * that will display the content from the Database Table
                         * on the screen using an SqlDataReader. */

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                global.log.MetroLog.INSTANCE.DebugWriteLine("TODO " + String.Format("{0} \t | {1}", reader[0], reader[1]), global.log.MetroLog.LogType.INFO);
                                SqlCommand commandinsert = new SqlCommand("INSERT INTO TWENLISCH (`NUMMER`, `TEXT`) VALUES("+ reader[0] + ", "+ reader[1] + ") ON DUPLICATE KEY UPDATE `TEXT` = "+ reader[1] + "; ", sqlLocalConnection);
                                try
                                {
                                    commandinsert.ExecuteNonQuery();
                                }
                                catch (Exception)
                                {
                                    global.log.MetroLog.INSTANCE.DebugWriteLine("TODO " + String.Format("{0} \t | {1}", reader[0], reader[1]), global.log.MetroLog.LogType.INFO);
                                    throw;
                                }
                            }
                        }
                    }
                        

                }
            }
            catch (Exception ex)
            {
                //TODO
                MetroFramework.MetroMessageBox.Show(this, ex.ToString(), ex.Source, System.Windows.Forms.MessageBoxButtons.OK);
            }
        }
    }
}

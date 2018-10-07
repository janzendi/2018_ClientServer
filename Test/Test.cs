using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace Test
{
    class Test
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ThreadSyncDB("Data Source = localhost\\SQLEXPRESS;Initial Catalog = ProductionDB; User ID = dbuser; Password = d");
            GetTextID("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\win10\\Desktop\\2018_ClientServer\\Client\\config\\Sprachen.mdb;");
            Console.ReadLine();
        }

        private static void GetTextID(string connetionString)
        {
            try
            {
                using (OleDbConnection oleDbConnection = new OleDbConnection(connetionString))
                {
                    oleDbConnection.Open();
                    OleDbCommand oleDbCommand = new OleDbCommand("SELECT TEXT FROM ENGLISCH WHERE NUMMER = 60000;", oleDbConnection);
                    try
                    {
                        OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
                        while (oleDbDataReader.Read())
                        {
                            Console.WriteLine(oleDbDataReader[0].ToString());
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    Console.WriteLine("done");
                    oleDbConnection.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void ThreadSyncDB(object connectionstring)
        {

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.ConnectionString = connectionstring.ToString();
                    sqlConnection.Open();

                    using (SqlConnection sqlLocalConnection = new SqlConnection())
                    {

                        sqlLocalConnection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "DB.mdf" + ";Integrated Security=True";
                        sqlLocalConnection.Open();

                        for (int i = 80000; i < 100000; i+=1000)
                        {
                            try
                            {

                                // Create the command
                                SqlCommand command = new SqlCommand("SELECT * FROM dbo.ENGLISCH WHERE NUMMER BETWEEN " + i + " AND " + (i + 999) + ";", sqlConnection);
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
                                        string strtext = CleanInput(reader[1].ToString());
                                        strtext = strtext.Replace('@', ' ');
                                        Console.WriteLine(String.Format("{0} \t | {1}", reader[0], strtext));
                                        SqlCommand commandinsert = new SqlCommand("INSERT IGNORE INTO TWENGLISCH (NUMMER, TEXT) VALUES('" + reader[0] + "', '" + strtext + "');", sqlLocalConnection);
                                        //SqlCommand commandinsert = new SqlCommand("INSERT INTO TWENGLISCH ('NUMMER', 'TEXT') VALUES("+ reader[0] + ", "+ reader[1] + ") ON DUPLICATE KEY UPDATE TEXT = '"+ reader[1] + "';", sqlLocalConnection); 
                                        try
                                        {
                                            commandinsert.ExecuteNonQuery();
                                        }
                                        catch (Exception e)
                                        {
                                            //TODO
                                            //MetroFramework.MetroMessageBox.Show(this, ex.ToString(), ex.Source, System.Windows.Forms.MessageBoxButtons.OK);

                                            Console.WriteLine("Error on: \t" + String.Format("{0} \t | {1}", reader[0], strtext));
                                            Console.WriteLine(e.ToString());
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("FINISH");
            Console.ReadLine();
        }

        static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings.
            try
            {
                return Regex.Replace(strIn, @"[^\w\.@-]", "",
                                RegexOptions.None);
            }
            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}

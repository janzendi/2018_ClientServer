using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            sqlconnect();
        }

        public static void sqlconnect()
        {
            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                // Trusted_Connection is used to denote the connection uses Windows Authentication
                string tmpconnect = "Data Source=DESKTOP-88P6IC0\\SQLEXPRESS;Initial Catalog = ProductionDB; User ID = dbuser; Password = d";
                conn.ConnectionString = tmpconnect; //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
                conn.Open();
                // Create the command
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.ENGLISCH", conn);
                // Add the parameters.
                //command.Parameters.Add(new SqlParameter("0", 1));

                /* Get the rows and display on the screen! 
                 * This section of the code has the basic code
                 * that will display the content from the Database Table
                 * on the screen using an SqlDataReader. */

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("FirstColumn\tSecond Column\t\tThird Column\t\tForth Column\t");
                    int i = 0;
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1}",
                            reader[0], reader[1]));
                        if (++i == 100)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                Console.ReadLine();
                Console.Clear();
                

                /* In this section there is an example of the Exception case
                 * Thrown by the SQL Server, that is provided by SqlException 
                 * Using that class object, we can get the error thrown by SQL Server.
                 * In my code, I am simply displaying the error! */
                Console.WriteLine("Now the error trial!");

                // try block
                try
                {
                    // Create the command to execute! With the wrong name of the table (Depends on your Database tables)
                    SqlCommand errorCommand = new SqlCommand("SELECT * FROM someErrorColumn", conn);
                    // Execute the command, here the error will pop up!
                    // But since we're catching the code block's errors, it will be displayed inside the console.
                    errorCommand.ExecuteNonQuery();
                }
                // catch block
                catch (SqlException er)
                {
                    // Since there is no such column as someErrorColumn (Depends on your Database tables)
                    // SQL Server will throw an error.
                    Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                }
            }
            // Final step, close the resources flush dispose them. ReadLine to prevent the console from closing.
            Console.ReadLine();
        }

        public void xmltest()
        {

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("users");
            xmlDoc.AppendChild(rootNode);

            XmlNode userNode = xmlDoc.CreateElement("user");
            XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "42";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "John Doe";
            rootNode.AppendChild(userNode);

            userNode = xmlDoc.CreateElement("user");
            attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "39";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "Jane Doe";
            rootNode.AppendChild(userNode);

            xmlDoc.Save("test-doc.xml");
        }

        public static void serialnumbertest()
        {
            System.IO.TextWriter txtFile = new System.IO.StreamWriter("SERIALNUMBERS.txt");
            Random random = new Random();
            string tmp = "";
            for (int i = 0; i < 20000; i++)
            {
                tmp += random.Next(1000000, 2147483647).ToString() + ", ";
            }
            txtFile.Write(tmp);
            txtFile.Close();
        }
        
    }
}

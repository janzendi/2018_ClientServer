using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Client.global.config
{
    static class LocalDB
    {
        // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\win10\Desktop\2018_ClientServer\Client\config\DB.mdf;Integrated Security=True
        public static SqlConnection GetLocalConnection()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = "Data Source=" + config.ConfigReadWriter.SQLLOCALSERVERNAME + ";AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + config.ConfigReadWriter.SQLLOCALFILEPATH + ";Integrated Security=True";
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
}

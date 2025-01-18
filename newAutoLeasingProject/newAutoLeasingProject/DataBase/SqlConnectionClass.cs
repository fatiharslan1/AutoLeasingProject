using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace newAutoLeasingProject.DataBase
{
    public class SqlConnectionClass
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-0U62NCI;Initial Catalog=AutoLeasing;Integrated Security=True;MultipleActiveResultSets=True;Connection Timeout=60;");

        public static void CheckConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {

            }
        }
    }
}
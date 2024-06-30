using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

using System;

namespace WebScraperDemo
{
    public class SqlConnection
    {
  
        public static MySqlConnection? SqlConnect()
        {
            try
            {
                string connnection = "server=localhost; uid=root; pwd=root; database=film_db";
                MySqlConnection conn = new MySqlConnection(connnection);
                conn.ConnectionString = connnection;
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Did not connect to DataBase");
                return null;
            }

        }

        public void SqlAddFileNames(List<string> strings)
        {

        }

    }


}


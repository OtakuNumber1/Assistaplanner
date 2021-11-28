using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace Assistaplanner
{
    public class Database
    {


        public static SQLiteConnection DatabaseConnection()
        {
            SQLiteConnection myConnection;
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            myConnection = new SQLiteConnection(@"Data Source= ../../db/assistadb.db");

            return myConnection;
        }

        public static void IsConnectionOpen(SQLiteConnection conn){
            
            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
        }
    }
}

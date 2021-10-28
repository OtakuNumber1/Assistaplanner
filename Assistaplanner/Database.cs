using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Assistaplanner
{
    public class Database
    {


        public static SQLiteConnection DatabaseConnection()
        {
            SQLiteConnection myConnection;

            myConnection = new SQLiteConnection(@"Data Source= C:\Users\Yannick Ratzenböck\source\repos\Assistaplanner\Assistaplanner\assistadb.db");

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

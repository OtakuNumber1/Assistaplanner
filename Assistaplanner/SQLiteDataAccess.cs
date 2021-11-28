using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistaplanner
{
    public class SQLiteDataAccess
    {
        public static List<TerminKategorie> LoadKategorien()
        {
            using(IDbConnection cnn = Database.DatabaseConnection())
            {
                var output = cnn.Query<TerminKategorie>("select * from terminKategorie", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Termin> LoadTermineFromDay(string Wochentag)
        {
            using (IDbConnection cnn = Database.DatabaseConnection())
            {
                var output = cnn.Query<Termin>("select * from termin where wochentag='" + Wochentag + "';", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Termin> LoadTermine()
        {
            using(IDbConnection cnn = Database.DatabaseConnection())
            {
                var output = cnn.Query<Termin>("select * from termin", new DynamicParameters());
                return output.ToList();
            }
        }
        public static void SaveKategorie(TerminKategorie kategorie)
        {
            using (IDbConnection cnn = Database.DatabaseConnection())
            {

            }
        }


    }
}

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

                
                List<Termin> list =  output.ToList();
                foreach(Termin t in list)
                {
                    t.zeit = DateTime.Parse(t.vonStunde + ":" + t.vonMinute);
                }

                return list;
            }
        }
        public static List<Termin> LoadTermineFromDayOfKalenderwoche(string Wochentag, int kw)
        {
            using (IDbConnection cnn = Database.DatabaseConnection())
            {
                var output = cnn.Query<Termin>("select * from termin where wochentag='" + Wochentag +  "' and kalenderwoche= '" + kw + "';", new DynamicParameters());

                List<Termin> list = output.ToList();
                foreach (Termin t in list)
                {
                    t.zeit = DateTime.Parse(t.vonStunde + ":" + t.vonMinute);
                }

                return list;
            }
        }
        public static List<Termin> LoadTermineOfKalenderwoche(int kw)
        {
            using (IDbConnection cnn = Database.DatabaseConnection())
            {
                var output = cnn.Query<Termin>("select * from termin where kalenderwoche='" + kw + "';", new DynamicParameters());

                List<Termin> list = output.ToList();
                foreach (Termin t in list)
                {
                    t.zeit = DateTime.Parse(t.vonStunde + ":" + t.vonMinute);
                }

                return list;
            }
        }
        public static List<Termin> LoadTermine()
        {
            using(IDbConnection cnn = Database.DatabaseConnection())
            {
                var output = cnn.Query<Termin>("select * from termin", new DynamicParameters());

                List<Termin> list = output.ToList();
                foreach (Termin t in list)
                {
                    t.zeit = DateTime.Parse(t.vonStunde + ":" + t.vonMinute);
                }

                return list;
            }
        }
        public static void SaveKategorie(TerminKategorie kategorie)
        {
            using (IDbConnection cnn = Database.DatabaseConnection())
            {

            }
        }
        public static List<Kalenderwoche> LoadKalenderwochen()
        {
            using(IDbConnection cnn = Database.DatabaseConnection())
            {
                var output = cnn.Query<Kalenderwoche>("select * from kalenderwoche", new DynamicParameters());
                return output.ToList();
            }
        }


    }
}

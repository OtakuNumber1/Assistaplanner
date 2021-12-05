using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assistaplanner
{
    /// <summary>
    /// Interaction logic for ShowKategorien.xaml
    /// </summary>
    public partial class ShowKategorien : Window
    {

        public object KategorieName { get; private set; }

        List<TerminKategorie> kat = SQLiteDataAccess.LoadKategorien();
           
        public ShowKategorien()
        {
            InitializeComponent();
          
            List<TerminKategorie> kategorien = KategorienLaden();
         

           
        }

        
        public static List<TerminKategorie> KategorienLaden()
        {
           
            List<TerminKategorie> kat = SQLiteDataAccess.LoadKategorien();
            return kat;

        }

        private void kategorieHinzufügenButton_Click(object sender, RoutedEventArgs e)
        {
            NeueKategorie neuekat = new NeueKategorie();
            neuekat.Show();
            List<TerminKategorie> aktuelleTermine = SQLiteDataAccess.LoadKategorien();
            kategorienliste.ItemsSource = aktuelleTermine;
        }

            private void KategorieLöschenButton_Click(object sender, RoutedEventArgs e)
        {
            TerminKategorie selectedKategorie = kategorienliste.SelectedItem as TerminKategorie;

            if (selectedKategorie != null) {
                int idOfKategorie = selectedKategorie.terminKategorieID;
                using (IDbConnection cnn = Database.DatabaseConnection())
                {
                    cnn.Query<TerminKategorie>("delete from terminKategorie where terminKategorieID=" + idOfKategorie, new DynamicParameters());
                    
                }
            }
            kategorienliste.ItemsSource = KategorienLaden();
        }

        private void kategorienliste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<TerminKategorie> kat = SQLiteDataAccess.LoadKategorien();
            kategorienliste.ItemsSource = kat;

        }
    }
}

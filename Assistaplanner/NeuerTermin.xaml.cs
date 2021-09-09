using System;
using System.Collections.Generic;
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
    /// Interaction logic for NeuerTermin.xaml
    /// </summary>
    public partial class NeuerTermin : Window
    {
        public NeuerTermin()
        {
            List<int> kategorien = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            InitializeComponent();
            KategoriePicker.ItemsSource = kategorien;


        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertIntoDB();
            this.Close();
        }
        public void InsertIntoDB()
        {
            SQLiteConnection conn = Database.DatabaseConnection();

            string insertTerminQuery = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`von`,`bis`,`beschreibung`) VALUES (@kategorie, @titel, @untertitel, @von, @bis, @beschreibung)";

            SQLiteCommand command = new SQLiteCommand(insertTerminQuery, conn);
            Database.IsConnectionOpen(conn);
            command.Parameters.AddWithValue("@kategorie", KategoriePicker.SelectedValue);
            command.Parameters.AddWithValue("@titel", TitelText.Text);
            command.Parameters.AddWithValue("@untertitel", UntertitelText.Text);
            command.Parameters.AddWithValue("@von", 1600);
            command.Parameters.AddWithValue("@bis", 1800);
            command.Parameters.AddWithValue("@beschreibung", BeschreibungText.Text);
            var result = command.ExecuteNonQuery();

            Console.WriteLine(result);
        }

        private void TitelText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

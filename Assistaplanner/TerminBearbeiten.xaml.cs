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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TerminBearbeiten : Window
    {

        private Termin termin;

        public TerminBearbeiten(Termin termin)
        {
            this.termin = termin;
            List<string> wochentage = new List<string> { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
            InitializeComponent();
            List<TerminKategorie> kategorien = ShowKategorien.KategorienLaden();
            KategoriePicker.ItemsSource = kategorien;
            KategoriePicker.DisplayMemberPath = "KategorieName";
            KategoriePicker.SelectedValuePath = "terminKategorieID";
            wochentagBox.ItemsSource = wochentage;

            TitelText.Text = termin.TerminTitel;
            UntertitelText.Text = termin.TerminUntertitel;
            wochentagBox.SelectedItem = termin.Wochentag;
            vonStunde.Text = termin.vonStunde + "";
            vonMinute.Text = termin.vonMinute + "";
            bisStunde.Text = termin.bisStunde + "";
            bisMinute.Text = termin.bisMinute + "";
            if (kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).Count() > 0)
            {
                KategoriePicker.SelectedItem = kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).First();
            }
            BeschreibungText.Text = termin.beschreibung;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = Database.DatabaseConnection();

            string insertTerminQuery = "UPDATE termin SET `terminKategorie`=@terminKategorie, `terminTitel`=@terminTitel, `terminUntertitel`=@terminUntertitel,`wochentag`=@wochentag,`vonStunde`=@vonStunde, `vonMinute`=@vonMinute,`bisStunde`=@bisStunde,`bisMinute`=@bisMinute,`beschreibung`=@beschreibung WHERE terminID=@id";

            SQLiteCommand command = new SQLiteCommand(insertTerminQuery, conn);

            Database.IsConnectionOpen(conn);
            command.Parameters.AddWithValue("@id", termin.TerminID);
            command.Parameters.AddWithValue("@terminKategorie", KategoriePicker.SelectedValue);
            command.Parameters.AddWithValue("@terminTitel", TitelText.Text);
            command.Parameters.AddWithValue("@terminUntertitel", UntertitelText.Text);
            command.Parameters.AddWithValue("@wochentag", wochentagBox.SelectedItem);
            command.Parameters.AddWithValue("@vonStunde", vonStunde.Text);
            command.Parameters.AddWithValue("@vonMinute", vonMinute.Text);
            command.Parameters.AddWithValue("@bisStunde", bisStunde.Text);
            command.Parameters.AddWithValue("@bisMinute", bisMinute.Text);
            command.Parameters.AddWithValue("@beschreibung", BeschreibungText.Text);
            var result = command.ExecuteNonQuery();
            Close();
        }
    }
}

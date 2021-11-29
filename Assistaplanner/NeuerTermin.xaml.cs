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
            List<string> wochentage = new List<string> { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag"};
            InitializeComponent();
            List<TerminKategorie> kategorien = ShowKategorien.KategorienLaden();
            KategoriePicker.ItemsSource = kategorien;
            KategoriePicker.DisplayMemberPath = "KategorieName";
            KategoriePicker.SelectedValuePath = "terminKategorieID";
            wochentagBox.ItemsSource = wochentage;


        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertIntoDB();
            Close();
        }
        public void InsertIntoDB()
        {
            SQLiteConnection conn = Database.DatabaseConnection();

            string insertTerminQuery = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";

            SQLiteCommand command = new SQLiteCommand(insertTerminQuery, conn);



            Database.IsConnectionOpen(conn);
            if (KategoriePicker.SelectedValue != null)
            {
                command.Parameters.AddWithValue("@terminKategorie", KategoriePicker.SelectedValue);
            }
            else
            {
                errorText.Text = "Es wurde keine Kategorie ausgewählt";
            }
            if (TitelText.Text != null)
            {
                command.Parameters.AddWithValue("@terminTitel", TitelText.Text);
            }
            else
            {
                errorText.Text = "Bitte geben Sie einen Titel ein!";
            }
            command.Parameters.AddWithValue("@terminUntertitel", UntertitelText.Text);
            if (wochentagBox.SelectedItem != null)
            {
                command.Parameters.AddWithValue("@wochentag", wochentagBox.SelectedItem);
            }
            else
            {
                errorText.Text = "Geben Sie bitte einen Wochentag an";
            }
            command.Parameters.AddWithValue("@vonStunde", vonStunde.Text);
            command.Parameters.AddWithValue("@vonMinute", vonMinute.Text);
            command.Parameters.AddWithValue("@bisStunde", bisStunde.Text);
            command.Parameters.AddWithValue("@bisMinute", bisMinute.Text);
            command.Parameters.AddWithValue("@beschreibung", BeschreibungText.Text);
            var result = command.ExecuteNonQuery();
        }

       

        private void TitelText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
     
    }
}

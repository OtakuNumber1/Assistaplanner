
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
        }
        public void InsertIntoDB()
        {
            SQLiteConnection conn = Database.DatabaseConnection();

            string insertTerminQuery = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";

            SQLiteCommand command = new SQLiteCommand(insertTerminQuery, conn);



            Database.IsConnectionOpen(conn);
            bool isError = false;


            //Kategorie überprüfen
            if (KategoriePicker.SelectedValue != null)
            {
                command.Parameters.AddWithValue("@terminKategorie", KategoriePicker.SelectedValue);
            }
            else
            {
                errorText.Text = "Es wurde keine Kategorie ausgewählt";
                isError = true;


            }

            //Bis-Zeit überprüfen
            if (bisStunde.Text.Length != 0 & bisMinute.Text.Length != 0)
            {
                command.Parameters.AddWithValue("@bisStunde", bisStunde.Text);
                command.Parameters.AddWithValue("@bisMinute", bisMinute.Text);
            }
            else
            {
                errorText.Text = "Geben Sie bitte eine Endzeit ein!";
                isError = true;

            }

            //Von-Zeit überprüfen
            if (vonStunde.Text.Length != 0 & vonMinute.Text.Length != 0)
            {
                command.Parameters.AddWithValue("@vonStunde", vonStunde.Text);
                command.Parameters.AddWithValue("@vonMinute", vonMinute.Text);
            }
            else
            {
                errorText.Text = "Geben sie eine Startzeit ein!";
                isError = true;

            }

            //Wochentag überprüfen
            if (wochentagBox.SelectedItem != null)
            {
                command.Parameters.AddWithValue("@wochentag", wochentagBox.SelectedItem);
            }
            else
            {
                errorText.Text = "Geben Sie bitte einen Wochentag an";
                isError = true;

            }

            //Titel überprüfen
            if (TitelText.Text.Length != 0)
            {
                command.Parameters.AddWithValue("@terminTitel", TitelText.Text);
            }
            else
            {
                errorText.Text = "Bitte geben Sie einen Titel ein!";
                isError = true;

            }

            //Untertitel eintragen
            command.Parameters.AddWithValue("@terminUntertitel", UntertitelText.Text);


            //Beschreibung einfügen
            command.Parameters.AddWithValue("@beschreibung", BeschreibungText.Text);

            //Nicht in DB schicken wenn Fehler vorliegt
            if(isError == false)
            {
                var result = command.ExecuteNonQuery();
                Close();
            }
           
        }

       

        private void TitelText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
     
    }
}

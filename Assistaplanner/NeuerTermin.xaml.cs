using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Assistaplanner.TerminSerie;

namespace Assistaplanner
{
    /// <summary>
    /// Interaction logic for NeuerTermin.xaml
    /// </summary>
    public partial class NeuerTermin : Window
    {
        private int kw;
        private Selection terminSerienSelection;
        private bool darfTerminSerieGeöffnetWerden;
        public NeuerTermin(int kw)
        {
            
            this.kw = kw;
            List<string> wochentage = new List<string> { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
            InitializeComponent();
            List<TerminKategorie> kategorien = ShowKategorien.KategorienLaden();
            KategoriePicker.ItemsSource = kategorien;
            KategoriePicker.DisplayMemberPath = "KategorieName";
            KategoriePicker.SelectedValuePath = "terminKategorieID";
            wochentagBox.ItemsSource = wochentage;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InsertIntoDB();
        }

        private Termin allesAusgefülltCheck()
        {
            Termin termin = new Termin();
            bool isError = false;
            if (KategoriePicker.SelectedValue != null)
            {
                termin.TerminKategorie = (int)KategoriePicker.SelectedValue;
            }
            else
            {
                isError = true;
                errorText.Text = "Es wurde keine Kategorie ausgewählt";
            }
            if (TitelText.Text != null)
            {
                termin.TerminTitel = TitelText.Text;
            }
            else
            {
                isError = true;
                errorText.Text = "Bitte geben Sie einen Titel ein!";
            }

            if (vonStunde.Text.Length != 0 && Convert.ToInt32(vonStunde.Text) <= 24 && Convert.ToInt32(vonStunde.Text) >= 0 )
            {
                termin.vonStunde = Convert.ToInt32(vonStunde.Text);
            }
            else
            {
                isError = true;
                errorText.Text = "Geben sie eine richtige Stunde ein: Von-Stunde";
            }
            if (vonMinute.Text.Length != 0 && Convert.ToInt32(vonMinute.Text) <= 60 && Convert.ToInt32(vonMinute.Text) >= 0 )
            {
                if(vonMinute.Text == "00")
                {
                    termin.vonMinute = 0;
                }
                else
                {
                    termin.vonMinute = Convert.ToInt32(vonMinute.Text);
                }
                
            }
            else
            {
                isError = true;
                errorText.Text = "Geben sie eine richtige Minute ein: Von-Minute";
            }
            if (bisStunde.Text.Length != 0 && Convert.ToInt32(bisStunde.Text) <= 24 && Convert.ToInt32(bisStunde.Text) >= 0 )
            {
                termin.bisStunde = Convert.ToInt32(bisStunde.Text);
            }
            else
            {
                isError = true;
                errorText.Text = "Geben sie eine richtige Stunde ein: Bis-Stunde";
            }
            if (bisMinute.Text.Length != 0 && Convert.ToInt32(bisMinute.Text) <= 60 && Convert.ToInt32(bisMinute.Text) >= 0)
            {
                if(bisMinute.Text == "00")
                {
                    termin.bisMinute = 0;
                }
                else
                {
                    termin.bisMinute = Convert.ToInt32(bisMinute.Text);
                }
            }
            else
            {
                isError = true;
                errorText.Text = "Geben sie eine richtige Minute ein: Bis-Minute";
            }
            if (wochentagBox.Text.Length != 0)
            {
                termin.Wochentag = wochentagBox.Text;
            }
            else
            {
                isError = true;
                errorText.Text = "Geben Sie bitte einen Wochentag an";
            }

            termin.TerminUntertitel = UntertitelText.Text;
            termin.Kalenderwoche = kw;
            termin.beschreibung = BeschreibungText.Text;
            if (isError == false)
            {
                this.darfTerminSerieGeöffnetWerden = true;
                return termin;
            }
            else
            {
                this.darfTerminSerieGeöffnetWerden = false;
                return null;
            }
        }

        public void InsertIntoDB()
        {
            SQLiteConnection conn = Database.DatabaseConnection();

            string insertTerminQuery = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";

            SQLiteCommand command = new SQLiteCommand(insertTerminQuery, conn);



            Database.IsConnectionOpen(conn);
            Termin einzufügen = allesAusgefülltCheck();
            if(einzufügen != null)
            {

                command.Parameters.AddWithValue("@terminKategorie", einzufügen.TerminKategorie);
                command.Parameters.AddWithValue("@terminTitel", einzufügen.TerminTitel);
                command.Parameters.AddWithValue("@kalenderwoche", einzufügen.Kalenderwoche);
                command.Parameters.AddWithValue("@terminUntertitel", einzufügen.TerminUntertitel);
                command.Parameters.AddWithValue("@wochentag", einzufügen.Wochentag);
                command.Parameters.AddWithValue("@vonStunde", einzufügen.vonStunde);
                command.Parameters.AddWithValue("@vonMinute", einzufügen.vonMinute);
                command.Parameters.AddWithValue("@bisStunde", einzufügen.bisStunde);
                command.Parameters.AddWithValue("@bisMinute", einzufügen.bisMinute);
                command.Parameters.AddWithValue("@beschreibung", einzufügen.beschreibung);
                var result = command.ExecuteNonQuery();
                Close();

            }
            else
            {

            }
        }

        private void vonStunde_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled == true && vonStunde.Text.Length != 0)
            {
                vonMinute.Text = "00";
            }
            
        }

        private void vonMinute_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled == true && vonMinute.Text.Length != 0)
            {
            }
        }

        private void bisStunde_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled == true && bisStunde.Text.Length != 0)
            {
                bisMinute.Text = "00";
            }
        }

        private void bisMinute_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            if (e.Handled == true && bisMinute.Text.Length != 0)
            {
            }
        }

        private Termin allesAusgefülltCheckFürTerminSerie()
        {
            Termin termin = new Termin();
            bool isError = false;
            if (KategoriePicker.SelectedValue != null)
            {
                termin.TerminKategorie = (int)KategoriePicker.SelectedValue;
            }
            else
            {
                isError = true;
                errorText.Text = "Es wurde keine Kategorie ausgewählt";
            }
            if (TitelText.Text != null)
            {
                termin.TerminTitel = TitelText.Text;
            }
            else
            {
                isError = true;
                errorText.Text = "Bitte geben Sie einen Titel ein!";
            }

            if (vonStunde.Text.Length != 0 && Convert.ToInt32(vonStunde.Text) <= 24 && Convert.ToInt32(vonStunde.Text) >= 0)
            {
                termin.vonStunde = Convert.ToInt32(vonStunde.Text);
            }
            else
            {
                isError = true;
                errorText.Text = "Geben sie eine richtige Stunde ein: Von-Stunde";
            }
            if (vonMinute.Text.Length != 0 && Convert.ToInt32(vonMinute.Text) <= 60 && Convert.ToInt32(vonMinute.Text) >= 0)
            {
                if (vonMinute.Text == "00")
                {
                    termin.vonMinute = 0;
                }
                else
                {
                    termin.vonMinute = Convert.ToInt32(vonMinute.Text);
                }

            }
            else
            {
                isError = true;
                errorText.Text = "Geben sie eine richtige Minute ein: Von-Minute";
            }
            if (bisStunde.Text.Length != 0 && Convert.ToInt32(bisStunde.Text) <= 24 && Convert.ToInt32(bisStunde.Text) >= 0)
            {
                termin.bisStunde = Convert.ToInt32(bisStunde.Text);
            }
            else
            {
                isError = true;
                errorText.Text = "Geben sie eine richtige Stunde ein: Bis-Stunde";
            }
            if (bisMinute.Text.Length != 0 && Convert.ToInt32(bisMinute.Text) <= 60 && Convert.ToInt32(bisMinute.Text) >= 0)
            {
                if (bisMinute.Text == "00")
                {
                    termin.bisMinute = 0;
                }
                else
                {
                    termin.bisMinute = Convert.ToInt32(bisMinute.Text);
                }
            }
            else
            {
                isError = true;
                errorText.Text = "Geben sie eine richtige Minute ein: Bis-Minute";
            }
            

            termin.TerminUntertitel = UntertitelText.Text;
            termin.Kalenderwoche = kw;
            termin.beschreibung = BeschreibungText.Text;
            if (isError == false)
            {
                this.darfTerminSerieGeöffnetWerden = true;
                return termin;
            }
            else
            {
                this.darfTerminSerieGeöffnetWerden = false;
                return null;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Termin termin = allesAusgefülltCheckFürTerminSerie();

            if(darfTerminSerieGeöffnetWerden == true)
            {
                TerminSerie ts = new TerminSerie(termin);
                ts.ShowDialog();
                Close();
            }
        }
    }
}

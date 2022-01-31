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
    /// Interaction logic for TerminSerie.xaml
    /// </summary>
    public partial class TerminSerie : Window
    {
        Selection lastSelection;
        Termin listenTermin;
        public TerminSerie(Termin termin)
        {
            InitializeComponent();
            this.listenTermin = termin;
        }
        private bool isDayChecked()
        {
            bool isChecked = false;
            if (moCheck.IsChecked == true || diCheck.IsChecked == true || miCheck.IsChecked == true || doCheck.IsChecked == true || frCheck.IsChecked == true || saCheck.IsChecked == true || soCheck.IsChecked == true)
            {

                Console.WriteLine("Irgendein Tag is Checked");
                isChecked = true;
            }
            return isChecked;
        }
        private void checkAllEverydayBox()
        {
            moCheck.IsChecked = true;
            diCheck.IsChecked = true;
            miCheck.IsChecked = true;
            doCheck.IsChecked = true;
            frCheck.IsChecked = true;
            saCheck.IsChecked = true;
            soCheck.IsChecked = true;

            moCheck.IsEnabled = false;
            diCheck.IsEnabled = false;
            miCheck.IsEnabled = false;
            doCheck.IsEnabled = false;
            frCheck.IsEnabled = false;
            saCheck.IsEnabled = false;
            soCheck.IsEnabled = false;
        }

        private Selection saveCurrentSelection()
        {
            Selection s = new Selection();
            if (moCheck.IsChecked == true)
            {
                s.moSelection = 1;
            }
            else
            {
                s.moSelection = 0;
            }


            if (diCheck.IsChecked == true)
            {
                s.diSelection = 1;
            }
            else
            {
                s.diSelection = 0;
            }


            if (miCheck.IsChecked == true)
            {
                s.miSelection = 1;
            }
            else
            {
                s.miSelection = 0;
            }


            if (doCheck.IsChecked == true)
            {
                s.doSelection = 1;
            }
            else
            {
                s.doSelection = 0;
            }


            if (frCheck.IsChecked == true)
            {
                s.frSelection = 1;
            }
            else
            {
                s.frSelection = 0;
            }


            if (saCheck.IsChecked == true)
            {
                s.saSelection = 1;
            }
            else
            {
                s.saSelection = 0;
            }


            if (soCheck.IsChecked == true)
            {
                s.soSelection = 1;
            }
            else
            {
                s.soSelection = 0;
            }

            return s;
        }

        private void applyLastSelection(Selection s)
        {
            if (s.moSelection == 1)
            {
                moCheck.IsChecked = true;
            }
            else
            {
                moCheck.IsChecked = false;
            }

            if (s.diSelection == 1)
            {
                diCheck.IsChecked = true;
            }
            else
            {
                diCheck.IsChecked = false;
            }

            if (s.miSelection == 1)
            {
                miCheck.IsChecked = true;
            }
            else
            {
                miCheck.IsChecked = false;
            }

            if (s.doSelection == 1)
            {
                doCheck.IsChecked = true;
            }
            else
            {
                doCheck.IsChecked = false;
            }
            
            if (s.frSelection == 1)
            {
                frCheck.IsChecked = true;
            }
            else
            {
                frCheck.IsChecked = false;
            }

            if (s.saSelection == 1)
            {
                saCheck.IsChecked = true;
            }
            else
            {
                saCheck.IsChecked = false;
            } 
            
            if (s.soSelection == 1)
            {
                soCheck.IsChecked = true;
            }
            else
            {
                soCheck.IsChecked = false;
            }

            moCheck.IsEnabled = true;
            diCheck.IsEnabled = true;
            miCheck.IsEnabled = true;
            doCheck.IsEnabled = true;
            frCheck.IsEnabled = true;
            saCheck.IsEnabled = true;
            soCheck.IsEnabled = true;
        }

        private void everydayCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (everydayCheck.IsChecked == true)
            {
                this.lastSelection = saveCurrentSelection();
                checkAllEverydayBox();
            }
            else
            {
                applyLastSelection(lastSelection);
            }
            
        }

        public class Selection
        {
            public int moSelection { get; set; }
            public int diSelection { get; set; }
            public int miSelection { get; set; }
            public int doSelection { get; set; }
            public int frSelection { get; set; }
            public int saSelection { get; set; }
            public int soSelection { get; set; }

        }
        private void TerminSerieInsertIntoDB()
        {
            SQLiteConnection conn = Database.DatabaseConnection();
               
                if (everydayCheck.IsChecked == true)
                {
                Database.IsConnectionOpen(conn);

                string insertMo = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                string insertDi = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                string insertMi = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                string insertDo = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                string insertFr = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                string insertSa = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                string insertSo = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";

                SQLiteCommand commandMo = new SQLiteCommand(insertMo, conn);
                commandMo.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                commandMo.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                commandMo.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                commandMo.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                commandMo.Parameters.AddWithValue("@wochentag", "Montag");
                commandMo.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                commandMo.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                commandMo.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                commandMo.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                commandMo.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                commandMo.ExecuteNonQuery();


                SQLiteCommand commandDi = new SQLiteCommand(insertDi, conn);
                commandDi.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                commandDi.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                commandDi.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                commandDi.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                commandDi.Parameters.AddWithValue("@wochentag", "Dienstag");
                commandDi.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                commandDi.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                commandDi.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                commandDi.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                commandDi.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                commandDi.ExecuteNonQuery();
                SQLiteCommand commandMi = new SQLiteCommand(insertMi, conn);
                commandMi.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                commandMi.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                commandMi.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                commandMi.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                commandMi.Parameters.AddWithValue("@wochentag", "Mittwoch");
                commandMi.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                commandMi.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                commandMi.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                commandMi.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                commandMi.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                commandMi.ExecuteNonQuery();

                SQLiteCommand commandDo = new SQLiteCommand(insertDo, conn);
                commandDo.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                commandDo.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                commandDo.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                commandDo.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                commandDo.Parameters.AddWithValue("@wochentag", "Donnerstag");
                commandDo.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                commandDo.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                commandDo.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                commandDo.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                commandDo.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                commandDo.ExecuteNonQuery();
                SQLiteCommand commandFr = new SQLiteCommand(insertFr, conn);
                commandFr.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                commandFr.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                commandFr.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                commandFr.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                commandFr.Parameters.AddWithValue("@wochentag", "Freitag");
                commandFr.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                commandFr.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                commandFr.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                commandFr.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                commandFr.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                commandFr.ExecuteNonQuery();
                SQLiteCommand commandSa = new SQLiteCommand(insertSa, conn);
                commandSa.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                commandSa.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                commandSa.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                commandSa.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                commandSa.Parameters.AddWithValue("@wochentag", "Samstag");
                commandSa.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                commandSa.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                commandSa.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                commandSa.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                commandSa.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                commandSa.ExecuteNonQuery();
                SQLiteCommand commandSo = new SQLiteCommand(insertSo, conn);
                commandSo.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                commandSo.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                commandSo.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                commandSo.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                commandSo.Parameters.AddWithValue("@wochentag", "Sonntag");
                commandSo.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                commandSo.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                commandSo.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                commandSo.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                commandSo.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                commandSo.ExecuteNonQuery();
            }
                else { 
                if(moCheck.IsChecked == true)
                {
                    Database.IsConnectionOpen(conn);

                    string insertMo = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                    SQLiteCommand commandMo = new SQLiteCommand(insertMo, conn);
                    commandMo.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                    commandMo.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                    commandMo.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                    commandMo.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                    commandMo.Parameters.AddWithValue("@wochentag", "Montag");
                    commandMo.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                    commandMo.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                    commandMo.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                    commandMo.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                    commandMo.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                    commandMo.ExecuteNonQuery();
                }
                if (diCheck.IsChecked == true)
                {
                    string insertDi = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                    SQLiteCommand commandDi = new SQLiteCommand(insertDi, conn);
                    commandDi.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                    commandDi.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                    commandDi.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                    commandDi.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                    commandDi.Parameters.AddWithValue("@wochentag", "Dienstag");
                    commandDi.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                    commandDi.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                    commandDi.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                    commandDi.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                    commandDi.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                    commandDi.ExecuteNonQuery();
                }
                if (miCheck.IsChecked == true)
                {
                    string insertMi = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                    SQLiteCommand commandMi = new SQLiteCommand(insertMi, conn);
                    commandMi.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                    commandMi.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                    commandMi.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                    commandMi.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                    commandMi.Parameters.AddWithValue("@wochentag", "Mittwoch");
                    commandMi.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                    commandMi.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                    commandMi.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                    commandMi.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                    commandMi.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                    commandMi.ExecuteNonQuery();
                }
                if (doCheck.IsChecked == true)
                {
                    string insertDo = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                    SQLiteCommand commandDo = new SQLiteCommand(insertDo, conn);
                    commandDo.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                    commandDo.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                    commandDo.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                    commandDo.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                    commandDo.Parameters.AddWithValue("@wochentag", "Donnerstag");
                    commandDo.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                    commandDo.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                    commandDo.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                    commandDo.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                    commandDo.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                    commandDo.ExecuteNonQuery();
                }
                if (frCheck.IsChecked == true)
                {
                    string insertFr = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                    SQLiteCommand commandFr = new SQLiteCommand(insertFr, conn);
                    commandFr.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                    commandFr.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                    commandFr.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                    commandFr.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                    commandFr.Parameters.AddWithValue("@wochentag", "Freitag");
                    commandFr.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                    commandFr.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                    commandFr.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                    commandFr.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                    commandFr.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                    commandFr.ExecuteNonQuery();
                }
                if (saCheck.IsChecked == true)
                {
                    string insertSa = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                    SQLiteCommand commandSa = new SQLiteCommand(insertSa, conn);
                    commandSa.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                    commandSa.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                    commandSa.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                    commandSa.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                    commandSa.Parameters.AddWithValue("@wochentag", "Samstag");
                    commandSa.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                    commandSa.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                    commandSa.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                    commandSa.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                    commandSa.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                    commandSa.ExecuteNonQuery();

                }
                if (soCheck.IsChecked == true)
                {
                    string insertSo = "INSERT INTO termin (`terminKategorie`,`terminTitel`,`terminUntertitel`,`kalenderwoche`,`wochentag`,`vonStunde`,`vonMinute`,`bisStunde`,`bisMinute`,`beschreibung`) VALUES (@terminKategorie, @terminTitel, @terminUntertitel, @kalenderwoche, @wochentag, @vonStunde, @vonMinute, @bisStunde, @bisMinute, @beschreibung)";
                    SQLiteCommand commandSo = new SQLiteCommand(insertSo, conn);
                    commandSo.Parameters.AddWithValue("@terminKategorie", listenTermin.TerminKategorie);
                    commandSo.Parameters.AddWithValue("@terminTitel", listenTermin.TerminTitel);
                    commandSo.Parameters.AddWithValue("@kalenderwoche", listenTermin.Kalenderwoche);
                    commandSo.Parameters.AddWithValue("@terminUntertitel", listenTermin.TerminUntertitel);
                    commandSo.Parameters.AddWithValue("@wochentag", "Sonntag");
                    commandSo.Parameters.AddWithValue("@vonStunde", listenTermin.vonStunde);
                    commandSo.Parameters.AddWithValue("@vonMinute", listenTermin.vonMinute);
                    commandSo.Parameters.AddWithValue("@bisStunde", listenTermin.bisStunde);
                    commandSo.Parameters.AddWithValue("@bisMinute", listenTermin.bisMinute);
                    commandSo.Parameters.AddWithValue("@beschreibung", listenTermin.beschreibung);
                    commandSo.ExecuteNonQuery();
                }
            }
        }
        private void tsHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            Selection finalSelection = saveCurrentSelection();

            //Termine hinzufügen
            TerminSerieInsertIntoDB();

            Close();
            

        }
    }
}

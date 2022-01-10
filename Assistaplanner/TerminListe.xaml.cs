using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for TerminListe.xaml
    /// </summary>
    public partial class TerminListe : Window
    {
        Termin lastSelectedTermin;
        public TerminListe()
        {
            InitializeComponent();
            TermineLaden();
        }
        public List<Termin> TermineLaden()
        {
            List<Termin> term = SQLiteDataAccess.LoadTermine();
            terminDataGrid.ItemsSource = term;
            return term;
        }

        private void terminLöschenButton_Click(object sender, RoutedEventArgs e)
        {
            Termin selectedTermin = terminDataGrid.SelectedItem as Termin;
            if (selectedTermin != null)
            {
                int idOfTermin = selectedTermin.TerminID;
                using (IDbConnection cnn = Database.DatabaseConnection())
                {
                    cnn.Query<Termin>("delete from termin where terminID=" + idOfTermin, new DynamicParameters());
                    TermineLaden();
                }
            }
        }

        private void enableEditButton(object sender, SelectionChangedEventArgs e)
        {
            if (terminDataGrid.SelectedItem != null)
            {
                terminBearbeitenButton.IsEnabled = true;
                terminLöschenButton.IsEnabled = true;
                lastSelectedTermin = (Termin)terminDataGrid.SelectedItem;
            }
            else
            {
                terminLöschenButton.IsEnabled = false;
                terminBearbeitenButton.IsEnabled = false;
            }
            
        }

        private void editButtonClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("editButtonClicked");
            TerminBearbeiten tb = new TerminBearbeiten(lastSelectedTermin);
            tb.ShowDialog();
            List<Termin> aktuelleTermine = SQLiteDataAccess.LoadTermine();
            terminDataGrid.ItemsSource = aktuelleTermine;
        }
    }
}

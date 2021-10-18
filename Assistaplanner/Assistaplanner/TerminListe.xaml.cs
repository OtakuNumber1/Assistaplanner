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
    }
}

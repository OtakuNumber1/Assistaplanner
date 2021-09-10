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
    /// Interaction logic for ShowKategorien.xaml
    /// </summary>
    public partial class ShowKategorien : Window
    {
        public object KategorieName { get; private set; }

        public ShowKategorien()
        {
            InitializeComponent();
            List<TerminKategorie> kat = KategorienLaden();
            kategorienliste.ItemsSource = kat;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Bearbeitknopf
        }
        public static List<TerminKategorie> KategorienLaden()
        {
            List<TerminKategorie> kat = SQLiteDataAccess.LoadKategorien();
            return kat;
        }

    
    }
}

using System;
using System.Collections.Generic;
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
    /// Interaction logic for Tagesansicht.xaml
    /// </summary>
    public partial class Tagesansicht : Window
    {
        public Tagesansicht(string Wochentag)
        {
            InitializeComponent();
            wochentagText.Text = Wochentag;

        }

 
        private void terminListeTagesansicht_Click(object sender, RoutedEventArgs e)
        {
            TerminListe termine = new TerminListe();
            termine.ShowDialog();
            //RenderTermine();
        }

        private void kategorienlisteTagesansicht_Click(object sender, RoutedEventArgs e)
        {

            ShowKategorien KategorienListe = new ShowKategorien();
            KategorienListe.ShowDialog();
            //RenderTermine();
        }

        private void neuerTerminTagesansicht_Click(object sender, RoutedEventArgs e)
        {
            NeuerTermin neuerTermin = new NeuerTermin();
            neuerTermin.ShowDialog();
            //RenderTermine();
        }

        private void Wochenansicht_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }

        private void ExitButtonT_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
    /// Interaction logic for TerminSerie.xaml
    /// </summary>
    public partial class TerminSerie : Window
    {
        Selection lastSelection;
        public TerminSerie(Termin termin)
        {
            InitializeComponent();
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

        private void tsHinzufügen_Click(object sender, RoutedEventArgs e)
        {
            Selection finalSelection = saveCurrentSelection();
            
            Close();

        }
    }
}

﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Assistaplanner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        

        private void neuerTerminButton_Click(object sender, RoutedEventArgs e)
        {
            NeuerTermin neuerTermin = new NeuerTermin();
            neuerTermin.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowKategorien KategorienListe = new ShowKategorien();
            KategorienListe.Show();
        }

        private void terminLöschenButton_Click(object sender, RoutedEventArgs e)
        {
            TerminListe termine = new TerminListe();
            termine.Show();
        }
    }
}

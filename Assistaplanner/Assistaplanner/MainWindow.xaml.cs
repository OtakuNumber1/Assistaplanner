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
            neuerTermin.ShowDialog();
            RenderTermine();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowKategorien KategorienListe = new ShowKategorien();
            KategorienListe.ShowDialog();
            RenderTermine();
        }

        private void terminLöschenButton_Click(object sender, RoutedEventArgs e)
        {
            TerminListe termine = new TerminListe();
            termine.ShowDialog();
            RenderTermine();
        }

        private void RenderTermine()
        {
            List<UIElement> delete = new List<UIElement>();

            kalender.Children.Clear();
            kalender.Children.Add(kalenderGrid);
  
            List<Termin> termine = SQLiteDataAccess.LoadTermine();
            foreach (Termin termin in termine) {
                Label label = null;
                switch (termin.Wochentag)
                {
                    case "Montag":
                        label = montag;
                        break;
                    case "Dienstag":
                        label = dienstag;
                        break;
                    case "Mittwoch":
                        label = mittwoch;
                        break;
                    case "Donnerstag":
                        label = donnerstag;
                        break;
                    case "Freitag":
                        label = freitag;
                        break;
                    case "Samstag":
                        label = samstag;
                        break;
                    case "Sonntag":
                        label = sonntag;
                        break;
                }
                if (label != null)
                {
                    Console.WriteLine("Label");
                    Point point = label.TransformToAncestor(kalender).Transform(new Point(0, 0));
                    double startY = kalender.ActualHeight / 26.0 * 2;
                    double totalHeight = kalender.ActualHeight * 24.0 / 26;
                    int startMinute = termin.vonMinute + 60 * termin.vonStunde;
                    int bisMinuten = termin.bisMinute + 60 * termin.bisStunde;

                    Button button = new Button();
                    button.Width = kalender.ActualWidth * 250 / (125 + 250 * 7);
                    button.Height = Math.Max(0, bisMinuten - startMinute) / (24.0 * 60.0) * totalHeight;
                    button.Margin = new Thickness(point.X, startY + startMinute/(24.0 * 60.0) * totalHeight, 0, 0);
                    button.Content = termin.TerminTitel;
                    List<TerminKategorie> kategorien = ShowKategorien.KategorienLaden();

        
                    if (kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).Count() > 0)
                    {
                        Color color = ButtonColour(kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).First().KategorieFarbe);
                        button.Background = new SolidColorBrush(color);
                    }
                    button.Click += (sender, e) =>
                    {
                        TerminBearbeiten terminBearbeiten = new TerminBearbeiten(termin);
                        terminBearbeiten.ShowDialog();
                        RenderTermine();
                    };

                    kalender.Children.Add(button);
                    Panel.SetZIndex(button, 0);
                }
            }
        }
        private Color ButtonColour(string colourname)
        {
            //{ "Blau", "Rot", "Lila", "Hellblau", "Hellgrün", "Gelb", "Grün" };
            Color color = new Color();
            switch (colourname)
            {
                case "Blau":
                    color = Color.FromRgb(0, 191, 255);
                    break;
                case "Rot":
                    color = Color.FromRgb(255,0,0);
                    break;
                case "Lila":
                    color = Color.FromRgb(191, 62, 255);
                    break;
                case "Hellblau":
                    color = Color.FromRgb(187,255,255);
                    break;
                case "Hellgrün":
                    color = Color.FromRgb(0,255,127);
                    break;
                case "Gelb":
                    color = Color.FromRgb(255,255,0);
                    break;
                case "Grün":
                    color = Color.FromRgb(154,205,50);
                    break;
            }


        private void Wochenansicht_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderTermine();
        }
    }
}
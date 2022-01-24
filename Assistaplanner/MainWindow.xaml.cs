﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
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
        
        /*public MainWindow()
        {
            
        }*/
        public MainWindow()
        {
           
            InitializeComponent();
            for(int i=1; i < 53; i++)
            {
                kalenderWochenPicker.Items.Add(i);
               
            }
         //  kalenderWochenPicker.SelectedItem =kw;
            if (kalenderWochenPicker.SelectedItem == null)
            {
                kalenderWochenPicker.SelectedValue = +1;
            }
        }

        

        private void neuerTerminButton_Click(object sender, RoutedEventArgs e)
        {
            NeuerTermin neuerTermin = new NeuerTermin((int) kalenderWochenPicker.SelectedValue);
            neuerTermin.ShowDialog();
            RenderTermine();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowKategorien KategorienListe = new ShowKategorien();
            KategorienListe.ShowDialog();
            RenderTermine();
        }
        private void TagesansichtButton_Click(object sender, RoutedEventArgs e)
        {

            Tagesansicht tagesansicht = new Tagesansicht("Montag",(int) kalenderWochenPicker.SelectedValue);
            tagesansicht.ShowDialog();
            RenderTermine();
        }
     

        private void TermineButton_Click(object sender, RoutedEventArgs e)
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
  
            List<Termin> termine = SQLiteDataAccess.LoadTermineOfKalenderwoche((int) kalenderWochenPicker.SelectedValue);
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


            return color;
        }
      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderTermine();

        }

        private void Montag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Montag", (int) kalenderWochenPicker.SelectedValue);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }
        private void dienstag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Dienstag", (int)kalenderWochenPicker.SelectedValue);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Mittwoch_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Mittwoch", (int)kalenderWochenPicker.SelectedValue);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Donnerstag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Donnerstag", (int)kalenderWochenPicker.SelectedValue);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Freitag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Freitag", (int)kalenderWochenPicker.SelectedValue);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Samstag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Samstag", (int)kalenderWochenPicker.SelectedValue);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Sonntag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Sonntag", (int)kalenderWochenPicker.SelectedValue);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void kalenderwocheChanged(object sender, SelectionChangedEventArgs e)
        {
            RenderTermine();
           // kw = Int32.Parse(this.kalenderWochenPicker.SelectedItem.ToString());
        }

        private void nächsteButton_Click(object sender, RoutedEventArgs e)
        {
            if (kalenderWochenPicker.SelectedItem != null)
            {
                if ((int)kalenderWochenPicker.SelectedValue != 52)
                    kalenderWochenPicker.SelectedValue = ((int)kalenderWochenPicker.SelectedValue) + 1;
               // kw = Int32.Parse(this.kalenderWochenPicker.SelectedItem.ToString());
            }
        }
        
    

        private void vorherigeButton_Click(object sender, RoutedEventArgs e)
        {



            if (kalenderWochenPicker.SelectedItem != null)
            {
                if ((int)kalenderWochenPicker.SelectedValue != 1)
                {
                    kalenderWochenPicker.SelectedValue = ((int)kalenderWochenPicker.SelectedValue) - 1;
                   //  kw = Int32.Parse(this.kalenderWochenPicker.SelectedItem.ToString());
                }
            }
        }

        private void PDFButtonT_Click(object sender, RoutedEventArgs e)
        {

            // Initialize document object
            Document document = new Document();

            // Add page
          //  Page page = document.Pages.Add();

            // Add text to new page
          //  page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Hello World!"));

            // Save PDF 
         //   document.Save("document.pdf");

        }
    }
}

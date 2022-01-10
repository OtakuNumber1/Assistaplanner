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
        private String Wochentag;
        private int kw;
        public Tagesansicht(string Wochentag, int kw)
        {
            InitializeComponent();
            int einträge;

            this.Wochentag = Wochentag;
            this.kw = kw;
            wochentagText.Text = Wochentag;

        }
        private void RenderTermine(string Wochentag)
        {
            List<UIElement> delete = new List<UIElement>();

            tagkalender.Children.Clear();
            tagkalender.Children.Add(tagkalenderGrid);

            List<Termin> termine = SQLiteDataAccess.LoadTermineFromDayOfKalenderwoche(Wochentag, kw);
            foreach (Termin termin in termine)
            {
                Console.WriteLine("1");
                Label label = erste;
               
                if (label != null)
                {
                    


                    Console.WriteLine("Label");
                    Point point = label.TransformToAncestor(tagkalender).Transform(new Point(0, 0));
                    double startY = tagkalender.ActualHeight / 26.0 * 2;
                    double totalHeight = tagkalender.ActualHeight * 24.0 / 26;
                    int startMinute = termin.vonMinute + 60 * termin.vonStunde;
                    int bisMinuten = termin.bisMinute + 60 * termin.bisStunde;

                    


                    Button button = new Button();
                    button.Width = tagkalender.ActualWidth * 250 / (125 + 250 * 4);
                    button.Height = Math.Max(0, bisMinuten - startMinute) / (24.0 * 60.0) * totalHeight;
                    button.Margin = new Thickness(point.X - 171, startY + startMinute / (24.0 * 60.0) * totalHeight, 0, 0);
                    button.Content = termin.TerminTitel;
                    List<TerminKategorie> kategorien = ShowKategorien.KategorienLaden();

                    Console.WriteLine("Werte:" + button.Width + button.Height + button.Margin);
                    if (kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).Count() > 0)
                    {
                        Color color = ButtonColour(kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).First().KategorieFarbe);
                        button.Background = new SolidColorBrush(color);
                        Console.WriteLine("3");
                    }
                    button.Click += (sender, e) =>
                    {
                        TerminBearbeiten terminBearbeiten = new TerminBearbeiten(termin);
                        terminBearbeiten.ShowDialog();
                        RenderTermine(Wochentag);
                    };

                    tagkalender.Children.Add(button);
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
                    color = Color.FromRgb(255, 0, 0);
                    break;
                case "Lila":
                    color = Color.FromRgb(191, 62, 255);
                    break;
                case "Hellblau":
                    color = Color.FromRgb(187, 255, 255);
                    break;
                case "Hellgrün":
                    color = Color.FromRgb(0, 255, 127);
                    break;
                case "Gelb":
                    color = Color.FromRgb(255, 255, 0);
                    break;
                case "Grün":
                    color = Color.FromRgb(154, 205, 50);
                    break;
            }

            return color;
        }
       

        // liste mit allen Terminen termine einfüg dann beim rendereing die temrine vergleichechen wenn sie isch überlappen anfang mit ende und ende mit anfang vergleichen 



        private void terminListeTagesansicht_Click(object sender, RoutedEventArgs e)
        {
            TerminListe termine = new TerminListe();
            termine.ShowDialog();
            RenderTermine(Wochentag);
        }

        private void kategorienlisteTagesansicht_Click(object sender, RoutedEventArgs e)
        {

            ShowKategorien KategorienListe = new ShowKategorien();
            KategorienListe.ShowDialog();
            RenderTermine(Wochentag);
        }

        private void neuerTerminTagesansicht_Click(object sender, RoutedEventArgs e)
        {
            NeuerTermin neuerTermin = new NeuerTermin(kw);
            neuerTermin.ShowDialog();
            RenderTermine(Wochentag);
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RenderTermine(Wochentag);
        }
    }
}

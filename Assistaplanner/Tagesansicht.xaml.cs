using iTextSharp.text;

using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;



using iTextSharp.text.pdf;
using Aspose.Pdf;
using System.Drawing;
using Microsoft.Win32;
using Dapper;

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
            

            this.Wochentag = Wochentag;
            this.kw = kw;
            wochentagText.Text = Wochentag;

        }
        private void RenderTermine(string Wochentag)
        {
            List<UIElement> delete = new List<UIElement>();

            tagkalender.Children.Clear();
            tagkalender.Children.Add(tagkalenderGrid);

            List<Termin> sortiert = SQLiteDataAccess.LoadTermineFromDayOfKalenderwoche(this.Wochentag, kw);
            foreach (Termin t in sortiert)
            {
                t.zeit = DateTime.Parse(t.vonStunde + ":" + t.vonMinute);
            }

            sortiert = sortiert.OrderBy(x => x.zeit).AsList<Termin>();


            //Spalten zuweisen
            int maxSpalte = 0;
            List<Termin> abgearbeitet = new List<Termin>();
            foreach (Termin termin in sortiert)
            {
                termin.spalte = 0;
                foreach (Termin t1 in abgearbeitet)
                {
                    if (UeberschneidenSichTermine(t1, termin))
                    {
                        termin.spalte++;
                        if (maxSpalte < termin.spalte)
                        {
                            maxSpalte = termin.spalte;
                        }
                    }
                }
                abgearbeitet.Add(termin);
            }

            foreach (Termin termin in sortiert)
            {
                Console.WriteLine("1");
                Label label = erste;
               
                if (label != null)
                {

                    double totalColWidth = tagkalender.ActualWidth * 250 / (125 + 250 * 4);
                    double subColWidth = totalColWidth * (maxSpalte);

                    Console.WriteLine("Label");
                    System.Windows.Point point = label.TransformToAncestor(tagkalender).Transform(new System.Windows.Point(0, 0));
                    double startY = tagkalender.ActualHeight / 26.0 * 2;
                    double totalHeight = tagkalender.ActualHeight * 24.0 / 26;
                    int startMinute = termin.vonMinute + 60 * termin.vonStunde;
                    int bisMinuten = termin.bisMinute + 60 * termin.bisStunde;

                    double marginLeft = point.X + subColWidth * termin.spalte;
                    Button button = new Button();
                    button.Width = subColWidth;
                    button.Height = Math.Max(0, bisMinuten - startMinute) / (24.0 * 60.0) * totalHeight;
                    button.Margin = new Thickness(marginLeft -171, startY + startMinute / (24.0 * 60.0) * totalHeight, 0, 0);
                    button.Content = termin.TerminTitel;
                    List<TerminKategorie> kategorien = ShowKategorien.KategorienLaden();

                    Console.WriteLine("Werte:" + button.Width + button.Height + button.Margin);
                    if (kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).Count() > 0)
                    {
                        System.Windows.Media.Color color = ButtonColour(kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).First().KategorieFarbe);
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
        private System.Windows.Media.Color ButtonColour(string colourname)
        {
            //{ "Blau", "Rot", "Lila", "Hellblau", "Hellgrün", "Gelb", "Grün" };
            System.Windows.Media.Color color = new System.Windows.Media.Color();
            switch (colourname)
            {
                case "Blau":
                    color = System.Windows.Media.Color.FromRgb(0, 191, 255);
                    break;
                case "Rot":
                    color = System.Windows.Media.Color.FromRgb(255, 0, 0);
                    break;
                case "Lila":
                    color = System.Windows.Media.Color.FromRgb(191, 62, 255);
                    break;
                case "Hellblau":
                    color = System.Windows.Media.Color.FromRgb(187, 255, 255);
                    break;
                case "Hellgrün":
                    color = System.Windows.Media.Color.FromRgb(0, 255, 127);
                    break;
                case "Gelb":
                    color = System.Windows.Media.Color.FromRgb(255, 255, 0);
                    break;
                case "Grün":
                    color = System.Windows.Media.Color.FromRgb(154, 205, 50);
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
        public bool UeberschneidenSichTermine(Termin bestehenderTermin, Termin neuerTermin)
        {
            string t1VonUhrzeit = bestehenderTermin.vonStunde + ":" + bestehenderTermin.vonMinute;
            string t1BisUhrzeit = bestehenderTermin.bisStunde + ":" + bestehenderTermin.bisMinute;


            string t2VonUhrzeit = neuerTermin.vonStunde + ":" + neuerTermin.vonMinute;
            string t2BisUhrzeit = neuerTermin.bisStunde + ":" + neuerTermin.bisMinute;

            DateTime von = DateTime.Parse(t1VonUhrzeit);
            DateTime bis = DateTime.Parse(t1BisUhrzeit);

            DateTime vonNeu = DateTime.Parse(t2VonUhrzeit);
            DateTime bisNeu = DateTime.Parse(t2BisUhrzeit);

            if (vonNeu.Ticks > von.Ticks && vonNeu.Ticks < bis.Ticks)
            {
                return true;
            }
            else
            {
                if (bisNeu.Ticks > von.Ticks && bisNeu.Ticks < bis.Ticks)
                {
                    return true;
                }
                else
                {
                    if (vonNeu.Ticks > von.Ticks && vonNeu.Ticks < bis.Ticks)
                    {

                        return true;
                    }
                    else
                    {
                        if (bisNeu.Ticks > von.Ticks && bisNeu.Ticks < bis.Ticks)
                        {
                            return true;
                        }
                        else
                        {
                            if (vonNeu.Ticks <= von.Ticks && bisNeu.Ticks >= bis.Ticks)
                            {

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            RenderTermine(Wochentag);
        }

        private void PDFButtonT_Click(object sender, RoutedEventArgs e)
        {
           



                    String filename = "day.png";

 
              int screenLeft = 50;

                int screenTop = 180;

                int screenWidth = 1820;

                int screenHeight = 850;



                    Bitmap bitmap_Screen = new Bitmap(screenWidth, screenHeight);

                    Graphics g = Graphics.FromImage(bitmap_Screen);


                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap_Screen.Size);

            
                    bitmap_Screen.Save(filename);



                    Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document("assis_woche.pdf");

            // Set coordinates
            int lowerLeftX = 20;
            int lowerLeftY = 50;
            int upperRightX = 820;
            int upperRightY = 500;

            Aspose.Pdf.Page page = pdfDocument.Pages[1];

                    FileStream imageStream = new FileStream("day.png", FileMode.Open);

                    page.Resources.Images.Add(imageStream);

                    page.Contents.Add(new Aspose.Pdf.Operators.GSave());

                    Aspose.Pdf.Rectangle rectangle = new Aspose.Pdf.Rectangle(lowerLeftX, lowerLeftY, upperRightX, upperRightY);
                    Aspose.Pdf.Matrix matrix = new Aspose.Pdf.Matrix(new double[] { rectangle.URX - rectangle.LLX, 0, 0, rectangle.URY - rectangle.LLY, rectangle.LLX, rectangle.LLY });

                    page.Contents.Add(new Aspose.Pdf.Operators.ConcatenateMatrix(matrix));
                    XImage ximage = page.Resources.Images[page.Resources.Images.Count];

                   
                    page.Contents.Add(new Aspose.Pdf.Operators.Do(ximage.Name));

                    page.Contents.Add(new Aspose.Pdf.Operators.GRestore());

            SaveFileDialog save = new SaveFileDialog();
            save.Title = "PDF speichern";
            save.Filter = "pdf files (*.pdf)|*.pdf";
            save.ShowDialog();
                    pdfDocument.Save(save.FileName);



        }
    }
}

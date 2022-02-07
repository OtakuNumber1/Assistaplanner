using iTextSharp.text;
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
using System.Drawing;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aspose.Pdf;
using Microsoft.Win32;

namespace Assistaplanner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int kw;
        /*public MainWindow()
        {
            
        }*/
        public MainWindow()
        {

            InitializeComponent();
            kw = 1;
            for (int i = 1; i < 53; i++)
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
            NeuerTermin neuerTermin = new NeuerTermin(kw);
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

            Tagesansicht tagesansicht = new Tagesansicht("Montag", kw);
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

            List<Termin> termine = SQLiteDataAccess.LoadTermineOfKalenderwoche(kw);
            foreach (Termin termin in termine)
            {
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
                    System.Windows.Point point = label.TransformToAncestor(kalender).Transform(new System.Windows.Point(0, 0));
                    double startY = kalender.ActualHeight / 26.0 * 2;
                    double totalHeight = kalender.ActualHeight * 24.0 / 26;
                    int startMinute = termin.vonMinute + 60 * termin.vonStunde;
                    int bisMinuten = termin.bisMinute + 60 * termin.bisStunde;

                    Button button = new Button();
                    button.Width = kalender.ActualWidth * 250 / (125 + 250 * 7);
                    button.Height = Math.Max(0, bisMinuten - startMinute) / (24.0 * 60.0) * totalHeight;
                    button.Margin = new Thickness(point.X, startY + startMinute / (24.0 * 60.0) * totalHeight, 0, 0);
                    button.Content = termin.TerminTitel;
                    List<TerminKategorie> kategorien = ShowKategorien.KategorienLaden();


                    if (kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).Count() > 0)
                    {
                        System.Windows.Media.Color color = ButtonColour(kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).First().KategorieFarbe);
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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderTermine();

        }

        private void Montag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Montag", kw);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }
        private void dienstag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Dienstag",kw);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Mittwoch_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Mittwoch", kw);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Donnerstag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Donnerstag", kw);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Freitag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Freitag", kw);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Samstag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Samstag",kw);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }

        private void Sonntag_Clicked(object sender, MouseButtonEventArgs e)
        {
            Tagesansicht tagesansicht = new Tagesansicht("Sonntag", kw);
            this.Close();
            tagesansicht.ShowDialog();
            RenderTermine();
        }


        private void kalenderwocheChanged(object sender, SelectionChangedEventArgs e)
        {
            RenderTermine();
            // kw = Int32.Parse(this.kalenderWochenPicker.SelectedItem.ToString());
        }

        private void nächsteButton_Click(object sender, RoutedEventArgs e)
        {
           if(kw != 52)
            {
                kw += 1;
                RenderTermine();
            }
        }



        private void vorherigeButton_Click(object sender, RoutedEventArgs e)
        {



            if (kw != 1)
            {
                kw -= 1;
                RenderTermine();
            }
        
        }

        private void PDFButtonT_Click(object sender, RoutedEventArgs e)
        {
            {
                

                String filename = "week.png";


                int screenLeft = 20;

                int screenTop = 210;

                int screenWidth = 1800;

                int screenHeight = 810;

           

                Bitmap bitmap_Screen = new Bitmap(screenWidth, screenHeight);

                Graphics g = Graphics.FromImage(bitmap_Screen);



                g.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap_Screen.Size);

              
           

                Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document("assis_woche.pdf");

                // Set coordinates
                int lowerLeftX = 20;
                int lowerLeftY = 80;
                int upperRightX = 820;
                int upperRightY = 450;

                Aspose.Pdf.Page page = pdfDocument.Pages[1];

                FileStream imageStream = new FileStream("week.png", FileMode.Open);

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
                Nullable<bool> result = save.ShowDialog();
                if (result == true)
                {
                    pdfDocument.Save(save.FileName);
                }
                imageStream.Close();
                
            }
        }
    }
}

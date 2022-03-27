using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using Aspose.Pdf;
using Microsoft.Win32;
using System.Data;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using Dapper;

namespace Assistaplanner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int kw;
        DispatcherTimer dt;
        Button lastButtonOn;
        /*public MainWindow()
        {
            
        }*/
        public MainWindow()
        {

            InitializeComponent();
            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 2);// zwei Sekunden warten
            dt.Tick += new EventHandler(dt_Tick);
            kw = 1;
            kwZahl.Content = kw;
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

        private void dt_Tick(object sender, EventArgs e)
        {
            Termin t = lastButtonOn.DataContext as Termin;
            //Fenster aufmachen
            
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


        private void RenderTermine()
        {
            List<UIElement> delete = new List<UIElement>();

            kalender.Children.Clear();
            kalender.Children.Add(kalenderGrid);

           
             String[] wochentage = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };
            Label label = null;
           
            foreach (String s in wochentage)
                {
                switch (s)
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
                
                    List<Termin> sortiert = SQLiteDataAccess.LoadTermineFromDayOfKalenderwoche(s, kw);
                    foreach (Termin t in sortiert)
                    {
                        t.TerminUntertitel = t.vonStunde + ":" + t.vonMinute;
                    }

                    sortiert = sortiert.OrderBy(x => DateTime.Parse(x.TerminUntertitel)).AsList<Termin>();

                    foreach (Termin termin in sortiert)
                    {
                        termin.spalte = -1;
                        foreach (Termin t1 in sortiert)
                        {
                            if (UeberschneidenSichTermine(t1, termin))
                            {
                               termin.spalte++;
                            }

                        }
                        Console.Write(termin.TerminID + ": " + termin.spalte);

                        Console.WriteLine();

                            System.Windows.Point point = label.TransformToAncestor(kalender).Transform(new System.Windows.Point(0, 0));
                            double startY = kalender.ActualHeight / 26.0 * 2;
                            double totalHeight = kalender.ActualHeight * 24.0 / 26;
                            int startMinute = termin.vonMinute + 60 * termin.vonStunde;
                    int bisMinuten = termin.bisMinute + 60 * termin.bisStunde;
                    Button button = new Button();

                            int marginLeft = 0;
                            button.DataContext = termin;
                            button.Width = kalender.ActualWidth * 250 / (125 + 250 * 7);
                            button.Height = Math.Max(0, bisMinuten - startMinute) / (24.0 * 60.0) * totalHeight;
                            button.Margin = new Thickness(point.X, startY + startMinute / (24.0 * 60.0) * totalHeight, 0, 0);
                            button.Content = termin.TerminTitel;
                            button.MouseEnter += new MouseEventHandler(EnterButton);
                            button.MouseLeave += new MouseEventHandler(LeaveButton);
                            button.MouseMove += new MouseEventHandler(Start_Drag);
                            List<TerminKategorie> kategorien = ShowKategorien.KategorienLaden();
                            if (kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).Count() > 0)
                            {
                                System.Windows.Media.Color color = ButtonColour(kategorien.Where(k => k.terminKategorieID == termin.TerminKategorie).First().KategorieFarbe);
                                button.Background = new SolidColorBrush(color);
                            }
                            button.MouseRightButtonDown += (sender, e) =>
                            {

                                ContextMenu cm = this.FindResource("cmButton") as ContextMenu;
                                cm.PlacementTarget = sender as Button;
                                foreach (MenuItem m in cm.Items)
                                {
                                    m.DataContext = sender;
                                }
                                cm.IsOpen = true;


                            };
                            kalender.Children.Add(button);
                            Panel.SetZIndex(button, 0);
                        
                    }
            }

           
       
        }

        private void LeaveButton(object sender, MouseEventArgs e)
        {
            
            dt.Stop();
        }

        private void EnterButton(object sender, MouseEventArgs e)
        {
            lastButtonOn = sender as Button;
            Termin t = lastButtonOn.DataContext as Termin;
            dt.Start();
            Console.WriteLine("Länger wie 2 Sekunden auf Button mit TerminID " + t.TerminID);
            String content = "Titel: " + t.TerminTitel + " @ " + "Von: " + t.vonStunde +":"+ t.vonMinute + " @ " + "Bis: " + t.bisStunde + ":" + t.bisMinute;
            content = content.Replace("@", System.Environment.NewLine);
            ToolTip t1 = new ToolTip();
            t1.Content = content;
            lastButtonOn.ToolTip = t1;
        }


        private void Start_Drag(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Button button = sender as Button;
                Termin buttonTermin = button.DataContext as Termin;
                Console.WriteLine(buttonTermin.TerminID.ToString());
                DataObject dao = new DataObject();
                System.Windows.Point p = button.TransformToAncestor(Application.Current.MainWindow).Transform(new System.Windows.Point(0, 0));
                Console.WriteLine("Originales X: " + p.X + " Originales Y: " + p.Y);
                dao.SetData("Termin", buttonTermin);
                dao.SetData("PointButton", p);
                dao.SetData("Button", button);
                
                DragDrop.DoDragDrop(button, dao, DragDropEffects.Move);
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
            if (kw != 52)
            {

                kw += 1;
                kwZahl.Content = kw;
                RenderTermine();
            }
            else
            {
                if (kw == 52)
                {
                    kw = 1;
                    kwZahl.Content = kw;
                    RenderTermine();
                }
            }
        }

        private void vorherigeButton_Click(object sender, RoutedEventArgs e)
        {
            if (kw != 1)
            {
                kw -= 1;
                kwZahl.Content = kw;
                RenderTermine();
            }
            else
            {
                if (kw == 1)
                {
                    kw = 52;
                    kwZahl.Content = kw;
                    RenderTermine();
                }
            }
        }

        private void PDFButtonT_Click(object sender, RoutedEventArgs e)
        {
            {
                

                //String filename = "week.png";


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

        
        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItem cm = sender as MenuItem;
            Button clickedButton = cm.DataContext as Button;
            Termin clickedTermin = clickedButton.DataContext as Termin;
            Console.WriteLine(clickedTermin.TerminID);
            TerminBearbeiten tb = new TerminBearbeiten(clickedTermin);
            tb.ShowDialog();
            RenderTermine();
        }
        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {

            MenuItem cm = sender as MenuItem;
            Button clickedButton = cm.DataContext as Button;
            Termin clickedTermin = clickedButton.DataContext as Termin;

            SQLiteConnection conn = Database.DatabaseConnection();

            string deleteQuery = "DELETE FROM termin WHERE terminID=@id";
            SQLiteCommand command = new SQLiteCommand(deleteQuery, conn);

            Database.IsConnectionOpen(conn);
            command.Parameters.AddWithValue("@id", clickedTermin.TerminID);
            var result = command.ExecuteNonQuery();
            RenderTermine();
            
        }

        private void kalenderGrid_Drop(object sender, DragEventArgs e)
        {
            //Termin aus Daten holen
            Termin dragedTermin = e.Data.GetData("Termin") as Termin;
            Button origButton = e.Data.GetData("Button") as Button;
            System.Windows.Point positionOriginalButton = (System.Windows.Point) e.Data.GetData("PointButton");
            //Punkt des Buttons holen
            System.Windows.Point p = e.GetPosition(Application.Current.MainWindow);
            Console.WriteLine(p.Y);
            double startY = kalender.ActualHeight / 26.0 * 2;
            double totalHeight = kalender.ActualHeight * 24.0 / 26;
            //Termin auf neue Uhrzeit umändern
            System.Windows.Point gerundet = GetXVonButton(origButton, dragedTermin);
            System.Windows.Point neuePosition = new System.Windows.Point();
            neuePosition.X = gerundet.X;

            double differenz = p.Y - positionOriginalButton.Y;

            double prozentÄnderung = differenz / totalHeight;
            Console.WriteLine("Prozent Änderung" + prozentÄnderung);
            int differenzMinute = Convert.ToInt32(24 * 60 * prozentÄnderung);
            Console.WriteLine(differenzMinute);
            
            int neuVonMinute = dragedTermin.vonStunde * 60 + dragedTermin.vonMinute + differenzMinute;
            int neuBisMinute = dragedTermin.bisStunde * 60 + dragedTermin.bisMinute + differenzMinute;
            if (neuVonMinute > 0 && neuBisMinute > 0 && neuBisMinute < 1420)
            {
                SQLiteConnection conn = Database.DatabaseConnection();
                string insertTerminQuery = "UPDATE termin SET `vonStunde`=@vonStunde, `vonMinute`=@vonMinute,`bisStunde`=@bisStunde,`bisMinute`=@bisMinute WHERE terminID=@id";
                Database.IsConnectionOpen(conn);
                SQLiteCommand command = new SQLiteCommand(insertTerminQuery, conn);
                command.Parameters.AddWithValue("@id", dragedTermin.TerminID);
                command.Parameters.AddWithValue("@vonStunde", neuVonMinute / 60);
                command.Parameters.AddWithValue("@vonMinute", neuVonMinute % 60);
                command.Parameters.AddWithValue("@bisStunde", neuBisMinute / 60);
                command.Parameters.AddWithValue("@bisMinute", neuBisMinute % 60);
                var result = command.ExecuteNonQuery();
            }
            RenderTermine();

        }
        private System.Windows.Point GetXVonButton(Button button, Termin termin)
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
            System.Windows.Point point = label.TransformToAncestor(kalender).Transform(new System.Windows.Point(0, 0));

            Console.WriteLine("X: " + point.X + " Y: " + point.Y);
            return point;
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
 
        }
    }
}

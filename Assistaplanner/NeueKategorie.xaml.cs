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
    /// Interaction logic for NeueKategorie.xaml
    /// </summary>
    public partial class NeueKategorie : Window
    {
        public NeueKategorie()
        {
            List<string> farben = new List<string> { "Blau", "Rot", "Lila", "Hellblau", "Hellgrün", "Gelb", "Grün" };
            InitializeComponent();
            FarbeComboBox.ItemsSource = farben;
        }
        public void CreateKategorie()
        {
            SQLiteConnection conn = Database.DatabaseConnection();

            string insertTerminQuery = "INSERT INTO terminKategorie (`KategorieName`,`KategorieFarbe`) VALUES (@KategorieName, @KategorieFarbe)";

            SQLiteCommand command = new SQLiteCommand(insertTerminQuery, conn);

            Database.IsConnectionOpen(conn);
            command.Parameters.AddWithValue("@KategorieName", KategorieNameText.Text);
            command.Parameters.AddWithValue("@KategorieFarbe", FarbeComboBox.SelectedValue);
            var result = command.ExecuteNonQuery();

            Console.WriteLine(result);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void KategorieHinzufügenButton_Click(object sender, RoutedEventArgs e)
        {
            CreateKategorie();
            Close();
        }
    }
}

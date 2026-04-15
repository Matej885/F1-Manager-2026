using F1_Manager_2026.Menu;
using System.Windows;
using System.Windows.Controls;

namespace F1_Manager_2026
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : Window
    {
        public Calendar()
        {
            // Tento riadok teraz správne prepojí XAML s týmto kódom
            InitializeComponent();

            // Nastavenie dátového kontextu na tvoju databázu tratí
            this.DataContext = Database.Instance;
        }
        private void Track_Click(object sender, RoutedEventArgs e)
        {
            // Získame tlačidlo, na ktoré sa kliklo
            var button = sender as Button;
            // Získame dáta (objekt Track) priradené k tomuto tlačidlu
            var clickedTrack = button?.DataContext as Track;

            if (clickedTrack != null)   
            {
                // Nastavíme vybratú trať v databáze
                Database.Instance.SelectedTrack = clickedTrack;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MainCareerMenu mainMenu = new MainCareerMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
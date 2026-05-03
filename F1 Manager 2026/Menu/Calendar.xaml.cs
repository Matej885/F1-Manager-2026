using F1_Manager_2026.Menu;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace F1_Manager_2026
{
    public partial class Calendar : Window
    {
        public Calendar()
        {
            InitializeComponent();
            this.DataContext = Database.Instance;
            UpdateOverlay();
        }

        private void Track_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var clickedTrack = button?.DataContext as Track;

            if (clickedTrack != null)
            {
                Database.Instance.SelectedTrack = clickedTrack;
                UpdateOverlay(); // Aktualizujeme zobrazenie "COMPLETED"
            }
        }

        // Pomocná funkcia na zobrazenie nápisu "Done" v pravom paneli
        private void UpdateOverlay()
        {
            var selected = Database.Instance.SelectedTrack;
            if (selected != null && DoneOverlay != null)
            {
                DoneOverlay.Visibility = selected.IsDone ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MainCareerMenu mainMenu = new MainCareerMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
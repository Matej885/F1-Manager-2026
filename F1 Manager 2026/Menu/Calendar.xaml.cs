using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using F1_Manager_2026.Menu; // Ak máš MainCareerMenu tu, ponechaj to

namespace F1_Manager_2026
{
    public partial class Calendar : Window
    {
        public Calendar()
        {
            InitializeComponent();
            this.DataContext = Database.Instance;

            // Základná inicializácia dát
            if (Database.Instance.Calendar2026 != null && Database.Instance.Calendar2026.Any())
            {
                if (Database.Instance.SelectedTrack == null)
                    Database.Instance.SelectedTrack = Database.Instance.Calendar2026.First();
            }

            UpdateOverlay();
        }

        // TÁTO METÓDA CHÝBALA ALEBO BOLA NEPRÍSTUPNÁ
        private void Track_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Track clickedTrack)
            {
                Database.Instance.SelectedTrack = clickedTrack;
                UpdateOverlay();
            }
        }

        // TÁTO METÓDA CHÝBALA ALEBO BOLA NEPRÍSTUPNÁ
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            // Predpokladáme, že MainCareerMenu existuje v projekte
            MainCareerMenu mainMenu = new MainCareerMenu();
            mainMenu.Show();
            this.Close();
        }

        private void UpdateOverlay()
        {
            var selected = Database.Instance.SelectedTrack;
            var overlay = this.FindName("DoneOverlay") as Border;

            if (selected != null && overlay != null)
            {
                overlay.Visibility = selected.IsDone ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
}
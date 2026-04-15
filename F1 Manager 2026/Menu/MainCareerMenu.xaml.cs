using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace F1_Manager_2026.Menu
{
    public partial class MainCareerMenu : Window
    {
        public MainCareerMenu()
        {
            InitializeComponent();
            LoadTeamData();
        }

        private void LoadTeamData()
        {
            var db = Database.Instance;
            var team = db.PlayerTeamInstance;

            if (team == null) return;

            // --- 1. TOP BAR (TEAM & BUDGET) ---
            Team_Name_Top.Text = team.teamName.ToUpper();
            Budget_Label.Text = "$ " + team.Budget.ToString("N0");

            // Načítanie loga tímu
            if (!string.IsNullOrEmpty(team.Engine_Path))
                Team_Logo_Small.Source = new BitmapImage(new Uri(team.Engine_Path, UriKind.RelativeOrAbsolute));

            // --- 2. MONOPOST (CENTER) ---
            Car_Model_Name.Text = team.teamName + " Chassis";
            if (!string.IsNullOrEmpty(team.PathToCar))
                Main_Car_Preview.Source = new BitmapImage(new Uri(team.PathToCar, UriKind.RelativeOrAbsolute));

            // Voliteľné: Ak máš v XAML premenné pre štatistiky auta
            // TopSpeedValue.Text = (320 + (team.AeroPower / 10)).ToString() + " KM/H";
            // AccelValue.Text = (2.1 - (team.EnginePower / 1000.0)).ToString("F2") + "s";

            // --- 3. JAZDEC 1 (CHARLES LECLERC / Vlastný) ---
            NameLabel1.Text = team.driver1name.ToUpper();
            RatingLabel1.Text = team.driver1rating.ToString();

            // Tvár a kombinéza 1
            if (!string.IsNullOrEmpty(team.PathToDriver1))
                Driver1_Face.Source = new BitmapImage(new Uri(team.PathToDriver1, UriKind.RelativeOrAbsolute));
            if (!string.IsNullOrEmpty(team.teamclothespath))
                Driver1_Suit.Source = new BitmapImage(new Uri(team.suitpath, UriKind.RelativeOrAbsolute));
            // --- 4. JAZDEC 2 (LEWIS HAMILTON / Vlastný) ---
            NameLabel2.Text = team.driver2name.ToUpper();
            RatingLabel2.Text = team.driver2rating.ToString();
            // Tvár a kombinéza 2
            if (!string.IsNullOrEmpty(team.PathToDriver2))
                Driver2_Face.Source = new BitmapImage(new Uri(team.PathToDriver2, UriKind.RelativeOrAbsolute));
            if (!string.IsNullOrEmpty(team.teamclothespath))
                Driver2_Suit.Source = new BitmapImage(new Uri(team.suitpath, UriKind.RelativeOrAbsolute));
        }

        // --- NAVIGÁCIA A TLAČIDLÁ ---

        private void Button_Click_Upgrade(object sender, RoutedEventArgs e)
        {
            Upgrades upgrades = new Upgrades();
            upgrades.Show();
            this.Close();
        }

        public void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveGame.Save(Database.Instance);
                MessageBox.Show("Game has been saved successfully!", "Save Game", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // EXIT
        {
            Application.Current.Shutdown();
        }

        // Ak by si pridal tlačidlá pre Staff alebo Standings
        private void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            // StaffWindow staff = new StaffWindow();
            // staff.Show();
            // this.Close();
        }

        private void Button_Click_Calendar(object sender, RoutedEventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Close();
        }
    }
}
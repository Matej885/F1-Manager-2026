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
            Progress1.Value = team.driver1rating;

            // Tvár a kombinéza 1
            if (!string.IsNullOrEmpty(team.PathToDriver1))
                Driver1_Face.Source = new BitmapImage(new Uri(team.PathToDriver1, UriKind.RelativeOrAbsolute));
            if (!string.IsNullOrEmpty(team.teamclothespath))
                Driver1_Suit.Source = new BitmapImage(new Uri(team.teamclothespath, UriKind.RelativeOrAbsolute));
            // --- 4. JAZDEC 2 (LEWIS HAMILTON / Vlastný) ---
            NameLabel2.Text = team.driver2name.ToUpper();
            RatingLabel2.Text = team.driver2rating.ToString();
            Progress2.Value = team.driver2rating;

            // Tvár a kombinéza 2
            if (!string.IsNullOrEmpty(team.PathToDriver2))
                Driver2_Face.Source = new BitmapImage(new Uri(team.PathToDriver2, UriKind.RelativeOrAbsolute));
            if (!string.IsNullOrEmpty(team.teamclothespath))
                Driver2_Suit.Source = new BitmapImage(new Uri(team.teamclothespath, UriKind.RelativeOrAbsolute));
        }

        // --- NAVIGÁCIA A TLAČIDLÁ ---

        private void Button_Click_Upgrade(object sender, RoutedEventArgs e)
        {
            Upgrades upgrades = new Upgrades();
            upgrades.Show();
            SaveGame.Save(Database.Instance);
            this.Close();
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
            SaveGame.Save(Database.Instance);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            options.Show();
            SaveGame.Save(Database.Instance);
            this.Close();
        }
    }
}
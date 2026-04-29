using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using F1_Manager_2026.Picking_Team;

namespace F1_Manager_2026.Menu
{
    /// <summary>
    /// Interaction logic for WCC.xaml
    /// </summary>
    public partial class WCC : Window
    {
        // Vlastnosti pre Binding v XAML
        public TeamStandings Top1 { get; set; }
        public TeamStandings Top2 { get; set; }
        public TeamStandings Top3 { get; set; }
        public List<TeamStandings> OtherTeams { get; set; }

        public WCC()
        {
            InitializeComponent();
            var db = Database.Instance;
            if (db.CurrentDayInfo.EndOfSeason == true)
            {
                BackButton.Content = "Continue to boss negotiation";
            }
            LoadTeamStandingsData();
            this.DataContext = this;
        }

        private void LoadTeamStandingsData()
        {
            var db = Database.Instance;
            var drivers = db.DriverList;
            var teams = db.F1Teams;

            // Zeskupuj jazdcov podľa tímu
            var teamGroups = drivers
                .Where(d => !string.IsNullOrEmpty(d.Team))
                .GroupBy(d => d.Team)
                .ToList();

            // Vytvor TeamStandings objekty a agreguj údaje
            var teamStandingsList = new List<TeamStandings>();

            foreach (var group in teamGroups)
            {
                // Hľadaj tím v Database.F1Teams aby si dostal LogoPath
                var teamFromDb = teams.FirstOrDefault(t => t.Name == group.Key);
                var logoPath = teamFromDb?.LogoPath ?? "/Images/lowprestige_logo.png";

                var team = new TeamStandings(group.Key, logoPath);

                foreach (var driver in group)
                {
                    team.Points += driver.Points;
                    team.Wins += driver.Wins;
                    team.Podiums += driver.Podiums;
                    team.Drivers.Add(driver);
                }

                teamStandingsList.Add(team);
            }

            // Zoraď tímy podľa bodov (descending)
            var sortedTeams = teamStandingsList
                .OrderByDescending(t => t.Points)
                .ToList();

            // Priradenie pre pódium
            if (sortedTeams.Count >= 1) Top1 = sortedTeams[0];
            if (sortedTeams.Count >= 2) Top2 = sortedTeams[1];
            if (sortedTeams.Count >= 3) Top3 = sortedTeams[2];

            // Ostatné tímy od 4. miesta nižšie
            OtherTeams = sortedTeams.Skip(3).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            if (db.CurrentDayInfo.EndOfSeason == true)
            {
                Engine_Pick DP = new Engine_Pick();
                this.Close();
                DP.Show();
            }
            else
            {
                MainCareerMenu mainMenu = new MainCareerMenu();
                mainMenu.Show();
            }
            this.Close();
        }
    }
}


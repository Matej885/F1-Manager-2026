using F1_Manager_2026.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace F1_Manager_2026
{
    public partial class WCC : Window
    {
        public class WCCEntry
        {
            public string Name { get; set; }
            public BitmapImage Logo { get; set; }
            public int Points { get; set; }
            public int Rating { get; set; }
        }

        public WCC()
        {
            InitializeComponent();
            LoadStandings();
        }

        private void LoadStandings()
        {
            var db = Database.Instance;
            var allTeams = new List<WCCEntry>();

            BtnBack.Content = db.CurrentDayInfo.EndOfSeason ? "Continue to Standings" : "Back to HQ";

            // 1. AI Tímy
            foreach (var team in db.F1Teams)
            {
                int teamPoints = db.DriverList
                    .Where(d => d.Team == team.Name)
                    .Sum(d => d.Points);

                allTeams.Add(new WCCEntry
                {
                    Name = team.Name,
                    Rating = team.Rating,
                    Points = teamPoints,
                    Logo = LoadImage(team.LogoPath)
                });
            }

            // 2. Hráčsky Tím
            // Správny výpočet bodov: sčítame body všetkých jazdcov, ktorí patria do hráčovho tímu
            int playerTeamPoints = db.DriverList
                .Where(d => d.Team == db.PlayerTeamInstance.teamName)
                .Sum(d => d.Points); 

            allTeams.Add(new WCCEntry
            {
                Name = db.PlayerTeamInstance.teamName,
                Rating = db.PlayerTeamInstance.TeamPower,
                Points = playerTeamPoints,
                Logo = LoadImage(db.PlayerTeamInstance.logopath)
            });

            // 3. Zoradenie
            var sorted = allTeams
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.Rating)
                .ToList();
            // 3.5 Zápis pozície hráča do databázy
            var playerTeamName = db.PlayerTeamInstance.teamName;
            // IndexOf vráti 0 pre prvého, preto pridávame +1
            int finalPosition = sorted.FindIndex(t => t.Name == playerTeamName) + 1;

            db.PlayerTeamInstance.WCCPosition = finalPosition;
            // 4. UI DataContext
            this.DataContext = new
            {
                Top1 = sorted.ElementAtOrDefault(0),
                Top2 = sorted.ElementAtOrDefault(1),
                Top3 = sorted.ElementAtOrDefault(2),
                OtherTeams = sorted.Skip(3).ToList()
            };
        }

        // Pomocná funkcia pre bezpečné načítanie obrázkov
        private BitmapImage LoadImage(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path)) return null;
                return new BitmapImage(new Uri($"pack://application:,,,{path}", UriKind.Absolute));
            }
            catch { return null; } 
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (Database.Instance.CurrentDayInfo.EndOfSeason == true)
            {
                new Standings().Show();
                this.Close();
            }
            else
            {
                new MainCareerMenu().Show();
                this.Close();
            }
        }
    }
}
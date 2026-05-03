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

            // 1. Spracovanie AI Tímov
            foreach (var team in db.F1Teams)
            {
                // Výpočet bodov: Sčítame body všetkých jazdcov, ktorí patria do tohto tímu
                int teamPoints = db.DriverList
                    .Where(d => d.Team == team.Name)
                    .Sum(d => d.Points);

                allTeams.Add(new WCCEntry
                {
                    Name = team.Name,
                    Rating = team.Rating,
                    Points = teamPoints,
                    Logo = new BitmapImage(new Uri($"pack://application:,,,{team.LogoPath}", UriKind.Absolute))
                });
            }

            // 2. Spracovanie Hráčskeho Tímu
            // Sčítame body jazdcov, ktorí jazdia za hráčov tím
            int playerTeamPoints = db.DriverList
                .Where(d => d.Team == db.PlayerTeamInstance.teamName)
                .Sum(d => d.Points);

            allTeams.Add(new WCCEntry
            {
                Name = db.PlayerTeamInstance.teamName,
                Rating = (int)db.PlayerTeamInstance.AeroPower, // Použijeme AeroPower ako rating pre hráča
                Points = playerTeamPoints,
                Logo = new BitmapImage(new Uri($"pack://application:,,,{db.PlayerTeamInstance.logopath}", UriKind.Absolute))
            });

            // 3. Zoradenie podľa BODOV (primárne) a potom podľa Ratingu (sekundárne)
            // Týmto zabezpečíš, že ten, kto má viac bodov, bude vždy vyššie
            var sorted = allTeams
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.Rating)
                .ToList();

            // 4. Nastavenie dát pre UI
            this.DataContext = new
            {
                Top1 = sorted.Count > 0 ? sorted[0] : null,
                Top2 = sorted.Count > 1 ? sorted[1] : null,
                Top3 = sorted.Count > 2 ? sorted[2] : null,
                OtherTeams = sorted.Skip(3).ToList()
            };
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainCareerMenu().Show();
            this.Close();
        }
    }
}
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

            // 1. AI Tímy z databázy
            foreach (var team in db.F1Teams)
            {
                allTeams.Add(new WCCEntry
                {
                    Name = team.Name,
                    Rating = team.Rating,
                    Points = 0, // Tu si neskôr namapuj body ak ich pridáš do F1Team triedy
                    // OPRAVA URI: team.LogoPath už obsahuje "/", tak ho sem nedávame manuálne
                    Logo = new BitmapImage(new Uri($"pack://application:,,,{team.LogoPath}", UriKind.Absolute))
                });
            }

            // 2. Hráčsky Tím
            allTeams.Add(new WCCEntry
            {
                Name = db.PlayerTeamInstance.teamName,
                Rating = 100,
                Points = 0,
                // Ako logo hráča používame helmu alebo suitpath z databázy
                Logo = new BitmapImage(new Uri("pack://application:,,,/Images/helmet.png", UriKind.Absolute))
            });

            // 3. Zoradenie (aktuálne podľa Ratingu, kým nemáš body)
            var sorted = allTeams.OrderByDescending(t => t.Rating).ToList();

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using F1_Manager_2026.Menu;
using F1_Manager_2026.Picking_Team;

namespace F1_Manager_2026.Race_Simulation
{
    public class RaceResult
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public double AvgPos { get; set; }
        public string Team { get; set; }
        public string PhotoPath { get; set; }
        public int PointsEarned { get; set; }
    }

    public partial class Race_Simulation : Window
    {
        private Track currentTrack;

        public Race_Simulation()
        {
            InitializeComponent();

            var db = Database.Instance;

            currentTrack = db.Calendar2026.OrderBy(t => t.Round).FirstOrDefault(t => !t.IsDone);

            if (currentTrack != null)
            {
                TrackNameLabel.Text = currentTrack.Name;
            }
            else
            {
                TrackNameLabel.Text = "SEASON FINISHED";
                BtnStartSim.IsEnabled = false;
            }
        }

        private async void BtnStartSim_Click(object sender, RoutedEventArgs e)
        {
            BtnStartSim.Visibility = Visibility.Collapsed;
            var redBrush = new SolidColorBrush(Colors.Red);
            var offBrush = new SolidColorBrush(Color.FromRgb(34, 34, 34));

            await Task.Delay(500); Light1.Fill = redBrush;
            await Task.Delay(500); Light2.Fill = redBrush;
            await Task.Delay(500); Light3.Fill = redBrush;
            await Task.Delay(500); Light4.Fill = redBrush;
            await Task.Delay(500); Light5.Fill = redBrush;

            await Task.Delay(new Random().Next(1000, 2000));
            Light1.Fill = offBrush; Light2.Fill = offBrush; Light3.Fill = offBrush; Light4.Fill = offBrush; Light5.Fill = offBrush;

            StatusText.Text = "RACING...";

            for (int i = 0; i <= 100; i += 10)
            {
                SimProgressBar.Value = i;
                await Task.Delay(100);
            }

            await Task.Run(() => RunRaceLogic());

            StartSequenceOverlay.Visibility = Visibility.Collapsed;
            ResultsListView.Visibility = Visibility.Visible;
            FinishBtn.Visibility = Visibility.Visible;
        }

        private void RunRaceLogic()
        {
            var db = Database.Instance;
            var rnd = new Random();
            var playerTeam = db.PlayerTeamInstance;

            // ZMENA TU: Vyfiltrujeme preč jazdcov, ktorí nemajú F2 a zároveň NIE SÚ Free Agent
            var f1Drivers = db.DriverList
                .Where(d => !d.IsF2 && d.Team != "Free Agent")
                .ToList();

            if (f1Drivers.Count == 0) return;

            var results = f1Drivers.Select(d => {
                double carPower = (d.Team == playerTeam.teamName)
                    ? playerTeam.AeroPower
                    : (db.F1Teams.FirstOrDefault(t => t.Name == d.Team)?.Rating ?? 50);

                return new
                {
                    Driver = d,
                    Score = (d.Skill * carPower) * (rnd.Next(80, 120) / 100.0)
                };
            })
            .OrderByDescending(x => x.Score)
            .ToList();

            Dispatcher.Invoke(() =>
            {
                var finalResultsList = new List<RaceResult>();
                double totalReward = 0;

                for (int i = 0; i < results.Count; i++)
                {
                    var d = results[i].Driver;
                    int position = i + 1;
                    int pts = CalculateF1Points(position);

                    // Keďže sme ich vyfiltrovali vyššie, tu už podmienku na Free Agent nemusíme riešiť
                    d.Points += pts;
                    if (position == 1) d.Wins++;
                    if (position <= 3) d.Podiums++;

                    if (d.Team == playerTeam.teamName)
                    {
                        totalReward += (double)CalculateGoalReward(position, playerTeam);
                    }

                    finalResultsList.Add(new RaceResult
                    {
                        Position = position,
                        Name = d.Name,
                        Team = d.Team,
                        PointsEarned = pts,
                        PhotoPath = d.PhotoPath
                    });
                }

                SaveRaceHistory(finalResultsList, currentTrack, playerTeam);

                if (totalReward > 0)
                {
                    playerTeam.Budget += (double)totalReward;
                    db.AddDevelopmentLog($"Race Bonus: Received ${totalReward:N0} for meeting team goals.");
                }

                ResultsListView.ItemsSource = finalResultsList;
            });
        }

        private void SaveRaceHistory(List<RaceResult> finalResultsList, Track? track, PlayerTeam playerTeam)
        {
            if (track == null || finalResultsList.Count == 0)
            {
                return;
            }

            var db = Database.Instance;
            var winner = finalResultsList[0];
            var driver1Result = finalResultsList.FirstOrDefault(r => r.Name == playerTeam.driver1name);
            var driver2Result = finalResultsList.FirstOrDefault(r => r.Name == playerTeam.driver2name);

            // Free Agent tím odtiaľto vypadne automaticky, keďže kontrolujeme rovnosť s playerTeam.teamName
            int totalPoints = finalResultsList
                .Where(r => r.Team == playerTeam.teamName)
                .Sum(r => r.PointsEarned);

            var historyEntry = new RaceWeekendHistory
            {
                RoundNumber = track.Round,
                TrackName = track.Name,
                WinnerName = winner.Name,
                WinnerTeam = winner.Team,
                Driver1Pos = driver1Result?.Position ?? 0,
                Driver2Pos = driver2Result?.Position ?? 0,
                TotalPoints = totalPoints,
                IsPodium = (driver1Result?.Position ?? int.MaxValue) <= 3 ||
                           (driver2Result?.Position ?? int.MaxValue) <= 3,
                FullResults = finalResultsList.Select(r => new RaceResultEntry
                {
                    Position = r.Position,
                    DriverName = r.Name,
                    TeamName = r.Team,
                    PointsEarned = r.PointsEarned
                }).ToList()
            };

            db.RaceHistory.RemoveAll(r => r.RoundNumber == track.Round);
            db.RaceHistory.Add(historyEntry);
            db.RaceHistory = db.RaceHistory.OrderBy(r => r.RoundNumber).ToList();
        }

        private decimal CalculateGoalReward(int position, PlayerTeam team)
        {
            if (position <= team.UnrealisticGoal) return 10_000_000m;
            if (position <= team.HighGoal) return 5_000_000m;
            if (position <= team.MediumGoal) return 2_500_000m;
            if (position <= team.LowGoal) return 1_000_000m;

            return 0;
        }

        private int CalculateF1Points(int pos)
        {
            return pos switch { 1 => 25, 2 => 18, 3 => 15, 4 => 12, 5 => 10, 6 => 8, 7 => 6, 8 => 4, 9 => 2, 10 => 1, _ => 0 };
        }

        private void ResultsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ResultsListView.SelectedItem is RaceResult selected)
            {
                DetailName.Text = selected.Name;
                DetailTeam.Text = selected.Team;
                try { DetailPhoto.Source = new BitmapImage(new Uri(selected.PhotoPath, UriKind.RelativeOrAbsolute)); } catch { }
                DriverDetailPanel.Visibility = Visibility.Visible;
            }
        }

        private void CloseDetail_Click(object sender, RoutedEventArgs e) => DriverDetailPanel.Visibility = Visibility.Collapsed;

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrack != null)
            {
                currentTrack.IsDone = true;
            }

            Database.Instance.CurrentDayInfo.Day += 7;

            MainCareerMenu menu = new MainCareerMenu();
            menu.Show();
            this.Close();
        }
    }
}
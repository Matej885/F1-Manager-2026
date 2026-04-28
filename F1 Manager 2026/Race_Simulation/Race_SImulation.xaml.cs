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
    // 1. DEFINÍCIA TRIEDY - Musí byť tu, aby ju videli všetky metódy v tomto súbore
    public class RaceResult
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public double AvgPos { get; set; }
        public int Skill { get; set; }
        public string Team { get; set; }
        public string PhotoPath { get; set; }
        public string SuitPath { get; set; }
        public int PointsEarned { get; set; }
    }

    public partial class Race_Simulation : Window
    {
        public Race_Simulation()
        {
            InitializeComponent();
            TrackNameLabel.Text = Database.Instance.SelectedTrack?.Name ?? "GRAND PRIX";
        }

        private async void BtnStartSim_Click(object sender, RoutedEventArgs e)
        {
            BtnStartSim.Visibility = Visibility.Collapsed;
            var redBrush = new SolidColorBrush(Colors.Red);
            var offBrush = new SolidColorBrush(Color.FromRgb(34, 34, 34));

            // Sekvencia svetiel
            StatusText.Text = "STARTING SEQUENCE...";
            await Task.Delay(800); Light1.Fill = redBrush;
            await Task.Delay(800); Light2.Fill = redBrush;
            await Task.Delay(800); Light3.Fill = redBrush;
            await Task.Delay(800); Light4.Fill = redBrush;
            await Task.Delay(800); Light5.Fill = redBrush;

            Random rnd = new Random();
            await Task.Delay(rnd.Next(1000, 2500));

            Light1.Fill = offBrush; Light2.Fill = offBrush; Light3.Fill = offBrush;
            Light4.Fill = offBrush; Light5.Fill = offBrush;

            StatusText.Text = "LIGHTS OUT AND AWAY WE GO!";

            // Simulácia
            SimProgressBar.Value = 10;
            await Task.Delay(500);
            StatusText.Text = "CALCULATING AERODYNAMICS...";
            SimProgressBar.Value = 40;
            await Task.Delay(500);
            StatusText.Text = "SIMULATING PIT STRATEGY...";
            SimProgressBar.Value = 80;

            // Spustenie logiky na pozadí
            await Task.Run(() => RunRaceLogic());

            SimProgressBar.Value = 100;
            await Task.Delay(500);

            StartSequenceOverlay.Visibility = Visibility.Collapsed;
            ResultsListView.Visibility = Visibility.Visible;
            FinishBtn.Visibility = Visibility.Visible;
        }

        private void RunRaceLogic()
        {
            var db = Database.Instance;
            Random rnd = new Random();
            // Len F1 jazdci
            var f1Drivers = db.DriverList.Where(d => d.IsF2 == false).ToList();
            Dictionary<string, double> stats = new Dictionary<string, double>();

            for (int sim = 0; sim < 50; sim++)
            {
                var available = new List<Driver>(f1Drivers);
                int currentPos = 1;

                while (available.Count > 0)
                {
                    var bestDriver = available
                        .OrderByDescending(d =>
                        {
                            var team = db.F1Teams.FirstOrDefault(t => t.Name == d.Team);
                            double carPower = team?.Rating ?? 50;
                            // Tvoj vzorec: (Skill ^ 4) * Sila Auta
                            double performance = Math.Pow(d.Skill, 4) * carPower;
                            return performance * (rnd.Next(85, 116) / 100.0);
                        })
                        .First();

                    if (!stats.ContainsKey(bestDriver.Name)) stats[bestDriver.Name] = 0;
                    stats[bestDriver.Name] += currentPos;
                    available.Remove(bestDriver);
                    currentPos++;
                }
            }

            // UI Update
            Dispatcher.Invoke(() =>
            {
                var finalResults = stats.Select(kvp =>
                {
                    var d = f1Drivers.First(dr => dr.Name == kvp.Key);
                    return new RaceResult
                    {
                        Name = kvp.Key,
                        AvgPos = Math.Round(kvp.Value / 50, 2),
                        Skill = d.Skill,
                        Team = d.Team,
                        PhotoPath = d.PhotoPath,
                        SuitPath = d.Name == db.PlayerTeamInstance.teamName ? db.PlayerTeamInstance.suitpath : "/Images/suit_default.png"
                    };
                }).OrderBy(r => r.AvgPos).ToList();

                for (int i = 0; i < finalResults.Count; i++)
                {
                    finalResults[i].Position = i + 1;
                    int pts = CalculateF1Points(i + 1);
                    finalResults[i].PointsEarned = pts;

                    var driverDb = db.DriverList.FirstOrDefault(d => d.Name == finalResults[i].Name);
                    if (driverDb != null) driverDb.Points += pts;
                }

                ResultsListView.ItemsSource = finalResults;
            });
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
                try
                {
                    DetailPhoto.Source = new BitmapImage(new Uri(selected.PhotoPath, UriKind.RelativeOrAbsolute));
                }
                catch { }
                DriverDetailPanel.Visibility = Visibility.Visible;
            }
        }

        private void CloseDetail_Click(object sender, RoutedEventArgs e) => DriverDetailPanel.Visibility = Visibility.Collapsed;

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            db.CurrentDayInfo.Day++;
            db.CurrentDayInfo.Day++;
            db.CurrentDayInfo.Day++;
            db.CurrentDayInfo.Day++;
            MainCareerMenu menu = new MainCareerMenu();
            menu.Show();
            this.Close();
        }
    }
}
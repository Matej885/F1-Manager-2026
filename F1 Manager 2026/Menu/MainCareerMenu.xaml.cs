using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;

namespace F1_Manager_2026.Menu
{
    public partial class MainCareerMenu : Window
    {
        public bool IsSimulating { get; private set; } = false;
        public DispatcherTimer timer = new DispatcherTimer();

        // --- STATICKÁ LOGIKA PREHRÁVAČA ---
        private static MediaPlayer musicPlayer = new MediaPlayer();
        private static List<string> playlist;
        private static int currentTrackIndex = 0;
        private static double currentVolume = 0.5;
        private static bool isMusicInitialized = false;

        private Functions functions = new Functions();

        public MainCareerMenu()
        {
            InitializeComponent();
            LoadTeamData();
            UpdateLogUI();

            // --- NASTAVENIE TIMERA ---
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            UpdateDayDisplay();

            // --- INICIALIZÁCIA HUDY ---
            if (!isMusicInitialized)
            {
                playlist = functions.GetMusicList();

                // KĽÚČOVÁ ČASŤ: Keď skladba skončí, zavolaj PlayNextTrack
                musicPlayer.MediaEnded += (s, e) => {
                    this.Dispatcher.Invoke(() => PlayNextTrack());
                };

                isMusicInitialized = true;
                PlayCurrentTrack();
            }
            else
            {
                UpdateSongTitleUI();
                musicPlayer.Volume = currentVolume;
            }

            if (Music_Visualizer != null) Music_Visualizer.Play();
        }

        // --- HUDOBNÉ METÓDY ---

        private void PlayCurrentTrack()
        {
            if (playlist == null || playlist.Count == 0) return;

            try
            {
                // Zastavíme aktuálnu, aby sa korektne načítala nová adresa
                musicPlayer.Stop();
                musicPlayer.Open(new Uri(playlist[currentTrackIndex], UriKind.RelativeOrAbsolute));
                musicPlayer.Volume = currentVolume;
                musicPlayer.Play();
                UpdateSongTitleUI();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Chyba prehrávania: " + ex.Message);
            }
        }

        private void UpdateSongTitleUI()
        {
            if (playlist != null && playlist.Count > 0 && Song_Name != null)
            {
                string name = Path.GetFileNameWithoutExtension(playlist[currentTrackIndex]);
                Song_Name.Text = name.Replace("_", " ").ToUpper();
            }
        }

        private void PlayNextTrack()
        {
            if (playlist == null || playlist.Count == 0) return;

            currentTrackIndex++;
            if (currentTrackIndex >= playlist.Count) currentTrackIndex = 0;

            PlayCurrentTrack();
        }

        private void BtnNextSong_Click(object sender, RoutedEventArgs e)
        {
            functions.Button_Effect();
            PlayNextTrack();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // VOLUME UP (+)
        {
            currentVolume = Math.Min(1.0, currentVolume + 0.1);
            musicPlayer.Volume = currentVolume;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) // VOLUME DOWN (-)
        {
            currentVolume = Math.Max(0.0, currentVolume - 0.1);
            musicPlayer.Volume = currentVolume;
        }

        private void WaveRepeat_Click(object sender, RoutedEventArgs e)
        {
            if (Music_Visualizer != null)
            {
                Music_Visualizer.Position = TimeSpan.Zero;
                Music_Visualizer.Play();
            }
        }

        // --- SIMULAČNÁ LOGIKA ---

        private void Timer_Tick(object sender, EventArgs e)
        {
            var db = Database.Instance;
            int nextDay = db.CurrentDayInfo.Day + 1;

            bool isRaceUpcoming = db.Calendar2026.Any(t =>
                t.RaceDay >= nextDay &&
                t.RaceDay <= nextDay + 2);

            if (isRaceUpcoming || db.CurrentDayInfo.IsSpecialEvent || nextDay > 273)
            {
                StopSimulation();
                Race_Simulation.Race_Simulation _Simulation = new Race_Simulation.Race_Simulation();
                _Simulation.Show();
                this.Close();
                return;
            }

            db.CurrentDayInfo.Day = nextDay;
            HandleUpgrades(db);
            UpdateDayDisplay();
        }

        private void HandleUpgrades(Database db)
        {
            // Aero
            if (db.PlayerFacilities.AeroUpgradeDaysLeft > 0)
            {
                db.PlayerFacilities.AeroUpgradeDaysLeft--;
                if (db.PlayerFacilities.AeroUpgradeDaysLeft == 0)
                {
                    db.PlayerTeamInstance.AeroPower += db.PlayerFacilities.NextAeroUpgrade;
                    db.AddDevelopmentLog($"Aero upgrade completed! Performance boost +{db.PlayerFacilities.NextAeroUpgrade} applied.");
                    db.PlayerFacilities.WindTunnel_Enabled = true;
                    db.PlayerFacilities.AeroUpgradeDaysLeft = -1;
                    db.PlayerTeamInstance.AeroUpgradeLevel++;
                    UpdateLogUI();
                }
            }
            // Tu by nasledovala logika pre Chassis a Engine...
        }

        private void UpdateLogUI()
        {
            if (Development_Log == null) return;
            string separator = Environment.NewLine + Environment.NewLine;
            string fullLog = string.Join(separator, Database.Instance.PlayerFacilities.DevelopmentLog);
            Development_Log.Text = fullLog;
        }

        private void UpdateDayDisplay()
        {
            if (DayLabel != null)
                DayLabel.Text = Database.Instance.CurrentDayInfo.Day.ToString();
        }

        private void StopSimulation()
        {
            timer.Stop();
            BtnSimulate.Content = "CONTINUE";
            IsSimulating = false;
        }

        private void StartSimulation()
        {
            var db = Database.Instance;
            if (db.Calendar2026.Any(t => t.RaceDay >= db.CurrentDayInfo.Day && t.RaceDay <= db.CurrentDayInfo.Day + 2)) return;
            if (db.CurrentDayInfo.Day >= 20)
            {
                
            }
            timer.Start();
            BtnSimulate.Content = "STOP";
            IsSimulating = true;
        }

        private void BtnSimulate_Click(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            else StartSimulation();
        }

        private void LoadTeamData()
        {
            var db = Database.Instance;
            var team = db.PlayerTeamInstance;
            if (team == null) return;

            Team_Name_Top.Text = team.teamName.ToUpper();
            Budget_Label.Text = "$ " + team.Budget.ToString("N0");

            if (!string.IsNullOrEmpty(team.Engine_Path))
                Team_Logo_Small.Source = new BitmapImage(new Uri(team.Engine_Path, UriKind.RelativeOrAbsolute));

            if (!string.IsNullOrEmpty(team.PathToCar))
                Main_Car_Preview.Source = new BitmapImage(new Uri(team.PathToCar, UriKind.RelativeOrAbsolute));

            // Jazdec 1
            NameLabel1.Text = team.driver1name?.ToUpper() ?? "VACANT";
            RatingLabel1.Text = team.driver1rating.ToString();
            if (!string.IsNullOrEmpty(team.PathToDriver1))
                Driver1_Face.Source = new BitmapImage(new Uri(team.PathToDriver1, UriKind.RelativeOrAbsolute));
            if (!string.IsNullOrEmpty(team.suitpath))
                Driver1_Suit.Source = new BitmapImage(new Uri(team.suitpath, UriKind.RelativeOrAbsolute));

            // Jazdec 2
            NameLabel2.Text = team.driver2name?.ToUpper() ?? "VACANT";
            RatingLabel2.Text = team.driver2rating.ToString();
            if (!string.IsNullOrEmpty(team.PathToDriver2))
                Driver2_Face.Source = new BitmapImage(new Uri(team.PathToDriver2, UriKind.RelativeOrAbsolute));
            if (!string.IsNullOrEmpty(team.suitpath))
                Driver2_Suit.Source = new BitmapImage(new Uri(team.suitpath, UriKind.RelativeOrAbsolute));
        }

        // --- NAVIGÁCIA ---
        private void Button_Click_Upgrade(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            new Upgrades().Show();
            this.Close();
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            SaveGame.Save(Database.Instance);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Button_Click_Calendar(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            new Calendar().Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            new Standings().Show();
            this.Close();
        }
        private void SeasonEnd(object  sender, EventArgs e)
        {
            var db = Database.Instance;
            db.CurrentDayInfo.EndOfSeason = true;
            MessageBox.Show("This is the end of the season. Let´s see who won it.");
            Standings standings = new Standings();
            standings.Show();
        }
        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Functions functions = new Functions();
            functions.Button_Effect();
        }
    }
}
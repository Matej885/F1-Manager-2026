using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;
using F1_Manager_2026.Picking_Team;

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
            SaveGame.Save(Database.Instance);
            // --- NASTAVENIE TIMERA ---
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            UpdateDayDisplay();

            // --- INICIALIZÁCIA HUDY ---
            if (!isMusicInitialized)
            {
                playlist = functions.GetMusicList();

                // KĽÚČOVÁ ČASŤ: Keď skladba skončí, zavolaj PlayNextTrack
                musicPlayer.MediaEnded += (s, e) =>
                {
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

            // 1. KONTROLA KONCA SEZÓNY (Ak už nie sú žiadne ďalšie preteky)
            if (db.CurrentDayInfo.AreAllRacesFinished)
            {
                timer.Stop();
                IsSimulating = false;

                db.CurrentDayInfo.EndOfSeason = true;

                MessageBox.Show("The final race has been concluded. The season is officially over!", "Season End");
                WCC wcc = new WCC();
                wcc.Show();

                this.Close();
                return;
            }

            // 2. BEŽNÁ SIMULÁCIA DŇA
            int nextDay = db.CurrentDayInfo.Day + 1;

            var nextRace = db.CurrentDayInfo.NextUpcomingRace;

            if (nextRace != null && nextDay == nextRace.RaceDay)
            {
                StopSimulation();
                // Nastavíme deň presne na deň pretekov
                db.CurrentDayInfo.Day = nextRace.RaceDay;

                Race_Simulation.Race_Simulation _Simulation = new Race_Simulation.Race_Simulation();
                _Simulation.Show();
                this.Close();
                return;
            }

            // Posun dňa a spracovanie upgradov
            db.CurrentDayInfo.Day = nextDay;
            HandleUpgrades(db);
            UpdateDayDisplay();
            SaveGame.Save(db);
        }

        private void HandleUpgrades(Database db)
        {
            // ================= AERO =================

            if (db.PlayerFacilities.AeroUpgradeDaysLeft > 0)
            {
                db.PlayerFacilities.AeroUpgradeDaysLeft--;

                if (db.PlayerFacilities.AeroUpgradeDaysLeft == 0)
                {
                    db.PlayerTeamInstance.AeroPower += db.PlayerFacilities.NextAeroUpgrade;

                    db.AddDevelopmentLog(
                        $"Aero upgrade completed! Performance boost +{db.PlayerFacilities.NextAeroUpgrade} applied.");

                    db.PlayerFacilities.WindTunnel_Enabled = true;
                    db.PlayerTeamInstance.AeroUpgradeLevel++;

                    db.PlayerFacilities.NextAeroUpgrade = 0;

                    UpdateLogUI();
                }
            }

            // ================= CHASSIS =================

            if (db.PlayerFacilities.ChassisUpgradeDaysLeft > 0)
            {
                db.PlayerFacilities.ChassisUpgradeDaysLeft--;

                if (db.PlayerFacilities.ChassisUpgradeDaysLeft == 0)
                {
                    db.PlayerTeamInstance.ChassisPower += db.PlayerFacilities.NextChassisUpgrade;

                    db.AddDevelopmentLog(
                        $"Chassis upgrade completed! Performance boost +{db.PlayerFacilities.NextChassisUpgrade} applied.");

                    db.PlayerFacilities.CFD_Enabled = true;
                    db.PlayerTeamInstance.ChassisUpgradeLevel++;

                    db.PlayerFacilities.NextChassisUpgrade = 0;

                    UpdateLogUI();
                }
            }

            // ================= ENGINE =================

            if (db.PlayerFacilities.EngineUpgradeDaysLeft > 0)
            {
                db.PlayerFacilities.EngineUpgradeDaysLeft--;

                if (db.PlayerFacilities.EngineUpgradeDaysLeft == 0)
                {
                    db.PlayerTeamInstance.EnginePower += db.PlayerFacilities.NextEngineUpgrade;

                    db.AddDevelopmentLog(
                        $"Engine upgrade completed! Performance boost +{db.PlayerFacilities.NextEngineUpgrade} applied.");

                    db.PlayerFacilities.powertrainDyno_Enabled = true;
                    db.PlayerTeamInstance.Engine_UpgradeLevel++;

                    db.PlayerFacilities.NextEngineUpgrade = 0;

                    UpdateLogUI();
                }
            }
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

            // Ak je dnes race day -> okamžite otvor race
            var nextRace = db.CurrentDayInfo.NextUpcomingRace;

            if (nextRace != null && db.CurrentDayInfo.Day >= nextRace.RaceDay)
            {
                StopSimulation();

                Race_Simulation.Race_Simulation sim = new Race_Simulation.Race_Simulation();
                sim.Show();
                this.Close();
                return;
            }

            // Koniec sezóny
            if (db.CurrentDayInfo.Day >= 280)
            {
                StopSimulation();

                Engine_Pick ep = new Engine_Pick();
                ep.Show();

                db.CurrentDayInfo.Day = 1;
                db.CurrentDayInfo.EndOfSeason = true;

                this.Close();
                return;
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
            Upgrades upgrades = new Upgrades();
            upgrades.Show();
            SaveGame.Save(Database.Instance);
            this.Close();
        }



        private void Button_Click_1(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Button_Click_Calendar(object sender, RoutedEventArgs e)
        {
            SaveGame.Save(Database.Instance);
            if (IsSimulating) StopSimulation();
            new Calendar().Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveGame.Save(Database.Instance);
            if (IsSimulating) StopSimulation();
            new Standings().Show();
            this.Close();
        }

        private void Button_Click_WDC(object sender, RoutedEventArgs e)
        {
            SaveGame.Save(Database.Instance);
            if (IsSimulating) StopSimulation();
            new Standings().Show();
            this.Close();
        }

        private void Button_Click_WCC(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            new WCC().Show();
            this.Close();
        } 

        private void SeasonEnd(object sender, EventArgs e)
        {
            var db = Database.Instance;
            db.CurrentDayInfo.EndOfSeason = true;
            MessageBox.Show("This is the end of the season. Let´s see who won it.");
            WCC wcc = new WCC();
            wcc.Show();
            this.Close();
        }
        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Functions functions = new Functions();
            functions.Button_Effect();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new RaceHistory().Show();
            this.Close();
        }
    }
}
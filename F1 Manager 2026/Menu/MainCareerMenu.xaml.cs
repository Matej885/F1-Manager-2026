using System;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace F1_Manager_2026.Menu
{
    public partial class MainCareerMenu : Window
    {
        public bool IsSimulating { get; private set; } = false;
        public DispatcherTimer timer = new DispatcherTimer();

        public MainCareerMenu()
        {
            InitializeComponent();
            LoadTeamData();

            // --- NASTAVENIE TIMERA ---
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;

            UpdateDayDisplay();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var db = Database.Instance;

            // 1. URČÍME NASLEDUJÚCI DEŇ (Look-ahead)
            int nextDay = db.CurrentDayInfo.Day + 1;

            // 2. KONTROLA PRETEKOV (Zastavenie 2 dni vopred)
            // Ak je zajtra alebo o 2 dni závod, nepokračujeme v simulácii.
            bool isRaceUpcoming = db.Calendar2026.Any(t =>
                t.RaceDay >= nextDay &&
                t.RaceDay <= nextDay + 2);

            if (isRaceUpcoming)
            {
                StopSimulation();
                return;
            }

            // 3. KONTROLA ŠPECIÁLNYCH EVENTOV
            if (db.CurrentDayInfo.IsSpecialEvent)
            {
                StopSimulation();
                return;
            }

            // 4. KONTROLA KONCA SEZÓNY
            if (nextDay > 273)
            {
                StopSimulation();
                return;
            }

            // 5. AK VŠETKO PREŠLO, REÁLNE INKREMENTUJEME DEŇ
            db.CurrentDayInfo.Day = nextDay;
            UpdateDayDisplay();
        }

        private void UpdateLogUI()
        {
            // Spojíme všetky riadky v liste pomocou odriadkovania
            string fullLog = string.Join(Environment.NewLine, Database.Instance.PlayerFacilities.DevelopmentLog);

            // Priradíme text do TextBlocku
            Development_Log.Text = fullLog;
        }

        private void UpdateDayDisplay()
        {
            DayLabel.Text = Database.Instance.CurrentDayInfo.Day.ToString();
        }

        private void StopSimulation()
        {
            timer.Stop();
            BtnSimulate.Content = "Start Simulation";
            IsSimulating = false;
        }

        private void StartSimulation()
        {
            var db = Database.Instance;
            int currentDay = db.CurrentDayInfo.Day;

            // Validácia pred štartom (rovnaká logika ako v Timeri)
            bool tooCloseToRace = db.Calendar2026.Any(t =>
                t.RaceDay >= currentDay &&
                t.RaceDay <= currentDay + 2);
            db.AddDevelopmentLog("Race weekend is underway!");
            if (tooCloseToRace)
            {
                // Ak sme príliš blízko závodu, simuláciu ani nespustíme
                return;
            }

            timer.Start();
            BtnSimulate.Content = "Stop Simulation";
            IsSimulating = true;
        }

        private void BtnSimulate_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            UpdateLogUI();
            if (IsSimulating)
                StopSimulation();
            else
                StartSimulation();
        }

        private void LoadTeamData()
        {
            var db = Database.Instance;
            var team = db.PlayerTeamInstance;

            if (team == null) return;

            // Základné informácie
            Team_Name_Top.Text = team.teamName.ToUpper();
            Budget_Label.Text = "$ " + team.Budget.ToString("N0");

            if (!string.IsNullOrEmpty(team.Engine_Path))
                Team_Logo_Small.Source = new BitmapImage(new Uri(team.Engine_Path, UriKind.RelativeOrAbsolute));

            // Auto a šasi
            Car_Model_Name.Text = team.teamName + " Chassis";
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

        // --- NAVIGÁCIA (Vždy zastaví simuláciu) ---

        private void Button_Click_Upgrade(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            Upgrades upgrades = new Upgrades();
            upgrades.Show();
            SaveGame.Save(Database.Instance);
            this.Close();
        }

        public void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            try
            {
                SaveGame.Save(Database.Instance);
            }
            catch (Exception)
            {
                // Tiché zlyhanie alebo logovanie
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // EXIT
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_Calendar(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Close();
        }

        private void Button_Click_Staff(object sender, RoutedEventArgs e)
        {
            if (IsSimulating) StopSimulation();
            // Navigácia pre Staff okno
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            options.Show();
        }
    }
}
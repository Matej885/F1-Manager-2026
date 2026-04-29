using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace F1_Manager_2026.Menu
{
    public partial class Upgrades : Window
    {
        // Základné ceny vylepšení
        public int basicenginecost = 10000000;
        public int aero_cost = 15000000;
        public int chassis_cost = 12000000;

        public Upgrades()
        {
            InitializeComponent();
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            var db = Database.Instance;
            var team = db.PlayerTeamInstance;

            // Načítanie stavu budov
            string windtunnel_text = db.PlayerFacilities.WindTunnel_Enabled ? "Functional" : "Not Operational";
            string cfd_text = db.PlayerFacilities.CFD_Enabled ? "Functional" : "Not Operational";
            string dyno_text = db.PlayerFacilities.powertrainDyno_Enabled ? "Functional" : "Not Operational";

            // Nastavenie obrázka motora
            if (!string.IsNullOrEmpty(team.Engine_Path))
            {
                Engine_Image.Source = new BitmapImage(new Uri($"/Images/{team.Engine_Path}", UriKind.RelativeOrAbsolute));
            }

            // Úvodný log a texty
            Upgrades_Log.Text = $"[{DateTime.Now:HH:mm:ss}]: Welcome to the Upgrades menu! Here you will upgrade your Power Unit, Chassis and Aerodynamics.";

            WindTunnel_Text.Text = $"Wind Tunnel: {windtunnel_text} - Level: {db.PlayerFacilities.WindTunnel_Level}";
            Dyno_Text.Text = $"Powertrain Dyno: {dyno_text} - Level: {db.PlayerFacilities.powertrainDyno_Level}";
            CFD_Text.Text = $"CFD Simulator: {cfd_text} - Level: {db.PlayerFacilities.CFD_Level}";

            CheckMoney();
        }

        private void Aero_Upgrade_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            int actual_aero_cost = aero_cost * db.PlayerTeamInstance.AeroUpgradeLevel;

            Random random = new Random();
            int strenght = random.Next(1, 10);
            db.PlayerTeamInstance.Budget -= actual_aero_cost;
            db.PlayerFacilities.WindTunnel_Enabled = false;
            db.AddDevelopmentLog($"Aerodynamics upgrade started. It will take between 30 and 40 days to complete. Your money has been deducted.");
            LogUpgrade("Aerodynamics", "30 - 40");
            Random rnd = new Random();
            int daysleft = rnd.Next(30, 40);
            db.PlayerFacilities.AeroUpgradeDaysLeft = daysleft;
            db.PlayerFacilities.NextAeroUpgrade = strenght;
            CheckMoney();
        }

        private void PowerUnit_Upgrade_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            int actual_engine_cost = basicenginecost * db.PlayerTeamInstance.Engine_UpgradeLevel;

            Random random = new Random();
            int strenght = random.Next(1, 20);
            db.PlayerTeamInstance.Budget -= actual_engine_cost;
            db.PlayerFacilities.powertrainDyno_Enabled = false;
            db.AddDevelopmentLog($"Power Unit upgrade started. It will take between 50 and 60 days to complete. Your money has been deducted.");
            LogUpgrade("Power Unit", "50 - 60");
            Random rnd = new Random();
            int daysleft = rnd.Next(50, 60);
            db.PlayerFacilities.EngineUpgradeDaysLeft = daysleft;
            db.PlayerFacilities.NextEngineUpgrade = strenght;
            CheckMoney();
        }

        private void Chassis_Upgrade_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            int actual_chassis_cost = chassis_cost * db.PlayerTeamInstance.ChassisUpgradeLevel;

            Random random = new Random();
            int strenght = random.Next(1, 15);
            db.PlayerTeamInstance.Budget -= actual_chassis_cost;
            db.PlayerFacilities.CFD_Enabled = false;
            db.AddDevelopmentLog($"Chassis upgrade started. It will take between 20 and 30 days to complete. Your money has been deducted.");
            LogUpgrade("Chassis", "20 - 30");
            Random rnd = new Random();
            int daysleft = rnd.Next(20, 30);
            db.PlayerFacilities.ChassisUpgradeDaysLeft = daysleft;
            db.PlayerFacilities.NextChassisUpgrade = strenght; 
            CheckMoney();
        }

        private void LogUpgrade(string partName, string timeleft)
        {
            Upgrades_Log.Text += Environment.NewLine + $"[{DateTime.Now:HH:mm:ss}]: Your {partName} is in development! It will be ready between {timeleft} days.";
        }

        private void CheckMoney()
        {
            var db = Database.Instance;
            var team = db.PlayerTeamInstance;

            // Zobrazenie rozpočtu
            Budget.Text = $"{team.Budget.ToString("N0")} $";

            // Výpočet cien
            int actual_engine_cost = basicenginecost * team.Engine_UpgradeLevel;
            int actual_aero_cost = aero_cost * team.AeroUpgradeLevel;
            int actual_chassis_cost = chassis_cost * team.ChassisUpgradeLevel;

            // --- POWER UNIT LOGIKA ---
            if (team.Budget < actual_engine_cost)
            {
                PowerUnit_Upgrade.Content = "Low on Cash!";
                PowerUnit_Upgrade.IsEnabled = false;
            }
            else if (!db.PlayerFacilities.powertrainDyno_Enabled)
            {
                PowerUnit_Upgrade.Content = "In Development";
                PowerUnit_Upgrade.IsEnabled = false;
            }
            else
            {
                PowerUnit_Upgrade.Content = $"Cost: {actual_engine_cost:N0} $";
                PowerUnit_Upgrade.IsEnabled = true;
            }

            // --- CHASSIS LOGIKA ---
            if (team.Budget < actual_chassis_cost)
            {
                Chassis_Upgrade.Content = "Low on Cash!";
                Chassis_Upgrade.IsEnabled = false;
            }
            else if (!db.PlayerFacilities.CFD_Enabled)
            {
                Chassis_Upgrade.Content = "In Development";
                Chassis_Upgrade.IsEnabled = false;
            }
            else
            {
                Chassis_Upgrade.Content = $"Cost: {actual_chassis_cost:N0} $";
                Chassis_Upgrade.IsEnabled = true;
            }

            // --- AERO LOGIKA ---
            if (team.Budget < actual_aero_cost)
            {
                Aero_Upgrade.Content = "Low on Cash!";
                Aero_Upgrade.IsEnabled = false;
            }
            else if (!db.PlayerFacilities.WindTunnel_Enabled)
            {
                Aero_Upgrade.Content = "In Development";
                Aero_Upgrade.IsEnabled = false;
            }
            else
            {
                Aero_Upgrade.Content = $"Cost: {actual_aero_cost:N0} $";
                Aero_Upgrade.IsEnabled = true;
            }

            // Refresh stavu budov
            UpdateFacilityLabels();
        }

        private void UpdateFacilityLabels()
        {
            var db = Database.Instance;
            WindTunnel_Text.Text = $"Wind Tunnel: {(db.PlayerFacilities.WindTunnel_Enabled ? "Functional" : "In Use")} - Lvl: {db.PlayerFacilities.WindTunnel_Level}";
            Dyno_Text.Text = $"Powertrain Dyno: {(db.PlayerFacilities.powertrainDyno_Enabled ? "Functional" : "In Use")} - Lvl: {db.PlayerFacilities.powertrainDyno_Level}";
            CFD_Text.Text = $"CFD Simulator: {(db.PlayerFacilities.CFD_Enabled ? "Functional" : "In Use")} - Lvl: {db.PlayerFacilities.CFD_Level}";
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            MainCareerMenu mainCareerMenu = new MainCareerMenu();
            mainCareerMenu.Show();
            this.Close();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PowerUnit_Upgrade_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Functions functions = new Functions();
            functions.Button_Effect();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainCareerMenu mainCareerMenu = new MainCareerMenu();
            mainCareerMenu.Show();
            SaveGame.Save(Database.Instance);
            this.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace F1_Manager_2026.Menu
{
    public partial class Upgrades : Window
    {
        public int basicenginecost = 10000000;
        public int aero_cost = 15000000;
        public int chassis_cost = 12000000;

        public Upgrades()
        {
            var db = Database.Instance;
            string windtunnel_text = "";
            string dyno_text = "";
            string cfd_text = "";

            if (db.PlayerFacilities.WindTunnel_Enabled == true) windtunnel_text = "Functional";
            else windtunnel_text = "Not Operational";

            if (db.PlayerFacilities.CFD_Enabled == true) cfd_text = "Functional";
            else cfd_text = "Not Operational";

            if (db.PlayerFacilities.powertrainDyno_Enabled == true) dyno_text = "Functional";
            else dyno_text = "Not Operational";

            InitializeComponent();

            CheckMoney();
            UpdateTechnicalStats();

            DateTime currenttime = DateTime.Now;
            Engine_Image.Source = new BitmapImage(new Uri(Database.Instance.PlayerTeamInstance.Engine_Path, UriKind.Relative));
            Upgrades_Log.Text = $"[{currenttime}]: Welcome to the Upgrades menu! Here you will upgrade your level of Power Unit, Chassis and Aerodynamics. But be mindful to not spend all your money on Upgrades too! ";
            WindTunnel_Text.Text = $"Wind Tunnel: {windtunnel_text} - Level: {db.PlayerFacilities.WindTunnel_Level}";
            Dyno_Text.Text = $"Powertrain Dyno: {dyno_text} - Level: {db.PlayerFacilities.powertrainDyno_Level}";
            CFD_Text.Text = $"CFD Simulator: {cfd_text} - Level: {db.PlayerFacilities.CFD_Level}";
            Engine_Image.Source = new BitmapImage(new Uri($"/Images/{db.PlayerTeamInstance.Engine_Path}", UriKind.Relative));
        }

        private void Aero_Upgrade_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            int actual_aero_cost = aero_cost * (db.PlayerTeamInstance.AeroUpgradeLevel);
            Random random = new Random();
            int random_effectivity_aero = random.Next(1, 10);
            db.PlayerTeamInstance.AeroPower += random_effectivity_aero;
            db.PlayerTeamInstance.Budget -= actual_aero_cost;
            db.PlayerTeamInstance.AeroUpgradeLevel++;
            Upgrades_Log.Text += Environment.NewLine + $"[{DateTime.Now}]: Your Aerodynamics part is in development! It will take about 20-30 days to be ready to install.";
            db.PlayerFacilities.WindTunnel_Enabled = false;
            CheckMoney();
            UpdateTechnicalStats();
        }

        private void PowerUnit_Upgrade_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            int actual_engine_cost = basicenginecost * (db.PlayerTeamInstance.Engine_UpgradeLevel);
            Random random = new Random();
            int random_effectivity_engine = random.Next(1, 20);
            db.PlayerTeamInstance.EnginePower += random_effectivity_engine;
            db.PlayerTeamInstance.Budget -= actual_engine_cost;
            db.PlayerTeamInstance.Engine_UpgradeLevel++;
            Upgrades_Log.Text += Environment.NewLine + $"[{DateTime.Now}]: Your Power Unit part is in development! It will take about 30-40 days to be ready to install.";
            db.PlayerFacilities.powertrainDyno_Enabled = false;
            CheckMoney();
            UpdateTechnicalStats();
        }

        private void Chassis_Upgrade_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            int actual_chassis_cost = chassis_cost * (db.PlayerTeamInstance.ChassisUpgradeLevel);
            Random random = new Random();
            int random_effectivity_chassis = random.Next(1, 15);
            db.PlayerTeamInstance.AeroPower += random_effectivity_chassis;
            db.PlayerTeamInstance.Budget -= actual_chassis_cost;
            db.PlayerTeamInstance.ChassisUpgradeLevel++;
            db.PlayerFacilities.CFD_Enabled = false;    
            Upgrades_Log.Text += Environment.NewLine + $"[{DateTime.Now}]: Your Chassis part is in development! It will take about 25-35 days to be ready to install.";
            CheckMoney();
            UpdateTechnicalStats();
        }

        private void CheckMoney()
        {
            var db = Database.Instance;

            // 1. Základné údaje
            Budget.Content = $"{db.PlayerTeamInstance.Budget.ToString("N0")} $";
            int actual_engine_cost = basicenginecost * (db.PlayerTeamInstance.Engine_UpgradeLevel);
            int actual_aero_cost = aero_cost * (db.PlayerTeamInstance.AeroUpgradeLevel);
            int actual_chassis_cost = chassis_cost * (db.PlayerTeamInstance.ChassisUpgradeLevel);

            // 2. Určenie textov stavu
            string windtunnel_text = db.PlayerFacilities.WindTunnel_Enabled ? "Functional" : "Not Operational";
            string cfd_text = db.PlayerFacilities.CFD_Enabled ? "Functional" : "Not Operational";
            string dyno_text = db.PlayerFacilities.powertrainDyno_Enabled ? "Functional" : "Not Operational";

            // --- POWER UNIT ---
            if (db.PlayerTeamInstance.Budget < actual_engine_cost)
            {
                PowerUnit_Upgrade.Content = "Low on Cash!";
                PowerUnit_Upgrade.IsEnabled = false;
            }
            else if (!db.PlayerFacilities.powertrainDyno_Enabled) // Ak nie je funkčné
            {
                PowerUnit_Upgrade.Content = "In Development";
                PowerUnit_Upgrade.IsEnabled = false; // TU SA TO VYPNE
            }
            else
            {
                PowerUnit_Upgrade.Content = $"Cost: {actual_engine_cost:N0} $";
                PowerUnit_Upgrade.IsEnabled = true;
            }

            // --- CHASSIS ---
            if (db.PlayerTeamInstance.Budget < actual_chassis_cost)
            {
                Chassis_Upgrade.Content = "Low on Cash!";
                Chassis_Upgrade.IsEnabled = false;
            }
            else if (!db.PlayerFacilities.CFD_Enabled)
            {
                Chassis_Upgrade.Content = "In Development";
                Chassis_Upgrade.IsEnabled = false; // TU SA TO VYPNE
            }
            else
            {
                Chassis_Upgrade.Content = $"Cost: {actual_chassis_cost:N0} $";
                Chassis_Upgrade.IsEnabled = true;
            }

            // --- AERO ---
            if (db.PlayerTeamInstance.Budget < actual_aero_cost)
            {
                Aero_Upgrade.Content = "Low on Cash!";
                Aero_Upgrade.IsEnabled = false;
            }
            else if (!db.PlayerFacilities.WindTunnel_Enabled)
            {
                Aero_Upgrade.Content = "In Development";
                Aero_Upgrade.IsEnabled = false; // TU SA TO VYPNE
            }
            else
            {
                Aero_Upgrade.Content = $"Cost: {actual_aero_cost:N0} $";
                Aero_Upgrade.IsEnabled = true;
            }

            // 3. Update textových polí na konci
            WindTunnel_Text.Text = $"Wind Tunnel: {windtunnel_text} - Level: {db.PlayerFacilities.WindTunnel_Level}";
            Dyno_Text.Text = $"Powertrain Dyno: {dyno_text} - Level: {db.PlayerFacilities.powertrainDyno_Level}";
            CFD_Text.Text = $"CFD Simulator: {cfd_text} - Level: {db.PlayerFacilities.CFD_Level}";
        }

        private void UpdateTechnicalStats()
        {
            var team = Database.Instance.PlayerTeamInstance;
            Stat_MaxSpeed.Content = $"{(310 + team.EnginePower * 0.5):N0} KM/H";
            Stat_Grip.Content = $"{(4.0 + team.AeroPower * 0.02 + team.ChassisPower * 0.01):F2} G";
            Stat_Reliability.Content = $"{(60 + team.Engine_UpgradeLevel * 5)}%";
            Stat_Weight.Content = $"{(810 - team.ChassisUpgradeLevel * 3)} KG";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pridať do Next Season Data udaje");
        }
    }
}
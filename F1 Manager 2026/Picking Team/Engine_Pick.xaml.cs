using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace F1_Manager_2026.Picking_Team
{
    public partial class Engine_Pick : Window
    {
        // Používame long alebo decimal podľa toho, čo máš v databáze
        private Dictionary<Button, decimal> _enginePrices;

        public Engine_Pick()
        {
            InitializeComponent();

            _enginePrices = new Dictionary<Button, decimal>
            {
                { Btn_Ferrari, 25000000m },
                { Btn_Mercedes, 28500000m },
                { Btn_Honda, 18000000m },
                { Btn_Audi, 21000000m },
                { Btn_Renault, 17500000m },
                { Btn_Ford, 23000000m }
            };

            CheckMoney();
        }

        private void CheckMoney()
        {
            var db = Database.Instance;
            decimal budget = (decimal)db.PlayerTeamInstance.Budget; // Pretypovanie ak treba
            MoneyLabel.Content = $"{budget.ToString("N0")} $";

            foreach (var item in _enginePrices)
            {
                Button btn = item.Key;
                if (btn == null) continue;

                decimal cost = item.Value;

                if (budget < cost)
                {
                    btn.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
                    btn.Foreground = Brushes.Red;
                    btn.Content = "Low on Cash!";
                    btn.IsEnabled = false;
                }
            }
        }

        private void Btn_Ferrari_Click(object sender, RoutedEventArgs e)
            => SelectEngine("Ferrari", "ferrari_engine.png", 94, 90, 25000000);

        private void Btn_Mercedes_Click_1(object sender, RoutedEventArgs e)
            => SelectEngine("Mercedes", "mercedes_engine.jpg", 91, 98, 28500000);

        private void Btn_Honda_Click_1(object sender, RoutedEventArgs e)
            => SelectEngine("Honda", "honda_engine.jpg", 96, 85, 18000000);

        private void Btn_Audi_Click_1(object sender, RoutedEventArgs e)
            => SelectEngine("Audi Sport", "audi_engine.jpg", 89, 70, 21000000);

        private void Btn_Renault_Click_1(object sender, RoutedEventArgs e)
            => SelectEngine("Renault", "renault_engine.jpg", 85, 80, 17500000);

        private void Btn_Ford_Click(object sender, RoutedEventArgs e)
            => SelectEngine("Red Bull Ford", "redbull_engine.jpg", 85, 90, 23000000);

        private void SelectEngine(string name, string path, int power, int reliability, decimal cost)
        {
            var db = Database.Instance;

            if ((decimal)db.PlayerTeamInstance.Budget < cost)
            {
                MessageBox.Show("Insufficient funds!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            db.PlayerTeamInstance.EngineName = name;
            db.PlayerTeamInstance.Engine_Path = path;
            db.PlayerTeamInstance.EnginePower = power;
            db.PlayerTeamInstance.EngineReliability = reliability;
            db.PlayerTeamInstance.Budget -= cost;

            Drivers_Pick dp = new Drivers_Pick();
            dp.Show();
            this.Close();
        }

        // TOTO JE SPRÁVNE PRE OKNO (namiesto OnExit)
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Ak je toto jediné/posledné okno a niekto ho zavrie (Alt+F4), 
            // zavoláme vypnutie celej aplikácie, čo aktivuje Kill() v App.xaml.cs
            if (Application.Current.Windows.Count == 0)
            {
                Application.Current.Shutdown();
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
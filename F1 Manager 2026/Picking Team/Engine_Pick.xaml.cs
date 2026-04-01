using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace F1_Manager_2026.Picking_Team
{
    public partial class Engine_Pick : Window
    {
        // Slovník: Tlačidlo -> Cena
        private Dictionary<Button, int> _enginePrices;

        public Engine_Pick()
        {
            InitializeComponent();

            // Inicializujeme ceny priradené ku konkrétnym tlačidlám z XAML
            _enginePrices = new Dictionary<Button, int>
            {
                { Btn_Ferrari, 25000000 },
                { Btn_Mercedes, 28500000 },
                { Btn_Honda, 23000000 },
                { Btn_Audi, 21000000 },
                { Btn_Renault, 17500000 }
            };

            CheckMoney();
        }

        private void CheckMoney()
        {
            var db = Database.Instance;
            var budget = db.PlayerTeamInstance.Budget;
            MoneyLabel.Content = $"{db.PlayerTeamInstance.Budget.ToString("N0")} $";
            // Prejdeme všetky motory v slovníku naraz
            foreach (var item in _enginePrices)
            {
                Button btn = item.Key;
                int cost = item.Value;

                if (budget < cost)
                {
                    // Ak je hráč chudobný, zmeníme vizuál a vypneme button
                    btn.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
                    btn.Foreground = Brushes.Red;
                    btn.Content = "Low on Cash!";
                    btn.IsEnabled = false;
                }
            }
        }

        // --- CLICK EVENTY ---

        private void Btn_Ferrari_Click(object sender, RoutedEventArgs e)
            => SelectEngine("Ferrari", "ferrari_engine.png", 94, 90, 25000000);

        private void Btn_Mercedes_Click(object sender, RoutedEventArgs e)
            => SelectEngine("Mercedes", "mercedes_engine.jpg", 91, 98, 28500000);

        private void Btn_Honda_Click(object sender, RoutedEventArgs e)
            => SelectEngine("Honda RBPT", "honda_engine.jpg", 96, 85, 23000000);

        private void Btn_Audi_Click(object sender, RoutedEventArgs e)
            => SelectEngine("Audi Sport", "audi_engine.jpg", 89, 70, 21000000);

        private void Btn_Renault_Click(object sender, RoutedEventArgs e)
            => SelectEngine("Renault", "renault_engine.jpg", 85, 80, 17500000);

        // Spoločná metóda na uloženie výberu, nech to nekopíruješ ako vrah
        private void SelectEngine(string name, string path, int power, int reliability, int cost)
        {
            var db = Database.Instance;
            db.PlayerTeamInstance.EngineName = name;
            db.PlayerTeamInstance.Engine_Path = path;
            db.PlayerTeamInstance.EnginePower = power;
            db.PlayerTeamInstance.EngineReliability = reliability;
            db.PlayerTeamInstance.Budget -= cost; // Odčítame prachy
            Drivers_Pick dp = new Drivers_Pick();
            dp.Show();
            this.Close();
        }

        private void Btn_Mercedes_Click_1(object sender, RoutedEventArgs e)
        {
            SelectEngine("Mercedes", "mercedes_engine.jpg", 91, 98, 28500000);
        }

        private void Btn_Honda_Click_1(object sender, RoutedEventArgs e)
        {
            SelectEngine("Honda RBPT", "honda_engine.jpg", 96, 85, 23000000);
        }

        private void Btn_Audi_Click_1(object sender, RoutedEventArgs e)
        {
            SelectEngine("Audi Sport", "audi_engine.jpg", 89, 70, 21000000);
        }

        private void Btn_Renault_Click_1(object sender, RoutedEventArgs e)
        {
            SelectEngine("Renault", "renault_engine.jpg", 85, 80, 17500000);
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
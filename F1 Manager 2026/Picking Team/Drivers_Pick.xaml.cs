using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace F1_Manager_2026.Picking_Team
{
    public partial class Drivers_Pick : Window
    {
        public int timesselected = 0;
        public Drivers_Pick()
        {
            InitializeComponent();
            LoadDataToUI();
        }

        private void LoadDataToUI()
        {
            var allDrivers = Database.DriverList;
            if (allDrivers != null)
                DriversItemsControl.ItemsSource = allDrivers;
        }

        private void DriverCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border kliknutyBorder && kliknutyBorder.DataContext is Driver kliknutyJazdec)
            {
                // 1. Získame názov tímu, ktorý sme si vybrali v MainMenu
                string mojTim = GameState.PlayerTeamInstance.teamName;

                // 2. Nastavíme jazdcovi náš tím -> toto automaticky zmení SuitPath v triede Drivers
                kliknutyJazdec.Team = mojTim;

                // 3. Uložíme výber do globálneho stavu
                GameState.PlayerTeamInstance.driver1name = kliknutyJazdec.Name;
                GameState.PlayerTeamInstance.driver1rating = kliknutyJazdec.Skill;
                GameState.PlayerTeamInstance.driver1cost = kliknutyJazdec.Cost;

                if (timesselected < 1)
                {
                    MessageBox.Show($"Jazdec {kliknutyJazdec.Name} úspešne podpísaný za {mojTim}!");
                    timesselected++;
                }
                else
                {
                    MessageBox.Show($"Jazdec {kliknutyJazdec.Name} úspešne podpísaný za {mojTim}!");
                    this.Close();
                }
            }
        }

        private void DriverCard_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Border b)
            {
                b.BorderBrush = Brushes.Red;
                b.BorderThickness = new Thickness(4);
                b.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            }
        }

        private void DriverCard_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Border b)
            {
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(51, 51, 51));
                b.BorderThickness = new Thickness(2);
                b.Background = new SolidColorBrush(Color.FromRgb(26, 26, 26));
            }
        }
    }
}
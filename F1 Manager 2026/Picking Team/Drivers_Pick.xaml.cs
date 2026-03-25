using System.Media;
using System.Numerics;
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
            ResetMoney();
        }

        private void ResetMoney()
        {
            BudgetDisplay.Text = $"{Database.Instance.PlayerTeamInstance.Budget.ToString("N0")}$";
        }
        private void LoadDataToUI()
        {
            var allDrivers = Database.Instance.DriverList; 
            if (allDrivers != null)
                DriversItemsControl.ItemsSource = allDrivers;
        }

        private void DriverCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border kliknutyBorder && kliknutyBorder.DataContext is Driver kliknutyJazdec)
            {
                // 1. Získame názov tímu, ktorý sme si vybrali v MainMenu
                string mojTim = Database.Instance.PlayerTeamInstance.teamName;
                if (kliknutyJazdec.Team == mojTim)
                {
                    MessageBox.Show($"You have already selected: {kliknutyJazdec.Name}!", "Info", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                else
                {
                    if (timesselected < 1)
                    {
                        if (kliknutyJazdec.Cost > Database.Instance.PlayerTeamInstance.Budget)
                        {
                            MessageBox.Show($"Not enough money for: {kliknutyJazdec.Name}!", "Info", MessageBoxButton.OK, MessageBoxImage.Hand);
                            return;
                        }
                        else
                        {
                            MediaPlayer player = new MediaPlayer();
                            player.Open(new Uri("Sounds/signing.wav", UriKind.Relative));
                            player.Play();
                            Database.Instance.PlayerTeamInstance.Budget -= (decimal)kliknutyJazdec.Cost;
                            // 2. Nastavíme jazdcovi náš tím -> toto automaticky zmení SuitPath v triede Drivers
                            kliknutyJazdec.Team = mojTim;
                            // 3. Uložíme výber do globálneho stavu
                            Database.Instance.PlayerTeamInstance.driver1name = kliknutyJazdec.Name;
                            Database.Instance.PlayerTeamInstance.driver1rating = kliknutyJazdec.Skill;
                            Database.Instance.PlayerTeamInstance.driver1cost = kliknutyJazdec.Cost;
                            MessageBox.Show($"{kliknutyJazdec.Name} has agreed to sign contract with your team: {mojTim}!");
                            ResetMoney();
                            timesselected++;
                        }
                    }
                    else
                    {
                        if (kliknutyJazdec.Cost > Database.Instance.PlayerTeamInstance.Budget)
                        {
                            MessageBox.Show($"Not enough money for: {kliknutyJazdec.Name}!", "Info", MessageBoxButton.OK, MessageBoxImage.Hand);
                            return;
                        }
                        else
                        {
                            MediaPlayer player = new MediaPlayer();
                            player.Open(new Uri("Sounds/signing.wav", UriKind.Relative));
                            player.Play();
                            Database.Instance.PlayerTeamInstance.Budget -= (decimal)kliknutyJazdec.Cost;
                            // 2. Nastavíme jazdcovi náš tím -> toto automaticky zmení SuitPath v triede Drivers
                            kliknutyJazdec.Team = mojTim;
                            // 3. Uložíme výber do globálneho stavu
                            Database.Instance.PlayerTeamInstance.driver2name = kliknutyJazdec.Name;
                            Database.Instance.PlayerTeamInstance.driver2rating = kliknutyJazdec.Skill;
                            Database.Instance.PlayerTeamInstance.driver2cost = kliknutyJazdec.Cost;
                            MessageBox.Show($"Jazdec {kliknutyJazdec.Name} úspešne podpísaný za {mojTim}!");
                            ResetMoney();
                            timesselected++;
                            MessageBox.Show("You have selected 2 drivers, you cannot select more!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                    }
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
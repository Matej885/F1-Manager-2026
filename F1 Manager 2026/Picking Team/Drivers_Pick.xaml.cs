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
            if (sender is Border b && b.DataContext is Driver kliknuty)
            {
                var db = Database.Instance;
                var p = db.PlayerTeamInstance;

                if (timesselected >= 2)
                {
                    MessageBox.Show("You have 2 drivers already"); return;
                }

                if (kliknuty.Team == p.teamName)
                {
                    MessageBox.Show("He already drives with you!", "Warning", MessageBoxButton.OK, MessageBoxImage.Hand); return;
                }

                if (p.Prestige < kliknuty.minprestige)
                {
                    MessageBox.Show($"Your prestige is too low! {kliknuty.Name} does not want to sign a contract with you. Continue to score points or win and you can talk with the driver later again!");
                    return;
                }

                if (p.Budget < (decimal)kliknuty.Cost)
                {
                    MessageBox.Show("Low on cash!", "Warning", MessageBoxButton.OK,MessageBoxImage.Hand);
                    return;
                }

                // AK PREŠIEL, PODPISUJEME
                string povodnyTim = kliknuty.Team;
                p.Budget -= (decimal)kliknuty.Cost;

                if (timesselected == 0)
                {
                    p.driver1name = kliknuty.Name;
                    p.driver1cost = kliknuty.Cost;
                    p.driver1rating = kliknuty.Skill;
                }
                else if (timesselected == 1)
                {
                    p.driver2name = kliknuty.Name;
                    p.driver2cost = kliknuty.Cost;
                    p.driver2rating = kliknuty.Skill;
                    MessageBox.Show($"You have signed a contract with {Database.Instance.PlayerTeamInstance.driver1name} for {Database.Instance.PlayerTeamInstance.driver1cost.ToString("N0")} $ and {Database.Instance.PlayerTeamInstance.driver2name} for {Database.Instance.PlayerTeamInstance.driver2cost.ToString("N0")} $", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                kliknuty.Team = p.teamName;
                kliknuty.IsF2 = false;

                timesselected++;
                ResetMoney();
                if (timesselected == 2) this.Close();
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
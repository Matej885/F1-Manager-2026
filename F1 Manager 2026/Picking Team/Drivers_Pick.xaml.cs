using System.Windows;

namespace F1_Manager_2026.Picking_Team
{
    public partial class Drivers_Pick : Window
    {
        public Drivers_Pick()
        {
            InitializeComponent();
            DriversItemsControl.ItemsSource = Drivers.GetAllDrivers();
        }
    }
}
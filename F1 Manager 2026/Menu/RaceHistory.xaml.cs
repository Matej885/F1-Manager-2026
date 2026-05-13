using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace F1_Manager_2026.Menu
{
    /// <summary>
    /// Interaction logic for RaceHistory.xaml
    /// </summary>
    public partial class RaceHistory : Window
    {
        public RaceHistory()
        {
            InitializeComponent();
            LoadRaceHistory();
        }

        private void LoadRaceHistory()
        {
            HistoryGrid.ItemsSource = Database.Instance.RaceHistory
                .OrderBy(r => r.RoundNumber)
                .ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new MainCareerMenu().Show();
            this.Close();
        }
    }
}
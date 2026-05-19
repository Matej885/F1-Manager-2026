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

namespace F1_Manager_2026.Menu
{
    public partial class RaceHistoryDetail : Window
    {
        public RaceHistoryDetail(RaceWeekendHistory historyEntry)
        {
            InitializeComponent();
            DataContext = historyEntry;
            ResultsGrid.ItemsSource = historyEntry.FullResults
                .OrderBy(r => r.Position)
                .ToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            new MainCareerMenu().Show();
            this.Close();
        }
    }
}
using F1_Manager_2026.Picking_Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace F1_Manager_2026.Menu
{
    public partial class Standings : Window
    {
        // Vlastnosti pre Binding v XAML
        public Driver Top1 { get; set; }
        public Driver Top2 { get; set; }
        public Driver Top3 { get; set; }
        public List<Driver> OtherDrivers { get; set; }

        public Standings()
        {
            InitializeComponent();
            var db = Database.Instance;
            if (db.CurrentDayInfo.EndOfSeason == true)
            {
                BackButton.Content = "Continue to boss negotiation"; 
            }
            LoadStandingsData();
            this.DataContext = this; // Dôležité pre fungovanie {Binding ...}
        }

        private void LoadStandingsData()
        {
                var sortedList = Database.Instance.DriverList
                .OrderByDescending(d => d.Points)
                .ToList();

            // Priradenie pre pódium (ošetrené, ak by bolo v liste menej jazdcov)
            if (sortedList.Count >= 1) Top1 = sortedList[0];
            if (sortedList.Count >= 2) Top2 = sortedList[1];
            if (sortedList.Count >= 3) Top3 = sortedList[2];

            // Ostatní od 4. miesta nižšie
            OtherDrivers = sortedList.Skip(3).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            var db = Database.Instance;
            if (db.CurrentDayInfo.EndOfSeason == true)
            {
               Engine_Pick DP = new Engine_Pick();
                this.Close();
                DP.Show();
            }
            else
            {
                MainCareerMenu mainMenu = new MainCareerMenu();
                mainMenu.Show();
            }
            this.Close();
        }
    }
}
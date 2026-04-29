using System;
using System.Collections.Generic;
using System.Linq;

namespace F1_Manager_2026.Menu
{
    public class TeamStandings
    {
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string ImagePath { get; set; }
        public int Points { get; set; }
        public int Wins { get; set; }
        public int Podiums { get; set; }
        public List<Driver> Drivers { get; set; }

        public TeamStandings()
        {
            Drivers = new List<Driver>();
        }

        public TeamStandings(string name, string logoPath)
        {
            Name = name;
            LogoPath = logoPath;
            ImagePath = logoPath;
            Points = 0;
            Wins = 0;
            Podiums = 0;
            Drivers = new List<Driver>();
        }

        public void AddDriver(Driver driver)
        {
            Drivers.Add(driver);
            Points += driver.Points;
            Wins += driver.Wins;
            Podiums += driver.Podiums;
        }
    }
}


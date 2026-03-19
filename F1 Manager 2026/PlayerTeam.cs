using System;
using System.Collections.Generic;
using System.Text;

namespace F1_Manager_2026
{
    public class PlayerTeam
    {
        // Use string.Empty to satisfy the non-nullable requirement
        public string Logo { get; set; } = string.Empty;
        public string driver1name = string.Empty;
        public string driver2name = string.Empty;
        public string teamName = string.Empty;
        public string playername = string.Empty;

        public int driver1rating;
        public int driver1cost;
        public int Races = 0;
        public int driver2rating;
        public int pointsDriver1;
        public int pointsDriver2;
        public int driver2cost;
        public int Standings;
        public int TeamPower = 10;

        public decimal Budget { get; set; }
        public string teamtype { get; set; } = string.Empty;
        public int effectivity = 0;
        public string UpgradeName = string.Empty;
    }
}
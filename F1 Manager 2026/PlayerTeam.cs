using System;
using System.Collections.Generic;
using System.Text;

namespace F1_Manager_2026
{
    public class PlayerTeam
    {
        public string driver1name;
        public string driver2name;
        public string teamName;
        public string playername;
        public int driver1rating;
        public int driver1cost;
        public int Races = 0;
        public int driver2rating;
        public int pointsDriver1;
        public int pointsDriver2;
        public int driver2cost;
        public int Standings;
        public int TeamPower = 10;
        public int Money { get; set; } = 10000;
        public string teamtype { get; set; }
        public int effectivity = 0;
        public string UpgradeName = "";
    }
}

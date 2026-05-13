using System.Collections.Generic;

namespace F1_Manager_2026
{
    public class RaceWeekendHistory
    {
        public int RoundNumber { get; set; }
        public string TrackName { get; set; } = "";
        public string WinnerName { get; set; } = "";
        public string WinnerTeam { get; set; } = "";
        public int Driver1Pos { get; set; }
        public int Driver2Pos { get; set; }
        public int TotalPoints { get; set; }
        public bool IsPodium { get; set; }
        public List<RaceResultEntry> FullResults { get; set; } = new List<RaceResultEntry>();
    }

    public class RaceResultEntry
    {
        public int Position { get; set; }
        public string DriverName { get; set; } = "";
        public string TeamName { get; set; } = "";
        public int PointsEarned { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace F1_Manager_2026
{
    public class Tracks
    {
        private bool raceday = false;
        public class Race
        {
            public string TrackName { get; set; }
            public int RaceDay { get; set; }

            public Race(string name, int day)
            {
                TrackName = name;
                RaceDay = day;
            }
        }

        public List<Race> AllRaces = new List<Race>();

        public Tracks()
        {
            AllRaces.Add(new Race("Bahrain", 15));
            AllRaces.Add(new Race("Jeddah", 22));
            AllRaces.Add(new Race("Melbourne", 30));
            AllRaces.Add(new Race("Suzuka", 45));
            AllRaces.Add(new Race("Shanghai", 52));
            AllRaces.Add(new Race("Miami", 67));
            AllRaces.Add(new Race("Imola", 75));
            AllRaces.Add(new Race("Monaco", 80));
            AllRaces.Add(new Race("Montreal", 87));
            AllRaces.Add(new Race("Barcelona", 120));
            AllRaces.Add(new Race("Red Bull Ring", 127));
            AllRaces.Add(new Race("Silverstone", 134));
            AllRaces.Add(new Race("Hungaroring", 141));
            AllRaces.Add(new Race("Spa-Francorchamps", 148));
            AllRaces.Add(new Race("Zandvoort", 155));
            AllRaces.Add(new Race("Monza", 162));
            AllRaces.Add(new Race("Baku", 169));
            AllRaces.Add(new Race("Singapore", 171));
            AllRaces.Add(new Race("Austin", 179));
            AllRaces.Add(new Race("Mexico City", 185));
            AllRaces.Add(new Race("Interlagos", 192));
            AllRaces.Add(new Race("Las Vegas", 199));
            AllRaces.Add(new Race("Lusail", 206));
            AllRaces.Add(new Race("Abu Dhabi", 213));
        }

        // Funkcia na kontrolu, či sa dnes jazdí
        /* public void CheckRaceDay(int currentDay)
        {
            foreach (var race in AllRaces)
            {
                if (race.RaceDay == currentDay - 1)
                {
                    List<Teams> allTeams = Teams.TeamList.AllTeams;
                    RaceSimulation raceSimulation = new RaceSimulation(allTeams);
                    Console.WriteLine($"Vitaj na trati {race.TrackName}");
                    Console.WriteLine("Ak si chceš pozrieť rebríček tímov a jazdcov");
                    raceSimulation.SimulateRace();
                    raceday = true;
                }
                else
                {
                    raceday = false;
                }
            }
        }*/
    }
}

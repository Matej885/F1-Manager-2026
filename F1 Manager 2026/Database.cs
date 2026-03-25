using System;
using System.Collections.Generic;
using System.Linq;

namespace F1_Manager_2026
{
    // 1. STATICKÁ DATABÁZA
    public static class Database
    {
        public static List<Driver> DriversList { get; set; } = new List<Driver>();

        static Database()
        {
            // Naplnenie listu pri štarte aplikácie
            DriversList = Driver.GetAllDrivers();
        }
    }

    // 2. TRIEDA PRE JAZDCA (Premenovaná na Driver, aby sa neplietla s listom)
    public class Driver
    {
        private string? _team;
        public string? Name { get; set; }
        public int Number { get; set; }
        public string? PhotoPath { get; set; }
        public string? SuitPath { get; private set; }
        public int Skill { get; set; }
        public int Cost { get; set; }

        public string? Team
        {
            get => _team;
            set
            {
                _team = value;
                UpdateSuitPath();
            }
        }

        public string FormattedCost
        {
            get
            {
                double costValue = (Skill - 60) * 0.8;
                return "COST: $" + costValue.ToString("F1") + "M";
            }
        }

        private void UpdateSuitPath()
        {
            string folder = "/Images/";
            if (_team == null) { SuitPath = folder + "suit_default.png"; return; }

            SuitPath = _team switch
            {
                "McLaren" => folder + "suit_mclaren.png",
                "Ferrari" => folder + "suit_ferrari.png",
                "Red Bull Racing" => folder + "RB_suit.png",
                "Mercedes" => folder + "suit_mercedes.png",
                "Aston Martin" => folder + "suit_astonmartin.png",
                "Alpine" => folder + "suit_alpine.png",
                "Haas" => folder + "suit_haas.png",
                "RB" => folder + "suit_RBJ.png",
                "Williams" => folder + "suit_williams1.png",
                "Cadillac" => folder + "suit_cadillac.png",
                "Audi" => folder + "suit_audi.png",
                _ => folder + "suit_default.png"
            };
        }

        // STATICKÉ DEFINÍCIE JAZDCOV
        public static Driver Lando_Norris = new Driver { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/norris.png", Skill = 95, Team = "McLaren", Cost = 70000000 };
        public static Driver Oscar_Piastri = new Driver { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/piastri.png", Skill = 92, Team = "McLaren", Cost = 67000000 };
        public static Driver Charles_Leclerc = new Driver { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/leclerc.png", Skill = 94, Team = "Ferrari", Cost = 70000000 };
        public static Driver Lewis_Hamilton = new Driver { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/hamilton.png", Skill = 93, Team = "Ferrari", Cost = 83000000 };
        public static Driver Max_Verstappen = new Driver { Name = "Max Verstappen", Number = 33, PhotoPath = "/Images/verstappen.png", Skill = 96, Team = "Red Bull Racing", Cost = 85000000 };
        public static Driver Isack_Hadjar = new Driver { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/hadjar.png", Skill = 80, Team = "Red Bull Racing", Cost = 1000000 };
        public static Driver George_Russell = new Driver { Name = "George Russell", Number = 63, PhotoPath = "/Images/russell.png", Skill = 90, Team = "Mercedes", Cost = 45000000 };
        public static Driver Kimi_Antonelli = new Driver { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/antonelli.png", Skill = 84, Team = "Mercedes", Cost = 38000000 };
        public static Driver Fernando_Alonso = new Driver { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/alonso.png", Skill = 88, Team = "Aston Martin", Cost = 50000000 };
        public static Driver Lance_Stroll = new Driver { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/stroll.png", Skill = 78, Team = "Aston Martin", Cost = 1000000 };
        public static Driver Pierre_Gasly = new Driver { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/gasly.png", Skill = 85, Team = "Alpine", Cost = 15000000 };
        public static Driver Franco_Colapinto = new Driver { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/colapinto.png", Skill = 82, Team = "Alpine", Cost = 500000 };
        public static Driver Oliver_Bearman = new Driver { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/bearman.png", Skill = 81, Team = "Haas", Cost = 1000000 };
        public static Driver Esteban_Ocon = new Driver { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/ocon.png", Skill = 83, Team = "Haas", Cost = 5000000 };
        public static Driver Liam_Lawson = new Driver { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/lawson.png", Skill = 83, Team = "RB", Cost = 1000000 };
        public static Driver Arvid_Lindblad = new Driver { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/lindblad.png", Skill = 79, Team = "RB", Cost = 0 };
        public static Driver Alex_Albon = new Driver { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/albon.png", Skill = 86, Team = "Williams", Cost = 25000000 };
        public static Driver Carlos_Sainz = new Driver { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/sainz.png", Skill = 91, Team = "Williams", Cost = 42000000 };
        public static Driver Valtteri_Bottas = new Driver { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/bottas.png", Skill = 84, Team = "Cadillac", Cost = 0 };
        public static Driver Sergio_Perez = new Driver { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/perez.png", Skill = 82, Team = "Cadillac", Cost = 0 };
        public static Driver Nico_Hulkenberg = new Driver { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/hulkenberg.png", Skill = 84, Team = "Audi", Cost = 10000000 };
        public static Driver Gabriel_Bortoleto = new Driver { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/bortoleto.png", Skill = 80, Team = "Audi", Cost = 5000000 };

        public static List<Driver> GetAllDrivers()
        {
            return new List<Driver>
            {
                Max_Verstappen, Lando_Norris, Charles_Leclerc, Lewis_Hamilton, Oscar_Piastri,
                Carlos_Sainz, George_Russell, Fernando_Alonso, Alex_Albon, Pierre_Gasly,
                Valtteri_Bottas, Nico_Hulkenberg, Kimi_Antonelli, Esteban_Ocon, Liam_Lawson,
                Franco_Colapinto, Sergio_Perez, Oliver_Bearman, Isack_Hadjar,
                Gabriel_Bortoleto, Arvid_Lindblad, Lance_Stroll
            };
        }
    }

}
using System;
using System.Collections.Generic;

namespace F1_Manager_2026
{
    public class Drivers
    {
        // Pridaný otáznik (string?), aby kompilátor nehlásil chybu "Non-nullable field"
        private string? _team;
        public string? Name { get; set; }
        public int Number { get; set; }
        public string? PhotoPath { get; set; }
        public string? SuitPath { get; private set; }
        public int Skill { get; set; }
        public int Cost { get; set; }
        public string? Team
        {
            get { return _team; }
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
                double cost = (Skill - 60) * 0.8;
                return "COST: $" + cost.ToString("F1") + "M";
            }
        }

        private void UpdateSuitPath()
        {
            string folder = "/Images/";
            if (_team == null) { SuitPath = folder + "suit_default.png"; return; }

            switch (_team)
            {
                case "McLaren": SuitPath = folder + "suit_mclaren.png"; break;
                case "Ferrari": SuitPath = folder + "suit_ferrari.png"; break;
                case "Red Bull Racing": SuitPath = folder + "RB_suit.png"; break;
                case "Mercedes": SuitPath = folder + "suit_mercedes.png"; break;
                case "Aston Martin": SuitPath = folder + "suit_astonmartin.png"; break;
                case "Alpine": SuitPath = folder + "suit_alpine.png"; break;
                case "Haas": SuitPath = folder + "suit_haas.png"; break;
                case "RB": SuitPath = folder + "suit_RBJ.png"; break;
                case "Williams": SuitPath = folder + "suit_williams1.png"; break;
                case "Cadillac": SuitPath = folder + "suit_cadillac.png"; break;
                case "Audi": SuitPath = folder + "suit_audi.png"; break;
                case "ART Grand Prix": SuitPath = folder + "suit_art.png"; break;
                case "Invicta Racing": SuitPath = folder + "suit_invicta.png"; break;
                case "MP Motorsport": SuitPath = folder + "suit_mp.png"; break;
                case "Campos Racing": SuitPath = folder + "suit_campos.png"; break;
                case "Rodin Motorsport": SuitPath = folder + "suit_rodin.png"; break;
                case "DAMS Lucas Oil": SuitPath = folder + "suit_dams.png"; break;
                case "Trident": SuitPath = folder + "suit_trident.png"; break;
                case "Hitech": SuitPath = folder + "suit_hitech.png"; break;
                case "Prema": SuitPath = folder + "suit_prema.png"; break;
                case "Van Amersfoort Racing": SuitPath = folder + "suit_var.png"; break;
                case "AIX Racing": SuitPath = folder + "suit_aix.png"; break;
                    case "Minardi": SuitPath = folder + "suit_minardi.png"; break;
                    case "Siemens": SuitPath = folder + "suit_siemens.png"; break;
                default: SuitPath = folder + "suit_default.png"; break;
            }
        }

        // VŠETCI JAZDCI DEFINOVANÍ AKO PUBLIC STATIC
        public static Drivers Lando_Norris = new Drivers { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/norris.png", Skill = 95, Team = "Siemens", Cost = 70000000 };
        public static Drivers Oscar_Piastri = new Drivers { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/piastri.png", Skill = 92, Team = "McLaren", Cost = 67000000 };
        public static Drivers Charles_Leclerc = new Drivers { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/leclerc.png", Skill = 94, Team = "Ferrari", Cost = 70000000 };
        public static Drivers Lewis_Hamilton = new Drivers { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/hamilton.png", Skill = 93, Team = "Ferrari", Cost = 83000000 };
        public static Drivers Max_Verstappen = new Drivers { Name = "Max Verstappen", Number = 33, PhotoPath = "/Images/verstappen.png", Skill = 96, Team = "Siemens", Cost = 85000000 };
        public static Drivers Isack_Hadjar = new Drivers { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/hadjar.png", Skill = 80, Team = "Red Bull Racing", Cost = 1000000 };
        public static Drivers George_Russell = new Drivers { Name = "George Russell", Number = 63, PhotoPath = "/Images/russell.png", Skill = 90, Team = "Mercedes", Cost = 45000000 };
        public static Drivers Kimi_Antonelli = new Drivers { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/antonelli.png", Skill = 84, Team = "Mercedes", Cost = 38000000 };
        public static Drivers Fernando_Alonso = new Drivers { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/alonso.png", Skill = 88, Team = "Aston Martin", Cost = 50000000 };
        public static Drivers Lance_Stroll = new Drivers { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/stroll.png", Skill = 78, Team = "Aston Martin", Cost = 1000000 };
        public static Drivers Pierre_Gasly = new Drivers { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/gasly.png", Skill = 85, Team = "Alpine", Cost = 15000000 };
        public static Drivers Franco_Colapinto = new Drivers { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/colapinto.png", Skill = 82, Team = "Alpine", Cost = 500000 };
        public static Drivers Oliver_Bearman = new Drivers { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/bearman.png", Skill = 81, Team = "Haas", Cost = 1000000 };
        public static Drivers Esteban_Ocon = new Drivers { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/ocon.png", Skill = 83, Team = "Haas", Cost = 5000000 };
        public static Drivers Liam_Lawson = new Drivers { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/lawson.png", Skill = 83, Team = "RB", Cost = 1000000 };
        public static Drivers Arvid_Lindblad = new Drivers { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/lindblad.png", Skill = 79, Team = "RB", Cost = 0 };
        public static Drivers Alex_Albon = new Drivers { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/albon.png", Skill = 86, Team = "Williams", Cost = 25000000 };
        public static Drivers Carlos_Sainz = new Drivers { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/sainz.png", Skill = 91, Team = "Williams", Cost = 42000000 };
        public static Drivers Valtteri_Bottas = new Drivers { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/bottas.png", Skill = 84, Team = "Cadillac", Cost = 0 };
        public static Drivers Sergio_Perez = new Drivers { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/perez.png", Skill = 82, Team = "Cadillac", Cost = 0 };
        public static Drivers Nico_Hulkenberg = new Drivers { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/hulkenberg.png", Skill = 84, Team = "Audi", Cost = 10000000 };
        public static Drivers Gabriel_Bortoleto = new Drivers { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/bortoleto.png", Skill = 80, Team = "Audi", Cost = 5000000 };

        public static List<Drivers> GetAllDrivers()
        {
            List<Drivers> allDrivers = new List<Drivers>();

            // Pole so všetkými jazdcami
            Drivers[] array = new Drivers[] {
                Max_Verstappen, Lando_Norris, Charles_Leclerc, Lewis_Hamilton, Oscar_Piastri,
                Carlos_Sainz, George_Russell, Fernando_Alonso, Alex_Albon, Pierre_Gasly,
                Valtteri_Bottas, Nico_Hulkenberg, Kimi_Antonelli, Esteban_Ocon, Liam_Lawson,
                Franco_Colapinto, Sergio_Perez, Oliver_Bearman, Isack_Hadjar,
                Gabriel_Bortoleto, Arvid_Lindblad, Lance_Stroll
            };

            int index = 0;
            while (index < array.Length)
            {
                allDrivers.Add(array[index]);
                index = index + 1;
            }

            return allDrivers;
        }
    }
}
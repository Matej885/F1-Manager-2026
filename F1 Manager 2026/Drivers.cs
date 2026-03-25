using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace F1_Manager_2026
{
    public class Drivers : INotifyPropertyChanged
    {
        private string? _team;
        private string? _suitPath;

        public string? Name { get; set; }
        public int Number { get; set; }
        public string? PhotoPath { get; set; }
        public int Skill { get; set; }
        public int Cost { get; set; }

        public string? Team
        {
            get => _team;
            set
            {
                _team = value;
                UpdateSuitPath();
                OnPropertyChanged();
            }
        }

        public string? SuitPath
        {
            get => _suitPath;
            private set
            {
                _suitPath = value;
                OnPropertyChanged();
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
            if (string.IsNullOrEmpty(_team)) { SuitPath = folder + "suit_default.png"; return; }

            // Logika pre tvoje vybrateľné tímy
            if (_team.Contains("Minardi")) SuitPath = folder + "suit_minardi.png";
            else if (_team.Contains("Alfa Romeo")) SuitPath = folder + "suit_alfa.png";
            else if (_team.Contains("BMW")) SuitPath = folder + "suit_bmw.png";
            else if (_team.Contains("Siemens")) SuitPath = folder + "suit_siemens.png";

            // Logika pre pôvodné tímy jazdcov
            else switch (_team)
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
                    default: SuitPath = folder + "suit_default.png"; break;
                }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static List<Drivers> GetAllDrivers()
        {
            return new List<Drivers>
            {
                new Drivers { Name = "Max Verstappen", Number = 33, PhotoPath = "/Images/verstappen.png", Skill = 96, Team = "Red Bull Racing", Cost = 85000000 },
                new Drivers { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/norris.png", Skill = 95, Team = "McLaren", Cost = 70000000 },
                new Drivers { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/leclerc.png", Skill = 94, Team = "Ferrari", Cost = 70000000 },
                new Drivers { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/hamilton.png", Skill = 93, Team = "Ferrari", Cost = 83000000 },
                new Drivers { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/piastri.png", Skill = 92, Team = "McLaren", Cost = 67000000 },
                new Drivers { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/sainz.png", Skill = 91, Team = "Williams", Cost = 42000000 },
                new Drivers { Name = "George Russell", Number = 63, PhotoPath = "/Images/russell.png", Skill = 90, Team = "Mercedes", Cost = 45000000 },
                new Drivers { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/alonso.png", Skill = 88, Team = "Aston Martin", Cost = 50000000 },
                new Drivers { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/albon.png", Skill = 86, Team = "Williams", Cost = 25000000 },
                new Drivers { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/gasly.png", Skill = 85, Team = "Alpine", Cost = 15000000 },
                new Drivers { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/bottas.png", Skill = 84, Team = "Cadillac", Cost = 0 },
                new Drivers { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/hulkenberg.png", Skill = 84, Team = "Audi", Cost = 10000000 },
                new Drivers { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/antonelli.png", Skill = 84, Team = "Mercedes", Cost = 38000000 },
                new Drivers { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/ocon.png", Skill = 83, Team = "Haas", Cost = 5000000 },
                new Drivers { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/lawson.png", Skill = 83, Team = "RB", Cost = 1000000 },
                new Drivers { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/colapinto.png", Skill = 82, Team = "Alpine", Cost = 500000 },
                new Drivers { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/perez.png", Skill = 82, Team = "Cadillac", Cost = 0 },
                new Drivers { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/bearman.png", Skill = 81, Team = "Haas", Cost = 1000000 },
                new Drivers { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/hadjar.png", Skill = 80, Team = "Red Bull Racing", Cost = 1000000 },
                new Drivers { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/bortoleto.png", Skill = 80, Team = "Audi", Cost = 5000000 },
                new Drivers { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/lindblad.png", Skill = 79, Team = "RB", Cost = 0 },
                new Drivers { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/stroll.png", Skill = 78, Team = "Aston Martin", Cost = 1000000 }
            };
        }
    }
}
using System.Collections.Generic;

namespace F1_Manager_2026
{
    public static class Database
    {
        public static List<Driver> DriverList { get; set; }

        static Database()
        {
            DriverList = new List<Driver>
            {
                new Driver { Name = "Max Verstappen", Number = 33, PhotoPath = "/Images/verstappen.png", Skill = 96, Team = "Red Bull Racing", Cost = 85000000 },
                new Driver { Name = "Lando Norris", Number = 4, PhotoPath = "/Images/norris.png", Skill = 95, Team = "McLaren", Cost = 70000000 },
                new Driver { Name = "Charles Leclerc", Number = 16, PhotoPath = "/Images/leclerc.png", Skill = 94, Team = "Ferrari", Cost = 70000000 },
                new Driver { Name = "Lewis Hamilton", Number = 44, PhotoPath = "/Images/hamilton.png", Skill = 93, Team = "Ferrari", Cost = 83000000 },
                new Driver { Name = "Oscar Piastri", Number = 81, PhotoPath = "/Images/piastri.png", Skill = 92, Team = "McLaren", Cost = 67000000 },
                new Driver { Name = "Carlos Sainz", Number = 55, PhotoPath = "/Images/sainz.png", Skill = 91, Team = "Williams", Cost = 42000000 },
                new Driver { Name = "George Russell", Number = 63, PhotoPath = "/Images/russell.png", Skill = 90, Team = "Mercedes", Cost = 45000000 },
                new Driver { Name = "Fernando Alonso", Number = 14, PhotoPath = "/Images/alonso.png", Skill = 88, Team = "Aston Martin", Cost = 50000000 },
                new Driver { Name = "Alex Albon", Number = 23, PhotoPath = "/Images/albon.png", Skill = 86, Team = "Williams", Cost = 25000000 },
                new Driver { Name = "Pierre Gasly", Number = 10, PhotoPath = "/Images/gasly.png", Skill = 85, Team = "Alpine", Cost = 15000000 },
                new Driver { Name = "Valtteri Bottas", Number = 77, PhotoPath = "/Images/bottas.png", Skill = 84, Team = "Cadillac", Cost = 0 },
                new Driver { Name = "Nico Hulkenberg", Number = 27, PhotoPath = "/Images/hulkenberg.png", Skill = 84, Team = "Audi", Cost = 10000000 },
                new Driver { Name = "Kimi Antonelli", Number = 12, PhotoPath = "/Images/antonelli.png", Skill = 84, Team = "Mercedes", Cost = 38000000 },
                new Driver { Name = "Esteban Ocon", Number = 31, PhotoPath = "/Images/ocon.png", Skill = 83, Team = "Haas", Cost = 5000000 },
                new Driver { Name = "Liam Lawson", Number = 30, PhotoPath = "/Images/lawson.png", Skill = 83, Team = "RB", Cost = 1000000 },
                new Driver { Name = "Franco Colapinto", Number = 43, PhotoPath = "/Images/colapinto.png", Skill = 82, Team = "Alpine", Cost = 500000 },
                new Driver { Name = "Sergio Perez", Number = 11, PhotoPath = "/Images/perez.png", Skill = 82, Team = "Cadillac", Cost = 0 },
                new Driver { Name = "Oliver Bearman", Number = 87, PhotoPath = "/Images/bearman.png", Skill = 81, Team = "Haas", Cost = 1000000 },
                new Driver { Name = "Isack Hadjar", Number = 6, PhotoPath = "/Images/hadjar.png", Skill = 80, Team = "Red Bull Racing", Cost = 1000000 },
                new Driver { Name = "Gabriel Bortoleto", Number = 5, PhotoPath = "/Images/bortoleto.png", Skill = 80, Team = "Audi", Cost = 5000000 },
                new Driver { Name = "Arvid Lindblad", Number = 41, PhotoPath = "/Images/lindblad.png", Skill = 79, Team = "RB", Cost = 0 },
                new Driver { Name = "Lance Stroll", Number = 18, PhotoPath = "/Images/stroll.png", Skill = 78, Team = "Aston Martin", Cost = 1000000 }
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Manager_2026
{
    public class F1Team
    {
        public string Name { get; set; } = "";
        public string LogoPath { get; set; } = "";
        public int Rating { get; set; } // Sila auta (0-100)

        public List<F1Team> F1Teams { get; set; } = new List<F1Team>
        {
    new F1Team { Name = "Red Bull Racing", Rating = 75, LogoPath = "/Images/redbull.png" },
    new F1Team { Name = "Ferrari", Rating = 97, LogoPath = "/Images/ferrari.png" },
    new F1Team { Name = "Mercedes-AMG", Rating = 100, LogoPath = "/Images/mercedes.png" },
    new F1Team { Name = "McLaren", Rating = 93, LogoPath = "/Images/mclaren.png" },
    new F1Team { Name = "Aston Martin Aramco", Rating = 50, LogoPath = "/Images/astonmartin.png" },
    new F1Team { Name = "Audi F1 Team", Rating = 72, LogoPath = "/Images/audi.png" },
    new F1Team { Name = "Alpine", Rating = 75, LogoPath = "/Images/alpine.png" },
    new F1Team { Name = "Williams Racing", Rating = 68, LogoPath = "/Images/williams.png" },
    new F1Team { Name = "Visa Cash App RB", Rating = 73, LogoPath = "/Images/rb.png" },
    new F1Team { Name = "Haas F1 Team", Rating = 76, LogoPath = "/Images/haas.png" },
    new F1Team { Name = "Cadillac F1 Team", Rating = 58, LogoPath = "/Images/cadillac.png" }
        };
    }
}

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
        public int Rating { get; set; } // Sila auta/zázemia (0-100)
        public int Prestige { get; set; } 
    }
}

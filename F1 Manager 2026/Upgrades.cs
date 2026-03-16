using System;
using System.Collections.Generic;
using System.Text;

namespace F1_Manager_2026
{
    public class Upgrades
    {
        public class AllUpgrades
        {
            public List<string> Parts = new List<string>();

            public void AddUpgrades()
            {
                Parts.Add("Power Unit Upgrade - Enhanced engine performance with improved hybrid deployment");
                Parts.Add("Front Wing Upgrade - Optimized aerodynamic balance for better cornering");
                Parts.Add("Rear Wing Upgrade - Refined downforce and DRS efficiency");
                Parts.Add("Suspension Upgrade - Advanced suspension for stability and precision handling");
                Parts.Add("Brake Upgrade - High-performance carbon brakes with superior responsiveness");
                Parts.Add("Transmission Upgrade - Seamless gearbox with faster and smoother shifts");
                Parts.Add("Tire Upgrade - Race-optimized compounds for consistent grip");
                Parts.Add("Fuel System Upgrade - Efficient fuel delivery for sustained performance");
                Parts.Add("Cooling System Upgrade - Enhanced thermal management for engine and ERS");
                Parts.Add("ERS Upgrade - Advanced energy recovery system for power boosts");
            }
        }
    }
}

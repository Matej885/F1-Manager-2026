using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace F1_Manager_2026.Picking_Team
{
    /// <summary>
    /// Logika pre okno Drivers_Pick.xaml
    /// </summary>
    public partial class Drivers_Pick : Window
    {
        public Drivers_Pick()
        {
            InitializeComponent();
            LoadDataToUI();
        }

        private void LoadDataToUI()
        {
            // Načítanie všetkých jazdcov zo statickej triedy Drivers
            List<Drivers> allDriversList = Drivers.GetAllDrivers();

            if (allDriversList != null)
            {
                if (allDriversList.Count > 0)
                {
                    // Naplnenie ItemsControl dátami
                    DriversItemsControl.ItemsSource = allDriversList;
                }
                else
                {
                    MessageBox.Show("Zoznam jazdcov je prázdny!");
                }
            }
            else
            {
                MessageBox.Show("Dáta jazdcov sa nepodarilo načítať (null).");
            }
        }

        // Táto metóda rieši Border pri vstupe myši
        private void DriverCard_MouseEnter(object sender, MouseEventArgs e)
        {
            // Pretypujeme sender na Border, aby sme k nemu mali prístup
            Border b = sender as Border;

            if (b != null)
            {
                // Nastavenie červeného okraja a hrúbky 4
                b.BorderBrush = Brushes.Red;
                b.BorderThickness = new Thickness(4);

                // Mierne zosvetlenie pozadia pre efekt "hover"
                b.Background = new SolidColorBrush(Color.FromRgb(40, 40, 40));
            }
        }

        // Táto metóda vráti Border do pôvodného stavu pri odchode myši
        private void DriverCard_MouseLeave(object sender, MouseEventArgs e)
        {
            Border b = sender as Border;

            if (b != null)
            {
                // Návrat k pôvodnej šedej farbe (#333333) a hrúbke 2
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(51, 51, 51));
                b.BorderThickness = new Thickness(2);

                // Návrat k pôvodnému tmavému pozadiu (#1A1A1A)
                b.Background = new SolidColorBrush(Color.FromRgb(26, 26, 26));
            }
        }
        private void DriverCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 1. Získame Border, na ktorý sa kliklo (Poradil Gemini) ---
            Border kliknutyBorder = (Border)sender;

            // 2. Vytiahneme si jazdca, ktorý patrí k tejto karte (vďaka Bindingu)
            Drivers kliknutyJazdec = (Drivers)kliknutyBorder.DataContext;

            // 3. Získame si zoznam všetkých jazdcov, aby sme v nich mohli hľadať
            List<Drivers> vsetciJazdci = Drivers.GetAllDrivers();

            // 4. Vytvoríme si prázdnu premennú, kam si uložíme výsledok
            Drivers najdenyJazdec = null;

            // 5. Prejdeme všetkých jazdcov jedného po druhom
            foreach (Drivers j in vsetciJazdci)
            {
                // Hladame meno jazdca v liste podla zdroja Bindingu z borderu
                if (j.Name == kliknutyJazdec.Name)
                {
                    PlayerTeam playerTeam = new PlayerTeam
                    {
                        driver1name = j.Name,
                        driver1rating = j.Skill,
                    };
                    playerTeam.driver1name = j.Name;
                    playerTeam.driver1rating = j.Skill;
                    playerTeam.driver1cost = j.Cost;
                    j.Team = playerTeam.teamName;
                    Drivers drivers = new Drivers();
                    Drivers_Pick pick = new Drivers_Pick();
                    pick.Show();
                    this.Close();
                    MessageBox.Show($"Vybral si jazdca: {playerTeam.driver1name} s ratingom {playerTeam.driver1rating}!");
                }
                else
                {
                    // Ak nie, pokračujeme v hľadaní ďalšieho jazdca
                    continue;
                }
            }
        }
    }
}
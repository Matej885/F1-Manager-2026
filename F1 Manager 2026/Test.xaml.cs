using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace F1_Manager_2026
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        private List<Drivers> f1Jazdci;
        private int aktualnyIndex = 0;

        public Test()
        {
            InitializeComponent();

            // Zoznam všetkých F1 jazdcov podľa tvojej triedy
            f1Jazdci = new List<Drivers>
            {
                Drivers.Lando_Norris,
                Drivers.Oscar_Piastri,
                Drivers.Charles_Leclerc,
                Drivers.Lewis_Hamilton,
                Drivers.Max_Verstappen,
                Drivers.Isack_Hadjar,
                Drivers.George_Russell,
                Drivers.Kimi_Antonelli,
                Drivers.Fernando_Alonso,
                Drivers.Lance_Stroll,
                Drivers.Pierre_Gasly,
                Drivers.Franco_Colapinto,
                Drivers.Oliver_Bearman,
                Drivers.Esteban_Ocon,
                Drivers.Liam_Lawson,
                Drivers.Arvid_Lindblad,
                Drivers.Alex_Albon,
                Drivers.Carlos_Sainz,
                Drivers.Valtteri_Bottas,
                Drivers.Sergio_Perez,
                Drivers.Nico_Hulkenberg,
                Drivers.Gabriel_Bortoleto
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonValtteri_Click(object sender, RoutedEventArgs e)
        {
            driverphoto_shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bottas.png", UriKind.Absolute));
        }

        private void ButtonBortoleto_Click(object sender, RoutedEventArgs e)
        {
            driverphoto_shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bortoleto.png", UriKind.Absolute));
        }

        private void ButtonHulk_Click(object sender, RoutedEventArgs e)
        {
            driverphoto_shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/piastri.png", UriKind.Absolute));
            racesuit_shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/RB_suit.png", UriKind.Absolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (f1Jazdci == null || f1Jazdci.Count == 0) return;

            Drivers vybranyJazdec = f1Jazdci[aktualnyIndex];

            try
            {
                driverphoto_shower.Source = new BitmapImage(new Uri("pack://application:,,," + vybranyJazdec.PhotoPath, UriKind.Absolute));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nepodarilo sa načítať obrázok: " + ex.Message);
            }

            aktualnyIndex++;

            if (aktualnyIndex >= f1Jazdci.Count)
            {
                aktualnyIndex = 0;
            }
        }
    }
}
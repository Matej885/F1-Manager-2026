using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Documents;
using System.ComponentModel;

namespace F1_Manager_2026.Picking_Team
{
    /// <summary>
    /// Interaction logic for Main_TeamChoosing.xaml
    /// </summary>
    public partial class Main_TeamChoosing : Window
    {
        public int Team_Chosen = 0;
        public Main_TeamChoosing()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Team_Chosen = 1;
            Difficulty_Grid1.Visibility = Visibility.Visible;
            Difficulty_Grid2.Visibility = Visibility.Visible;
            Difficulty_Grid3.Visibility = Visibility.Visible;
            Difficulty_Grid4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Visibility = Visibility.Visible;
            Car_Speed_Rectangle2.Visibility = Visibility.Visible;
            Car_Speed_Rectangle3.Visibility = Visibility.Visible;
            Car_Speed_Rectangle4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle5.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle2.Fill = new SolidColorBrush(Colors.Black);
            Car_Speed_Rectangle3.Fill = new SolidColorBrush(Colors.Black);
            Car_Speed_Rectangle4.Fill = new SolidColorBrush(Colors.Black);
            Car_Shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Minardi_Car.jpg", UriKind.Absolute));
            Logo_Shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/minardi-logo.png", UriKind.Absolute));
            Difficulty_Label.Visibility = Visibility.Visible;
            Money_Label.Visibility = Visibility.Visible;
            Car_Speed_Label.Visibility = Visibility.Visible;
            Difficulty_Grid1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid2.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid3.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid4.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Description_Text.Text = "Forget the corporate billions. Minardi is back for 2026, and they’ve brought nothing but a dream and a set of old wrenches. You are the grid's biggest underdog—starting with the smallest budget, aging facilities, and a car that has to fight for every single position.\r\n\r\nThis isn't about luxury; it’s about survival. Every point is a miracle, and every finish is a victory. The giants expect you to fail, but they’ve forgotten one thing: heart can’t be bought. Do you have the grit to turn this garage team into a giant-slayer? Welcome to the hardest seat in Formula 1";
            Money_Description_Label.Content = "80,000,000 $";
            Team_Name_Label.Content = "Minardi F1 Team";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Team_Chosen = 2;
            Difficulty_Grid1.Visibility = Visibility.Visible;
            Difficulty_Grid2.Visibility = Visibility.Visible;
            Difficulty_Grid3.Visibility = Visibility.Visible;
            Difficulty_Grid4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Visibility = Visibility.Visible;
            Car_Speed_Rectangle2.Visibility = Visibility.Visible;
            Car_Speed_Rectangle3.Visibility = Visibility.Visible;
            Car_Speed_Rectangle4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle5.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle2.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle3.Fill = new SolidColorBrush(Colors.Black);
            Car_Speed_Rectangle4.Fill = new SolidColorBrush(Colors.Black);
            Car_Shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/AlfaRomeo_Car.jpg", UriKind.Absolute));
            Logo_Shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/AlfaRomeo-logo.jpg", UriKind.Absolute));
            Difficulty_Label.Visibility = Visibility.Visible;
            Money_Label.Visibility = Visibility.Visible;
            Car_Speed_Label.Visibility = Visibility.Visible;
            Difficulty_Grid1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid2.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid3.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid4.Visibility = Visibility.Hidden;
            Description_Text.Text = "Forget the corporate billions. Minardi is back for 2026, and they’ve brought nothing but a dream and a set of old wrenches. You are the grid's biggest underdog—starting with the smallest budget, aging facilities, and a car that has to fight for every single position.\r\n\r\nThis isn't about luxury; it’s about survival. Every point is a miracle, and every finish is a victory. The giants expect you to fail, but they’ve forgotten one thing: heart can’t be bought. Do you have the grit to turn this garage team into a giant-slayer? Welcome to the hardest seat in Formula 1";
            Money_Description_Label.Content = "140,000,000 $";
            Team_Name_Label.Content = "Alfa Romeo F1 Team";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Team_Chosen = 3;
            Difficulty_Grid1.Visibility = Visibility.Visible;
            Difficulty_Grid2.Visibility = Visibility.Visible;
            Difficulty_Grid3.Visibility = Visibility.Visible;
            Difficulty_Grid4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Visibility = Visibility.Visible;
            Car_Speed_Rectangle2.Visibility = Visibility.Visible;
            Car_Speed_Rectangle3.Visibility = Visibility.Visible;
            Car_Speed_Rectangle4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle5.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle2.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle3.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle4.Fill = new SolidColorBrush(Colors.Black);
            Car_Shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/BMW_Car.jpg", UriKind.Absolute));
            Logo_Shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/BMW_Logo.png", UriKind.Absolute));
            Difficulty_Label.Visibility = Visibility.Visible;
            Money_Label.Visibility = Visibility.Visible;
            Car_Speed_Label.Visibility = Visibility.Visible;
            Difficulty_Grid1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid2.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid3.Visibility = Visibility.Hidden;
            Difficulty_Grid4.Visibility = Visibility.Hidden;
            Description_Text.Text = "Forget the corporate billions. Minardi is back for 2026, and they’ve brought nothing but a dream and a set of old wrenches. You are the grid's biggest underdog—starting with the smallest budget, aging facilities, and a car that has to fight for every single position.\r\n\r\nThis isn't about luxury; it’s about survival. Every point is a miracle, and every finish is a victory. The giants expect you to fail, but they’ve forgotten one thing: heart can’t be bought. Do you have the grit to turn this garage team into a giant-slayer? Welcome to the hardest seat in Formula 1";
            Money_Description_Label.Content = "180,000,000 $";
            Team_Name_Label.Content = "BMW Sauber F1 Team";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Team_Chosen = 4;
            Difficulty_Grid1.Visibility = Visibility.Visible;
            Difficulty_Grid2.Visibility = Visibility.Visible;
            Difficulty_Grid3.Visibility = Visibility.Visible;
            Difficulty_Grid4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Visibility = Visibility.Visible;
            Car_Speed_Rectangle2.Visibility = Visibility.Visible;
            Car_Speed_Rectangle3.Visibility = Visibility.Visible;
            Car_Speed_Rectangle4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle5.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle2.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle3.Fill = new SolidColorBrush(Colors.White);
            Car_Speed_Rectangle4.Fill = new SolidColorBrush(Colors.White);
            Car_Shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Siemens_Car.jpg", UriKind.Absolute));
            Logo_Shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/Siemens-logo.png", UriKind.Absolute));
            Difficulty_Label.Visibility = Visibility.Visible;
            Money_Label.Visibility = Visibility.Visible;
            Car_Speed_Label.Visibility = Visibility.Visible;
            Difficulty_Grid1.Source = new BitmapImage(new Uri("pack://application:,,,/Images/coloured_tire_difficulty.png", UriKind.Absolute));
            Difficulty_Grid2.Visibility = Visibility.Hidden;
            Difficulty_Grid3.Visibility = Visibility.Hidden;
            Difficulty_Grid4.Visibility = Visibility.Hidden;
            Description_Text.Text = "Forget the corporate billions. Minardi is back for 2026, and they’ve brought nothing but a dream and a set of old wrenches. You are the grid's biggest underdog—starting with the smallest budget, aging facilities, and a car that has to fight for every single position.\r\n\r\nThis isn't about luxury; it’s about survival. Every point is a miracle, and every finish is a victory. The giants expect you to fail, but they’ve forgotten one thing: heart can’t be bought. Do you have the grit to turn this garage team into a giant-slayer? Welcome to the hardest seat in Formula 1";
            Money_Description_Label.Content = "210,000,000 $";
            Team_Name_Label.Content = "Siemens Racing F1 Team";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Team_Chosen == 0)
            {
                MessageBox.Show("Pick your team first!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (Team_Chosen == 1)
                {
                    PlayerTeam playerTeam = new PlayerTeam();
                    GameState.InitializeTeam(1);
                    Drivers_Pick drivers_Pick = new Drivers_Pick();
                    drivers_Pick.Show();
                    this.Close();
                }
                else if (Team_Chosen == 2)
                {
                    GameState.InitializeTeam(2);
                    Drivers_Pick drivers_Pick = new Drivers_Pick();
                    drivers_Pick.Show();
                    this.Close();
                }
                else if (Team_Chosen == 3)
                {
                    GameState.InitializeTeam(3);
                    Drivers_Pick drivers_Pick = new Drivers_Pick();
                    drivers_Pick.Show();
                    this.Close();
                }
                else if (Team_Chosen == 4)
                {
                    GameState.InitializeTeam(4);
                    Drivers_Pick drivers_Pick = new Drivers_Pick();
                    drivers_Pick.Show();
                    this.Close();
                }
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
        }
    }
}

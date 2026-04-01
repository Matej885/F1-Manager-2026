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
        Functions functions = new Functions();
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
            Description_Text.Text = "Minardi - an Italian F1 team that competed in the F1 World Championship from 1985 until 2005 with only limited success. Founded by Giancarlo Minardi, this small team scored only 38 championship points throughout its entire history. However, this small but highly dedicated squad has nurtured future icons, launching the careers of legends such as Fernando Alonso, Giancarlo Fisichella, Mark Webber, and the formidable yet controversial Jos Verstappen. After many years, they are back and they need your help. Currently one of the weakest teams on the grid with a tiny budget and limited driver interest, they still hold onto a big dream. Will you replicate the miracle of teams like Brawn GP? Or will you make championship-winning car from scratch after a few seasons?";
            Money_Description_Label.Content = "20,000,000 $";
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
            Description_Text.Text = "Alfa Romeo - this Italian legend competed in the first-ever F1 seasons from 1950 to 1951, again from 1979 to 1985, and most recently in the modern era from 2019 to 2023. In their prime, Alfa Romeo secured two World Championships with two of, if not the greatest drivers to ever live: Juan Manuel Fangio and Nino Farina. However, they struggled to replicate that early dominance in later years. With 10 wins, 26 podiums, and 199 total points in their history, they are returning hungrier than ever. They desperately need stability, a more competitive car, and top-tier drivers, even though their budget remains tight. Can you push this legendary Italian beauty back to where it belongs — at the front of the grid?";
            Money_Description_Label.Content = "50,000,000 $";
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
            Money_Description_Label.Content = "80,000,000 $";
            Description_Text.Text = "BMW - famously known in its prime as the BMW Sauber F1 Team. Although they competed for only four seasons, they achieved more than most. With 17 podiums and a legendary victory by Robert Kubica, they introduced world-class talents such as Sebastian Vettel and Jacques Villeneuve to the grid. Now, this powerhouse manufacturer from Germany returns to reclaim its spot on the podium. They need a leader who can make every penny count and foster a winning atmosphere within the team. Do you have what it takes to lead the German giant back to glory?";
            Team_Name_Label.Content = "BMW Sauber F1 Team";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Team_Chosen = 4;
            Difficulty_Grid1.Visibility = Visibility.Visible;
            Difficulty_Grid2.Visibility = Visibility.Visible;
            Difficulty_Grid3.Visibility = Visibility.Visible;
            Difficulty_Grid4.Visibility = Visibility.Visible;
            Car_Speed_Rectangle1.Visibility = Visibility.Visible;//kk
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
            Description_Text.Text = "Siemens - if you think they focus only on digital technology, AI, and automation, you are dead wrong. This industrial titan has hand-picked its finest engineers, hired the world's best mechanics, and unleashed a beast onto the track. They need a leader who can master this machine while maintaining peace in the garage—a task just as vital as the car's aero package. Remember: at this level, excellence is the bare minimum. You must balance the fierce rivalry between your star drivers, satisfy the board of directors, and stay ahead in a ruthless development race. Here, failing to reach the podium isn't just a bad day; it’s a full-blown crisis.";
            Money_Description_Label.Content = "120,000,000 $";
            Team_Name_Label.Content = "Siemens Racing F1 Team";
        }
        //666666666666666666666666666666666666666666666666666666666
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Team_Chosen == 0)
            {
                MessageBox.Show("Pick your team first!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Database.Instance.PlayerTeamInstance.PlayerName = $"{Name_Label.Text} {Surname_Label.Text}";
                if (Team_Chosen == 1)
                {
                    PlayerTeam playerTeam = new PlayerTeam();
                    Database.Instance.InitializeTeam(1);
                    Drivers_Pick drivers_Pick = new Drivers_Pick();
                }
                else if (Team_Chosen == 2)
                {
                    Database.Instance.InitializeTeam(2);
                    Drivers_Pick drivers_Pick = new Drivers_Pick();
                }
                else if (Team_Chosen == 3)
                {
                    Database.Instance.InitializeTeam(3);
                    Drivers_Pick drivers_Pick = new Drivers_Pick();
                }
                else if (Team_Chosen == 4)
                {
                    Database.Instance.InitializeTeam(4);
                    Drivers_Pick drivers_Pick = new Drivers_Pick();
                }
                Engine_Pick engine_Pick = new Engine_Pick();
                
                engine_Pick.Show();
                this.Close();
            }
        }

        private void Main_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            functions.Button_Effect();
        }
    }
}

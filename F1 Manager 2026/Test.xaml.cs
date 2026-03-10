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

namespace F1_Manager_2026
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonValtteri_Click(object sender, RoutedEventArgs e)
        {
            {
                driverphoto_shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bottas.png", UriKind.Absolute));
            }
        }

        private void ButtonBortoleto_Click(object sender, RoutedEventArgs e)
        {
            {
                driverphoto_shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/bortoleto.png", UriKind.Absolute));
            }
        }

        private void ButtonHulk_Click(object sender, RoutedEventArgs e)
        {
            driverphoto_shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/hulkenberg.png", UriKind.Absolute));
            racesuit_shower.Source = new BitmapImage(new Uri("pack://application:,,,/Images/RB_suit.png", UriKind.Absolute));
        }
    }
}
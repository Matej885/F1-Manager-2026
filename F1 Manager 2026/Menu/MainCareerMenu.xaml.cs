using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace F1_Manager_2026.Menu
{
    /// <summary>
    /// Interaction logic for MainCareerMenu.xaml
    /// </summary>
    public partial class MainCareerMenu : Window
    {
        public MainCareerMenu()
        {
            InitializeComponent();
            var db = Database.Instance;
            Main_Car_Preview.Source = new BitmapImage(new Uri(db.PlayerTeamInstance.PathToCar, UriKind.Relative));
            Team_Name_Top.Content = db.PlayerTeamInstance.teamName;
            Car_Model_Name.Content = db.PlayerTeamInstance.teamName + " Chassis";
            Budget_Label.Content = db.PlayerTeamInstance.Budget.ToString("n0") + "$";
            Driver1_Face.Source = new BitmapImage(new Uri(db.PlayerTeamInstance.PathToDriver1, UriKind.Relative));
            Driver2_Face.Source = new BitmapImage(new Uri(db.PlayerTeamInstance.PathToDriver2, UriKind.Relative));
            NameLabel1.Content = db.PlayerTeamInstance.driver1name;
            NameLabel2.Content = db.PlayerTeamInstance.driver2name;
            RatingLabel1.Content = db.PlayerTeamInstance.driver1rating;
            RatingLabel2.Content = db.PlayerTeamInstance.driver2rating;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            options.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        

        public void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveGame.Save(Database.Instance);
            MessageBox.Show("Hra uspesne ulozena","Save Game", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_Upgrade(object sender, RoutedEventArgs e)
        {
            Upgrades upgrades = new Upgrades();
            upgrades.Show();
            this.Close();
        }
    }
}

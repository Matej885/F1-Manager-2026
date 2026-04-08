using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace F1_Manager_2026
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var a = Database.Instance.DriverList;
            Loading_Screen_Intro_Media_Element.Play();

        }
        private void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            // Keby sa niecčo pokazilo nech máme informáciu o tom čo sa stalo
            MessageBox.Show(e.ErrorException.Message);
        }
        private void MediaRepeat(object sender, RoutedEventArgs e) //aby sa video po skončení spustilo znova
        {
            Options options = new Options();
            options.Show();
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Loading_Screen_Intro_Media_Element.Stop();
            Options options = new Options();
            options.Show();
            this.Close();
        }

    }
}
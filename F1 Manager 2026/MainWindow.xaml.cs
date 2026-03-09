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
    /// <summary>
    /// Toto okno slúží iba ako úvodná obrazovka, ktorá sa zobrazí pri spustení hry. 
    /// Spustí sa F1 Intro a po jeho skončení sa automaticky načíta hlavné menu hry.
    /// Video sa dá preskočiť kliknutím na tláčítko "Skip Button", ktoré je v pravo dole
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Loading_Screen_Intro_Media_Element.Stop();
            Options options = new Options();
            options.Show();
            this.Close();
        }
    }
}
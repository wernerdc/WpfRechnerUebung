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

namespace WpfRechner {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnVerlaufLoeschen_Click(object sender, RoutedEventArgs e) {
            lBoxVerlauf.Items.Clear();
        }

        private void btnBerechene_Click(object sender, RoutedEventArgs e) {
            double zahl1 = 0;
            double zahl2 = 0;
            string rechenart = "";
            
            try {
                zahl1 = double.Parse(tbZahl1.Text);
                zahl2 = double.Parse(tbZahl2.Text);
                ComboBoxItem selectedItem = cbRechenart.SelectedItem as ComboBoxItem;
                rechenart = selectedItem.Content.ToString();
            } catch {
                MessageBox.Show("Ungültige Eingabe! \nEs sind nur Zahlen und Komma erlaubt.", "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result = 0;
            switch (rechenart) {
                case "+":
                    result = zahl1 + zahl2;
                    break;
                case "-":
                    result = zahl1 - zahl2;
                    break;
                case "*":
                    result = zahl1 * zahl2;
                    break;
                case "/":
                    result = zahl1 / zahl2;
                    break;
                case "%":
                    result = zahl1 % zahl2;
                    break;
                default:
                    break;
            }

            tbErgebnis.Text = result.ToString();

            DateTime dateTime = DateTime.Now;
            string listItemText = String.Format("[{0:dd.MM.yyyy H:mm:ss}]:  {1} {2} {3} = {4}", dateTime, zahl1, rechenart, zahl2, result);

            ListBoxItem listBoxItem = new() { Content = listItemText };
            lBoxVerlauf.Items.Add(listBoxItem);
            lBoxVerlauf.ScrollIntoView(listBoxItem);
            lBoxVerlauf.SelectedItem = listBoxItem;
        }

        private void btnBeenden_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
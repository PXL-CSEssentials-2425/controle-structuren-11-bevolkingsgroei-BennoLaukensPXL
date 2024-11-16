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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _11Bevolkingsgroei
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        StringBuilder sb = new StringBuilder();
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(populationTextBox.Text, out int currentPopulation) || !double.TryParse(growthPercentageTextBox.Text, out double growth) || growth <= 0)
            {
                MessageBox.Show($"Please enter a valid number for the population/growth percentage\r\n(Minimum is 1)", $"Invalid number");
            }
            else
            {
                double population = double.Parse(currentPopulation.ToString());
                double doublePopulation = population * 2;
                int years = 0;
                growth /= 100;
                for (; population < doublePopulation; years++)
                {
                    population += population * growth;
                }
                sb.AppendLine($"Verdubbeling bevolking {countryTextBox.Text} na {years} jaar.");
                sb.AppendLine();
                sb.AppendLine($"Nieuw bevolkingsaantal op dat moment:");
                sb.AppendLine($"{population}");
                resultTextBox.Text = sb.ToString();
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            countryTextBox.Clear();
            populationTextBox.Clear();
            growthPercentageTextBox.Clear();
            resultTextBox.Clear();
            countryTextBox.Focus();
        }

        private void closebutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

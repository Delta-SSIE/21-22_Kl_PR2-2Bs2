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

namespace wpf_02_Scitadlo
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

        private void SectiBtn_Click(object sender, RoutedEventArgs e)
        {
            double cislo1, cislo2, soucet;

            if (
                double.TryParse(Input1TB.Text, out cislo1) &&
                double.TryParse(Input2TB.Text, out cislo2)
            )
            {
                soucet = cislo1 + cislo2;
                OutputTB.Text = soucet.ToString();
            }
            else
            {
                MessageBox.Show("Jsi pako, máš tam špatný vstup");
            }
        }
    }
}

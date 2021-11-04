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

namespace WPF_04_O_Deset_vic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InputTB_TextChanged(null, null);
        }

        private void InputTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputTB == null || OutputTB == null) //když na začátku ještě nejsou
            {
                return;
            }

            // do outputu dát input zvětšený deset

            // uložím input - číslo
            if (int.TryParse(InputTB.Text, out int input)) { 

                // přičtu deset
                int output = input + 10;

                // pošlu do output
                OutputTB.Text = output.ToString();

                OutputTB.Background = Brushes.White;
                OutputTB.Foreground = Brushes.Black;
            } else
            {
                OutputTB.Text = "Chybný vstup";

                OutputTB.Background = Brushes.Red;
                OutputTB.Foreground = Brushes.White;
            }
        }
    }
}

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

namespace WPF_01_hello_world
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int pocetKliku = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (HelloLabel.Content == "Goodbye World!")
            {
                HelloLabel.Content = "Hello World!";
            }
            else
            { 
                HelloLabel.Content = "Goodbye World!";
            }

            pocetKliku++;
            PocetTextBlock.Text = pocetKliku.ToString();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            pocetKliku = 0;
            PocetTextBlock.Text = pocetKliku.ToString();
        }

    }
}

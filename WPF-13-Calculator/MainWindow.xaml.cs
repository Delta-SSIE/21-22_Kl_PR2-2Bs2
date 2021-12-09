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

namespace WPF_13_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentText;
        public MainWindow()
        {
            InitializeComponent();
            currentText = "0";
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            string currentBtn = ((Button)sender).Content.ToString();

            if (currentText == "0")
                currentText = currentBtn;
            else
                currentText += currentBtn;

            Render();
        }

        private void Render()
        {
            DisplayTB.Text = currentText;
        }
    }
}

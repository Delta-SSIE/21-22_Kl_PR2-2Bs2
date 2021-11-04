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

namespace WPF_05_Check_the_checkbox
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

        private void ZaskrtniBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckboxInput.IsChecked = true;
        }

        private void OdskrtniBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckboxInput.IsChecked = false;
        }

        private void ZmenStavBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckboxInput.IsChecked = !CheckboxInput.IsChecked;
        }

        private void CheckboxInput_Checked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Klik na mě");
            ZmenStavBtn.Content = (bool)CheckboxInput.IsChecked ? "Zruš" : "Označ";
        }
    }
}

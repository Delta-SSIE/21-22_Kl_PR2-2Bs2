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

namespace WPF_11_Kontextove_zakazane_prvky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            setDiscountState();
        }

        private void CheckBox_Toggled(object sender, RoutedEventArgs e)
        {
            setDiscountState();
        }


        private void setDiscountState()
        {
            if (DiscountCB.IsChecked == true)
            {
                DiscountsCTRL.IsEnabled = true;
            }
            else
            {
                DiscountsCTRL.IsEnabled = false;
            }
        }
    }
}

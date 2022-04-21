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
using System.Windows.Shapes;

namespace WPF_18_Nove_okno
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        public enum KdoZacne { Hrac, Pocitac, Nahoda }
        public KdoZacne Zacne { get; private set; }
        public Dialog(string otazka)
        {
            InitializeComponent();
            Otazka.Content = otazka;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //vydat odpověď
            if (sender == HracBtn)
                Zacne = KdoZacne.Hrac;
            else if (sender == PocitacBtn)
                Zacne = KdoZacne.Pocitac;
            else
                Zacne = KdoZacne.Nahoda;

            DialogResult = true; //tak poznám, že nezavřel křížkem

            //zavřít okno
            this.Close();
        }

    }
}

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
using System.Windows.Threading;

namespace WPF_17_AlarmClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime alarmTime;
        private bool alarmEnabled = false;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            Clock.Content = $"{now.Hour:00}:{now.Minute:00}:{now.Second:00}";


            if(alarmEnabled && alarmTime < now)
            {
                alarmEnabled = false;
                OnOffBtn.Content = alarmEnabled ? "On" : "Off";
                Alarm();
            }
        }

        private void TimeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HoursTB == null || MinutesTB == null)
                return;

            parseAlarmTime();
        }

        private void Alarm()
        {
            MessageBox.Show("Vstávat, lenochu!");
        }

        private void parseAlarmTime()
        {
            int minutes;
            int hours;

            if (!int.TryParse(HoursTB.Text, out hours) || hours > 23 || hours < 0)
            {
                return;
            }
            if (!int.TryParse(MinutesTB.Text, out minutes) || minutes > 59 || minutes < 0)
            {
                return;
            }

            alarmTime = DateTime.Today + TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(minutes);
            if (alarmTime < DateTime.Now)
                alarmTime += TimeSpan.FromDays(1);
        }

        private void OnOffBtn_Click(object sender, RoutedEventArgs e)
        {
            alarmEnabled = !alarmEnabled;
            OnOffBtn.Content = alarmEnabled ? "On" : "Off";
            parseAlarmTime();
        }

        private void HoursTB_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox setter = sender as TextBox;
            setter.SelectAll();
            e.Handled = true;
        }
    }
}

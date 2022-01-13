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

namespace WPF_14_Namorni_bitva
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int MapSize = 10;
        const int Boats = 12;

        private Player _player;
        private Player _computer;


        public MainWindow()
        {
            InitializeComponent();

            //vytvořit oba hráče
            _player = new Player(MapSize, Boats);
            _player.PlaceBoats();

            _computer = new Player(MapSize, Boats);
            _computer.PlaceBoats();

            //zobrazit jejich stav
            InitializeDisplay(PlayerDisplay, _player.PrivateMap);
            InitializeDisplay(ComputerDisplay, _computer.PublicMap);

        }

        private void InitializeDisplay(Grid display, TileState[,] map)
        {
            for (int i = 0; i < MapSize; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                display.RowDefinitions.Add(rowDefinition);
            }

            for (int i = 0; i < MapSize; i++)
            {
                ColumnDefinition colDefinition = new ColumnDefinition();
                display.ColumnDefinitions.Add(colDefinition);
            }


            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    Rectangle tile = new Rectangle();
                    tile.Style = FindResource("SeaTile") as Style;

                    display.Children.Add(tile);
                    Grid.SetColumn(tile, x);
                    Grid.SetRow(tile, y);
                }
            }
        }

        // když střílí Hráč
        
        // když střílí PC
    }
}

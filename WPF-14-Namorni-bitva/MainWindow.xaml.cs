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

namespace WPF_14_Namorni_bitva
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int MapSize = 3;
        const int Boats = 5;

        private Player _player;
        private Player _computer;

        private Rectangle[,] _playerTiles;


        public MainWindow()
        {
            InitializeComponent();

            //vytvořit oba hráče
            _player = new Player(MapSize, Boats);
            _player.PlaceBoats();

            _computer = new Player(MapSize, Boats);
            _computer.PlaceBoats();

            //zobrazit jejich stav
            _playerTiles = InitializeDisplay(PlayerDisplay, _player.PrivateMap);
            InitializeDisplay(ComputerDisplay, _computer.PublicMap, true);

            RenderScore();

        }

        private Rectangle[,] InitializeDisplay(Grid display, TileState[,] map, bool RegisterClick = false)
        {
            Rectangle[,] tiles = new Rectangle[MapSize, MapSize];

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
                    tile.Style = FindStyle(map[x, y]);
                    tiles[x, y] = tile;

                    if (RegisterClick)
                        tile.MouseDown += Tile_MouseDown;

                    display.Children.Add(tile);
                    Grid.SetColumn(tile, x);
                    Grid.SetRow(tile, y);
                }
            }

            return tiles;
        }

        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //zjistit souřadnice
            Rectangle clickedTile = (Rectangle)sender;
            int row = Grid.GetRow(clickedTile);
            int column = Grid.GetColumn(clickedTile);
            Coordinates target = new Coordinates() { X = column, Y = row };

            //vyhodnotit zásah
            _computer.HandleShot(target);

            //vykreslit
            clickedTile.Style = FindStyle(_computer.PublicMap[column, row]);
            RenderScore();

            if (!_computer.IsAlive)
            {
                MessageBox.Show("Victory", "You win!");
                Close();
                return;
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            ComputerMove();
        }

        private void ComputerMove()
        {
            //střílí PC

            //vymyslí si cíl
            Coordinates target = _computer.RandomTarget(_player.PublicMap);

            //vyhodnotit zásah
            _player.HandleShot(target);

            //vykreslit
            Rectangle hitTile = _playerTiles[target.X, target.Y];
            hitTile.Style = FindStyle(_player.PrivateMap[target.X, target.Y]);
            RenderScore();

            if (!_player.IsAlive)
            {
                MessageBox.Show("Defeat", "You lost!");
                Close();
                return;
            }
        }


        private void RenderScore()
        {
            PlayerScoreLbl.Content = $"{_player.Wrecks} / {Boats}";
            ComputerScoreLbl.Content = $"{_computer.Wrecks} / {Boats}";
        }

        private Style FindStyle(TileState state)
        {
            switch (state)
            {
                case TileState.Water:
                    return FindResource("SeaTile") as Style;
                case TileState.Shot:
                    return FindResource("ShotTile") as Style;
                case TileState.Boat:
                    return FindResource("BoatTile") as Style;
                case TileState.Wreck:
                    return FindResource("WreckTile") as Style;
                default:
                    return null; //musí být, aby kompilátor měl zajištěnu návratovou hodnotu
            }
        }
    }
}

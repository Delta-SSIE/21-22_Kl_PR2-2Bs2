using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_14_Namorni_bitva
{
    class Player
    {
        private int _mapSize;
        private int _boatCount;
        private TileState[,] _map;

        public Player(int mapSize, int boatCount)
        {
            if (mapSize < 1 || boatCount < 1)
                throw new ArgumentOutOfRangeException();

            _mapSize = mapSize;
            _boatCount = boatCount;
        }

        public bool IsFinished
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // vygenerovat mapu
        public void CreateMap()
        {
            _map = new TileState[_mapSize, _mapSize];

            for (int x = 0; x < _mapSize; x++)
            {
                for (int y = 0; y < _mapSize; y++)
                {
                    _map[x, y] = TileState.Water;
                }
            }
        }

        // umístit lodičky
        public void PlaceBoats()
        {
            // 1. umístit do mapy daný počet lodí
            int placed = 0;

            for (int x = 0; x < _mapSize; x++)
            {
                for (int y = 0; y < _mapSize; y++)
                {
                    _map[x, y] = TileState.Boat;
                    placed++;

                    if (placed >= _boatCount)
                        break;
                }
                if (placed >= _boatCount)
                    break;
            }

            // 2. vymyslet, kolikrát chci míchat
            // všechny

            Random rnd = RndHelper.GetInstance();

            // 3. zamíchat
            for (int x = 0; x < _mapSize; x++)
            {
                for (int y = 0; y < _mapSize; y++)
                {
                    int newX = rnd.Next(_mapSize);
                    int newY = rnd.Next(_mapSize);

                    TileState tmp = _map[x, y];
                    _map[x, y] = _map[newX, newY];
                    _map[newX, newY] = tmp;
                }
            }
        }

        // zpracovat výstřel
        // pro počítač - vymyslet, kam střílet

        // poskytnout mapu pro zobrazení
            // pro mne
            // pro protivníka
    }
}

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

        public int Wrecks { get; private set; } = 0;

        public Player(int mapSize, int boatCount)
        {
            if (mapSize < 1 || boatCount < 1)
                throw new ArgumentOutOfRangeException();

            _mapSize = mapSize;
            _boatCount = boatCount;

            CreateMap();
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


        /// <summary>
        /// Modifies map - marks shot at coordinates
        /// </summary>
        /// <param name="target"></param>
        /// <returns>True on hit, false otherwise</returns>
        public bool HandleShot (Coordinates target)
        {
            TileState state = _map[target.X, target.Y]; //co tam je?

            switch(state)
            {
                case TileState.Boat:
                    _map[target.X, target.Y] = TileState.Wreck;
                    Wrecks++;
                    return true;

                case TileState.Water:
                    _map[target.X, target.Y] = TileState.Shot;
                    break;
            }

            return false;

        }

        // pro počítač - vymyslet, kam střílet
        public Coordinates RandomTarget(TileState[,] opponentMap)
        {
            Random rnd = RndHelper.GetInstance();

            Coordinates target = new Coordinates();

            do
            {
                target.X = rnd.Next(_mapSize);
                target.Y = rnd.Next(_mapSize);
            } 
            while (opponentMap[target.X, target.Y] != TileState.Water);

            return target;
        }


        // poskytnout mapu pro zobrazení
            // pro mne
            // pro protivníka
        public TileState[,] PublicMap
        {
            get
            {
                //alokuju novou stejně velkou mapu
                TileState[,] publicMap = new TileState[_mapSize, _mapSize];
                
                for (int x = 0; x < _mapSize; x++)
                {
                    for (int y = 0; y < _mapSize; y++)
                    {
                        //projdu vše, ale místo neodkrytých lodí zapíšu prázdno
                        TileState state = _map[x, y];
                        if (state == TileState.Boat)
                            state = TileState.Water;

                        publicMap[x, y] = state;
                    }
                }

                //vrátím se zamaskovanými loďmi
                return publicMap;
            }
        }

        public TileState[,] PrivateMap
        {
            get
            {
                return (TileState[,])_map.Clone();
            }
        }

        public bool IsAlive
        {
            get
            {
                return Wrecks < _boatCount;
            }
        }
    }
}

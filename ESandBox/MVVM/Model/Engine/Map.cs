using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESandBox.MVVM.Model.Engine
{
    class Map
    {
        private Tile[,] _tiles;

        public Map(Size size)
        {
            _tiles = new Tile[size.Width, size.Height];
            InitializeMap();
        }

        public Tile[,] Tiles { get { return _tiles; } }

        public int Rows { get { return _tiles.GetLength(0);} }

        public int Cols { get { return _tiles.GetLength(1);} }

        public void Update()
        {
            ReverseMap();
        }

        private void InitializeMap()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    _tiles[r, c] = 
                        new Tile(new Point(r, c)) { Black = r % 2 == 0 ^ c % 2 != 0 };
        }

        public void ReverseMap()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    _tiles[r, c].Black = !_tiles[r, c].Black;
        }
    }
}

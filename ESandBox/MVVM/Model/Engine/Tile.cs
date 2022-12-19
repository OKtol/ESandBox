using System.Drawing;

namespace ESandBox.MVVM.Model.Engine
{
    class Tile
    {
        private Point _location;
        private bool _black;

        public Tile(Point location)
        {
            _location = location;
        }

        public Point Location { get { return _location; } }

        public bool Black { get { return _black;} set { _black = value; } }
    }
}

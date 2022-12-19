using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ESandBox.MVVM.Model.Engine
{
    class Rendering
    {
        private Canvas _screen;
        private Image[,] _imageControls;
        private Map _map;
        private ReadOnlyDictionary<string, BitmapImage> _sprites;

        public Rendering(Canvas screen, Map map, ReadOnlyDictionary<string, BitmapImage> sprites) 
        {
            _screen = screen;
            _map = map;
            _sprites = sprites;
            _imageControls = new Image[_map.Rows, _map.Cols];
            SetupCanvas(48);
        }

        private void SetupCanvas(int cellSideLen)
        {
            for (int r = 0; r < _map.Rows; r++)
                for (int c = 0; c < _map.Cols; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSideLen,
                        Height = cellSideLen
                    };

                    Canvas.SetTop(imageControl, r* cellSideLen);
                    Canvas.SetLeft(imageControl, c * cellSideLen);
                    _screen.Children.Add(imageControl);
                    _imageControls[r, c] = imageControl;
                }
        }

        public void Render()
        {
            RenderMap();
        }

        public void RenderMap() 
        {
            for (int r = 0; r < _map.Rows; r++)
                for (int c = 0; c < _map.Cols; c++)
                    _imageControls[r, c].Source =
                        _sprites.ContainsKey("DarkGrayTile.bmp") && _sprites.ContainsKey("LigthGrayTile.bmp") ?
                        (_map.Tiles[r, c].Black ? _sprites["DarkGrayTile.bmp"] : _sprites["LigthGrayTile.bmp"]) :
                        throw new Exception("DarkGrayTile.bpm or LigthGrayTile.bmp not loaded!");
        }
    }
}

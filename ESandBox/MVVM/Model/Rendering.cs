using ESandBox.MVVM.ViewModel;
using System.Windows;
using System.Windows.Media;

namespace ESandBox.MVVM.Model
{
    static class Rendering
    {
        public static DrawingImage frame;

        internal static void Render()
        {
            var dg = new DrawingGroup();
            var dc = dg.Open();
            var sideLen = 25;
            var cellSide = 40;
            var cellSize = new Size(cellSide, cellSide);
            for (int y = 0; y < sideLen; y++)
                for (int x = 0; x < sideLen; x++)
                {
                    var logicalLocation = new Point(x, y);
                    var cellCoords = logicalLocation.MultiplyTransform(cellSide);
                    var rect = new Rect(cellCoords, cellSize);
                    dc.DrawRectangle(y + x % 2 == 0 ? Brushes.White : Brushes.Black, (Pen)null, rect);
                }
            dc.Close();
            frame = new DrawingImage(dg);
        }
    }
}

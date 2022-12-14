using System.Windows;

namespace ESandBox.MVVM.Model
{
    static class Geometry
    {
        public static Point GetCenter(this Rect rect)
            {
                var x = rect.Left + rect.Width / 2;
                var y = rect.Top + rect.Height / 2;
                return new Point(x, y);
            }

        public static Point MultiplyTransform(this Point p, int factor)
        {
            return new Point(p.X * factor, p.Y * factor);
        }
    }
}

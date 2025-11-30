using System.Drawing.Drawing2D;

namespace ProjectR.Classes
{
    internal class Utils
    {
        public static string TrimString(string input, int maxLength)
        {
            return input.Length <= maxLength ? input : $"{input[..maxLength]}...";
        }

        /// <summary>
        /// Returns a GraphicsPath with rounded corners for the given control and radius to enable redrawing the control region.
        /// 
        /// Based on: https://stackoverflow.com/a/58906678
        /// </summary>
        public static GraphicsPath PaintRoundedCorners(Control control, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new();

            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, diameter, diameter), 180, 90);
            path.AddArc(new Rectangle(control.Width - diameter, 0, diameter, diameter), 270, 90);
            path.AddArc(new Rectangle(control.Width - diameter, control.Height - diameter, diameter, diameter), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - diameter, diameter, diameter), 90, 90);
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// Returns a GraphicsPath with rounded corners with border for the given control and radius to enable redrawing the control region.
        /// 
        /// Based on: https://stackoverflow.com/a/58906678
        /// </summary>
        public static GraphicsPath PaintRoundedCorners(PaintEventArgs e, Control control, int radius, float borderWidth, Color borderColor)
        {
            int diameter = radius * 2;
            GraphicsPath path = new();

            path.StartFigure();
            path.AddArc(new RectangleF(0.5f, 0.5f, diameter, diameter), 180, 90);
            path.AddArc(new RectangleF(control.Width - diameter, 0.5f, diameter, diameter), 270, 90);
            path.AddArc(new RectangleF(control.Width - diameter, control.Height - diameter, diameter, diameter), 0, 90);
            path.AddArc(new RectangleF(0.5f, control.Height - diameter, diameter, diameter), 90, 90);
            path.CloseFigure();

            Graphics graphics = e.Graphics;

            using Pen pen = new(borderColor, 2);

            graphics.DrawPath(pen, path);

            return path;
        }
    }
}

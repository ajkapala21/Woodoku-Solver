using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woodoku_App
{
    class PieceButton : Button
    {
        private int x;
        private int y;
        private int size;
        private Shape shape;
        public PieceButton(int xValue, int yValue, int s, Shape sh)
        {
            x = xValue;
            y = yValue;
            size = s;
            shape = sh;
            Location = new System.Drawing.Point(xValue, yValue);
            Size = new System.Drawing.Size(size, size);
            Enabled = true;
            BackgroundImage = shape.getBitmap();
            BackgroundImageLayout = ImageLayout.Stretch;
            Click += new EventHandler(setGlobalShape);
        }
        private void setGlobalShape(object sender, EventArgs e)
        {
            Global.selectedAIShape = shape;
        }
    }
}

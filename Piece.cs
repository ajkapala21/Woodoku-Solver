using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woodoku_App
{
    /// <summary>
    /// The piece class is an object used for the grid that makes up the main game. Each piece inherits from
    /// the Label class so each piece is really just a label. This allows us to easily edit the form through
    /// the creation of many labels that will make up are grid of squares that displays the game.
    /// </summary>
    public class Piece : Label
    {
        private int x;
        private int y;
        private int size = 40;

        public Piece(int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
            Location = new System.Drawing.Point(xValue, yValue);
            Size = new System.Drawing.Size(size, size);
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Enabled = true;
        }

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
    }
}

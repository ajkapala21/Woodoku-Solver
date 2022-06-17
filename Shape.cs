using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodoku_App
{
    /// <summary>
    /// each Shape must have a name, the actually shape saved in a 5v5 grid of bolleans, a image from
    /// Shape_images.resx, and values for the earliest and latest round that it can randomly appear.
    /// This class is used in the Shapes class to initialize a list of all the shapes we need for the game
    /// </summary>
    public class Shape
    {
        string name;
        bool[,] shape = new bool[5, 5];
        Bitmap image;
        int earliestRound;
        int latestRound;
        public Shape(string n, bool[,] array, Bitmap i, int e, int l)
        {
            name = n;
            shape = array;
            image = i;
            earliestRound = e;
            latestRound = l;
        }
        public Shape()
        {
            name = "";
            shape = new bool[0, 0];
            image = new Bitmap(1, 1);
            earliestRound = 0;
            latestRound = 1000;
        }
        public bool[,] getShape()
        {
            return shape;
        }
        public Bitmap getBitmap()
        {
            return image;
        }
        public string getName()
        {
            return name;
        }
        public int getEarliestRound()
        {
            return earliestRound;
        }
        public int getLatestRound()
        {
            return latestRound;
        }
    }
}

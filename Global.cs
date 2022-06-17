using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woodoku_App
{
    static public class Global
    {
        public struct Location
        {
            public Location(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X { get; set; }
            public int Y { get; set; }
        }
        public struct Move
        {
            public Move(Location l, int choice)
            {
                location = l;
                shape = choice;
            }
            public Location location { get; set; }
            public int shape { get; set; }
        }
        public static Shapes shapes { get; set; }
        public static int gameSize = 40;
        public static int windowWidth = 500;
        public static int windowHeight = 600;
        public static List<Button> AIButtons { get; set; }
        public static Button ClearAIButtons { get; set; }
        public static List<Control> startScreen { get; set; }
        public static List<Control> gameScreen { get; set; }
        public static List<Control> smartScreen { get; set; }
        public static List<Control> descriptionScreen { get; set; }
        public static Shape emptyShape { get; set; }
        public static Form1 mainForm { get; set; }
        public static Button Button1 { get; set; }
        public static Button Button2 { get; set; }
        public static Button Button3 { get; set; }
        public static Button botGameButton { get; set; }
        public static Button bestMoveButton { get; set; }
        public static RichTextBox  BestMoveText { get; set; }
        public static Label roundLabel { get; set; }
        public static Label spaceScoreLabel { get; set; }
        public static Label ScoreLabel { get; set; }
        public static Label[,] display { get; set; }
        public static Label botScore { get; set; }
        public static Shape selectedAIShape { get; set; }
        public static Button OkButton { get; set; }
        public static Button homeButton { get; set; }
        
        public static bool canPlaceAtLocation(Shape s, int x, int y, ref GameState game)
        {
            for (int i = 0; i < s.getShape().GetLength(0); i++)
            {
                for (int j = 0; j < s.getShape().GetLength(1); j++)
                {
                    if (s.getShape()[j, i] == true)
                    {
                        if (x + i - 2 < 0 || x + i - 2 >= game.board.GetLength(0) || y + j - 2 < 0 || y + j - 2 >= game.board.GetLength(1))
                        {
                            return false;
                        }
                        else if (game.board[x + i - 2, y + j - 2] == true)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public static Location getLocation(Piece p)
        {
            int x = (p.getX() - windowWidth / 2 + Global.display.GetLength(0) * gameSize / 2) / gameSize;
            int y = (p.getY() - windowHeight / 2 + Global.display.GetLength(1) * gameSize / 2 + 60) / gameSize;
            Location loc = new Location(x, y);
            return loc;
        }
        public static void DeleteAIButtons()
        {
            foreach (Button b in AIButtons)
            {
                mainForm.Controls.Remove(b);
            }
        }
        public static void DeleteDisplay()
        {
            foreach (Label l in display)
            {
                mainForm.Controls.Remove(l);
            }
        }
        
        //checks if a shape can be placed anywhere
        public static bool canPlaceAnywhere(Shape s, ref GameState g)
        {
            for (int i = 0; i < g.board.GetLength(0); i++)
            {
                for (int j = 0; j < g.board.GetLength(1); j++)
                {
                    if (canPlaceAtLocation(s, i, j, ref g))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static string printMoveSetUp(Move move, GameState game)
        {
            string s = "";
            s += "Shape: " + game.Shapes[move.shape].getName();
            s += " Location: (" + move.location.X + ", " + move.location.Y + ")";
            return s;
        }
        public static void changeScreen(string s)
        {
            hideOtherScreens(s);
            activateScreen(s);
        }
        private static void hideOtherScreens(string s)
        {
            if (s != "game")
            {
                foreach (Control c in gameScreen)
                {
                    c.Enabled = false;
                    c.Visible = false;
                }
            }
            if (s != "description")
            {
                foreach (Control c in descriptionScreen)
                {
                    c.Enabled = false;
                    c.Visible = false;
                }
            }
            if (s != "smart")
            {
                foreach (Control c in smartScreen)
                {
                    c.Enabled = false;
                    c.Visible = false;
                }
            }
            if (s != "start")
            {
                foreach (Control c in startScreen)
                {
                    c.Enabled = false;
                    c.Visible = false;
                }
            }
        }
        private static void activateScreen(string s)
        {
            if (s == "game")
            {
                foreach (Control c in gameScreen)
                {
                    c.Enabled = true;
                    c.Visible = true;
                }
                mainForm.Width = 574;
            }
            if(s == "description")
            {
                foreach (Control c in descriptionScreen)
                {
                    c.Enabled = true;
                    c.Visible = true;
                }
                addLabelToScreen(new System.Drawing.Point(330, 20), new System.Drawing.Size(340, 100), "How To Use", 40, descriptionScreen);
                string text = "To use the solver you must input the pieces that appear " +
                    "on your game into the solver." +
                    "\n\nThen you must select the show moves button." +
                    "\n\nAfter pressing the button wait for the best moves to appear on the board (This may take a while)." +
                    "\n\nPlace the moves on your game in the order from lightest to darkest color." +
                    "\n\nThen hit place moves for the solver to keep the same board as you.";
                addLabelToScreen(new System.Drawing.Point(100, 120), new System.Drawing.Size(800, 400), text, 18, descriptionScreen);
                mainForm.Width = 1000;
            }
            if (s == "smart")
            {
                foreach (Control c in smartScreen)
                {
                    c.Enabled = true;
                    c.Visible = true;
                }

                mainForm.Width = 1000;
            }
            if (s == "start")
            {
                foreach (Control c in startScreen)
                {
                    c.Enabled = true;
                    c.Visible = true;
                }

                addLabelToScreen(new System.Drawing.Point(107, 50), new System.Drawing.Size(360, 100), "Woodoku Solver", 30, startScreen);

                mainForm.Width = 574;
            }
        }
        private static void addLabelToScreen(System.Drawing.Point location, System.Drawing.Size size, String text, int fontSize, List<Control> screen)
        {
            Label txt = new Label();
            txt.Location = location;
            txt.Size = size;
            txt.Text = text;
            txt.Font = new Font(txt.Font.FontFamily, fontSize);

            mainForm.Controls.Add(txt);
            screen.Add(txt);
        }
    }
    
}

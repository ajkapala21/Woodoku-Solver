using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woodoku_App
{
    public class DisplayBoard
    {
        Label[,] boardDisplay = new Label[9, 9];
        GameState game;
        List<Button> buttons = new List<Button> { Global.Button1, Global.Button2, Global.Button3 };
        Color[,] boardColors = new Color[9, 9];
        public DisplayBoard(GameState g)
        {
            game = g;
            initLabels();
            initButtons();
            updateBoardDisplay();
        }
        //Initializes all the Labels that make up the gameboard
        public void initLabels()
        {
            for (int i = 0; i < boardDisplay.GetLength(0); i++)
            {
                for (int j = 0; j < boardDisplay.GetLength(1); j++)
                {
                    Piece p = new Piece(i * Global.gameSize + Global.windowWidth / 2 - boardDisplay.GetLength(0) * Global.gameSize / 2, j * Global.gameSize + Global.windowHeight / 2 - boardDisplay.GetLength(1) * Global.gameSize / 2 - 60);
                    boardDisplay[i, j] = p;
                    boardDisplay[i, j].MouseMove += new MouseEventHandler(createView_WhenMouseOver);
                    boardDisplay[i, j].MouseEnter += new EventHandler(clearView_WhenMouseLeave);
                    Global.mainForm.Controls.Add(boardDisplay[i, j]);
                }
            }
            colorBoard();
            Global.display = boardDisplay;
        }
        //clears placement display upon moving across labels
        public void displayButtons()
        {
            for (int i = 0; i < game.activeButtons.Count; i++)
            {
                buttons[game.activeButtons[i]].Enabled = true;
                buttons[game.activeButtons[i]].BackgroundImage 
                    = game.Shapes[game.activeButtons[i]].getBitmap();
                buttons[game.activeButtons[i]].BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        private void clearView_WhenMouseLeave(object sender, EventArgs e)
        {
            clearView();
        }
        //Creates a "greyed" view of where your block would be placed
        private void createView_WhenMouseOver(object sender, EventArgs e)
        {
            Piece p = sender as Piece;
            Global.Location location = Global.getLocation(p);
            placementDisplay(game.selectedShape, location.X, location.Y);
        }
        public void initButtons()
        {
            Global.Button1.Click += new EventHandler(setSelectedPiece_OnPress);
            Global.Button2.Click += new EventHandler(setSelectedPiece_OnPress);
            Global.Button3.Click += new EventHandler(setSelectedPiece_OnPress);
        }
        //Set selected piece when clicking a button
        private void setSelectedPiece_OnPress(object sender, EventArgs e)
        {
            Button b = sender as Button;
            String bname = b.Name;
            if (game.Shapes.Count > 0)
            {
                if (bname == "button1")
                {
                    game.selectedShape = game.Shapes[0];
                    game.selectedShapeNum = 0;

                }
                else if (bname == "button2")
                {
                    game.selectedShape = game.Shapes[1];
                    game.selectedShapeNum = 1;
                }
                else
                {
                    game.selectedShape = game.Shapes[2];
                    game.selectedShapeNum = 2;
                }
            }
        }
        public void updateDisplay()
        {
            updateBoardDisplay();
            updateButtonDisplay();
            updateLabels();
        }
        public void updateBoardDisplay()
        {
            for (int i = 0; i < game.board.GetLength(0); i++)
            {
                for (int j = 0; j < game.board.GetLength(1); j++)
                {
                    if (game.board[i, j] == true)
                    {
                        boardDisplay[i, j].BackColor = Color.SaddleBrown;
                    }
                    if (game.board[i, j] == false)
                    {
                        boardDisplay[i, j].BackColor = boardColors[i, j];
                    }
                }
            }
        }
        public void updateButtonDisplay()
        {
            foreach (Button b in buttons)
            {
                Shape s = new Shape();
                b.Enabled = false;
                b.BackgroundImage = s.getBitmap();
                b.BackgroundImageLayout = ImageLayout.Stretch;
            }
            displayButtons();
        }
        //Just controls the light brown draw and drop feature
        private void placementDisplay(Shape s, int x, int y)
        {
            if (Global.canPlaceAtLocation(s, x, y, ref game) == false)
            {
                clearView();
                return;
            }
            else
            {
                for (int i = 0; i < s.getShape().GetLength(0); i++)
                {
                    for (int j = 0; j < s.getShape().GetLength(1); j++)
                    {
                        if (s.getShape()[j, i] == true)
                        {
                            boardDisplay[x + i - 2, y + j - 2].BackColor = Color.SandyBrown;
                        }
                    }
                }
            }
        }
        //Clears the past views whenever the mouse moves over a new label
        private void clearView()
        {
            for (int i = 0; i < boardDisplay.GetLength(0); i++)
            {
                for (int j = 0; j < boardDisplay.GetLength(1); j++)
                {
                    if (boardDisplay[i, j].BackColor == Color.SandyBrown)
                    {
                        boardDisplay[i, j].BackColor = boardColors[i, j];
                    }
                }
            }
        }
        public void updateLabels()
        {
            Global.roundLabel.Text = "Round: " + game.round;
            Global.ScoreLabel.Text = "Score: " + game.Score;
            Global.spaceScoreLabel.Text = "SpaceScore: " + game.SpaceScore;
        }
        public void colorSquareOfLabels(int num)
        {
            int x = num % 3;
            int y = num / 3;

            for (int i = x * 3; i < (x + 1) * 3; i++)
            {
                for (int j = y * 3; j < (y + 1) * 3; j++)
                {
                    if((x+y) % 2 == 1)
                    {
                        boardColors[i, j] = Color.DarkGray;
                    }
                    else
                    {
                        boardColors[i, j] = Color.LightGray;
                    }
                }
            }
        }
        public void colorBoard()
        {
            for(int i = 0; i < boardColors.GetLength(0); i++)
            {
                colorSquareOfLabels(i);
            }
        }
        public void displayMoves(List<Global.Move> moves)
        {
            int index = 0;
            List<Color> colors = new List<Color> { Color.LightBlue, Color.CadetBlue, Color.DarkBlue };
            foreach(Global.Move move in moves)
            {
                for (int i = 0; i < game.Shapes[move.shape].getShape().GetLength(0); i++)
                {
                    for (int j = 0; j < game.Shapes[move.shape].getShape().GetLength(1); j++)
                    {
                        if (game.Shapes[move.shape].getShape()[j, i] == true)
                        {
                            boardDisplay[move.location.X + i - 2, move.location.Y + j - 2].BackColor = colors[index];
                        }
                    }
                }
                index++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woodoku_App
{

    public class GameController
    {
        GameState game;
        public GameController(ref GameState g)
        {
            game = g;
        }
        //Creates the choices for pieces !!!!Need to add in ablitity to always garuntee you can place something!!!
        public void create_choices()
        {
            game.movesLastRound.Clear();
            game.round++;
            game.activeButtons = new List<int> { 0, 1, 2 };
            Random rand = new Random();
            List<Shape> shapesIWant = Global.shapes.ShapesIWant(game.round);
            List<Shape> choices = new List<Shape>();
            for (int i = 0; i < 3; i++)
            {
                int num = rand.Next(shapesIWant.Count);
                choices.Add(shapesIWant[num]);
            }
            game.Shapes = choices;
        }
        public void setSelectedLocation_OnClick(object sender, EventArgs e)
        {
            Piece p = sender as Piece;
            Global.Location location = Global.getLocation(p);
            makeMove(location);
        }
        public void makeMove(Global.Location location)
        {
            placeShape(location.X, location.Y);
            //saves moves made in a round - useful for bots
            game.movesLastRound.Add(new Global.Move(location, game.selectedShapeNum));
            clearIfNeeded();
            updateActiveButtons();
            checkForMoves();
            game.Score = game.Score + scoreValue(game.selectedShape);
            game.SpaceScore = calculateSpaceScore();
            game.selectedShape = Global.emptyShape;
            isGameOver();
        }
        public void makeMoveBot(Global.Location location)
        {
            placeShape(location.X, location.Y);
            //saves moves made in a round - useful for bots
            game.movesLastRound.Add(new Global.Move(location, game.selectedShapeNum));
            clearIfNeeded();
            updateActiveButtons();
            //identifcal except for no checkForMoves because that would reset the moveslastround
            game.Score = game.Score + scoreValue(game.selectedShape);
            game.SpaceScore = calculateSpaceScore();
            game.selectedShape = Global.emptyShape;
            isGameOver();
        }
        public void placeShape(int x, int y)
        {
            if (Global.canPlaceAtLocation(game.selectedShape, x, y, ref game) == false || game.selectedShape.getName() == "")
            {
                return;
            }
            for (int i = 0; i < game.selectedShape.getShape().GetLength(0); i++)
            {
                for (int j = 0; j < game.selectedShape.getShape().GetLength(1); j++)
                {
                    if (game.selectedShape.getShape()[j, i] == true)
                    {
                        game.board[x + i - 2, y + j - 2] = true;
                    }
                }
            }
        }
        public void updateActiveButtons()
        {
            game.activeButtons.Remove(game.selectedShapeNum);
        }
        //clears the board when necessary
        private void clearIfNeeded()
        {
            int numCleared = 0;
            List<int> rows = checkRows();
            List<int> column = checkColumns();
            List<int> squares = checkSquares();
            numCleared += clearRow(rows);
            numCleared += clearColumn(column);
            numCleared += clearSquare(squares);
            game.Score = game.Score + numCleared * 18;
            if (numCleared >= 1)
            {
                game.streak++;
                if (game.streak > 1)
                {
                    game.Score = game.Score + (game.streak - 1) * 10;
                }
            }
            else
            {
                game.streak = 0;
            }
            if (numCleared > 1)
            {
                game.Score = game.Score + (numCleared - 1) * 10;
            }
        }
        //actually checks columns since the set selected location gives [col, row] values :/
        private List<int> checkRows()
        {
            List<int> rows = new List<int>();
            for (int i = 0; i < game.board.GetLength(0); i++)
            {
                bool[] array = new bool[game.board.GetLength(1)];
                for (int j = 0; j < game.board.GetLength(1); j++)
                {
                    array[j] = game.board[i, j];
                }
                if (allEqualTrue(array))
                {
                    rows.Add(i);
                }
            }
            return rows;
        }
        //actually checks rows
        private List<int> checkColumns()
        {
            List<int> rows = new List<int>();
            for (int i = 0; i < game.board.GetLength(0); i++)
            {
                bool[] array = new bool[game.board.GetLength(1)];
                for (int j = 0; j < game.board.GetLength(1); j++)
                {
                    array[j] = game.board[j, i];
                }
                if (allEqualTrue(array))
                {
                    rows.Add(i);
                }
            }
            return rows;
        }
        //clears a row of the board and updates Display
        private int clearRow(List<int> num)
        {
            for (int n = 0; n < num.Count; n++)
            {
                for (int i = 0; i < game.board.GetLength(0); i++)
                {
                    game.board[num[n], i] = false;
                }
            }
            return num.Count;
        }
        //clears a column of the board and updates the Display
        private int clearColumn(List<int> num)
        {
            for (int n = 0; n < num.Count; n++)
            {
                for (int i = 0; i < game.board.GetLength(1); i++)
                {
                    game.board[i, num[n]] = false;
                }
            }
            return num.Count;
        }
        //clears a sqaure of the board and updates the Display
        private int clearSquare(List<int> num)
        {
            foreach (int value in num)
            {
                int x = value % 3;
                int y = value / 3;
                int n = 0;
                for (int i = x * 3; i < (x + 1) * 3; i++)
                {
                    for (int j = y * 3; j < (y + 1) * 3; j++)
                    {
                        game.board[i, j] = false;
                        n++;
                    }
                }
            }
            return num.Count;
        }
        //just loops through and checks all sqaures
        private List<int> checkSquares()
        {
            List<int> list = new List<int>();
            for (int n = 0; n < game.board.GetLength(0); n++)
            {
                if (checkSquare(n) == true)
                {
                    list.Add(n);
                }
            }
            return list;
        }
        //checks if one sqaure has all true values
        private bool checkSquare(int num)
        {
            int x = num % 3;
            int y = num / 3;
            bool[] array = new bool[game.board.GetLength(0)];
            int n = 0;
            for (int i = x * 3; i < (x + 1) * 3; i++)
            {
                for (int j = y * 3; j < (y + 1) * 3; j++)
                {
                    array[n] = game.board[i, j];
                    n++;
                }
            }
            if (allEqualTrue(array))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //sees if an array of bools all equal true.
        private bool allEqualTrue(bool[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == false)
                {
                    return false;
                }
            }
            return true;
        }

        //return the score value of placing a shape
        private int scoreValue(Shape s)
        {
            int value = 0;
            for (int i = 0; i < s.getShape().GetLength(0); i++)
            {
                for (int j = 0; j < s.getShape().GetLength(1); j++)
                {
                    if (s.getShape()[i, j] == true)
                    {
                        value++;
                    }
                }
            }
            return value;
        }
        //calculates spacescore of the board
        private int calculateSpaceScore()
        {
            int s = 0;
            for (int i = 0; i < game.board.GetLength(0); i++)
            {
                for (int j = 0; j < game.board.GetLength(1); j++)
                {
                    int temp = getSpaceScoreForLocation(i, j);
                    s += temp;
                }
            }
            return s;
        }
        //gives spacescore for one location
        private int getSpaceScoreForLocation(int x, int y)
        {
            int temp = 0;
            if (game.board[x, y])
            {
                return 0;
            }
            else
            {
                temp = isSpaceAroundV2(x, y);
            }
            return temp;
        }
        //Checks if there is space around a spot for space score calculations
        private int isSpaceAround(int x, int y)
        {
            int clearRings = 0;
            for (int rings = 1; rings <= 5; rings++)
            {
                if (!(x - rings < 0 || y - rings < 0 || x + rings >= game.board.GetLength(0) || y + rings >= game.board.GetLength(1)))
                {
                    for (int i = x - rings; i <= x + rings; i++)
                    {
                        for (int j = y - rings; j <= y + rings; j++)
                        {
                            if (game.board[i, j])
                            {
                                return clearRings + 1;
                            }
                        }
                    }
                    clearRings++;
                }
                else
                {
                    return clearRings + 1;
                }
            }
            return clearRings + 1;
        }
        private int isSpaceAroundV2(int x, int y)
        {
            //V2 4767 average from 25 SS
            int favorCenter = 0;
            int clearSpots = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (!(i < 0 || j < 0 || i >= game.board.GetLength(0) || j >= game.board.GetLength(1)))
                    {
                        if (game.board[i, j] == false)
                        {
                            clearSpots++;
                        }
                    }
                }
            }
            return clearSpots + favorCenter - 1;
        } 
        public void checkForMoves()
        {
            if (game.activeButtons.Count == 0)
            {
                create_choices();
            }
        }
        //
        public void isGameOver()
        {
            game.GameOver = true;
            List<Shape> c = new List<Shape>();
            foreach (int i in game.activeButtons)
            {
                c.Add(game.Shapes[i]);
            }
            foreach (Shape s in c)
            {
                if (Global.canPlaceAnywhere(s, ref game) == true)
                {
                    game.GameOver = false;
                }
            }
        }
    }
}

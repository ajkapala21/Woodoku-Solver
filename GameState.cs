using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woodoku_App
{
    public class GameState
    {
        public bool[,] board;
        public List<int> activeButtons;
        public List<Shape> Shapes;
        public int Score;
        public int SpaceScore;
        public int round;
        public Shape selectedShape;
        public int selectedShapeNum;
        public int streak;
        public bool GameOver;
        public List<Global.Move> movesLastRound;

        public GameState()
        {
            initBoard();
            activeButtons = new List<int> { 0, 1, 2};
            //Shapes will be set by the game controller
            round = 0;
            Score = 0;
            SpaceScore = 0;
            round = 0;
            selectedShape = new Shape();
            streak = 0;
            GameOver = false;
            Shapes = new List<Shape>();
            movesLastRound = new List<Global.Move>();
        }
        public GameState(ref GameState g)
        {
            board = new bool[9, 9];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = g.board[i,j];
                }
            }
            activeButtons = new List<int>();
            foreach(int i in g.activeButtons)
            {
                activeButtons.Add(i);
            }
            Shapes = g.Shapes;
            Score = g.Score;
            SpaceScore = g.SpaceScore;
            round = g.round;
            selectedShape = new Shape(g.selectedShape.getName(), g.selectedShape.getShape(), 
                g.selectedShape.getBitmap(), g.selectedShape.getEarliestRound(), g.selectedShape.getLatestRound());
            streak = g.streak;
            GameOver = g.GameOver;
            movesLastRound = new List<Global.Move>();
            foreach (Global.Move move in g.movesLastRound)
            {
                movesLastRound.Add(move);
            }
        }
        public void initBoard()
        {
            board = new bool[9, 9];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = false;
                }
            }
        }

    }
}

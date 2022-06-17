using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodoku_App
{
    class BestMove
    {

        int highScore;
        int highSpaceScore;
        List<List<Global.Move>> BestMoves;
        GameState originalGame;
        public BestMove(GameState game)
        {
            originalGame =  new GameState(ref game);
            BestMoves = new List<List<Global.Move>>();

        }
        public List<Global.Move> GetBestMoves()
        {
            BestMoves.Clear();
            FindBestMoves();
            Random rand = new Random();
            int num = rand.Next(BestMoves.Count);
            return BestMoves[num];
        }
        public void addToListIfBetter(ref GameState g)
        {
            if (g.Score == highScore && g.SpaceScore == highSpaceScore)
            {
                BestMoves.Add(g.movesLastRound);
            }
            else if ((g.Score == highScore && g.SpaceScore > highSpaceScore) || g.Score > highScore)
            {
                BestMoves.Clear();
                BestMoves.Add(g.movesLastRound);
                highScore = g.Score;
                highSpaceScore = g.SpaceScore;
            }
        }
        public void FindBestMoves()
        {
            List<List<int>> permutations = Permutations.Permute(originalGame.activeButtons.ToArray());
            foreach (List<int> list in permutations)
            {
                createAllGamesForOrder(list, ref originalGame, 0);
            }
        }
        public List<Global.Move> FindAllMoves(ref GameState game, int shapeNum)
        {
            List<Global.Move> allMoves = new List<Global.Move>();
            for (int i = 0; i < game.board.GetLength(0); i++)
            {
                for (int j = 0; j < game.board.GetLength(1); j++)
                {
                    if (Global.canPlaceAtLocation(game.Shapes[shapeNum], i, j, ref game))
                    {
                        Global.Location loc = new Global.Location(i, j);
                        Global.Move temp = new Global.Move(loc, shapeNum);
                        allMoves.Add(temp);
                    }
                }
            }
            return allMoves;
        }
        public void createAllGamesForOrder(List<int> list, ref GameState game, int i)
        {
            if (i >= list.Count || game.GameOver == true)
            {
                addToListIfBetter(ref game);
                return;
            }
            List<Global.Move> allMoves = FindAllMoves(ref game, list[i]);
            foreach (Global.Move move in allMoves)
            {
                GameState g = new GameState(ref game);
                GameController control = new GameController(ref g);
                g.selectedShapeNum = move.shape;
                g.selectedShape = g.Shapes[move.shape];
                control.makeMoveBot(move.location);
                createAllGamesForOrder(list, ref g, i + 1);
            }
        }
        public int playRestOfGame()
        {
            GameState game = new GameState(ref originalGame);
            GameController control = new GameController(ref game);
            while (game.GameOver != true)
            {
                List<Global.Move> moves = GetBestMoves();
                foreach (Global.Move move in moves)
                {
                    game.selectedShapeNum = move.shape;
                    game.selectedShape = game.Shapes[move.shape];
                    control.makeMove(move.location);
                }
                Global.botScore.Text = "Score: " + game.Score;
                Console.WriteLine("Score: " + game.Score);
            }
            Global.botScore.Text = "Score: " + game.Score + " Done";
            return originalGame.Score;
        }
    }
}

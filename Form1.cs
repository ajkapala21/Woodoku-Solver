using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woodoku_App
{
    public partial class Form1 : Form
    {
        GameState game;
        GameController mainGame;
        DisplayBoard display;
        List<Global.Move> moveList;

        List<Control> pieceSelection;
        Button gameOver;
        public Form1()
        {
            InitializeComponent();
            init();
            Global.changeScreen("start");
        }
        public void init()
        {
            Global.emptyShape = new Shape();
            Global.shapes = new Shapes();
            Global.mainForm = this;
            //multiple screens
            Global.BestMoveText = bestMoveText;
            Global.bestMoveButton = best_Move_Button;

            //Sets up Screen 1
            Global.gameScreen = new List<Control> { button1, button2, button3, round_label, home_button, score_label } ;
            Global.Button1 = button1;
            Global.Button2 = button2;
            Global.Button3 = button3;
            Global.roundLabel = round_label;
            Global.spaceScoreLabel = space_score_label;
            Global.ScoreLabel = score_label;
            Global.homeButton = home_button;
            //Set up Start Screen
            Global.startScreen = new List<Control> { go_to_game_screen, go_to_smart_screen };
            //set up Smart Screen
            Global.ClearAIButtons = AI_clear;
            Global.smartScreen = new List<Control> { best_Move_Button, bestMoveText, home_button, AI_clear };
            //set up Description Screen
            Global.descriptionScreen = new List<Control> { Ok_Button };
            Global.OkButton = Ok_Button;

        }

        public void GameFunction()
        {
            //initializes main drivers of the game
            game = new GameState();
            mainGame = new GameController(ref game);
            display = new DisplayBoard(game);
            
            clearEventHandlers();
            newChoices();
            initEventHandlers();
            display.updateLabels();
        }
        public void clearEventHandlers()
        {
            best_Move_Button.Click -= new EventHandler(BestMoveButton_OnClick);
        }
        public void initEventHandlers()
        {
            for (int i = 0; i < Global.display.GetLength(0); i++)
            {
                for (int j = 0; j < Global.display.GetLength(1); j++)
                {
                    Global.display[i, j].Click += new EventHandler(Label_OnClick);
                }
            }
            best_Move_Button.Click += new EventHandler(BestMoveButton_OnClick);
        }
        public void newChoices()
        {
            //Creates choices
            mainGame.create_choices();
            //then displays them
            display.displayButtons();
        }
        private void Label_OnClick(object sender, EventArgs e)
        {
            Piece p = sender as Piece;
            Global.Location location = Global.getLocation(p);
            if (Global.canPlaceAtLocation(game.selectedShape, location.X, location.Y, ref game) == false || game.selectedShape.getName() == "")
            {
                return;
            }
            mainGame.setSelectedLocation_OnClick(sender, e);
            checkForButtonDisplayUpdate();
            display.updateDisplay();

            if(game.GameOver == true)
            {
                createGameOverButton();
            }
        }
        //if no moves left creates new ones
        public void checkForButtonDisplayUpdate()
        {
            if (game.activeButtons.Count == 3)
            {
                display.displayButtons();
            }
        }
        public void createGameOverButton()
        {
            gameOver = new Button();
            gameOver.Size = new System.Drawing.Size(200, 100);
            gameOver.Text = "Game Over";
            gameOver.Click += new EventHandler(GameOverButton_OnClick);
            gameOver.Location = new System.Drawing.Point(Size.Width / 2 - gameOver.Size.Width / 2, Size.Height / 2 - gameOver.Size.Height / 2 - 100);
            Controls.Add(gameOver);
            Controls.SetChildIndex(gameOver, 1);
        }
        private void GameOverButton_OnClick(object sender, EventArgs e)
        {
            reset();
        }
        private void BestMoveButton_OnClick(object sender, EventArgs e)
        {
            if (game.Shapes.Count == 3)
            {
                bestMoveText.Text = "";
                BestMove best = new BestMove(game);
                moveList = best.GetBestMoves();
                foreach (Global.Move move in moveList)
                {
                    bestMoveText.Text += Global.printMoveSetUp(move, game) + "\n";
                }
                display.displayMoves(moveList);
                Button b = sender as Button;
                b.Text = "Place Moves";
                b.Click -= new EventHandler(BestMoveButton_OnClick);
                b.Click += new EventHandler(BestMoveButtonPlacement_OnClick);
            }
        }
        private void BestMoveButtonPlacement_OnClick(object sender, EventArgs e)
        {
            makeMoves(moveList);
            Button b = sender as Button;
            b.Text = "Show Moves";
            b.Click += new EventHandler(BestMoveButton_OnClick);
            b.Click -= new EventHandler(BestMoveButtonPlacement_OnClick);
            clearButtonsAI();
        }
        private void reset()
        {
            Controls.Remove(gameOver);
            //Removes all the labels of the board from the Display since a new ones will be created
            for (int i = 0; i < Global.display.GetLength(0); i++)
            {
                for (int j = 0; j < Global.display.GetLength(1); j++)
                {
                    Controls.Remove(Global.display[i, j]);
                }
            }
            GameFunction();
        }
        private void makeMoves(List<Global.Move> moves)
        {
            foreach(Global.Move move in moves)
            {
                game.selectedShape = game.Shapes[move.shape];
                game.selectedShapeNum = move.shape;
                mainGame.makeMove(move.location);
                checkForButtonDisplayUpdate();
                display.updateDisplay();
                if (game.GameOver == true)
                {
                    createGameOverButton();
                }
            }
        }
        private void bot_Game_Button_OnClick(object sender, EventArgs e)
        {
            int runs = 25;
            List<int> Score = new List<int>();
            for (int i = 0; i < runs; i++)
            {
                while (game.GameOver == false)
                {
                    bestMoveText.Text = "";
                    BestMove best = new BestMove(game);
                    List<Global.Move> list = best.GetBestMoves();
                    foreach (Global.Move move in list)
                    {
                        bestMoveText.Text += Global.printMoveSetUp(move, game) + "\n";
                    }
                    makeMoves(list);
                }
                Console.WriteLine("Game: " + i + " Score: " + game.Score);
                Score.Add(game.Score);
                reset();
            }
            int total = 0;
            foreach(int s in Score)
            {
                total += s;
            }
            Console.WriteLine("Average Score: " + total/runs);
        }
        private void go_to_smart_screen_Click(object sender, EventArgs e)
        {
            Global.changeScreen("description");
        }
        private void smartSetUp()
        {
            game = new GameState();
            mainGame = new GameController(ref game);
            display = new DisplayBoard(game);
            clearEventHandlers();
            best_Move_Button.Click += new EventHandler(BestMoveButton_OnClick);
            createAIButtons();
        }
        public void createAIButtons()
        {
            game.Shapes.Clear();
            Global.AIButtons = new List<Button>();
            for(int i = 0; i < 3; i++)
            {
                Button b = new Button();
                b.Location = new System.Drawing.Point(80 + 120 * i, 449);
                b.Size = new System.Drawing.Size(100, 100);
                b.BackColor = Color.White;
                b.Enabled = true;
                b.Click += new EventHandler(setPieceForButton);
                Controls.Add(b);
                Global.AIButtons.Add(b);
            }
        }
        private void setPieceForButton(object sender, EventArgs e)
        {
            game.Shapes.Add(Global.selectedAIShape);
            Button b = sender as Button;
            b.Enabled = false;
            b.BackgroundImage = Global.selectedAIShape.getBitmap();
            b.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void clearButtonsAI()
        {
            game.Shapes.Clear();
            foreach (Button b in Global.AIButtons)
            {
                b.Enabled = true;
                b.BackgroundImage = Global.emptyShape.getBitmap();
                b.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        private void go_to_game_screen_Click(object sender, EventArgs e)
        {
            GameFunction();
            Global.changeScreen("game");
        }
        private void setUpPieceSelection(int x, int y, int screenHeight, List<Shape> shapes)
        {
            pieceSelection = new List<Control>();
            int height = findDimensions(shapes.Count);
            int size = screenHeight / height;
            int index = 0;
            for(int row = 0; row < height; row++)
            {
                for(int col = 0; col < height/2; col++)
                {
                    PieceButton p = new PieceButton(x + col * size, y + row * size, size, shapes[index]);
                    Global.mainForm.Controls.Add(p);
                    pieceSelection.Add(p);
                    index++;
                    if (index >= shapes.Count)
                    {
                        return;
                    }
                }
            }
        }
        private int findDimensions(int count)
        {
            int height = 2;
            while (height * (height / 2) < count)
            {
                height += 2;
            }
            return height;
        }
        private void AI_clear_Click(object sender, EventArgs e)
        {
            game.Shapes.Clear();
            clearButtonsAI();
        }

        private void TEST_screen_Click(object sender, EventArgs e)
        {

            game = new GameState();
            mainGame = new GameController(ref game);
            mainGame.create_choices();

            int runs = 25;
            List<int> Score = new List<int>();
            for (int i = 0; i < runs; i++)
            {
                while (game.GameOver == false)
                {
                    bestMoveText.Text = "";
                    BestMove best = new BestMove(game);
                    List<Global.Move> list = best.GetBestMoves();
                    foreach (Global.Move move in list)
                    {
                        game.selectedShape = game.Shapes[move.shape];
                        game.selectedShapeNum = move.shape;
                        mainGame.makeMove(move.location);
                    }
                }
                Console.WriteLine("Game: " + i + " Score: " + game.Score);
                Score.Add(game.Score);
                game = new GameState();
                mainGame = new GameController(ref game);
                mainGame.create_choices();
            }
            int total = 0;
            foreach (int s in Score)
            {
                total += s;
            }
            Console.WriteLine("Average Score: " + total / runs);
        }

        private void home_button_Click(object sender, EventArgs e)
        {
            if (Global.AIButtons != null)
            {
                foreach(Control p in pieceSelection)
                {
                    Controls.Remove(p);
                }
                Global.DeleteAIButtons();
            }
            Global.DeleteDisplay();
            Global.changeScreen("start");
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            Global.changeScreen("smart");
            setUpPieceSelection(580, 10, 550, Global.shapes.shapes);
            smartSetUp();
        }
    }
}

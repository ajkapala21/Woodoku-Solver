using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woodoku_App
{
    public class Shapes
    {
        public List<Shape> shapes = new List<Shape>();
        public Shapes()
        {
            init_shapes();
        }
        /// <summary>
        /// Nothing fancy about the init_shapes function. I probably could have made a tool
        /// to help create the shape stuff but manually creating them with copy and paste work too.
        /// This class is basically made just to hide the atrocity of all the manually inputted shapes.
        /// </summary>
        public void init_shapes()
        {
            int r = 100000;
            bool[,] one = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("One Piece", one, Properties.Resource1.one, 3, 8)); //1
            bool[,] cross = new bool[,]
            {
                { false, false, false, false, false },
                { false, false, true, false, false },
                { false, true, true, true, false },
                { false, false, true, false, false },
                { false, false, false, false, false },
            };
            shapes.Add(new Shape("Joe Piece", cross, Properties.Resource1.Joe_Piece, 4, r));//2
            bool[,] TwoStepLeft = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, false, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("2 Step Left", TwoStepLeft, Properties.Resource1._2_Step_Left, 8, r));//3
            bool[,] TwoStepRight = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, true, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("2 Step Right", TwoStepRight, Properties.Resource1._2_Step_Right, 8, r));//4
            bool[,] TwoxTwo = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, true, false},
                {false, false, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Two x Two", TwoxTwo, Properties.Resource1._2x2, 1, r));//5
            bool[,] ThreeStepLeft = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, false, false, false},
                {false, false, true, false, false},
                {false, false, false, true, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("3 Step Left", ThreeStepLeft, Properties.Resource1._3_Step_Left, 8, r));//6
            bool[,] ThreeStepRight = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, true, false},
                {false, false, true, false, false},
                {false, true, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("3 Step Right", ThreeStepRight, Properties.Resource1._3_Step_Right, 8, r));//7
            bool[,] FourStepLeft = new bool[,]
            {
                {true, false, false, false, false},
                {false, true, false, false, false},
                {false, false, true, false, false},
                {false, false, false, true, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("4 Step Right", FourStepLeft, Properties.Resource1._4_Step_Left, 8, r));//8
            bool[,] FourStepRight = new bool[,]
            {
                {false, false, false, false, true},
                {false, false, false, true, false},
                {false, false, true, false, false},
                {false, true, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("4 Step Right", FourStepRight, Properties.Resource1._4_Step_Right, 8, r));//9
            bool[,] DownLeftStair = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, true, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Down Left Stair", DownLeftStair, Properties.Resource1.Down_Left_Stair, 1, r));//10
            bool[,] DownRightStair = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, false, true, true, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Down Right Stair", DownRightStair, Properties.Resource1.Down_Right_Stair, 1, r));//11
            bool[,] UpRightStair = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Up Right Stair", UpRightStair, Properties.Resource1.Up_Right_Stair, 1, r));//12
            bool[,] UpLeftStair = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, true, true, false, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Up Left Stair", UpLeftStair, Properties.Resource1.Up_Left_Stair, 1, r));//13
            bool[,] FerbDown = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, true, true, true, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Ferb Down", FerbDown, Properties.Resource1.Ferb_Down, 1, r));//14
            bool[,] FerbLeft = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, true, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Ferb Left", FerbLeft, Properties.Resource1.Ferb_Left, 1, r));//15
            bool[,] FerbRight = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, true, true, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Ferb Right", FerbRight, Properties.Resource1.Ferb_Right, 1, r));//16
            bool[,] FerbUp = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, true, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Ferb Up", FerbUp, Properties.Resource1.Ferb_Up, 1, r));//17
            bool[,] HFive = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {true, true, true, true, true},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Five Horizontal", HFive, Properties.Resource1.H_Five, 1, r));//18
            bool[,] HFour = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, true, true, true, true},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Four Horizontal", HFour, Properties.Resource1.H_Four, 1, r));//19
            bool[,] HThree = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, true, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Four Three", HThree, Properties.Resource1.H_Three, 1, r));//20
            bool[,] HTwo = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, false, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Four Two", HTwo, Properties.Resource1.H_two, 1, 8));//21
            bool[,] Helmet = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, true, true, true, false},
                {false, true, false, true, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Helmet", Helmet, Properties.Resource1.Helmet, 8, r));//22
            bool[,] UpSideDownHelmet = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, false, true, false},
                {false, true, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Upside Down Helmet", UpSideDownHelmet, Properties.Resource1.UpSideDown_Helmet, 8, r));//23
            bool[,] LeftHelmet = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, true, false, false},
                {false, false, true, false, false},
                {false, true, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Left Helmet", LeftHelmet, Properties.Resource1.Helmet_Left, 8, r));//24
            bool[,] RightHelmet = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, true, false},
                {false, false, true, false, false},
                {false, false, true, true, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Right Helmet", RightHelmet, Properties.Resource1.Helmet_Right, 8, r));//24
            bool[,] InvertedLDown = new bool[,]
{
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, true, true, true, false},
                {false, false, false, true, false},
                {false, false, false, false, false},
};
            shapes.Add(new Shape("Inverted L Down", InvertedLDown, Properties.Resource1.Inverted_L_Down, 1, r));//25
            bool[,] InvertedLLeft = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, true, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Inverted L Left", InvertedLLeft, Properties.Resource1.Inverted_L_Left, 1, r));//26
            bool[,] InvertedLRight = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, true, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Inverted L Right", InvertedLRight, Properties.Resource1.Inverted_L_Right, 1, r));//27
            bool[,] InvertedLUp = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, false, false, false},
                {false, true, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Inverted L Up", InvertedLUp, Properties.Resource1.Inverted_L_Up, 1, r));//28
            bool[,] LDown = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, true, true, true, false},
                {false, true, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("L Down", LDown, Properties.Resource1.L_Down, 1, r));//29
            bool[,] LLeft = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("L Left", LLeft, Properties.Resource1.L_Left, 1, r));//30
            bool[,] L = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, true, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("L Right", L, Properties.Resource1.L_Right, 1, r));//31
            bool[,] LUp = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, true, false},
                {false, true, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("L Up", LUp, Properties.Resource1.L_Up, 1, r));//32
            bool[,] Quadrant1 = new bool[,]
            {
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, true, true},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Quadrant 1", Quadrant1, Properties.Resource1.Quadrant_1, 1, r));//33
            bool[,] Quadrant2 = new bool[,]
            {
                {false, false, true, false, false},
                {false, false, true, false, false},
                {true, true, true, false, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Quadrant 2", Quadrant2, Properties.Resource1.Quadrant_2, 1, r));//34
            bool[,] Quadrant3 = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {true, true, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
            };
            shapes.Add(new Shape("Quadrant 3", Quadrant3, Properties.Resource1.Quandrant_3, 1, r));//35
            bool[,] Quadrant4 = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, false, true, true, true},
                {false, false, true, false, false},
                {false, false, true, false, false},
            };
            shapes.Add(new Shape("Quadrant 4", Quadrant4, Properties.Resource1.Quadrant_4, 1, r));//36
            bool[,] SliderDown = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, true, false},
                {false, false, true, true, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Slider Down", SliderDown, Properties.Resource1.Slider_Down, 1, r));//37
            bool[,] SliderLeft = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, true, false, false},
                {false, false, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Slider Left", SliderLeft, Properties.Resource1.Slider_Left, 1, r));//38
            bool[,] SliderUp = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, false, false, false},
                {false, true, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Slider Up", SliderUp, Properties.Resource1.Slider_Up, 1, r));//39
            bool[,] sliderRight = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, true, false},
                {false, true, true, false, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Slider Right", sliderRight, Properties.Resource1.Slider_Right, 1, r));//40
            bool[,] T = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, true, true, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("T", T, Properties.Resource1.T, 1, r));//41
            bool[,] TDown = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, true, true, true, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("T Down", TDown, Properties.Resource1.T_Down, 1, r));//42
            bool[,] TLeft = new bool[,]
            {
                {false, false, false, false, false},
                {false, true, false, false, false},
                {false, true, true, true, false},
                {false, true, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("T Left", TLeft, Properties.Resource1.T_Left, 1, r));//43
            bool[,] TRight = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, false, true, false},
                {false, true, true, true, false},
                {false, false, false, true, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("T Right", TRight, Properties.Resource1.T_Right, 1, r));//44
            bool[,] VFive = new bool[,]
            {
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
            };
            shapes.Add(new Shape("Vertical Five", VFive, Properties.Resource1.V_Five, 1, r));//45
            bool[,] VFour = new bool[,]
            {
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Vertical Four", VFour, Properties.Resource1.V_Four, 1, r));//46
            bool[,] VThree = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Vertical Three", VThree, Properties.Resource1.V_Three, 1, r));//47
            bool[,] VTwo = new bool[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false},
                {false, false, false, false, false},
            };
            shapes.Add(new Shape("Vertical Two", VTwo, Properties.Resource1.V_Two, 1, r));
        }

        //gives a list of only the possible shapes i want based on the round
        public List<Shape> ShapesIWant(int round)
        {
            List<Shape> temp = new List<Shape>();
            foreach (Shape s in shapes)
            {
                if (s.getEarliestRound() <= round && s.getLatestRound() >= round)
                {
                    temp.Add(s);
                }
            }
            return temp;
        }
    }
}

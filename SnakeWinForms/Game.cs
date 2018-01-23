using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Reflection;

namespace SnakeWinForms
{
    class Game
    {
        public delegate void SomethingChange();
        public event SomethingChange OnChange;
        public event SomethingChange GameOver;
        Timer timer;
        public Snake Snake { get; private set; }
        public Field Field { get; private set; }
        public bool AllowToSpin { get; set; }
        public int Points { get; private set; }
        public bool GameOnPause = false;
        public Game(string Level)
        {
            int width, height;
            Points = 0;
            AllowToSpin = true;
            timer = new Timer();
            timer.Elapsed += SnakeStep;
            timer.Interval = 500;
            List<string> temp = new List<string>();
          
            string[] arr = Level.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            temp = arr.ToList<string>();

            width = temp[0].Length;
            height = temp.Count;
            List<Segment> Body = new List<Segment>();
            CellState[,] Map = new CellState[height,width];
            for (int i = 0; i < height; i++)
            {
                string row = temp[i];
                for (int j = 0; j < width; j++)
                {
                    char ch = row[j];
                    if (ch == '1')
                        Map[i, j] = CellState.Wall;
                    if (ch == '2')
                        Body.Add(new Segment(i, j));
                }
            }
            Snake = new Snake(Body);
            Field = new Field(Map, width, height);
        }

        private void SnakeStep(object sender, ElapsedEventArgs e)
        {
            
            Snake.Move();
            AllowToSpin = true;
            if (IsPlayerLose())
            {
                timer.Stop();
                GameOver();
            }
            else
            {
                CheckFood();
                OnChange();
            }
        }
        public void PauseUnPause()
        {
            if (GameOnPause)
                timer.Start();
            else
                timer.Stop();
            GameOnPause = !GameOnPause;
        }
        public void Start()
        {
            timer.Start();
        }
        private bool IsPlayerLose()
        {
                if (Snake.IsItOver)
                    return true;

                if (Field.Map[Snake.Head.RowIndx,Snake.Head.ColIndx] == CellState.Wall)
                    return true;
                return false;
        }
        private void CheckFood()
        {
            if (Field.Map[Snake.Head.RowIndx, Snake.Head.ColIndx] == CellState.Food)
            {
                Field.Map[Snake.Head.RowIndx, Snake.Head.ColIndx] = CellState.None;
                Field.PlaceFood();
                Points++;
                timer.Interval = timer.Interval/1.1f;
                Snake.Eat();
            }
        }
    }
}

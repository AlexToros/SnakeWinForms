using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

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
        public Game(string LevelPath)
        {
            Points = 0;
            AllowToSpin = true;
            timer = new Timer();
            timer.Elapsed += SnakeStep;
            timer.Interval = 500;
            List<string> temp = new List<string>();
            using (StreamReader sstream = new StreamReader(LevelPath))
            {
                while (!sstream.EndOfStream)
                {
                    temp.Add(sstream.ReadLine());
                }
            }
            List<Segment> Body = new List<Segment>();
            CellState[,] Map = new CellState[temp[0].Length, temp.Count];
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp[i].Length; j++)
                {
                    if (temp[i][j] == '1')
                        Map[i, j] = CellState.Wall;
                    if (temp[i][j] == '2')
                        Body.Add(new Segment(i, j));
                }
            }
            Snake = new Snake(Body);
            Field = new Field(Map, temp[0].Length, temp.Count);
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

        public void Start()
        {
            timer.Start();
        }
        private bool IsPlayerLose()
        {
            try
            {
                if (Snake.IsItOver)
                    return true;

                if (Field.Map[Snake.Head.RowIndx,Snake.Head.ColIndx] == CellState.Wall)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
            
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

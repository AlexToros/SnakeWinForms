using System.Collections.Generic;
using System.IO;

namespace SnakeWinForms
{
    class Snake
    {
        public class Segment
        {
            public int RowIndx { get; set; }
            public int ColIndx { get; set; }
            public Segment(int rowIndx, int colIndx)
            {
                RowIndx = rowIndx;
                ColIndx = colIndx;
            }
        }
        public enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }
        public Segment Head { get; private set; }
        public Direction CurrentDirection { get; set; }
        public List<Segment> Body { get; private set; }
        public Snake(string LevelPath)
        {
            CurrentDirection = Direction.Left;
            Body = new List<Segment>();

            List<string> temp = new List<string>();
            using (StreamReader sstream = new StreamReader(LevelPath))
            {
                while (!sstream.EndOfStream)
                {
                    temp.Add(sstream.ReadLine());
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp[i].Length; j++)
                {
                    if (temp[i][j] == '2')
                        Body.Add(new Segment(i,j));
                }
            }
            Head = Body[0];
        }
        public void Move()
        {
            Body[Body.Count - 1].ColIndx = Head.ColIndx;
            Body[Body.Count - 1].RowIndx = Head.RowIndx;
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Head.RowIndx++;
                    break;
                case Direction.Right:
                    Head.ColIndx++;
                    break;
                case Direction.Down:
                    Head.RowIndx--;
                    break;
                case Direction.Left:
                    Head.ColIndx--;
                    break;
            }
        }
        
    }
}

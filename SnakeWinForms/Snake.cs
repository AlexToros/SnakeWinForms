using System.Collections.Generic;
using System.IO;
using System;

namespace SnakeWinForms
{
    class Snake
    {
        public bool IsItOver = false;
        public Segment Head { get; private set; }
        public Direction CurrentDirection { get; set; }
        public List<Segment> Body { get; private set; }

        public Snake(List<Segment> body)
        {
            CurrentDirection = Direction.Left;
            Body = body;
            Head = Body[0];
        }
        public void Move()
        {
            for (int i = Body.Count-1; i > 0; i--)    
            {
                Body[i].ColIndx = Body[i - 1].ColIndx;
                Body[i].RowIndx = Body[i - 1].RowIndx;
            }
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Head.RowIndx--;
                    break;
                case Direction.Right:
                    Head.ColIndx++;
                    break;
                case Direction.Down:
                    Head.RowIndx++;
                    break;
                case Direction.Left:
                    Head.ColIndx--;
                    break;
            }
            for (int i = 1; i < Body.Count; i++)
            {
                if (Head.Equals(Body[i]))
                {
                    IsItOver = true;
                    break;
                }
            }
        }
        public void Eat()
        {
            Body.Add(new Segment(Head.RowIndx, Head.ColIndx));
        }
        
    }
    public class Segment : IEquatable<Segment>
    {
        public int RowIndx { get; set; }
        public int ColIndx { get; set; }
        public Segment(int rowIndx, int colIndx)
        {
            RowIndx = rowIndx;
            ColIndx = colIndx;
        }

        public bool Equals(Segment other)
        {
            return this.ColIndx == other.ColIndx && this.RowIndx == other.RowIndx;
        }
    }
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
}

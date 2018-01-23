using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace SnakeWinForms
{
    class Field
    {
        Random rnd = new Random();
        public CellState[,] Map { get; private set; }
        public static int Widht { get; private set; }
        public static int Height { get; private set; }
        public Field(CellState[,] map, int width, int height)
        {
            Map = map;
            Widht = width;
            Height = height;
            PlaceFood();
        }

        public void PlaceFood()
        {
            int cIndx = rnd.Next(0, Widht);
            int rIndx = rnd.Next(0, Height);
            if (Map[cIndx, rIndx] == CellState.None)
                Map[cIndx, rIndx] = CellState.Food;
            else
                PlaceFood();
        }
    }
    public enum CellState
    {
        None,
        Wall,
        Food
    }
}
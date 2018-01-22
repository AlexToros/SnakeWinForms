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
        public Snake Snake { get; private set; }
        public enum CellState
        {
            None,
            Wall,
            Food,
            SnakeBody
        }
        public CellState[,] Map { get; private set; }

        public Field(string LevelPath)
        {
            List<string> temp = new List<string>();
            using (StreamReader sstream = new StreamReader(LevelPath))
            {
                while (!sstream.EndOfStream)
                {
                    temp.Add(sstream.ReadLine());
                }
            }
            Map = new CellState[temp[0].Length, temp.Count];
            for (int i = 0; i < temp.Count; i++)
            {
                for (int j = 0; j < temp[i].Length; j++)
                {
                    if (temp[i][j] == '1')
                    {
                        Map[i, j] = CellState.Wall;
                    }
                }
            }
        }

    }
}
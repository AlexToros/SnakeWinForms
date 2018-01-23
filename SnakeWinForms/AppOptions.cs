using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeWinForms
{
    static class AppOptions
    {
        public static bool AllowGoThroughWall = false;

        public static string CurrentLevel = Properties.Resources.TestLevel;
        public static int CellSide = 20;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeWinForms
{
    class FieldBox : UserControl
    {
        private TextBox tb;
        public Game Game { get; private set; }
        public FieldBox()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            DoubleBuffered = true;
            Width = 500;
            Height = 500;
            Dock = DockStyle.Fill;
            BackColor = Color.White;
        }
        public void BuildLevel(Game game, TextBox Tb)
        {
            Game = game;
            tb = Tb;
            Game.OnChange += Game_OnChange;
            Game.GameOver += Game_GameOver;
        }

        private void Game_GameOver()
        {
            MessageBox.Show("Конец!");
        }

        private void Game_OnChange()
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Game == null) return;
            int CellWidth = Width / Field.Widht;
            int CellHeight = Height / Field.Height;
            System.Drawing.Size rectangleSize = new Size(CellWidth,CellHeight);
            Point currentLocation;
            for (int i = 0; i < Field.Widht; i++)
                for (int j = 0; j < Field.Height; j++)
                {
                    currentLocation = new Point(j * CellWidth, i * CellHeight);
                    switch (Game.Field.Map[i,j])
                    {
                        case CellState.Wall:
                            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(currentLocation, rectangleSize));
                            break;
                        case CellState.Food:
                            e.Graphics.FillRectangle(Brushes.Yellow, new Rectangle(currentLocation, rectangleSize));
                            break;
                    }
                }
            foreach (Segment s in Game.Snake.Body)
            {
                currentLocation = new Point(s.ColIndx * CellWidth, s.RowIndx * CellHeight);
                e.Graphics.FillRectangle(Brushes.Green, new Rectangle(currentLocation, rectangleSize));
            }
            tb.Text = Game.Points.ToString();
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!Game.AllowToSpin) return;
            Keys key = e.KeyCode;
            switch (key)    
            {
                case Keys.Left:
                    if (Game.Snake.CurrentDirection == Direction.Right) return;
                    Game.AllowToSpin = false;
                    Game.Snake.CurrentDirection = Direction.Left;
                    break;
                case Keys.Up:
                    if (Game.Snake.CurrentDirection == Direction.Down) return;
                    Game.AllowToSpin = false;
                    Game.Snake.CurrentDirection = Direction.Up;
                    break;
                case Keys.Right:
                    if (Game.Snake.CurrentDirection == Direction.Left) return;
                    Game.AllowToSpin = false;
                    Game.Snake.CurrentDirection = Direction.Right;
                    break;
                case Keys.Down:
                    if (Game.Snake.CurrentDirection == Direction.Up) return;
                    Game.AllowToSpin = false;
                    Game.Snake.CurrentDirection = Direction.Down;
                    break;
            }
        }
    }
}

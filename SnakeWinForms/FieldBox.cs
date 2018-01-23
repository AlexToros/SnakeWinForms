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
        Form1 containeer;
        private Label label1;
        private TextBox tb;
        public Game Game { get; private set; }
        public FieldBox()
        {
            InitializeComponent();

            label1.Text = "Игра Змейка" + Environment.NewLine + "Выбор уровней в настройках" +
                Environment.NewLine + "Управление - Arrow Keys" + Environment.NewLine + "Пауза - Esc";
        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(810, 390);
            this.label1.TabIndex = 0;
            this.label1.Text = "Приветствие";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FieldBox
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "FieldBox";
            this.Size = new System.Drawing.Size(810, 390);
            this.ResumeLayout(false);

        }
        public void HideTheStartLable()
        {
            label1.Visible = false;
        }
        public void BuildLevel(Game game, TextBox Tb, Form1 form1)
        {
            Game = game;
            tb = Tb;
            containeer = form1;
            Game.OnChange += Game_OnChange;
            Game.GameOver += Game_GameOver;
            containeer.Width = Field.Widht * AppOptions.CellSide + 16;
            containeer.Height = Field.Height * AppOptions.CellSide + 62;
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
            int Side = AppOptions.CellSide;
            System.Drawing.Size rectangleSize = new Size(Side, Side);
            Point currentLocation;
            for (int i = 0; i < Field.Widht; i++)
                for (int j = 0; j < Field.Height; j++)
                {
                    currentLocation = new Point(i * Side, j * Side);
                    switch (Game.Field.Map[j,i])
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
                currentLocation = new Point(s.ColIndx * Side, s.RowIndx * Side);
                e.Graphics.FillRectangle(Brushes.Green, new Rectangle(currentLocation, rectangleSize));
            }
            tb.Text = Game.Points.ToString();
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (Game == null) return;
            if (!Game.AllowToSpin) return;
            Keys key = e.KeyCode;
            if (!Game.GameOnPause)
            {
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
            if (key == Keys.Escape)
            {
                if (!Game.GameOnPause)
                {
                    Graphics gr = this.CreateGraphics();
                    Font font = new Font("Arial", 44);
                    gr.DrawString("PAUSE", font, Brushes.Red, Field.Widht * AppOptions.CellSide / 2 - 100, Field.Height * AppOptions.CellSide / 2-40);
                }
                Game.PauseUnPause();
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeWinForms
{
    public partial class Form1 : Form
    {
        Game Game;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game = new Game(AppOptions.CurrentLevel);
            SnakeField.BuildLevel(Game, textBox1, this);
            SnakeField.Invalidate();
            SnakeField.HideTheStartLable();
            Game.Start();
            SnakeField.Focus();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm f = new OptionsForm();
            f.ShowDialog();
        }
        
    }
}

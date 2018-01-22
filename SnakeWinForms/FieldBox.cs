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
        
        public Field CurrentField { get; private set; }
        public FieldBox()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            Width = 500;
            Height = 500;
            Dock = DockStyle.Fill;
            BackColor = Color.White;
        }
        public void BuildLevel(Snake snake, Field field)
        {
            CurrentField = field;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            
        }
    }
}

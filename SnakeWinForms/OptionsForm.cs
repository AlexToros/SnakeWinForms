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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            BehaviorCHB.Checked = AppOptions.AllowGoThroughWall;
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            AppOptions.AllowGoThroughWall = BehaviorCHB.Checked;
            this.Close();
        }

        private void Cancel_button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SnakeWinForms
{
    public partial class OptionsForm : Form
    {
        public class Level
        {
            public string Name { get; private set; }
            public string Value { get; private set; }
            public Level(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
        List<Level> Levels;
        public OptionsForm()
        {
            InitializeComponent();
            BehaviorCHB.Checked = AppOptions.AllowGoThroughWall;
            Levels = new List<Level>();
            Type t = typeof(SnakeWinForms.Properties.Resources);
            foreach (var s in t.GetProperties())
            {
                if (s.PropertyType == typeof(string))
                    Levels.Add(new Level(s.Name, s.GetValue(t,null).ToString()) );
            }
            LevelsBox.DataSource = Levels;
            LevelsBox.DisplayMember = "Name";
            LevelsBox.ValueMember = "Value";
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            AppOptions.AllowGoThroughWall = BehaviorCHB.Checked;
            AppOptions.CurrentLevel = (string)LevelsBox.SelectedValue;
            this.Close();
        }

        private void Cancel_button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

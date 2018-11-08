using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroGame.Characters;

namespace FightMechanizmTestingGUI
{
    public partial class FightScreen : Form
    {
        public List<Character> teamA = new List<Character>();
        public List<Character> teamB = new List<Character>();

        public FightScreen()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btStart_Click(object sender, EventArgs e)
        {

        }

        private void btNextTurn_Click(object sender, EventArgs e)
        {

        }
    }
}

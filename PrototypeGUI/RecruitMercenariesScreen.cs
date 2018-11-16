using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.RefresingMechanism;

namespace PrototypeGUI
{
    public partial class RecruitMercenariesScreen : Form
    {
        private RefreshingMechnism _refreshingMechnism;
        public RecruitMercenariesScreen(RefreshingMechnism refreshingMechnism)
        {
            InitializeComponent();
            _refreshingMechnism = refreshingMechnism;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RecruitMercenariesScreen_Load(object sender, EventArgs e)
        {

        }
    }
}

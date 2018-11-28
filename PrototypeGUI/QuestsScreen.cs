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
    public partial class QuestsScreen : Form
    {
        private readonly IRefreshingMechnism _refreshingMechnism;

        public QuestsScreen(IRefreshingMechnism refreshingMechnism)
        {
            InitializeComponent();
            _refreshingMechnism = refreshingMechnism;
        }

        private void AdventuresScreen_Load(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btBeginQuest_Click(object sender, EventArgs e)
        {

        }
    }
}

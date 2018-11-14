using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototypeGUI
{
    public partial class btCampain : Form
    {
        public btCampain()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.ShowDialog();
        }

        private void btHeroes_Click(object sender, EventArgs e)
        {
            HeroesScreen heroesScreen = new HeroesScreen();
            heroesScreen.ShowDialog();
        }

        private void btMercenaries_Click(object sender, EventArgs e)
        {
            MercenariesScreen mercenariesScreen = new MercenariesScreen();
            mercenariesScreen.ShowDialog();
        }

        private void btInventory_Click(object sender, EventArgs e)
        {
            InventoryScreen inventoryScreen = new InventoryScreen();
            inventoryScreen.ShowDialog();
        }

        private void btRecruitMercenaries_Click(object sender, EventArgs e)
        {
            RecruitMercenariesScreen recruitMercenariesScreen = new RecruitMercenariesScreen();
            recruitMercenariesScreen.ShowDialog();
        }
    }
}

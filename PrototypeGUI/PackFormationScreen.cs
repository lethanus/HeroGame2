using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.Mercenaries;

namespace PrototypeGUI
{
    public partial class PackFormationScreen : Form
    {
        private readonly IMercenaryManagement _mercenaryManagement;

        public PackFormationScreen(IMercenaryManagement mercenaryManagement)
        {
            InitializeComponent();
            _mercenaryManagement = mercenaryManagement;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PackFormationScreen_Load(object sender, EventArgs e)
        {
            var characters = _mercenaryManagement.GetAllMercenariesForLoggedUser();

            listCharacters.Columns.Clear();
            listCharacters.Columns.Add("Level", 40, HorizontalAlignment.Center);
            listCharacters.Columns.Add("Name", 70, HorizontalAlignment.Center);
            listCharacters.Columns.Add("MaxHp", 50, HorizontalAlignment.Center);
            listCharacters.Columns.Add("Attack", 50, HorizontalAlignment.Center);
            listCharacters.Columns.Add("Defence", 60, HorizontalAlignment.Center);
            listCharacters.Columns.Add("Speed", 50, HorizontalAlignment.Center);
            listCharacters.Items.Clear();
            foreach (var character in characters)
            {
                List<string> row = new List<string>();
                row.Add(character.Level.ToString());
                row.Add(character.Name);
                row.Add(character.MaxHp.ToString());
                row.Add($"{character.getMin_Att().ToString()}-{character.getMax_Att().ToString()}");
                row.Add(character.Def.ToString());
                row.Add(character.Speed.ToString());
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = character;
                listCharacters.Items.Add(listViewItem);
            }
        }

        private void btFront1_Click(object sender, EventArgs e)
        {

        }

        private void btFront2_Click(object sender, EventArgs e)
        {

        }

        private void btFront3_Click(object sender, EventArgs e)
        {

        }

        private void btMiddle1_Click(object sender, EventArgs e)
        {

        }

        private void btMiddle2_Click(object sender, EventArgs e)
        {

        }

        private void btMiddle3_Click(object sender, EventArgs e)
        {

        }

        private void btMiddle4_Click(object sender, EventArgs e)
        {

        }

        private void btRear1_Click(object sender, EventArgs e)
        {

        }

        private void btRear2_Click(object sender, EventArgs e)
        {

        }

        private void btRear3_Click(object sender, EventArgs e)
        {

        }
    }
}

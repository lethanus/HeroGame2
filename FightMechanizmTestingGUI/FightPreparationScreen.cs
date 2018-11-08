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
    public partial class FightPreparationScreen : Form
    {
        private List<Character> teamA = new List<Character>();
        private List<Character> teamB = new List<Character>();

        public FightPreparationScreen()
        {
            InitializeComponent();
        }

        private void FightPreparationScreen_Load(object sender, EventArgs e)
        {
            CharacterFactory characterFactory = new CharacterFactory();
            var characters = characterFactory.BuildStandardCharacters();
            listCharacters.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listCharacters.Columns.Add("MaxHp", 50, HorizontalAlignment.Right);
            listCharacters.Columns.Add("Attack", 50, HorizontalAlignment.Right);
            listCharacters.Columns.Add("Defence", 50, HorizontalAlignment.Right);
            listCharacters.Columns.Add("Speed", 50, HorizontalAlignment.Right);
            
            foreach (var character in characters)
            {
                string[] row = { character.Name, character.MaxHp.ToString(), character.Att.ToString(), character.Def.ToString(), character.Speed.ToString() };
                var listViewItem = new ListViewItem(row);
                listViewItem.Tag = character;
                listCharacters.Items.Add(listViewItem);
            }
        }

        private void btToTeamB_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listCharacters.SelectedItems)
            {
                var character = (Character)item.Tag;
                teamB.Add(character);
            }

            listTeamB.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listTeamB.Columns.Add("MaxHp", 50, HorizontalAlignment.Right);
            listTeamB.Columns.Add("Attack", 50, HorizontalAlignment.Right);
            listTeamB.Columns.Add("Defence", 50, HorizontalAlignment.Right);
            listTeamB.Columns.Add("Speed", 50, HorizontalAlignment.Right);

            listTeamB.Items.Clear();
            foreach (var character in teamB)
            {
                string[] row = { character.Name, character.MaxHp.ToString(), character.Att.ToString(), character.Def.ToString(), character.Speed.ToString() };
                var listViewItem = new ListViewItem(row);
                listViewItem.Tag = character;
                listTeamB.Items.Add(listViewItem);
            }
        }

        private void btToTeamA_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listCharacters.SelectedItems)
            {
                var character = (Character)item.Tag;
                teamA.Add(character);
            }

            listTeamA.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listTeamA.Columns.Add("MaxHp", 50, HorizontalAlignment.Right);
            listTeamA.Columns.Add("Attack", 50, HorizontalAlignment.Right);
            listTeamA.Columns.Add("Defence", 50, HorizontalAlignment.Right);
            listTeamA.Columns.Add("Speed", 50, HorizontalAlignment.Right);

            listTeamA.Items.Clear();
            foreach (var character in teamA)
            {
                string[] row = { character.Name, character.MaxHp.ToString(), character.Att.ToString(), character.Def.ToString(), character.Speed.ToString() };
                var listViewItem = new ListViewItem(row);
                listViewItem.Tag = character;
                listTeamA.Items.Add(listViewItem);
            }
        }

        private void btSimulateFight_Click(object sender, EventArgs e)
        {

        }

        private void btRemoveFromA_Click(object sender, EventArgs e)
        {

        }

        private void btRemoveFromB_Click(object sender, EventArgs e)
        {

        }
    }
}

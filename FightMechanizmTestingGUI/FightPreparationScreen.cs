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
            RefreshListView(listCharacters, characters);
        }

        private void RefreshListView(ListView listView, List<Character> characters)
        {
            listView.Columns.Clear();
            listView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listView.Columns.Add("MaxHp", 50, HorizontalAlignment.Right);
            listView.Columns.Add("Attack", 50, HorizontalAlignment.Right);
            listView.Columns.Add("Defence", 50, HorizontalAlignment.Right);
            listView.Columns.Add("Speed", 50, HorizontalAlignment.Right);
            //listView.Columns.Add("ID", 100, HorizontalAlignment.Right);
            listView.Items.Clear();
            foreach (var character in characters)
            {
                string[] row = { character.Name, character.MaxHp.ToString(), character.Att.ToString(), character.Def.ToString(), character.Speed.ToString(), character.ID };
                var listViewItem = new ListViewItem(row);
                listViewItem.Tag = character;
                listView.Items.Add(listViewItem);
            }
        }

        private void btToTeamB_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listCharacters.SelectedItems)
            {
                var character = (Character)item.Tag;
                teamB.Add(character.CreateCopy());
            }
            RefreshListView(listTeamB, teamB);
        }

        private void btToTeamA_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listCharacters.SelectedItems)
            {
                var character = (Character)item.Tag;
                teamA.Add(character.CreateCopy());
            }
            RefreshListView(listTeamA, teamA);
        }

        private void btSimulateFight_Click(object sender, EventArgs e)
        {

        }

        private void btRemoveFromA_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listTeamA.SelectedItems)
            {
                var character = (Character)item.Tag;
                teamA = teamA.Where(x => x.ID != character.ID).ToList();
            }
            RefreshListView(listTeamA, teamA);
        }

        private void btRemoveFromB_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listTeamB.SelectedItems)
            {
                var character = (Character)item.Tag;
                teamB = teamB.Where(x => x.ID != character.ID).ToList();
            }
            RefreshListView(listTeamB, teamB);

        }
    }
}

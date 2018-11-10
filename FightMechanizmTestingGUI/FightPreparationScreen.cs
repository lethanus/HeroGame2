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
        private List<ICharacterInTeam> teamA = new List<ICharacterInTeam>();
        private List<ICharacterInTeam> teamB = new List<ICharacterInTeam>();

        public FightPreparationScreen()
        {
            InitializeComponent();
        }

        private void FightPreparationScreen_Load(object sender, EventArgs e)
        {
            CharacterFactory characterFactory = new CharacterFactory();
            var characters = characterFactory.BuildStandardCharacters();
            RefreshListView(listCharacters, characters, false);
        }

        private void RefreshListView(ListView listView, List<ICharacterInTeam> characters, bool team)
        {
            listView.Columns.Clear();
            listView.Columns.Add("Name", 100, HorizontalAlignment.Left);
            if (team) listView.Columns.Add("Position", 90, HorizontalAlignment.Left);
            listView.Columns.Add("MaxHp", 50, HorizontalAlignment.Right);
            listView.Columns.Add("Attack", 50, HorizontalAlignment.Right);
            listView.Columns.Add("Defence", 70, HorizontalAlignment.Right);
            listView.Columns.Add("Speed", 50, HorizontalAlignment.Right);
            listView.Items.Clear();
            foreach (var character in characters.Select(x=>x.GetCharacter()))
            {
                List<string> row = new List<string>();
                row.Add(character.Name);
                if (team) row.Add(character.GetPosition().ToString());
                row.Add(character.MaxHp.ToString());
                row.Add(character.Att.ToString());
                row.Add(character.Def.ToString());
                row.Add(character.Speed.ToString());
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = character;
                listView.Items.Add(listViewItem);
            }

        }

        private void btToTeamB_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listCharacters.SelectedItems)
            {
                var character = (Character)item.Tag;
                var copy = character.CreateCopy();
                copy.SetTeam("B");
                var position = TeamPositionHelper.GetFirstAvailablePositionInTeam(teamB);
                if (position != TeamPosition.None)
                {
                    copy.SetPosition(position);
                    teamB.Add(copy);
                }
            }
            RefreshListView(listTeamB, teamB, true);
        }

        private void btToTeamA_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listCharacters.SelectedItems)
            {
                var character = (Character)item.Tag;
                var copy = character.CreateCopy();
                copy.SetTeam("A");
                var position = TeamPositionHelper.GetFirstAvailablePositionInTeam(teamA);
                if (position != TeamPosition.None)
                {
                    copy.SetPosition(position);
                    teamA.Add(copy);
                }
            }
            RefreshListView(listTeamA, teamA, true);
        }

        private void btSimulateFight_Click(object sender, EventArgs e)
        {
            FightScreen fightScreen = new FightScreen();
            fightScreen.teamA.Clear();
            fightScreen.teamB.Clear();
            foreach(var character in teamA)
            {
                fightScreen.teamA.Add(character.GetCharacter().CreateCopy());
            }
            foreach (var character in teamB)
            {
                fightScreen.teamB.Add(character.GetCharacter().CreateCopy());
            }

            fightScreen.ShowDialog();
        }

        private void btRemoveFromA_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listTeamA.SelectedItems)
            {
                var character = (Character)item.Tag;
                teamA = teamA.Where(x => x.getID() != character.ID).ToList();
            }
            RefreshListView(listTeamA, teamA, true);
        }

        private void btRemoveFromB_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listTeamB.SelectedItems)
            {
                var character = (Character)item.Tag;
                teamB = teamB.Where(x => x.getID() != character.ID).ToList();
            }
            RefreshListView(listTeamB, teamB, true);

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

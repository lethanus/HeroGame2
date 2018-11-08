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
        public List<ICharacterInTeam> teamA = new List<ICharacterInTeam>();
        public List<ICharacterInTeam> teamB = new List<ICharacterInTeam>();

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

        private void FightScreen_Load(object sender, EventArgs e)
        {
            UpdateCharacters(teamA, teamB);
        }

        private void UpdateCharacters(List<ICharacterInTeam> teamA, List<ICharacterInTeam> teamB)
        {
            teamAfront1.Text = GetCharacterInfo(teamA, TeamPosition.Front_1);
            teamAfront2.Text = GetCharacterInfo(teamA, TeamPosition.Front_2);
            teamAfront3.Text = GetCharacterInfo(teamA, TeamPosition.Front_3);

            teamAmiddle1.Text = GetCharacterInfo(teamA, TeamPosition.Middle_1);
            teamAmiddle2.Text = GetCharacterInfo(teamA, TeamPosition.Middle_2);
            teamAmiddle3.Text = GetCharacterInfo(teamA, TeamPosition.Middle_3);
            teamAmiddle4.Text = GetCharacterInfo(teamA, TeamPosition.Middle_4);

            teamArear1.Text = GetCharacterInfo(teamA, TeamPosition.Rear_1);
            teamArear2.Text = GetCharacterInfo(teamA, TeamPosition.Rear_2);
            teamArear3.Text = GetCharacterInfo(teamA, TeamPosition.Rear_3);

            teamBfront1.Text = GetCharacterInfo(teamB, TeamPosition.Front_1);
            teamBfront2.Text = GetCharacterInfo(teamB, TeamPosition.Front_2);
            teamBfront3.Text = GetCharacterInfo(teamB, TeamPosition.Front_3);

            teamBmiddle1.Text = GetCharacterInfo(teamB, TeamPosition.Middle_1);
            teamBmiddle2.Text = GetCharacterInfo(teamB, TeamPosition.Middle_2);
            teamBmiddle3.Text = GetCharacterInfo(teamB, TeamPosition.Middle_3);
            teamBmiddle4.Text = GetCharacterInfo(teamB, TeamPosition.Middle_4);

            teamBrear1.Text = GetCharacterInfo(teamB, TeamPosition.Rear_1);
            teamBrear2.Text = GetCharacterInfo(teamB, TeamPosition.Rear_2);
            teamBrear3.Text = GetCharacterInfo(teamB, TeamPosition.Rear_3);

        }

        private string GetCharacterInfo(List<ICharacterInTeam> team, TeamPosition position)
        {
            var character = team.FirstOrDefault(x => x.GetPosition() == position);
            if (character == null) return "NONE";
            else return character.GetCharacter().ToCharacterString();
        }
    }
}

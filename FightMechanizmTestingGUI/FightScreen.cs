using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.Characters;
using HeroesGame.FightMechanizm;

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
            var all = new List<ICharacterInTeam>();
            all.AddRange(teamA);
            all.AddRange(teamB);
            FightMechanizm fightMechanizm = new FightMechanizm(all,"A","B", new TextBoxLogger(logBox));
            fightMechanizm.StartFight();
            UpdateCharacters(teamA, teamB);
            
        }

        private void FightScreen_Load(object sender, EventArgs e)
        {
            UpdateCharacters(teamA, teamB);
        }

        private void UpdateCharacters(List<ICharacterInTeam> teamA, List<ICharacterInTeam> teamB)
        {
            SetCharacterInfo(teamA, TeamPosition.Front_1, teamAfront1);
            SetCharacterInfo(teamA, TeamPosition.Front_2, teamAfront2);
            SetCharacterInfo(teamA, TeamPosition.Front_3, teamAfront3);

            SetCharacterInfo(teamA, TeamPosition.Middle_1, teamAmiddle1);
            SetCharacterInfo(teamA, TeamPosition.Middle_2, teamAmiddle2);
            SetCharacterInfo(teamA, TeamPosition.Middle_3, teamAmiddle3);
            SetCharacterInfo(teamA, TeamPosition.Middle_4, teamAmiddle4);

            SetCharacterInfo(teamA, TeamPosition.Rear_1, teamArear1);
            SetCharacterInfo(teamA, TeamPosition.Rear_2, teamArear2);
            SetCharacterInfo(teamA, TeamPosition.Rear_3, teamArear3);

            SetCharacterInfo(teamB, TeamPosition.Front_1, teamBfront1);
            SetCharacterInfo(teamB, TeamPosition.Front_2, teamBfront2);
            SetCharacterInfo(teamB, TeamPosition.Front_3, teamBfront3);

            SetCharacterInfo(teamB, TeamPosition.Middle_1, teamBmiddle1);
            SetCharacterInfo(teamB, TeamPosition.Middle_2, teamBmiddle2);
            SetCharacterInfo(teamB, TeamPosition.Middle_3, teamBmiddle3);
            SetCharacterInfo(teamB, TeamPosition.Middle_4, teamBmiddle4);

            SetCharacterInfo(teamB, TeamPosition.Rear_1, teamBrear1);
            SetCharacterInfo(teamB, TeamPosition.Rear_2, teamBrear2);
            SetCharacterInfo(teamB, TeamPosition.Rear_3, teamBrear3);

        }

        private void SetCharacterInfo(List<ICharacterInTeam> team, TeamPosition position, TextBox textBox)
        {
            var character = team.FirstOrDefault(x => x.GetPosition() == position);
            if (character == null)
            {
                textBox.Text = "NONE";
                textBox.BackColor = Color.Gray;
            }
            else
            {
                textBox.Text = character.GetCharacter().ToCharacterString();
                if (character.GetCharacter().Hp == 0) textBox.BackColor = Color.Orange;
                else textBox.BackColor = Color.LightGreen;
            }
        }
    }
}

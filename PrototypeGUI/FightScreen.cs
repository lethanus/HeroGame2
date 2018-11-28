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
using HeroesGame.Core.Randomizers;
using HeroesGame.Loggers;

namespace PrototypeGUI
{
    public partial class FightScreen : Form
    {
        public List<ICharacterInTeam> teamA = new List<ICharacterInTeam>();
        public List<ICharacterInTeam> teamB = new List<ICharacterInTeam>();
        private IFightManagement _fightManagement;
        private readonly IFightMechanizm _fightMechanizm;

        public FightScreen(IFightManagement fightManagement, IFightMechanizm fightMechanizm)
        {
            InitializeComponent();
            _fightManagement = fightManagement;
            _fightMechanizm = fightMechanizm;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            var all = new List<ICharacterInTeam>();
            all.AddRange(teamA);
            all.AddRange(teamB);
            _fightManagement.StartFight();
            UpdateCharacters(teamA, teamB);
            btClose.Enabled = true;

        }

        private void FightScreen_Load(object sender, EventArgs e)
        {
            _fightMechanizm.SetNewLogger(new TextBoxLogger(logBox));
            teamA = _fightManagement.GetPlayerCharacters();
            teamB = _fightManagement.GetOpponentCharacters();
            btClose.Enabled = false;
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

    public class TextBoxLogger : Logger
    {
        private RichTextBox _richTextBox;

        public TextBoxLogger(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;
        }

        public void LogLine(string line)
        {
            _richTextBox.AppendText(line + Environment.NewLine);
        }
    }
}

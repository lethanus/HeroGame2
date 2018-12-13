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
        private readonly FightReplay _fightReplay;
        private int actionID;
        private List<FightAction> currentActions;

        public FightScreen(FightReplay fightReplay)
        {
            InitializeComponent();
            _fightReplay = fightReplay;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            btClose.Enabled = true;
            actionID = 1;
            fightTimer.Enabled = true;
            btClose.Enabled = true;
        }

        private void FightScreen_Load(object sender, EventArgs e)
        {
            btClose.Enabled = false;
            UpdateCharacters(_fightReplay.TeamA, _fightReplay.TeamB);
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
                if(currentActions!= null)
                    foreach (var action in currentActions)
                    {
                        if (character.getID() == action.Attacker_ID)
                            textBox.BackColor = Color.Green;
                        if (character.getID() == action.Defender_ID)
                            textBox.BackColor = Color.Red;
                    }
            }
        }

        private void fightTimer_Tick(object sender, EventArgs e)
        {
            if (_fightReplay.Actions.Count(x=>x.Action_Order == actionID) == 0)
            {
                logBox.AppendText(_fightReplay.FightResult.ToString() + Environment.NewLine);
                fightTimer.Enabled = false;
            }
            else
            {
                currentActions = _fightReplay.Actions.Where(x=>x.Action_Order == actionID).ToList();
                foreach (var action in currentActions)
                {
                    var all = _fightReplay.TeamA.Union(_fightReplay.TeamB);
                    all.First(x => x.getID() == action.Defender_ID).setNewHP(action.Defender_New_Hp);
                    logBox.AppendText(action.ToString() + Environment.NewLine);
                }
                UpdateCharacters(_fightReplay.TeamA, _fightReplay.TeamB);
                actionID++;
            }
        }

        private void FightScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            fightTimer.Enabled = false;
        }
    }
}

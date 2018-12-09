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
        private List<ICharacterInTeam> _teamA;
        private List<ICharacterInTeam> _teamB;
        private Dictionary<int,FightAction> _actions;
        private readonly FightResult _fightResult;
        private int actionID;
        private FightAction currentAction;

        public FightScreen(List<ICharacterInTeam> teamA, List<ICharacterInTeam> teamB, List<FightAction> actions, FightResult fightResult)
        {
            InitializeComponent();
            _teamA = teamA;
            _teamB = teamB;
            _actions = actions.ToDictionary(x=>x.Action_Order, x=>x);
            _fightResult = fightResult;
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
            UpdateCharacters(_teamA, _teamB);
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
                if (currentAction != null)
                {
                    if (character.getID() == currentAction.Attacker_ID)
                        textBox.BackColor = Color.Green;
                    if (character.getID() == currentAction.Defender_ID)
                        textBox.BackColor = Color.Red;
                }
            }
        }

        private void fightTimer_Tick(object sender, EventArgs e)
        {
            if (!_actions.ContainsKey(actionID))
            {
                logBox.AppendText(_fightResult.ToString() + Environment.NewLine);
                fightTimer.Enabled = false;
            }
            else
            {
                currentAction = _actions[actionID++];
                var all = _teamA.Union(_teamB);
                all.First(x => x.getID() == currentAction.Defender_ID).setNewHP(currentAction.Defender_New_Hp);
                logBox.AppendText(currentAction.ToString() + Environment.NewLine);
                UpdateCharacters(_teamA, _teamB);
            }
        }
    }
}

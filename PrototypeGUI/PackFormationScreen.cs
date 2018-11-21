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
using HeroesGame.Characters;
using HeroesGame.PackBuilding;

namespace PrototypeGUI
{
    public partial class PackFormationScreen : Form
    {
        private readonly IMercenaryManagement _mercenaryManagement;
        private readonly IPackFormationBuilder _packFormationBuilder;

        public PackFormationScreen(IMercenaryManagement mercenaryManagement, IPackFormationBuilder packFormationBuilder)
        {
            InitializeComponent();
            _mercenaryManagement = mercenaryManagement;
            _packFormationBuilder = packFormationBuilder;
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
            RefreshPositions();
        }

        private void RefreshPositions()
        {
            var characters = _mercenaryManagement.GetAllMercenariesForLoggedUser();
            var positions = _packFormationBuilder.GetAll();

            front1.Text = GetCharacterInfo(positions, characters, TeamPosition.Front_1);
            front2.Text = GetCharacterInfo(positions, characters, TeamPosition.Front_2);
            front3.Text = GetCharacterInfo(positions, characters, TeamPosition.Front_3);
            middle1.Text = GetCharacterInfo(positions, characters, TeamPosition.Middle_1);
            middle2.Text = GetCharacterInfo(positions, characters, TeamPosition.Middle_2);
            middle3.Text = GetCharacterInfo(positions, characters, TeamPosition.Middle_3);
            middle4.Text = GetCharacterInfo(positions, characters, TeamPosition.Middle_4);
            rear1.Text = GetCharacterInfo(positions, characters, TeamPosition.Rear_1);
            rear2.Text = GetCharacterInfo(positions, characters, TeamPosition.Rear_2);
            rear3.Text = GetCharacterInfo(positions, characters, TeamPosition.Rear_3);

        }

        private string GetCharacterInfo(List<CharacterInThePack> positions, List<Character> characters, TeamPosition position)
        {
            var id = positions.First(x => x.Position == position).Character_ID;
            if (id != "")
                return characters.First(x => x.ID == id).ToPositionFormatString();
            else return "";
        }

        private void UpdatePosition(TeamPosition position)
        {
            if (listCharacters.SelectedItems.Count == 1)
            {
                var character = (Character)listCharacters.SelectedItems[0].Tag;
                _packFormationBuilder.SetCharacterToPosition(character.ID, position);
            }
        }

        private void btFront1_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Front_1);
            RefreshPositions();
        }

        private void btFront2_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Front_2);
            RefreshPositions();
        }

        private void btFront3_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Front_3);
            RefreshPositions();
        }

        private void btMiddle1_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Middle_1);
            RefreshPositions();
        }

        private void btMiddle2_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Middle_2);
            RefreshPositions();
        }

        private void btMiddle3_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Middle_3);
            RefreshPositions();
        }

        private void btMiddle4_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Middle_4);
            RefreshPositions();
        }

        private void btRear1_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Rear_1);
            RefreshPositions();
        }

        private void btRear2_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Rear_2);
            RefreshPositions();
        }

        private void btRear3_Click(object sender, EventArgs e)
        {
            UpdatePosition(TeamPosition.Rear_3);
            RefreshPositions();
        }
    }
}

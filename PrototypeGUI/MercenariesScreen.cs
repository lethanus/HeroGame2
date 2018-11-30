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

namespace PrototypeGUI
{
    public partial class MercenariesScreen : Form
    {
        private IMercenaryManagement _mercenaryManagement;
        public MercenariesScreen(IMercenaryManagement mercenaryManagement)
        {
            InitializeComponent();
            _mercenaryManagement = mercenaryManagement;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MercenariesScreen_Load(object sender, EventArgs e)
        {
            var mercenaries = _mercenaryManagement.GetAllMercenariesForLoggedUser();

            listMercenaries.Columns.Clear();
            listMercenaries.Columns.Add("Level", 100, HorizontalAlignment.Center);
            listMercenaries.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listMercenaries.Columns.Add("MaxHp", 50, HorizontalAlignment.Center);
            listMercenaries.Columns.Add("Attack", 50, HorizontalAlignment.Center);
            listMercenaries.Columns.Add("Defence", 70, HorizontalAlignment.Center);
            listMercenaries.Columns.Add("Speed", 50, HorizontalAlignment.Center);
            listMercenaries.Items.Clear();
            foreach(var mercenary in mercenaries)
            {
                List<string> row = new List<string>();
                row.Add(mercenary.Level.ToString());
                row.Add(mercenary.Name);
                row.Add(mercenary.MaxHp.ToString());
                row.Add($"{mercenary.getMin_Att().ToString()}-{mercenary.getMax_Att().ToString()}");
                row.Add(mercenary.Def.ToString());
                row.Add(mercenary.Speed.ToString());
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = mercenary;
                listMercenaries.Items.Add(listViewItem);
            }
        }

        private void listMercenaries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listMercenaries.SelectedItems.Count == 1)
            {
                var character = (Character)listMercenaries.SelectedItems[0].Tag;
                if (character.Name == "Rat")
                {
                    merccenaryPicture.Image = Image.FromFile(@"C:\Emil\Projects\HeroGameDataFiles\Pictures\Rat1.jpg");

                }
                else merccenaryPicture.Image = null;
            }
            else merccenaryPicture.Image = null;
        }
    }
}

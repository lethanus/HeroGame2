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
            listMercenaries.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listMercenaries.Columns.Add("MaxHp", 50, HorizontalAlignment.Right);
            listMercenaries.Columns.Add("Attack", 50, HorizontalAlignment.Right);
            listMercenaries.Columns.Add("Defence", 70, HorizontalAlignment.Right);
            listMercenaries.Columns.Add("Speed", 50, HorizontalAlignment.Right);
            listMercenaries.Items.Clear();
            foreach(var mercenary in mercenaries)
            {
                List<string> row = new List<string>();
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
    }
}

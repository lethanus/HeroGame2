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
    public partial class MercenaryTemplatesScreen : Form
    {
        private IMercenaryTemplateRepository _mercenaryTemplateRepository;
        public MercenaryTemplatesScreen(IMercenaryTemplateRepository mercenaryTemplateRepository)
        {
            InitializeComponent();
            _mercenaryTemplateRepository = mercenaryTemplateRepository;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MercenaryTemplatesScreen_Load(object sender, EventArgs e)
        {
            listMercenaryTemplates.Columns.Clear();
            listMercenaryTemplates.Columns.Add("Level", 50, HorizontalAlignment.Right);
            listMercenaryTemplates.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listMercenaryTemplates.Columns.Add("HP_range", 100, HorizontalAlignment.Center);
            listMercenaryTemplates.Columns.Add("Min_Attack_range", 100, HorizontalAlignment.Center);
            listMercenaryTemplates.Columns.Add("Attack_add_for_max", 130, HorizontalAlignment.Center);
            listMercenaryTemplates.Columns.Add("Defence_range", 100, HorizontalAlignment.Center);
            listMercenaryTemplates.Columns.Add("Speed_range", 100, HorizontalAlignment.Center);
            listMercenaryTemplates.Items.Clear();
            foreach (var template in _mercenaryTemplateRepository.GetMercenaryTemplates())
            {
                List<string> row = new List<string>();
                row.Add(template.Level);
                row.Add(template.Name);
                row.Add(template.HP_range);
                row.Add(template.Min_Attack_range);
                row.Add(template.Attack_add_for_max);
                row.Add(template.Defence_range);
                row.Add(template.Speed_range);
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = template;
                listMercenaryTemplates.Items.Add(listViewItem);
            }
        }
    }
}

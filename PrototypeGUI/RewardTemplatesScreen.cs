using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.Quests;

namespace PrototypeGUI
{
    public partial class RewardTemplatesScreen : Form
    {
        private readonly IRewardTemplatesRepository _rewardTemplatesRepository;

        public RewardTemplatesScreen(IRewardTemplatesRepository rewardTemplatesRepository)
        {
            InitializeComponent();
            _rewardTemplatesRepository = rewardTemplatesRepository;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RewardTemplatesScreen_Load(object sender, EventArgs e)
        {
            listRewardTemplates.Columns.Clear();
            listRewardTemplates.Columns.Add("ID", 50, HorizontalAlignment.Center);
            listRewardTemplates.Columns.Add("Level", 50, HorizontalAlignment.Center);
            listRewardTemplates.Columns.Add("Rewards", 100, HorizontalAlignment.Center);
            listRewardTemplates.Items.Clear();
            foreach (var template in _rewardTemplatesRepository.GetAll())
            {
                List<string> row = new List<string>();
                row.Add(template.ID);
                row.Add(template.Level.ToString());
                row.Add(template.Rewards);
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = template;
                listRewardTemplates.Items.Add(listViewItem);
            }
        }
    }
}

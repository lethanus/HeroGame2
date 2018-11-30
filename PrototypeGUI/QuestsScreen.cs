using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.RefresingMechanism;
using HeroesGame.Quests;


namespace PrototypeGUI
{
    public partial class QuestsScreen : Form
    {
        private readonly IRefreshingMechnism _refreshingMechnism;
        private readonly IQuestManagement _questManagement;

        public QuestsScreen(IRefreshingMechnism refreshingMechnism, IQuestManagement questManagement)
        {
            InitializeComponent();
            _refreshingMechnism = refreshingMechnism;
            _questManagement = questManagement;
        }

        private void AdventuresScreen_Load(object sender, EventArgs e)
        {
            RefreshQuests();
            UpdateRefresh();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btBeginQuest_Click(object sender, EventArgs e)
        {

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if (_questManagement.GenerateQuests())
            {
                refreshTimer.Enabled = true;
                btRefresh.Enabled = false;
            }
            RefreshQuests();
        }

        private void RefreshQuests()
        {
            var quests = _questManagement.GetAll();
            listQuests.Columns.Clear();
            listQuests.Columns.Add("Level", 50, HorizontalAlignment.Center);
            listQuests.Columns.Add("Name", 200, HorizontalAlignment.Center);
            listQuests.Columns.Add("Rewards", 200, HorizontalAlignment.Center);
            listQuests.Items.Clear();
            foreach (var quest in quests)
            {
                List<string> row = new List<string>();
                row.Add(quest.Level);
                row.Add(quest.Name);
                row.Add(quest.WinRewards);
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = quest;
                listQuests.Items.Add(listViewItem);
            }

        }

        private void UpdateRefresh()
        {
            var now = DateTime.Now;
            var result = _refreshingMechnism.GetRefreshStatus(RefreshOption.Quests, now);
            btRefresh.Enabled = result.Status == RefresStatus.Ready;
            var lastRefreshTime = _refreshingMechnism.GetLastRefresh(RefreshOption.Quests);
            if (result.Status == RefresStatus.Ready)
            {
                btRefresh.Text = "Refresh";
                refreshTimer.Enabled = false;
            }
            else
            {
                btRefresh.Text = DateTime.MinValue.AddSeconds(result.SecondsLeft).ToLongTimeString();
                refreshTimer.Enabled = true;
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateRefresh();
        }
    }
}

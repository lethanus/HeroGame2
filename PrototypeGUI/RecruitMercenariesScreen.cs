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
using HeroesGame.Mercenaries;

namespace PrototypeGUI
{
    public partial class RecruitMercenariesScreen : Form
    {
        private IRefreshingMechnism _refreshingMechnism;
        private IMercenaryManagement _mercenaryManagement;
        public RecruitMercenariesScreen(IRefreshingMechnism refreshingMechnism, IMercenaryManagement mercenaryManagement)
        {
            InitializeComponent();
            _refreshingMechnism = refreshingMechnism;
            _mercenaryManagement = mercenaryManagement;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RecruitMercenariesScreen_Load(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;
            UpdateRefresh();
        }


        private void UpdateRefresh()
        {
            var status = _refreshingMechnism.GetRefreshStatus("Mercenaries", DateTime.Now);
            btRefresh.Enabled = status == RefresStatus.Enabled;
            var delay = _refreshingMechnism.GetDelayValue("Mercenaries");
            nextRefreshBar.Maximum = delay*4;
            var lastRefreshTime = _refreshingMechnism.GetLastRefresh("Mercenaries");
            if (lastRefreshTime != null)
            {
                var now = DateTime.Now;
                if (lastRefreshTime.LastAction.AddSeconds(delay) > now)
                {
                    nextRefreshBar.Value = (int)(now - lastRefreshTime.LastAction).TotalSeconds*4;
                    refreshTimer.Enabled = true;
                }
                else
                {
                    nextRefreshBar.Value = delay*4;
                    refreshTimer.Enabled = false;
                }
            }
            else
            {
                nextRefreshBar.Value = delay*4;
                refreshTimer.Enabled = false;
            }

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            _refreshingMechnism.AddRefreshFactForLoggedAccount("Mercenaries", DateTime.Now);
            UpdateRefresh();
            refreshTimer.Enabled = true;
            var recruits = _mercenaryManagement.GenerateMercenaries("a");

            listRecruits.Columns.Clear();
            listRecruits.Columns.Add("Level", 50, HorizontalAlignment.Left);
            listRecruits.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listRecruits.Columns.Add("MaxHp", 50, HorizontalAlignment.Right);
            listRecruits.Columns.Add("Attack", 50, HorizontalAlignment.Right);
            listRecruits.Columns.Add("Defence", 70, HorizontalAlignment.Right);
            listRecruits.Columns.Add("Speed", 50, HorizontalAlignment.Right);
            listRecruits.Items.Clear();
            foreach (var recruit in recruits)
            {
                List<string> row = new List<string>();
                row.Add(recruit.Level.ToString());
                row.Add(recruit.Name);
                row.Add(recruit.Hp.ToString());
                row.Add(recruit.Attack.ToString());
                row.Add(recruit.Defence.ToString());
                row.Add(recruit.Speed.ToString());
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = recruit;
                listRecruits.Items.Add(listViewItem);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (nextRefreshBar.Value < nextRefreshBar.Maximum)
                nextRefreshBar.Value++;
            else
            {
                refreshTimer.Enabled = false;
                UpdateRefresh();
            }
        }
    }
}

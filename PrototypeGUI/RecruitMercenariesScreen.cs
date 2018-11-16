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

namespace PrototypeGUI
{
    public partial class RecruitMercenariesScreen : Form
    {
        private IRefreshingMechnism _refreshingMechnism;
        public RecruitMercenariesScreen(IRefreshingMechnism refreshingMechnism)
        {
            InitializeComponent();
            _refreshingMechnism = refreshingMechnism;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RecruitMercenariesScreen_Load(object sender, EventArgs e)
        {
            UpdateRefresh();
        }


        private void UpdateRefresh()
        {
            var status = _refreshingMechnism.GetRefreshStatus("Mercenaries", DateTime.Now);
            btRefresh.Enabled = status == RefresStatus.Enabled;
            var delay = _refreshingMechnism.GetDelayValue("Mercenaries");
            nextRefreshBar.Maximum = delay;
            var lastRefreshTime = _refreshingMechnism.GetLastRefresh("Mercenaries");
            if (lastRefreshTime != null)
            {
                var now = DateTime.Now;
                if (lastRefreshTime.LastAction.AddSeconds(delay) > now)
                {
                    nextRefreshBar.Value = (int)(now - lastRefreshTime.LastAction).TotalSeconds;
                    refreshTimer.Enabled = true;
                }
                else
                {
                    nextRefreshBar.Value = delay;
                    refreshTimer.Enabled = false;
                }
            }
            else
            {
                nextRefreshBar.Value = delay;
                refreshTimer.Enabled = false;
            }

        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            _refreshingMechnism.AddRefreshFactForLoggedAccount("Mercenaries", DateTime.Now);
            UpdateRefresh();
            refreshTimer.Enabled = true;
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

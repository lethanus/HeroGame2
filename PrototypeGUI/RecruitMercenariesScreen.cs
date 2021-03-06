﻿using System;
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
using HeroesGame.Inventory;

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
            UpdateRefresh();
            RefreshRecruits();
            UpdateGifts();
        }

        private void UpdateGifts()
        {
            var currentGifts = _mercenaryManagement.GetCurrentGifts();
            listGifts.Columns.Clear();
            listGifts.Columns.Add("Name", 100, HorizontalAlignment.Center);
            listGifts.Columns.Add("Amount", 50, HorizontalAlignment.Center);
            listGifts.Items.Clear();
            foreach (var gift in currentGifts)
            {
                List<string> row = new List<string>();
                row.Add(gift.Name);
                row.Add(gift.Amount.ToString());
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = gift;
                listGifts.Items.Add(listViewItem);
            }
            btRemoveGift.Enabled = listGifts.SelectedItems.Count == 1;
            UpdateConvinceChance();
        }

        private void RefreshRecruits()
        {
            var recruits = _mercenaryManagement.GetRecruits();

            listRecruits.Columns.Clear();
            listRecruits.Columns.Add("Level", 50, HorizontalAlignment.Left);
            listRecruits.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listRecruits.Columns.Add("MaxHp", 50, HorizontalAlignment.Right);
            listRecruits.Columns.Add("Attack", 50, HorizontalAlignment.Right);
            listRecruits.Columns.Add("Defence", 70, HorizontalAlignment.Right);
            listRecruits.Columns.Add("Speed", 50, HorizontalAlignment.Right);
            listRecruits.Columns.Add("Skills", 100, HorizontalAlignment.Right);
            listRecruits.Items.Clear();
            foreach (var recruit in recruits)
            {
                List<string> row = new List<string>();
                row.Add(recruit.Level.ToString());
                row.Add(recruit.Name);
                row.Add(recruit.Hp.ToString());
                row.Add($"{recruit.Attack_Min.ToString()}-{recruit.Attack_Max.ToString()}");
                row.Add(recruit.Defence.ToString());
                row.Add(recruit.Speed.ToString());
                row.Add(recruit.Skills);
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = recruit;
                listRecruits.Items.Add(listViewItem);
            }

        }

        private void UpdateRefresh()
        {
            var now = DateTime.Now;
            var result = _refreshingMechnism.GetRefreshStatus(RefreshOption.Mercenaries, now);
            btRefresh.Enabled = result.Status == RefresStatus.Ready;
            var lastRefreshTime = _refreshingMechnism.GetLastRefresh(RefreshOption.Mercenaries);
            if(result.Status == RefresStatus.Ready)
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

        private void btRefresh_Click(object sender, EventArgs e)
        {
            if(_mercenaryManagement.GenerateMercenaries())
            {
                refreshTimer.Enabled = true;
                btRefresh.Enabled = false;
            }
            RefreshRecruits();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateRefresh();
        }

        private void btConvince_Click(object sender, EventArgs e)
        {
            if(listRecruits.SelectedItems.Count == 1)
            {
                var recruit = (Mercenary)listRecruits.SelectedItems[0].Tag;
                var result = _mercenaryManagement.ConvinceRecruit(recruit);
                ConvinceResultBox.Text = result ? "Good job" : "Nah... Failed";
                RefreshRecruits();
                UpdateGifts();
            }
        }

        private void listRecruits_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateConvinceChance();
        }

        private void UpdateConvinceChance()
        {
            if (listRecruits.SelectedItems.Count == 1)
            {
                var recruit = (Mercenary)listRecruits.SelectedItems[0].Tag;
                var chance = _mercenaryManagement.GetConvinceChance(recruit.Level);
                if (chance > 100) chance = 100;
                convinceChanceBox.Text = $"{chance}%";
            }
            else convinceChanceBox.Text = "";
        }

        private void btAddGift_Click(object sender, EventArgs e)
        {
            AddingGiftsScreen addingGiftsScreen = new AddingGiftsScreen(_mercenaryManagement);
            if(addingGiftsScreen.ShowDialog() == DialogResult.OK)
            {
                var selectedGift = addingGiftsScreen.SelectedGift;
                var amount = addingGiftsScreen.Amount;
                _mercenaryManagement.AddGifts(selectedGift.Name, amount);
                UpdateGifts();
            }
        }

        private void btRemoveGift_Click(object sender, EventArgs e)
        {
            if (listGifts.SelectedItems.Count == 1)
            {
                var gift = (PositionInInventory)listGifts.SelectedItems[0].Tag;
                RemovingGiftScreen removingGiftScreen = new RemovingGiftScreen(gift);
                if (removingGiftScreen.ShowDialog() == DialogResult.OK)
                {
                    var amount = removingGiftScreen.Amount;
                    _mercenaryManagement.RemoveGifts(gift.Name, amount);
                    UpdateGifts();
                }
            }
        }

        private void listGifts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btRemoveGift.Enabled = listGifts.SelectedItems.Count == 1;
        }
    }
}

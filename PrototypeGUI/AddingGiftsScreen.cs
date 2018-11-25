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
using HeroesGame.Inventory;

namespace PrototypeGUI
{
    public partial class AddingGiftsScreen : Form
    {
        private readonly IMercenaryManagement _mercenaryManagement;
        public PositionInInventory SelectedGift { get; private set; }
        public int Amount { get; private set; }

        public AddingGiftsScreen(IMercenaryManagement mercenaryManagement)
        {
            InitializeComponent();
            _mercenaryManagement = mercenaryManagement;
            SelectedGift = null;
        }

        private void AddingGiftsScreen_Load(object sender, EventArgs e)
        {
            RefreshGifts();
        }

        private void RefreshGifts()
        {
            var availableGifts = _mercenaryManagement.GetAvailableGiftItems();
            listGifts.Columns.Clear();
            listGifts.Columns.Add("Name", 100, HorizontalAlignment.Center);
            listGifts.Columns.Add("Amount", 50, HorizontalAlignment.Center);
            listGifts.Items.Clear();
            foreach (var gift in availableGifts)
            {
                List<string> row = new List<string>();
                row.Add(gift.Name);
                row.Add(gift.Amount.ToString());
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = gift;
                listGifts.Items.Add(listViewItem);
            }
            btConfirm.Enabled = availableGifts.Count > 0;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (SelectedGift != null)
            {
                Amount = (int) amountBox.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void listGifts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGifts.SelectedItems.Count == 1)
            {
                SelectedGift = (PositionInInventory)listGifts.SelectedItems[0].Tag;
                amountBox.Minimum = 1;
                amountBox.Maximum = SelectedGift.Amount;
                amountBox.Value = 1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.Inventory;

namespace PrototypeGUI
{
    public partial class RemovingGiftScreen : Form
    {
        private readonly PositionInInventory _positionInInventory;

        public int Amount { get; private set; }

        public RemovingGiftScreen(PositionInInventory positionInInventory)
        {
            InitializeComponent();
            _positionInInventory = positionInInventory;
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            Amount = (int)amountBox.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RemovingGiftScreen_Load(object sender, EventArgs e)
        {
            itemNameBox.Text = _positionInInventory.Name;
            amountBox.Minimum = 1;
            amountBox.Maximum = _positionInInventory.Amount;
            amountBox.Value = 1;
        }
    }
}

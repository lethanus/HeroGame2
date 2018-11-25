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
    public partial class InventoryScreen : Form
    {
        private readonly IInventoryManagement _inventoryManagement;

        public InventoryScreen(IInventoryManagement inventoryManagement)
        {
            InitializeComponent();
            _inventoryManagement = inventoryManagement;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InventoryScreen_Load(object sender, EventArgs e)
        {
            var items = _inventoryManagement.GetAll();

            listItems.Columns.Clear();
            listItems.Columns.Add("ID", 100, HorizontalAlignment.Center);
            listItems.Columns.Add("Name", 100, HorizontalAlignment.Center);
            listItems.Columns.Add("Category", 100, HorizontalAlignment.Center);
            listItems.Columns.Add("Amount", 100, HorizontalAlignment.Center);
            listItems.Columns.Add("Effects", 200, HorizontalAlignment.Center);
            listItems.Items.Clear();
            foreach (var item in items)
            {
                List<string> row = new List<string>();
                row.Add(item.ID);
                row.Add(item.Name);
                row.Add(item.Category.ToString());
                row.Add(item.Amount.ToString());
                row.Add(item.Effects);
                var listViewItem = new ListViewItem(row.ToArray());
                listItems.Tag = item;
                listItems.Items.Add(listViewItem);
            }
        }
    }
}

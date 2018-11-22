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
    public partial class ItemDictionaryScreen : Form
    {
        private readonly IItemTemplateRepository _itemTemplateRepository;

        public ItemDictionaryScreen(IItemTemplateRepository itemTemplateRepository)
        {
            InitializeComponent();
            _itemTemplateRepository = itemTemplateRepository;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ItemDictionaryScreen_Load(object sender, EventArgs e)
        {
            var itemTemplates = _itemTemplateRepository.GetAllTemplates();

            listItems.Columns.Clear();
            listItems.Columns.Add("ID", 100, HorizontalAlignment.Center);
            listItems.Columns.Add("Name", 100, HorizontalAlignment.Center);
            listItems.Columns.Add("Category", 100, HorizontalAlignment.Center);
            listItems.Items.Clear();
            foreach (var template in itemTemplates)
            {
                List<string> row = new List<string>();
                row.Add(template.ID);
                row.Add(template.Name);
                row.Add(template.Category);
                var listViewItem = new ListViewItem(row.ToArray());

                listItems.Items.Add(listViewItem);
            }
        }
    }
}

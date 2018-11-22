using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.Configuration;

namespace PrototypeGUI
{
    public partial class ConfigurationSettingsScreen : Form
    {
        private readonly IConfigRepository _configRepository;

        public ConfigurationSettingsScreen(IConfigRepository configRepository)
        {
            InitializeComponent();
            _configRepository = configRepository;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigurationSettingsScreen_Load(object sender, EventArgs e)
        {
            listConfigurationSettings.Columns.Clear();
            listConfigurationSettings.Columns.Add("Parameter name", 200, HorizontalAlignment.Center);
            listConfigurationSettings.Columns.Add("Parameter value", 200, HorizontalAlignment.Center);
            listConfigurationSettings.Items.Clear();
            foreach (var parameter in _configRepository.GetAll())
            {
                List<string> row = new List<string>();
                row.Add(parameter.Name);
                row.Add(parameter.Value);

                var listViewItem = new ListViewItem(row.ToArray());
                listConfigurationSettings.Items.Add(listViewItem);
            }
        }
    }
}

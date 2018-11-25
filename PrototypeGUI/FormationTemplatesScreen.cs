using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.PackBuilding;


namespace PrototypeGUI
{
    public partial class FormationTemplatesScreen : Form
    {
        private readonly IFormationTemplateRepository _formationTemplateRepository;

        public FormationTemplatesScreen(IFormationTemplateRepository formationTemplateRepository)
        {
            InitializeComponent();
            _formationTemplateRepository = formationTemplateRepository;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormationTemplatesScreen_Load(object sender, EventArgs e)
        {
            listFormationTemplates.Columns.Clear();
            listFormationTemplates.Columns.Add("Level", 50, HorizontalAlignment.Right);
            listFormationTemplates.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listFormationTemplates.Columns.Add("F1", 100, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("F2", 100, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("F3", 130, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("M1", 100, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("M2", 100, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("M3", 100, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("M4", 100, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("R1", 100, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("R2", 100, HorizontalAlignment.Center);
            listFormationTemplates.Columns.Add("R3", 100, HorizontalAlignment.Center);
            listFormationTemplates.Items.Clear();
            foreach (var template in _formationTemplateRepository.GetAll())
            {
                List<string> row = new List<string>();
                row.Add(template.Level.ToString());
                row.Add(template.Name);
                row.Add(template.F1);
                row.Add(template.F2);
                row.Add(template.F3);
                row.Add(template.M1);
                row.Add(template.M2);
                row.Add(template.M3);
                row.Add(template.M4);
                row.Add(template.R1);
                row.Add(template.R2);
                row.Add(template.R3);
                var listViewItem = new ListViewItem(row.ToArray());
                listViewItem.Tag = template;
                listFormationTemplates.Items.Add(listViewItem);
            }
        }
    }
}

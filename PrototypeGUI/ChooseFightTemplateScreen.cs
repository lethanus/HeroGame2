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
    public partial class ChooseFightTemplateScreen : Form
    {
        private IFormationTemplateRepository _formationTemplateRepository;
        public FormationTemplate SelectedTemplate { get; private set; }

        public ChooseFightTemplateScreen(IFormationTemplateRepository formationTemplateRepository)
        {
            InitializeComponent();
            _formationTemplateRepository = formationTemplateRepository;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChooseFightTemplateScreen_Load(object sender, EventArgs e)
        {
            var templates = _formationTemplateRepository.GetAll();

            fightsTemplatesCombo.Items.AddRange(templates.ToArray());
            fightsTemplatesCombo.SelectedIndex = 0;

        }

        private void fightsTemplatesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(fightsTemplatesCombo.SelectedItem != null)
                SelectedTemplate = (FormationTemplate) fightsTemplatesCombo.SelectedItem;
        }
    }
}

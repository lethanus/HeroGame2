using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroesGame.Accounts;
using HeroesGame.Configuration;
using HeroesGame.RefresingMechanism;
using HeroesGame.Mercenaries;
using HeroesGame.Repositories;
using HeroesGame.Core.Randomizers;

namespace PrototypeGUI
{
    public partial class btCampain : Form
    {
        private IAccountRepository _accountRepository;
        private IConfigRepository _configRepository;
        private IRefreshRepository _refreshRepository;
        private IRefreshingMechnism _refreshingMechnism;
        private IAccountManagement _accountManagement;
        private IMercenaryRepository _mercenaryRepository;
        private IMercenaryTemplateRepository _mercenaryTemplateRepository;
        private IMercenaryManagement _mercenaryManagement;

        public btCampain()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            if(loginScreen.ShowDialog() == DialogResult.OK)
            {
                var loggedAccount = _accountManagement.Login(loginScreen.Login, loginScreen.Password);
                if (loggedAccount != null)
                    accountDetailsBox.Text = loggedAccount.ToString();
                else
                    accountDetailsBox.Text = "Login failed";
            }
            UpdateGameControls(_accountManagement.GetLoggedAccount());
        }

        private void btHeroes_Click(object sender, EventArgs e)
        {
            HeroesScreen heroesScreen = new HeroesScreen();
            heroesScreen.ShowDialog();
        }

        private void btMercenaries_Click(object sender, EventArgs e)
        {
            MercenariesScreen mercenariesScreen = new MercenariesScreen(_mercenaryManagement);
            mercenariesScreen.ShowDialog();
        }

        private void btInventory_Click(object sender, EventArgs e)
        {
            InventoryScreen inventoryScreen = new InventoryScreen();
            inventoryScreen.ShowDialog();
        }

        private void btRecruitMercenaries_Click(object sender, EventArgs e)
        {
            RecruitMercenariesScreen recruitMercenariesScreen = new RecruitMercenariesScreen(_refreshingMechnism);
            recruitMercenariesScreen.ShowDialog();
        }

        private void btCampain_Load(object sender, EventArgs e)
        {
            _accountRepository = new AccountJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\Accounts.json");
            var accounts = _accountRepository.GetAccounts();
            if(accounts.Count == 0)
            {
                _accountRepository.AddAccount(new Account("testAccount", "testPassword"));
                _accountRepository.AddAccount(new Account("testAccount1", "testPassword"));
                _accountRepository.AddAccount(new Account("testAccount2", "testPassword"));
            }
            _accountManagement = new AccountManagement(_accountRepository);
            
            _configRepository = new ConfigJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\Configuration.json");
            var delay = _configRepository.GetParameterValue("Delay_for_option_Mercenaries_in_sec");
            if (delay == "") _configRepository.SetConfigParameter("Delay_for_option_Mercenaries_in_sec", "20");
            _refreshRepository = new RefreshJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\");
            
            _refreshingMechnism = new RefreshingMechnism(_refreshRepository, _configRepository, _accountManagement);
            _mercenaryTemplateRepository = new MercenaryTemplateJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\MercenaryTemplates.json");
            _mercenaryRepository = new MercenaryJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\");
            _mercenaryManagement = new MercenaryManagement(_mercenaryRepository, _accountManagement, _mercenaryTemplateRepository, new ValueRandomizer(), _configRepository);
            if(_mercenaryTemplateRepository.GetMercenaryTemplates().Count == 0)
            {
                foreach (var template in MercenaryTemplatesCollectionGenerator.Generate())
                {
                    _mercenaryTemplateRepository.AddMercenaryTemplate(template);
                }
            }

            UpdateGameControls(_accountManagement.GetLoggedAccount());
        }

        private void UpdateGameControls(Account account)
        {
            foreach (Control control in gamePanel.Controls)
            {
                control.Enabled = account != null;
            }
        }
    }
}

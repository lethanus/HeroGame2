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
using HeroesGame.PackBuilding;
using HeroesGame.Core.Randomizers;
using HeroesGame.Inventory;
using HeroesGame.FightMechanizm;
using HeroesGame.Loggers;
using HeroesGame.Quests;

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
        private IRecruitsRepository _recruitsRepository;
        private IPackFormationBuilder _packFormationBuilder;
        private IPackFormationRepository _packFormationRepository;
        private IInventoryManagement _inventoryManagement;
        private IPositionInInventoryRepository _positionInInventoryRepository;
        private IItemTemplateRepository _itemTemplateRepository;
        private IFormationTemplateRepository _formationTemplateRepository;
        private IOpponentPackFormationBuilder _opponentPackFormationBuilder;
        private IFightMechanizm _fightMechanizm;
        private IFightManagement _fightManagement;
        private IValueRandomizer _valueRandomizer;
        private IQuestManagement _questManagement;
        private Logger _logger;

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
            InventoryScreen inventoryScreen = new InventoryScreen(_inventoryManagement);
            inventoryScreen.ShowDialog();
        }

        private void btRecruitMercenaries_Click(object sender, EventArgs e)
        {
            RecruitMercenariesScreen recruitMercenariesScreen = new RecruitMercenariesScreen(_refreshingMechnism, _mercenaryManagement);
            recruitMercenariesScreen.ShowDialog();
        }

        private void btCampain_Load(object sender, EventArgs e)
        {
            _accountRepository = new AccountJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\Accounts.json");
            var accounts = _accountRepository.GetAll();
            if(accounts.Count == 0)
            {
                _accountRepository.Add(new Account("testAccount", "testPassword"));
                _accountRepository.Add(new Account("testAccount1", "testPassword"));
                _accountRepository.Add(new Account("testAccount2", "testPassword"));
            }
            _accountManagement = new AccountManagement(_accountRepository);
            
            _configRepository = new ConfigJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\Configuration.json");
            EnsureConfigValue("Delay_for_option_Mercenaries_in_sec", "20");
            EnsureConfigValue("Delay_for_option_Quests_in_sec", "20");
            EnsureConfigValue("NumberOfRecruits", "10");
            EnsureConfigValue("ChanceForLevel_1_mercenary", "10000_10000");
            EnsureConfigValue("ChanceForLevel_2_mercenary", "2500_10000");
            EnsureConfigValue("ChanceForLevel_3_mercenary", "500_10000");
            EnsureConfigValue("ChanceForLevel_4_mercenary", "50_10000");

            EnsureConfigValue("ConvinceLevel_1_recruit", "7500_10000");
            EnsureConfigValue("ConvinceLevel_2_recruit", "5000_10000");
            EnsureConfigValue("ConvinceLevel_3_recruit", "2000_10000");
            EnsureConfigValue("ConvinceLevel_4_recruit", "1000_10000");
            EnsureConfigValue("NumberOfQuests", "5");

            EnsureConfigValue("ChanceForLevel_1_quest", "7500_10000");
            EnsureConfigValue("ChanceForLevel_2_quest", "5000_10000");
            EnsureConfigValue("ChanceForLevel_3_quest", "2000_10000");
            EnsureConfigValue("ChanceForLevel_4_quest", "1000_10000");

            _packFormationRepository = new PackFormationJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\");
            _packFormationBuilder = new PackFormationBuilder(_packFormationRepository, _accountManagement);


            _refreshRepository = new RefreshJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\");
            _recruitsRepository = new RecruitsJsonRepository(@"C:\Emil\Projects\HeroGameDataFiles\");
            _refreshingMechnism = new RefreshingMechnism(_refreshRepository, _configRepository, _accountManagement);
            _mercenaryTemplateRepository = new MercenaryTemplateJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\MercenaryTemplates.json");
            _mercenaryRepository = new MercenaryJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\");
            if(_mercenaryTemplateRepository.GetAll().Count == 0)
            {
                foreach (var template in MercenaryTemplatesCollectionGenerator.Generate())
                {
                    _mercenaryTemplateRepository.Add(template);
                }
            }

            
            _positionInInventoryRepository = new PositionInInventoryJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\");
            _itemTemplateRepository = new ItemTemplateJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\ItemTemplates.json");
            _inventoryManagement = new InventoryManagement(_itemTemplateRepository, _positionInInventoryRepository, _accountManagement);
            if (_itemTemplateRepository.GetAll().Count == 0)
            {
                foreach (var template in ItemTemplatesCollectionGenerator.Generate())
                {
                    _itemTemplateRepository.Add(template);
                }

            }
            _mercenaryManagement = new MercenaryManagement(_mercenaryRepository, _accountManagement, _mercenaryTemplateRepository, new ValueRandomizer(), _configRepository, _recruitsRepository, _inventoryManagement, _refreshingMechnism);
            _formationTemplateRepository = new FormationTemplateJsonFileRepository(@"C:\Emil\Projects\HeroGameDataFiles\FormationTemplates.json");
            _opponentPackFormationBuilder = new OpponentPackFormationBuilder(_formationTemplateRepository, _mercenaryManagement);
            if (_formationTemplateRepository.GetAll().Count == 0)
            {
                foreach (var template in FormationTemplatesCollectionGenerator.Generate())
                {
                    _formationTemplateRepository.Add(template);
                }
            }
            _valueRandomizer = new ValueRandomizer();
            _logger = new FakeLogger();
            _questManagement = new QuestManagement(_configRepository, _refreshingMechnism, _valueRandomizer, _formationTemplateRepository);

            UpdateGameControls(_accountManagement.GetLoggedAccount());
        }

        private void EnsureConfigValue(string parameterName, string parameterValue)
        {
            var value = _configRepository.GetParameterValue(parameterName);
            if (value == "") _configRepository.SetConfigParameter(parameterName, parameterValue);

        }

        private void UpdateGameControls(Account account)
        {
            foreach (Control control in gamePanel.Controls)
            {
                control.Enabled = account != null;
            }
        }

        private void btMercenaryTemplates_Click(object sender, EventArgs e)
        {
            MercenaryTemplatesScreen mercenaryTemplatesScreen = new MercenaryTemplatesScreen(_mercenaryTemplateRepository);
            mercenaryTemplatesScreen.ShowDialog();
        }

        private void btConfigSettings_Click(object sender, EventArgs e)
        {
            ConfigurationSettingsScreen configurationSettingsScreen = new ConfigurationSettingsScreen(_configRepository);
            configurationSettingsScreen.ShowDialog();
        }

        private void btPackFormation_Click(object sender, EventArgs e)
        {
            PackFormationScreen packFormationScreen = new PackFormationScreen(_mercenaryManagement, _packFormationBuilder);
            packFormationScreen.ShowDialog();
        }

        private void btItemDictionary_Click(object sender, EventArgs e)
        {
            ItemDictionaryScreen itemDictionaryScreen = new ItemDictionaryScreen(_itemTemplateRepository);
            itemDictionaryScreen.ShowDialog();
        }

        private void btFillInventory_Click(object sender, EventArgs e)
        {
            var items = _itemTemplateRepository.GetAll();
            foreach(var item in items)
            {
                _inventoryManagement.AddItems(item.ID, 10);
            }
            MessageBox.Show("10 of each added!");
        }

        private void btOpponentFormations_Click(object sender, EventArgs e)
        {
            FormationTemplatesScreen formationTemplatesScreen = new FormationTemplatesScreen(_formationTemplateRepository);
            formationTemplatesScreen.ShowDialog();
        }

        private void btQuests_Click(object sender, EventArgs e)
        {
            QuestsScreen questsScreen = new QuestsScreen(_refreshingMechnism, _questManagement);
            questsScreen.ShowDialog();
        }

        private void btFightVsTemplate_Click(object sender, EventArgs e)
        {
            _fightMechanizm = new FightMechanizm(_valueRandomizer, _logger);

            _fightManagement = new FightManagement(_opponentPackFormationBuilder, _fightMechanizm, _packFormationBuilder, _mercenaryManagement);


            ChooseFightTemplateScreen chooseFightTemplateScreen = new ChooseFightTemplateScreen(_formationTemplateRepository);
            if(chooseFightTemplateScreen.ShowDialog() == DialogResult.OK)
            {
                var selectedTemplate = chooseFightTemplateScreen.SelectedTemplate;
                _fightManagement.PrepareFightAgainstTemplate(selectedTemplate.ID);

                FightScreen fightScreen = new FightScreen(_fightManagement, _fightMechanizm);
                if (fightScreen.ShowDialog() == DialogResult.OK)
                {


                    var result = _fightManagement.GetLastFightResult();
                    MessageBox.Show(result.ToString());
                }
            }
        }
    }

    public class FakeLogger : Logger
    {
        public void LogLine(string line)
        {

        }
    }
}

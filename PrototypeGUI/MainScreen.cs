using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeroGame.Accounts;

namespace PrototypeGUI
{
    public partial class btCampain : Form
    {
        private AccountJsonFileRepository _accountRepository;
        private Account _loggedAccount = null;

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
                AccountManagement accountManagement = new AccountManagement(_accountRepository);
                _loggedAccount = accountManagement.Login(loginScreen.Login, loginScreen.Password);
                if (_loggedAccount != null)
                    accountDetailsBox.Text = _loggedAccount.ToString();
                else
                    accountDetailsBox.Text = "Login failed";
            }
            UpdateGameControls(_loggedAccount);
        }

        private void btHeroes_Click(object sender, EventArgs e)
        {
            HeroesScreen heroesScreen = new HeroesScreen();
            heroesScreen.ShowDialog();
        }

        private void btMercenaries_Click(object sender, EventArgs e)
        {
            MercenariesScreen mercenariesScreen = new MercenariesScreen();
            mercenariesScreen.ShowDialog();
        }

        private void btInventory_Click(object sender, EventArgs e)
        {
            InventoryScreen inventoryScreen = new InventoryScreen();
            inventoryScreen.ShowDialog();
        }

        private void btRecruitMercenaries_Click(object sender, EventArgs e)
        {
            RecruitMercenariesScreen recruitMercenariesScreen = new RecruitMercenariesScreen();
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
            UpdateGameControls(_loggedAccount);
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

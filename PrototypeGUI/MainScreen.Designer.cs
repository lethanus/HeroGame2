namespace PrototypeGUI
{
    partial class btCampain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btLogin = new System.Windows.Forms.Button();
            this.accountDetailsBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.GroupBox();
            this.btFightVsTemplate = new System.Windows.Forms.Button();
            this.btFillInventory = new System.Windows.Forms.Button();
            this.btPackFormation = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btAdventures = new System.Windows.Forms.Button();
            this.btInventory = new System.Windows.Forms.Button();
            this.btArena = new System.Windows.Forms.Button();
            this.btHeroes = new System.Windows.Forms.Button();
            this.btRecruitMercenaries = new System.Windows.Forms.Button();
            this.btMercenaries = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btMercenaryTemplates = new System.Windows.Forms.Button();
            this.btConfigSettings = new System.Windows.Forms.Button();
            this.btItemDictionary = new System.Windows.Forms.Button();
            this.btOpponentFormations = new System.Windows.Forms.Button();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(321, 198);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(75, 23);
            this.btLogin.TabIndex = 0;
            this.btLogin.Text = "Login";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // accountDetailsBox
            // 
            this.accountDetailsBox.Location = new System.Drawing.Point(16, 29);
            this.accountDetailsBox.Name = "accountDetailsBox";
            this.accountDetailsBox.Size = new System.Drawing.Size(380, 163);
            this.accountDetailsBox.TabIndex = 1;
            this.accountDetailsBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account details";
            // 
            // gamePanel
            // 
            this.gamePanel.Controls.Add(this.btFightVsTemplate);
            this.gamePanel.Controls.Add(this.btFillInventory);
            this.gamePanel.Controls.Add(this.btPackFormation);
            this.gamePanel.Controls.Add(this.button1);
            this.gamePanel.Controls.Add(this.btAdventures);
            this.gamePanel.Controls.Add(this.btInventory);
            this.gamePanel.Controls.Add(this.btArena);
            this.gamePanel.Controls.Add(this.btHeroes);
            this.gamePanel.Controls.Add(this.btRecruitMercenaries);
            this.gamePanel.Controls.Add(this.btMercenaries);
            this.gamePanel.Location = new System.Drawing.Point(402, 29);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(386, 409);
            this.gamePanel.TabIndex = 3;
            this.gamePanel.TabStop = false;
            this.gamePanel.Text = "Game panel";
            // 
            // btFightVsTemplate
            // 
            this.btFightVsTemplate.Location = new System.Drawing.Point(25, 146);
            this.btFightVsTemplate.Name = "btFightVsTemplate";
            this.btFightVsTemplate.Size = new System.Drawing.Size(124, 23);
            this.btFightVsTemplate.TabIndex = 9;
            this.btFightVsTemplate.Text = "Fight vs template";
            this.btFightVsTemplate.UseVisualStyleBackColor = true;
            this.btFightVsTemplate.Click += new System.EventHandler(this.btFightVsTemplate_Click);
            // 
            // btFillInventory
            // 
            this.btFillInventory.Location = new System.Drawing.Point(228, 59);
            this.btFillInventory.Name = "btFillInventory";
            this.btFillInventory.Size = new System.Drawing.Size(124, 23);
            this.btFillInventory.TabIndex = 8;
            this.btFillInventory.Text = "Add 10 of all";
            this.btFillInventory.UseVisualStyleBackColor = true;
            this.btFillInventory.Click += new System.EventHandler(this.btFillInventory_Click);
            // 
            // btPackFormation
            // 
            this.btPackFormation.Location = new System.Drawing.Point(25, 117);
            this.btPackFormation.Name = "btPackFormation";
            this.btPackFormation.Size = new System.Drawing.Size(124, 23);
            this.btPackFormation.TabIndex = 7;
            this.btPackFormation.Text = "Pack formation";
            this.btPackFormation.UseVisualStyleBackColor = true;
            this.btPackFormation.Click += new System.EventHandler(this.btPackFormation_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Campain";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btAdventures
            // 
            this.btAdventures.Location = new System.Drawing.Point(25, 59);
            this.btAdventures.Name = "btAdventures";
            this.btAdventures.Size = new System.Drawing.Size(124, 23);
            this.btAdventures.TabIndex = 5;
            this.btAdventures.Text = "Quests";
            this.btAdventures.UseVisualStyleBackColor = true;
            this.btAdventures.Click += new System.EventHandler(this.btQuests_Click);
            // 
            // btInventory
            // 
            this.btInventory.Location = new System.Drawing.Point(228, 30);
            this.btInventory.Name = "btInventory";
            this.btInventory.Size = new System.Drawing.Size(124, 23);
            this.btInventory.TabIndex = 4;
            this.btInventory.Text = "Inventory";
            this.btInventory.UseVisualStyleBackColor = true;
            this.btInventory.Click += new System.EventHandler(this.btInventory_Click);
            // 
            // btArena
            // 
            this.btArena.Location = new System.Drawing.Point(228, 175);
            this.btArena.Name = "btArena";
            this.btArena.Size = new System.Drawing.Size(124, 23);
            this.btArena.TabIndex = 3;
            this.btArena.Text = "Arena";
            this.btArena.UseVisualStyleBackColor = true;
            // 
            // btHeroes
            // 
            this.btHeroes.Location = new System.Drawing.Point(228, 204);
            this.btHeroes.Name = "btHeroes";
            this.btHeroes.Size = new System.Drawing.Size(124, 23);
            this.btHeroes.TabIndex = 2;
            this.btHeroes.Text = "Heroes";
            this.btHeroes.UseVisualStyleBackColor = true;
            this.btHeroes.Click += new System.EventHandler(this.btHeroes_Click);
            // 
            // btRecruitMercenaries
            // 
            this.btRecruitMercenaries.Location = new System.Drawing.Point(228, 117);
            this.btRecruitMercenaries.Name = "btRecruitMercenaries";
            this.btRecruitMercenaries.Size = new System.Drawing.Size(124, 23);
            this.btRecruitMercenaries.TabIndex = 1;
            this.btRecruitMercenaries.Text = "Recruit Mercenaries";
            this.btRecruitMercenaries.UseVisualStyleBackColor = true;
            this.btRecruitMercenaries.Click += new System.EventHandler(this.btRecruitMercenaries_Click);
            // 
            // btMercenaries
            // 
            this.btMercenaries.Location = new System.Drawing.Point(228, 146);
            this.btMercenaries.Name = "btMercenaries";
            this.btMercenaries.Size = new System.Drawing.Size(124, 23);
            this.btMercenaries.TabIndex = 0;
            this.btMercenaries.Text = "Mercenaries";
            this.btMercenaries.UseVisualStyleBackColor = true;
            this.btMercenaries.Click += new System.EventHandler(this.btMercenaries_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(321, 415);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Exit";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btMercenaryTemplates
            // 
            this.btMercenaryTemplates.Location = new System.Drawing.Point(16, 415);
            this.btMercenaryTemplates.Name = "btMercenaryTemplates";
            this.btMercenaryTemplates.Size = new System.Drawing.Size(135, 23);
            this.btMercenaryTemplates.TabIndex = 5;
            this.btMercenaryTemplates.Text = "Mercenary templates";
            this.btMercenaryTemplates.UseVisualStyleBackColor = true;
            this.btMercenaryTemplates.Click += new System.EventHandler(this.btMercenaryTemplates_Click);
            // 
            // btConfigSettings
            // 
            this.btConfigSettings.Location = new System.Drawing.Point(18, 386);
            this.btConfigSettings.Name = "btConfigSettings";
            this.btConfigSettings.Size = new System.Drawing.Size(133, 23);
            this.btConfigSettings.TabIndex = 6;
            this.btConfigSettings.Text = "Configuration settings";
            this.btConfigSettings.UseVisualStyleBackColor = true;
            this.btConfigSettings.Click += new System.EventHandler(this.btConfigSettings_Click);
            // 
            // btItemDictionary
            // 
            this.btItemDictionary.Location = new System.Drawing.Point(18, 357);
            this.btItemDictionary.Name = "btItemDictionary";
            this.btItemDictionary.Size = new System.Drawing.Size(133, 23);
            this.btItemDictionary.TabIndex = 7;
            this.btItemDictionary.Text = "Item dictionary";
            this.btItemDictionary.UseVisualStyleBackColor = true;
            this.btItemDictionary.Click += new System.EventHandler(this.btItemDictionary_Click);
            // 
            // btOpponentFormations
            // 
            this.btOpponentFormations.Location = new System.Drawing.Point(18, 328);
            this.btOpponentFormations.Name = "btOpponentFormations";
            this.btOpponentFormations.Size = new System.Drawing.Size(133, 23);
            this.btOpponentFormations.TabIndex = 8;
            this.btOpponentFormations.Text = "Opponent formations";
            this.btOpponentFormations.UseVisualStyleBackColor = true;
            this.btOpponentFormations.Click += new System.EventHandler(this.btOpponentFormations_Click);
            // 
            // btCampain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btOpponentFormations);
            this.Controls.Add(this.btItemDictionary);
            this.Controls.Add(this.btConfigSettings);
            this.Controls.Add(this.btMercenaryTemplates);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accountDetailsBox);
            this.Controls.Add(this.btLogin);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "btCampain";
            this.Text = "Game Main Screen";
            this.Load += new System.EventHandler(this.btCampain_Load);
            this.gamePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.RichTextBox accountDetailsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gamePanel;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btRecruitMercenaries;
        private System.Windows.Forms.Button btMercenaries;
        private System.Windows.Forms.Button btArena;
        private System.Windows.Forms.Button btHeroes;
        private System.Windows.Forms.Button btInventory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btAdventures;
        private System.Windows.Forms.Button btMercenaryTemplates;
        private System.Windows.Forms.Button btConfigSettings;
        private System.Windows.Forms.Button btPackFormation;
        private System.Windows.Forms.Button btItemDictionary;
        private System.Windows.Forms.Button btFillInventory;
        private System.Windows.Forms.Button btOpponentFormations;
        private System.Windows.Forms.Button btFightVsTemplate;
    }
}


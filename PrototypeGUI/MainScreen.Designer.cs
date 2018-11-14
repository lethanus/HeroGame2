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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btMercenaries = new System.Windows.Forms.Button();
            this.btRecruitMercenaries = new System.Windows.Forms.Button();
            this.btHeroes = new System.Windows.Forms.Button();
            this.btArena = new System.Windows.Forms.Button();
            this.btInventory = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btAdventures = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btAdventures);
            this.groupBox1.Controls.Add(this.btInventory);
            this.groupBox1.Controls.Add(this.btArena);
            this.groupBox1.Controls.Add(this.btHeroes);
            this.groupBox1.Controls.Add(this.btRecruitMercenaries);
            this.groupBox1.Controls.Add(this.btMercenaries);
            this.groupBox1.Location = new System.Drawing.Point(402, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 409);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game panel";
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
            // btMercenaries
            // 
            this.btMercenaries.Location = new System.Drawing.Point(228, 111);
            this.btMercenaries.Name = "btMercenaries";
            this.btMercenaries.Size = new System.Drawing.Size(124, 23);
            this.btMercenaries.TabIndex = 0;
            this.btMercenaries.Text = "Mercenaries";
            this.btMercenaries.UseVisualStyleBackColor = true;
            // 
            // btRecruitMercenaries
            // 
            this.btRecruitMercenaries.Location = new System.Drawing.Point(228, 82);
            this.btRecruitMercenaries.Name = "btRecruitMercenaries";
            this.btRecruitMercenaries.Size = new System.Drawing.Size(124, 23);
            this.btRecruitMercenaries.TabIndex = 1;
            this.btRecruitMercenaries.Text = "Recruit Mercenaries";
            this.btRecruitMercenaries.UseVisualStyleBackColor = true;
            // 
            // btHeroes
            // 
            this.btHeroes.Location = new System.Drawing.Point(228, 169);
            this.btHeroes.Name = "btHeroes";
            this.btHeroes.Size = new System.Drawing.Size(124, 23);
            this.btHeroes.TabIndex = 2;
            this.btHeroes.Text = "Heroes";
            this.btHeroes.UseVisualStyleBackColor = true;
            this.btHeroes.Click += new System.EventHandler(this.btHeroes_Click);
            // 
            // btArena
            // 
            this.btArena.Location = new System.Drawing.Point(228, 140);
            this.btArena.Name = "btArena";
            this.btArena.Size = new System.Drawing.Size(124, 23);
            this.btArena.TabIndex = 3;
            this.btArena.Text = "Arena";
            this.btArena.UseVisualStyleBackColor = true;
            // 
            // btInventory
            // 
            this.btInventory.Location = new System.Drawing.Point(228, 30);
            this.btInventory.Name = "btInventory";
            this.btInventory.Size = new System.Drawing.Size(124, 23);
            this.btInventory.TabIndex = 4;
            this.btInventory.Text = "Inventory";
            this.btInventory.UseVisualStyleBackColor = true;
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
            this.btAdventures.Text = "Adventures";
            this.btAdventures.UseVisualStyleBackColor = true;
            // 
            // btCampain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accountDetailsBox);
            this.Controls.Add(this.btLogin);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "btCampain";
            this.Text = "Game Main Screen";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.RichTextBox accountDetailsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btRecruitMercenaries;
        private System.Windows.Forms.Button btMercenaries;
        private System.Windows.Forms.Button btArena;
        private System.Windows.Forms.Button btHeroes;
        private System.Windows.Forms.Button btInventory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btAdventures;
    }
}


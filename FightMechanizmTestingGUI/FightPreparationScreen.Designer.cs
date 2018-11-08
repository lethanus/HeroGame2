namespace FightMechanizmTestingGUI
{
    partial class FightPreparationScreen
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
            this.btToTeamA = new System.Windows.Forms.Button();
            this.listCharacters = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btToTeamB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listTeamA = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.listTeamB = new System.Windows.Forms.ListView();
            this.btSimulateFight = new System.Windows.Forms.Button();
            this.btRemoveFromA = new System.Windows.Forms.Button();
            this.btRemoveFromB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btToTeamA
            // 
            this.btToTeamA.Location = new System.Drawing.Point(12, 364);
            this.btToTeamA.Name = "btToTeamA";
            this.btToTeamA.Size = new System.Drawing.Size(86, 23);
            this.btToTeamA.TabIndex = 0;
            this.btToTeamA.Text = "Add to team A";
            this.btToTeamA.UseVisualStyleBackColor = true;
            this.btToTeamA.Click += new System.EventHandler(this.btToTeamA_Click);
            // 
            // listCharacters
            // 
            this.listCharacters.FullRowSelect = true;
            this.listCharacters.GridLines = true;
            this.listCharacters.Location = new System.Drawing.Point(12, 36);
            this.listCharacters.Name = "listCharacters";
            this.listCharacters.Size = new System.Drawing.Size(305, 312);
            this.listCharacters.TabIndex = 1;
            this.listCharacters.UseCompatibleStateImageBehavior = false;
            this.listCharacters.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available characters:";
            // 
            // btToTeamB
            // 
            this.btToTeamB.Location = new System.Drawing.Point(104, 364);
            this.btToTeamB.Name = "btToTeamB";
            this.btToTeamB.Size = new System.Drawing.Size(86, 23);
            this.btToTeamB.TabIndex = 3;
            this.btToTeamB.Text = "Add to team B";
            this.btToTeamB.UseVisualStyleBackColor = true;
            this.btToTeamB.Click += new System.EventHandler(this.btToTeamB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Team A:";
            // 
            // listTeamA
            // 
            this.listTeamA.FullRowSelect = true;
            this.listTeamA.GridLines = true;
            this.listTeamA.Location = new System.Drawing.Point(385, 36);
            this.listTeamA.Name = "listTeamA";
            this.listTeamA.Size = new System.Drawing.Size(305, 312);
            this.listTeamA.TabIndex = 4;
            this.listTeamA.UseCompatibleStateImageBehavior = false;
            this.listTeamA.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(765, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Team B:";
            // 
            // listTeamB
            // 
            this.listTeamB.FullRowSelect = true;
            this.listTeamB.GridLines = true;
            this.listTeamB.Location = new System.Drawing.Point(764, 36);
            this.listTeamB.Name = "listTeamB";
            this.listTeamB.Size = new System.Drawing.Size(305, 312);
            this.listTeamB.TabIndex = 6;
            this.listTeamB.UseCompatibleStateImageBehavior = false;
            this.listTeamB.View = System.Windows.Forms.View.Details;
            // 
            // btSimulateFight
            // 
            this.btSimulateFight.Location = new System.Drawing.Point(423, 489);
            this.btSimulateFight.Name = "btSimulateFight";
            this.btSimulateFight.Size = new System.Drawing.Size(223, 23);
            this.btSimulateFight.TabIndex = 8;
            this.btSimulateFight.Text = "Simulate fight";
            this.btSimulateFight.UseVisualStyleBackColor = true;
            this.btSimulateFight.Click += new System.EventHandler(this.btSimulateFight_Click);
            // 
            // btRemoveFromA
            // 
            this.btRemoveFromA.Location = new System.Drawing.Point(389, 364);
            this.btRemoveFromA.Name = "btRemoveFromA";
            this.btRemoveFromA.Size = new System.Drawing.Size(86, 23);
            this.btRemoveFromA.TabIndex = 9;
            this.btRemoveFromA.Text = "Remove";
            this.btRemoveFromA.UseVisualStyleBackColor = true;
            this.btRemoveFromA.Click += new System.EventHandler(this.btRemoveFromA_Click);
            // 
            // btRemoveFromB
            // 
            this.btRemoveFromB.Location = new System.Drawing.Point(768, 364);
            this.btRemoveFromB.Name = "btRemoveFromB";
            this.btRemoveFromB.Size = new System.Drawing.Size(86, 23);
            this.btRemoveFromB.TabIndex = 10;
            this.btRemoveFromB.Text = "Remove";
            this.btRemoveFromB.UseVisualStyleBackColor = true;
            this.btRemoveFromB.Click += new System.EventHandler(this.btRemoveFromB_Click);
            // 
            // FightPreparationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 535);
            this.Controls.Add(this.btRemoveFromB);
            this.Controls.Add(this.btRemoveFromA);
            this.Controls.Add(this.btSimulateFight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listTeamB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listTeamA);
            this.Controls.Add(this.btToTeamB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listCharacters);
            this.Controls.Add(this.btToTeamA);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1141, 574);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1141, 574);
            this.Name = "FightPreparationScreen";
            this.Text = "Fight preparation screen";
            this.Load += new System.EventHandler(this.FightPreparationScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btToTeamA;
        private System.Windows.Forms.ListView listCharacters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btToTeamB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listTeamA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listTeamB;
        private System.Windows.Forms.Button btSimulateFight;
        private System.Windows.Forms.Button btRemoveFromA;
        private System.Windows.Forms.Button btRemoveFromB;
    }
}


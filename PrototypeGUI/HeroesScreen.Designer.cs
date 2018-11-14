namespace PrototypeGUI
{
    partial class HeroesScreen
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
            this.btClose = new System.Windows.Forms.Button();
            this.listHeroes = new System.Windows.Forms.ListView();
            this.btLevelUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(713, 415);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // listHeroes
            // 
            this.listHeroes.Location = new System.Drawing.Point(12, 12);
            this.listHeroes.Name = "listHeroes";
            this.listHeroes.Size = new System.Drawing.Size(776, 397);
            this.listHeroes.TabIndex = 1;
            this.listHeroes.UseCompatibleStateImageBehavior = false;
            // 
            // btLevelUp
            // 
            this.btLevelUp.Location = new System.Drawing.Point(632, 415);
            this.btLevelUp.Name = "btLevelUp";
            this.btLevelUp.Size = new System.Drawing.Size(75, 23);
            this.btLevelUp.TabIndex = 2;
            this.btLevelUp.Text = "Level up";
            this.btLevelUp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To level up heroes they will need to have enough killing points and have specific" +
    " trophies in inventory";
            // 
            // HeroesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLevelUp);
            this.Controls.Add(this.listHeroes);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "HeroesScreen";
            this.Text = "Heroes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ListView listHeroes;
        private System.Windows.Forms.Button btLevelUp;
        private System.Windows.Forms.Label label1;
    }
}
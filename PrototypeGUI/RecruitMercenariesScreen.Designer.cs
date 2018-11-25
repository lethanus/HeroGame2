namespace PrototypeGUI
{
    partial class RecruitMercenariesScreen
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
            this.components = new System.ComponentModel.Container();
            this.btClose = new System.Windows.Forms.Button();
            this.listRecruits = new System.Windows.Forms.ListView();
            this.btRefresh = new System.Windows.Forms.Button();
            this.nextRefreshBar = new System.Windows.Forms.ProgressBar();
            this.btConvince = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.convinceChanceBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btAddGift = new System.Windows.Forms.Button();
            this.btRemoveGift = new System.Windows.Forms.Button();
            this.listGifts = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.timeLeftBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            // listRecruits
            // 
            this.listRecruits.FullRowSelect = true;
            this.listRecruits.GridLines = true;
            this.listRecruits.Location = new System.Drawing.Point(12, 30);
            this.listRecruits.Name = "listRecruits";
            this.listRecruits.Size = new System.Drawing.Size(512, 379);
            this.listRecruits.TabIndex = 1;
            this.listRecruits.UseCompatibleStateImageBehavior = false;
            this.listRecruits.View = System.Windows.Forms.View.Details;
            this.listRecruits.SelectedIndexChanged += new System.EventHandler(this.listRecruits_SelectedIndexChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(12, 415);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // nextRefreshBar
            // 
            this.nextRefreshBar.Location = new System.Drawing.Point(93, 415);
            this.nextRefreshBar.Name = "nextRefreshBar";
            this.nextRefreshBar.Size = new System.Drawing.Size(431, 23);
            this.nextRefreshBar.Step = 1;
            this.nextRefreshBar.TabIndex = 3;
            this.nextRefreshBar.Value = 45;
            // 
            // btConvince
            // 
            this.btConvince.Location = new System.Drawing.Point(530, 337);
            this.btConvince.Name = "btConvince";
            this.btConvince.Size = new System.Drawing.Size(258, 23);
            this.btConvince.TabIndex = 4;
            this.btConvince.Text = "Try convince to join your pack";
            this.btConvince.UseVisualStyleBackColor = true;
            this.btConvince.Click += new System.EventHandler(this.btConvince_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(565, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current chance to convince:";
            // 
            // convinceChanceBox
            // 
            this.convinceChanceBox.Location = new System.Drawing.Point(713, 292);
            this.convinceChanceBox.Name = "convinceChanceBox";
            this.convinceChanceBox.ReadOnly = true;
            this.convinceChanceBox.Size = new System.Drawing.Size(75, 20);
            this.convinceChanceBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(555, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Convince chance can be increased";
            // 
            // btAddGift
            // 
            this.btAddGift.Location = new System.Drawing.Point(530, 173);
            this.btAddGift.Name = "btAddGift";
            this.btAddGift.Size = new System.Drawing.Size(75, 23);
            this.btAddGift.TabIndex = 9;
            this.btAddGift.Text = "Add gift";
            this.btAddGift.UseVisualStyleBackColor = true;
            this.btAddGift.Click += new System.EventHandler(this.btAddGift_Click);
            // 
            // btRemoveGift
            // 
            this.btRemoveGift.Location = new System.Drawing.Point(713, 173);
            this.btRemoveGift.Name = "btRemoveGift";
            this.btRemoveGift.Size = new System.Drawing.Size(75, 23);
            this.btRemoveGift.TabIndex = 10;
            this.btRemoveGift.Text = "Remove";
            this.btRemoveGift.UseVisualStyleBackColor = true;
            this.btRemoveGift.Click += new System.EventHandler(this.btRemoveGift_Click);
            // 
            // listGifts
            // 
            this.listGifts.FullRowSelect = true;
            this.listGifts.GridLines = true;
            this.listGifts.Location = new System.Drawing.Point(530, 30);
            this.listGifts.Name = "listGifts";
            this.listGifts.Size = new System.Drawing.Size(258, 137);
            this.listGifts.TabIndex = 11;
            this.listGifts.UseCompatibleStateImageBehavior = false;
            this.listGifts.View = System.Windows.Forms.View.Details;
            this.listGifts.SelectedIndexChanged += new System.EventHandler(this.listGifts_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Gifts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "by adding some gifts";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Potential recruits";
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 250;
            this.refreshTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeLeftBox
            // 
            this.timeLeftBox.Location = new System.Drawing.Point(597, 418);
            this.timeLeftBox.Name = "timeLeftBox";
            this.timeLeftBox.ReadOnly = true;
            this.timeLeftBox.Size = new System.Drawing.Size(100, 20);
            this.timeLeftBox.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Time left";
            // 
            // RecruitMercenariesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeLeftBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listGifts);
            this.Controls.Add(this.btRemoveGift);
            this.Controls.Add(this.btAddGift);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.convinceChanceBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btConvince);
            this.Controls.Add(this.nextRefreshBar);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.listRecruits);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecruitMercenariesScreen";
            this.Text = "Recruit Mercenaries";
            this.Load += new System.EventHandler(this.RecruitMercenariesScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ListView listRecruits;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ProgressBar nextRefreshBar;
        private System.Windows.Forms.Button btConvince;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox convinceChanceBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btAddGift;
        private System.Windows.Forms.Button btRemoveGift;
        private System.Windows.Forms.ListView listGifts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.TextBox timeLeftBox;
        private System.Windows.Forms.Label label6;
    }
}
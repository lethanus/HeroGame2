namespace PrototypeGUI
{
    partial class QuestsScreen
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
            this.label5 = new System.Windows.Forms.Label();
            this.btRefresh = new System.Windows.Forms.Button();
            this.listQuests = new System.Windows.Forms.ListView();
            this.btClose = new System.Windows.Forms.Button();
            this.btBeginQuest = new System.Windows.Forms.Button();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Available quests";
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(12, 417);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 19;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // listQuests
            // 
            this.listQuests.FullRowSelect = true;
            this.listQuests.GridLines = true;
            this.listQuests.Location = new System.Drawing.Point(12, 32);
            this.listQuests.Name = "listQuests";
            this.listQuests.Size = new System.Drawing.Size(512, 379);
            this.listQuests.TabIndex = 18;
            this.listQuests.UseCompatibleStateImageBehavior = false;
            this.listQuests.View = System.Windows.Forms.View.Details;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(713, 417);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 17;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btBeginQuest
            // 
            this.btBeginQuest.Location = new System.Drawing.Point(597, 351);
            this.btBeginQuest.Name = "btBeginQuest";
            this.btBeginQuest.Size = new System.Drawing.Size(138, 23);
            this.btBeginQuest.TabIndex = 25;
            this.btBeginQuest.Text = "Begin quest";
            this.btBeginQuest.UseVisualStyleBackColor = true;
            this.btBeginQuest.Click += new System.EventHandler(this.btBeginQuest_Click);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 250;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // QuestsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btBeginQuest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.listQuests);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestsScreen";
            this.Text = "Quests";
            this.Load += new System.EventHandler(this.AdventuresScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ListView listQuests;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btBeginQuest;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
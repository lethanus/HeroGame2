namespace PrototypeGUI
{
    partial class MercenariesScreen
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
            this.listMercenaries = new System.Windows.Forms.ListView();
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
            // listMercenaries
            // 
            this.listMercenaries.FullRowSelect = true;
            this.listMercenaries.GridLines = true;
            this.listMercenaries.Location = new System.Drawing.Point(12, 12);
            this.listMercenaries.Name = "listMercenaries";
            this.listMercenaries.Size = new System.Drawing.Size(776, 397);
            this.listMercenaries.TabIndex = 1;
            this.listMercenaries.UseCompatibleStateImageBehavior = false;
            this.listMercenaries.View = System.Windows.Forms.View.Details;
            // 
            // MercenariesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listMercenaries);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "MercenariesScreen";
            this.Text = "Mercenaries";
            this.Load += new System.EventHandler(this.MercenariesScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ListView listMercenaries;
    }
}
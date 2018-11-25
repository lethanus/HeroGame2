namespace PrototypeGUI
{
    partial class AddingGiftsScreen
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
            this.listGifts = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amountBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listGifts
            // 
            this.listGifts.FullRowSelect = true;
            this.listGifts.GridLines = true;
            this.listGifts.Location = new System.Drawing.Point(12, 34);
            this.listGifts.Name = "listGifts";
            this.listGifts.Size = new System.Drawing.Size(285, 269);
            this.listGifts.TabIndex = 12;
            this.listGifts.UseCompatibleStateImageBehavior = false;
            this.listGifts.View = System.Windows.Forms.View.Details;
            this.listGifts.SelectedIndexChanged += new System.EventHandler(this.listGifts_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Available gifts";
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(66, 322);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(69, 20);
            this.amountBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Amount";
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(222, 320);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 17;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btConfirm
            // 
            this.btConfirm.Location = new System.Drawing.Point(141, 320);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(75, 23);
            this.btConfirm.TabIndex = 16;
            this.btConfirm.Text = "Confirm";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // AddingGiftsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 355);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listGifts);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 394);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 394);
            this.Name = "AddingGiftsScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add gifts";
            this.Load += new System.EventHandler(this.AddingGiftsScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amountBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listGifts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown amountBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btConfirm;
    }
}
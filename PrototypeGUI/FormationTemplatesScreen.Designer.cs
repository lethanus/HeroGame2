﻿namespace PrototypeGUI
{
    partial class FormationTemplatesScreen
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
            this.listFormationTemplates = new System.Windows.Forms.ListView();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listFormationTemplates
            // 
            this.listFormationTemplates.FullRowSelect = true;
            this.listFormationTemplates.GridLines = true;
            this.listFormationTemplates.Location = new System.Drawing.Point(12, 12);
            this.listFormationTemplates.Name = "listFormationTemplates";
            this.listFormationTemplates.Size = new System.Drawing.Size(776, 397);
            this.listFormationTemplates.TabIndex = 5;
            this.listFormationTemplates.UseCompatibleStateImageBehavior = false;
            this.listFormationTemplates.View = System.Windows.Forms.View.Details;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(713, 415);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // FormationTemplatesScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listFormationTemplates);
            this.Controls.Add(this.btClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormationTemplatesScreen";
            this.Text = "Formation templates";
            this.Load += new System.EventHandler(this.FormationTemplatesScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listFormationTemplates;
        private System.Windows.Forms.Button btClose;
    }
}
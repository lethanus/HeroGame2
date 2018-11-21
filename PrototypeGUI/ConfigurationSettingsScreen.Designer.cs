namespace PrototypeGUI
{
    partial class ConfigurationSettingsScreen
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
            this.listConfigurationSettings = new System.Windows.Forms.ListView();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listConfigurationSettings
            // 
            this.listConfigurationSettings.FullRowSelect = true;
            this.listConfigurationSettings.GridLines = true;
            this.listConfigurationSettings.Location = new System.Drawing.Point(12, 12);
            this.listConfigurationSettings.Name = "listConfigurationSettings";
            this.listConfigurationSettings.Size = new System.Drawing.Size(776, 397);
            this.listConfigurationSettings.TabIndex = 3;
            this.listConfigurationSettings.UseCompatibleStateImageBehavior = false;
            this.listConfigurationSettings.View = System.Windows.Forms.View.Details;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(713, 415);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ConfigurationSettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listConfigurationSettings);
            this.Controls.Add(this.btClose);
            this.Name = "ConfigurationSettingsScreen";
            this.Text = "Configuration settings";
            this.Load += new System.EventHandler(this.ConfigurationSettingsScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listConfigurationSettings;
        private System.Windows.Forms.Button btClose;
    }
}
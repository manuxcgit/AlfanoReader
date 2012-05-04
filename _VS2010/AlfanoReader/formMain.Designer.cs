namespace AlfanoReader
{
    partial class formMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemfichier = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemimporterDepuisAlfano = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemouvrirFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemquitter = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemparametres = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemportSerie = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 240);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.AutoSize = false;
            this.toolStripStatusLabelInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Maximum = 2048;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemfichier,
            this.ToolStripMenuItemparametres});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(484, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItemfichier
            // 
            this.ToolStripMenuItemfichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemimporterDepuisAlfano,
            this.ToolStripMenuItemouvrirFichier,
            this.toolStripMenuItem1,
            this.ToolStripMenuItemquitter});
            this.ToolStripMenuItemfichier.Name = "ToolStripMenuItemfichier";
            this.ToolStripMenuItemfichier.Size = new System.Drawing.Size(54, 20);
            this.ToolStripMenuItemfichier.Text = "Fichier";
            // 
            // ToolStripMenuItemimporterDepuisAlfano
            // 
            this.ToolStripMenuItemimporterDepuisAlfano.Name = "ToolStripMenuItemimporterDepuisAlfano";
            this.ToolStripMenuItemimporterDepuisAlfano.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemimporterDepuisAlfano.Text = "Importer depuis Alfano";
            this.ToolStripMenuItemimporterDepuisAlfano.Click += new System.EventHandler(this.e_ToolStripMenuItemimporterDepuisAlfano_Click);
            // 
            // ToolStripMenuItemouvrirFichier
            // 
            this.ToolStripMenuItemouvrirFichier.Name = "ToolStripMenuItemouvrirFichier";
            this.ToolStripMenuItemouvrirFichier.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemouvrirFichier.Text = "Ouvrir Fichier";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // ToolStripMenuItemquitter
            // 
            this.ToolStripMenuItemquitter.Name = "ToolStripMenuItemquitter";
            this.ToolStripMenuItemquitter.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemquitter.Text = "Quitter";
            // 
            // ToolStripMenuItemparametres
            // 
            this.ToolStripMenuItemparametres.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemportSerie});
            this.ToolStripMenuItemparametres.Name = "ToolStripMenuItemparametres";
            this.ToolStripMenuItemparametres.Size = new System.Drawing.Size(78, 20);
            this.ToolStripMenuItemparametres.Text = "Parametres";
            // 
            // ToolStripMenuItemportSerie
            // 
            this.ToolStripMenuItemportSerie.Name = "ToolStripMenuItemportSerie";
            this.ToolStripMenuItemportSerie.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItemportSerie.Text = "Port Serie";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formMain";
            this.Text = "Alfano Reader";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemfichier;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemimporterDepuisAlfano;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemouvrirFichier;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemquitter;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemparametres;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemportSerie;
        private System.IO.Ports.SerialPort serialPort1;
    }
}


namespace AlfanoReader
{
    partial class formParamSerie
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cBPortName = new System.Windows.Forms.ComboBox();
            this.cBStopBit = new System.Windows.Forms.ComboBox();
            this.cBDataBits = new System.Windows.Forms.ComboBox();
            this.cBParity = new System.Windows.Forms.ComboBox();
            this.cBBaudRate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdValider = new System.Windows.Forms.Button();
            this.cmdAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Serie :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Bits :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parity :";
            // 
            // cBPortName
            // 
            this.cBPortName.FormattingEnabled = true;
            this.cBPortName.Location = new System.Drawing.Point(77, 6);
            this.cBPortName.Name = "cBPortName";
            this.cBPortName.Size = new System.Drawing.Size(121, 21);
            this.cBPortName.TabIndex = 5;
            // 
            // cBStopBit
            // 
            this.cBStopBit.FormattingEnabled = true;
            this.cBStopBit.Location = new System.Drawing.Point(77, 114);
            this.cBStopBit.Name = "cBStopBit";
            this.cBStopBit.Size = new System.Drawing.Size(121, 21);
            this.cBStopBit.TabIndex = 6;
            // 
            // cBDataBits
            // 
            this.cBDataBits.FormattingEnabled = true;
            this.cBDataBits.Location = new System.Drawing.Point(77, 87);
            this.cBDataBits.Name = "cBDataBits";
            this.cBDataBits.Size = new System.Drawing.Size(121, 21);
            this.cBDataBits.TabIndex = 8;
            // 
            // cBParity
            // 
            this.cBParity.FormattingEnabled = true;
            this.cBParity.Location = new System.Drawing.Point(77, 60);
            this.cBParity.Name = "cBParity";
            this.cBParity.Size = new System.Drawing.Size(121, 21);
            this.cBParity.TabIndex = 9;
            // 
            // cBBaudRate
            // 
            this.cBBaudRate.FormattingEnabled = true;
            this.cBBaudRate.Location = new System.Drawing.Point(77, 33);
            this.cBBaudRate.Name = "cBBaudRate";
            this.cBBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cBBaudRate.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Stop Bit :";
            // 
            // cmdValider
            // 
            this.cmdValider.Location = new System.Drawing.Point(15, 161);
            this.cmdValider.Name = "cmdValider";
            this.cmdValider.Size = new System.Drawing.Size(75, 23);
            this.cmdValider.TabIndex = 12;
            this.cmdValider.Text = "Valider";
            this.cmdValider.UseVisualStyleBackColor = true;
            this.cmdValider.Click += new System.EventHandler(this.e_cmdValider_Click);
            // 
            // cmdAnnuler
            // 
            this.cmdAnnuler.Location = new System.Drawing.Point(123, 161);
            this.cmdAnnuler.Name = "cmdAnnuler";
            this.cmdAnnuler.Size = new System.Drawing.Size(75, 23);
            this.cmdAnnuler.TabIndex = 13;
            this.cmdAnnuler.Text = "Annuler";
            this.cmdAnnuler.UseVisualStyleBackColor = true;
            this.cmdAnnuler.Click += new System.EventHandler(this.e_cmdAnnuler_Click);
            // 
            // formParamSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 201);
            this.Controls.Add(this.cmdAnnuler);
            this.Controls.Add(this.cmdValider);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cBBaudRate);
            this.Controls.Add(this.cBParity);
            this.Controls.Add(this.cBDataBits);
            this.Controls.Add(this.cBStopBit);
            this.Controls.Add(this.cBPortName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formParamSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paramètres Port Serie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cBPortName;
        private System.Windows.Forms.ComboBox cBStopBit;
        private System.Windows.Forms.ComboBox cBDataBits;
        private System.Windows.Forms.ComboBox cBParity;
        private System.Windows.Forms.ComboBox cBBaudRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdValider;
        private System.Windows.Forms.Button cmdAnnuler;
    }
}
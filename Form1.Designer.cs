namespace projMe
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.CheckColorPrevision = new System.Windows.Forms.CheckBox();
            this.buttonMinusTentativi = new System.Windows.Forms.Button();
            this.buttonPlusTentativi = new System.Windows.Forms.Button();
            this.txtTentativi = new System.Windows.Forms.TextBox();
            this.checkUseTentativi = new System.Windows.Forms.CheckBox();
            this.panelSettingsGame = new System.Windows.Forms.Panel();
            this.labelTentativi = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panelSettingsGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.Location = new System.Drawing.Point(402, 233);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(210, 56);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Start game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            this.buttonStartGame.MouseLeave += new System.EventHandler(this.HoverExit);
            this.buttonStartGame.MouseHover += new System.EventHandler(this.hoverButton);
            // 
            // CheckColorPrevision
            // 
            this.CheckColorPrevision.AutoSize = true;
            this.CheckColorPrevision.Location = new System.Drawing.Point(36, 17);
            this.CheckColorPrevision.Margin = new System.Windows.Forms.Padding(2);
            this.CheckColorPrevision.Name = "CheckColorPrevision";
            this.CheckColorPrevision.Size = new System.Drawing.Size(105, 17);
            this.CheckColorPrevision.TabIndex = 2;
            this.CheckColorPrevision.Text = "pre-visione colori";
            this.CheckColorPrevision.UseVisualStyleBackColor = true;
            // 
            // buttonMinusTentativi
            // 
            this.buttonMinusTentativi.Enabled = false;
            this.buttonMinusTentativi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinusTentativi.Location = new System.Drawing.Point(36, 68);
            this.buttonMinusTentativi.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMinusTentativi.Name = "buttonMinusTentativi";
            this.buttonMinusTentativi.Size = new System.Drawing.Size(29, 31);
            this.buttonMinusTentativi.TabIndex = 4;
            this.buttonMinusTentativi.Text = "-";
            this.buttonMinusTentativi.UseVisualStyleBackColor = true;
            this.buttonMinusTentativi.Click += new System.EventHandler(this.buttonMinusTentativi_Click);
            // 
            // buttonPlusTentativi
            // 
            this.buttonPlusTentativi.Enabled = false;
            this.buttonPlusTentativi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlusTentativi.Location = new System.Drawing.Point(122, 68);
            this.buttonPlusTentativi.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlusTentativi.Name = "buttonPlusTentativi";
            this.buttonPlusTentativi.Size = new System.Drawing.Size(29, 31);
            this.buttonPlusTentativi.TabIndex = 5;
            this.buttonPlusTentativi.Text = "+";
            this.buttonPlusTentativi.UseVisualStyleBackColor = true;
            this.buttonPlusTentativi.Click += new System.EventHandler(this.buttonPlusTentativi_Click);
            // 
            // txtTentativi
            // 
            this.txtTentativi.Enabled = false;
            this.txtTentativi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTentativi.Location = new System.Drawing.Point(70, 68);
            this.txtTentativi.Margin = new System.Windows.Forms.Padding(2);
            this.txtTentativi.Name = "txtTentativi";
            this.txtTentativi.Size = new System.Drawing.Size(49, 32);
            this.txtTentativi.TabIndex = 6;
            this.txtTentativi.Text = "10";
            this.txtTentativi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkUseTentativi
            // 
            this.checkUseTentativi.AutoSize = true;
            this.checkUseTentativi.Location = new System.Drawing.Point(36, 40);
            this.checkUseTentativi.Margin = new System.Windows.Forms.Padding(2);
            this.checkUseTentativi.Name = "checkUseTentativi";
            this.checkUseTentativi.Size = new System.Drawing.Size(99, 17);
            this.checkUseTentativi.TabIndex = 7;
            this.checkUseTentativi.Text = "Utilizzo tentativi";
            this.checkUseTentativi.UseVisualStyleBackColor = true;
            this.checkUseTentativi.CheckedChanged += new System.EventHandler(this.checkUseTentativi_CheckedChanged);
            // 
            // panelSettingsGame
            // 
            this.panelSettingsGame.Controls.Add(this.CheckColorPrevision);
            this.panelSettingsGame.Controls.Add(this.checkUseTentativi);
            this.panelSettingsGame.Controls.Add(this.buttonMinusTentativi);
            this.panelSettingsGame.Controls.Add(this.txtTentativi);
            this.panelSettingsGame.Controls.Add(this.buttonPlusTentativi);
            this.panelSettingsGame.Location = new System.Drawing.Point(402, 295);
            this.panelSettingsGame.Margin = new System.Windows.Forms.Padding(2);
            this.panelSettingsGame.Name = "panelSettingsGame";
            this.panelSettingsGame.Size = new System.Drawing.Size(182, 111);
            this.panelSettingsGame.TabIndex = 8;
            // 
            // labelTentativi
            // 
            this.labelTentativi.AutoSize = true;
            this.labelTentativi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTentativi.Location = new System.Drawing.Point(478, 26);
            this.labelTentativi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTentativi.Name = "labelTentativi";
            this.labelTentativi.Size = new System.Drawing.Size(0, 26);
            this.labelTentativi.TabIndex = 9;
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(858, 412);
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(53, 38);
            this.buttonRestart.TabIndex = 10;
            this.buttonRestart.Text = "Reload";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 19);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(82, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 19);
            this.button2.TabIndex = 12;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(167, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 19);
            this.button3.TabIndex = 13;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.labelTentativi);
            this.Controls.Add(this.panelSettingsGame);
            this.Controls.Add(this.buttonStartGame);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Form1";
            this.Text = "memory";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panelSettingsGame.ResumeLayout(false);
            this.panelSettingsGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.CheckBox CheckColorPrevision;
        private System.Windows.Forms.Button buttonMinusTentativi;
        private System.Windows.Forms.Button buttonPlusTentativi;
        private System.Windows.Forms.TextBox txtTentativi;
        private System.Windows.Forms.CheckBox checkUseTentativi;
        private System.Windows.Forms.Panel panelSettingsGame;
        private System.Windows.Forms.Label labelTentativi;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}


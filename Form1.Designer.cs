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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.panelImageDefault = new System.Windows.Forms.Panel();
            this.CheckColorPrevision = new System.Windows.Forms.CheckBox();
            this.buttonFullscreen = new System.Windows.Forms.Button();
            this.buttonMinusTentativi = new System.Windows.Forms.Button();
            this.buttonPlusTentativi = new System.Windows.Forms.Button();
            this.txtTentativi = new System.Windows.Forms.TextBox();
            this.checkUseTentativi = new System.Windows.Forms.CheckBox();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.labelTentativi = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.Location = new System.Drawing.Point(536, 287);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(280, 69);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Start game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // panelImageDefault
            // 
            this.panelImageDefault.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelImageDefault.BackgroundImage")));
            this.panelImageDefault.Location = new System.Drawing.Point(1033, 299);
            this.panelImageDefault.Margin = new System.Windows.Forms.Padding(4);
            this.panelImageDefault.Name = "panelImageDefault";
            this.panelImageDefault.Size = new System.Drawing.Size(133, 123);
            this.panelImageDefault.TabIndex = 1;
            this.panelImageDefault.Visible = false;
            // 
            // CheckColorPrevision
            // 
            this.CheckColorPrevision.AutoSize = true;
            this.CheckColorPrevision.Location = new System.Drawing.Point(48, 21);
            this.CheckColorPrevision.Name = "CheckColorPrevision";
            this.CheckColorPrevision.Size = new System.Drawing.Size(132, 20);
            this.CheckColorPrevision.TabIndex = 2;
            this.CheckColorPrevision.Text = "pre-visione colori";
            this.CheckColorPrevision.UseVisualStyleBackColor = true;
            // 
            // buttonFullscreen
            // 
            this.buttonFullscreen.Location = new System.Drawing.Point(1148, 27);
            this.buttonFullscreen.Name = "buttonFullscreen";
            this.buttonFullscreen.Size = new System.Drawing.Size(150, 42);
            this.buttonFullscreen.TabIndex = 3;
            this.buttonFullscreen.Text = "Entra in Fullscreen";
            this.buttonFullscreen.UseVisualStyleBackColor = true;
            this.buttonFullscreen.Click += new System.EventHandler(this.buttonFullscreen_Click);
            // 
            // buttonMinusTentativi
            // 
            this.buttonMinusTentativi.Enabled = false;
            this.buttonMinusTentativi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinusTentativi.Location = new System.Drawing.Point(48, 84);
            this.buttonMinusTentativi.Name = "buttonMinusTentativi";
            this.buttonMinusTentativi.Size = new System.Drawing.Size(39, 38);
            this.buttonMinusTentativi.TabIndex = 4;
            this.buttonMinusTentativi.Text = "-";
            this.buttonMinusTentativi.UseVisualStyleBackColor = true;
            this.buttonMinusTentativi.Click += new System.EventHandler(this.buttonMinusTentativi_Click);
            // 
            // buttonPlusTentativi
            // 
            this.buttonPlusTentativi.Enabled = false;
            this.buttonPlusTentativi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlusTentativi.Location = new System.Drawing.Point(163, 84);
            this.buttonPlusTentativi.Name = "buttonPlusTentativi";
            this.buttonPlusTentativi.Size = new System.Drawing.Size(39, 38);
            this.buttonPlusTentativi.TabIndex = 5;
            this.buttonPlusTentativi.Text = "+";
            this.buttonPlusTentativi.UseVisualStyleBackColor = true;
            this.buttonPlusTentativi.Click += new System.EventHandler(this.buttonPlusTentativi_Click);
            // 
            // txtTentativi
            // 
            this.txtTentativi.Enabled = false;
            this.txtTentativi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTentativi.Location = new System.Drawing.Point(93, 84);
            this.txtTentativi.Name = "txtTentativi";
            this.txtTentativi.Size = new System.Drawing.Size(64, 38);
            this.txtTentativi.TabIndex = 6;
            this.txtTentativi.Text = "10";
            this.txtTentativi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkUseTentativi
            // 
            this.checkUseTentativi.AutoSize = true;
            this.checkUseTentativi.Location = new System.Drawing.Point(48, 49);
            this.checkUseTentativi.Name = "checkUseTentativi";
            this.checkUseTentativi.Size = new System.Drawing.Size(119, 20);
            this.checkUseTentativi.TabIndex = 7;
            this.checkUseTentativi.Text = "Utilizzo tentativi";
            this.checkUseTentativi.UseVisualStyleBackColor = true;
            this.checkUseTentativi.CheckedChanged += new System.EventHandler(this.checkUseTentativi_CheckedChanged);
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.CheckColorPrevision);
            this.panelSettings.Controls.Add(this.checkUseTentativi);
            this.panelSettings.Controls.Add(this.buttonMinusTentativi);
            this.panelSettings.Controls.Add(this.txtTentativi);
            this.panelSettings.Controls.Add(this.buttonPlusTentativi);
            this.panelSettings.Location = new System.Drawing.Point(536, 363);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(242, 137);
            this.panelSettings.TabIndex = 8;
            // 
            // labelTentativi
            // 
            this.labelTentativi.AutoSize = true;
            this.labelTentativi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTentativi.Location = new System.Drawing.Point(637, 32);
            this.labelTentativi.Name = "labelTentativi";
            this.labelTentativi.Size = new System.Drawing.Size(0, 32);
            this.labelTentativi.TabIndex = 9;
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(1144, 507);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(71, 47);
            this.buttonRestart.TabIndex = 10;
            this.buttonRestart.Text = "Reload";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.labelTentativi);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.buttonFullscreen);
            this.Controls.Add(this.panelImageDefault);
            this.Controls.Add(this.buttonStartGame);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Form1";
            this.Text = "memory";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_MoveOnScreen);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Panel panelImageDefault;
        private System.Windows.Forms.CheckBox CheckColorPrevision;
        private System.Windows.Forms.Button buttonFullscreen;
        private System.Windows.Forms.Button buttonMinusTentativi;
        private System.Windows.Forms.Button buttonPlusTentativi;
        private System.Windows.Forms.TextBox txtTentativi;
        private System.Windows.Forms.CheckBox checkUseTentativi;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelTentativi;
        private System.Windows.Forms.Button buttonRestart;
    }
}


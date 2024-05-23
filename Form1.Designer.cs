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
            this.panelSettingsGame = new System.Windows.Forms.Panel();
            this.textBoxBX = new System.Windows.Forms.TextBox();
            this.xjjx = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTentativi = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panelSettingsGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartGame.Location = new System.Drawing.Point(415, 213);
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
            this.CheckColorPrevision.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckColorPrevision.Location = new System.Drawing.Point(36, 17);
            this.CheckColorPrevision.Margin = new System.Windows.Forms.Padding(2);
            this.CheckColorPrevision.Name = "CheckColorPrevision";
            this.CheckColorPrevision.Size = new System.Drawing.Size(123, 17);
            this.CheckColorPrevision.TabIndex = 2;
            this.CheckColorPrevision.Text = "pre-visione colori";
            this.CheckColorPrevision.UseVisualStyleBackColor = true;
            // 
            // panelSettingsGame
            // 
            this.panelSettingsGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSettingsGame.Controls.Add(this.textBoxBX);
            this.panelSettingsGame.Controls.Add(this.xjjx);
            this.panelSettingsGame.Controls.Add(this.button2);
            this.panelSettingsGame.Controls.Add(this.button1);
            this.panelSettingsGame.Controls.Add(this.CheckColorPrevision);
            this.panelSettingsGame.Location = new System.Drawing.Point(415, 294);
            this.panelSettingsGame.Margin = new System.Windows.Forms.Padding(2);
            this.panelSettingsGame.Name = "panelSettingsGame";
            this.panelSettingsGame.Size = new System.Drawing.Size(182, 111);
            this.panelSettingsGame.TabIndex = 8;
            // 
            // textBoxBX
            // 
            this.textBoxBX.Enabled = false;
            this.textBoxBX.Location = new System.Drawing.Point(69, 57);
            this.textBoxBX.Name = "textBoxBX";
            this.textBoxBX.Size = new System.Drawing.Size(45, 20);
            this.textBoxBX.TabIndex = 13;
            this.textBoxBX.Text = "7";
            // 
            // xjjx
            // 
            this.xjjx.AutoSize = true;
            this.xjjx.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xjjx.Location = new System.Drawing.Point(33, 38);
            this.xjjx.Name = "xjjx";
            this.xjjx.Size = new System.Drawing.Size(58, 13);
            this.xjjx.TabIndex = 12;
            this.xjjx.Text = "Max points";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(120, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 25);
            this.button2.TabIndex = 11;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.labelTentativi);
            this.Controls.Add(this.panelSettingsGame);
            this.Controls.Add(this.buttonStartGame);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Form1";
            this.Text = "memory";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyPress);
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
        private System.Windows.Forms.Panel panelSettingsGame;
        private System.Windows.Forms.Label labelTentativi;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.TextBox textBoxBX;
        private System.Windows.Forms.Label xjjx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}


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
            this.buttonStartGame.Location = new System.Drawing.Point(553, 262);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(280, 69);
            this.buttonStartGame.TabIndex = 0;
            this.buttonStartGame.Text = "Start game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            this.buttonStartGame.MouseLeave += new System.EventHandler(this.HoverExit);
            this.buttonStartGame.MouseHover += new System.EventHandler(this.hoverButton);
            // 
            // panelSettingsGame
            // 
            this.panelSettingsGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSettingsGame.Controls.Add(this.textBoxBX);
            this.panelSettingsGame.Controls.Add(this.xjjx);
            this.panelSettingsGame.Controls.Add(this.button2);
            this.panelSettingsGame.Controls.Add(this.button1);
            this.panelSettingsGame.Location = new System.Drawing.Point(553, 362);
            this.panelSettingsGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSettingsGame.Name = "panelSettingsGame";
            this.panelSettingsGame.Size = new System.Drawing.Size(242, 136);
            this.panelSettingsGame.TabIndex = 8;
            // 
            // textBoxBX
            // 
            this.textBoxBX.Enabled = false;
            this.textBoxBX.Location = new System.Drawing.Point(92, 70);
            this.textBoxBX.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBX.Name = "textBoxBX";
            this.textBoxBX.Size = new System.Drawing.Size(59, 22);
            this.textBoxBX.TabIndex = 13;
            this.textBoxBX.Text = "7";
            // 
            // xjjx
            // 
            this.xjjx.AutoSize = true;
            this.xjjx.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xjjx.Location = new System.Drawing.Point(44, 47);
            this.xjjx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xjjx.Name = "xjjx";
            this.xjjx.Size = new System.Drawing.Size(71, 16);
            this.xjjx.TabIndex = 12;
            this.xjjx.Text = "Max points";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 66);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 31);
            this.button2.TabIndex = 11;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 66);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Panel panelSettingsGame;
        private System.Windows.Forms.Label labelTentativi;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.TextBox textBoxBX;
        private System.Windows.Forms.Label xjjx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}


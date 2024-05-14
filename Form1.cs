using Bogus;
using projMe.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace projMe
{
    public partial class Form1 : Form
    {

        PictureBox[] Squares = new PictureBox[28];
        Color[] ColorsInit = new Color[14];
      
        int[] allPositions = new int[28];
        
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        //int SpaceBordersAndSquaresWidth = (Screen.PrimaryScreen.Bounds.Width - 1300) / 2;
        //int SpaceBordersAndSquaresHeight = (Screen.PrimaryScreen.Bounds.Height - 700) / 2;

        int Ht = Screen.PrimaryScreen.Bounds.Height/15;

        int firstPos = -1;
        int secondPos = -1;
        bool[] DiscoveredSquares = new bool[28];
        bool[] DefinedSquares = new bool[28];
        Label[] ColorPrevisionLabels = new Label[28];
        int nt = default;
        Image HiddenSquareImg = Image.FromFile(Path.Combine(@"imgs", "not_seen.png"));
        Panel[] Attempts = new Panel[0];
        bool gameIsWithAttempts = false;
        bool gameHasColorsShown = false;
        public Form1()
        {
            InitializeComponent();
        }
        private async void Sq_Click(object sender, EventArgs e)
        {
            PictureBox ClickedSquare = sender as PictureBox;
            
            if (ClickedSquare.Image != HiddenSquareImg)
                return;
            ClickedSquare.BackColor = (Color)ClickedSquare.Tag;
            ClickedSquare.Image = null;
            

            //MessageBox.Show(ClickedSquare.BackColor.ToString());
            int numDiscovers = 0;
            for (int i = 0; i < 28; i++)
            {
                if (ClickedSquare == Squares[i])
                {
                    DiscoveredSquares[i] = true;
                    break;
                }
            }

            for (int i = 0; i < 28; i++)
            {
                if (DiscoveredSquares[i] && !DefinedSquares[i])
                {
                    numDiscovers++;
                    if (numDiscovers == 1)
                    {
                        firstPos = i;
                    }
                    if (numDiscovers == 2)
                    {
                        secondPos = i;
                    }

                }
            }
            if (numDiscovers == 1)
            {
                return;
            }
            if (numDiscovers == 2)
            {
                if (Squares[firstPos].BackColor == Squares[secondPos].BackColor)
                {
                    DefinedSquares[firstPos] = true;
                    DefinedSquares[secondPos] = true;
                    for ( int i = 0; i<28; i++)
                    {
                        Squares[i].Enabled = false;
                    }
                    await Task.Delay(500);
                    this.Controls.Remove(Squares[firstPos]);
                    this.Controls.Remove(Squares[secondPos]);
                    for (int i = 0; i < 28; i++)
                    {
                        Squares[i].Enabled = true;
                    }
                    for (int i = 0; i < 28; i++)
                    {
                        if (!DefinedSquares[i])
                        {
                            //  Win = false;
                            return;
                        }
                    }
                    MessageBox.Show("hai vinto");
                    await Task.Delay(2000);
                    
                    

                    Squares = new PictureBox[28];
                    if (gameIsWithAttempts)
                    {
                        for (int a = 0; a<nt; a++)
                        {
                            this.Controls.Remove(Attempts[nt-1]);
                        }
                        nt = default;
                    }
                    if (gameHasColorsShown)
                    {
                        for (int a = 0; a < 28; a++)
                        {
                            this.Controls.Remove(ColorPrevisionLabels[a]);
                        }
                    }
                    buttonStartGame.Visible = true;
                    panelSettingsGame.Visible = true;
                    return;
                }
                for (int i = 0; i<28; i++)
                {
                    Squares[i].Enabled = false;
                }
                await Task.Delay(1000);
                if (gameIsWithAttempts)
                {
                    nt--;
                    Attempts[nt].BackColor = Color.White;
                    labelTentativi.Text = $"Tentativi: {nt}";
                    if (Attempts[0].BackColor == Color.White)
                    {
                        MessageBox.Show("hai perso");
                        await Task.Delay(1000);
                        Application.Restart();
                        return;
                    }
                }
                
                for (int i = 0; i < 28; i++)
                {
                    if (DiscoveredSquares[i] && !DefinedSquares[i])
                    {
                        Squares[i].Image = HiddenSquareImg;
                   
                        DiscoveredSquares[i] = false;
                        Squares[firstPos].Image = HiddenSquareImg;
                        DiscoveredSquares[firstPos] = false;
                    
                    }
                }
                
                for (int i = 0; i < 28; i++)
                {
                    Squares[i].Enabled = true;
                }
            }
         
            
          
            
                
            ColorsInit[0] = Color.Yellow;
            ColorsInit[1] = Color.Lime;
            ColorsInit[2] = Color.Blue;
            ColorsInit[3] = Color.Red;
            ColorsInit[4] = Color.Magenta;
            ColorsInit[5] = Color.Black;
            ColorsInit[6] = Color.DarkGreen;
            ColorsInit[7] = Color.Gray;
            ColorsInit[8] = Color.FromArgb(128, 128, 200);
            ColorsInit[9] = Color.Pink;
            ColorsInit[10] = Color.Purple;
            ColorsInit[11] = Color.Orange;
            ColorsInit[12] = Color.LightBlue;
            ColorsInit[13] = Color.Brown;

            
        }
        private void HoverInsideSquare(object sender, EventArgs e)
        {
            if ((sender as PictureBox).Image == HiddenSquareImg)
            Cursor = Cursors.Hand;
        }
            private void HoverExit(object sender, EventArgs e)
            {
                Cursor = Cursors.Default;
            }
        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            panelSettingsGame.Visible = false;




            this.Size = new Size(screenWidth, screenHeight);
            this.MaximizeBox = false;

            if (checkUseTentativi.Checked)
            {
                nt = int.Parse(txtTentativi.Text);
                gameIsWithAttempts = true;
                int halfScreenWidth = screenWidth / 2;
                Panel panelFirst = new Panel();
                panelFirst.Location = new Point(10, 10);
                panelFirst.Size = new Size(screenWidth / 2 / nt, 30);
                panelFirst.BackColor = Color.Lime;
                panelFirst.BorderStyle = BorderStyle.FixedSingle;
                Array.Resize(ref Attempts, nt);
                Attempts[0] = panelFirst;
                this.Controls.Add(panelFirst);
                for (int i = 1; i < nt; i++)
                {
                    Panel panel = new Panel();
                    Attempts[i] = panel;
                    panel.Location = new Point(Attempts[i - 1].Size.Width + Attempts[i - 1].Location.X, 10);
                    panel.Size = new Size(screenWidth / 2 / nt, 30);
                    panel.BackColor = Color.Lime;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(panel);
                }
                labelTentativi.Text = $"Tentativi: {nt}"; }
            #region Pre-settaggio
            #region addColorsToArray
            ColorsInit[0] = Color.Yellow;
            ColorsInit[1] = Color.Lime;
            ColorsInit[2] = Color.Blue;
            ColorsInit[3] = Color.Red;
            ColorsInit[4] = Color.Magenta;
            ColorsInit[5] = Color.Black;
            ColorsInit[6] = Color.DarkGreen;
            ColorsInit[7] = Color.Gray;
            ColorsInit[8] = Color.FromArgb(128, 128, 200);
            ColorsInit[9] = Color.Pink;
            ColorsInit[10] = Color.Purple;
            ColorsInit[11] = Color.Orange;
            ColorsInit[12] = Color.LightBlue;
            ColorsInit[13] = Color.Brown;
            #endregion
            #region positions/discovers
            for (int i = 0; i < 28; i++)
            {
                allPositions[i] = i;
            }
            for (int i = 0; i < 28; i++)
            {
                DiscoveredSquares[i] = false;
            }
            for (int i = 0; i < 28; i++)
            {
                DefinedSquares[i] = false;
            }
            #endregion
            #region Tentativi

            #endregion
            #endregion //colori

            Panel BoxesInside = new Panel()
            {
                Width = Ht * 13,
                Height = Ht * 7,
                Location = new Point(Ht, Ht),
                BorderStyle = BorderStyle.FixedSingle,
            };
            if (9 * Ht > screenHeight)
            {
                Ht = screenHeight / 9;
                
                BoxesInside.Location = new Point(Ht, Ht);
            }
                #region addPanels
                for (int a = 0; a < 14; a++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(100, 100);
                x.SizeMode = PictureBoxSizeMode.StretchImage;
                Squares[a] = x;
                Squares[a].Tag = ColorsInit[a];


            }
            for (int a = 14; a < 28; a++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(100, 100);
                Squares[a] = x;
                Squares[a].Tag = ColorsInit[a - 14];
            }

            #endregion
            #region addControls...
            for (int a = 0; a < 7; a++)
            {
                Squares[a].Location = new Point(Ht+2*a*Ht);
                Squares[a].Image = HiddenSquareImg;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(Squares[a]);
            }
            for (int a = 7; a < 14; a++)
            {
                Squares[a].Location = new Point();
                Squares[a].Image = HiddenSquareImg;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(Squares[a]);
            }
            for (int a = 14; a < 21; a++)
            {
                Squares[a].Location = new Point();
                Squares[a].Image = HiddenSquareImg;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(Squares[a]);
            }
            for (int a = 21; a < 28; a++)
            {
                Squares[a].Location = new Point();
                Squares[a].Image = HiddenSquareImg;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(Squares[a]);
            }
            for (int x = 0; x < 28; x++)
            {
                var random = new Faker();
                int rc = random.PickRandom(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27);
                Color tagColor = (Color)Squares[x].Tag;
                Squares[x].Tag = (Color)Squares[rc].Tag;
                Squares[rc].Tag = tagColor;


            }
            if (CheckColorPrevision.Checked)
            {
                gameHasColorsShown = true;
                for (int a = 0; a < 28; a++)
                {
                    Label l = new Label();
                    l.Location = new Point(Squares[a].Location.X, Squares[a].Location.Y-30);
                    l.Size = new Size(100, 30);
                    l.ForeColor = (Color)Squares[a].Tag;
                    l.Text = Squares[a].Tag.ToString();
                    ColorPrevisionLabels[a] = l;
                    this.Controls.Add(l);
                }
            }
            #endregion
            #region EventHandlers

            for (int i = 0; i < 28; i++)
            {
                this.Squares[i].Click += new System.EventHandler(Sq_Click);
                this.Squares[i].MouseEnter += new System.EventHandler(HoverInsideSquare);
                this.Squares[i].MouseLeave += new System.EventHandler(HoverExit);
            }




            #endregion
            buttonStartGame.Visible = false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            buttonFullscreen.Text = "Esci da Fullscreen";
            this.Location = new Point(0, 0);
            this.Size = new Size(screenWidth, screenHeight);
            buttonStartGame.Location = new Point(screenWidth / 2 - buttonStartGame.Width / 2, screenHeight / 2 - buttonStartGame.Width / 2);
            buttonFullscreen.Size = new Size(150, 40);
            buttonFullscreen.Location = new Point(this.Size.Width - 200, 0);
            panelSettingsGame.Location = new Point(buttonStartGame.Location.X, buttonStartGame.Location.Y+buttonStartGame.Size.Height+4);
            labelTentativi.Location = new Point(screenWidth / 2 + 10, 20);
            labelTentativi.Size = new Size(20, 20);
            buttonRestart.Location = new Point(screenWidth - buttonRestart.Width, screenHeight - buttonRestart.Height);
               
        }
        
       

        private void buttonFullscreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                buttonFullscreen.Text = "Esci da Fullscreen";
                return;
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.MaximizeBox = false;
                buttonFullscreen.Text = "Entra in Fullscreen (consigliato)";
                return;
            }
            
        }

        private void checkUseTentativi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUseTentativi.Checked)
            {
                buttonPlusTentativi.Enabled = true;
                buttonMinusTentativi.Enabled = true;
               
            }
            else
            {
                buttonPlusTentativi.Enabled = false;
                buttonMinusTentativi.Enabled = false;
                
            }
        }

        private void buttonMinusTentativi_Click(object sender, EventArgs e)
        {
            
            int trsCorr = int.Parse(txtTentativi.Text);
            if (trsCorr > 1)
            {
                trsCorr = trsCorr - 1;
                txtTentativi.Text = trsCorr.ToString();
            }
        }

        private void buttonPlusTentativi_Click(object sender, EventArgs e)
        {
            int trsCorr = int.Parse(txtTentativi.Text);
            if (trsCorr < 50)
            {
                trsCorr = trsCorr + 1;
                txtTentativi.Text = trsCorr.ToString();
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

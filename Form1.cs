using Bogus;
using projMe.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        Panel[] Squares = new Panel[28];
        Color[] ColorsInit = new Color[14];
      
        int[] allPositions = new int[28];
        
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int SpaceBordersAndSquaresWidth = (Screen.PrimaryScreen.Bounds.Width - 1300) / 2;
        int SpaceBordersAndSquaresHeight = (Screen.PrimaryScreen.Bounds.Height - 700) / 2;
        
        int firstPos = -1;
        int secondPos = -1;
        bool[] DiscoveredSquares = new bool[28];
        bool[] DefinedSquares = new bool[28];
        bool AllowedToResize;
        int nt = default;
        Panel[] Tentativi = new Panel[0];
        bool gameIsWithTries = false;
        public Form1()
        {
            InitializeComponent();
        }
        private async void Sq_Click(object sender, EventArgs e)
        {
            Panel ClickedSquare = sender as Panel;
            
            if (ClickedSquare.BackgroundImage != panelImageDefault.BackgroundImage)
                return;
            ClickedSquare.BackColor = (Color)ClickedSquare.Tag;
            ClickedSquare.BackgroundImage = null;
            

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
                    
                    for (int j = 0; j < 28; j++)
                    {
                        this.Controls.Remove(Squares[j]);
                    }
                    Squares = new Panel[28];
                    buttonStartGame.Visible = true;
                    Application.Restart();
                    return;
                }
                for (int i = 0; i<28; i++)
                {
                    Squares[i].Enabled = false;
                }
                await Task.Delay(1000);
                if (gameIsWithTries)
                {
                    nt--;
                    Tentativi[nt].BackColor = Color.White;
                    labelTentativi.Text = $"Tentativi: {nt}";
                    if (Tentativi[0].BackColor == Color.White)
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
                        Squares[i].BackgroundImage = panelImageDefault.BackgroundImage;
                   //     Squares[i].BackColor = default;
                        DiscoveredSquares[i] = false;
                        Squares[firstPos].BackgroundImage = panelImageDefault.BackgroundImage;
                        DiscoveredSquares[firstPos] = false;
                    //    Squares[firstPos].BackColor = default;
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
            if ((sender as Panel).BackgroundImage == panelImageDefault.BackgroundImage)
            Cursor = Cursors.Hand;
        }
        private void HoverExit(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            panelSettings.Enabled = false;
        
            
            
            
            this.Size = new Size(screenWidth, screenHeight);
            this.MaximizeBox = false;
            //this.MinimizeBox = false;
            if (checkUseTentativi.Checked)
            {
                nt = int.Parse(txtTentativi.Text);  
                gameIsWithTries = true;
                int halfScreenWidth = screenWidth / 2;
                Panel panelFirst = new Panel();
                panelFirst.Location = new Point(10, 10);
                panelFirst.Size = new Size(screenWidth/2/nt, 30);
                panelFirst.BackColor = Color.Lime;
                panelFirst.BorderStyle = BorderStyle.FixedSingle;
                Array.Resize(ref Tentativi, nt);
                Tentativi[0] = panelFirst;
                this.Controls.Add(panelFirst);
                for (int i = 1; i<nt; i++)
                {
                    Panel panel = new Panel();
                    Tentativi[i] = panel;
                    panel.Location = new Point(Tentativi[i - 1].Size.Width + Tentativi[i-1].Location.X, 10);
                    panel.Size = new Size(screenWidth / 2 / nt, 30);
                    panel.BackColor = Color.Lime;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(panel);
                }
                labelTentativi.Text = $"Tentativi: {nt}";            }
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
            #endregion


            #region addPanels
            for (int a = 0; a < 14; a++)
            {
                Panel x = new Panel();
                x.Size = new Size(100, 100);
                Squares[a] = x;
                Squares[a].Tag = ColorsInit[a];


            }
            for (int a = 14; a < 28; a++)
            {
                Panel x = new Panel();
                x.Size = new Size(100, 100);
                Squares[a] = x;
                Squares[a].Tag = ColorsInit[a - 14];
            }


            

            //while (numUsedPositions < 27)
            
                
            


            
            

            #endregion
            #region addControls...
            for (int a = 0; a < 7; a++)
            {
                Squares[a].Location = new Point(SpaceBordersAndSquaresWidth + 200 * a, SpaceBordersAndSquaresHeight);
                Squares[a].BackgroundImage = panelImageDefault.BackgroundImage;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(Squares[a]);
            }
            for (int a = 7; a < 14; a++)
            {
                Squares[a].Location = new Point(SpaceBordersAndSquaresWidth + 200 * (a - 7), SpaceBordersAndSquaresHeight + 200);
                Squares[a].BackgroundImage = panelImageDefault.BackgroundImage;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(Squares[a]);
            }
            for (int a = 14; a < 21; a++)
            {
                Squares[a].Location = new Point(SpaceBordersAndSquaresWidth + 200 * (a - 14), SpaceBordersAndSquaresHeight + 400);
                Squares[a].BackgroundImage = panelImageDefault.BackgroundImage;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                this.Controls.Add(Squares[a]);
            }
            for (int a = 21; a < 28; a++)
            {
                Squares[a].Location = new Point(SpaceBordersAndSquaresWidth + 200 * (a - 21), SpaceBordersAndSquaresHeight + 600);
                Squares[a].BackgroundImage = panelImageDefault.BackgroundImage;
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
                for (int a = 0; a < 7; a++)
                {
                    Label l = new Label();
                    l.Location = new Point(200 * a + 100, 100 - 40);
                    l.Size = new Size(100, 30);
                    l.ForeColor = (Color)Squares[a].Tag;
                    l.Text = Squares[a].Tag.ToString();
                    this.Controls.Add(l);
                }
                for (int a = 7; a < 14; a++)
                {
                    Label l = new Label();
                    l.Location = new Point(200 * (a - 7) + 100, 300 - 40);
                    l.Size = new Size(100, 30);
                    l.ForeColor = (Color)Squares[a].Tag;
                    l.Text = Squares[a].Tag.ToString();
                    this.Controls.Add(l);
                }
                for (int a = 14; a < 21; a++)
                {
                    Label l = new Label();
                    l.Location = new Point(200 * (a - 14) + 100, 500 - 40);
                    l.Size = new Size(100, 30);
                    l.ForeColor = (Color)Squares[a].Tag;
                    l.Text = Squares[a].Tag.ToString();
                    this.Controls.Add(l);
                }
                for (int a = 21; a < 28; a++)
                {
                    Label l = new Label();
                    l.Location = new Point(200 * (a - 21) + 100, 700 - 40);
                    l.Size = new Size(100, 30);
                    l.ForeColor = (Color)Squares[a].Tag;
                    l.Text = Squares[a].Tag.ToString();
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
            CheckColorPrevision.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllowedToResize = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            buttonFullscreen.Text = "Esci da Fullscreen";
            this.Location = new Point(0, 0);
            this.Size = new Size(screenWidth, screenHeight);
            buttonStartGame.Location = new Point(screenWidth / 2 - buttonStartGame.Width / 2, screenHeight / 2 - buttonStartGame.Width / 2);
            buttonFullscreen.Size = new Size(150, 40);
            buttonFullscreen.Location = new Point(this.Size.Width - 200, 0);
            panelSettings.Location = new Point(buttonStartGame.Location.X, buttonStartGame.Location.Y+buttonStartGame.Size.Height+4);
            labelTentativi.Location = new Point(screenWidth / 2 + 10, 20);
            labelTentativi.Size = new Size(20, 20);
            buttonRestart.Location = new Point(screenWidth - buttonRestart.Width, screenHeight - buttonRestart.Height);
               
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (AllowedToResize)
            {
               
                return;
            }
            this.Size = new Size(screenWidth, screenHeight);
            this.Location = new Point(0, 0);
            AllowedToResize = false;
        }
        private void Form1_MoveOnScreen(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
        }

        private void buttonFullscreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                AllowedToResize = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                buttonFullscreen.Text = "Esci da Fullscreen";
                return;
            }
            if (this.WindowState == FormWindowState.Maximized)
            {
                AllowedToResize = true;
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

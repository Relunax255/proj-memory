using Bogus;
using projMe.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        

        int defSize = Screen.PrimaryScreen.Bounds.Height/8;

        int firstPos = -1;
        int secondPos = -1;
        bool[] DiscoveredSquares = new bool[28];
        bool[] DefinedSquares = new bool[28];
        Label[] ColorPrevisionLabels = new Label[28];
        int nt = default;
        Image HiddenSquareImg = Image.FromFile(Path.Combine(@"img", "not_seen.png"));
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
        private void hoverButton(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            buttonStartGame.Visible = false;
            panelSettingsGame.Visible = false;
            Panel setNicknamesPanel = new Panel();
            setNicknamesPanel.Size = new Size(this.Width / 3, this.Height / 4);
            setNicknamesPanel.Location = new Point(this.Width / 2 - setNicknamesPanel.Width / 2, this.Height / 2 - setNicknamesPanel.Height / 2);
            setNicknamesPanel.BackColor = Color.White;
            setNicknamesPanel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(setNicknamesPanel);
            Panel nick1 = new Panel();
            nick1.Size = new Size(setNicknamesPanel.Width / 2 - 4, setNicknamesPanel.Height - 4);
            nick1.Location = new Point(1, 1);
            nick1.BackColor = Color.Green;
            TextBox nick1insert = new TextBox();
            nick1insert.Width = nick1.Width * 2/3;
            nick1insert.Location = new Point(nick1.Width/2-nick1insert.Width/2, nick1.Height/2-nick1insert.Height/2);
            Button nick1Confirm = new Button();
            nick1Confirm.Size = new Size(nick1insert.Width, nick1insert.Height * 2);
            nick1Confirm.Location = new Point(nick1insert.Location.X, nick1insert.Location.Y+(nick1.Height-nick1insert.Location.Y)/2);
            nick1Confirm.Text = "Confirm";
            nick1Confirm.ForeColor = Color.White;
            nick1.Controls.Add(nick1insert);
            nick1.Controls.Add(nick1Confirm);
            
            Panel nick2 = new Panel();
            nick2.Size = new Size(setNicknamesPanel.Width / 2 - 4, setNicknamesPanel.Height - 4);
            nick2.Location = new Point(nick1.Width+5, 1);
            nick2.BackColor = Color.Green;
            TextBox nick2insert = new TextBox();
            nick2insert.Width = nick2.Width * 2 / 3;
            nick2insert.Location = new Point(nick2.Width / 2 - nick2insert.Width / 2, nick2.Height / 2 - nick2insert.Height / 2);
            Button nick2Confirm = new Button();
            nick2Confirm.Size = new Size(nick2insert.Width, nick2insert.Height * 2);
            nick2Confirm.Location = new Point(nick2insert.Location.X, nick2insert.Location.Y + (nick2.Height - nick2insert.Location.Y) / 2);
            nick2Confirm.Text = "Confirm";
            nick2Confirm.ForeColor = Color.White;
            nick2.Controls.Add(nick2insert);
            nick2.Controls.Add(nick2Confirm);
            setNicknamesPanel.Controls.Add(nick1);
            setNicknamesPanel.Controls.Add(nick2);

        }
        private void gameStart()
        {
            FlowLayoutPanel flw = new FlowLayoutPanel();

            int defPadding = 11;
            panelSettingsGame.Visible = false;



            flw.Size = new Size(Width - 100, Height - 100);
            flw.Location = new Point(50, 50);
            flw.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(flw);

            this.Size = new Size(screenWidth, screenHeight);
            this.MaximizeBox = false;


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

            #endregion


            #region squaresDefinitions
            for (int a = 0; a < 14; a++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(defSize, defSize);
                x.SizeMode = PictureBoxSizeMode.StretchImage;
                Squares[a] = x;
                Squares[a].Margin = new Padding(defPadding);
                Squares[a].Image = HiddenSquareImg;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                Squares[a].Tag = ColorsInit[a];


            }
            for (int a = 14; a < 28; a++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(defSize, defSize);
                x.SizeMode = PictureBoxSizeMode.StretchImage;
                Squares[a] = x;
                Squares[a].Margin = new Padding(defPadding);
                Squares[a].Image = HiddenSquareImg;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                Squares[a].Tag = ColorsInit[a - 14];
            }
            for (int x = 0; x < 28; x++)
            {
                var random = new Faker();
                int rc = random.PickRandom(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27);
                Color tagColor = (Color)Squares[x].Tag;
                Squares[x].Tag = (Color)Squares[rc].Tag;
                Squares[rc].Tag = tagColor;


            }
            #endregion
            #region addControls...


            for (int a = 0; a < 28; a++)
            {

                flw.Controls.Add(Squares[a]);

            }
            int inRowBoxes = 1;
            int yPos = Squares[0].Location.Y;
            for (int n = 1; n < 28; n++)
            {
                if (Squares[n].Location.Y == yPos)
                {
                    inRowBoxes++;
                }
                else { break; }
            }
            //
            int inColBoxes = 1;
            int xPos = Squares[0].Location.X;
            for (int n = inRowBoxes; n < 28; n = n + inRowBoxes)
            {
                if (Squares[n].Location.X == xPos)
                {
                    inColBoxes++;
                }
                else { break; }
            }
            //MessageBox.Show(inRowBoxes.ToString());
            flw.Size = new Size(inRowBoxes * defSize + 2 * (inRowBoxes * defPadding) + 2, inColBoxes * defSize + 2 * (inColBoxes * defPadding) + 2);
            flw.Location = new Point(this.Width / 2 - flw.Width / 2, this.Height / 2 - flw.Height / 2);

            int firstSquareXpos = flw.Location.X + defPadding;
            int firstSquareYpos = flw.Location.Y + defPadding;
            int column = 0;
            int m = 0;

            for (int i = 0; i < 28; i = i + inRowBoxes)
            {
                int p = 0;
                while (m < inRowBoxes * (column + 1) && m < 28)
                {
                    flw.Controls.Remove(Squares[m]);
                    Squares[m].Location = new Point(firstSquareXpos + p * (defSize + 2 * defPadding), firstSquareYpos + column * (defSize + 2 * defPadding));
                    this.Controls.Add(Squares[m]);
                    m++;
                    p++;
                }

                column++;
            }
            this.Controls.Remove(flw);

            if (CheckColorPrevision.Checked)
            {
                gameHasColorsShown = true;
                for (int a = 0; a < 28; a++)
                {
                    Label l = new Label();
                    l.Location = new Point(Squares[a].Location.X, Squares[a].Location.Y - 30);
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
                Squares[i].Click += new System.EventHandler(Sq_Click);
                Squares[i].MouseEnter += new System.EventHandler(HoverInsideSquare);
                Squares[i].MouseLeave += new System.EventHandler(HoverExit);
            }




            #endregion
            buttonStartGame.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;  
            this.Location = new Point(0, 0);
            this.Size = new Size(screenWidth, screenHeight);
            buttonStartGame.Location = new Point(screenWidth / 2 - buttonStartGame.Width / 2, screenHeight / 2 - buttonStartGame.Width / 2);
            panelSettingsGame.Location = new Point(buttonStartGame.Location.X, buttonStartGame.Location.Y+buttonStartGame.Size.Height+4);
            labelTentativi.Location = new Point(screenWidth / 2 + 10, 20);
            labelTentativi.Size = new Size(20, 20);
            buttonRestart.Location = new Point(screenWidth - buttonRestart.Width, screenHeight - buttonRestart.Height);

            Button buttonExit = new Button()
            {
                Size = new Size(30, 30),
                Location = new Point(this.Width - 30, 0),
                BackColor = Color.Red,
                ForeColor = Color.White,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter

            };
            this.Controls.Add(buttonExit);
            buttonExit.Click += new System.EventHandler(exit);
        }
        
       

       

       

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Squares[0].Location.ToString());
        }

        
    }
}

using projMe.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.XPath;

namespace projMe
{
    public partial class Form1 : Form
    {

        PictureBox[] Squares = new PictureBox[0];
        Image[] InitImgs = new Image[13];
        
      
        int[] allPositions = new int[0];
        
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        

        
        int squareRoot = default;
        int firstPos = -1;
        int secondPos = -1;
        bool[] DiscoveredSquares = new bool[0];
        bool[] DefinedSquares = new bool[0];
        Label[] ColorPrevisionLabels = new Label[0];
        Image HiddenSquareImg = Image.FromFile(Path.Combine(@"img", "not_seen.png"));
        
        bool p1status = false;
        bool p2status = false;
        string player1nickname = default;
        string player2nickname = default;
        int player1pt = default;
        int player2pt = default;
        int CurrentPlayer = default;
        int maxpoints = 7;
        int numSquares = default;
        public Form1()
        {
            InitializeComponent();
            for (int x = 0; x<13; x++)
            {
                InitImgs[x] = Image.FromFile(Path.Combine(@"img", @"gameimgs", $"{x+1}.png"));
            }
        }
        private async void Sq_Click(object sender, EventArgs e)
        {
            PictureBox ClickedSquare = sender as PictureBox;
           
            if (ClickedSquare.Image != HiddenSquareImg)
                return;
            ClickedSquare.Image = (Image)ClickedSquare.Tag;
            
            

            
            int numDiscovers = 0;
            for (int i = 0; i < numSquares; i++)
            {
                if (ClickedSquare == Squares[i])
                {
                    DiscoveredSquares[i] = true;
                    break;
                }
            }

            for (int i = 0; i < numSquares; i++)
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
                if (Squares[firstPos].Image == Squares[secondPos].Image)
                {
                    DefinedSquares[firstPos] = true;
                    DefinedSquares[secondPos] = true;
                    for ( int i = 0; i<numSquares; i++)
                    {
                        Squares[i].Enabled = false;
                    }
                    await Task.Delay(500);
                    this.Controls.Remove(Squares[firstPos]);
                    this.Controls.Remove(Squares[secondPos]);
                    if (CurrentPlayer == 1)
                    {
                        player1pt++;
                        this.Controls.Find("p1pts", false)[0].Text = player1pt.ToString();
                    }
                    else
                    {
                        player2pt++;

                        this.Controls.Find("p2pts", false)[0].Text = player2pt.ToString();
                        this.Controls.Find("p2pts", false)[0].Location = new Point(this.Controls.Find("p2lbl", false)[0].Location.X - this.Controls.Find("p2pts", false)[0].Width, 30);
                    }
                    for (int i = 0; i < numSquares; i++)
                    {
                        Squares[i].Enabled = true;
                    }
                    for (int i = 0; i < numSquares; i++)
                    {
                        if (!DefinedSquares[i])
                        {
                           
                            return;
                        }
                    }
                    


                    await Task.Delay(900);
                   
                    Panel brs = new Panel();
                    brs.Size = new Size(this.Width / 3 - 10, this.Height / 3 - 10);
                    
                    brs.BackColor = Color.Black;
                    PanelCenter(ref brs);
                    this.Controls.Add(brs);
                    Panel ResultsBox = new Panel();
                    ResultsBox.Size = new Size(this.Width / 3 - 30, this.Height / 3 - 30);
                    ResultsBox.BorderStyle = BorderStyle.FixedSingle;
                    ResultsBox.BackColor = Color.FromArgb(66,66,66);
                    ResultsBox.Location = new Point(10, 10);

                    brs.Controls.Add(ResultsBox);
                    
                  
                    Label lbpsc = new Label();
                    lbpsc.Size = new Size(ResultsBox.Width, ResultsBox.Height / 4);
                    lbpsc.Font = new Font("", 27f, System.Drawing.FontStyle.Bold);
                    lbpsc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lbpsc.Text = $"{player1nickname}  {player2nickname}";
                    lbpsc.ForeColor = Color.White;
                    lbpsc.Location = new Point(0, ResultsBox.Height/3-lbpsc.Height/2);
                    ResultsBox.Controls.Add(lbpsc);
                    Label lbsc = new Label();
                    lbsc.Size = new Size(ResultsBox.Width, ResultsBox.Height / 4);
                    lbsc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    lbsc.Font = new Font("", 27f, System.Drawing.FontStyle.Bold);
                    lbsc.ForeColor = Color.White;
                    lbsc.Text = $"{player1pt} - {player2pt}";
                    lbsc.Location = new Point(0, ResultsBox.Height/3*2-lbsc.Height/2);
                    ResultsBox.Controls.Add(lbsc);
                    await Task.Delay(3000);
                    this.Controls.Remove(brs);
                    
                    reset();
                    
                    return;
                }
                for (int i = 0; i<numSquares; i++)
                {
                    Squares[i].Enabled = false;
                }
                await Task.Delay(1000);
                
                if (CurrentPlayer == 1)
                {
                    CPisNow2();
                }
                else
                {
                    CPisNow1();
                }
                for (int i = 0; i < numSquares; i++)
                {
                    if (DiscoveredSquares[i] && !DefinedSquares[i])
                    {
                        Squares[i].Image = HiddenSquareImg;
                   
                        DiscoveredSquares[i] = false;
                        Squares[firstPos].Image = HiddenSquareImg;
                        DiscoveredSquares[firstPos] = false;
                    
                    }
                }
                
                for (int i = 0; i < numSquares; i++)
                {
                    Squares[i].Enabled = true;
                }
            }

          
          
            
                
            

            
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
            numSquares = maxpoints * 2;
            squareRoot = (int)Math.Sqrt(numSquares);
            buttonStartGame.Visible = false;
            panelSettingsGame.Visible = false;
            Panel setNicknamesPanel = new Panel();
            setNicknamesPanel.Name = "generalBox";
            setNicknamesPanel.Size = new Size(this.Width / 3, this.Height / 4);
            setNicknamesPanel.Location = new Point(this.Width / 2 - setNicknamesPanel.Width / 2, this.Height / 2 - setNicknamesPanel.Height / 2);
            setNicknamesPanel.BackColor = Color.White;
            setNicknamesPanel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(setNicknamesPanel);
            Panel nick1Box = new Panel();
            nick1Box.Name = "nick1Box";
            nick1Box.Size = new Size(setNicknamesPanel.Width / 2 - 4, setNicknamesPanel.Height - 4);
            nick1Box.Location = new Point(1, 1);
            nick1Box.BackColor = Color.Green;
            TextBox nick1insert = new TextBox();
            nick1insert.Name = "nick1Ins";
            nick1insert.Width = nick1Box.Width * 2/3;
            nick1insert.Location = new Point(nick1Box.Width/2-nick1insert.Width/2, nick1Box.Height/2-nick1insert.Height/2);
            nick1insert.Text = "Player1";
            Label n1text = new Label();
            n1text.Font = new Font("", 16F);
            n1text.Size = new Size(nick1Box.Width, 50);
            n1text.Location = new Point(0, nick1insert.Location.Y/2 - nick1Box.Location.Y/2-n1text.Height/2);
            n1text.Text = "Insert player 1 nickname";
            n1text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Button nick1Confirm = new Button();
            nick1Confirm.Size = new Size(nick1insert.Width, nick1insert.Height * 2);
            nick1Confirm.Location = new Point(nick1insert.Location.X, nick1insert.Location.Y+(nick1Box.Height-nick1insert.Location.Y)/2);
            nick1Confirm.Text = "Confirm";
            nick1Confirm.ForeColor = Color.White;
            nick1Box.Controls.Add(nick1insert);
            nick1Box.Controls.Add(nick1Confirm);
            nick1Box.Controls.Add(n1text);
            
            Panel nick2Box = new Panel();
            nick2Box.Name = "nick2Box";
            nick2Box.Size = new Size(setNicknamesPanel.Width / 2 - 4, setNicknamesPanel.Height - 4);
            nick2Box.Location = new Point(nick1Box.Width+5, 1);
            nick2Box.BackColor = Color.Green;
            TextBox nick2insert = new TextBox();
            nick2insert.Name = "nick2Ins";
            nick2insert.Width = nick2Box.Width * 2 / 3;
            nick2insert.Location = new Point(nick2Box.Width / 2 - nick2insert.Width / 2, nick2Box.Height / 2 - nick2insert.Height / 2);
            nick2insert.Text = "Player2";
            Label n2text = new Label();
            n2text.Font = new Font("", 16F);
            n2text.Size = new Size(nick2Box.Width, 50);
            n2text.Location = new Point(0, nick2insert.Location.Y / 2 - nick2Box.Location.Y / 2 - n2text.Height / 2);
            n2text.Text = "Insert player 2 nickname";
            n2text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Button nick2Confirm = new Button();
            nick2Confirm.Size = new Size(nick2insert.Width, nick2insert.Height * 2);
            nick2Confirm.Location = new Point(nick2insert.Location.X, nick2insert.Location.Y + (nick2Box.Height - nick2insert.Location.Y) / 2);
            nick2Confirm.Text = "Confirm";
            nick2Confirm.ForeColor = Color.White;
            nick2Box.Controls.Add(nick2insert);
            nick2Box.Controls.Add(nick2Confirm);
            nick2Box.Controls.Add(n2text);

            setNicknamesPanel.Controls.Add(nick1Box);
            setNicknamesPanel.Controls.Add(nick2Box);

            nick1Confirm.Click += new System.EventHandler(p1isNowReady);
            nick2Confirm.Click += new System.EventHandler(p2isNowReady);

        }
        private async void gameStart()
        {
            DiscoveredSquares = new bool[numSquares];
            DefinedSquares = new bool[numSquares];
            ColorPrevisionLabels = new Label[numSquares];
            Squares = new PictureBox[numSquares];
            

            allPositions = new int[numSquares];
            this.Controls.Remove(this.Controls.Find("generalBox", true)[0]);
            FlowLayoutPanel flw = new FlowLayoutPanel();
            flw.Visible = false;
            
            int defSize = Screen.PrimaryScreen.Bounds.Height / 8;
            int defPadding = defSize / 10;
            panelSettingsGame.Visible = false;



            flw.Size = new Size((squareRoot+1)*(defPadding*2+defSize), (squareRoot+1) * (defPadding * 2 + defSize));
            flw.Location = new Point(50, 50);
            flw.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(flw);

            this.Size = new Size(screenWidth, screenHeight);
            this.MaximizeBox = false;


            #region Pre-settaggio
           
            #region positions/discovers
            for (int i = 0; i < numSquares; i++)
            {
                allPositions[i] = i;
            }
            for (int i = 0; i < numSquares; i++)
            {
                DiscoveredSquares[i] = false;
            }
            for (int i = 0; i < numSquares; i++)
            {
                DefinedSquares[i] = false;
            }
            #endregion

            #endregion


            #region squaresDefinitions
            for (int a = 0; a < numSquares/2; a++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(defSize, defSize);
                x.SizeMode = PictureBoxSizeMode.StretchImage;
                Squares[a] = x;
                Squares[a].Margin = new Padding(defPadding);
                Squares[a].Image = HiddenSquareImg;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                Squares[a].Tag = InitImgs[a];


            }
            for (int a = numSquares/2; a < numSquares; a++)
            {
                PictureBox x = new PictureBox();
                x.Size = new Size(defSize, defSize);
                x.SizeMode = PictureBoxSizeMode.StretchImage;
                Squares[a] = x;
                Squares[a].Margin = new Padding(defPadding);
                Squares[a].Image = HiddenSquareImg;
                Squares[a].BorderStyle = BorderStyle.FixedSingle;
                Squares[a].Tag = InitImgs[a - numSquares / 2];
            }
            for (int x = 0; x < numSquares; x++)
            {      
                Random rd = new Random();
                int rc = rd.Next(0, numSquares);
                PictureBox tm = Squares[x];
                Squares[x] = Squares[rc];
                Squares[rc] = tm;
                await Task.Delay(1);


            }
            #endregion
            #region addControls...


            for (int a = 0; a < numSquares; a++)
            {

                flw.Controls.Add(Squares[a]);

            }
            int inRowBoxes = 1;
            int yPos = Squares[0].Location.Y;
            for (int n = 1; n < numSquares; n++)
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
            for (int n = inRowBoxes; n < numSquares; n = n + inRowBoxes)
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

            for (int i = 0; i < numSquares; i = i + inRowBoxes)
            {
                int p = 0;
                while (m < inRowBoxes * (column + 1) && m < numSquares)
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

           
            #endregion
            #region EventHandlers

            for (int i = 0; i < numSquares; i++)
            {
                Squares[i].Click += new System.EventHandler(Sq_Click);
                Squares[i].MouseEnter += new System.EventHandler(HoverInsideSquare);
                Squares[i].MouseLeave += new System.EventHandler(HoverExit);
            }




            #endregion
            buttonStartGame.Visible = false;
            #region labels Nickname and Points
            Label player1Label = new Label();
            player1Label.Name = "p1lbl";
            player1Label.AutoSize = true;
            player1Label.Font = new Font("", 13f);
            player1Label.Text = player1nickname;
            player1Label.Size = new Size(player1Label.Width, 26);
            player1Label.Location = new Point(0, 30);
            player1Label.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(player1Label);
            
            Label player1score = new Label();
            player1score.Name = "p1pts";
            player1score.AutoSize = true;
            player1score.Font = new Font("", 13f);
            player1score.Text = "0";
            player1score.Location = new Point(player1Label.Width-2, 30);
            player1score.Size = new Size(player1score.Width, 26);
            player1score.BorderStyle = BorderStyle.FixedSingle;
            player1score.Font = new Font("", 13f);
            
            this.Controls.Add(player1score);

            Label player2Label = new Label();
            player2Label.Name = "p2lbl";
            player2Label.AutoSize = true;
            player2Label.Font = new Font("", 13f);
            player2Label.Text = player2nickname;
            this.Controls.Add(player2Label);
            player2Label.Size = new Size(player2Label.Width, 26);
            player2Label.Location = new Point(this.Width-player2Label.Width, 30);
            player2Label.BorderStyle = BorderStyle.FixedSingle;
            
            
            Label player2score = new Label();
            player2score.Name = "p2pts";
            player2score.AutoSize = true;
            player2score.Font = new Font("", 13f);
            player2score.Text = "0";
            this.Controls.Add(player2score);
            player2score.Size = new Size(player2score.Width, 26);
            player2score.Location = new Point(player2Label.Location.X-player2score.Width, 30);
            player2score.BorderStyle = BorderStyle.FixedSingle;
            #endregion
            Random rch = new Random();
            CurrentPlayer = rch.Next(1, 3);
            if (CurrentPlayer == 1)
            {
                CPisNow1();
            }
            else
            {
                CPisNow2();
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;  
            this.Location = new Point(0, 0);
            this.Size = new Size(screenWidth, screenHeight);
            buttonStartGame.Location = new Point(screenWidth / 2 - buttonStartGame.Width / 2, screenHeight / 2 - buttonStartGame.Width / 2);
            panelSettingsGame.Location = new Point(Width/2-panelSettingsGame.Width/2, buttonStartGame.Location.Y+buttonStartGame.Size.Height+4);
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

        

        
        void p1isNowReady(object sender, EventArgs e)
        {
            p1status = true;
            (sender as Button).Text = "Confirmed";
            (sender as Button).Enabled = false;
            player1nickname = this.Controls.Find("generalBox", false)[0].Controls.Find("nick1Box", false)[0].Controls.Find("nick1Ins", false)[0].Text;
            
            if (p2status)
            {
                gameStart();
            }
        }

        void p2isNowReady(object sender, EventArgs e)
        {
            p2status = true;
            (sender as Button).Text = "Confirmed";
            (sender as Button).Enabled = false;
            player2nickname = this.Controls.Find("generalBox", false)[0].Controls.Find("nick2Box", false)[0].Controls.Find("nick2Ins", false)[0].Text;
            if (p1status)
            {
                gameStart();
            }
        }
        void keyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                exit(sender, e);
            }
            MessageBox.Show("diocane");
        }
        void CPisNow1()
        {
            CurrentPlayer = 1;
            this.Controls.Find("p1lbl", false)[0].BackColor = Color.Lime;
            this.Controls.Find("p1pts", false)[0].BackColor = Color.Lime;
            this.Controls.Find("p2lbl", false)[0].BackColor = Color.White;
            this.Controls.Find("p2pts", false)[0].BackColor = Color.White;
        }
        void CPisNow2()
        {
            CurrentPlayer = 2;
            this.Controls.Find("p2lbl", false)[0].BackColor = Color.Lime;
            this.Controls.Find("p2pts", false)[0].BackColor = Color.Lime;
            this.Controls.Find("p1lbl", false)[0].BackColor = Color.White;
            this.Controls.Find("p1pts", false)[0].BackColor = Color.White;
        }
        void reset()
        {
            Squares = new PictureBox[28];
            p1status = false;
            p2status = false;
            this.Controls.Remove(this.Controls.Find("p1pts", false)[0]);
            this.Controls.Remove(this.Controls.Find("p1lbl", false)[0]);
            this.Controls.Remove(this.Controls.Find("p2pts", false)[0]);
            this.Controls.Remove(this.Controls.Find("p2lbl", false)[0]);
            player1pt = 0;
            player2pt = 0;
           
            buttonStartGame.Visible = true;
            panelSettingsGame.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maxpoints = int.Parse(textBoxBX.Text);
            if (maxpoints >= 13) return;
            maxpoints = maxpoints + 2;
            textBoxBX.Text = maxpoints.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maxpoints = int.Parse(textBoxBX.Text);
            if (maxpoints <= 3) return;
            maxpoints = maxpoints - 2;
            textBoxBX.Text = maxpoints.ToString();
        }
        void PanelCenter(ref Panel panel)
        {
            panel.Location = new Point(this.Width/2-panel.Width/2, this.Height/2-panel.Height/2);
        }

        
    }
}

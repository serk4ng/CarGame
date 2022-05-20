using System.Media;
namespace Game
{
    public partial class Form1 : Form
    {
        public int point = 0;
        public int crashCounter = 0;
        public int health = 3;
        public bool isCarOne = true;
        public int level = 1;
        public System.Windows.Forms.Timer coinTimer = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer healthTimer = new System.Windows.Forms.Timer();
        public SoundPlayer coinSound = new SoundPlayer(Properties.Resources.coin_sound);
        SoundPlayer player = new SoundPlayer(Properties.Resources.car);
        public System.Windows.Forms.Timer coinEatTimer = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer healthEatTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            CreateDynamicButton(100, 40);
            CreateDynamicButton(260, 40);
            RunCoin();
            RunHealth();
            coinSound.Load();
            player.Load();
        }

        private void btnCar_KeyDown(object sender, KeyEventArgs e)
        {

            //arrow keys
            if (e.KeyCode == Keys.A)
            {
                btnCar.Left -= 20;
            }
            else if (e.KeyCode == Keys.D)
            {
                btnCar.Left += 20;
            }
            else if (e.KeyCode == Keys.W)
            {
                btnCar.Top -= 20;
            }
            else if (e.KeyCode == Keys.S)
            {
                btnCar.Top += 20;
            }
            else if (e.KeyCode == Keys.Escape)
            {

                timer1.Enabled = false;
                pictureBox1.Enabled = false;
                var dialogResult = MessageBox.Show("Continue ?", "Paused", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                switch (dialogResult)
                {
                    case DialogResult.Cancel:
                        Application.Exit();
                        break;
                    case DialogResult.OK:
                        timer1.Enabled = true;
                        pictureBox1.Enabled = true;
                        break;
                }

            }
        }


        private void CreateDynamicButton(int x, int y)
        {

            Button dynamicButton = new Button();

            dynamicButton.BackgroundImage = Properties.Resources.pngwing_com;
            dynamicButton.BackgroundImageLayout = ImageLayout.Stretch;
            dynamicButton.FlatAppearance.BorderSize = 0;
            dynamicButton.FlatStyle = FlatStyle.Popup;
            dynamicButton.ForeColor = Color.Transparent;
            dynamicButton.Location = new Point(x, y);
            dynamicButton.Name = "DynamicButton";
            dynamicButton.Size = new Size(37, 67);
            dynamicButton.TabIndex = 0;
            dynamicButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            dynamicButton.UseVisualStyleBackColor = false;
            dynamicButton.BackColor = Color.DarkSlateGray;
            dynamicButton.Enabled = false;

            timer1.Interval = 20;
            timer1.Start();
            Controls.Add(dynamicButton);
            timer1.Tick += new EventHandler(
                delegate (object sender, EventArgs e)
                {
                    switch (point)
                    {
                        case int n when n < 500:
                            dynamicButton.Top += 4;
                            break;
                        case int n when n > 500 && n < 2000:
                            dynamicButton.Top += 6;
                            level = 2;
                            break;
                        case int n when n >= 2000 && n < 4000:
                            dynamicButton.Top += 8;
                            level = 3;
                            break;
                        case int n when n >= 4000 && n < 6000:
                            dynamicButton.Top += 10;
                            level = 4;
                            break;
                        case int n when n >= 6000:
                            dynamicButton.Top += 12;
                            level = 5;
                            break;
                    }

                    lblLevel.Text = "Level : " + level;

                    point++;
                    carPoint.Text = "Point: " + point;


                    List<Control> carList = new List<Control>();
                    foreach (Control item in Controls.OfType<Control>().ToList())
                    {

                        if (item.Name == "DynamicButton")
                        {
                            carList.Add(item);
                        }

                    }

                    if (carList[0].Bounds.IntersectsWith(carList[1].Bounds))
                    {
                        carList[0].Left = carList[0].Left - 30;
                        carList[1].Left = carList[1].Left + 30;
                    }


                    if (dynamicButton.Top > this.Height)
                    {

                        Random rnd = new Random();
                        if (isCarOne)
                        {
                            dynamicButton.Location = new Point(rnd.Next(30, 250), rnd.Next(40, 200));
                            isCarOne = false;
                        }
                        else
                        {
                            dynamicButton.Location = new Point(rnd.Next(30, 250) + 100, rnd.Next(40, 200));
                            isCarOne = true;
                        }

                        dynamicButton.Top = 0;
                    }
                    if (btnCar.Bottom > this.Height || btnCar.Left < 20 || btnCar.Right > this.Width - 20 || btnCar.Top < 50)
                    {
                        btnCar.Location = new Point(180, 240);
                    }
                    if (dynamicButton.Bounds.IntersectsWith(btnCar.Bounds))
                    {
                        point -= 100;
                        carPoint.Text = "Point: " + point;
                        carPoint.ForeColor = Color.Red;

                        SoundPlayer player2 = new SoundPlayer(Path.Combine(this.GetType().Assembly.Location, "../../../../Assets", "crash.wav"));

                        player2.Load();
                        if (player2.IsLoadCompleted)
                        {
                            player2.PlaySync();

                            player.Play();
                            player.PlayLooping();
                        }

                        health--;
                        lblHealth.Text = "Health: " + health;
                        if (health == 0)
                        {
                            timer1.Stop();
                            var dialogResult = MessageBox.Show("Your Point: " + point, "Game Over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            switch (dialogResult)
                            {
                                case DialogResult.Cancel:
                                    Application.Exit();
                                    break;
                                case DialogResult.Retry:
                                    Application.Restart();
                                    break;
                            }
                        }

                        foreach (Control item in Controls.OfType<Control>().ToList())
                        {
                            if (item.Name == "DynamicButton")
                            {
                                Random rnd = new Random();
                                item.Location = new Point(rnd.Next(30, 250), rnd.Next(30, 50));

                            }

                        }


                        btnCar.Location = new Point(180, 240);
                    }

                    else
                    {
                        carPoint.ForeColor = Color.Green;
                    }



                }
            );
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            player.Play();
            player.PlayLooping();
            carPoint.Text = "Point: " + point;
            lblHealth.Text = "Health: " + health;
            carPoint.ForeColor = Color.Green;
            this.CenterToScreen();
            pictureBox1.SendToBack();
            btnCar.BackColor = Color.DarkSlateGray;

        }

        public void RunCoin()
        {
            coinTimer.Interval = 5000;
            coinTimer.Start();
            coinTimer.Tick += new EventHandler(
                delegate (object sender2, EventArgs e2)
                {
                    Random rnd = new Random();
                    int x = rnd.Next(30, 250);
                    int y = rnd.Next(30, 50);
                    CreateCoin(x, y);
                }
            );
        }

        public void RunHealth()
        {
            healthTimer.Interval = 15000;
            healthTimer.Start();
            healthTimer.Tick += new EventHandler(
                delegate (object sender2, EventArgs e2)
                {
                    Random rnd = new Random();
                    int x = rnd.Next(30, 250);
                    int y = rnd.Next(30, 50);
                    CreateHealth(x, y);
                }
            );
        }

        private void CreateCoin(int x, int y)
        {
            Label lblCoin = new Label();
            lblCoin.BackColor = Color.DarkSlateGray;
            lblCoin.BackgroundImage = Properties.Resources.coin;
            lblCoin.BackgroundImageLayout = ImageLayout.Stretch;

            lblCoin.FlatStyle = FlatStyle.Popup;

            lblCoin.Location = new Point(x, y);
            lblCoin.Name = "Coin";
            lblCoin.Size = new Size(20, 20);
            lblCoin.TabIndex = 0;
            lblCoin.Enabled = false;


            Controls.Add(lblCoin);
            lblCoin.BringToFront();

            timer1.Tick += new EventHandler(
                delegate (object sender, EventArgs e)
                {

                    lblCoin.Top += 6;
                    if (lblCoin.Top > this.Height)
                    {
                        lblCoin.Dispose();
                    }
                    if (lblCoin.Bounds.IntersectsWith(btnCar.Bounds))
                    {
                        lblCoin.Left = 1000;
                        Controls.Remove(lblCoin);

                        coinSound.Play();

                        coinEatTimer.Interval = 350;
                        coinEatTimer.Start();
                        coinEatTimer.Tick += new EventHandler(
                            delegate (object sender3, EventArgs e3)
                            {
                                coinEatTimer.Stop();
                                player.Play();
                                player.PlayLooping();
                            }
                        );

                        point += 100;
                        carPoint.Text = "Point: " + point;

                    }

                }
            );
        }

        private void CreateHealth(int x, int y)
        {
            Label giveHealth = new Label();
            giveHealth.BackColor = Color.DarkSlateGray;
            giveHealth.BackgroundImage = Properties.Resources.health;
            giveHealth.BackgroundImageLayout = ImageLayout.Stretch;

            giveHealth.FlatStyle = FlatStyle.Popup;

            giveHealth.Location = new Point(x, y);
            giveHealth.Name = "Health";
            giveHealth.Size = new Size(20, 20);
            giveHealth.TabIndex = 0;
            giveHealth.Enabled = false;


            Controls.Add(giveHealth);
            giveHealth.BringToFront();

            timer1.Tick += new EventHandler(
                delegate (object sender, EventArgs e)
                {

                    giveHealth.Top += 6;
                    if (giveHealth.Top > this.Height)
                    {
                        giveHealth.Dispose();
                    }
                    if (giveHealth.Bounds.IntersectsWith(btnCar.Bounds))
                    {
                        giveHealth.Left = 1000;
                        Controls.Remove(giveHealth);

                        coinSound.Play();

                        healthEatTimer.Interval = 350;
                        healthEatTimer.Start();
                        healthEatTimer.Tick += new EventHandler(
                            delegate (object sender3, EventArgs e3)
                            {
                                healthEatTimer.Stop();
                                player.Play();
                                player.PlayLooping();

                            }
                        );
                        health++;
                    }
                    lblHealth.Text = "Health: " + health;
                }
            );
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCar_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void lblLevel_Click(object sender, EventArgs e)
        {

        }

        private void lblHealth_Click(object sender, EventArgs e)
        {

        }
    }
}
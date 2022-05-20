namespace Game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.carPoint = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblHealth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCar
            // 
            this.btnCar.BackColor = System.Drawing.Color.Transparent;
            this.btnCar.BackgroundImage = global::Game.Properties.Resources.pngwing_com;
            this.btnCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCar.FlatAppearance.BorderSize = 0;
            this.btnCar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCar.ForeColor = System.Drawing.Color.Transparent;
            this.btnCar.Location = new System.Drawing.Point(178, 286);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(37, 67);
            this.btnCar.TabIndex = 0;
            this.btnCar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCar.UseVisualStyleBackColor = false;
            this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
            this.btnCar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCar_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 369);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // carPoint
            // 
            this.carPoint.Location = new System.Drawing.Point(299, -3);
            this.carPoint.Name = "carPoint";
            this.carPoint.Size = new System.Drawing.Size(100, 23);
            this.carPoint.TabIndex = 0;
            this.carPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLevel
            // 
            this.lblLevel.Location = new System.Drawing.Point(-1, -3);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(100, 23);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.Text = "Level : 1";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHealth
            // 
            this.lblHealth.Location = new System.Drawing.Point(-1, 20);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(100, 23);
            this.lblHealth.TabIndex = 3;
            this.lblHealth.Text = "Health:";
            this.lblHealth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHealth.Click += new System.EventHandler(this.lblHealth_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(399, 365);
            this.Controls.Add(this.lblHealth);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.carPoint);
            this.Controls.Add(this.btnCar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Car Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnCar;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Label carPoint;
        private Label lblLevel;
        private Label lblHealth;
    }
}
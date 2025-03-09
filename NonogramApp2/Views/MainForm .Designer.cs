using System.Windows.Forms;

namespace NonogramApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label welcomeLabel;
        private Button loginButton;
        private Button registerButton;
        private Label popularLabel;
        private Button btnStartGame;
        private Button logoutButton; // Uitloggen knop

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.Button button2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.popularLabel = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            button2.AutoSize = true;
            button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button2.Location = new System.Drawing.Point(311, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(67, 30);
            button2.TabIndex = 3;
            button2.Text = "Profile";
            button2.UseVisualStyleBackColor = true;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(-3, 52);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(337, 48);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welkom bij de Nonogram Applicatie\n\nSpeel uitdagende puzzels en verbeter je vaardi" +
    "gheden!";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.loginButton.Location = new System.Drawing.Point(576, 70);
            this.loginButton.Margin = new System.Windows.Forms.Padding(2);
            this.loginButton.Name = "loginButton";
            this.loginButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.loginButton.Size = new System.Drawing.Size(100, 30);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Inloggen";
            this.loginButton.Click += new System.EventHandler(this.Login_Click);
            // 
            // registerButton
            // 
            this.registerButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.registerButton.Location = new System.Drawing.Point(703, 70);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 30);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Registreren";
            this.registerButton.Click += new System.EventHandler(this.Register_Click);
            // 
            // popularLabel
            // 
            this.popularLabel.Location = new System.Drawing.Point(20, 143);
            this.popularLabel.Name = "popularLabel";
            this.popularLabel.Size = new System.Drawing.Size(200, 30);
            this.popularLabel.TabIndex = 4;
            this.popularLabel.Text = "Populaire Puzzels";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartGame.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(380, 511);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(211, 40);
            this.btnStartGame.TabIndex = 5;
            this.btnStartGame.Text = "Speel Nu";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.logoutButton.Enabled = false;
            this.logoutButton.Location = new System.Drawing.Point(830, 70);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(100, 30);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Uitloggen";
            this.logoutButton.Click += new System.EventHandler(this.Logout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(246, 189);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(2080, 1024);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 215);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.button1.Location = new System.Drawing.Point(222, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoEllipsis = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 8, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nonogram Applicatie";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(2080, 46);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(776, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(974, 46);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(974, 573);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.popularLabel);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.logoutButton);
            this.MaximumSize = new System.Drawing.Size(2080, 1024);
            this.MinimumSize = new System.Drawing.Size(790, 620);
            this.Name = "MainForm";
            this.Text = "Nonogram Applicatie";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private PictureBox pictureBox1;
        private Button button1;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}

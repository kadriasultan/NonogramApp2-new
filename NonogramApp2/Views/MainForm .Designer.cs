using System.Windows.Forms;

namespace NonogramApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem homeMenuItem;
        private ToolStripMenuItem profileMenuItem;
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.homeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.popularLabel = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button(); // Uitloggen knop
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();

            // menuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.homeMenuItem,
                this.profileMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;

            // homeMenuItem
            this.homeMenuItem.Name = "homeMenuItem";
            this.homeMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeMenuItem.Text = "Home";
            this.homeMenuItem.Click += new System.EventHandler(this.Home_Click);

            // profileMenuItem
            this.profileMenuItem.Name = "profileMenuItem";
            this.profileMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileMenuItem.Text = "Profiel";
            this.profileMenuItem.Click += new System.EventHandler(this.Profile_Click);

            // welcomeLabel
            this.welcomeLabel.Location = new System.Drawing.Point(94, 79);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(600, 60);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welkom bij de Nonogram Applicatie\n\nSpeel uitdagende puzzels en verbeter je vaardi" +
            "gheden!";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // loginButton
            this.loginButton.Location = new System.Drawing.Point(594, 27);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 30);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Inloggen";
            this.loginButton.Click += new System.EventHandler(this.Login_Click);

            // registerButton
            this.registerButton.Location = new System.Drawing.Point(700, 27);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 30);
            this.registerButton.TabIndex = 3;
            this.registerButton.Text = "Registreren";
            this.registerButton.Click += new System.EventHandler(this.Register_Click);

            // popularLabel
            this.popularLabel.Location = new System.Drawing.Point(303, 198);
            this.popularLabel.Name = "popularLabel";
            this.popularLabel.Size = new System.Drawing.Size(200, 30);
            this.popularLabel.TabIndex = 4;
            this.popularLabel.Text = "Populaire Puzzels";

            // btnStartGame
            this.btnStartGame.Location = new System.Drawing.Point(307, 290);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(150, 40);
            this.btnStartGame.TabIndex = 5;
            this.btnStartGame.Text = "Speel Nu";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.BtnStartGame_Click);

            // logoutButton
            this.logoutButton.Location = new System.Drawing.Point(700, 63); // Positie van de Uitloggen knop
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(100, 30);
            this.logoutButton.TabIndex = 6;
            this.logoutButton.Text = "Uitloggen";
            this.logoutButton.Click += new System.EventHandler(this.Logout_Click);
            this.logoutButton.Enabled = false; // Standaard uitgeschakeld

            // MainForm
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.popularLabel);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.logoutButton); // Voeg de uitlogknop toe aan de form
            this.Name = "MainForm";
            this.Text = "Nonogram Applicatie";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

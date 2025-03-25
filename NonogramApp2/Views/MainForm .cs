using NonogramApp.Views;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NonogramApp
{
    public partial class MainForm : Form
    {
        private bool isLoggedIn = false;
        private PictureBox nonogramPictureBox;
        private PictureBox welcomeImagePictureBox;

        public MainForm()
        {
            InitializeComponent();
            ApplyStyles();
            this.Resize += MainForm_Resize;

            // Initialiseren van PictureBox voor het weergeven van de nonogram
            nonogramPictureBox = new PictureBox
            {
                Location = new Point(20, 200),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.White
            };
            this.Controls.Add(nonogramPictureBox);

            // Initialiseren van PictureBox voor de welkomstafbeelding
            welcomeImagePictureBox = new PictureBox
            {
                Location = new Point(20, 50),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };
            this.Controls.Add(welcomeImagePictureBox);
        }

        private void ApplyStyles()
        {
            // Achtergrondkleur met gradient
            this.BackColor = Color.FromArgb(240, 240, 240); // Lichtgrijs
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Algemeen uiterlijk van knoppen
            foreach (var btn in new Button[] { btnStartGame, loginButton, registerButton, logoutButton })
            {
                btn.BackColor = Color.FromArgb(52, 152, 219); // Blauw
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Height = 50;
                btn.Width = this.ClientSize.Width / 3 - 20; // Breedte past zich aan bij formaat van het scherm
                btn.Margin = new Padding(10);
                btn.Padding = new Padding(10);
                btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right; // Zorgt ervoor dat knoppen zich aanpassen

                // Hover-effect
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185); // Donkerder blauw

                // Ronde hoeken voor knoppen
                btn.Region = new Region(CreateRoundedRectangle(btn.ClientRectangle, 20));
            }

            // Logout knop met een andere kleur
            logoutButton.BackColor = Color.FromArgb(231, 76, 60); // Rood

            // Welkomstlabel stijlen
            welcomeLabel.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.FromArgb(44, 62, 80); // Donkerblauw
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;
            welcomeLabel.Margin = new Padding(20);
            welcomeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Aanpassen van knoppenbreedte bij resizing van het form
            foreach (var btn in new Button[] { btnStartGame, loginButton, registerButton, logoutButton })
            {
                btn.Width = this.ClientSize.Width / 3 - 20;  // Breedte past zich aan bij formaat van het scherm
            }

            // Aanpassen van de grootte van de nonogram en welkomstafbeelding
            if (nonogramPictureBox != null)
            {
                nonogramPictureBox.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height / 2);
            }

            if (welcomeImagePictureBox != null)
            {
                welcomeImagePictureBox.Size = new Size(this.ClientSize.Width - 40, 120);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToggleGameButton();
            LoadWelcomeImage(); // Laad afbeelding wanneer het formulier wordt geladen
        }

        private void LoadWelcomeImage()
        {
            try
            {
                // Pad naar de welkomstafbeelding (lokaal opgeslagen)
                string imagePath = @"C:\path\to\your\downloaded\image.png"; // Pas dit pad aan naar de locatie van de afbeelding

                // Probeer de afbeelding in de PictureBox te laden
                welcomeImagePictureBox.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                // Als er een fout is bij het laden van de afbeelding
                MessageBox.Show($"Fout bij het laden van de afbeelding: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToggleGameButton()
        {
            btnStartGame.Enabled = isLoggedIn;
            logoutButton.Enabled = isLoggedIn;
            loginButton.Enabled = !isLoggedIn;
            registerButton.Enabled = !isLoggedIn;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                isLoggedIn = true;
                ToggleGameButton();
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void GenerateNonogram()
        {
            int gridSize = 10;
            int cellSize = 40;
            Bitmap bmp = new Bitmap(gridSize * cellSize, gridSize * cellSize);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Pen gridPen = new Pen(Color.Black, 1);
                SolidBrush fillBrush = new SolidBrush(Color.Black);
                Random rnd = new Random();

                for (int y = 0; y < gridSize; y++)
                {
                    for (int x = 0; x < gridSize; x++)
                    {
                        if (rnd.Next(2) == 1)
                        {
                            g.FillRectangle(fillBrush, x * cellSize, y * cellSize, cellSize, cellSize);
                        }
                        g.DrawRectangle(gridPen, x * cellSize, y * cellSize, cellSize, cellSize);
                    }
                }
            }
            nonogramPictureBox.Image = bmp; // Weergave van de gegenereerde nonogram
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Je moet eerst inloggen om het spel te starten.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerateNonogram(); // Genereer een nieuw nonogram
            MessageBox.Show("Het spel start nu!", "Spel Gestart", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uitgelogd!", "Uitgelogd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isLoggedIn = false;
            ToggleGameButton();
        }

        // Methode om een afgeronde rechthoek te maken voor knoppen
        private static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(rect.Left, rect.Top + radius, rect.Left, rect.Bottom - radius);
            path.AddArc(rect.Left, rect.Bottom - radius * 2, radius * 2, radius * 2, 180, 90);
            path.AddLine(rect.Left, rect.Bottom, rect.Right, rect.Bottom);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 270, 90);
            path.AddLine(rect.Right, rect.Bottom - radius, rect.Right, rect.Top + radius);
            path.AddArc(rect.Right - radius * 2, rect.Top, radius * 2, radius * 2, 0, 90);
            path.AddLine(rect.Right, rect.Top, rect.Left, rect.Top);
            return path;
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}

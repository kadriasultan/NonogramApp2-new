using NonogramApp.Views;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
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
            // Basisstijl voor alle knoppen (behoudt bestaande grootte en positie)
            Action<Button, Color, Color, int> styleButton = (btn, bgColor, hoverColor, borderRadius) =>
            {
                // Behoud bestaande grootte en positie
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = bgColor;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;

                // Subtiel hover-effect (donkerder versie van hoofdkleur)
                btn.FlatAppearance.MouseOverBackColor = hoverColor;
                btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(hoverColor, 0.2f);

                // Behoud bestaande afmetingen
                btn.Height = 46; // Subtiele hoogte-aanpassing voor betere proporties
                btn.Width = Math.Max(160, btn.Width); // Minimale breedte

                // Verfijnde ronde hoeken (iets subtieler dan voorheen)
                btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, borderRadius, borderRadius));
            };

            // Licht aangepast kleurenschema (iets verzadigder)
            Color primaryBlue = Color.FromArgb(0, 122, 204);
            Color hoverBlue = Color.FromArgb(0, 96, 180);
            Color accentColor = Color.FromArgb(255, 140, 0);
            Color hoverAccent = Color.FromArgb(230, 120, 0);
            Color dangerRed = Color.FromArgb(220, 60, 60);
            Color hoverRed = Color.FromArgb(190, 50, 50);

            // Pas stijlen toe met subtiele aanpassingen
            styleButton(btnStartGame, accentColor, hoverAccent, 8);
            styleButton(loginButton, primaryBlue, hoverBlue, 8);
            styleButton(registerButton, Color.FromArgb(80, 80, 80), Color.FromArgb(60, 60, 60), 8);
            styleButton(logoutButton, dangerRed, hoverRed, 8);

            // Text padding aanpassing voor betere balans
            foreach (var btn in new[] { btnStartGame, loginButton, registerButton, logoutButton })
            {
                btn.Padding = new Padding(8, 4, 8, 4);
            }

            // Label stijl verfijning (subtiele aanpassing)
            welcomeLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            welcomeLabel.ForeColor = Color.Black;
        }

        // Ondersteunende methode voor ronde hoeken (efficiëntere versie)
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
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

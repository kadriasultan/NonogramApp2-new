using NonogramApp.Views;
using System;
using System.Windows.Forms;

namespace NonogramApp
{
    public partial class MainForm : Form
    {
        private bool isLoggedIn = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToggleGameButton();  // Zorg ervoor dat knoppen goed worden ingesteld bij het laden
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
            // Wanneer de gebruiker op Inloggen klikt, wordt het LoginForm geopend
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)  // Als het LoginForm met OK wordt gesloten
            {
                isLoggedIn = true;
                ToggleGameButton();
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            // Open het RegisterForm bij het klikken op de Register knop
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();  // ShowDialog zorgt ervoor dat het formulier modal is
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            if (!isLoggedIn)
            {
                MessageBox.Show("Je moet eerst inloggen om het spel te starten.");
                return;
            }
            MessageBox.Show("Het spel start nu!");
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uitgelogd!");
            isLoggedIn = false;
            ToggleGameButton();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Home menu item clicked!");
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Profile menu item clicked!");
        }
    }
}

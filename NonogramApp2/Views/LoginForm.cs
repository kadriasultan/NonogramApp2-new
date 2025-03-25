using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NonogramApp.Models;

namespace NonogramApp.Views
{
    public partial class LoginForm : Form
    {
        private DataManager _dataManager;  // Gebruik DataManager
        private string usersFilePath = @"Data\users.json";

        public LoginForm()
        {
            InitializeComponent();
            _dataManager = new DataManager();  // Maak een instantie van DataManager
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Controleer of de velden niet leeg zijn
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vul zowel gebruikersnaam als wachtwoord in!");
                return;
            }

            // Laad de gebruikers via DataManager
            var users = _dataManager.LoadUsersData();

            // Controleer of de gebruikersnaam en wachtwoord correct zijn
            var user = users.Find(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                MessageBox.Show("Inloggen succesvol!");
                this.DialogResult = DialogResult.OK;  // Sluit het loginformulier met OK
                this.Close();  // Sluit het formulier na succesvolle login
            }
            else
            {
                MessageBox.Show("Ongeldige gebruikersnaam of wachtwoord.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NonogramApp.Models; // Zorg ervoor dat je de juiste namespace hebt voor je User-model

namespace NonogramApp.Views
{
    public partial class RegisterForm : Form
    {
        // Dit is een lijst van geregistreerde gebruikers (je zou dit in een database moeten opslaan in een echte toepassing)
        private static List<User> registeredUsers = new List<User>();

        public RegisterForm()
        {
            InitializeComponent();
        }

        // Laadfunctie, hier kun je initialisatiecode toevoegen
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Eventuele initialisatiecode hier
        }

        // Verwerkt de registratie van de gebruiker
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // Haal de waarden op uit de tekstvakken
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Controleer of de gebruiker alle velden heeft ingevuld
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vul zowel gebruikersnaam als wachtwoord in!");
                return;
            }

            // Controleer of het wachtwoord overeenkomt met de bevestiging
            if (password != confirmPassword)
            {
                MessageBox.Show("Wachtwoorden komen niet overeen.");
                return;
            }

            // Controleer of de gebruikersnaam al in gebruik is
            if (registeredUsers.Exists(user => user.Username == username))
            {
                MessageBox.Show("Gebruikersnaam is al in gebruik.");
                return;
            }

            // Hash het wachtwoord (je kunt een veiligere hashfunctie gebruiken, zoals SHA256)
            string passwordHash = HashPassword(password);

            // Maak een nieuwe gebruiker aan en voeg deze toe aan de lijst
            User newUser = new User(username, passwordHash);
            registeredUsers.Add(newUser);

            // Geef een succesbericht weer
            MessageBox.Show("Account succesvol geregistreerd!");

            // Optioneel: Sluit het formulier of reset de velden
            this.Close();
        }

        // Simpele wachtwoord-hashfunctie (gebruik een veiligere optie in een echte applicatie)
        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
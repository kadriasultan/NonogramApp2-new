using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NonogramApp.Models; // Zorg dat we User kunnen gebruiken

namespace NonogramApp
{
    public class DataManager
    {
        // Dynamisch pad naar het JSON-bestand (maakt je code flexibeler)
        private readonly string usersFilePath;

        public DataManager()
        {
            // Zorgt ervoor dat de JSON altijd op de juiste plek wordt gevonden
            usersFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.json");

            // Controleer of de map bestaat, anders maak je deze aan
            string directoryPath = Path.GetDirectoryName(usersFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Controleer of het JSON-bestand bestaat, anders maak je een leeg bestand aan
            if (!File.Exists(usersFilePath))
            {
                File.WriteAllText(usersFilePath, "[]"); // Leeg JSON-bestand maken
            }
        }

        /// <summary>
        /// Registreert een nieuwe gebruiker en slaat deze op in users.json
        /// </summary>
        public void RegisterUser(string username, string password)
        {
            List<User> users = LoadUsersData();

            if (!users.Exists(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                users.Add(new User(username, password));
                SaveUserData(users);
                Console.WriteLine("✅ Registratie succesvol!");
            }
            else
            {
                Console.WriteLine("⚠ Gebruikersnaam bestaat al!");
            }
        }

        /// <summary>
        /// Laadt de gebruikersdata uit users.json
        /// </summary>
        public List<User> LoadUsersData()
        {
            try
            {
                if (!File.Exists(usersFilePath))
                {
                    return new List<User>(); // Bestaat het bestand niet? Geef een lege lijst terug.
                }

                string jsonData = File.ReadAllText(usersFilePath);
                return JsonConvert.DeserializeObject<List<User>>(jsonData) ?? new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Fout bij het laden van gebruikersdata: {ex.Message}");
                return new List<User>(); // Voorkomt crash bij JSON-fout
            }
        }

        /// <summary>
        /// Slaat de gebruikersdata op in users.json
        /// </summary>
        private void SaveUserData(List<User> users)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(usersFilePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Fout bij het opslaan van gebruikersdata: {ex.Message}");
            }
        }
    }
}

// Helpers/JsonHelper.cs
using NonogramApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace NonogramApp.Helpers
{
    public static class JsonHelper
    {
        private static string filePath = @"Data\users.json";  // Pad naar je JSON bestand

        public static List<User> ReadUsersFromJson()
        {
            // Controleer of het bestand bestaat
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);  // Lees de JSON-data uit het bestand
                return JsonConvert.DeserializeObject<List<User>>(jsonData);  // Converteer de JSON naar een lijst van User-objecten
            }
            return new List<User>();  // Geef een lege lijst terug als het bestand niet bestaat
        }

        public static void WriteUsersToJson(List<User> users)
        {
            // Zet de lijst van gebruikers om naar JSON
            string jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);  // Mooi geformatteerde JSON
            File.WriteAllText(filePath, jsonData);  // Schrijf de JSON-data naar het bestand
        }
    }
}

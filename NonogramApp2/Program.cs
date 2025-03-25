using NonogramApp;
using NonogramApp.Views;
using System;
using System.Windows.Forms;

namespace NonogramApp2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // 🔹 Test JSON-gegevens laden en opslaan
            DataManager dataManager = new DataManager();

            Console.WriteLine("✅ Test: Laden van gebruikers...");
            var users = dataManager.LoadUsersData();

            if (users.Count == 0)
            {
                Console.WriteLine("⚠️ Geen gebruikers gevonden, toevoegen...");
                dataManager.RegisterUser("testuser@example.com", "wachtwoord123");
            }
            else
            {
                Console.WriteLine($"📂 {users.Count} gebruikers gevonden.");
            }

            // 🔹 Start de applicatie
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

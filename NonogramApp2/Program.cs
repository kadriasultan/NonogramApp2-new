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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // Dit opent het RegisterForm
       
         
        }
    }
}

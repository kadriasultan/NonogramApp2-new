using System;
using System.Windows.Forms;

namespace NonogramApp.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registration is not implemented yet.");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}

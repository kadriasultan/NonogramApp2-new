using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonogramApp.Views
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }
    
      private void StartGame()
        {
            // Logica om het spel te starten
        }

        private void EndGame()
        {
            // Logica om het spel te beëindigen
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

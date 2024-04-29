using System;
using System.Windows.Forms;

namespace Blissfull_Convenience
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Enter_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new recover();
            loginForm.Show();
        }
    }
}

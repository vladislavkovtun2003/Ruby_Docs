using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Docs
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
            this.textBoxUsername.Text = "admin";
            this.textBoxPassword.Text = "admin";
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm MainForm = new MainForm(this.textBoxUsername.Text, this.textBoxPassword.Text, true);
        }

        private void Auth_FormClosing(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

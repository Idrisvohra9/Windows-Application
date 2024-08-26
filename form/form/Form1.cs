using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
namespace form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //button1.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username.Length >= 1 && password.Length >= 1)
            {
                if (password.Length < 8)
                {
                    MessageBox.Show("Password is too short", "Warning");
                }
                else if (!password.Any(char.IsDigit))
                {
                    MessageBox.Show("Password does not contain number!", "Warning");
                }
                else
                {
                    MessageBox.Show("Username: " + username + "\n" + "Password: " + password, "Your data");
                }
            }
        }
    }
}

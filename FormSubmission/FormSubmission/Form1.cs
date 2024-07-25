using System;
using System.Windows.Forms;

namespace FormSubmission
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string email = emailField.Text;
            if (name.Length > 0 && email.Length > 0)
            {
                string message = $"Name: {name}\nEmail: {email}";
                MessageBox.Show(message, "Submitted Information");
            }
            else
            {
                MessageBox.Show("Empty form cannot be submitted!", "Error");
            }
        }
    }
}

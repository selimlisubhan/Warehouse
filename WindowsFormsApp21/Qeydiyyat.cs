using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
    public partial class Qeydiyyat : Form
    {
        public Qeydiyyat()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                var y = db.Users.ToList().Where(x => (x.UserName == textBox1.Text)).ToList();
                if (y.Count == 0)
                {
                    User user1 = new User() { UserName = textBox1.Text, Password = textBox2.Text, Name = textBox4.Text, Surname = textBox5.Text };
                    db.Users.Add(user1);
                    db.SaveChanges();
                    Close();
                }
                else
                {
                    MessageBox.Show("The user already exists");
                }
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Username is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Password is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Re-Password is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Name is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                errorProvider1.SetError(textBox5, "Surname is empty");
            }
            else
            {
                errorProvider1.Clear();
            }

            if ((textBox2.Text == textBox3.Text) && !(string.IsNullOrWhiteSpace(textBox1.Text)) && !(string.IsNullOrWhiteSpace(textBox2.Text)) && !(string.IsNullOrWhiteSpace(textBox3.Text)) && !(string.IsNullOrWhiteSpace(textBox4.Text)) && !(string.IsNullOrWhiteSpace(textBox5.Text)))
            {
                button1.Enabled = true;
            } else
                button1.Enabled = false;
        }

        private void Qeydiyyat_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Username is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Password is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Re-Password is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Name is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                errorProvider1.SetError(textBox5, "Surname is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if ((textBox2.Text == textBox3.Text) && !(string.IsNullOrWhiteSpace(textBox1.Text)) && !(string.IsNullOrWhiteSpace(textBox2.Text)) && !(string.IsNullOrWhiteSpace(textBox3.Text)) && !(string.IsNullOrWhiteSpace(textBox4.Text)) && !(string.IsNullOrWhiteSpace(textBox5.Text)))
            {
                button1.Enabled = true;
            }
            else
                button1.Enabled = false;
        }

    }
}

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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                db.customs.Add(new Custom() { Name = textBox1.Text, Surname = textBox2.Text, Email = textBox3.Text, Phone = maskedTextBox1.Text, Address = richTextBox1.Text, User_id = Form1.user });
                db.SaveChanges();
                Close();
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Name is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "SurName is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Email is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!(string.IsNullOrWhiteSpace(textBox1.Text)) && !(string.IsNullOrWhiteSpace(textBox2.Text)) && !(string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                button1.Enabled = true;
            }
        }
    }
}

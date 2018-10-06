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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                db.products.Add(new Prod() { Name = textBox1.Text, Price = textBox2.Text, Quantity = (int)numericUpDown1.Value, Description = richTextBox1.Text, User_id = Form1.user });
                db.SaveChanges();
                Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int price = -1;
            if(!(int.TryParse(textBox2.Text, out price)))
            {
                textBox2.Text = "";
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Product name is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Price is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!(string.IsNullOrWhiteSpace(textBox1.Text)) && !(string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                button1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Product name is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Price is empty");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!(string.IsNullOrWhiteSpace(textBox1.Text)) && !(string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                button1.Enabled = true;
            }
        }

        private void Product_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            button1.Enabled = false;
        }
    }
}

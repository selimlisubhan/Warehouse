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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                string[] vs = comboBox1.SelectedItem.ToString().Split(' ');
                var prod = db.products.ToList().FirstOrDefault(x => x.Name == comboBox2.SelectedItem.ToString());
                var clientId = db.customs.ToList().FirstOrDefault(x => x.Name == vs[0]);
                db.orders.Add(new Orders() { Client_id = clientId, Product_id = prod, Quantity = (int)numericUpDown1.Value, Arrive = dateTimePicker1.Value, OrderTime = DateTime.Now, User_id = Form1.user });
db.SaveChanges();
                prod.Quantity -= (int)numericUpDown1.Value;
                Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                comboBox2.Items.Clear();
                var prod = db.products.ToList().Where(x => x.User_id == Form1.user);
                foreach (var item in prod)
                {
                    if (item.Quantity > 0)
                    {
                        comboBox2.Items.Add(item.Name);
                    }
                }
                if (comboBox1.SelectedIndex < 1)
                {
                    errorProvider1.SetError(comboBox1, "Client is empty");
                }
                else
                {
                    errorProvider1.Clear();
                }
                if (comboBox2.SelectedIndex < 1)
                {
                    errorProvider1.SetError(comboBox2, "Product is empty");
                }
                else
                {
                    errorProvider1.Clear();
                }
                if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                {
                    errorProvider1.Clear();
                    button1.Enabled = true;
                }
            }
        }

        private void Order_Load(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                comboBox1.Items.Clear();
                numericUpDown1.Maximum = 0;
                numericUpDown1.Minimum = 1;
                button1.Enabled = false;
                var cust = db.customs.ToList().Where(x => x.User_id == Form1.user);
                foreach (var item in cust)
                {
                    string z = item.Name + " " + item.Surname;
                    comboBox1.Items.Add(z);
                }
                dateTimePicker1.MinDate = DateTime.Now.AddDays(1);
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                var prod1 = db.products.ToList().FirstOrDefault(x => x.Name == comboBox2.SelectedItem.ToString());
                numericUpDown1.Maximum = prod1.Quantity;
                if (comboBox1.SelectedIndex < 1)
                {
                    errorProvider1.SetError(comboBox1, "Client is empty");
                }
                else
                {
                    errorProvider1.Clear();
                }
                if (comboBox2.SelectedIndex < 1)
                {
                    errorProvider1.SetError(comboBox2, "Product is empty");
                }
                else
                {
                    errorProvider1.Clear();
                }
                if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
                {
                    errorProvider1.Clear();
                    button1.Enabled = true;
                }
            }
        }
    }
}

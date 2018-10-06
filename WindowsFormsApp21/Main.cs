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
    public partial class Main : Form
    {
        Customer customer;
        Order order;
        Product product;
        User user;

        public Main()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customer = new Customer();
            customer.ShowDialog();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            order = new Order();
            order.ShowDialog();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            product = new Product();
            product.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                user = Form1.user;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
            }
        }


        private void Order_Click(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                listView2.Items.Clear();
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = false;
                ListViewItem list;
                int id = 0;
                var tapilan = db.orders.ToList().Where(x => x.User_id == user).ToList().ToList();
                foreach (var item in tapilan)
                {
                    id++;
                    list = new ListViewItem(id.ToString());
                    list.SubItems.Add(item.Client_id.Name);
                    list.SubItems.Add(item.Product_id.Name);
                    list.SubItems.Add(item.Quantity.ToString());
                    list.SubItems.Add(item.OrderTime.ToString());
                    list.SubItems.Add(item.Arrive.ToString());
                    if (DateTime.Now > item.Arrive)
                    {
                        list.SubItems.Add("Ended");
                    }
                    else if (DateTime.Now < item.Arrive)
                    {
                        list.SubItems.Add("Waiting");
                    }
                    else if (DateTime.Now == item.Arrive)
                    {
                        list.SubItems.Add("Sending");
                    }
                    listView2.Items.Add(list);
                }
            }
        }

        private void Custom_Click(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                listView1.Items.Clear();
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                ListViewItem list;
                int id = 0;
                var tapilan = db.customs.ToList().Where(x => x.User_id == user).ToList();
                foreach (var item in tapilan)
                {
                    id++;
                    list = new ListViewItem(id.ToString());
                    list.SubItems.Add(item.Name);
                    list.SubItems.Add(item.Surname);
                    list.SubItems.Add(item.Email);
                    list.SubItems.Add(item.Phone);
                    list.SubItems.Add(item.Address);
                    listView1.Items.Add(list);
                }
            }
        }

        private void Product_Click(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                listView3.Items.Clear();
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                ListViewItem list;
                int id = 0;
                var tapilan = db.products.ToList().Where(x => x.User_id == user).ToList();
                foreach (var item in tapilan)
                {
                    id++;
                    list = new ListViewItem(id.ToString());
                    list.SubItems.Add(item.Name);
                    list.SubItems.Add(item.Price);
                    list.SubItems.Add(item.Quantity.ToString());
                    list.SubItems.Add(item.Description);
                    listView3.Items.Add(list);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (panel1.Visible == true && panel2.Visible == false && panel3.Visible == false)
            {
                using (EntityModel db = new EntityModel())
                {
                    ListViewItem list;
                    int id = 0;
                    listView1.Items.Clear();
                    if (textBox1.Text == "")
                    {
                        var tapilan = db.customs.ToList().Where(x => x.User_id == user).ToList();
                        foreach (var item in tapilan)
                        {
                            id++;
                            list = new ListViewItem(id.ToString());
                            list.SubItems.Add(item.Name);
                            list.SubItems.Add(item.Surname);
                            list.SubItems.Add(item.Email);
                            list.SubItems.Add(item.Phone);
                            list.SubItems.Add(item.Address);
                            listView1.Items.Add(list);
                        }
                    }
                    else
                    {
                        var tapilan = db.customs.ToList().Where(x => (x.Id.ToString().Contains(textBox1.Text) ||
                                                            x.Name.Contains(textBox1.Text) ||
                                                            x.Surname.Contains(textBox1.Text) ||
                                                            x.Phone.Contains(textBox1.Text) ||
                                                            x.Email.Contains(textBox1.Text) ||
                                                            x.Address.Contains(textBox1.Text)) &&
                                                            x.User_id == user
                                                             ).ToList();
                        foreach (var item in tapilan)
                        {
                            id++;
                            list = new ListViewItem(id.ToString());
                            list.SubItems.Add(item.Name);
                            list.SubItems.Add(item.Surname);
                            list.SubItems.Add(item.Email);
                            list.SubItems.Add(item.Phone);
                            list.SubItems.Add(item.Address);
                            listView1.Items.Add(list);
                        }
                    }
                }

            }
            else if (panel1.Visible == true && panel2.Visible == true && panel3.Visible == false)
            {
                using (EntityModel db = new EntityModel())
                {
                    ListViewItem list;
                    int id = 0;
                    listView2.Items.Clear();
                    if (textBox1.Text == "")
                    {
                        var tapilan = db.orders.ToList().Where(x => x.User_id == user).ToList();
                        foreach (var item in tapilan)
                        {
                            id++;
                            list = new ListViewItem(id.ToString());
                            list.SubItems.Add(item.Client_id.Name);
                            list.SubItems.Add(item.Product_id.Name);
                            list.SubItems.Add(item.Quantity.ToString());
                            list.SubItems.Add(item.OrderTime.ToString());
                            list.SubItems.Add(item.Arrive.ToString());
                            if (DateTime.Now > item.Arrive)
                            {
                                list.SubItems.Add("Ended");
                            }
                            else if (DateTime.Now < item.Arrive)
                            {
                                list.SubItems.Add("Waiting");
                            }
                            else if (DateTime.Now == item.Arrive)
                            {
                                list.SubItems.Add("Sending");
                            }
                            listView2.Items.Add(list);
                        }
                    }
                    else
                    {
                        var tapilan = db.orders.ToList().Where(x => (x.Id.ToString().Contains(textBox1.Text) ||
                                                            x.Arrive.ToString().Contains(textBox1.Text) ||
                                                            x.Client_id.Name.Contains(textBox1.Text) ||
                                                            x.Product_id.Name.Contains(textBox1.Text) ||
                                                            x.OrderTime.ToString().Contains(textBox1.Text) ||
                                                            x.Quantity.ToString().Contains(textBox1.Text)) &&
                                                            x.User_id == user
                                                             ).ToList();
                        foreach (var item in tapilan)
                        {
                            id++;
                            list = new ListViewItem(id.ToString());
                            list.SubItems.Add(item.Client_id.Name);
                            list.SubItems.Add(item.Product_id.Name);
                            list.SubItems.Add(item.Quantity.ToString());
                            list.SubItems.Add(item.OrderTime.ToString());
                            list.SubItems.Add(item.Arrive.ToString());
                            if (DateTime.Now > item.Arrive)
                            {
                                list.SubItems.Add("Ended");
                            }
                            else if (DateTime.Now < item.Arrive)
                            {
                                list.SubItems.Add("Waiting");
                            }
                            else if (DateTime.Now == item.Arrive)
                            {
                                list.SubItems.Add("Sending");
                            }
                            listView2.Items.Add(list);
                        }
                    }
                }
            }
            else if (panel1.Visible == true && panel2.Visible == true && panel3.Visible == true)
            {
                using (EntityModel db = new EntityModel())
                {
                    ListViewItem list;
                    int id = 0;
                    listView3.Items.Clear();
                    if (textBox1.Text == "")
                    {
                        var tapilan = db.products.ToList().Where(x => x.User_id == user).ToList();
                        foreach (var item in tapilan)
                        {
                            id++;
                            list = new ListViewItem(id.ToString());
                            list.SubItems.Add(item.Name);
                            list.SubItems.Add(item.Price);
                            list.SubItems.Add(item.Quantity.ToString());
                            list.SubItems.Add(item.Description);
                            listView3.Items.Add(list);
                        }
                    }
                    else
                    {
                        var tapilan = db.products.ToList().Where(x => (x.Id.ToString().Contains(textBox1.Text) ||
                                                            x.Name.Contains(textBox1.Text) ||
                                                            x.Description.Contains(textBox1.Text) ||
                                                            x.Quantity.ToString().Contains(textBox1.Text) ||
                                                            x.Price.Contains(textBox1.Text)) &&
                                                            x.User_id == user
                                                             ).ToList();
                        foreach (var item in tapilan)
                        {
                            id++;
                            list = new ListViewItem(id.ToString());
                            list.SubItems.Add(item.Name);
                            list.SubItems.Add(item.Price);
                            list.SubItems.Add(item.Quantity.ToString());
                            list.SubItems.Add(item.Description);
                            listView3.Items.Add(list);
                        }
                    }
                }
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.user = null;
        }
    }
}

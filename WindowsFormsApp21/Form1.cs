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
    public partial class Form1 : Form
    {
        Qeydiyyat qeydiyyat;
        Main main;

        //public static List<User> users = new List<User>();
        //public static List<Custom> customs = new List<Custom>();
        //public static List<Prod> products = new List<Prod>();
        //public static List<Orders> orders = new List<Orders>();
        public static User user;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            qeydiyyat = new Qeydiyyat();
            qeydiyyat.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (EntityModel db = new EntityModel())
            {
                var y = db.Users.ToList().Where(x => (x.UserName == textBox1.Text && x.Password == textBox2.Text)).ToList();

                if (y.Count == 0)
                {
                    MessageBox.Show("Melumatlar duzgun deyil");
                }
                else
                {
                    user = new User();
                    user = db.Users.ToList().FirstOrDefault(x => (x.UserName == textBox1.Text && x.Password == textBox2.Text));
                    main = new Main();
                    main.ShowDialog();
                }
            }
        }
    }    
}

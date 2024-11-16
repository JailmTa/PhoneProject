using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussnessLayerPhoneProject;

namespace PhoneShopProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int ID= clsBussnesLayer.Login(tbUserName.Text, tbPassWord.Text);
            if (ID>0)
            {
                this.Hide();
                Form1 form = new Form1(ID);   
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("The PassWord Or User Name Is Wrong !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();   
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

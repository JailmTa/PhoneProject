using BussnessLayerPhoneProject;
using Guna.UI2.WinForms;
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
    public partial class Form1 : Form
    {
        int _ID = 0;
        public Form1(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        string btn = "";

        private void Refreash(string tag)
        {
            if (tag == "Phones" || tag== "BuyPhones")
            {
                guna2DataGridView1.DataSource = clsBussnesLayer.GetAllMobails();
            }
            else
            {
                guna2DataGridView1.DataSource = clsBussnesLayer.getAllCustemars();
            }
        }


        private void showDataGradView(Guna2Button button)
        {
            if (button.Tag == "Home")
            {
                gbBuyPhones.Visible = false;
                this.ContextMenuStrip = contextMenuStrip2;
              
            }
            else if (button.Tag == "Phones")
            {
                gbBuyPhones.Visible = true;
                label3.Text = "Show All Mobiles Phone";
                guna2DataGridView1.DataSource = clsBussnesLayer.GetAllMobails();
                this.ContextMenuStrip = contextMenuStrip1;
                btnBuy.Visible = false;
                btnAdd.Visible = true;
                btnAdd.Tag = "Phone";
                btnAdd.Text = "Add " + btnAdd.Tag;
            }
            else if (button.Tag == "BuyPhones")
            {
                label3.Text = "Update Mobile Information";
                gbBuyPhones.Visible = true;
                guna2DataGridView1.DataSource = clsBussnesLayer.GetAllMobails();
                this.ContextMenuStrip = contextMenuStrip2;
                btnBuy.Visible = true;
                btnAdd.Visible = false;
            }
            else if (button.Tag == "Custemars")
            {
                gbBuyPhones.Visible = true;
                label3.Text = "Show All Custemats";
                guna2DataGridView1.DataSource = clsBussnesLayer.getAllCustemars();
                this.ContextMenuStrip = contextMenuStrip2;
                btnBuy.Visible = false;
                btnAdd.Visible = false;
            }
            else if(button.Tag== "Setting")
            {
                label3.Text = "Update Users Information";
                gbBuyPhones.Visible = true;
                guna2DataGridView1.DataSource = clsBussnesLayer.getAllCustemars();
                this.ContextMenuStrip = contextMenuStrip1;
                btnBuy.Visible = false;
                btnAdd.Visible = true;
                btnAdd.Tag = "Custemar";
                btnAdd.Text = "Add " + btnAdd.Tag;
            }
            else
            {
                label3.Text = "Orders Information";
                gbBuyPhones.Visible = true;
                guna2DataGridView1.DataSource =clsBussnesLayer.GeetAllOrders(); 
                this.ContextMenuStrip = contextMenuStrip2;
                btnBuy.Visible = false;
                btnAdd.Visible = false;
            }
            btn = button.Tag.ToString();
        }

        private void setButtonCustemas(Guna2Button button)
        {

        }

        private void RebliceColore(object sender, EventArgs e)
        {
            btnHome.FillColor = System.Drawing.Color.FromArgb(225, 184, 249);
            btnPhones.FillColor = System.Drawing.Color.FromArgb(225, 184, 249);
            btnCustemars.FillColor = System.Drawing.Color.FromArgb(225, 184, 249);
            btnBuyPhones.FillColor = System.Drawing.Color.FromArgb(225, 184, 249);
            btnSetting.FillColor = System.Drawing.Color.FromArgb(225, 184, 249);
            btnOrder.FillColor = System.Drawing.Color.FromArgb(225, 184, 249);
            int NX=btnHome.Location.X,NY=btnHome.Location.Y;
            btnHome.Size =btnExit.Size;
            NX = btnPhones.Location.X;NY = btnPhones.Location.Y;
            btnPhones.Size = btnExit.Size;
            NX = btnCustemars.Location.X;NY = btnCustemars.Location.Y;
            btnCustemars.Size =btnExit.Size;
            NX= btnBuyPhones.Location.X;NY=btnBuyPhones.Location.Y;
            btnBuyPhones.Size =btnExit.Size;
            NX= btnSetting.Location.X;NY=btnSetting.Location.Y;
            btnSetting.Size =btnExit.Size;
            NX = btnOrder.Location.X; NY=btnOrder.Location.Y;
            btnOrder.Size =btnExit.Size;
            ((Guna2Button)sender).FillColor = System.Drawing.Color.FromArgb(202, 120, 250);
            NX = ((Guna2Button)sender).Location.X; NY = ((Guna2Button)sender).Location.Y;
            ((Guna2Button)sender).Size = new System.Drawing.Size(220, 40);
            showDataGradView((Guna2Button)sender);
        }

     
        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = clsBussnesLayer.GetAllMobails();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = clsBussnesLayer.FindPhones(guna2TextBox1.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void upDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btn == "Phones")
            {
                Form3 form3 = new Form3(Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[0].Value));
                form3.ShowDialog();
            }
            else
            {
                Form2 form2 = new Form2(Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[0].Value),btn);
                form2.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btn == "Phones")
            {
                clsBussnesLayer.DeletePhone(Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[0].Value));
                MessageBox.Show("The Phone Delete Successfuly","Deleted",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                clsBussnesLayer.DeleteCus(Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[0].Value));
                MessageBox.Show("The Custemar Delete Successfuly", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Shur You Wonna To Buy ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsBussnesLayer.UpDatePhone(Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[0].Value), guna2DataGridView1.CurrentRow.Cells[1].Value.ToString()
                   , Convert.ToInt16(guna2DataGridView1.CurrentRow.Cells[2].Value), guna2DataGridView1.CurrentRow.Cells[3].Value.ToString(),
                        Convert.ToInt16(guna2DataGridView1.CurrentRow.Cells[4].Value), Convert.ToInt16(guna2DataGridView1.CurrentRow.Cells[5].Value),
                        Convert.ToInt16(guna2DataGridView1.CurrentRow.Cells[6].Value), Convert.ToInt16(guna2DataGridView1.CurrentRow.Cells[7].Value),
                        guna2DataGridView1.CurrentRow.Cells[8].Value.ToString(), guna2DataGridView1.CurrentRow.Cells[9].Value.ToString(),
                        guna2DataGridView1.CurrentRow.Cells[10].Value.ToString(), Convert.ToInt64(guna2DataGridView1.CurrentRow.Cells[11].Value),
                        Convert.ToInt16(Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[12].Value) - 1)) > 0)
                {
                    clsBussnesLayer.Buying(Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[0].Value), _ID);
                    MessageBox.Show("You By The Phone Successfuly :)", "Ordered Successfuly",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Refreash(btn);
                }

                else
                {
                    MessageBox.Show("There Aren't Any More For This Item", "Can't Buy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (((Guna2Button)sender).Tag == "Custemar")
            {
                Form2 f = new Form2();
                f.ShowDialog();
            }
            else
            {
                Form3 f = new Form3();
                f.ShowDialog();
            }
        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gbBuyPhones_Enter(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

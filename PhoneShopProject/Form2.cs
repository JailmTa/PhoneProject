using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BussnessLayerPhoneProject;
using Guna.UI2.HtmlRenderer.Adapters.Entities;
using Guna.UI2.WinForms;

namespace PhoneShopProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.Text = "Add New Custemar";
            tbID.Enabled = false;
            btnSave.Text = "Save";
            btnSave.Tag = "Save";
            _Stutes = "Save";
        }
        int _ID = 0; 
        string _Stutes="";
        public Form2(int ID,string Stutes)
        {
            InitializeComponent();
            _ID = ID;
            label1.Text = "UpDate Custemar";
            tbID.Enabled = false;
            tbUserName.Enabled = false;
            tbPassWord.Enabled = false;
            tbConfermPassWord.Enabled = false;
            btnSave.Text = "UpDate";
            btnSave.Tag = "UpDate";
            _Stutes= Stutes;    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Stutes == "Save")
            {
                if (tbFirstName.Text == "" || tbLastName.Text == "" || tbEmail.Text == "" || tbAddreass.Text == "" || tbPhoneNumber.Text == "" || tbUserName.Text == "" || tbPassWord.Text == "" || tbConfermPassWord.Text == "")
                {
                    MessageBox.Show("There Are Missed Inforamtions !", "Denay Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbPassWord.Text != tbConfermPassWord.Text)
                {
                    MessageBox.Show("There Are Chinge At PassWord !", "Denay Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbPassWord.Text.Length <= 8)
                {
                    MessageBox.Show("The PassWord Leass Thin 8 Char !", "Denay Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int id = clsBussnesLayer.AddCustemar(tbFirstName.Text, tbLastName.Text, tbEmail.Text, (DateTime)dtpBIrthDate.Value, tbAddreass.Text, tbPhoneNumber.Text);
                    clsBussnesLayer.AddUser(id, tbUserName.Text, tbPassWord.Text);
                    MessageBox.Show("The Custemar Has Added","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                if (tbFirstName.Text == "" || tbLastName.Text == "" || tbEmail.Text == "" || tbAddreass.Text == "" || tbPhoneNumber.Text == "")
                {
                    MessageBox.Show("There Are Missed Inforamtions !", "Denay Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int id = clsBussnesLayer.UpDateCustemar(_ID,tbFirstName.Text, tbLastName.Text, tbEmail.Text, (DateTime)dtpBIrthDate.Value, tbAddreass.Text, tbPhoneNumber.Text);
                    MessageBox.Show("The Custemar Has UpDated", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }

        private void tbID_Validating(object sender, CancelEventArgs e)
        {
            if (((Guna2TextBox)sender).Text == "")
            {
                e.Cancel = true;
                ((Guna2TextBox)sender).Focus();
                errorProvider1.SetError(((Guna2TextBox)sender), "You Must Fill This Text Box");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(((Guna2TextBox)sender), "");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (_ID != 0)
            {
                string FN = "", LN = "", EM = "", AD = "", PH = "";
                DateTime BD= DateTime.Now;

                clsBussnesLayer.FindCus(_ID, ref FN, ref LN, ref EM,ref BD, ref AD, ref PH);
                tbID.Text = _ID.ToString();
                tbFirstName.Text = FN.ToString();
                tbLastName.Text = LN.ToString();
                tbEmail.Text = EM.ToString();
                tbAddreass.Text= AD.ToString();
                tbPhoneNumber.Text = PH.ToString();
                dtpBIrthDate.Text = BD.ToString();

            }
        }
    }
}

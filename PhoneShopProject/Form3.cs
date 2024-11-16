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
using Guna.UI2.HtmlRenderer.Adapters.Entities;
using Guna.UI2.WinForms;

namespace PhoneShopProject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            label1.Text = "Add New Phone";
            tbID.Enabled = false;
            btnSave.Text = "Save";
            btnSave.Tag = "Save";
        }
        int _ID = 0;
        public Form3(int ID)
        {
            InitializeComponent();
            _ID = ID;
            label1.Text = "UpDate Phone";
            tbID.Enabled = false;
            btnSave.Text = "UpDate";
            btnSave.Tag = "UpDate";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbCPU.Text == "" || tbName.Text == "" || tbGPU.Text == "" || tbName.Text == "" || tbQuilitiy.Text == "" || tbScreanSize.Text == "" || tbSecreanQ.Text == ""
    || cbColor.Text == "" || cbBackCam.Text == "" || cbFrontCam.Text == "" || cbRam.Text == "" || cbRom.Text == ""
    || cbCompanyName.Text == "")
            {
                MessageBox.Show("There Are Missed Inforamtions !", "Denay Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (btnSave.Tag == "Save")
            {

                if(MessageBox.Show("Are You Sure You Wonna To Add This Phone ?","Confnerm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.OK)
                clsBussnesLayer.AddPhone(cbColor.Text, tbName.Text,Convert.ToInt16(cbCompanyName.SelectedIndex+1), Convert.ToInt16(cbRom.Text), Convert.ToInt16(cbRam.Text), Convert.ToInt16(cbFrontCam.Text), Convert.ToInt16(cbBackCam.Text)
                    , tbCPU.Text, tbGPU.Text, tbSecreanQ.Text, Convert.ToDouble(tbScreanSize.Text), Convert.ToInt16(tbQuilitiy.Text));


            }
            else
            {
                if (MessageBox.Show("Are You Sure You Wonna To UpDate This Phone ?", "Confnerm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    clsBussnesLayer.UpDatePhone(_ID, tbName.Text, Convert.ToInt16(cbCompanyName.SelectedIndex + 1), cbColor.Text, Convert.ToInt16(cbRom.Text), Convert.ToInt16(cbRam.Text), Convert.ToInt16(cbFrontCam.Text), Convert.ToInt16(cbBackCam.Text)
                    , tbCPU.Text, tbGPU.Text, tbSecreanQ.Text, Convert.ToDouble(tbScreanSize.Text), Convert.ToInt16(tbQuilitiy.Text));
            }
        }

        private void tbID_Validating(object sender, CancelEventArgs e)
        {
            if (((Guna2TextBox)sender).Text == "")
            {
                e.Cancel = true;
                ((Guna2TextBox)sender).Focus();
                errorProvider1.SetError(((Guna2TextBox)sender), "You Must Validating This Text Box");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(((Guna2TextBox)sender), "");

            }
        }

        private void cbCompanyName_Validating(object sender, CancelEventArgs e)
        {
            if (((Guna2ComboBox)sender).Text == "")
            {
                e.Cancel = true;
                ((Guna2ComboBox)sender).Focus();
                errorProvider1.SetError(((Guna2ComboBox)sender), "You Must Validating This Text Box");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(((Guna2ComboBox)sender), "");

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (_ID != 0)
            {
                string Name ="";
                short CompnayID=0;
                string Color ="";
                short Rom =0;
                short Ram =0;
                short FC =0;
                short BC =0;
                string CPU ="";
                string GPU ="";
                string Secerrnq="" ;
                double Size =0.0;
                short Qui = 0;

                 clsBussnesLayer.Find(_ID, ref Name, ref CompnayID, ref Color, ref Rom, ref Ram, ref FC, ref BC
                         , ref CPU, ref GPU, ref Secerrnq, ref Size, ref Qui);
                tbID.Text = _ID.ToString();
                tbName.Text = Name.ToString();
                cbCompanyName.Text = cbCompanyName.Items[Convert.ToInt32(CompnayID.ToString())-1].ToString();
                cbColor.Text = Color.ToString();
                cbRom.Text = Rom.ToString();
                cbRam.Text = Ram.ToString();
                cbFrontCam.Text = FC.ToString();
                cbBackCam.Text = BC.ToString();
                tbCPU.Text = CPU.ToString();
                tbGPU.Text = GPU.ToString();
                tbSecreanQ.Text = Secerrnq.ToString();
                tbScreanSize.Text = Size.ToString();
                tbQuilitiy.Text = Qui.ToString();

            }
        }

        //private void tbID_TextChanged(object sender, EventArgs e)
        //{
        //    string Name = "";
        //    short CompnayID = 0;
        //    string Color = "";
        //    short Rom = 0;
        //    short Ram = 0;
        //    short FC = 0;
        //    short BC = 0;
        //    string CPU = "";
        //    string GPU = "";
        //    string Secerrnq = "";
        //    double Size = 0.0;
        //    short Qui = 0;

        //    clsBussnesLayer.Find(_ID, ref Name, ref CompnayID, ref Color, ref Rom, ref Ram, ref FC, ref BC
        //            , ref CPU, ref GPU, ref Secerrnq, ref Size, ref Qui);
        //    tbName.Text = Name.ToString();
        //    cbCompanyName.Text = CompnayID.ToString();
        //    cbColor.Text = Color;
        //    cbRom.Text = Rom.ToString();
        //    cbRam.Text = Ram.ToString();
        //    cbFrontCam.Text = FC.ToString();
        //    cbBackCam.Text = BC.ToString();
        //    tbCPU.Text = CPU;
        //    tbGPU.Text = GPU;
        //    tbSecreanQ.Text = Secerrnq;
        //    tbScreanSize.Text = Size.ToString();
        //    tbQuilitiy.Text = Qui.ToString();

        //}
    }
}

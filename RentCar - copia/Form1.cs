using RentCar.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string pass = txtPassword.Text.Trim();

            using (Models.RentCarDBEntities db = new Models.RentCarDBEntities()) 
            {
                var lst = from d in db.Empleado
                          where d.usuario == txtUser.Text
                          && d.password == pass
                          select d;

                if (lst.Count() >0)
                {
                    //MessageBox.Show("Usuario Existe");
                    //this.Close();
                    this.Hide();
                    FrmPrincipal frmPrincipal = new FrmPrincipal();
                    frmPrincipal.FormClosed += (s, args) => this.Close();
                    frmPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Usuario No Existe!");
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
    }
}

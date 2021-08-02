using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentCar.Models;

namespace RentCar.Formularios
{
    public partial class FrmEmpleados : Form
    {
        public int? idEmpleado;
        Empleado empleado = null;
        public FrmEmpleados(int? idEmpleado = null)
        {
            InitializeComponent();

            this.idEmpleado = idEmpleado;
            Limpiar();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet5.Empleado' Puede moverla o quitarla según sea necesario.
            this.empleadoTableAdapter.Fill(this.rentCarDBDataSet5.Empleado);
        }

        private void Limpiar()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            txtNombre.Clear();
            txtCedula.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtFiltrar.Clear();

            cmbEstado.Text = "";
            cmbTanda.Text = "";

            nddPorciento.Value = 0;
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    empleado = db.Empleado.Find(id);

                    txtNombre.Text = empleado.Nombre;
                    txtCedula.Text = empleado.Cedula;
                    txtUsuario.Text = empleado.usuario;
                    txtContraseña.Text = empleado.password;
                    cmbTanda.Text = empleado.Tanda_Labor;
                    cmbEstado.Text = empleado.Estado;
                    nddPorciento.Value = (decimal)empleado.Porciento_comision;
                    dtpFechaIngreso.Value = (DateTime)empleado.fecha_ingreso;

                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnGuardar.Enabled = false;
                }
            }
        }

        private void Refrescar()
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                var lst = from d in db.Empleado
                          select d;
                if (!txtFiltrar.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Nombre.Contains(txtFiltrar.Text.Trim()));
                }
                dataGridView1.DataSource = lst.ToList();
            }
        }

        public static bool validaCedula(string pCedula)

        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //validaCedula(txtCedula.Text.ToString());

            if (validaCedula(txtCedula.Text.ToString()) == true)
            {
                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    empleado = new Empleado();
                    empleado.Nombre = txtNombre.Text;
                    empleado.Cedula = txtCedula.Text;
                    //empleado.Tanda_Labor = cmbTanda.Text;
                    empleado.usuario = txtUsuario.Text;
                    empleado.password = txtContraseña.Text;
                    empleado.Porciento_comision = (int?)nddPorciento.Value;
                    //empleado.Estado = cmbEstado.Text;
                    empleado.fecha_ingreso = dtpFechaIngreso.Value;

                    if (cmbEstado.Text == "Activo")
                    {
                        empleado.Estado = "A";
                    }
                    else if (cmbEstado.Text == "Inactivo")
                    {
                        empleado.Estado = "I";
                    }

                    if (cmbTanda.Text == "Matutino")
                    {
                        empleado.Tanda_Labor = "M";
                    }
                    else if (cmbTanda.Text == "Vespertino")
                    {
                        empleado.Tanda_Labor = "V";
                    }
                    else if (cmbTanda.Text == "Nocturno")
                    {
                        empleado.Tanda_Labor = "N";
                    }

                    db.Empleado.Add(empleado);

                    db.SaveChanges();
                }
                Refrescar();
                Limpiar();
                MessageBox.Show("El empleado ha sido guardado satisfactoriamente!");
            }
            else 
            {
                MessageBox.Show("Esta cedula no es valida!");
                txtCedula.Clear();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (validaCedula(txtCedula.Text.ToString()) == true)
            {
                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    empleado.Nombre = txtNombre.Text;
                    empleado.Cedula = txtCedula.Text;
                    //empleado.Tanda_Labor = cmbTanda.Text;
                    empleado.usuario = txtUsuario.Text;
                    empleado.password = txtContraseña.Text;
                    empleado.Porciento_comision = (int?)nddPorciento.Value;
                    //empleado.Estado = cmbEstado.Text;
                    empleado.fecha_ingreso = dtpFechaIngreso.Value;

                    if (cmbEstado.Text == "Activo")
                    {
                        empleado.Estado = "A";
                    }
                    else if (cmbEstado.Text == "Inactivo")
                    {
                        empleado.Estado = "I";
                    }

                    if (cmbTanda.Text == "Matutino")
                    {
                        empleado.Tanda_Labor = "M";
                    }
                    else if (cmbTanda.Text == "Vespertino")
                    {
                        empleado.Tanda_Labor = "V";
                    }
                    else if (cmbTanda.Text == "Nocturno")
                    {
                        empleado.Tanda_Labor = "N";
                    }

                    db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                Refrescar();
                Limpiar();
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                MessageBox.Show("El empleado ha sido editado satisfactoriamente!");
            }
            else
                MessageBox.Show("Esta cedula no es valida!");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            try
            {
                if (id != null)
                {
                    using (RentCarDBEntities db = new RentCarDBEntities())
                    {
                        empleado = db.Empleado.Find(id);
                        db.Empleado.Remove(empleado);

                        db.SaveChanges();
                    }
                    Refrescar();
                    Limpiar();
                    btnGuardar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    MessageBox.Show("El empleado ha sido eliminado satisfactoriamente!");
                }
            }
            catch
            {
                MessageBox.Show("El registro no puede ser eliminado porque contiene registro asosiados");
            }
           
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Refrescar();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}

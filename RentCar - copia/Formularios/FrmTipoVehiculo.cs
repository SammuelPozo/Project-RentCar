using RentCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar.Formularios
{
    public partial class FrmTipoVehiculo : Form
    {
        public int? idTipoVehiculo;
        Tipo_vehiculo tipovehiculo = null;

        public FrmTipoVehiculo(int? idTipoVehiculo = null)
        {
            InitializeComponent();

            this.idTipoVehiculo = idTipoVehiculo;
            Limpiar();
        }

        private void FrmTipoVehiculo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet1.Tipo_vehiculo' Puede moverla o quitarla según sea necesario.
            this.tipo_vehiculoTableAdapter.Fill(this.rentCarDBDataSet1.Tipo_vehiculo);

        }

        private void Limpiar()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            txtFiltro.Clear();
            txtDescripcionTipoVehiculo.Clear();
            comboBox1.Text = "";
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

        private void Refrescar()
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                var lst = from d in db.Tipo_vehiculo
                          select d;
                if (!txtFiltro.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Descripcion.Contains(txtFiltro.Text.Trim()));
                }
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                tipovehiculo = new Tipo_vehiculo();
                tipovehiculo.Descripcion = txtDescripcionTipoVehiculo.Text;
                //tipovehiculo.Estado = comboBox1.Text;

                if (comboBox1.Text == "Activo")
                {
                    tipovehiculo.Estado = "A";
                }
                else if (comboBox1.Text == "Inactivo")
                {
                    tipovehiculo.Estado = "I";
                }

                db.Tipo_vehiculo.Add(tipovehiculo);

                db.SaveChanges();
                Refrescar();
                Limpiar();
                MessageBox.Show("El tipo de vehiculo ha sido guardado satisfactoriamente!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                tipovehiculo.Descripcion = txtDescripcionTipoVehiculo.Text;
                tipovehiculo.Estado = comboBox1.Text;

                if (comboBox1.Text == "Activo")
                {
                    tipovehiculo.Estado = "A";
                }
                else if (comboBox1.Text == "Inactivo")
                {
                    tipovehiculo.Estado = "I";
                }

                db.Entry(tipovehiculo).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                Refrescar();
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                MessageBox.Show("El tipo de vehiculo ha sido editado satisfactoriamente!");
            }
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
                        tipovehiculo = db.Tipo_vehiculo.Find(id);
                        db.Tipo_vehiculo.Remove(tipovehiculo);

                       

                        db.SaveChanges();
                    }
                    Refrescar();
                    Limpiar();
                    MessageBox.Show("El tipo de vehiculo ha sido eliminado satisfactoriamente!");
                }
            }
            catch
            {
                MessageBox.Show("El registro no puede ser eliminado porque contiene relaciones");
            }

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? id = GetId();
            if(id != null)
            {
                using(RentCarDBEntities db = new RentCarDBEntities())
                {
                    tipovehiculo = db.Tipo_vehiculo.Find(id);
                    txtDescripcionTipoVehiculo.Text = tipovehiculo.Descripcion;
                    comboBox1.Text = tipovehiculo.Estado;

                    btnGuardar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnGuardar.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refrescar();
            Limpiar();
        }
    }
}

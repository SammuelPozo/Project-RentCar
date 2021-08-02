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
    public partial class FrmModelo : Form
    {
        public int? idModelo;
        Modelo modelo = null;

        public FrmModelo(int? idModelo = null)
        {
            InitializeComponent();

            this.idModelo = idModelo;
            Refrescar();
            ObtenerMarca();
            Limpiar();
        }


        private void FrmModelo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet4.Modelo' Puede moverla o quitarla según sea necesario.
            this.modeloTableAdapter1.Fill(this.rentCarDBDataSet4.Modelo);
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet3.Modelo' Puede moverla o quitarla según sea necesario.
            //this.modeloTableAdapter.Fill(this.rentCarDBDataSet3.Modelo);
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet.Marca' Puede moverla o quitarla según sea necesario.
            this.marcaTableAdapter.Fill(this.rentCarDBDataSet.Marca);

        }

        private void Limpiar()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            txtDescripcion.Clear();
            txtFiltro.Clear();
            cmbEstado.Text = "";
            cmbMarca.Text = "";
        }

        private void ObtenerMarca()
        {
            using (RentCarDBEntities db = new RentCarDBEntities())
            {
                var lstIdMarca = db.Marca.Where(x => x.Estado == "A").Select(x => new { x.idMarca, x.Descripcion}).ToList();

                cmbMarca.DataSource = lstIdMarca;
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "idMarca";
                if (cmbMarca.Items.Count > 1)
                {
                    cmbMarca.SelectedIndex = -1;
                }
            }
        }

        private void Refrescar()
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                var lst = from d in db.Modelo
                          select d;
                if (!txtFiltro.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Descripcion.Contains(txtFiltro.Text.Trim()));
                }
                dataGridView1.DataSource = lst.ToList();
            }
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

        private int? GetIdByIdMarca()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var marca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());

            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                modelo = new Modelo();
                modelo.Descripcion = txtDescripcion.Text;
                modelo.Estado = cmbEstado.Text;
                modelo.Id_marca = marca;

                db.Modelo.Add(modelo);

                db.SaveChanges();
                Refrescar();
                Limpiar();
                MessageBox.Show("El modelo ha sido guardado  satisfactoriamente!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var marca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());

            using (RentCarDBEntities db = new RentCarDBEntities())
            {
                modelo.Descripcion = txtDescripcion.Text;
                modelo.Estado = cmbEstado.Text;
                modelo.Id_marca = marca;

                db.Entry(modelo).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                Refrescar();
                Limpiar();
                ObtenerMarca();
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                MessageBox.Show("El modelo ha sido editado satisfactoriamente!");
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
                        modelo = db.Modelo.Find(id);
                        db.Modelo.Remove(modelo);

                        db.SaveChanges();
                    }
                    Refrescar();
                    Limpiar();
                    ObtenerMarca();
                    btnGuardar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    MessageBox.Show("El modelo ha sido eliminado satisfactoriamente!");
                }
            }
            catch
            {
                MessageBox.Show("El registro no puede ser eliminado porque contiene relacion con otra tabla");
                Limpiar();
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? id = GetId();
            int? i = GetIdByIdMarca();
            
            if(id != null)
            {
                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    var marca = db.Marca.Where(x => x.idMarca == i).Select(x => new {x.idMarca, x.Descripcion}).ToList();

                    
                    modelo = db.Modelo.Find(id);
                    txtDescripcion.Text = modelo.Descripcion;
                    cmbEstado.Text = modelo.Estado;

                    cmbMarca.DataSource = marca;
                    cmbMarca.DisplayMember = "Descripcion";
                    cmbMarca.ValueMember = "idMarca";

                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnGuardar.Enabled = false;

                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnGuardar.Enabled = true;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Refrescar();
            Limpiar();
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

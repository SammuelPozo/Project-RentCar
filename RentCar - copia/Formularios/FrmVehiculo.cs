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
    public partial class FrmVehiculo : Form
    {
        public int? idVehiculo;
        Vehiculo vehiculo = null;
        public FrmVehiculo(int? idVehiculo = null)
        {
            InitializeComponent();
            this.idVehiculo = idVehiculo;   
            ObtenerDatos();
            Limpiar();
        }

        private void FrmVehiculo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet5.Vehiculo' Puede moverla o quitarla según sea necesario.
            this.vehiculoTableAdapter.Fill(this.rentCarDBDataSet5.Vehiculo);

        }

        private void Limpiar()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = true;

            txtDescripcion.Clear();
            nmPlaca.Value = 0;
            nmMotor.Value = 0;
            nmChasis.Value = 0;
            txtFiltro.Clear();

            cmbCombustible.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbModelo.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
        }

        private void Refrescar()
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                var lst = from d in db.Vehiculo
                          select d;
                if (!txtFiltro.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Descripcion.Contains(txtFiltro.Text.Trim()));
                }
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private void ObtenerDatos()
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                var lstIdMarca = db.Marca.Where(x => x.Estado == "A").Select(x => new { x.idMarca, x.Descripcion }).ToList();
                cmbMarca.DataSource = lstIdMarca;
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "idMarca";
                if (cmbMarca.Items.Count > 1)
                {
                    cmbMarca.SelectedIndex = -1;
                }

                var lstModelo = db.Modelo.Where(x => x.Estado == "A").Select(x => new { x.idModelo, x.Descripcion }).ToList();
                cmbModelo.DataSource = lstModelo;
                cmbModelo.DisplayMember = "Descripcion";
                cmbModelo.ValueMember = "idModelo";
                if (cmbModelo.Items.Count > 1)
                {
                    cmbModelo.SelectedIndex = -1;
                }

                var lstTipoVehiculo = db.Tipo_vehiculo.Where(x => x.Estado == "A").Select(x => new { x.idTipoVehiculo, x.Descripcion }).ToList();
                cmbTipo.DataSource = lstTipoVehiculo;
                cmbTipo.DisplayMember = "Descripcion";
                cmbTipo.ValueMember = "idTipoVehiculo";
                if (cmbTipo.Items.Count > 1)
                {
                    cmbTipo.SelectedIndex = -1;
                }

                var lstTipoCombustible = db.Tipo_combustible.Where(x => x.Estado == "A").Select(x => new { x.idTipoCombustible, x.Descripcion }).ToList();
                cmbCombustible.DataSource = lstTipoCombustible;
                cmbCombustible.DisplayMember = "Descripcion";
                cmbCombustible.ValueMember = "idTipoCombustible";
                if (cmbCombustible.Items.Count > 1)
                {
                    cmbCombustible.SelectedIndex = -1;
                }
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

        private int? GetIdMarca()
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

        private int? GetIdModelo()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private int? GetTipoVehiculo()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private int? GetTipoCombustible()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var marca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
            var modelo = Convert.ToInt32(cmbModelo.SelectedValue.ToString());
            var tipoVeh = Convert.ToInt32(cmbTipo.SelectedValue.ToString());
            var tipoComb = Convert.ToInt32(cmbCombustible.SelectedValue.ToString());

            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                vehiculo = new Vehiculo();
                vehiculo.IdMarca = marca;
                vehiculo.IdModelo = modelo;
                vehiculo.IdTipoVehiculo = tipoVeh;
                vehiculo.IdTipoCombustible = tipoComb;
                vehiculo.No_chahis = (int)nmChasis.Value;
                vehiculo.No_motor = (int)nmMotor.Value;
                vehiculo.No_placa = (int)nmPlaca.Value;
                vehiculo.Descripcion = txtDescripcion.Text;
                //vehiculo.Estado = cmbEstado.Text;

                if (cmbEstado.Text == "Disponible")
                {
                    vehiculo.Estado = "D";
                }
                else if (cmbEstado.Text == "Rentado")
                {
                    vehiculo.Estado = "R";
                }
                else if (cmbEstado.Text == "Mantenimiento")
                {
                    vehiculo.Estado = "M";
                }
                else if (cmbEstado.Text == "Inactivo")
                {
                    vehiculo.Estado = "I";
                }

                db.Vehiculo.Add(vehiculo);

                db.SaveChanges();
                Refrescar();
                ObtenerDatos();
                Limpiar();
                MessageBox.Show("El vehiculo se ha guardado satisfactoriamente!");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var marca = Convert.ToInt32(cmbMarca.SelectedValue.ToString());
            var modelo = Convert.ToInt32(cmbModelo.SelectedValue.ToString());
            var tipoVeh = Convert.ToInt32(cmbTipo.SelectedValue.ToString());
            var tipoComb = Convert.ToInt32(cmbCombustible.SelectedValue.ToString());

            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                vehiculo.IdMarca = marca;
                vehiculo.IdModelo = modelo;
                vehiculo.IdTipoVehiculo = tipoVeh;
                vehiculo.IdTipoCombustible = tipoComb;
                vehiculo.No_chahis = (int)nmChasis.Value;
                vehiculo.No_motor = (int)nmMotor.Value;
                vehiculo.No_placa = (int)nmPlaca.Value;
                vehiculo.Descripcion = txtDescripcion.Text;
                //vehiculo.Estado = cmbEstado.Text;

                if (cmbEstado.Text == "Disponible")
                {
                    vehiculo.Estado = "D";
                }
                else if (cmbEstado.Text == "Rentado")
                {
                    vehiculo.Estado = "R";
                }
                else if (cmbEstado.Text == "Mantenimiento")
                {
                    vehiculo.Estado = "M";
                }
                else if (cmbEstado.Text == "Inactivo")
                {
                    vehiculo.Estado = "I";
                }


                db.Entry(vehiculo).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                Refrescar();
                ObtenerDatos();
                Limpiar();
                MessageBox.Show("El vehiculo se ha editado satisfactoriamente!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? id = GetId();
            int? DidMarca = GetIdMarca();
            int? DidModelo = GetIdModelo();
            int? DidTipoVeh = GetTipoVehiculo();
            int? DidTipoComb = GetTipoCombustible();

            if (id != null)
            {
                using(RentCarDBEntities db = new RentCarDBEntities())
                {
                    var marca = db.Marca.Where(x => x.idMarca == DidMarca).Select(x => new { x.idMarca, x.Descripcion }).ToList();
                    var modelo = db.Modelo.Where(x => x.idModelo == DidModelo).Select(x => new { x.idModelo, x.Descripcion }).ToList();
                    var TipoVeh = db.Vehiculo.Where(x => x.idVehiculo == DidTipoVeh).Select(x => new { x.idVehiculo, x.Descripcion }).ToList();
                    var TipoCom = db.Tipo_combustible.Where(x => x.idTipoCombustible == DidTipoComb).Select(x => new { x.idTipoCombustible, x.Descripcion }).ToList();

                    vehiculo = db.Vehiculo.Find(id);

                    txtDescripcion.Text = vehiculo.Descripcion;
                    cmbEstado.Text = vehiculo.Estado;
                    nmChasis.Value = vehiculo.No_chahis;
                    nmMotor.Value = vehiculo.No_motor;
                    nmPlaca.Value = vehiculo.No_placa;

                    cmbMarca.DataSource = marca;
                    cmbMarca.DisplayMember = "Descripcion";
                    cmbMarca.ValueMember = "idMarca";

                    cmbModelo.DataSource = modelo;
                    cmbModelo.DisplayMember = "Descripcion";
                    cmbModelo.ValueMember = "idModelo";

                    cmbTipo.DataSource = TipoVeh;
                    cmbTipo.DisplayMember = "Descripcion";
                    cmbTipo.ValueMember = "idVehiculo";

                    cmbCombustible.DataSource = TipoCom;
                    cmbCombustible.DisplayMember = "Descripcion";
                    cmbCombustible.ValueMember = "idTipoCombustible";

                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnGuardar.Enabled = false;

                }
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
                        vehiculo = db.Vehiculo.Find(id);
                        db.Vehiculo.Remove(vehiculo);

                        db.SaveChanges();


                        Refrescar();
                        ObtenerDatos();
                        Limpiar();
                        MessageBox.Show("El vehiculo se ha eliminado satisfactoriamente!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("El registro no puede ser eliminado porque contiene registros asociados");
                Limpiar();
            }
            
        }
    }
}

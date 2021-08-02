using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentCar.Models;

namespace RentCar.Formularios
{
    public partial class FrmInspeccion : Form
    {
        public int? idInspeccion;
        Inspeccion inspeccion = null;

        public FrmInspeccion(int? idInspeccion = null)
        {
            InitializeComponent();
            this.idInspeccion = idInspeccion;
            Refrescar();
            ObtenerDatos();
            Limpiar();
        }

        private void FrmInspeccion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet6.Inspeccion' Puede moverla o quitarla según sea necesario.
            this.inspeccionTableAdapter1.Fill(this.rentCarDBDataSet6.Inspeccion);
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet5.Inspeccion' Puede moverla o quitarla según sea necesario.
            //this.inspeccionTableAdapter.Fill(this.rentCarDBDataSet5.Inspeccion);
            Refrescar();
            Limpiar();

        }

        private void Limpiar()
        {
            txtFiltrar.Clear();

            cmbCantidadCombus.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbEmpleado.SelectedIndex = -1;
            cmbCliente.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;
            
            cbGatoSi.Checked = false;
            cbGomaResSi.Checked = false;
            cbInfDer.Checked = false;
            cbInfIzq.Checked = false;
            cbRalladuraSi.Checked = false;
            cbRoturaCristalSi.Checked = false;
            cbSupDer.Checked = false;
            cbSupIzq.Checked = false;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void Refrescar()
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                var lst = (from d in db.Inspeccion
                           join Empleado in db.Empleado
                           on d.IdEmpleado equals Empleado.idEmpleado
                           join Vehiculo in db.Vehiculo
                           on d.IdVehiculo equals Vehiculo.idVehiculo
                           join cliente in db.cliente
                           on d.IdCliente equals cliente.idCliente
                           select new
                           {
                               Id = d.idInspeccion,
                               Cliente = cliente.Nombre,
                               Empleado = Empleado.Nombre,
                               Vehiculo = Vehiculo.Descripcion,
                               Ralladura = d.Ralladura,
                               CantidadCombustible = d.Cantidad_combustible,
                               GomaRespuesta = d.Goma_respuesta,
                               Gato = d.Gato,
                               RoturaCristal = d.Rotura_cristal,
                               GomaSupIzq = d.goma_sup_izq,
                               GomaSupDer = d.goma_sup_der,
                               GomaInfIzq = d.goma_inf_izq,
                               GomaInfDer = d.goma_inf_der,
                               Fecha = d.fecha,
                               Estado = d.Estado
                           }).AsQueryable();

                if (!txtFiltrar.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Empleado.Contains(txtFiltrar.Text.Trim()) ||
                    d.Cliente.Contains(txtFiltrar.Text.Trim()) ||
                    d.Vehiculo.Contains(txtFiltrar.Text.Trim()) ||
                    d.Estado.Contains(txtFiltrar.Text.Trim()));
                }
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private void ObtenerDatos()
        {
            using (RentCarDBEntities db = new RentCarDBEntities())
            {
                var lstEmpleado = db.Empleado.Where(x => x.Estado == "A").Select(x => new { x.idEmpleado, x.Nombre }).ToList();
                cmbEmpleado.DataSource = lstEmpleado;
                cmbEmpleado.DisplayMember = "Nombre";
                cmbEmpleado.ValueMember = "idEmpleado";
                if (cmbEmpleado.Items.Count > 1)
                {
                    cmbEmpleado.SelectedIndex = -1;
                }

                var lstCliente = db.cliente.Where(x => x.Estado == "A").Select(x => new { x.idCliente, x.Nombre }).ToList();
                cmbCliente.DataSource = lstCliente;
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "idCliente";
                if(cmbCliente.Items.Count > 1)
                {
                    cmbCliente.SelectedIndex = -1;
                }

                var lstVehiculo = db.Vehiculo.Where(x => x.Estado == "R").Select(x => new { x.idVehiculo, x.Descripcion }).ToList();
                cmbVehiculo.DataSource = lstVehiculo;
                cmbVehiculo.DisplayMember = "Descripcion";
                cmbVehiculo.ValueMember = "idVehiculo";

                if(cmbEmpleado.Items.Count > 1)
                {
                    cmbEmpleado.SelectedIndex = -1;
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

        #region Boton Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(cmbVehiculo.Text.Trim()=="" || cmbEstado.Text.Trim()=="" || cmbCliente.Text.Trim()=="" || cmbCantidadCombus.Text.Trim()=="")
            {
                MessageBox.Show("Debes completar los campos vacios");
            }
            else
            {
                var emple = Convert.ToInt32(cmbEmpleado.SelectedValue.ToString());
                var clien = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
                var vehic = Convert.ToInt32(cmbVehiculo.SelectedValue.ToString());

                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    inspeccion = new Inspeccion();
                    inspeccion.IdCliente = clien;
                    inspeccion.IdEmpleado = emple;
                    inspeccion.IdVehiculo = vehic;
                    inspeccion.Estado = cmbEstado.Text;
                    inspeccion.fecha = dtpFecha.Value;
                    inspeccion.Cantidad_combustible = cmbCantidadCombus.Text;

                    if (cbRalladuraSi.Checked)
                    {
                        inspeccion.Ralladura = "S";
                    }
                    else
                    {
                        inspeccion.Ralladura = "N";
                    }

                    if (cbGomaResSi.Checked)
                    {
                        inspeccion.Goma_respuesta = "S";
                    }
                    else
                    {
                        inspeccion.Goma_respuesta = "N";
                    }

                    if (cbGatoSi.Checked)
                    {
                        inspeccion.Gato = "S";
                    }
                    else
                    {
                        inspeccion.Gato = "N";
                    }

                    if (cbRoturaCristalSi.Checked)
                    {
                        inspeccion.Rotura_cristal = "S";
                    }
                    else
                    {
                        inspeccion.Rotura_cristal = "N";
                    }

                    if (cbSupDer.Checked)
                    {
                        inspeccion.goma_sup_der = "B";
                    }
                    else
                    {
                        inspeccion.goma_sup_der = "M";
                    }

                    if (cbSupIzq.Checked)
                    {
                        inspeccion.goma_sup_izq = "B";
                    }
                    else
                    {
                        inspeccion.goma_sup_izq = "M";
                    }

                    if (cbInfIzq.Checked)
                    {
                        inspeccion.goma_inf_izq = "B";
                    }
                    else
                    {
                        inspeccion.goma_inf_izq = "M";
                    }

                    if (cbInfDer.Checked)
                    {
                        inspeccion.goma_inf_der = "B";
                    }
                    else
                    {
                        inspeccion.goma_inf_der = "M";
                    }

                    db.Inspeccion.Add(inspeccion);

                    db.SaveChanges();

                    MessageBox.Show("El registro fue guardado satisfactoriamente");
                }
            }
            Refrescar();
            ObtenerDatos();
            Limpiar();

        }

        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? id = GetId();

            if(id != null)
            {
                using(RentCarDBEntities db = new RentCarDBEntities())
                {
                    var lstEmpleado = db.Empleado.Where(x => x.Estado == "A").Select(x => new { x.idEmpleado, x.Nombre }).ToList();
                    var lstCliente = db.cliente.Where(x => x.Estado == "A").Select(x => new { x.idCliente, x.Nombre }).ToList();
                    var lstVehiculo = db.Vehiculo.Where(x => x.Estado == "R").Select(x => new { x.idVehiculo, x.Descripcion }).ToList();

                    inspeccion = db.Inspeccion.Find(id);

                    cmbEstado.Text = inspeccion.Estado;
                    dtpFecha.Value = (DateTime)inspeccion.fecha;
                    cmbCantidadCombus.Text = inspeccion.Cantidad_combustible;

                    cmbEmpleado.DataSource = lstEmpleado;
                    cmbEmpleado.DisplayMember = "Nombre";
                    cmbEmpleado.ValueMember = "idEmpleado";

                    cmbCliente.DataSource = lstCliente;
                    cmbCliente.DisplayMember = "Nombre";
                    cmbCliente.ValueMember = "idCliente";

                    cmbVehiculo.DataSource = lstVehiculo;
                    cmbVehiculo.DisplayMember = "Descripcion";
                    cmbVehiculo.ValueMember = "idVehiculo";

                    if (inspeccion.Ralladura == "S")
                    {
                        cbRalladuraSi.Checked = true;
                    }
                    
                    if (inspeccion.Goma_respuesta == "S")
                    {
                        cbGomaResSi.Checked = true;
                    }
                    
                    if (inspeccion.Gato == "S")
                    {
                        cbGatoSi.Checked = true;
                    }
                    
                    if (inspeccion.Rotura_cristal == "S")
                    {
                        cbRoturaCristalSi.Checked = true;
                    }
                    
                    if (inspeccion.goma_sup_der == "B")
                    {
                        cbSupDer.Checked = true;
                    }
                    
                    if (inspeccion.goma_sup_izq == "B")
                    {
                        cbSupIzq.Checked = true;
                    }
                    
                    if (inspeccion.goma_inf_izq == "B")
                    {
                        cbInfIzq.Checked = true;
                    }
                    
                    if (inspeccion.goma_inf_der == "B")
                    {
                        cbInfDer.Checked = true;
                    }

                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnGuardar.Enabled = false;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (cmbVehiculo.Text.Trim() == "" || cmbEstado.Text.Trim() == "" || cmbCliente.Text.Trim() == "" || cmbCantidadCombus.Text.Trim() == "")
            {
                MessageBox.Show("Debes completar los campos vacios");
            }
            else
            {
                var emple = Convert.ToInt32(cmbEmpleado.SelectedValue.ToString());
                var clien = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
                var vehic = Convert.ToInt32(cmbVehiculo.SelectedValue.ToString());

                using (RentCarDBEntities db = new RentCarDBEntities())
                {                    
                    inspeccion.IdCliente = clien;
                    inspeccion.IdEmpleado = emple;
                    inspeccion.IdVehiculo = vehic;
                    inspeccion.Estado = cmbEstado.Text;
                    inspeccion.fecha = dtpFecha.Value;
                    inspeccion.Cantidad_combustible = cmbCantidadCombus.Text;

                    if (cbRalladuraSi.Checked)
                    {
                        inspeccion.Ralladura = "S";
                    }
                    else
                    {
                        inspeccion.Ralladura = "N";
                    }

                    if (cbGomaResSi.Checked)
                    {
                        inspeccion.Goma_respuesta = "S";
                    }
                    else
                    {
                        inspeccion.Goma_respuesta = "N";
                    }

                    if (cbGatoSi.Checked)
                    {
                        inspeccion.Gato = "S";
                    }
                    else
                    {
                        inspeccion.Gato = "N";
                    }

                    if (cbRoturaCristalSi.Checked)
                    {
                        inspeccion.Rotura_cristal = "S";
                    }
                    else
                    {
                        inspeccion.Rotura_cristal = "N";
                    }

                    if (cbSupDer.Checked)
                    {
                        inspeccion.goma_sup_der = "B";
                    }
                    else
                    {
                        inspeccion.goma_sup_der = "M";
                    }

                    if (cbSupIzq.Checked)
                    {
                        inspeccion.goma_sup_izq = "B";
                    }
                    else
                    {
                        inspeccion.goma_sup_izq = "M";
                    }

                    if (cbInfIzq.Checked)
                    {
                        inspeccion.goma_inf_izq = "B";
                    }
                    else
                    {
                        inspeccion.goma_inf_izq = "M";
                    }

                    if (cbInfDer.Checked)
                    {
                        inspeccion.goma_inf_der = "B";
                    }
                    else
                    {
                        inspeccion.goma_inf_der = "M";
                    }


                    db.Entry(inspeccion).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    MessageBox.Show("El registro fue editado satisfactoriamente");
                }
            }
            Refrescar();
            ObtenerDatos();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            try
            {
                if(id != null)
                {
                    using(RentCarDBEntities db = new RentCarDBEntities())
                    {
                        inspeccion = db.Inspeccion.Find(id);

                        db.Inspeccion.Remove(inspeccion);

                        db.SaveChanges();
                        Refrescar();
                        ObtenerDatos();
                        Limpiar();
                        MessageBox.Show("El registro ha sido eliminado satisfactoriamente!!");
                    }
                }
            }
            catch
            {
                Limpiar();
                MessageBox.Show("El registro no puede ser eliminado porque relaciones!!");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Refrescar();
            Limpiar();
        }
    }
}

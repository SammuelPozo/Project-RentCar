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
    public partial class FrmRenta : Form
    {
        public int? idRentaDevolucion;
        Renta_Devolucion renta_Devolucion = null;

        public FrmRenta(int? idRentaDevolucion = null)
        {

            InitializeComponent();
            this.idRentaDevolucion = idRentaDevolucion;
            Refrescar();
            ObtenerDatos();
            Limpiar();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FrmRenta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet5.Renta_Devolucion' Puede moverla o quitarla según sea necesario.
            this.renta_DevolucionTableAdapter.Fill(this.rentCarDBDataSet5.Renta_Devolucion);
            ObtenerDatos();
            Limpiar();

        }

        private void Limpiar()
        {
            btnBorrar.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;

            txtComentario.Clear();
            txtFiltrar.Clear();
            

            nmCantidadDias.Value = 0;
            nmMontoDia.Value = 0;

            cmbCliente.SelectedIndex = -1;
            cmbEmpleado.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbVehiculo.SelectedIndex = -1;
        }

        private void Refrescar()
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                var lst = (from d in db.Renta_Devolucion
                           join Empleado in db.Empleado
                           on d.IdEmpleado equals Empleado.idEmpleado
                           join Vehiculo in db.Vehiculo
                           on d.IdVehiculo equals Vehiculo.idVehiculo
                           join cliente in db.cliente
                           on d.IdCliente equals cliente.idCliente
                           select new
                           {
                               Id = d.idRentaDevolucion,
                               Placa = Vehiculo.No_placa,
                               Vehiculo = Vehiculo.Descripcion,
                               Cliente = cliente.Nombre,
                               CedulaCliente = cliente.Cedula,
                               FechaRenta = d.FechaRenta,
                               FechaDevolucion = d.FechaDevolucion,
                               MontoDia = d.MontoDia,
                               Dias = d.CantidadDias,
                               EstadoVehiculo = Vehiculo.Estado,
                               Comentario = d.Comentario,
                               Empleado = Empleado.Nombre,
                               CedulaEmpleado = Empleado.Cedula,
                               Estado = d.Estado
                           }).AsQueryable();

                if (!txtFiltrar.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Empleado.Contains(txtFiltrar.Text.Trim()) || d.Cliente.Contains(txtFiltrar.Text.Trim()));
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

                var lstCliente = db.cliente.Where(x => x.Estado == "A").Select(x => new { x.idCliente, x.Nombre }).ToList();
                cmbCliente.DataSource = lstCliente;
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "idCliente";

                var lstVehiculo = db.Vehiculo.Where(x => x.Estado == "D").Select(x => new { x.idVehiculo, x.Descripcion }).ToList();
                cmbVehiculo.DataSource = lstVehiculo;
                cmbVehiculo.DisplayMember = "Descripcion";
                cmbVehiculo.ValueMember = "idVehiculo";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtComentario.Text.Trim()=="" || cmbCliente.Text.Trim() == "" || cmbEmpleado.Text.Trim() == "" || cmbVehiculo.Text.Trim() == ""
                || cmbEstado.Text.Trim() == "" || nmMontoDia.Value == 0 || nmCantidadDias.Value == 0)
            {
                MessageBox.Show("Debes de completar los campos vacios");
            }
            else
            {
                if(dtpFechaRenta.Value > dtpFechaDevolucion.Value)
                {
                    MessageBox.Show("La fecha de devolucion es menor a la de renta");
                }
                else
                {
                    var emple = Convert.ToInt32(cmbEmpleado.SelectedValue.ToString());
                    var clien = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
                    var vehic = Convert.ToInt32(cmbVehiculo.SelectedValue.ToString()); 

                    using (RentCarDBEntities db = new RentCarDBEntities())
                    {
                        renta_Devolucion = new Renta_Devolucion();
                        renta_Devolucion.IdCliente = clien;
                        renta_Devolucion.IdEmpleado = emple;
                        renta_Devolucion.IdVehiculo = vehic;
                        renta_Devolucion.FechaRenta = dtpFechaRenta.Value;
                        renta_Devolucion.FechaDevolucion = dtpFechaDevolucion.Value;
                        renta_Devolucion.MontoDia = nmMontoDia.Value;
                        renta_Devolucion.CantidadDias = nmCantidadDias.Value.ToString();
                        renta_Devolucion.Comentario = txtComentario.Text;
                        //renta_Devolucion.Estado = cmbEstado.Text;

                        if (cmbEstado.Text == "Activo")
                        {
                            renta_Devolucion.Estado = "A";
                        }
                        else if (cmbEstado.Text == "Inactivo")
                        {
                            renta_Devolucion.Estado = "I";
                        }

                        db.Renta_Devolucion.Add(renta_Devolucion);

                        db.SaveChanges();

                        MessageBox.Show("El registro se ha guardado satisfactoriamente!!");
                    }
                }
            }
            Refrescar();
            ObtenerDatos();
            Limpiar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    var lstEmpleado = db.Empleado.Where(x => x.Estado == "A").Select(x => new { x.idEmpleado, x.Nombre }).ToList();
                    var lstCliente = db.cliente.Where(x => x.Estado == "A").Select(x => new { x.idCliente, x.Nombre }).ToList();
                    var lstVehiculo = db.Vehiculo.Where(x => x.Estado == "R" || x.Estado ==  "D").Select(x => new { x.idVehiculo, x.Descripcion }).ToList();
                    
                    renta_Devolucion = db.Renta_Devolucion.Find(id);

                    txtComentario.Text = renta_Devolucion.Comentario;
                    dtpFechaRenta.Value = renta_Devolucion.FechaRenta;
                    dtpFechaDevolucion.Value = renta_Devolucion.FechaDevolucion;
                    nmCantidadDias.Value = Convert.ToDecimal(renta_Devolucion.CantidadDias);
                    nmMontoDia.Value = renta_Devolucion.MontoDia;
                    cmbEstado.Text = renta_Devolucion.Estado;


                    cmbEmpleado.DataSource = lstEmpleado;
                    cmbEmpleado.DisplayMember = "Nombre";
                    cmbEmpleado.ValueMember = "idEmpleado";

                    cmbCliente.DataSource = lstCliente;
                    cmbCliente.DisplayMember = "Nombre";
                    cmbCliente.ValueMember = "idCliente";

                    cmbVehiculo.DataSource = lstVehiculo;
                    cmbVehiculo.DisplayMember = "Descripcion";
                    cmbVehiculo.ValueMember = "idVehiculo";

                    btnEditar.Enabled = true;
                    btnBorrar.Enabled = true;
                    btnGuardar.Enabled = false;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtComentario.Text.Trim() == "" || cmbCliente.Text.Trim() == "" || cmbEmpleado.Text.Trim() == "" || cmbVehiculo.Text.Trim() == ""
                || cmbEstado.Text.Trim() == "" || nmMontoDia.Value == 0 || nmCantidadDias.Value == 0)
            {
                MessageBox.Show("Debes de completar los campos vacios");
            }
            else
            {
                if (dtpFechaRenta.Value > dtpFechaDevolucion.Value)
                {
                    MessageBox.Show("La fecha de devolucion es menor a la de renta");
                }
                else
                {
                    var emple = Convert.ToInt32(cmbEmpleado.SelectedValue.ToString());
                    var clien = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
                    var vehic = Convert.ToInt32(cmbVehiculo.SelectedValue.ToString());

                    using (RentCarDBEntities db = new RentCarDBEntities())
                    {
                        renta_Devolucion.IdCliente = clien;
                        renta_Devolucion.IdEmpleado = emple;
                        renta_Devolucion.IdVehiculo = vehic;
                        renta_Devolucion.FechaRenta = dtpFechaRenta.Value;
                        renta_Devolucion.FechaDevolucion = dtpFechaDevolucion.Value;
                        renta_Devolucion.MontoDia = nmMontoDia.Value;
                        renta_Devolucion.CantidadDias = nmCantidadDias.Value.ToString();
                        renta_Devolucion.Comentario = txtComentario.Text;
                        //renta_Devolucion.Estado = cmbEstado.Text;

                        if (cmbEstado.Text == "Activo")
                        {
                            renta_Devolucion.Estado = "A";
                        }
                        else if (cmbEstado.Text == "Inactivo")
                        {
                            renta_Devolucion.Estado = "I";
                        }

                        db.Entry(renta_Devolucion).State = System.Data.Entity.EntityState.Modified;

                        db.SaveChanges();

                        MessageBox.Show("El registro se ha editado satisfactoriamente!!");
                    }
                }
            }
            Refrescar();
            ObtenerDatos();
            Limpiar();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            try
            {
                if(id != null)
                {
                    using(RentCarDBEntities db = new RentCarDBEntities())
                    {
                        renta_Devolucion = db.Renta_Devolucion.Find(id);

                        db.Renta_Devolucion.Remove(renta_Devolucion);

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

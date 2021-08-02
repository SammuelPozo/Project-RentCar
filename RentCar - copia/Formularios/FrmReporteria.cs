using RentCar.Models;
using SpreadsheetLight;
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

namespace RentCar.Formularios
{
    public partial class FrmReporteria : Form
    {
        public FrmReporteria()
        {
            InitializeComponent();
            Refrescar();
            ObtenerDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmReporteria_Load(object sender, EventArgs e)
        {
            Refrescar();
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
                           join Marca in db.Marca
                           on Vehiculo.IdMarca equals Marca.idMarca
                           join Modelo in db.Modelo
                           on Vehiculo.IdModelo equals Modelo.idModelo
                           join Tipo_combustible in db.Tipo_combustible
                           on Vehiculo.IdTipoCombustible equals Tipo_combustible.idTipoCombustible
                           join Tipo_vehiculo in db.Tipo_vehiculo
                           on Vehiculo.IdTipoVehiculo equals Tipo_vehiculo.idTipoVehiculo
                           where ckFechaRenta.Checked ? DbFunctions.TruncateTime(d.FechaRenta) >= DbFunctions.TruncateTime(dtpDesde.Value) &&
                                 DbFunctions.TruncateTime(d.FechaRenta) >= DbFunctions.TruncateTime(dtpDesde.Value) : true
                           select new
                           {
                               Id = d.idRentaDevolucion,
                               Vehiculo = Vehiculo.Descripcion,
                               EstadoVehiculo = Vehiculo.Estado,
                               Marca = Marca.Descripcion,
                               Modelo = Modelo.Descripcion,
                               TipoVehiculo = Tipo_vehiculo.Descripcion,
                               TipoCombustible = Tipo_combustible.Descripcion,
                               Cliente = cliente.Nombre,
                               ClienteCedula = cliente.Cedula,
                               Empleado = Empleado.Nombre,
                               EmpleadoCedula = Empleado.Cedula,
                               FechaRenta = d.FechaRenta,
                               FechaDevolucion = d.FechaDevolucion,
                               Dia = d.CantidadDias,
                               MontoXDias = d.MontoDia,
                               Estado = d.Estado
                           }).AsQueryable();

                if (!cmbTipoVehiculo.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.TipoVehiculo.Contains(cmbTipoVehiculo.Text.Trim()));
                }
                if (!cmbTipoCombs.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.TipoCombustible.Contains(cmbTipoCombs.Text.Trim()));
                }
                if (!cmbModelo.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Modelo.Contains(cmbModelo.Text.Trim()));
                }
                if (!cmbMarca.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Marca.Contains(cmbMarca.Text.Trim()));
                }
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private void ObtenerDatos()
        {
            using (RentCarDBEntities db = new RentCarDBEntities())
            {
                var lstModelo = db.Modelo.Where(x => x.Estado == "A").Select(x => new { x.idModelo, x.Descripcion }).ToList();
                cmbModelo.DataSource = lstModelo;
                cmbModelo.DisplayMember = "Descripcion";
                cmbModelo.ValueMember = "idModelo";
                if(cmbModelo.Items.Count > 1)
                {
                    cmbModelo.SelectedIndex = -1;
                }
  
                var lstMarca = db.Marca.Where(x => x.Estado == "A").Select(x => new { x.idMarca, x.Descripcion }).ToList();
                cmbMarca.DataSource = lstMarca;
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "idMarca";
                if (cmbMarca.Items.Count > 1)
                {
                    cmbMarca.SelectedIndex = -1;
                }

                var lstTipoCombs = db.Tipo_combustible.Where(x => x.Estado == "A").Select(x => new { x.idTipoCombustible, x.Descripcion }).ToList();
                cmbTipoCombs.DataSource = lstTipoCombs;
                cmbTipoCombs.DisplayMember = "Descripcion";
                cmbTipoCombs.ValueMember = "idTipoCombustible";
                if (cmbTipoCombs.Items.Count > 1)
                {
                    cmbTipoCombs.SelectedIndex = -1;
                }

                var lstVehiculo = db.Tipo_vehiculo.Where(x => x.Estado == "A").Select(x => new { x.idTipoVehiculo, x.Descripcion }).ToList();
                cmbTipoVehiculo.DataSource = lstVehiculo;
                cmbTipoVehiculo.DisplayMember = "Descripcion";
                cmbTipoVehiculo.ValueMember = "idTipoVehiculo";
                if (cmbTipoVehiculo.Items.Count > 1)
                {
                    cmbTipoVehiculo.SelectedIndex = -1;
                }
            }
        }

        //private void CheckboxAtive()
        //{
        //    if(ckFechaRenta.Checked == true)
        //    {
        //        dtpDesde.Enabled = true;
        //        dtpHasta.Enabled = true;
        //    }
        //    else
        //    {
        //        dtpDesde.Enabled = false;
        //        dtpHasta.Enabled = false;
        //    }

        //    if (ckMarca.Checked == true)
        //    {
        //        cmbMarca.Enabled = true;
        //    }
        //    else
        //    {
        //        cmbMarca.Enabled = false;
        //    }

        //    if(ckModelo.Checked == true)
        //    {
        //        cmbModelo.Enabled = true;
        //    }
        //    else
        //    {
        //        cmbModelo.Enabled = false;
        //    }

        //    if(ckTipoCombs.Checked == true)
        //    {
        //        cmbTipoCombs.Enabled = true;
        //    }
        //    else
        //    {
        //        cmbTipoCombs.Enabled = false;
        //    }
            
        //    if(ckTipoVehiculo.Checked == true)
        //    {
        //        cmbTipoVehiculo.Enabled = true;
        //    }
        //    else
        //    {
        //        cmbTipoVehiculo.Enabled = false;
        //    }
        //}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Refrescar();
            cmbModelo.SelectedIndex = -1;
            cmbMarca.SelectedIndex = -1;
            cmbTipoCombs.SelectedIndex = -1;
            cmbTipoVehiculo.SelectedIndex = -1;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                SLDocument sl = new SLDocument();
                SLStyle style = new SLStyle();
                style.Font.FontSize = 12;
                style.Font.Bold = true;

                int iC = 1;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    sl.SetCellValue(1, iC, column.HeaderText.ToString());
                    sl.SetCellStyle(1, iC, style);
                    iC++;
                }
                int iR = 2;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    sl.SetCellValue(iR, 1, row.Cells[0].Value.ToString());
                    sl.SetCellValue(iR, 2, row.Cells[1].Value.ToString());
                    sl.SetCellValue(iR, 3, row.Cells[2].Value.ToString());
                    sl.SetCellValue(iR, 4, row.Cells[3].Value.ToString());
                    sl.SetCellValue(iR, 5, row.Cells[4].Value.ToString());
                    sl.SetCellValue(iR, 6, row.Cells[5].Value.ToString());
                    sl.SetCellValue(iR, 7, row.Cells[6].Value.ToString());
                    sl.SetCellValue(iR, 8, row.Cells[7].Value.ToString());
                    sl.SetCellValue(iR, 9, row.Cells[8].Value.ToString());
                    sl.SetCellValue(iR, 10, row.Cells[9].Value.ToString());
                    sl.SetCellValue(iR, 11, row.Cells[10].Value.ToString());
                    sl.SetCellValue(iR, 12, row.Cells[11].Value.ToString());
                    sl.SetCellValue(iR, 13, row.Cells[12].Value.ToString());
                    sl.SetCellValue(iR, 14, row.Cells[13].Value.ToString());
                    sl.SetCellValue(iR, 15, row.Cells[14].Value.ToString());
                    iR++;
                }
                sl.SaveAs(@"C:\Users\Gabriel Sammuel Pozo\OneDrive\Escritorio\Exportaciones\Archivo.xlsx");
                MessageBox.Show("La tabla ha sido exportada.");

            }
            catch
            {
                MessageBox.Show("La carpeta asignada no existe");
            }
            
        }
    }
}

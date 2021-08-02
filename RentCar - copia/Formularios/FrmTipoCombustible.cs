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
    public partial class FrmTipoCombustible : Form
    {

        public int? idTipoCombustible;
        Tipo_combustible tipoCombustible = null;
        
        public FrmTipoCombustible(int? idTipoCombustible = null)
        {
            InitializeComponent();
            DeshabilitarLimpiar();

            this.idTipoCombustible = idTipoCombustible;
            
        }

        private void DeshabilitarLimpiar()
        {
            btnEliminar.Enabled = false;
            BtnEditar.Enabled = false;
            txtFiltro.Clear();
            txtDescripcionTipoCombustible.Clear();
            comboBox1.Text = "";
        }

        private void FrmTipoCombustible_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet2.Tipo_combustible' Puede moverla o quitarla según sea necesario.
            this.tipo_combustibleTableAdapter.Fill(this.rentCarDBDataSet2.Tipo_combustible);

        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString());
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
                var lst = from d in db.Tipo_combustible
                          select d;
                

                if (!txtFiltro.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Descripcion.Contains(txtFiltro.Text.Trim()));
                }

                dataGridView2.DataSource = lst.ToList();

            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                tipoCombustible = new Tipo_combustible();
                tipoCombustible.Descripcion = txtDescripcionTipoCombustible.Text;
                //tipoCombustible.Estado = comboBox1.Text;


                if (comboBox1.Text == "Activo")
                {
                    tipoCombustible.Estado = "A";
                }
                else if (comboBox1.Text == "Inactivo")
                {
                    tipoCombustible.Estado = "I";
                }

                db.Tipo_combustible.Add(tipoCombustible);

                db.SaveChanges();
                Refrescar();
                DeshabilitarLimpiar();
                MessageBox.Show("El tipo de combustible ha sido guardada satisfactoriamente!");
            }
            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                tipoCombustible.Descripcion = txtDescripcionTipoCombustible.Text;
                tipoCombustible.Estado = comboBox1.Text;

                if (comboBox1.Text == "Activo")
                {
                    tipoCombustible.Estado = "A";
                }
                else if (comboBox1.Text == "Inactivo")
                {
                    tipoCombustible.Estado = "I";
                }

                db.Entry(tipoCombustible).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                Refrescar();
                BtnGuardar.Enabled = true;
                btnEliminar.Enabled = false;
                BtnEditar.Enabled = false;
                MessageBox.Show("El tipo de combustible ha sido editado satisfactoriamente!");
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
                        tipoCombustible = db.Tipo_combustible.Find(id);
                        db.Tipo_combustible.Remove(tipoCombustible);

                        db.SaveChanges();
                    }
                    Refrescar();
                    DeshabilitarLimpiar();
                    MessageBox.Show("El tipo de combustible ha sido eliminado satisfactoriamente!");
                }
            }
            catch
            {
                MessageBox.Show("No se puede eliminar el registro ya que contiene relacion");
            }

            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.ClearSelection();
            dataGridView2.CurrentCell = null;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    tipoCombustible = db.Tipo_combustible.Find(id);
                    txtDescripcionTipoCombustible.Text = tipoCombustible.Descripcion;
                    comboBox1.Text = tipoCombustible.Estado;

                    BtnGuardar.Enabled = false;
                    BtnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeshabilitarLimpiar();
            BtnGuardar.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refrescar();
            DeshabilitarLimpiar();
        }
    }
}

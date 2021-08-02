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
    public partial class FrmMarca : Form
    {
        public int? idMarca;
        Marca marca = null;

        public FrmMarca(int? idMarca = null)
        {
            InitializeComponent();

            this.idMarca = idMarca;
            Limpiar();
        }

        private void Limpiar()
        {
            btnEliminar.Enabled = false;
            BtnEditar.Enabled = false;
            txtFiltro.Clear();
            txtDescripcionMarca.Clear();
            comboBox1.Text = "";
        }


        private void label1_Click(object sender, EventArgs e)
        {
            
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

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet.Marca' Puede moverla o quitarla según sea necesario.
            this.marcaTableAdapter.Fill(this.rentCarDBDataSet.Marca);
            Refrescar();
        }

        #region Refrescar Tabla
        private void Refrescar()
        {
            using (RentCarDBEntities db = new RentCarDBEntities())
            {
                var lst = from d in db.Marca
                          select d;

                if (!txtFiltro.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Descripcion.Contains(txtFiltro.Text.Trim()));
                }
                dataGridView2.DataSource = lst.ToList();
            }
        }
        #endregion

        #region Boton Guardar Marca
        private void BtnGuardarMarca_Click(object sender, EventArgs e)
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                marca = new Marca();
                marca.Descripcion = txtDescripcionMarca.Text;

                if(comboBox1.Text == "Activo")
                        marca.Estado = "A";
                    else if (comboBox1.Text == "Inactivo")
                    marca.Estado = "I";

                db.Marca.Add(marca);

                db.SaveChanges();
                Refrescar();
                Limpiar();
                MessageBox.Show("La marca ha sido guardada satisfactoriamente!");
            }
            
        }
        #endregion

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            using(RentCarDBEntities db = new RentCarDBEntities())
            {
                marca.Descripcion = txtDescripcionMarca.Text;
                marca.Estado = comboBox1.Text;

                db.Entry(marca).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
                Refrescar();
                BtnGuardarMarca.Enabled = true;
                BtnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                MessageBox.Show("La marca ha sido editada satisfactoriamente!");
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
                        marca = db.Marca.Find(id);
                        db.Marca.Remove(marca);

                        db.SaveChanges();
                    }
                    Refrescar();
                    Limpiar();
                    MessageBox.Show("La marca ha sido eliminada satisfactoriamente!");
                }
            }
            catch
            {
                MessageBox.Show("El registro no puede ser eliminado porque contiene relacion en otra tabla");
                Limpiar();
            }
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    marca = db.Marca.Find(id);
                    txtDescripcionMarca.Text = marca.Descripcion;
                    comboBox1.Text = marca.Estado;

                    BtnGuardarMarca.Enabled = false;
                    BtnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
            BtnGuardarMarca.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refrescar();
            Limpiar();
        }
    }
}

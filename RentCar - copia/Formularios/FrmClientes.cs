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
    public partial class FrmClientes : Form
    {

        public int? idCliente;
        cliente Cliente = null;
        public FrmClientes()
        {
            InitializeComponent();

            this.idCliente = idCliente;
            Limpiar();

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet7.cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter1.Fill(this.rentCarDBDataSet7.cliente);
            // TODO: esta línea de código carga datos en la tabla 'rentCarDBDataSet5.cliente' Puede moverla o quitarla según sea necesario.
            //this.clienteTableAdapter.Fill(this.rentCarDBDataSet5.cliente);
        }

        private void Limpiar()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            txtNombre.Clear();
            txtCedula.Clear();
            nmTarjeta.Value = 0;
            nmLimite.Value = 0;


            cmbEstado.Text = "";
            cmbTipoPersona.Text = "";
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

            if(id != null)
            {
                using(RentCarDBEntities db = new RentCarDBEntities())
                {
                    Cliente = db.cliente.Find(id);

                    txtNombre.Text = Cliente.Nombre;
                    txtCedula.Text = Cliente.Cedula;
                    cmbTipoPersona.Text = Cliente.Tipo_persona;
                    cmbEstado.Text = Cliente.Estado;

                    nmLimite.Value = Convert.ToDecimal(Cliente.Limite_cr);
                    nmTarjeta.Value = Convert.ToDecimal(Cliente.No_tarjeta_cr);


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
                var lst = from d in db.cliente
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


        private bool esUnRNCValido(string pRNC)

        {

            int vnTotal = 0;

            int[] digitoMult = new int[8] { 7, 9, 8, 6, 5, 4, 3, 2 };

            string vcRNC = pRNC.Replace("-", "").Replace(" ", "");

            string vDigito = vcRNC.Substring(8, 1);

            if (vcRNC.Length.Equals(9))

                if (!"145".Contains(vcRNC.Substring(0, 1)))

                    return false;

            for (int vDig = 1; vDig <= 8; vDig++)

            {

                int vCalculo = Int32.Parse(vcRNC.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];

                vnTotal += vCalculo;

            }

            if (vnTotal % 11 == 0 && vDigito == "1" || vnTotal % 11 == 1 && vDigito == "1" ||

                (11 - (vnTotal % 11)).Equals(vDigito))

                return true;

            else

                return false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(validaCedula(txtCedula.Text.ToString()) == true)
            {
                using (RentCarDBEntities db = new RentCarDBEntities())
                {
                    string ced = nmTarjeta.Value.ToString();
                    if (ced.Length != 16)
                    {
                        MessageBox.Show("La tarjeta de credito debe tener 16 digitos.");
                    }
                    else
                    {
                        var exists = db.cliente.Any(x => x.Cedula.Equals(txtCedula.Text));

                        if (exists && idCliente == null)
                        {
                            MessageBox.Show("Este cliente ya ha sido registrado.");
                            return;
                        }
                        else
                        {
                            Cliente = new cliente();
                            Cliente.Nombre = txtNombre.Text;
                            Cliente.Cedula = txtCedula.Text;

                            if(cmbEstado.Text == "Activo")
                            {
                                Cliente.Estado = "A";
                            }else if(cmbEstado.Text == "Inactivo")
                            {
                                Cliente.Estado = "I";
                            }

                            if (cmbTipoPersona.Text == "Fisica")
                            {
                                Cliente.Tipo_persona = "F";
                            }
                            else if (cmbTipoPersona.Text == "Juridica")
                            {
                                Cliente.Tipo_persona = "J";
                            }

                            Cliente.No_tarjeta_cr = nmTarjeta.Value.ToString();
                            Cliente.Limite_cr = nmLimite.Value.ToString();

                            db.cliente.Add(Cliente);

                            db.SaveChanges();

                            Refrescar();
                            Limpiar();
                            MessageBox.Show("El cliente ha sido registrado satisfactoriamente");
                        }
                    }
                }
                
                
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
                    
                    Cliente.Nombre = txtNombre.Text;
                    //Cliente.Tipo_persona = cmbTipoPersona.Text;
                    Cliente.Cedula = txtCedula.Text;
                    //Cliente.No_tarjeta_cr = txtTarjeta.Text;
                    //Cliente.Limite_cr = txtLimiteCredito.Text;
                    //Cliente.Estado = cmbEstado.Text;

                    if (cmbEstado.Text == "Activo")
                    {
                        Cliente.Estado = "A";
                    }
                    else if (cmbEstado.Text == "Inactivo")
                    {
                        Cliente.Estado = "I";
                    }

                    if (cmbTipoPersona.Text == "Fisica")
                    {
                        Cliente.Tipo_persona = "F";
                    }
                    else if (cmbTipoPersona.Text == "Juridica")
                    {
                        Cliente.Tipo_persona = "J";
                    }

                    Cliente.No_tarjeta_cr = nmTarjeta.Value.ToString();
                    Cliente.Limite_cr = nmLimite.Value.ToString();

                    db.Entry(Cliente).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                }
                Refrescar();
                Limpiar();
                btnGuardar.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                MessageBox.Show("El cliente ha sido editado satisfactoriamente");
            }
            else
            {
                MessageBox.Show("Esta cedula no es valida!");
                txtCedula.Clear();
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
                        Cliente = db.cliente.Find(id);
                        db.cliente.Remove(Cliente);

                        db.SaveChanges();
                    }
                    Refrescar();
                    Limpiar();
                    btnGuardar.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    MessageBox.Show("El cliente ha sido eliminado satisfactoriamente!");
                }
            }
            catch
            {
                MessageBox.Show("El registro no puede ser eliminado porque contiene registros asignados");
                Limpiar();
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

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}


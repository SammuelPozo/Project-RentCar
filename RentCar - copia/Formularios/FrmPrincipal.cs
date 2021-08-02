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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            SubMenuMantenimiento.Visible = false;
            SubMenuServicios.Visible = false;
            SubMenuReportes.Visible = false;
        }

        private void HideSubMenu()
        {
            if (SubMenuMantenimiento.Visible == true) 
            
                SubMenuReportes.Visible = false;
                SubMenuReportes.Visible = false;
            
            if(SubMenuServicios.Visible == true)
            
                SubMenuReportes.Visible = false;
                SubMenuMantenimiento.Visible = false;
            
            if(SubMenuReportes.Visible == true)
            
                SubMenuMantenimiento.Visible = false;
                SubMenuServicios.Visible = false;
            
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        #region Mantenimiento
        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            showSubMenu(SubMenuMantenimiento);
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmMarca());
            //my code here
            HideSubMenu();
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmModelo());
            //my code here
            HideSubMenu();
        }

        private void btnTipoVehiculo_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmTipoVehiculo());
            //my code here
            HideSubMenu();
        }

        private void btnTipoCombustible_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmTipoCombustible());
            //my code here
            HideSubMenu();
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmVehiculo());
            //my code here
            HideSubMenu();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmClientes());
            //my code here
            HideSubMenu();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmEmpleados());
            //my code here
            HideSubMenu();
        }

        #endregion

        #region Servicios
        private void btnServicios_Click(object sender, EventArgs e)
        {
            showSubMenu(SubMenuServicios);
        }

        private void btnRenta_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmRenta());
            //my code here
            HideSubMenu();
        }

        private void btnInspeccion_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmInspeccion());
            //my code here
            HideSubMenu();
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmDevolucion());
            //my code here
            HideSubMenu();
        }
        #endregion

        #region Reporte
        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(SubMenuReportes);
        }

        private void btnReporteria_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FrmReporteria());
            //my code here
            HideSubMenu();
        }
        #endregion

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Form activoForm = null;

        private void abrirPanelHijo(Form formHijo)
        {
            if (activoForm != null)
                activoForm.Close();
            activoForm = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelFomrHijo.Controls.Add(formHijo);
            panelFomrHijo.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }
    }
}

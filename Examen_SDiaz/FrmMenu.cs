using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen_SDiaz
{
    public partial class FrmMenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        FrmUsuarios frmUsuarios;
        FrmProducto FrmProducto = null;

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (frmUsuarios == null)
            {
                frmUsuarios = new FrmUsuarios();
                frmUsuarios.MdiParent = this;
                frmUsuarios.Show();
            }
            else
            {
                frmUsuarios.Activate();
            }
            
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (FrmProducto == null)
            {
                FrmProducto = new FrmProducto();
                FrmProducto.MdiParent = this;
                FrmProducto.Show();
            }
            else
            {
                FrmProducto.Activate();
            }
        }
    }
}

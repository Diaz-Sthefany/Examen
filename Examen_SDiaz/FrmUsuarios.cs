using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_SDiaz
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();
        string operacion = string.Empty;
        Usuario user = new Usuario();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuarioDA.ListarUsuarios();


        }

        private void UsuariosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo"; 
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;    
            RolComboBox.Enabled = true; 
            EstaActivoCheckBox.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;


        }

        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            RolComboBox.Enabled = false;
            EstaActivoCheckBox.Enabled = false;

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;


        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Text = " ";
            ClaveTextBox.Text = String.Empty;
            RolComboBox.Text = String.Empty;
            EstaActivoCheckBox.Enabled = true;
        }
        private void RolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            user.Codigo = CodigoTextBox.Text;
            user.Nombre = NombreTextBox.Text;   
            user.Clave = ClaveTextBox.Text;
            user.Rol = RolComboBox.Text;
            user.EstaActivo = EstaActivoCheckBox.Checked;

            if (operacion == "Nuevo")
            {
                bool inserto = usuarioDA.InsertarUsuario(user);

                if (inserto)
                {

                    MessageBox.Show("Usuario Creado");
                    ListarUsuarios();
                    LimpiarControles();
                    DesabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario No Se Pudo  Crear");
                }
            }
            else if (operacion == "Modificar")
            {
                bool modifico = usuarioDA.ModificarUsuario(user);
                {
                    if (modifico)
                    {
                        MessageBox.Show("Usuario Modifico");
                        ListarUsuarios();
                        LimpiarControles();
                        DesabilitarControles();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no se pudo Modificar");
                    }
                }
                    

                

            }

            
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ClaveTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Clave"].Value.ToString();
                RolComboBox.Text = UsuariosDataGridView.CurrentRow.Cells["Rol"].Value.ToString();
                EstaActivoCheckBox.Checked = Convert.ToBoolean(UsuariosDataGridView.CurrentRow.Cells["EstaActivo"].Value);
                HabilitarControles();
            }

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = usuarioDA.EliminarUsuario(UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {

                    MessageBox.Show("Usuario Eliminado");
                    ListarUsuarios();
                    
                }
                else
                {
                    MessageBox.Show("Usuario No Se Pudo  Eliminar");
                }
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        E_cliente objEntidad = new E_cliente();
        N_cliente objNegocio = new N_cliente();
        public bool editarse = false;
        public string Id;

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validarcampos())
            {
                if (editarse == false)
                {
                    try
                    {
                        objEntidad.Nombre = txt_nombre.Text.Trim();
                        objEntidad.Apellido = txt_apellido.Text.Trim();
                        objEntidad.Cedula = txt_cedula.Text.Trim();
                        objEntidad.Contacto = txt_contacto.Text.Trim();
                        objEntidad.Carro = txt_carro.Text.Trim();
                        objEntidad.Modelo = txt_modelo.Text.Trim(); 
                        objEntidad.Año = txt_año.Text.Trim();
                        objEntidad.Placa = txt_placa.Text.Trim();
                        objEntidad.Descripcion = txt_descripcion.Text.Trim();

                        objNegocio.agregarcliente(objEntidad);
                        MessageBox.Show("se han guardado los datos correctamente.");
                        mostrartabla("");
                        limpiarcampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se ha guardado los datos correctamente" + ex);
                    }
                }
                else if(editarse == true)
                {
                    try
                    {
                        objEntidad.IdCliente = Convert.ToInt32(Id);
                        objEntidad.Nombre = txt_nombre.Text.Trim();
                        objEntidad.Apellido = txt_apellido.Text.Trim();
                        objEntidad.Cedula = txt_cedula.Text.Trim();
                        objEntidad.Contacto = txt_contacto.Text.Trim();
                        objEntidad.Carro = txt_carro.Text.Trim();
                        objEntidad.Modelo = txt_modelo.Text.Trim();
                        objEntidad.Año = txt_año.Text.Trim();
                        objEntidad.Placa = txt_placa.Text.Trim();
                        objEntidad.Descripcion = txt_descripcion.Text.Trim();

                        objNegocio.editarcliente(objEntidad);
                        MessageBox.Show("se han editado los datos correctamente.");
                        mostrartabla("");
                        editarse = false;
                        limpiarcampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se ha editado los datos correctamente" + ex);
                    }
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (tablaClientes.SelectedRows.Count > 0)
            {
                editarse = true;
                Id = tablaClientes.CurrentRow.Cells[0].Value.ToString();
                txt_nombre.Text = tablaClientes.CurrentRow.Cells[1].Value.ToString();
                txt_apellido.Text = tablaClientes.CurrentRow.Cells[2].Value.ToString();
                txt_cedula.Text = tablaClientes.CurrentRow.Cells[3].Value.ToString();
                txt_contacto.Text = tablaClientes.CurrentRow.Cells[4].Value.ToString();
                txt_carro.Text = tablaClientes.CurrentRow.Cells[5].Value.ToString();
                txt_modelo.Text = tablaClientes.CurrentRow.Cells[6].Value.ToString();
                txt_año.Text = tablaClientes.CurrentRow.Cells[7].Value.ToString();
                txt_placa.Text = tablaClientes.CurrentRow.Cells[8].Value.ToString();
                txt_descripcion.Text = tablaClientes.CurrentRow.Cells[9].Value.ToString();
                mostrartabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la informacion que desea editar.");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (tablaClientes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas Seguro que Deseas Eliminar estos datos", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    objEntidad.IdCliente = Convert.ToInt32(tablaClientes.CurrentRow.Cells[0].Value.ToString());
                    objNegocio.eliminarcliente(objEntidad);
                    mostrartabla("");
                }
            }
        }
        public void acciontabla()
        {
            tablaClientes.Columns[0].Visible = false;
            tablaClientes.ClearSelection();
        }
        public void mostrartabla(string buscar)
        {
            tablaClientes.DataSource = objNegocio.datosCliente(buscar);
        }
        private bool validarcampos()
        {
            bool Ok = true;
            if (txt_nombre.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_nombre, "Ingrese un nombre.");
            }
            if (txt_apellido.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_apellido, "Ingrese un apellido.");
            }
            if (txt_cedula.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_cedula, "Ingrese su numero de cedula.");
            }
            if (txt_contacto.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_contacto, "Ingrese su contacto.");
            }
            if (txt_carro.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_carro, "Ingrese la marca del carro.");
            }
            if (txt_modelo.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_modelo, "Ingrese el modelo.");
            }
            if (txt_año.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_año, "Ingrese el año.");
            }
            if (txt_placa.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_placa, "Ingrese el numero de placa.");
            }
            if (txt_descripcion.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_descripcion, "Describa que problome tiene su vehiculo.");
            }
            return Ok;
        }
        public void limpiarcampos()
        {
            editarse = false;
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_cedula.Text = "";
            txt_contacto.Text = "";
            txt_carro.Text = "";
            txt_modelo.Text = "";
            txt_año.Text = "";
            txt_placa.Text = "";
            txt_descripcion.Text = "";
            txt_nombre.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            mostrartabla("");
            acciontabla();
            validacion();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            mostrartabla(txt_buscar.Text);
        }

        public bool validacion()
        {
            bool Ok = true;
            if(UserLoginCache.cargo == cargo.Usuario)
            {
                btn_editar.Enabled = false;
                btn_eliminar.Enabled = false;
            }
            return Ok;
        }
    }
}

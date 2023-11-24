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

namespace CapaPresentacion
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        E_inventario objEntidad = new E_inventario();
        N_inventario objNegocio = new N_inventario();
        public bool editarse = false;
        public string Id;
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (validarcampos())
            {
                if(editarse == false)
                {
                    try
                    {
                        objEntidad.Codigo = txt_codigo.Text.Trim();
                        objEntidad.Descripcion = txt_descripcion.Text.Trim();
                        objEntidad.Precio = Convert.ToDecimal(txt_precio.Text);
                        objEntidad.Existencia = Convert.ToInt32(txt_existencia.Text);

                        objNegocio.agregarproducto(objEntidad);
                        MessageBox.Show("se han guardado los datos correctamente.");
                        mostrartabla("");
                        limpiarcampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se ha guardado los datos correctamente" + ex);
                    }
                }
                else if (editarse == true)
                {
                    try
                    {
                        objEntidad.IdInve = Convert.ToInt32(Id);
                        objEntidad.Codigo = txt_codigo.Text.Trim();
                        objEntidad.Descripcion = txt_descripcion.Text.Trim();
                        objEntidad.Precio = Convert.ToDecimal(txt_precio.Text);
                        objEntidad.Existencia = Convert.ToInt32(txt_existencia.Text);

                        objNegocio.editarproducto(objEntidad);
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
            if (tablaProductos.SelectedRows.Count > 0)
            {
                editarse = true;
                Id = tablaProductos.CurrentRow.Cells[0].Value.ToString();
                txt_codigo.Text = tablaProductos.CurrentRow.Cells[1].Value.ToString();
                txt_descripcion.Text = tablaProductos.CurrentRow.Cells[2].Value.ToString();
                txt_precio.Text = tablaProductos.CurrentRow.Cells[3].Value.ToString();
                txt_existencia.Text = tablaProductos.CurrentRow.Cells[4].Value.ToString();
                mostrartabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la informacion que desea editar.");
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (tablaProductos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Estas Seguro que Deseas Eliminar estos datos", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    objEntidad.IdInve = Convert.ToInt32(tablaProductos.CurrentRow.Cells[0].Value.ToString());
                    objNegocio.eliminarproducto(objEntidad);
                    mostrartabla("");
                }
            }
        }
        public void acciontabla()
        {
            tablaProductos.Columns[0].Visible = false;
            tablaProductos.ClearSelection();
        }
        public void mostrartabla(string buscar)
        {
            tablaProductos.DataSource = objNegocio.datosProducto(buscar);
        }
        private bool validarcampos()
        {
            bool Ok = true;
            if (txt_codigo.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_codigo, "Ingrese un codigo de producto.");
            }
            if (txt_descripcion.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_descripcion, "Ingrese el nombre del producto.");
            }
            if (txt_precio.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_precio, "Ingrese un precio.");
            }
            if (txt_existencia.Text == "")
            {
                Ok = false;
                errorProvider1.SetError(txt_existencia, "Ingrese el numero de existencias del producto.");
            }
            return Ok;
        }
        public void limpiarcampos()
        {
            editarse = false;
            txt_codigo.Text = "";
            txt_descripcion.Text = "";
            txt_precio.Text = "";
            txt_existencia.Text = "";
            txt_codigo.Focus();
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            mostrartabla(txt_buscar.Text);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            validacion();
            mostrartabla("");
            acciontabla();
            
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_codigo.Text = "";
            txt_descripcion.Text = "";
            txt_precio.Text = "";
            txt_existencia.Text = "";
            txt_codigo.Focus();
        }

        public bool validacion()
        {
            bool Ok = true;
            if (UserLoginCache.cargo == cargo.Usuario)
            {
                btn_editar.Enabled = false;
                btn_eliminar.Enabled = false;
            }
            return Ok;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }
        

    }
}

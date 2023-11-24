using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        N_usuario objdatos = new N_usuario();

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            if (txt_usuario.Text != "USUARIO")
            {
                if (txt_contraseña.Text != "CONTRASEÑA")
                {
                    var validlogin = objdatos.selectlogin(txt_usuario.Text, txt_contraseña.Text);
                    if (validlogin == true)
                    {
                        Form1 menu = new Form1();
                        menu.Show();
                        menu.FormClosed += logout;
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Contraseña o usuario incorrecto.");
                }
            }
        }
        private void logout(object sender, FormClosedEventArgs e)
        {
            txt_contraseña.Clear();
            txt_usuario.Clear();
            this.Show();
            txt_usuario.Focus();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

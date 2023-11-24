using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaNegocio
{
    public class N_usuario
    {
        D_usuario objdatos = new D_usuario();
        public bool selectlogin(string usuario, string contraseña)
        {
            return objdatos.selectlogin(usuario, contraseña);
        }
    }
}

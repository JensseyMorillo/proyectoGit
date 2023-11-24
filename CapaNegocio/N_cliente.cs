using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaNegocio
{
    public class N_cliente
    {
        D_cliente objdatos = new D_cliente();
        public void agregarcliente(E_cliente cliente)
        {
            objdatos.Agregarcliente(cliente);
        }
        public void editarcliente(E_cliente cliente)
        {
            objdatos.Editarcliente(cliente);
        }
        public void eliminarcliente(E_cliente cliente)
        {
            objdatos.Eliminarcliente(cliente);
        }
        public List<E_cliente> datosCliente(string buscar)
        {
            return objdatos.datosCliente(buscar);
        }
    }
}

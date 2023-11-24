using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaNegocio
{
    public class N_inventario
    {
        D_inventario objdatos = new D_inventario();
        public void agregarproducto(E_inventario inventario)
        {
            objdatos.Agregarproducto(inventario);
        }
        public void editarproducto(E_inventario inventario)
        {
            objdatos.Editarproducto(inventario);
        }
        public void eliminarproducto(E_inventario inventario)
        {
            objdatos.Eliminarproducto(inventario);
        }
        public List<E_inventario> datosProducto(string buscar)
        {
            return objdatos.datosProducto(buscar);
        }
    }
}

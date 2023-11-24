using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_cliente
    {
        private int idCliente;
        private string nombre;
        private string apellido;
        private string cedula;
        private string contacto;
        private string carro;
        private string modelo;
        private string año;
        private string placa;
        private string descripcion;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Contacto { get => contacto; set => contacto = value; }
        public string Carro { get => carro; set => carro = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Año { get => año; set => año = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class D_cliente
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public void Agregarcliente(E_cliente cliente)
        {
            SqlCommand cmd = new SqlCommand("sp_agregarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
            cmd.Parameters.AddWithValue("@contacto", cliente.Contacto);
            cmd.Parameters.AddWithValue("@carro", cliente.Carro);
            cmd.Parameters.AddWithValue("@modelo", cliente.Modelo);
            cmd.Parameters.AddWithValue("@año", cliente.Año);
            cmd.Parameters.AddWithValue("@placa", cliente.Placa);
            cmd.Parameters.AddWithValue("@descripcion", cliente.Descripcion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void Editarcliente(E_cliente cliente)
        {
            SqlCommand cmd = new SqlCommand("sp_editarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
            cmd.Parameters.AddWithValue("@contacto", cliente.Contacto);
            cmd.Parameters.AddWithValue("@carro", cliente.Carro);
            cmd.Parameters.AddWithValue("@modelo", cliente.Modelo);
            cmd.Parameters.AddWithValue("@año", cliente.Año);
            cmd.Parameters.AddWithValue("@placa", cliente.Placa);
            cmd.Parameters.AddWithValue("@descripcion", cliente.Descripcion);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void Eliminarcliente(E_cliente cliente)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
            
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public List<E_cliente> datosCliente(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("sp_buscarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_cliente> listar = new List<E_cliente>();

            while (LeerFilas.Read())
            {
                listar.Add(new E_cliente
                {
                    IdCliente = LeerFilas.GetInt32(0),
                    Nombre = LeerFilas.GetString(1),
                    Apellido = LeerFilas.GetString(2),
                    Cedula = LeerFilas.GetString(3),
                    Contacto = LeerFilas.GetString(4),
                    Carro = LeerFilas.GetString(5),
                    Modelo = LeerFilas.GetString(6),
                    Año = LeerFilas.GetString(7),
                    Placa = LeerFilas.GetString(8),
                    Descripcion = LeerFilas.GetString(9),
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }
    }
}

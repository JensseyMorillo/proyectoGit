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
    public class D_inventario
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public void Agregarproducto(E_inventario inventario)
        {
            SqlCommand cmd = new SqlCommand("sp_agregarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@codigo", inventario.Codigo);
            cmd.Parameters.AddWithValue("@descripcion", inventario.Descripcion);
            cmd.Parameters.AddWithValue("@precio", inventario.Precio);
            cmd.Parameters.AddWithValue("@existencia", inventario.Existencia);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void Editarproducto(E_inventario inventario)
        {
            SqlCommand cmd = new SqlCommand("sp_editarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idInve", inventario.IdInve);
            cmd.Parameters.AddWithValue("@codigo", inventario.Codigo);
            cmd.Parameters.AddWithValue("@descripcion", inventario.Descripcion);
            cmd.Parameters.AddWithValue("@precio", inventario.Precio);
            cmd.Parameters.AddWithValue("@existencia", inventario.Existencia);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void Eliminarproducto(E_inventario inventario)
        {
            SqlCommand cmd = new SqlCommand("sp_eliminarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@idInve", inventario.IdInve);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public List<E_inventario> datosProducto(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("sp_buscarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", buscar);

            LeerFilas = cmd.ExecuteReader();

            List<E_inventario> listar = new List<E_inventario>();

            while (LeerFilas.Read())
            {
                listar.Add(new E_inventario
                {
                    IdInve = LeerFilas.GetInt32(0),
                    Codigo = LeerFilas.GetString(1),
                    Descripcion = LeerFilas.GetString(2),
                    Precio = LeerFilas.GetDecimal(3),
                    Existencia = LeerFilas.GetInt32(4),
                });
            }
            conexion.Close();
            LeerFilas.Close();
            return listar;
        }
    }
}

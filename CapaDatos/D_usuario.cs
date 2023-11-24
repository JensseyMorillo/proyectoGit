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
    public class D_usuario
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public bool selectlogin(string usuario, string contraseña)
        {


            try
            {

                SqlCommand cmd = new SqlCommand("SP_LOGIN", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                cmd.Parameters.AddWithValue("@VUSUARIO", usuario);
                cmd.Parameters.AddWithValue("@VCLAVE", contraseña);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserLoginCache.IDusuario = dr.GetInt32(0);
                        UserLoginCache.cargo = dr.GetString(1);
                    }
                    return true;

                }
                else
                    return false;
            }
            finally
            {
                conexion.Close();
            }

        }
        public void metodoCargo()
        {
            if (UserLoginCache.cargo == cargo.Administrador)
            {
                //codes
            }
            if (UserLoginCache.cargo == cargo.Usuario)
            {
                //codes
            }
        }
    }
}

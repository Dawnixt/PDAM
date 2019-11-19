using _08_CRUD_Personas_DAL.Connections;
using _08_CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUD_Personas_DAL.Manejadora
{
    public class clsManejadoraPersonasDAL
    {
        //Constructor que no sirve
        public clsManejadoraPersonasDAL()
        {

        }


        /// <summary>
        /// Crea una persoan en la bbdd
        /// </summary>
        /// <param name="persona">Que quieres crear</param>
        /// <returns></returns>
        public int aniadirPersona(clsPersona persona) {

            int filasCambiadas = 0;

            try
            {

                clsMyConnection conexion = new clsMyConnection();
                SqlConnection miConexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();

                miConexion = conexion.getConnection();

                comando.CommandText = "INSERT INTO PD_Personas (NombrePersona,ApellidosPersona,IDDepartamento,FechaNacimientoPersona,TelefonoPersona) VALUES(@nombre,@apellidos,@departamento,@fecha,@telefono)";

                comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
                comando.Parameters.Add("@apellidos",System.Data.SqlDbType.VarChar).Value = persona.ApellidosPersona;
                comando.Parameters.Add("@departamento",System.Data.SqlDbType.Int).Value = persona.IDDepartamento;
                comando.Parameters.Add("@fecha",System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
                comando.Parameters.Add("@telefono",System.Data.SqlDbType.VarChar).Value = persona.TelefonoPersona;

                comando.Connection = miConexion;
                filasCambiadas = comando.ExecuteNonQuery();

                conexion.closeConnection(ref miConexion);

            }
            catch (SqlException e)
            {

                throw e;

            }

            return filasCambiadas;

        }

        /// <summary>
        /// Actualiza una persona de la bbdd
        /// </summary>
        /// <param name="persona">La persona con los cambios hechos</param>
        /// <returns></returns>
        public int updatePersonaDAL(clsPersona persona) {

            int filasCambiadas = 0;

            try
            {

                clsMyConnection connection = new clsMyConnection();
                SqlConnection miconexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();

                miconexion = connection.getConnection();

                comando.CommandText = "Update PD_Personas SET NombrePersona = @nombre,ApellidosPersona = @apellidos,IDDepartamento = @departamento,FechaNacimientoPersona = @fecha,TelefonoPersona = @telefono WHERE idPersona = @id";

                comando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
                comando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPersona;
                comando.Parameters.Add("@departamento", System.Data.SqlDbType.Int).Value = persona.IDDepartamento;
                comando.Parameters.Add("@fecha", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
                comando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.TelefonoPersona;
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;

                comando.Connection = miconexion;
                filasCambiadas = comando.ExecuteNonQuery();

                connection.closeConnection(ref miconexion);

            }
            catch (SqlException e)
            {

                throw e;

            }

            return filasCambiadas;

        }

        /// <summary>
        /// Borra una persona de la bbdd
        /// </summary>
        /// <param name="id">De la persona que quieres borrar</param>
        /// <returns></returns>
        public int deletePersonaDAL(int id)
        {

            int filasCambiadas;

            try
            {

                clsMyConnection con = new clsMyConnection();
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();

                conexion = con.getConnection();

                comando.CommandText = "Delete From PD_Personas Where IdPersona = @idPersona";

                comando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = id;

                comando.Connection = conexion;
                filasCambiadas = comando.ExecuteNonQuery();

                con.closeConnection(ref conexion);

            }
            catch (SqlException e)
            {
                throw e;
            }

            return filasCambiadas;
        }

    }
}

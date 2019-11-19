using _08_CRUD_Personas_DAL.Connections;
using _08_CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUD_Personas_DAL.Lists
{
    public class clsListadoPersonasDAL
    {
        //Constructor que no sirve para nada
        public clsListadoPersonasDAL()
        {


        }

        /// <summary>
        /// Obtiene las personas de la bbdd
        /// </summary>
        /// <returns>Un listado con todas las personas de la bbdd</returns>
        public List<clsPersona> crearListadoPersonasDAL()
        {

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            clsMyConnection miconexion = new clsMyConnection();
            SqlConnection conexion = miconexion.getConnection();


            SqlCommand select = new SqlCommand();
            SqlDataReader reader;
            clsPersona objPersona;

            try
            {

                select.CommandText = "SELECT * FROM dbo.PD_Personas";
                select.Connection = conexion;
                reader = select.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        objPersona = new clsPersona();

                        objPersona.idPersona = (int)reader["idPersona"];

                        if (!String.IsNullOrEmpty(reader["NombrePersona"].ToString()))
                        {
                            objPersona.NombrePersona = (String)reader["NombrePersona"];

                        }

                        if (!String.IsNullOrEmpty(reader["ApellidosPersona"].ToString()))
                        {
                            objPersona.ApellidosPersona = (String)reader["ApellidosPersona"];
                        }
                            

                        if (!String.IsNullOrEmpty(reader["IDDepartamento"].ToString()))
                        {
                            objPersona.IDDepartamento = (int)reader["IDDepartamento"];
                        }
                            

                        if (!String.IsNullOrEmpty(reader["TelefonoPersona"].ToString()))
                        {
                            objPersona.TelefonoPersona = (String)reader["TelefonoPersona"];
                        }
                            

                        if (!String.IsNullOrEmpty(reader["FechaNacimientoPersona"].ToString()))
                        {
                            objPersona.FechaNacimiento = (DateTime)reader["FechaNacimientoPersona"];
                        }
                            
                        listadoPersonas.Add(objPersona);

                    }

                }

                reader.Close();

            }
            catch (SqlException s)
            {
                throw s;
            }
            finally
            {

                miconexion.closeConnection(ref conexion);

            }

            return listadoPersonas;

        }

        /// <summary>
        /// Obtiene la persona que tiene el mismo id de la bbdd
        /// </summary>
        /// <param name="id">De la persona que queremos</param>
        /// <returns>La persona que queremos de la bbdd</returns>
        public clsPersona obtenerPersonaIdDAL(int id)
        {

            clsPersona persona = new clsPersona();
            clsMyConnection con = new clsMyConnection();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;

            try
            {

                conexion = con.getConnection();

                comando.CommandText = "SELECT * FROM dbo.PD_Personas WHERE idPersona = @id";
                comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                comando.Connection = conexion;
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        persona.idPersona = (int)reader["idPersona"];

                        if (!String.IsNullOrEmpty(reader["NombrePersona"].ToString()))
                        {
                            persona.NombrePersona = (String)reader["NombrePersona"];
                        }


                        if (!String.IsNullOrEmpty(reader["ApellidosPersona"].ToString()))
                        {
                            persona.ApellidosPersona = (String)reader["ApellidosPersona"];
                        }


                        if (!String.IsNullOrEmpty(reader["IDDepartamento"].ToString()))
                        {
                            persona.IDDepartamento = (int)reader["IDDepartamento"];
                        }


                        if (!String.IsNullOrEmpty(reader["TelefonoPersona"].ToString()))
                        {
                            persona.TelefonoPersona = (String)reader["TelefonoPersona"];
                        }


                        if (!String.IsNullOrEmpty(reader["FechaNacimientoPersona"].ToString()))
                        {
                            persona.FechaNacimiento = (DateTime)reader["FechaNacimientoPersona"];
                        }
                    }
                        
                }

            }
            catch (SqlException e)
            {

                throw e;

            }
            finally
            {

                con.closeConnection(ref conexion);

            }

            return persona;

        }

    }

}

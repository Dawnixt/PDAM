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
    public class clsListadoDepartamentosDAL
    {
        //Constructor que no sirve para nada pero me siento raro sin el
        public clsListadoDepartamentosDAL()
        {



        }

        /// <summary>
        /// Coge todos los departamentos de la bbdd
        /// </summary>
        /// <returns>Una lista con los departamentos</returns>
        public List<clsDepartamento> crearListadoDepartamentosDAL()
        {

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            clsMyConnection miconexion = new clsMyConnection();
            SqlConnection conexion = miconexion.getConnection();


            SqlCommand select = new SqlCommand();
            SqlDataReader reader;
            clsDepartamento objDepartamento;

            try
            {

                select.CommandText = "SELECT * FROM dbo.PD_Departamentos";
                select.Connection = conexion;
                reader = select.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        objDepartamento = new clsDepartamento();

                        objDepartamento.idDepartamento = (int)reader["idDepartamento"];

                        if (!String.IsNullOrEmpty(reader["NombreDepartamento"].ToString()))
                        {
                            objDepartamento.NombreDepartamento = (String)reader["NombreDepartamento"];
                        }
                        

                        listadoDepartamentos.Add(objDepartamento);

                    }

                }

                reader.Close();

            }
            catch (SqlException s)
            {
            }
            finally
            {

                miconexion.closeConnection(ref conexion);

            }


            return listadoDepartamentos;

        }

        /// <summary>
        /// Consigue el departamento que tenga el mismo id que le mandamos
        /// </summary>
        /// <param name="id">Del departamento que queremos</param>
        /// <returns>El departamento que tenga el mismo id que le mandamos</returns>
        public clsDepartamento obtenerDepartamentoIdDAL(int id)
        {
            clsDepartamento objDepartamento = new clsDepartamento();
            clsMyConnection miconexion = new clsMyConnection();
            SqlConnection conexion = miconexion.getConnection();
            SqlCommand select = new SqlCommand();
            SqlDataReader reader;

            try
            {
                select.CommandText = "SELECT * FROM dbo.PD_Departamentos WHERE idDepartamento = @id";
                select.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                select.Connection = conexion;
                reader = select.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        objDepartamento.idDepartamento = (int)reader["idDepartamento"];

                        if (!String.IsNullOrEmpty(reader["NombreDepartamento"].ToString()))
                        {
                            objDepartamento.NombreDepartamento = (String)reader["NombreDepartamento"];
                        }
                    }
                    

                }

            }
            catch (SqlException e)
            {
                throw e;
            }

            return objDepartamento;

        }

    }
}

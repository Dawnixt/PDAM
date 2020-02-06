using ExamenSG_AJAXyJS_DAL.Connection;
using ExamenSG_AJAXyJS_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSG_AJAXyJS_DAL.Lists
{
    public class clsListadoAlgo
    {
        public clsListadoAlgo()
        {

        }

        /// <summary>
        /// Esta funcion nos permite obtner el listado de heroes completo
        /// </summary>
        /// <returns>Un listado con todos los super Heroes</returns>
        public List<clsAlgo> obtnerListadoHeroes()
        {
            List<clsAlgo> listadoHeroes = new List<clsAlgo>();

            try
            {
                clsMyConnection myConnection = new clsMyConnection();
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader;
                clsAlgo heroe;

                connection = myConnection.getConnection();
                command.CommandText = "Select * from dbo.superheroes";
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        heroe = new clsAlgo();

                        heroe.idHeroe = (int)reader["idSuperheroe"];

                        if (!String.IsNullOrEmpty(reader["nombreSuperheroe"].ToString()))
                        {
                            heroe.nombreHeroe = (string)reader["nombreSuperheroe"];
                        }

                        listadoHeroes.Add(heroe);

                    }

                }
                reader.Close();
                myConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }

            return listadoHeroes;
        }

        /// <summary>
        /// Esta funcion devuelve un heroe principalmente para conseguir el id
        /// </summary>
        /// <param name="heroe">El nombre del heroe que necesitamos</param>
        /// <returns>El heroe de la base de datos que tenga el mismo nombre</returns>
        public clsAlgo obtenerHeroe(int heroe)
        {
            clsAlgo superHeroe = new clsAlgo();

            try
            {
                clsMyConnection myConnection = new clsMyConnection();
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand();
                SqlDataReader reader;

                connection = myConnection.getConnection();
                command.CommandText = "Select * from dbo.superheroes where idSuperheroe = @id";
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = heroe;
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        superHeroe = new clsAlgo();

                        superHeroe.idHeroe = (int)reader["idSuperheroe"];

                        if (!String.IsNullOrEmpty(reader["nombreSuperheroe"].ToString()))
                        {
                            superHeroe.nombreHeroe = (string)reader["nombreSuperheroe"];
                        }
                    }
                }
                reader.Close();
                myConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {

            }

            return superHeroe;
        }
    }
}

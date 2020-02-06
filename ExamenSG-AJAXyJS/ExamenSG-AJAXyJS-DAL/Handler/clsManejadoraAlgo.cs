using ExamenSG_AJAXyJS_DAL.Connection;
using ExamenSG_AJAXyJS_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSG_AJAXyJS_DAL.Handler
{
    public class clsManejadoraAlgo
    {
        /// <summary>
        /// Esta funcion nos permite actualizar los campos observacio, reservada y idSuperHeroe de una mision
        /// </summary>
        /// <param name="misiones"> La mision con los valores por los que vamos a actualizar los viejos</param>
        /// <returns>Devuelve las filas cambiadas</returns>
        public int insertarHeroe(clsAlgo heroe)
        {

            int filasCambiadas = 0;

            try
            {

                clsMyConnection myConnection = new clsMyConnection();
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand();

                connection = myConnection.getConnection();
                command.CommandText = "Insert into superheroes values(@id,@nombre)";
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = heroe.idHeroe;
                command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = heroe.nombreHeroe;
                command.Connection = connection;
                filasCambiadas = command.ExecuteNonQuery();

                myConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }

            return filasCambiadas;

        }
        /// <summary>
        /// Esta funcion nos permite actualizar los campos observacio, reservada y idSuperHeroe de una mision
        /// </summary>
        /// <param name="misiones"> La mision con los valores por los que vamos a actualizar los viejos</param>
        /// <returns>Devuelve las filas cambiadas</returns>
        public int actualizarHeroe(clsAlgo heroe)
        {

            int filasCambiadas = 0;

            try
            {

                clsMyConnection myConnection = new clsMyConnection();
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand();

                connection = myConnection.getConnection();

                command.CommandText = "Update superheroes SET nombreSuperheroe = @nombre where idSuperheroe = @id";
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = heroe.idHeroe;
                command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = heroe.nombreHeroe;

                command.Connection = connection;
                filasCambiadas = command.ExecuteNonQuery();

                myConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }

            return filasCambiadas;

        }

        public int eliminarHeroe(int id)
        {
            int filasCambiasdas = 0;

            try
            {
                clsMyConnection myConnection = new clsMyConnection();
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand();

                connection = myConnection.getConnection();

                command.CommandText = "Delete from superheroes where idSuperheroe = @id";
                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                command.Connection = connection;
                filasCambiasdas = command.ExecuteNonQuery();

                myConnection.closeConnection(ref connection);
            }
            catch (SqlException)
            {
                throw;
            }

            return filasCambiasdas;
        }

    }
}

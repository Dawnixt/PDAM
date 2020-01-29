

using CRUDXamarin_DAL.Connection;
using CRUDXamarin_Ent;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarin_DAL.Handler
{
    public class clsGestionPersonasDAL
    {
        /*Aqui se hacen los metodos pa los insert update delete y eso
         No deberia saltar excepcion en los nonquery ya que debemos validar
         el modelo con los data anotations y eso y no debemos hacer nada sin
         que el modelo este bien
         */


            /// <summary>
            /// Metodo que inserta un objeto persona en la BBDD
            /// </summary>
            /// <param name="oPersona">
            /// objeto persona que se insertara en la BBDD
            /// </param>
            /// <returns>
            /// entero que sera el numero de filas afectadas
            /// </returns>
        public int insertarPersona(clsPersona oPersona)
        {
            
     
            

            return 0;
        }

        /// <summary>
        /// Método que elimina una persona de la BBDD
        /// </summary>
        /// <param name="idPersona">
        /// ID de la persona a eliminar
        /// </param>
        /// <returns>
        /// entero que sera el numero de filas afectadas
        /// </returns>
        public async Task<int> eliminarPersonaAsync(int idPersona)
        {
            int estado = 0;
            //Cliente HTTP
            HttpClient httpClient = new HttpClient();
            string cadena = clsMyConnection.getUriBase() + "PersonaApi/" + idPersona;
            Uri uri = new Uri(cadena);
            //clsPersona persona = null;
            /*Envuelvelo en un try catch*/
            HttpResponseMessage response = await httpClient.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {

                estado = 1;
                
            }


            return estado;
        }

        /// <summary>
        /// Metodo que actualiza los datos de una persona en la BBDD
        /// </summary>
        /// <param name="oPersona">
        /// Persona actualizada cuyos datos se volcarán en la BBDD
        /// </param>
        /// <returns>
        /// int con el numero de filas afectadas
        /// </returns>

        public int actualizarPersona(clsPersona oPersona)
        {
           
            
           return 0;
        }
    }
}

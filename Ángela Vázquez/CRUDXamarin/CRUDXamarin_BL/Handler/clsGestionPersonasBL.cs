

using CRUDXamarin_DAL.Handler;
using CRUDXamarin_Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarin_BL.Handler
{
    public class clsGestionPersonasBL
    {
        /// <summary>
        /// Metodo que comprobará la lógica de la empresa y llamará o no al método de insertar persona
        /// de la capa DAL
        /// </summary>
        /// <param name="oPersona">
        /// objeto persona que será insertado o no en la base de datos, dependiendo de si lo 
        /// permiten las reglas de la empresa
        /// </param>
        /// <returns>
        /// entero que sera el n de filas afectadas
        /// </returns>
        public int insertarPersona(clsPersona oPersona)
        {
            clsGestionPersonasDAL gestionPersonasDAL = new clsGestionPersonasDAL();

            
            return gestionPersonasDAL.insertarPersona(oPersona); ;
        }

        /// <summary>
        /// Método que llama al eliminar persona de la capa DAL o no, dependiendo de 
        /// la lógica de la empresa. Si se puede eliminar, se eliminará.
        /// </summary>
        /// <param name="oPersona">
        /// objeto persona que se quiere eliminar
        /// </param>
        /// <returns>
        /// devuelve el numero de filas afectadas o -1 si no se puede eliminar
        /// porque la empresa así lo quiere
        /// </returns>
        public async Task<int> eliminarPersona(clsPersona oPersona)
        {
            
            int resultado;
            clsGestionPersonasDAL gestionPersonasDAL = new clsGestionPersonasDAL();
            resultado = await gestionPersonasDAL.eliminarPersonaAsync(oPersona.idPersona);
            
            //de momento no hay logica de empresa
            return resultado;
            
            //return 0;
        }



        /// <summary>
        /// Método que llama al actualizar persona de la capa DAL o no, dependiendo de 
        /// la lógica de la empresa. Si se puede actualizar, se hará. Si se actualiza lo 
        /// harán todos sus campos.
        /// </summary>
        /// <param name="oPersona">
        /// objeto persona que se quiere actualizar
        /// </param>
        /// <returns>
        /// devuelve el numero de filas afectadas o -1 si no se puede actualizar
        /// porque la empresa así lo quiere
        /// </returns>
        public int actualizarPersona(clsPersona oPersona)
        {
            /*
            int resultado;
            clsGestionPersonasDAL gestionPersonasDAL = new clsGestionPersonasDAL();
            resultado = gestionPersonasDAL.actualizarPersona(oPersona);

            return resultado;
            */
            return 0;
        }
    }
}

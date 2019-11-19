using _08_CRUD_Personas_DAL.Manejadora;
using _08_CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUD_Personas_BL.Manejadora
{
    public class clsManejadoraPersonasBL
    {

        public clsManejadoraPersonasBL()
        {

        }

        /// <summary>
        /// Le pasa la persona a crear a la capa DAL
        /// </summary>
        /// <param name="persona">Que quieres crear</param>
        /// <returns></returns>
        public int aniadirPersonaBL(clsPersona persona)
        {

            int filasCambiadas = 0;

            clsManejadoraPersonasDAL manejadora = new clsManejadoraPersonasDAL();

            filasCambiadas = manejadora.aniadirPersona(persona);

            return filasCambiadas;

        }

        /// <summary>
        /// Le pasa la persona a actualizar a la capa DAL
        /// </summary>
        /// <param name="persona">La persona con los cambios hechos</param>
        /// <returns></returns>
        public int updatePersonaBL(clsPersona person)
        {

            int filasCambiadas = 0;

            clsManejadoraPersonasDAL manejadora = new clsManejadoraPersonasDAL();

            filasCambiadas = manejadora.updatePersonaDAL(person);

            return filasCambiadas;

        }

        /// <summary>
        /// Le pasa el id de la persona a borrar a la capa DAL
        /// </summary>
        /// <param name="id">De la persona que quieres borrar</param>
        /// <returns></returns>
        public int deletePersonaBL(int id)
        {

            int filasCambiadas = 0;

            clsManejadoraPersonasDAL manejadora = new clsManejadoraPersonasDAL();

            filasCambiadas = manejadora.deletePersonaDAL(id);

            return filasCambiadas;

        }

    }
}

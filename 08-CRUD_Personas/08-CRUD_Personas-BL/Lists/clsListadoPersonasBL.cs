using _08_CRUD_Personas_DAL.Lists;
using _08_CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUD_Personas_BL.Lists
{
    public class clsListadoPersonasBL
    {

        public clsListadoPersonasBL()
        {

        }

        /// <summary>
        /// Le pide a la capa DAL todos las persona
        /// </summary>
        /// <returns>Un listado con todas las personas de la bbdd</returns>
        public List<clsPersona> crearListadoPersonasBL()
        {
            clsListadoPersonasDAL personas = new clsListadoPersonasDAL();

            List<clsPersona> listado = personas.crearListadoPersonasDAL();

            return listado;
        }

        /// <summary>
        /// Le pide a la capa DAL una persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La persona que queremos de la bbdd</returns>
        public clsPersona obtenerPersonaIdBL(int id)
        {

            clsListadoPersonasDAL persona = new clsListadoPersonasDAL();

            clsPersona personaSelec = persona.obtenerPersonaIdDAL(id);

            return personaSelec;

        }

    }
}

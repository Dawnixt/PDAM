using ExamenSG_AJAXyJS_DAL.Lists;
using ExamenSG_AJAXyJS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSG_AJAXyJS_BL.Lists
{
    public class clsListadoAlgoBL
    {
        /// <summary>
        /// Esta funcion se conectara con la capa DAL para recoger el listado de heroes
        /// </summary>
        /// <returns>Un listado completo de heroes</returns>
        public List<clsAlgo> obtnerListadoHeroes()
        {

            List<clsAlgo> listadoSuperHeroes = new List<clsAlgo>();
            clsListadoAlgo heroesDAL = new clsListadoAlgo();

            listadoSuperHeroes = heroesDAL.obtnerListadoHeroes();

            return listadoSuperHeroes;

        }

        /// <summary>
        /// Esta funcion se conectara con la capa DAL para conseguir un heroe de la base de datos
        /// </summary>
        /// <param name="heroe">El nombre del heroe que necesitamos</param>
        /// <returns>El heroe de la base de datos que tenga el mismo nombre</returns>
        public clsAlgo obtenerHeroeBL(int heroe)
        {
            clsAlgo superHeroes = new clsAlgo();
            clsListadoAlgo heroesDAL = new clsListadoAlgo();

            superHeroes = heroesDAL.obtenerHeroe(heroe);
            return superHeroes;
        }

    }
}

using _08_CRUD_Personas_DAL.Lists;
using _08_CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUD_Personas_BL.Lists
{
    public class clsListadoDepartamentosBL
    {
        /// <summary>
        /// Le pide a la capa DAL todos los departamentos
        /// </summary>
        /// <returns>Una lista con los departamentos</returns>
        public List<clsDepartamento> crearListadoDepartamentosBL()
        {

            clsListadoDepartamentosDAL list = new clsListadoDepartamentosDAL();

            List<clsDepartamento> listado = list.crearListadoDepartamentosDAL();

            return listado;
        }

        /// <summary>
        /// Le pide a la capa DAL un departamento
        /// </summary>
        /// <param name="id">Del departamento que queremos</param>
        /// <returns>El departamento que tenga el mismo id que le mandamos</returns>
        public clsDepartamento obtenerDepartamentoIdBL(int id)
        {

            clsListadoDepartamentosDAL dep = new clsListadoDepartamentosDAL();

            clsDepartamento departamento = dep.obtenerDepartamentoIdDAL(id);

            return departamento;

        }

    }
}

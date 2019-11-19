using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUD_Personas_Entities
{
    public class clsDepartamento
    {

        public clsDepartamento()
        {

        }

        public clsDepartamento(int id,String nombre) {

            idDepartamento = id;
            NombreDepartamento = nombre;

        }

        public int idDepartamento { get; set; }

        public String NombreDepartamento { get; set; }

    }
}

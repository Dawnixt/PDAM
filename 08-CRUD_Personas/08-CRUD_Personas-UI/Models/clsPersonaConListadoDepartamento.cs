using _08_CRUD_Personas_BL.Lists;
using _08_CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _08_CRUD_Personas_UI.Models
{
    public class clsPersonaConListadoDepartamento : clsPersona
    {
        //Propiedades privadas
        private List<clsDepartamento> _listadoDepartamentos;

        //Constructores
        public clsPersonaConListadoDepartamento() : base()
        {

        }

        public clsPersonaConListadoDepartamento(List<clsDepartamento> lista, int id, string nombre, string apellidos, DateTime fecha, String telefono, int IDdepartamento) : base(id, nombre, apellidos, fecha, telefono, IDdepartamento)
        {

            this._listadoDepartamentos = lista;

        }

        public clsPersonaConListadoDepartamento(clsPersona persona, List<clsDepartamento> lista) : base(persona.idPersona,persona.NombrePersona,persona.ApellidosPersona,persona.FechaNacimiento,persona.TelefonoPersona,persona.IDDepartamento)
        {

            this._listadoDepartamentos = lista;

        }

        //Propiedades publicas
        public List<clsDepartamento> ListadoDepartamento
        {

            get
            {

                return _listadoDepartamentos;

            }

            set
            {
                _listadoDepartamentos = value;
            }

        }

    }
}
using _08_CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _08_CRUD_Personas_UI.Models
{
    public class clsPersonaConNombreDepartamento : clsPersona
    {
        //Propiedades privadas
        private string _nombreDepartamento;


        //Constructores
        public clsPersonaConNombreDepartamento() : base()
        {

            this._nombreDepartamento = "";

        }

        public clsPersonaConNombreDepartamento(clsPersona person, string nombre) : base(person.idPersona,person.NombrePersona,person.ApellidosPersona,person.FechaNacimiento,person.TelefonoPersona,person.IDDepartamento)
        {

            this._nombreDepartamento = nombre;

        }

        public clsPersonaConNombreDepartamento(string nombreDepartamento,int id, string nombre, string apellidos, DateTime fecha, String telefono, int IDdepartamento) : base(id, nombre, apellidos, fecha, telefono, IDdepartamento)
        {
            this._nombreDepartamento = nombreDepartamento;
        }

            //Propiedades publicas
        [Display(Name = "Nombre de departamento")]
        public string NombreDepartamento
        {
            get
            {
                return _nombreDepartamento;
            }

            set
            {
                _nombreDepartamento = value;
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace _08_CRUD_Personas_Entities
{
    public class clsPersona
    {

        public clsPersona()
        {
            idPersona = -1;
            NombrePersona = "Default";
            ApellidosPersona = "Default";
            FechaNacimiento = DateTime.Now;
            FotoPersona = null;
            IDDepartamento = 1;
        }

        public clsPersona(int IDpersona, String nombre, String apellido, DateTime fecha, String telefono, int IDdepartamento)
        {
            idPersona = IDpersona;
            this.NombrePersona = nombre;
            this.ApellidosPersona = apellido;
            this.FechaNacimiento = fecha;
            this.TelefonoPersona = telefono;
            this.IDDepartamento = IDdepartamento;
        }

        [HiddenInput(DisplayValue = false)]
        [Key]
        public int idPersona { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { set; get; }
        
        [Required(ErrorMessage = "Que es anonimus?")]
        [Display(Name = "Nombre")]
        public string NombrePersona { get; set; }

        [MaxLength(40)]
        [Display(Name = "Apellidos")]
        public string ApellidosPersona { get; set; }

        [Display(Name = "Departamento")]
        public int IDDepartamento { get; set; }

        [RegularExpression(@"^(\+34|0034|34)?[6|7|8|9][0-9]{8}$")]
        [Display(Name = "Telefono")]
        public string TelefonoPersona { get; set; }

        [Display(Name = "Foto")]
        public byte[] FotoPersona { get; set; }

    }
}
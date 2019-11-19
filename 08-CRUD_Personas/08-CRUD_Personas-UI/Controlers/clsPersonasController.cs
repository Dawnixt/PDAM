using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _08_CRUD_Personas_BL.Lists;
using _08_CRUD_Personas_BL.Manejadora;
using _08_CRUD_Personas_Entities;
using _08_CRUD_Personas_UI.Models;

namespace _08_CRUD_Personas_UI.Controlers
{
    public class clsPersonasController : Controller
    {
        private _08_CRUD_Personas_UIContext db = new _08_CRUD_Personas_UIContext();

        // GET: clsPersonas

        /// <summary>
        /// Carga la lista de personas que se veran en el index y se lo envia al index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            try
            {
                clsListadoPersonasBL personas = new clsListadoPersonasBL();
                clsListadoDepartamentosBL departamentos = new clsListadoDepartamentosBL();
                List<clsPersona> listado = new List<clsPersona>();
                List<clsPersonaConNombreDepartamento> personaConDepartamento = new List<clsPersonaConNombreDepartamento>();
                listado = personas.crearListadoPersonasBL();

                foreach(var item in listado)
                {

                    clsPersonaConNombreDepartamento objPersonaConDepartamento = new clsPersonaConNombreDepartamento();
                    objPersonaConDepartamento.NombrePersona = item.NombrePersona;
                    objPersonaConDepartamento.TelefonoPersona = item.TelefonoPersona;
                    objPersonaConDepartamento.idPersona = item.idPersona;
                    objPersonaConDepartamento.FotoPersona = item.FotoPersona;
                    objPersonaConDepartamento.ApellidosPersona = item.ApellidosPersona;
                    objPersonaConDepartamento.FechaNacimiento = item.FechaNacimiento;
                    objPersonaConDepartamento.NombreDepartamento = departamentos.obtenerDepartamentoIdBL(item.IDDepartamento).NombreDepartamento;

                    personaConDepartamento.Add(objPersonaConDepartamento);

                }

                return View(personaConDepartamento);

            }
            catch (Exception e)
            {
                return View("Error");

            }

        }

        // GET: clsPersonas/Details/5
        /// <summary>
        /// Le envia una persona con el nombre del departamento a la accion detalles
        /// </summary>
        /// <param name="id">El id de la persona</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            clsListadoPersonasBL list = new clsListadoPersonasBL();
            clsListadoDepartamentosBL listDep = new clsListadoDepartamentosBL();

            try
            {
                clsPersona person = new clsPersona();
                clsDepartamento dep = new clsDepartamento();
                person = list.obtenerPersonaIdBL(id);
                dep = listDep.obtenerDepartamentoIdBL(person.IDDepartamento);

                clsPersonaConNombreDepartamento personaConNombre = new clsPersonaConNombreDepartamento(person, dep.NombreDepartamento);

                return View(personaConNombre);
            }
            catch(Exception e)
            {
                return View("Error");
            }
            
        }

        // GET: clsPersonas/Create
        /// <summary>
        /// Le envia la lista de departamentos y el resto de campos de persona en blanco a la accion crear
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            try
            {
                clsPersonaConListadoDepartamento personaConListado = new clsPersonaConListadoDepartamento();
                clsListadoDepartamentosBL listadoDep = new clsListadoDepartamentosBL();
                personaConListado.ListadoDepartamento = listadoDep.crearListadoDepartamentosBL();

                return View(personaConListado);
            }
            catch (Exception e)
            {
                return View("Error");
            }
            
        }

        // POST: clsPersonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Se crea la ueva persona con los datos que nos da el usuario en la bbdd
        /// </summary>
        /// <param name="personaConDepartamento">La persona que quiere crear el usuario</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPersonaConListadoDepartamento personaConDepartamento)
        {
            //int filasAfectadas = 0;
            clsManejadoraPersonasBL manejadora = new clsManejadoraPersonasBL();
            List<clsPersona> lista = new List<clsPersona>();
            clsPersona persona = new clsPersona(personaConDepartamento.idPersona, personaConDepartamento.NombrePersona, personaConDepartamento.ApellidosPersona, personaConDepartamento.FechaNacimiento, personaConDepartamento.TelefonoPersona, personaConDepartamento.IDDepartamento);
            clsListadoPersonasBL listado = new clsListadoPersonasBL();
            
            if (ModelState.IsValid)
            {
                try
                {

                    manejadora.aniadirPersonaBL(persona);

                    //ViewData["FilasAfectadas"] = $"Se ha insertado {filasAfectadas} filas";

                    //Es esto o crear la lista y pasarla a la vista
                    return RedirectToAction("Index");
                    //, listado.crearListadoPersonasBL()

                }
                catch (Exception e)
                {

                    return View("Error");

                }
            }
            else
            {
                return View();
            }

            
        }

        // GET: clsPersonas/Edit/5
        /// <summary>
        /// Le enviamos la persona que se quiere editar junto con un listado de departamentos a la accion de editar
        /// </summary>
        /// <param name="id">El id de la persona</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {

            clsListadoPersonasBL list = new clsListadoPersonasBL();
            clsListadoDepartamentosBL lista = new clsListadoDepartamentosBL();
            try
            {
                clsPersona person = new clsPersona();
                person = list.obtenerPersonaIdBL(id);
                clsPersonaConListadoDepartamento personaConListado = new clsPersonaConListadoDepartamento(person, lista.crearListadoDepartamentosBL());

                return View(personaConListado);
            }
            catch (Exception e)
            {
                return View("Error");
            }
            
        }

        // POST: clsPersonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Actualizamos la persona con los cambios que el usuario queria
        /// </summary>
        /// <param name="clsPersona">La persona con los cambios</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPersona,FechaNacimiento,NombrePersona,ApellidosPersona,IDDepartamento,TelefonoPersona,FotoPersona")] clsPersona clsPersona)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    clsManejadoraPersonasBL manejadora = new clsManejadoraPersonasBL();
                    manejadora.updatePersonaBL(clsPersona);

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View("Error");
                }
                
            }
            return View(clsPersona);
        }

        // GET: clsPersonas/Delete/5
        /// <summary>
        /// Le enviamos la persona que se quiere borrar junto con el departamento al que pertenece
        /// </summary>
        /// <param name="id">El id de la persona</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {

            clsListadoPersonasBL list = new clsListadoPersonasBL();
            clsListadoDepartamentosBL listDep = new clsListadoDepartamentosBL();
            clsPersona person = new clsPersona();
            clsDepartamento dep = new clsDepartamento();

            try
            {
                person = list.obtenerPersonaIdBL(id);
                dep = listDep.obtenerDepartamentoIdBL(person.IDDepartamento);

                clsPersonaConNombreDepartamento personaConNombre = new clsPersonaConNombreDepartamento(person, dep.NombreDepartamento);

                return View(personaConNombre);
            }
            catch (Exception e)
            {
                return View("Error");
            }

        }

        // POST: clsPersonas/Delete/5
        /// <summary>
        /// Se borra a la persona de la bbdd
        /// </summary>
        /// <param name="id">El id del usuario</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clsManejadoraPersonasBL manejadora = new clsManejadoraPersonasBL();

            try
            {
                manejadora.deletePersonaBL(id);

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                return View("Error");
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

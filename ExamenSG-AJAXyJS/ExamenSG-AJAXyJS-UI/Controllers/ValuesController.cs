using ExamenSG_AJAXyJS_BL.Handler;
using ExamenSG_AJAXyJS_BL.Lists;
using ExamenSG_AJAXyJS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExamenSG_AJAXyJS_UI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<clsAlgo> Get()
        {
            clsListadoAlgoBL listado = new clsListadoAlgoBL();
            return listado.obtnerListadoHeroes();
        }

        // GET api/values/5
        public clsAlgo Get(int id)
        {
            clsListadoAlgoBL listadoAlgoBL = new clsListadoAlgoBL();
            clsAlgo heroe = listadoAlgoBL.obtenerHeroeBL(id);

            return heroe;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]clsAlgo heroe)
        {
            int filas = 0;
            clsManejadoraAlgoBL manejadoraAlgoBL = new clsManejadoraAlgoBL();
            HttpResponseMessage mensaje;

            filas = manejadoraAlgoBL.insertarHeroe(heroe);
            if(filas != 0)
            {
                mensaje = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                mensaje = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return mensaje;

        }

        // PUT api/values/5
        public HttpResponseMessage Put([FromBody]clsAlgo value)
        {

            int filas = 0;
            clsManejadoraAlgoBL manejadoraAlgoBL = new clsManejadoraAlgoBL();
            HttpResponseMessage message;

            filas = manejadoraAlgoBL.actualizarHeroe(value);
            if(filas != 0)
            {
                message = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                message = new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return message;

        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {

            int filas = 0;
            clsManejadoraAlgoBL manejadoraAlgoBL = new clsManejadoraAlgoBL();
            HttpResponseMessage message;

            filas = manejadoraAlgoBL.eliminarHeroe(id);

            if(filas != 0)
            {
                message = new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                message = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return message;
        }
    }
}

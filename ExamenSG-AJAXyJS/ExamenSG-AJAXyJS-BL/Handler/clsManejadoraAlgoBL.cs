using ExamenSG_AJAXyJS_DAL.Handler;
using ExamenSG_AJAXyJS_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSG_AJAXyJS_BL.Handler
{
    public class clsManejadoraAlgoBL
    {

        public int insertarHeroe(clsAlgo heroe)
        {
            int filasCambiadas = 0;

            clsManejadoraAlgo manejadoraAlgo = new clsManejadoraAlgo();

            filasCambiadas = manejadoraAlgo.insertarHeroe(heroe);

            return filasCambiadas;
        }

        public int actualizarHeroe(clsAlgo heroe)
        {
            int filasCambiadas = 0;

            clsManejadoraAlgo manejadoraAlgo = new clsManejadoraAlgo();

            filasCambiadas = manejadoraAlgo.actualizarHeroe(heroe);

            return filasCambiadas;
        }

        public int eliminarHeroe(int id)
        {
            int filasCambiadas = 0;
            clsManejadoraAlgo manejadoraAlgo = new clsManejadoraAlgo();
            filasCambiadas = manejadoraAlgo.eliminarHeroe(id);
            return filasCambiadas;
        }

    }
}

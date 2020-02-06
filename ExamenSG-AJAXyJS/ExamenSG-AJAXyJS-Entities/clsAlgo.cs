using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSG_AJAXyJS_Entities
{
    public class clsAlgo
    {
        //Propiedades privadas
        private int _idHeroe;
        private string _nombreSuperHeroe;

        //Constructores
        //Por defecto
        public clsAlgo()
        {

        }

        //Con parametros

        public clsAlgo(int id, string nombreHeroe)
        {

            this._idHeroe = id;
            this._nombreSuperHeroe = nombreHeroe;

        }

        //Propiedades publicas
        public int idHeroe
        {
            get
            {
                return _idHeroe;
            }
            set
            {
                _idHeroe = value;
            }
        }

        public string nombreHeroe
        {
            get
            {
                return _nombreSuperHeroe;
            }
            set
            {
                _nombreSuperHeroe = value;
            }
        }
    }
}

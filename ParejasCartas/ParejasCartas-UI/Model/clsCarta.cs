using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_UI.Model
{
    public class clsCarta
    {
        #region Propiedades privadas
        private string _imagenAMostrar;
        private string _imagenReverso;
        private string _imagenAnverso;
        private bool _volteada;
        #endregion

        #region Constructores
        public clsCarta()
        {
            _imagenAnverso = "ms-appx:///Assets/carta.jpg";
            _volteada = false;
        }

        public clsCarta(string reversoCarta)
        {
            _imagenAnverso = "ms-appx:///Assets/carta.jpg";
            _imagenReverso = reversoCarta;
            _volteada = false;
        }

        #endregion

        #region Propiedades publicas

        public string ImagenAMostrar
        {
            get
            {
                if (_volteada)
                {
                    _imagenAMostrar = _imagenReverso;
                }
                else
                {
                    _imagenAMostrar = _imagenAnverso;
                }
                return _imagenAMostrar;
            }
        }

        public string ImagenReverso
        {
            get
            {
                return _imagenReverso;
            }
            set
            {
                _imagenReverso = value;
            }
        }

        public string ImagenAnverso
        {
            get
            {
                return _imagenReverso;
            }
            set
            {
                _imagenReverso = value;
            }
        }

        public bool Volteada
        {
            get
            {
                return _volteada;
            }
            set
            {
                _volteada = value;
            }
        }

        #endregion

    }
}

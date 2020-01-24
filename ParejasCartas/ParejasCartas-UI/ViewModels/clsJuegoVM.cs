using ParejasCartas_UI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_UI.ViewModels
{
    public class clsJuegoVM : INotifyPropertyChanged
    {

        private ObservableCollection<clsCarta> _tablero;
        private string _tiempo;
        private string _nombreSeleccionado;

        public clsJuegoVM()
        {
            //Crea el tablero con metodo de las cartas aleatorias de la clase de utilidades
        }

        public ObservableCollection<clsCarta> Tablero
        {
            get
            {
                return _tablero;
            }
            set
            {
                _tablero = value;
            }
        }

        public string Tiempo
        {
            get
            {
                return _tiempo;
            }
            set
            {
                _tiempo = value;
            }
        }

        public string NombreSeleccionado
        {
            get
            {
                return _nombreSeleccionado;
            }
            set
            {
                _nombreSeleccionado = value;
            }
        }

        //Cosas del NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

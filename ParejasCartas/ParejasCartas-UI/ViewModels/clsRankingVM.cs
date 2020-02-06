using ParejasCartas_BL.Lists;
using ParejasCartas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParejasCartas_UI.ViewModels
{
    public class clsRankingVM : INotifyPropertyChanged
    {

        private ObservableCollection<clsScore> _listadoPuntuaciones;

        public clsRankingVM()
        {
            clsListadoPuntuacionesBL puntuacionesBL = new clsListadoPuntuacionesBL();
            _listadoPuntuaciones = new ObservableCollection<clsScore>(puntuacionesBL.obtenerListadoPuntuaciones());
        }

        public ObservableCollection<clsScore> ListadoPuntuaciones
        {
            get
            {
                return _listadoPuntuaciones;
            }
            set
            {
                _listadoPuntuaciones = value;
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

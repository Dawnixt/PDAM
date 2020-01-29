using JuegoEncontrarParejas_Entities;
using JuegoEncontrarParejas_UI.viewModel;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace JuegoEncontrarParejas_UI.viewModel
{
    public class MainPageVM : clsVMBase
    {
        #region"Atrib privados"
        private HubConnection conn;
        private IHubProxy proxy;
        private int _cantidadUsuarios;
        private string _estadoActual;
        private int _puntosOponente;
        private int _puntosJugador;
        private int time = 20;

        private DispatcherTimer dispatcherTimer;

        private Card cartaSeleccionada;
        private Card cartaPrevia;
        private ObservableCollection<Card> tablero;
        private bool isPrimeraCarta;
        private bool _isPartidaActiva;


        #endregion

        #region"Prop publicas"

        public string Temporizador { get; set; }
        public string ResultadoPartida { get; set; }

        public bool IsPartidaActiva
        {
            get { return this._isPartidaActiva; }
            set { this._isPartidaActiva = value; }
        }

        public int PuntosOponente
        {
            get { return this._puntosOponente; }
            set { this._puntosOponente = value; }
        }

        public int PuntosJugador
        {
            get { return this._puntosJugador; }
            set { this._puntosJugador = value; }
        }

        public string EstadoActual
        {
            get { return this._estadoActual; }
            set { this._estadoActual = value; }
        }
        public int CantidadUsuarios
        {
            get { return this._cantidadUsuarios; }
            set { this._cantidadUsuarios = value; }
        }


        public Card CartaSeleccionada
        {
            get
            {
                return this.cartaSeleccionada;
            }
            set
            {
                this.cartaSeleccionada = value;

                if (!this.cartaSeleccionada.isEncontrada && this.cartaSeleccionada != null)  //solo entra si no es null y NO esta encontrada
                {
                    //girarSeleccionada();

                    this.cartaSeleccionada.girarCarta();
                    NotifyPropertyChanged("CartaSeleccionada");

                    isPrimeraCarta = !isPrimeraCarta;



                    if (isPrimeraCarta)
                    {
                        cartaPrevia = cartaSeleccionada;
                        NotifyPropertyChanged("CartaSeleccionada");
                        cartaSeleccionada = null;
                    }
                    else if (isAMatch(cartaSeleccionada, cartaPrevia))
                    {

                        //Si sí es un match! (+1 punto)
                        cartaSeleccionada.isEncontrada = true;

                        cartaPrevia.isEncontrada = true;

                        NotifyPropertyChanged("CartaSeleccionada");


                        this._puntosJugador += 1;

                        proxy.Invoke("actualizarPuntuacionDelOponente", this._puntosJugador);
                        NotifyPropertyChanged("PuntosJugador");

                    }
                    else if (!isPrimeraCarta && !isAMatch(cartaSeleccionada, cartaPrevia))
                    {
                        if (cartaSeleccionada != null && cartaPrevia != null)
                        {
                            girarPrevia();
                            girarSeleccionada();
                        }



                    }
                    else
                    {
                        if (cartaSeleccionada != null)
                            girarSeleccionada();

                    }




                }
            }
        }

        public ObservableCollection<Card> Tablero
        {
            get { return this.tablero; }
            set { this.tablero = value; }
        }

        #endregion


        #region"Constructor"
        public MainPageVM()
        {
            this._isPartidaActiva = false;
            NotifyPropertyChanged("IsPartidaActiva");

            this.dispatcherTimer = new DispatcherTimer();
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            this.dispatcherTimer.Tick += Timer_Tik;
            // this.dispatcherTimer.Start();
            this.Temporizador = "00:00:30";


            try
            {
                SignalR();
            }
            catch (Exception e)
            {
                falloConexion();
            }


            this._puntosJugador = 0;
            this._puntosOponente = 0;
            isPrimeraCarta = false;
            this.cartaSeleccionada = null;
            this.cartaPrevia = null;
            List<Card> baraja = new List<Card>();
            //Añado las cartas a la baraja
            baraja.Add(new Card(1, 1, "ms-appx:///Assets/androidstudio.png"));
            baraja.Add(new Card(2, 1, "ms-appx:///Assets/androidstudio.png"));

            baraja.Add(new Card(3, 2, "ms-appx:///Assets/angelagit.png"));
            baraja.Add(new Card(4, 2, "ms-appx:///Assets/angelagit.png"));

            baraja.Add(new Card(5, 3, "ms-appx:///Assets/geany.png"));
            baraja.Add(new Card(6, 3, "ms-appx:///Assets/geany.png"));

            baraja.Add(new Card(7, 4, "ms-appx:///Assets/github.png"));
            baraja.Add(new Card(8, 4, "ms-appx:///Assets/github.png"));

            baraja.Add(new Card(9, 5, "ms-appx:///Assets/intellij.png"));
            baraja.Add(new Card(10, 5, "ms-appx:///Assets/intellij.png"));

            baraja.Add(new Card(11, 6, "ms-appx:///Assets/sqlserver.png"));
            baraja.Add(new Card(12, 6, "ms-appx:///Assets/sqlserver.png"));

            baraja.Add(new Card(13, 7, "ms-appx:///Assets/vagrant.png"));
            baraja.Add(new Card(14, 7, "ms-appx:///Assets/vagrant.png"));

            baraja.Add(new Card(15, 8, "ms-appx:///Assets/visualstudio.png"));
            baraja.Add(new Card(16, 8, "ms-appx:///Assets/visualstudio.png"));

            //barajar cartas
            this.tablero = new ObservableCollection<Card>(this.ShuffleList(baraja));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tik(object sender, object e)
        {
            if (time > 0 && this._cantidadUsuarios == 2)
            {

                if (time <= 10)
                {
                    time--;
                    Temporizador = string.Format("00:0{0}:0{1}", time / 60, time % 60);
                    NotifyPropertyChanged("Temporizador");
                }
                else
                {
                    time--;
                    Temporizador = string.Format("00:0{0}:{1}", time / 60, time % 60);
                    NotifyPropertyChanged("Temporizador");
                }



            }
            else
            {
                this.dispatcherTimer.Stop();
                if (this._isPartidaActiva)
                {
                    this._isPartidaActiva = false;
                    NotifyPropertyChanged("IsPartidaActiva");
                }

                if (time == 0)
                {
                    proxy.Invoke("usuarioHaFinalizado");
                    //if (_puntosJugador > _puntosOponente)
                    //{
                    //    ResultadoPartida = "¡Has ganado!";
                    //}
                    //else if (_puntosJugador == _puntosOponente)
                    //{
                    //    ResultadoPartida = "¡Empate!";
                    //}
                    //else
                    //{
                    //    ResultadoPartida = "¡Has perdido!";
                    //}
                    //NotifyPropertyChanged("ResultadoPartida");
                }
            }
        }
        #endregion

        #region"Metodos añadidos"
        private void SignalR()
        {

            conn = new HubConnection("https://juegoparejas-angela.azurewebsites.net/");

            proxy = conn.CreateHubProxy("GameHub");
            conn.Start().Wait();

            proxy.On("todosHanFinalizado", todosHanFinalizado);
            proxy.On<int>("updateUsuarios", updateUsuarios);
            proxy.On<string>("updateEstadoActual", updateEstadoActual);
            proxy.On<int>("updatePuntuacionOponente", updatePuntuacionOponente);

            proxy.Invoke("cantidadUsuariosConectados");
            proxy.Invoke("actualizarEstadoActual");



        }

        private void todosHanFinalizado()
        {
            if (_puntosJugador > _puntosOponente)
            {
                ResultadoPartida = "¡Has ganado!";
            }
            else if (_puntosJugador == _puntosOponente)
            {
                ResultadoPartida = "¡Empate!";
            }
            else
            {
                ResultadoPartida = "¡Has perdido!";
            }
            NotifyPropertyChanged("ResultadoPartida");
        }

        /// <summary>
        /// Actualiza la puntuación del oponente
        /// </summary>
        /// <param name="obj"></param>
        private async void updatePuntuacionOponente(int obj)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this._puntosOponente = obj;
                NotifyPropertyChanged("PuntosOponente");
            });
        }

        /// <summary>
        /// actualiza la cantidad de usuarios conectados que hay
        /// </summary>
        /// <param name="cantidadUsuarios">cantidad de usuarios que hay conectados</param>
        private async void updateUsuarios(int cantidadUsuarios)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this._cantidadUsuarios = cantidadUsuarios;
                NotifyPropertyChanged("CantidadUsuarios");

                //prueba
                if (this._cantidadUsuarios == 2)
                {
                    this._isPartidaActiva = true;
                    NotifyPropertyChanged("IsPartidaActiva");
                    this.dispatcherTimer.Start();
                }

            });


        }




        /// <summary>
        /// actualiza el mensaje del estado actual 
        /// </summary>
        /// <param name="estado"> cadena con el nuevo mensaje </param>
        private async void updateEstadoActual(string estado)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this._estadoActual = estado;
                NotifyPropertyChanged("EstadoActual");
            });


        }


        /// <summary>
        /// Baraja una lista
        /// </summary>
        /// <param name="inputList"> lista a barajar </param>
        /// <returns> lista barajada </returns>
        private List<Card> ShuffleList(List<Card> inputList)
        {
            List<Card> randomList = new List<Card>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        /// <summary>
        /// Devuelve la posicion en la lista de una carta con el id indicado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int obtenerPosicionCarta(int id)
        {
            bool encontrada = false;
            int pos = 0;
            for (int i = 0; i < this.tablero.Count && !encontrada; i++)
            {
                if (this.tablero[i].id == id)
                {
                    pos = i;
                    encontrada = true;

                }
            }
            return pos;
        }

        /// <summary>
        /// Comprueba si dos cartas son pareja
        /// </summary>
        /// <param name="carta">carta uno a comprobar</param>
        /// <param name="cartaPrevia">carta dos a comprobar</param>
        /// <returns>true si sí es pareja, false si no</returns>
        private bool isAMatch(Card carta, Card cartaPrevia)
        {
            bool pareja = false;
            if (carta.pareja == cartaPrevia.pareja && carta.id != cartaPrevia.id)
            {
                pareja = true;
            }
            return pareja;
        }

        /// <summary>
        /// gira la carta seleccionada
        /// </summary>
        private async void girarSeleccionada()
        {
            Task task = Task.Delay(100);
            await task.AsAsyncAction();

            cartaSeleccionada.girarCarta();



            //NotifyPropertyChanged("CartaSeleccionada");
            cartaSeleccionada = null;
            NotifyPropertyChanged("CartaSeleccionada");


        }

        /// <summary>
        /// Gira la carta previa
        /// </summary>
        private async void girarPrevia()
        {
            Task task = Task.Delay(100);
            await task.AsAsyncAction();
            cartaPrevia.girarCarta();


        }



        /// <summary>
        /// Muestra dialog cuando falla la conexion y da la posibilidad
        /// de reintentar o de salir de la app
        /// </summary>
        private async void falloConexion()
        {

            ContentDialog dialogo = new ContentDialog
            {
                Title = "Ooops!",
                Content = "Something went wrong, try again later",
                PrimaryButtonText = "Retry now",
                CloseButtonText = "Exit",
                DefaultButton = ContentDialogButton.Close
            };

            ContentDialogResult resultado = await dialogo.ShowAsync();
            if (resultado == ContentDialogResult.Primary)
            {

                try
                {
                    SignalR();
                }
                catch (Exception)
                {
                    falloConexion();
                }


            }
            else
            {
                CoreApplication.Exit();
            }

        }


        #endregion
    }
}

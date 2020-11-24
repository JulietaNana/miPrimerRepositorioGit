using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;

namespace JuegoSFML
{
    class Juego
    {
     
        
        //EstadoJuego Estado;
        private RenderWindow _ventana;
        private Sprite _backGround;
        private Texture _texBackGround;
        private Jugador _jugador1;
        private Jugador _jugador2;
        private Pelota _pelota;
        private Puntuacion _puntuacion;
        private CuentaRegresiva _cuentaRegresiva;
        private uint _anchoVentana = 800;
        private uint _altoVentana = 600;
        private bool gameOver = false;
        private bool gol = false;
        

        public void Setup()
        {
            _texBackGround = new Texture("Recursos/BackGround.png");
            _backGround = new Sprite(_texBackGround);
            _ventana = new RenderWindow(new VideoMode(_anchoVentana, _altoVentana), "Pong");
            _ventana.SetFramerateLimit(60);
            _jugador1 = new Jugador(0, "Recursos/RaquetaJugador2.png");
            _jugador1.ConfiguraControlador(Keyboard.Key.W, Keyboard.Key.S);

            _jugador2 = new Jugador((int)_anchoVentana - 40, "Recursos/RaquetaJugador1.png");
            _jugador2.ConfiguraControlador(Keyboard.Key.Up, Keyboard.Key.Down);

            


            _pelota = new Pelota();
            _puntuacion = new Puntuacion();

            _cuentaRegresiva = new CuentaRegresiva();

            //




        }

        public void Start()
        {

            Menu2 menuPrincipal = new Menu2();//
            menuPrincipal.ControladorMenu(Keyboard.Key.S);//
            menuPrincipal.EmpezarJuego();//
            Setup();
            //if (menuPrincipal.EmpezarJuego()) //
            //{
                    while (!gameOver)
                    {

                        while (!gol)
                        {

                            Input();
                            Update();
                            Render();
                        }
                        Reset();
                        System.Threading.Thread.Sleep(500);
                    }
           // }

               
            
        }




        //public void DibujarMenu()
        //{
        //    _ventana.DispatchEvents();
        //    _ventana.Clear(Color.Black);
        //    menu.DibujarMenu(_ventana);
        //}
         







        

        public void Update()
        {
            _pelota.Mover();
            ManejaColision();
            if(EsGol())
            {
                ManejaGol();
            }
            _puntuacion.Actualizar();
            _cuentaRegresiva.Actualizar();
            TerminoElTiempo();
            MaximoGoles();

        }

        public void Input()
        {
            _jugador1.ManejaInput();
            _jugador2.ManejaInput();

        }

        public void Render()
        {
            _ventana.Clear(Color.Black);
            _ventana.Draw(_backGround);
            foreach (Textos puntuacion in _puntuacion.Puntuaciones)
            {
                _ventana.Draw(puntuacion.Texto);
            }
            _ventana.Draw(_cuentaRegresiva.ObtenerCuentaRegresiva());
            _ventana.Draw(_jugador1.Rectangulo);
            _ventana.Draw(_jugador2.Rectangulo);
            _ventana.Draw(_pelota.Bola);
            _ventana.Display();

        }

        public void ManejaColision()
        {
            if (HayColisionConJugador())
            {
                _pelota.CambiarVelocidadX();
                _pelota.CambiarVelocidadY();
                _pelota.SonarColisionJugador();
                _pelota.CambiaraTextura2();
                
            }
            if (HayColisionConPantalla())
            {
                _pelota.CambiarVelocidadY();
                _pelota.SonarColisionVentana();
                _pelota.CambiaraTextura1();
            }

        }

        private bool HayColisionConJugador()
        {
            return _pelota.Colision(_jugador1) || _pelota.Colision(_jugador2);
        }

        private bool HayColisionConPantalla()
        {
           return _pelota.ColisionPantallaY(_altoVentana);
        }

        private bool EsGol()
        {
            return _pelota.ColisionPantallaXJ1(_anchoVentana) || _pelota.ColisionPantallaXJ2(_anchoVentana);
        }

        private void ManejaGol()
        {
            if(_pelota.ColisionPantallaXJ1(_anchoVentana))
            {
                _puntuacion.PuntosJugador1 += 1;
            } else
            {
                _puntuacion.PuntosJugador2 += 1;
            }
            gol = true;
        }
        
        public void Reset()
        {
             _pelota.Reset();

            

            Random r = new Random();

            if (r.Next(0, 2) == 0)
            {
                _pelota.CambiarVelocidadX();
                _pelota.CambiarVelocidadY();
            }
            else if (r.Next(0, 2) == 1)
            {
                _pelota.CambiarVelocidadX();


            }
            else if (r.Next(0, 2) == 2)
            {

                _pelota.CambiarVelocidadY();
            }

            gol = false;


        }

        public void TerminoElTiempo()
        {
            if (_cuentaRegresiva.SegundosRestantes == 0)
            {
                gameOver = true;
            }
        }

        public void MaximoGoles()
        {
            if (_puntuacion.PuntosJugador1 == _puntuacion.PuntajeMax 
                || _puntuacion.PuntosJugador2 == _puntuacion.PuntajeMax)
            {
                gameOver = true;
            }
        }

       
       
        
    }
}

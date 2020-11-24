using System;
using System.Threading;
using SFML.System;
using SFML.Graphics;


namespace JuegoSFML
{
    public class Puntuacion
    {

        private Font _fontArial = new Font("Recursos/Kinifed_.ttf");

        private Textos[] _puntuaciones;

        public Textos[] Puntuaciones
        {
            get { return _puntuaciones; }
        }

        private int _puntosJugador1;    
        public int PuntosJugador1
        {
            get { return _puntosJugador1; }
            set { _puntosJugador1 = value; }
        }

        private int _puntosJugador2;

        public int PuntosJugador2
        {
            get { return _puntosJugador2; }
            set { _puntosJugador2 = value; }
        }

        private int _puntajeMax = 5;
        public int PuntajeMax
        {
            get { return _puntajeMax; }
        }


        public Puntuacion()
        {
            _puntosJugador1 = 0;
            _puntosJugador2 = 0;
            
            Textos _puntuacionJ1 = new Textos( 40, Color.Black, new Vector2f(100, 8), _puntosJugador1.ToString());
            Textos _puntuacionJ2 = new Textos( 40, Color.Black, new Vector2f(700, 8), _puntosJugador2.ToString());

            _puntuaciones = new Textos[] { _puntuacionJ1, _puntuacionJ2 };
        }

        public void Actualizar()
        {
            _puntuaciones[0].Actualizar(_puntosJugador1.ToString());
            _puntuaciones[1].Actualizar(_puntosJugador2.ToString());

        }



     }


}

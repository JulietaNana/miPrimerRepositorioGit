using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace JuegoSFML
{
    class Jugador
    {
        
        private float _altoJugador = 80;
        private float _anchoJugador = 40;
        private Sprite _jugador;
        private Texture _texture;

        private Controlador _controlador;

        public Sprite Rectangulo
        {
            get { return _jugador; }
            set { _jugador = value; }
        }

        public Jugador(int posicionX, string a)
        {
            _texture = new Texture(a);
            _jugador = new Sprite(_texture);
            _jugador.Origin = new Vector2f(0,0);
            _jugador.Scale = new Vector2f(_anchoJugador / _jugador.GetGlobalBounds().Width, _altoJugador / _jugador.GetGlobalBounds().Height);
            _jugador.Position = new Vector2f(posicionX, 300);
            _controlador = new Controlador();

        }

        public void ConfiguraControlador(Keyboard.Key arriba, Keyboard.Key abajo)
        {
            _controlador.Arriba = arriba;
            _controlador.Abajo = abajo;
        }


        public void ManejaInput()
        {
            if (Keyboard.IsKeyPressed(_controlador.Arriba))
            {
                MoverArriba();

            }
            if (Keyboard.IsKeyPressed(_controlador.Abajo))
            {
                MoverAbajo();
            }
        }

        private void MoverArriba()
        {
        
            _jugador.Position += new Vector2f(0, -10f);

            if (ColisionArriba()) 
            {     
                _jugador.Position = new Vector2f(_jugador.Position.X, 0);

            }
        }

        private void MoverAbajo()
        {
            _jugador.Position += new Vector2f(0, 10f);
            if (ColisionAbajo())
            {
                _jugador.Position = new Vector2f(_jugador.Position.X, 600 -_altoJugador);

            }
        }

        public bool ColisionAbajo()
        {      
            return _jugador.Position.Y >= (600 - _altoJugador);
        }

        public bool ColisionArriba()
        {
            return _jugador.Position.Y <= 0;
        }

    }
}

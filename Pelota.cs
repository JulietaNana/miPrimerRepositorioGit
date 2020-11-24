using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System;

namespace JuegoSFML
{
    class Pelota
    {

        private Texture _textura1;
        private Texture _textura2;
        


        private Sprite _pelota;

        public Sprite Bola
        {
            get { return _pelota; }
        }

        private float _velocidadX = 2f;

        public float VelocidadX
        {
            get { return _velocidadX; }
            set { _velocidadX = value; }
        }
        private float _velocidadY = 2f;
        private float _radio = 30;

        private Sound _sound;

        public Pelota()
        {

            _textura1 = new Texture("Recursos/PelotaFeliz.png");
            _pelota = new Sprite(_textura1);

            _pelota.Origin = new Vector2f(_pelota.GetGlobalBounds().Width / 2, _pelota.GetGlobalBounds().Height / 2);
            _pelota.Scale = new Vector2f(_radio * 2 / _pelota.GetGlobalBounds().Width, _radio * 2 / _pelota.GetGlobalBounds().Height);
            _pelota.Position = new Vector2f(400, 300);

            SoundBuffer buffer = new SoundBuffer("Recursos/pelota-sfx.ogg");
            _sound = new Sound(buffer);

        }

        public void Mover()
        {
            _pelota.Position += new Vector2f(2f * _velocidadX, 2f * _velocidadY);
        }

        public void CambiarVelocidadX()
        {
            _velocidadX = -_velocidadX;

        }

        public void CambiarVelocidadY()
        {
            _velocidadY = -_velocidadY;
        }


        public bool Colision(Jugador jugador)
        {
            FloatRect limitePelota = _pelota.GetGlobalBounds();
            FloatRect limiteJugador = jugador.Rectangulo.GetGlobalBounds();
            return limitePelota.Intersects(limiteJugador);
        }

        public bool ColisionPantallaY(uint a)
        {
            return _pelota.Position.Y >= (a - _radio) || _pelota.Position.Y <= _radio;
        }

        public bool ColisionPantallaXJ1(uint a)
        {
            return _pelota.Position.X >= (a - _radio);
        }

        public bool ColisionPantallaXJ2(uint a)
        {
            return _pelota.Position.X <= (0 + _radio);
        }

        public void Reset()
        {
            _pelota.Position = new Vector2f(400, 300);
        }

        public void SonarColisionJugador()
        {
            _sound.Pitch = 3f;
            _sound.Play();
        }

        public void SonarColisionVentana()
        {
            _sound.Pitch = 5f;
            _sound.Play();
        }

        public void CambiaraTextura2()
        {
            _textura2 = new Texture("Recursos/PelotaGolpiada.png");
            _pelota.Texture = _textura2;
            

        }
        public void CambiaraTextura1()
        {
            _textura1 = new Texture("Recursos/PelotaFeliz.png");
            _pelota.Texture = _textura1;
             
        }

    }

}

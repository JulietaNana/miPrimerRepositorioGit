using SFML.System;
using SFML.Graphics;
using System.Timers;

namespace JuegoSFML
{
    
    class CuentaRegresiva
    {
        private Clock _cronometro;
        private float _segMaxJuego = 60;

        private float _cuentaRegresiva;
        public float SegundosRestantes
        {
            get { return _cuentaRegresiva; }
        }

        public Textos Reloj;

        public CuentaRegresiva()
        {
            _cronometro = new Clock();
            _cuentaRegresiva = _segMaxJuego;
            Reloj = new Textos(40, Color.Black, new Vector2f(370, 8), _cuentaRegresiva.ToString());
        }

        public void Actualizar()
        {
            _cuentaRegresiva = _segMaxJuego - (int)_cronometro.ElapsedTime.AsSeconds();
            Reloj.Actualizar(_cuentaRegresiva.ToString());
        }

        public Text ObtenerCuentaRegresiva()
        {
            return Reloj.Texto;
        }


       
        
    }
}

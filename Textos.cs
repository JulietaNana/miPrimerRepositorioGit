using SFML.System;
using SFML.Graphics;


namespace JuegoSFML
{
    public class Textos
    {
        private Font _fontArial = new Font("Recursos/Kinifed_.ttf");

        public Text Texto
        {
            get;set;
        }
        

        public Textos (uint tamano, Color color, Vector2f posicion, string texto)
        {
            Texto = new Text();
            Texto.Font = _fontArial;
            Texto.CharacterSize = tamano;
            Texto.FillColor = color;
            Texto.Position = posicion;
            Texto.DisplayedString = texto;
        }

        public void Actualizar(string texto)
        {
            Texto.DisplayedString = texto;
        }
    }


}

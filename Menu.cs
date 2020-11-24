using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;

namespace JuegoSFML
{
    public class Menu2
    {
        //poner jugar, con teclas que te lleve a esa palabra llevaría a una clase, mostrar 2 textos Jugar y Salir. 
        private Controlador _controlador;
        private RenderWindow _ventanaMenu;
        private Textos OpcionJugar;
        private Textos OpcionSalir;
        public Menu2() //
        {
            OpcionJugar = new Textos(50, Color.Black, new Vector2f(200, 95), "Jugar"); //
            OpcionSalir = new Textos(50, Color.Black, new Vector2f(200, 145), "Salir"); //
        }
        


        public bool EmpezarJuego()
        {
            if (Keyboard.IsKeyPressed(_controlador.Jugar))
            {
                return true;

            }
            return false;
        }
        public void ControladorMenu(Keyboard.Key S)
        {
            _controlador.Jugar = S;

        }

        public void Render()
        {

            _ventanaMenu.Clear(Color.Black);

            _ventanaMenu.Draw(OpcionJugar.Texto);

            _ventanaMenu.Draw(OpcionSalir.Texto);

            _ventanaMenu.Display();

        }








    }


    //    class Menu
    //    {
    //        private Keyboard.Key _arriba;
    //        private Keyboard.Key _abajo;
    //        private Keyboard.Key _eleccion;
    //        private Textos textNombreJuego;
    //        private Textos textMainMenu;
    //        private Textos textJugar;
    //        private Textos textSalir;
    //        private Controlador _controlador;

    //        enum opciones
    //        {
    //            Jugar = 1,
    //            Salir = 2
    //        }
    //        opciones opc;
    //        public Menu()
    //        {

    //            textNombreJuego = new Textos(50, Color.White, new Vector2f(200, 15), "TPONG");
    //            textMainMenu = new Textos(50, Color.White, new Vector2f(200, 55), "MENU");
    //            textJugar = new Textos(50, Color.White, new Vector2f(200, 95), "Jugar");
    //            textSalir = new Textos(50, Color.White, new Vector2f(200, 145), "Salir");
    //            _controlador = new Controlador();


    //        }

           

    //        public int MoverenMenu()
    //        {
    //            if (Keyboard.IsKeyPressed(_arriba))
    //            {
    //                opc = opciones.Jugar;
    //                return 0;
    //            }
    //            if (Keyboard.IsKeyPressed(_abajo))
    //            {
    //                opc = opciones.Salir;
    //                return 0;
    //            }
    //            if (Keyboard.IsKeyPressed(_eleccion))
    //            {
    //                return ((int)opc);
    //            }
    //            return 0;
    //        }
    //    }





    //}
}

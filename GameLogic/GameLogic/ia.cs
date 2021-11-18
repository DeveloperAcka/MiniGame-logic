using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    class ia : player
    {
        public ia() //constructor
        {
            this.id = "MÁQUINA";
        }

        //crea el deck del jugador
        public override List<carta> crearDeck(List<carta> cartasTotales) //falta por implementar
        {
            //asigna el deck manualmente -- al menos deben existir 5 guerreros
            List<carta> deck = new List<carta>();
            return deck;
        }

        //selecciona criterio de ronda
        public override int seleccionarCriterio() //falta por implementar
        {
            int criterio = 0;
            return criterio;
        }

        //arma una jugada de ronda con sus cartas, y retorna una lista con las cartas jugadas en esa ronda
        public override List<carta> armarJugada() //falta por implementar
        {
            List<carta> jugada = new List<carta>();
            return jugada;
        }


    }
}

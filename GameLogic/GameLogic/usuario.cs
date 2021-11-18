using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    class usuario : player
    {
        private double escencia;
        private int partidasGanadas;
        private int partidasPerdidas;

        //constructor
        public usuario(String id)
        {
            this.id = id;
        }

        //crea el deck del jugador
        public override List<carta> crearDeck(List<carta> cartasTotales)
        {
            //asigna el deck manualmente -- al menos deben existir 5 guerreros
            List<carta> deck = new List<carta>();

            deck.Add(cartasTotales[0]);
            deck.Add(cartasTotales[1]);
            deck.Add(cartasTotales[5]);
            deck.Add(cartasTotales[9]);
            deck.Add(cartasTotales[13]);
            deck.Add(cartasTotales[17]);
            deck.Add(cartasTotales[18]);
            deck.Add(cartasTotales[20]);
            deck.Add(cartasTotales[22]);
            deck.Add(cartasTotales[23]);
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

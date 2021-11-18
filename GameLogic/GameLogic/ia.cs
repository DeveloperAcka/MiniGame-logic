using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            bool aux = false;

            while (aux == false)
            {
                //lista auxiliar
                List<carta> comp = new List<carta>();

                //falta crear el deck de la maquina
                var rnd = new Random();
                var randomNumbers = Enumerable.Range(0, 29).OrderBy(x => rnd.Next()).Take(10).ToList();

                //crear el mazo de la máquina
                int i;
                for (i = 0; i < 10; i++)
                {
                    comp.Add( cartasTotales[randomNumbers[i]] );
                }


                int contador = 0;
                //comprobar al menos 5 guerreros
                foreach (carta card in comp)
                {
                    if (card.getTipo() == "guerrero")
                    {
                        contador = contador + 1;
                    }
                }

                if (contador == 5)
                {
                    aux = true;
                    deck = comp;
                }
            }
            
            return deck;
        }

        //selecciona criterio de ronda 
        public override int seleccionarCriterio() 
        {
            int criterio = 0;
            var rnd2 = new Random();
            var randomNumber3 = Enumerable.Range(1, 4).OrderBy(x => rnd2.Next()).Take(1).ToList();
            criterio = randomNumber3[0];
            return criterio;
        }

        //arma una jugada de ronda con sus cartas, y retorna una lista con las cartas jugadas en esa ronda, devuelvo una lista con las cartas para enfrentar el duelo
        public override List<carta> armarJugada(List<carta> cartasTotales)
        {
            List<carta> jugada = new List<carta>();


            //selecciono el guerrero randomicamente
            int movi = 0;
            bool selec = false;
            while (selec == false)
            {
                var rnd4 = new Random();
                var randomNumber4 = Enumerable.Range(0, cartasTotales.Count).OrderBy(x => rnd4.Next()).Take(1).ToList();
                movi = randomNumber4[0];

                if (cartasTotales[movi] != null && cartasTotales[movi].getTipo() == "guerrero")
                {
                    // agrego la carta a la lista
                    jugada.Add(cartasTotales[movi]);
                    selec = true;
                }
            }

            


            //agregación de carta de estrategia
            bool mien = false;
            while (mien == false)
            {
                Random x = new Random();
                int resp = x.Next(cartasTotales.Count);
                if (cartasTotales[resp].getTipo() != "guerrero") // si el randomico genera diferente de guerrero
                {
                    //agregarla a la lista
                    jugada.Add(cartasTotales[resp]);
                    mien = true;
                }
            }

            return jugada;
        }

    }
}

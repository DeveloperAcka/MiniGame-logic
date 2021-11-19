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
            deck.Add(cartasTotales[2]);
            deck.Add(cartasTotales[9]);
            deck.Add(cartasTotales[13]);
            deck.Add(cartasTotales[17]);
            deck.Add(cartasTotales[18]);
            deck.Add(cartasTotales[20]);
            deck.Add(cartasTotales[22]);
            deck.Add(cartasTotales[29]);
            return deck;
        }

        //selecciona criterio de ronda
        public override int seleccionarCriterio() //genera un criterio por entrada de jugador
        {
            int criterio = 0;

            Console.WriteLine("Selección de criterio de duelo");
            Console.WriteLine("\nOpciones de duelo: ");
            Console.WriteLine("1. Gana la carta con mayor ataque");
            Console.WriteLine("2. Gana la carta con menor ataque");
            Console.WriteLine("3. Gana la carta con mayor defensa");
            Console.WriteLine("4. Gana la carta con menor defensa");
            criterio = Convert.ToInt32(Console.ReadLine());

            switch (criterio)
            {
                case 1:
                    Console.WriteLine(this.id + " ha elegido que Gana la carta con mayor ataque: ");
                    break;

                case 2:
                    Console.WriteLine(this.id + " ha elegido que Gana la carta con menor ataque: ");
                    break;

                case 3:
                    Console.WriteLine(this.id + " ha elegido que Gana la carta con mayor defensa: ");
                    break;

                case 4:
                    Console.WriteLine(this.id + " ha elegido que Gana la carta con menor defensa: ");
                    break;

            }

            Console.ReadLine();


            return criterio;
        }

        //arma una jugada de ronda con sus cartas, y retorna una lista con las cartas jugadas en esa ronda
        public override void armarJugada()
        {
            List<carta> jugada = new List<carta>();

            //primero se elige una carta tipo guerreo
            bool selec = false;
            int sel = 0;
            while (selec == false)
            {
                Console.WriteLine("Escoja una carta de tipo guerrero, Ingrese el número");
                imprimirDeck();
                sel = Convert.ToInt32(Console.ReadLine());
                if (deck[sel] != null && deck[sel].getTipo() == "guerrero")
                {
                    selec = true;
                    //agrego a la lista de salida, la carta guerrero escogida
                    jugada.Add(deck[sel]);
                }
                    
                else
                    Console.WriteLine("Escoja un numero de carta valido, asegúrese que sea un guerrero");
            }

            //agregación de cartas de estrategia
            Console.WriteLine("\n\nDesea agregar una carga de estrategia? si/no");
            String resp = Console.ReadLine();

            while(resp == "si" && deck.Count>0)
            {
                Console.WriteLine("\n\nEscoja una carta de estrategia, Ingrese el número");
                imprimirDeck();
                sel = Convert.ToInt32(Console.ReadLine());
                if (deck[sel] != null && deck[sel].getTipo() != "guerrero")
                {
                    selec = true;
                    //agrego a la lista de salida la carta escogida
                    jugada.Add(deck[sel]);
                    Console.WriteLine("\n\nDesea agregar otra carta? si/no");
                    resp = Console.ReadLine();
                }
                else
                    Console.WriteLine("Escoja un numero de carta valido, asegúrese que no sea un guerrero");

            }

            this.jugada = jugada;

            //borrar las cartas del deck
            int i = 0;
            foreach (carta card in jugada)
            {
                deck.Remove(card);
            }
        }
    }
}

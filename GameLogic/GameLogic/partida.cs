using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    class partida
    {
        public static void Main()
        {
         
            //creo los jugadores, puede ser usuario vs usuario, usuario vs ia
            usuario player1 = new usuario("ProGamer");
            ia player2 = new ia();

            //creo la partida pasándole los jugadores
            partida P = new partida(player1, player2);

        }

        //constructor ** player 1 = usuario, player 2 = IA
        public partida(usuario player1, ia player2)
        {
            Console.WriteLine("Inicio de partida");
            Console.WriteLine("\n\nPresione una tecla para continuar");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Decks de los jugadores: \n\n");
            player1.imprimirDeck();
            player2.imprimirDeck();

        }
    }
}

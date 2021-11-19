using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    class partida
    {
        private usuario player1 = new usuario("ProGamer"); //jugador1
        private ia player2 = new ia(); //jugador 2

        private int contadorPlayer1 = 0; //contador de victorias del jugador1
        private int contadorPlayer2 = 0; //contador de victorias del jugador2
        private String winner; //ganador de la partida
        private String looser; //perdedor de la partida

        
        public static void Main()
        {
            //creo la partida pasándole los jugadores
            partida P = new partida();
        }

        //constructor ** player 1 = usuario, player 2 = IA
        public partida()
        {
            Console.WriteLine("Inicio de partida");
            Console.WriteLine("\n\nPresione una tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Decks de los jugadores: \n\n");
            player1.imprimirDeck();
            player2.imprimirDeck();
            Console.ReadLine();
            jugar();
        }

        public void jugar() { 
            //asignar los turnos
            Console.Clear();
            Console.WriteLine("Asignando turnos mediante moneda...");
            Console.WriteLine("\n\nPresione una tecla para continuar...");
            Console.ReadLine();
            asignarTurnos();
            

            //inician las rondas
            int ronda = 0;
            while (contadorPlayer1 < 3 && contadorPlayer2 < 3)
            {
                ronda = ronda + 1;
                Console.Clear();
                Console.WriteLine("Ronda N: " + ronda);
                Console.WriteLine("Presione una tecla para continuar...");
                if(player1.getPrimero() == true && ronda%2==1) //propuesta del usuario y respuesta de la máquina
                {
                    //propuesta usuario
                    Console.Clear();
                    Console.WriteLine("Turno del usuario");
                    Console.WriteLine("Presione una tecla para continuar...");
                    int opc;
                    opc = player1.seleccionarCriterio();
                    player1.armarJugada();

                    //respuesta de la máquina
                    Console.WriteLine("Turno de la máquina");
                    Console.WriteLine("Presione una tecla para continuar...");
                    player2.armarJugada();

                    //hallar ganador
                    hallarGanador(opc);
                }
                else if (player1.getPrimero() == true && ronda % 2 == 0)  //propuesta de la máquina y respuesta del usuario
                {
                    //propuesta de la máquina
                    int opc;
                    opc = player2.seleccionarCriterio();
                    player2.armarJugada();

                    //respuesta del usuario
                    player1.armarJugada();

                    //hallar ganador
                    hallarGanador(opc);
                }
                else if (player2.getPrimero() == true && ronda % 2 == 1)  //propuesta de la máquina y respuesta del usuario
                {
                    //propuesta de la máquina
                    int opc;
                    opc = player2.seleccionarCriterio();
                    player2.armarJugada();

                    //respuesta del usuario
                    player1.armarJugada();

                    //hallar ganador
                    hallarGanador(opc);
                }
                if (player2.getPrimero() == true && ronda % 2 == 0) //propuesta del usuario y respuesta de la máquina
                {
                    //propuesta usuario
                    Console.Clear();
                    Console.WriteLine("Turno del usuario");
                    Console.WriteLine("Presione una tecla para continuar...");
                    int opc;
                    opc = player1.seleccionarCriterio();
                    player1.armarJugada();

                    //respuesta de la máquina
                    Console.WriteLine("Turno de la máquina");
                    Console.WriteLine("Presione una tecla para continuar...");
                    player2.armarJugada();

                    //hallar ganador
                    hallarGanador(opc);
                }


                Console.WriteLine(contadorPlayer1);
                Console.WriteLine(contadorPlayer2);
                Console.ReadLine();
            }

            Console.Clear();

            //imprimir ganador
            if (contadorPlayer1 > contadorPlayer2)
            {
                Console.WriteLine("HA GANADO LA PARTIDA: " + player1.getId());
                winner = player1.getId();
                looser = player2.getId();
                Console.WriteLine("pulse una tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("HA GANADO LA PARTIDA" + player2.getId());
                looser = player1.getId();
                winner = player2.getId();
                Console.WriteLine("pulse una tecla para continuar...");
                Console.ReadLine();
                Console.Clear();
            }

            //cerrar el juego
            Environment.Exit(0);
        }

        //asigno los turnos por moneda
        public void asignarTurnos()
        {
            bool resp;
            Random moneda = new Random();
            int cae = moneda.Next(2);
            if (cae == 0) //gana el player 1
            {
                resp = true;
            }
            else //gana el player 2
            {
                resp = false;
            }

            if (resp == true) //asignar los turnos
            {
                player1.setPrimero(true);
                player2.setPrimero(false);
                Console.WriteLine("El " + player1.getId() + " comienza");
            }
            else
            {
                player1.setPrimero(false);
                player2.setPrimero(true);
                Console.WriteLine("El " + player2.getId() + " comienza");
            }
            Console.ReadLine();
        }

        //hallar ganador de una ronda
        public void hallarGanador(int opc)
        {
            //COMPARACIÓN DE QUIÉN GANA
            //primero es sacar todas las cartas y aplicar su estrategia
            List<carta> lista1 = player1.getJugada();
            List<carta> lista2 = player2.getJugada();

            carta c1 = lista1[0];
            carta c2 = lista2[0];

            lista1.Remove(c1);
            lista2.Remove(c2);

            //aplicar lista 1
            foreach(carta card in lista1)
            {
                //aplicación de magia y equipo
                if(card.getTipo()=="magia" || card.getTipo()=="equipo")
                {
                    //para magicas y equipo
                    if (opc == 1) //aumenta el ataque
                    {
                        c1.setAtaque(c1.getAtaque() + card.getAtaque());
                    }
                    else if (opc == 2) //disminuye el ataque
                    {
                        c1.setAtaque(c1.getAtaque() - card.getAtaque());
                    }
                    else if (opc == 3) //disminuye el ataque
                    {
                        c1.setDefensa(c1.getDefensa() + card.getDefensa());
                    }
                    else if (opc == 4) //disminuye el ataque
                    {
                        c1.setDefensa(c1.getDefensa() - card.getDefensa());
                    }

                }

                //aplicación de diplomacia
                if(card.getTipo()=="diplomacia")
                {
                    //para diplomacia
                    if (opc == 1) //disminuye el ataque del oponente
                    {
                        c2.setAtaque(c2.getAtaque() - card.getAtaque());
                    }
                    else if (opc == 2) //aumenta el ataque del oponente
                    {
                        c2.setAtaque(c2.getAtaque() + card.getAtaque());
                    }
                    else if (opc == 3) //disminuyo la defensa del oponente
                    {
                        c2.setDefensa(c2.getDefensa() - card.getDefensa());
                    }
                    else if (opc == 4) //aumenta la defensa del oponente
                    {
                        c2.setDefensa(c2.getDefensa() + card.getDefensa());
                    }
                }


            }

            //aplicar lista 2
            foreach (carta card in lista2)
            {
                //aplicación de magia y equipo
                if (card.getTipo() == "magia" || card.getTipo() == "equipo")
                {
                    //para magicas y equipo
                    if (opc == 1) //aumenta el ataque
                    {
                        c2.setAtaque(c2.getAtaque() + card.getAtaque());
                    }
                    else if (opc == 2) //disminuye el ataque
                    {
                        c2.setAtaque(c2.getAtaque() - card.getAtaque());
                    }
                    else if (opc == 3) //disminuye el ataque
                    {
                        c2.setDefensa(c2.getDefensa() + card.getDefensa());
                    }
                    else if (opc == 4) //disminuye el ataque
                    {
                        c2.setDefensa(c2.getDefensa() - card.getDefensa());
                    }

                }

                //aplicación de diplomacia
                if (card.getTipo() == "diplomacia")
                {
                    //para diplomacia
                    if (opc == 1) //disminuye el ataque del oponente
                    {
                        c1.setAtaque(c1.getAtaque() - card.getAtaque());
                    }
                    else if (opc == 2) //aumenta el ataque del oponente
                    {
                        c1.setAtaque(c1.getAtaque() + card.getAtaque());
                    }
                    else if (opc == 3) //disminuyo la defensa del oponente
                    {
                        c1.setDefensa(c1.getDefensa() - card.getDefensa());
                    }
                    else if (opc == 4) //aumenta la defensa del oponente
                    {
                        c1.setDefensa(c1.getDefensa() + card.getDefensa());
                    }
                }


            }

            //ahora comparo las cartas
            switch(opc)
            {
                case 1:
                    if(c1.getAtaque()>c2.getAtaque())
                    {
                        Console.WriteLine("Ha ganado " + player1.getId());
                        contadorPlayer1 = contadorPlayer1 + 1;
                    }
                    else
                    {
                        Console.WriteLine("Ha ganado " + player2.getId());
                        contadorPlayer2 = contadorPlayer2+ 1;
                    }
                    break;

                case 2:
                    if (c1.getAtaque() < c2.getAtaque())
                    {
                        Console.WriteLine("Ha ganado " + player1.getId());
                        contadorPlayer1 = contadorPlayer1 + 1;
                    }
                    else
                    {
                        Console.WriteLine("Ha ganado " + player2.getId());
                        contadorPlayer2 = contadorPlayer2 + 1;
                    }
                    break;

                case 3:
                    if (c1.getDefensa() > c2.getDefensa())
                    {
                        Console.WriteLine("Ha ganado " + player1.getId());
                        contadorPlayer1 = contadorPlayer1 + 1;
                    }
                    else
                    {
                        Console.WriteLine("Ha ganado " + player2.getId());
                        contadorPlayer2 = contadorPlayer2 + 1;
                    }
                    break;

                case 4:
                    if (c1.getDefensa() < c2.getDefensa())
                    {
                        Console.WriteLine("Ha ganado " + player1.getId());
                        contadorPlayer1 = contadorPlayer1 + 1;
                    }
                    else
                    {
                        Console.WriteLine("Ha ganado " + player2.getId());
                        contadorPlayer2 = contadorPlayer2 + 1;
                    }
                    break;
            }

            
            Console.WriteLine("Pulse una tecla para continuar...");
            Console.ReadLine();
        }


    }
}

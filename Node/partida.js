const usuario = require("./usuario.js");
const ia = require("./ia.js");
const player = require("./player.js");

class partida
{
    // constructor ** player 1 = usuario, player 2 = IA
    constructor()
    {
        this.player1 = new usuario("ProGamer"); 
        // player1.crearDeck(player1.importarCartas());//jugador1
        this.player2 = new ia(); //jugador 2

        this.contadorPlayer1 = 0; //contador de victorias del jugador1
        this.contadorPlayer2 = 0; //contador de victorias del jugador2
        this.winner; //ganador de la partida
        this.looser; //perdedor de la partida

        console.log("Inicio de partida");
        console.clear();
        console.log("Decks de los jugadores: \n\n");
        this.player1.imprimirDeck();
        this.player2.imprimirDeck();
        this.jugar();
        
    }

    jugar() 
    { 
        // Asignar los turnos
        console.clear();
        console.log("Asignando turnos mediante moneda...");
        this.asignarTurnos();

        // Inician las rondas
        let ronda = 0;
        while (this.contadorPlayer1 < 3 && this.contadorPlayer2 < 3)
        {
            ronda = ronda + 1;
            console.clear();
            console.log("Ronda N: " + ronda);
            console.log("Presione una tecla para continuar...");
            if(player1.getPrimero() == true && ronda%2==1) // propuesta del usuario y respuesta de la máquina
            {
                // Propuesta usuario
                Console.Clear();
                console.log("Turno del usuario");
                console.log("Presione una tecla para continuar...");
                let opc;
                opc = player1.seleccionarCriterio();
                player1.armarJugada();

                // Respuesta de la máquina
                console.log("Turno de la máquina");
                console.log("Presione una tecla para continuar...");
                this.player2.armarJugada();

                // Hallar ganador
                hallarGanador(opc);
            }
            else if (player1.getPrimero() == true && ronda % 2 == 0)  // propuesta de la máquina y respuesta del usuario
            {
                // Propuesta de la máquina
                let opc;
                opc = this.player2.seleccionarCriterio();
                this.player2.armarJugada();

                // Respuesta del usuario
                player1.armarJugada();

                // Hallar ganador
                hallarGanador(opc);
            }
            else if (this.player2.getPrimero() == true && ronda % 2 == 1)  // propuesta de la máquina y respuesta del usuario
            {
                // Propuesta de la máquina
                let opc;
                opc = this.player2.seleccionarCriterio();
                this.player2.armarJugada();

                // Respuesta del usuario
                player1.armarJugada();

                // Hallar ganador
                hallarGanador(opc);
            }
            if (this.player2.getPrimero() == true && ronda % 2 == 0) // propuesta del usuario y respuesta de la máquina
            {
                // Propuesta usuario
                Console.Clear();
                console.log("Turno del usuario");
                console.log("Presione una tecla para continuar...");
                let opc;
                opc = player1.seleccionarCriterio();
                player1.armarJugada();

                // Respuesta de la máquina
                console.log("Turno de la máquina");
                console.log("Presione una tecla para continuar...");
                this.player2.armarJugada();

                // Hallar ganador
                hallarGanador(opc);
            }


            console.log("Puntos de usuario: "+this.contadorPlayer1);
            console.log("Puntos de máquina: "+this.contadorthis.Player2);
            Console.ReadLine();
        }

        Console.Clear();

        // Imprimir ganador
        if (this.contadorPlayer1 > this.contadorthis.Player2)
        {
            console.log("HA GANADO LA PARTIDA: " + player1.getId());
            winner = player1.getId();
            looser = this.player2.getId();
            console.log("pulse una tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }
        else
        {
            console.log("HA GANADO LA PARTIDA" + this.player2.getId());
            looser = player1.getId();
            winner = this.player2.getId();
            console.log("pulse una tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        //cerrar el juego
        Environment.Exit(0);
    }

    // Asigno los turnos por moneda
    asignarTurnos()
    {
        let resp;
        let cae = Math.floor(Math.random() * 2);
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
           this.player1.setPrimero(true);
            this.player2.setPrimero(false);
            console.log("El " + this.player1.getId() + " comienza");
        }
        else
        {
            this.player1.setPrimero(false);
            this.player2.setPrimero(true);
            console.log("El " + this.player2.getId() + " comienza");
        }
        // console.ReadLine();
    }

    // Hallar ganador de una ronda
    hallarGanador(opc)
    {
        // COMPARACIÓN DE QUIÉN GANA
        // primero es sacar todas las cartas y aplicar su estrategia
        let lista1 = this.player1.getJugada();
        let lista2 = this.player2.getJugada();


        //IMPRESIÓN DE LAS JUGADAS DE CADA UNO
        //***********************************************************************
        Console.Clear();
        console.log("Comparación de jugadas: ");
        console.log("\n\nJugada de " + player1.getId());
        lista1.forEach(card => {
            card.info();
        });
        console.log("\n\nJugada de " + this.player2.getId());
        lista2.forEach(card => {
           card.info(); 
        });
        //*************************************************************************

        

        let c1 = lista1[0];
        let c2 = lista2[0];

        lista1.remove(c1);
        lista2.remove(c2);

        // aplicar lista 1
        lista1.forEach(card => {
            
            // aplicación de magia y equipo
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

            // aplicación de diplomacia
            if(card.getTipo()=="diplomacia")
            {
                // para diplomacia
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
        });
        

        //aplicar lista 2
        lista2.forEach(card => {

            // aplicación de magia y equipo
            if (card.getTipo() == "magia" || card.getTipo() == "equipo")
            {
                // para magicas y equipo
                if (opc == 1) // aumenta el ataque
                {
                    c2.setAtaque(c2.getAtaque() + card.getAtaque());
                }
                else if (opc == 2) // disminuye el ataque
                {
                    c2.setAtaque(c2.getAtaque() - card.getAtaque());
                }
                else if (opc == 3) // disminuye el ataque
                {
                    c2.setDefensa(c2.getDefensa() + card.getDefensa());
                }
                else if (opc == 4) // disminuye el ataque
                {
                    c2.setDefensa(c2.getDefensa() - card.getDefensa());
                }

            }

            // aplicación de diplomacia
            if (card.getTipo() == "diplomacia")
            {
                // para diplomacia
                if (opc == 1) // disminuye el ataque del oponente
                {
                    c1.setAtaque(c1.getAtaque() - card.getAtaque());
                }
                else if (opc == 2) // aumenta el ataque del oponente
                {
                    c1.setAtaque(c1.getAtaque() + card.getAtaque());
                }
                else if (opc == 3) // disminuyo la defensa del oponente
                {
                    c1.setDefensa(c1.getDefensa() - card.getDefensa());
                }
                else if (opc == 4) // aumenta la defensa del oponente
                {
                    c1.setDefensa(c1.getDefensa() + card.getDefensa());
                }
            }            
        });


        //*impresión de los stats finales
        console.log("\n\nStats final de " + player1.getId());
        c1.info();

        console.log("\n\nStats final de " + this.player2.getId());
        c2.info();

        console.log("\n\nLa opción de juego es");
        opc = prompt;

        console.log("Pulse una tecla para continuar...");
        // Console.ReadLine();
        //***************************************************************************


        //ahora comparo las cartas
        switch (opc)
        {
            case 1:
                if(c1.getAtaque()>c2.getAtaque())
                {
                    console.log("Ha ganado " + player1.getId());
                    this.contadorPlayer1 = this.contadorPlayer1 + 1;
                }
                else
                {
                    console.log("Ha ganado " + this.player2.getId());
                    this.contadorthis.Player2 = this.contadorthis.Player2+ 1;
                }
                break;

            case 2:
                if (c1.getAtaque() < c2.getAtaque())
                {
                    console.log("Ha ganado " + player1.getId());
                    this.contadorPlayer1 = this.contadorPlayer1 + 1;
                }
                else
                {
                    console.log("Ha ganado " + this.player2.getId());
                    this.contadorthis.Player2 = this.contadorthis.Player2 + 1;
                }
                break;

            case 3:
                if (c1.getDefensa() > c2.getDefensa())
                {
                    console.log("Ha ganado " + player1.getId());
                    this.contadorPlayer1 = this.contadorPlayer1 + 1;
                }
                else
                {
                    console.log("Ha ganado " + this.player2.getId());
                    this.contadorthis.Player2 = this.contadorthis.Player2 + 1;
                }
                break;

            case 4:
                if (c1.getDefensa() < c2.getDefensa())
                {
                    console.log("Ha ganado " + player1.getId());
                    this.contadorPlayer1 = this.contadorPlayer1 + 1;
                }
                else
                {
                    console.log("Ha ganado " + this.player2.getId());
                    this.contadorthis.Player2 = this.contadorthis.Player2 + 1;
                }
                break;
        }

        
        console.log("Pulse una tecla para continuar...");
        // Console.ReadLine();
    }
}

//creo la partida pasándole los jugadores
let P = new partida();

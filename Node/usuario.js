const player = require("./player.js");

class usuario extends player
{
    
    constructor(player_id)
    {
        super();
        // console.log(cartasTotales.toString());
       this.id = player_id;
    }

    

    // Crea el deck del jugador
    crearDeck(cartasTotales)
    {
        // asigna el deck manualmente -- al menos deben existir 5 guerreros
        
        let deck = [];
        deck.push(cartasTotales[4]);
        deck.push(cartasTotales[1]);
        deck.push(cartasTotales[2]);
        deck.push(cartasTotales[9]);
        deck.push(cartasTotales[13]);
        deck.push(cartasTotales[17]);
        deck.push(cartasTotales[18]);
        deck.push(cartasTotales[20]);
        deck.push(cartasTotales[22]);
        deck.push(cartasTotales[29]);
        return deck;
    }

    // selecciona criterio de ronda
    seleccionarCriterio() //genera un criterio por entrada de jugador
    {
        let criterio = 0;

        console.log("Selección de criterio de duelo");
        console.log("\nOpciones de duelo: ");
        console.log("1. Gana la carta con mayor ataque");
        console.log("2. Gana la carta con menor ataque");
        console.log("3. Gana la carta con mayor defensa");
        console.log("4. Gana la carta con menor defensa");
        criterio = prompt;

        switch (criterio)
        {
            case 1:
                console.log(this.id + " ha elegido que Gana la carta con mayor ataque: ");
                break;

            case 2:
                console.log(this.id + " ha elegido que Gana la carta con menor ataque: ");
                break;

            case 3:
                console.log(this.id + " ha elegido que Gana la carta con mayor defensa: ");
                break;

            case 4:
                console.log(this.id + " ha elegido que Gana la carta con menor defensa: ");
                break;

        }

        // Console.ReadLine();

        return criterio;
    }

    // Arma una jugada de ronda con sus cartas, y retorna una lista con las cartas jugadas en esa ronda
    armarJugada()
    {
        let jugada = [];

        // Primero se elige una carta tipo guerreo
        let selec = false;
        let sel = 0;
        while (selec == false)
        {
            console.log("Escoja una carta de tipo guerrero, Ingrese el número");
            imprimirDeck();
            sel = prompt;
            if (deck[sel] != null && deck[sel].getTipo() == "guerrero")
            {
                selec = true;
                // Agrego a la lista de salida, la carta guerrero escogida
                jugada.push(deck[sel]);
            }
            else
                console.log("Escoja un numero de carta valido, asegúrese que sea un guerrero");
        }

        // Agregación de cartas de estrategia
        console.log("\n\nDesea agregar una carga de estrategia? si/no");
        let resp = prompt();

        while(resp == "si" && deck.lenght>0)
        {
            console.log("\n\nEscoja una carta de estrategia, Ingrese el número");
            imprimirDeck();
            sel = prompt();
            if (deck[sel] != null && deck[sel].getTipo() != "guerrero")
            {
                selec = true;
                // Agrego a la lista de salida la carta escogida
                jugada.push(deck[sel]);
                console.log("\n\nDesea agregar otra carta? si/no");
                resp = prompt();
            }
            else
                console.log("Escoja un numero de carta valido, asegúrese que no sea un guerrero");

        }

        this.jugada = jugada;
        
        //borrar las cartas del deck
        let i = 0;
        jugada.forEach((card, i) => {
            deck.splice(i, card);
        });
    }
}

module.exports = usuario;
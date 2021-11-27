const player = require("./player.js");

class ia extends player
{
    // Constructor
    constructor()
    {
        super();
        this.id = "MÁQUINA";
    }

    // Crea el deck del jugador
    crearDeck(cartasTotales) //falta por implementar
    {
        // Asigna el deck manualmente -- al menos deben existir 5 guerreros
        let deck = [];

        let aux = false;
        
        while (aux == false)
        {
            //lista auxiliar
            let comp = [];

            //falta crear el deck de la maquina
            let randomNumbers = Array.from({length:10}, () => Math.floor(Math.random() * 30));

            //crear el mazo de la máquina
            let i;
            for (i = 0; i < 10; i++)
            {
                comp.push( cartasTotales[randomNumbers[i]] );
            }


            let contador = 0;
            //comprobar al menos 5 guerreros
            comp.forEach(card => {
                if (card.getTipo() == 'guerrero') {
                    contador++;
                }
            });

            if (contador == 5)
            {
                aux = true;
                deck = comp;
            }
        }
        
        return deck;
    }

    // Selecciona criterio de ronda 
    seleccionarCriterio() 
    {
        let criterio = 0;
        let randomNumber3 = Array.from({length:1}, () => Math.floor(Math.random() * 5));
        criterio = randomNumber3[0];

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

        return criterio;
    }

    // Arma una jugada de ronda con sus cartas, y retorna una lista con las cartas jugadas en esa ronda, devuelvo una lista con las cartas para enfrentar el duelo
    armarJugada()
    {
        let jugada = [];
        // Selecciono el guerrero randomicamente
        let movi = 0;
        let selec = false;
        while (selec == false)
        {
            var randomNumber4 = Array.from({length:1}, () => Math.floor(Math.random() * deck.length));
            movi = randomNumber4[0];

            if (deck[movi] != null && deck[movi].getTipo() == "guerrero")
            {
                // agrego la carta a la lista
                jugada.push(deck[movi]);
                selec = true;
            }
        }

        // Agregación de carta de estrategia
        let mien = false;
        while (mien == false)
        {
            let resp = Math.floor(Math.random() * (deck.length+1));
            if (deck[resp].getTipo() != "guerrero") // si el randomico genera diferente de guerrero
            {
                // Agregarla a la lista
                jugada.push(deck[resp]);
                mien = true;
            }
        }

        this.jugada = jugada;

        // Borrar las cartas del deck
        let i = 0;
        jugada.forEach((card,i) => {
            deck.remove(i, card);
        });

    }
}

module.exports = ia;
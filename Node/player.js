const carta = require("./carta.js");
const readline = require('readline-sync');

class player
{      
    
    constructor()
    {    
        this.id;
        this.primero;
        this.jugada;
        let cartasTotales = this.importarCartas();
        this.deck = this.crearDeck(cartasTotales);
    }

    // Cargar todas las cartas
    importarCartas()
    {
        // Importa la cartas manualmente
        let a0 = new carta(10, "Bruja verde", "magia", 450, 580, 1000);
        let a1 = new carta(1, "Bruja blanca", "guerrero", 800, 500, 1000);
        let a2 = new carta(2, "Bruja azul", "magia", 700, 400, 3000);
        let a3 = new carta(3, "Bruja roja", "equipo", 200, 500, 5000);
        let a4 = new carta(4, "Bruja celeste", "diplomacia", 600, 400, 1000);
        let a5 = new carta(5, "Bruja morada", "guerrero", 900, 200, 5000);
        let a6 = new carta(6, "Bruja negra", "magia", 50, 5000, 1000);
        let a7 = new carta(7, "Bruja rosada", "equipo", 150, 4800, 1000);
        let a8 = new carta(8, "Bruja gris", "diplomacia", 300, 500, 1000);
        let a9 = new carta(9, "Bruja escarlata", "guerrero", 850, 510, 1000);
        let b0 = new carta(20, "Duende verde", "diplomacia", 478, 525, 1000);
        let b1 = new carta(11, "Duende blanco", "equipo", 125, 8000, 1000);
        let b2 = new carta(12, "Duende azul", "diplomacia", 200, 5000, 1000);
        let b3 = new carta(13, "Duende rojo", "guerrero", 1250, 50, 1000);
        let b4 = new carta(14, "Duende celeste", "magia", 80, 50, 1000);
        let b5 = new carta(15, "Duende morado", "equipo", 8, 5, 1000);
        let b6 = new carta(16, "Duende negro", "diplomacia", 8000, 5000, 1000);
        let b7 = new carta(17, "Duende rosado", "guerrero", 777, 555, 1000);
        let b8 = new carta(18, "Duende gris", "magia", 888, 111, 1000);
        let b9 = new carta(19, "Duende escarlata", "equipo", 800, 147, 1000);
        let c0 = new carta(30, "Dragon verde", "magia", 7800, 7500, 1000);
        let c1 = new carta(21, "Dragon blanco", "guerrero", 278, 5000, 1000);
        let c2 = new carta(22, "Dragon azul", "magia", 8000, 50, 1000);
        let c3 = new carta(23, "Dragon rojo", "equipo", 222, 502, 1000);
        let c4 = new carta(24, "Dragon celeste", "diplomacia", 1800, 1500, 1000);
        let c5 = new carta(25, "Dragon morado", "guerrero", 2800, 2500, 1000);
        let c6 = new carta(26, "Dragon negro", "magia", 3800, 3500, 1000);
        let c7 = new carta(27, "Dragon rosado", "equipo", 4800, 4500, 1000);
        let c8 = new carta(28, "Dragon gris", "diplomacia", 5800, 5500, 1000);
        let c9 = new carta(29, "Dragon escarlata", "guerrero", 6800, 6500, 1000);
        
        // Crear el array con las cartas y agregarlas
        let cartasTotales = [];
        cartasTotales.push(a0);
        cartasTotales.push(a1);
        cartasTotales.push(a2);
        cartasTotales.push(a3);
        cartasTotales.push(a4);
        cartasTotales.push(a5);
        cartasTotales.push(a6);
        cartasTotales.push(a7);
        cartasTotales.push(a8);
        cartasTotales.push(a9);
        cartasTotales.push(b0);
        cartasTotales.push(b1);
        cartasTotales.push(b2);
        cartasTotales.push(b3);
        cartasTotales.push(b4);
        cartasTotales.push(b5);
        cartasTotales.push(b6);
        cartasTotales.push(b7);
        cartasTotales.push(b8);
        cartasTotales.push(b9);
        cartasTotales.push(c0);
        cartasTotales.push(c1);
        cartasTotales.push(c2);
        cartasTotales.push(c3);
        cartasTotales.push(c4);
        cartasTotales.push(c5);
        cartasTotales.push(c6);
        cartasTotales.push(c7);
        cartasTotales.push(c8);
        cartasTotales.push(c9);
     
        return cartasTotales;
    }

    // Crea el deck del jugador
    crearDeck(cartasTotales)
    {
        // Asigna el deck manualmente -- al menos deben existir 5 guerreros
        // console.log('xd------------------------------------------------------');
        let deck = [];
        return deck;
    }  

    // Imprime el deck del jugador
    imprimirDeck()
    {
        console.log("\n\nImpresión del deck de "+this.id);
        let i = 0;

        this.deck.forEach(card => {
            console.log(i);
            card.info();
            i++;
        });

    }

    // Selecciona criterio de ronda
    seleccionarCriterio()
    {
        let criterio = 0;
        return criterio;
    }

    // Arma una jugada de ronda con sus cartas, y retorna una lista con las cartas jugadas en esa ronda
    armarJugada()
    {
        let jugada = [];
    }

    // Retorna el deck con la carta eliminada
    retirarCarta(id, cartasTotales)
    {
        cartasTotales.forEach((card,i) => {
            if (card.getId() == id) 
            {
                // Elimino la carta del deck
                cartasTotales.splice(i, card);
            }
        });

        return cartasTotales;
    }

    // Cambia el valor de turno, que muestra si va primero o no
    setPrimero(change)
    {
        this.primero = change;
    }

    // Get id
    getId()
    {
        return this.id;
    }

    // Get primero
    getPrimero()
    {
        return this.primero;
    }

    // Get deck
    getDeck()
    {
        return this.deck;
    }

    // Get jugada
    getJugada()
    {
        return this.jugada;
    }

}

module.exports = player;
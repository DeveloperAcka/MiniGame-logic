using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    abstract class player
    {
        protected String id;
        protected bool primero;
        protected List<carta> cartasTotales= new List<carta>();
        protected List<carta> deck = new List<carta>();
        protected List<carta> jugada = new List<carta>();

        //constructor
        public player()
        {
            cartasTotales = importarCartas();
            deck = crearDeck(cartasTotales);
        }

        //cargar todas las cartas
        public List<carta> importarCartas()
        {
            //importa la cartas manualmente
            carta a0 = new carta(10, "Bruja verde", "magia", 450, 580, 1000);
            carta a1 = new carta(1, "Bruja blanca", "guerrero", 800, 500, 1000);
            carta a2 = new carta(2, "Bruja azul", "magia", 700, 400, 3000);
            carta a3 = new carta(3, "Bruja roja", "equipo", 200, 500, 5000);
            carta a4 = new carta(4, "Bruja celeste", "diplomacia", 600, 400, 1000);
            carta a5 = new carta(5, "Bruja morada", "guerrero", 900, 200, 5000);
            carta a6 = new carta(6, "Bruja negra", "magia", 50, 5000, 1000);
            carta a7 = new carta(7, "Bruja rosada", "equipo", 150, 4800, 1000);
            carta a8 = new carta(8, "Bruja gris", "diplomacia", 300, 500, 1000);
            carta a9 = new carta(9, "Bruja escarlata", "guerrero", 850, 510, 1000);
            carta b0 = new carta(20, "Duende verde", "diplomacia", 478, 525, 1000);
            carta b1 = new carta(11, "Duende blanco", "equipo", 125, 8000, 1000);
            carta b2 = new carta(12, "Duende azul", "diplomacia", 200, 5000, 1000);
            carta b3 = new carta(13, "Duende rojo", "guerrero", 1250, 50, 1000);
            carta b4 = new carta(14, "Duende celeste", "magia", 80, 50, 1000);
            carta b5 = new carta(15, "Duende morado", "equipo", 8, 5, 1000);
            carta b6 = new carta(16, "Duende negro", "diplomacia", 8000, 5000, 1000);
            carta b7 = new carta(17, "Duende rosado", "guerrero", 777, 555, 1000);
            carta b8 = new carta(18, "Duende gris", "magia", 888, 111, 1000);
            carta b9 = new carta(19, "Duende escarlata", "equipo", 800, 147, 1000);
            carta c0 = new carta(30, "Dragon verde", "magia", 7800, 7500, 1000);
            carta c1 = new carta(21, "Dragon blanco", "guerrero", 278, 5000, 1000);
            carta c2 = new carta(22, "Dragon azul", "magia", 8000, 50, 1000);
            carta c3 = new carta(23, "Dragon rojo", "equipo", 222, 502, 1000);
            carta c4 = new carta(24, "Dragon celeste", "diplomacia", 1800, 1500, 1000);
            carta c5 = new carta(25, "Dragon morado", "guerrero", 2800, 2500, 1000);
            carta c6 = new carta(26, "Dragon negro", "magia", 3800, 3500, 1000);
            carta c7 = new carta(27, "Dragon rosado", "equipo", 4800, 4500, 1000);
            carta c8 = new carta(28, "Dragon gris", "diplomacia", 5800, 5500, 1000);
            carta c9 = new carta(29, "Dragon escarlata", "guerrero", 6800, 6500, 1000);
            

            //crear el array con las cartas y agregarlas
            List<carta> cartasTotales = new List<carta>();
            cartasTotales.Add(a0);
            cartasTotales.Add(a1);
            cartasTotales.Add(a2);
            cartasTotales.Add(a3);
            cartasTotales.Add(a4);
            cartasTotales.Add(a5);
            cartasTotales.Add(a6);
            cartasTotales.Add(a7);
            cartasTotales.Add(a8);
            cartasTotales.Add(a9);
            cartasTotales.Add(b0);
            cartasTotales.Add(b1);
            cartasTotales.Add(b2);
            cartasTotales.Add(b3);
            cartasTotales.Add(b4);
            cartasTotales.Add(b5);
            cartasTotales.Add(b6);
            cartasTotales.Add(b7);
            cartasTotales.Add(b8);
            cartasTotales.Add(b9);
            cartasTotales.Add(c0);
            cartasTotales.Add(c1);
            cartasTotales.Add(c2);
            cartasTotales.Add(c3);
            cartasTotales.Add(c4);
            cartasTotales.Add(c5);
            cartasTotales.Add(c6);
            cartasTotales.Add(c7);
            cartasTotales.Add(c8);
            cartasTotales.Add(c9);
         
            return cartasTotales;
        }

        //crea el deck del jugador
        public virtual List<carta> crearDeck(List<carta> cartasTotales)
        {
            //asigna el deck manualmente -- al menos deben existir 5 guerreros
            List<carta> deck = new List<carta>();
            return deck;
        }  

        //imprime el deck del jugador
        public void imprimirDeck()
        {
            Console.WriteLine("\n\nImpresión del deck de "+id);
            int i = 0;
            foreach(carta card in this.deck)
            {
                Console.WriteLine(i);
                card.info();
               
                i = i + 1;
            }

        }

        //selecciona criterio de ronda
        public virtual int seleccionarCriterio()
        {
            int criterio = 0;
            return criterio;
        }

        //arma una jugada de ronda con sus cartas, y retorna una lista con las cartas jugadas en esa ronda
        public virtual void armarJugada()
        {
            List<carta> jugada = new List<carta>();
        }

        //retorna el deck con la carta eliminada
        public List<carta> retirarCarta(int id, List<carta> cartasTotales)
        {
            foreach(carta card in cartasTotales)
            {
                if(card.getId() == id)
                {
                    //elimino la carta del deck
                    cartasTotales.Remove(card);
                }
            }
            return cartasTotales;
        }

        //cambia el valor de turno, que muestra si va primero o no
        public void setPrimero(bool change)
        {
            this.primero = change;
        }

        //get id
        public String getId()
        {
            return this.id;
        }

        //get primero
        public bool getPrimero()
        {
            return this.primero;
        }

        //get deck
        public List<carta> getDeck()
        {
            return this.deck;
        }

        //get jugada
        public List<carta> getJugada()
        {
            return this.jugada;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    class carta
    {

        //declaracion de parametros de la carta
        private int id;
        private String nombre;
        private String tipo;
        private int ataque;
        private int defensa;
        private int poderMinado;

        //constructor
        public carta(int id, String nombre, String tipo, int ataque, int defensa, int poderMinado)
        {
            this.id = id;
            this.nombre = nombre;
            this.tipo = tipo;
            this.ataque = ataque;
            this.defensa = defensa;
            this.poderMinado = poderMinado;
        }

        //imprimir info general de la carta()
        public void info()
        {
            Console.WriteLine(this.nombre + " " + this.tipo + " " + this.ataque + " " + " " + this.defensa + " " + this.poderMinado);
        }

        //get del id
        public int getId()
        {
            return this.id;
        }

        //get del campo nombre
        public String getNombre()
        {
            return this.nombre;
        }

        //get del campo tipo
        public String getTipo()
        {
            return this.tipo;
        }

        //get del campo ataque
        public int getAtaque()
        {
            return this.ataque;
        }

        //get del campo defensa
        public int getDefensa()
        {
            return this.defensa;
        }

        //get del campo poder de minado
        public int getPoderMinado()
        {
            return this.poderMinado;
        }

        //set ataque
        public void setAtaque(int ataque)
        {
            this.ataque = ataque;
        }

        //set defensa
        public void setDefensa(int defensa)
        {
            this.defensa = defensa;
        }

    }
}

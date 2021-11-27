
class carta
{   
    // Constructor
    constructor(id, nombre, tipo, ataque, defensa, poderMinado)
    {
        this.id = id;
        this.nombre = nombre;
        this.tipo = tipo;
        this.ataque = ataque;
        this.defensa = defensa;
        this.poderMinado = poderMinado;
    }

    // Imprimir info general de la carta
    info()
    {
        console.log(this.nombre + " " + this.tipo + " " + this.ataque + " " + " " + this.defensa + " " + this.poderMinado);
    }

    // Get del id
    getId()
    {
        return this.id;
    }

    // Get del campo nombre
    getNombre()
    {
        return this.nombre;
    }

    // Get del campo tipo
    getTipo()
    {
        return this.tipo;
    }

    // Get del campo ataque
    getAtaque()
    {
        return this.ataque;
    }

    // Get del campo defensa
    getDefensa()
    {
        return this.defensa;
    }

    // Get del campo poder de minado
    getPoderMinado()
    {
        return this.poderMinado;
    }

    // Set ataque
    setAtaque(ataque)
    {
        this.ataque = ataque;
    }

    // Set defensa
    setDefensa(defensa)
    {
        this.defensa = defensa;
    }
}

module.exports = carta;


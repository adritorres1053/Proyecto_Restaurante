namespace Proyecto_Restaurante;
 
using System; 


public class Plato
{
    private string codigo;
    private string nombre;
    private string descripcion;
    private decimal precio;

    public Plato()
    { }

    public Plato(string codigo, string nombre, string descripcion, decimal precio)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.descripcion = descripcion;

        if (precio <= 0)
        {
            Console.WriteLine(" El precio ingresado no es válido. Se asignará un valor por defecto de $1.");
            this.precio = 1;
        }
        else
        {
            this.precio = precio;
        }
    }

    public string Codigo
    {
        get { return this.codigo; }
        set { this.codigo = value; }
    }

    public string Nombre
    {
        get { return this.nombre; }
        set { this.nombre = value; }
    }

    public string Descripcion
    {
        get { return this.descripcion; }
        set { this.descripcion = value; }
    }

    public decimal Precio
    {
        get { return this.precio; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine(" Error: el precio debe ser mayor a 0. Se mantendrá el valor anterior.");
            }
            else
            {
                this.precio = value;
            }
        }
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("PLATO");
        Console.WriteLine("Código: " + codigo);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Descripción: " + descripcion);
        Console.WriteLine("Precio: $" + precio);
        Console.WriteLine("----------------------------------");
    }
}

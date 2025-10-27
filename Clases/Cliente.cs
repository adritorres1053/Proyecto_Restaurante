namespace Proyecto_Restaurante;

using Listas; 
using System; 

public class Cliente
{
    private string cedula;
    private string nombre;
    private string celular;
    private string direccion;
    private string email;

    private ListaEnlazada<Pedido> pedidos;

    public Cliente()
    {
        pedidos = new ListaEnlazada<Pedido>();
    }

    public Cliente(string cedula, string nombre, string celular, string direccion, string email)
    {
        this.cedula = cedula;
        this.nombre = nombre;
        this.celular = celular;
        this.direccion = direccion;
        this.email = email;
        pedidos = new ListaEnlazada<Pedido>();
    }

    public string Cedula
    {
        get { return this.cedula; }
    }

    public string Nombre
    {
        get { return this.nombre; }
        set { this.nombre = value; }
    }

    public string Celular
    {
        get { return this.celular; }
        set { this.celular = value; }
    }

    public string Direccion
    {
        get { return this.direccion; }
        set { this.direccion = value; }
    }

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    public ListaEnlazada<Pedido> Pedidos
    {
        get { return this.pedidos; }
    }

    public void MostrarInformacion()
    {
        Console.WriteLine(" CLIENTE");
        Console.WriteLine("Cédula: " + cedula);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Celular: " + celular);
        Console.WriteLine("Dirección: " + direccion);
        Console.WriteLine("Email: " + email);
        Console.WriteLine("-----------------------------------");
    }
}

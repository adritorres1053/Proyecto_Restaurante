namespace Proyecto_Restaurante;

using Listas;
using System;

public class Restaurante
{
    private string nit;
    private string nombre;
    private string dueno;
    private string celular;
    private string direccion;

    // Estructuras del restaurante
    private ListaEnlazada<Cliente> clientes;
    private ListaEnlazada<Plato> platos;
    private Cola<Pedido> colaPedidos;
    private Pila<Pedido> historialPedidos; 

    public Restaurante(string nit, string nombre, string dueno, string celular, string direccion)
    {
        this.nit = nit;
        this.nombre = nombre;
        this.dueno = dueno;
        this.celular = celular;
        this.direccion = direccion;

        clientes = new ListaEnlazada<Cliente>();
        platos = new ListaEnlazada<Plato>();
        colaPedidos = new Cola<Pedido>();
        historialPedidos = new Pila<Pedido>();
    }

    public string Nit
    {
        get { return this.nit; }
    }

    public string Nombre
    {
        get { return this.nombre; }
        set { this.nombre = value; }
    }

    public string Dueno
    {
        get { return this.dueno; }
        set { this.dueno = value; }
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

    public ListaEnlazada<Cliente> Clientes
    {
        get { return this.clientes; }
    }

    public ListaEnlazada<Plato> Platos
    {
        get { return this.platos; }
    }

    public Cola<Pedido> ColaPedidos
    {
        get { return this.colaPedidos; }
    }

    public Pila<Pedido> HistorialPedidos
    {
        get { return this.historialPedidos; }
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("RESTAURANTE");
        Console.WriteLine("NIT: " + nit);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Dueño: " + dueno);
        Console.WriteLine("Celular: " + celular);
        Console.WriteLine("Dirección: " + direccion);
        Console.WriteLine("----------------------------------");
    }
    public void AgregarCliente(Cliente cliente)
    {
        Nodo<Cliente>? actual = clientes.Cabeza;

        while (actual != null)
        {
            if (actual.Valor.Cedula == cliente.Cedula)
            {
                Console.WriteLine("Ya existe un cliente con esa cédula.");
                return;
            }
            actual = actual.Siguiente;
        }

        clientes.Agregar(cliente);
        Console.WriteLine("Cliente agregado correctamente.");
    }

    public void AgregarPlato(Plato plato)
    {
        Nodo<Plato>? actual = platos.Cabeza;

        while (actual != null)
        {
            if (actual.Valor.Codigo == plato.Codigo)
            {
                Console.WriteLine("Ya existe un plato con ese código.");
                return;
            }
            actual = actual.Siguiente;
        }

        platos.Agregar(plato);
        Console.WriteLine("Plato agregado correctamente al menú.");
    }

    public void CrearPedido(Pedido pedido)
    {
        colaPedidos.Agregar(pedido);
        Console.WriteLine("Pedido agregado a la cola de pedidos pendientes.");
    }

    public void DespacharPedido()
    {
        if (colaPedidos.EstaVacia())
        {
            Console.WriteLine("No hay pedidos pendientes para despachar.");
            return;
        }

        Pedido pedido = colaPedidos.Primero();
        colaPedidos.Eliminar();
        pedido.Estado = "DESPACHADO";
        historialPedidos.AgregarElemento(pedido);

        Console.WriteLine(" Pedido #" + pedido.IdPedido + " despachado correctamente.");
    }

    public void ListarClientes()
    {
        if (clientes.Cabeza == null)
        {
            Console.WriteLine("No hay clientes registrados.");
            return;
        }

        Nodo<Cliente> actual = clientes.Cabeza;
        while (actual != null)
        {
            actual.Valor.MostrarInformacion();
            actual = actual.Siguiente;
        }
    }

    public void ListarPlatos()
    {
        if (platos.Cabeza == null)
        {
            Console.WriteLine("No hay platos registrados en el menú.");
            return;
        }

        Nodo<Plato> actual = platos.Cabeza;
        while (actual != null)
        {
            actual.Valor.MostrarInformacion();
            actual = actual.Siguiente;
        }
    }

    public void MostrarPedidosPendientes()
    {
        if (colaPedidos.EstaVacia())
        {
            Console.WriteLine("No hay pedidos pendientes.");
            return;
        }

        Console.WriteLine("Pedidos pendientes:");
        colaPedidos.Imprimir();
    }


    public void MostrarHistorial()
    {
        Console.WriteLine("Últimos pedidos despachados:");
        historialPedidos.ImprimirPila();
    }
}

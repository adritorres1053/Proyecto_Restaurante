namespace Proyecto_Restaurante;

using Listas;

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
    private Pila<Pedido> historialPedidos; // para ver los últimos despachados

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

    
    // Métodos funcionales del restaurante
    
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

    // Agregar cliente
    public void AgregarCliente(Cliente cliente)
    {
        if (clientes.Buscar(c => c.Cedula == cliente.Cedula) != null)
        {
            Console.WriteLine("Ya existe un cliente con esa cédula.");
            return;
        }

        clientes.Agregar(cliente);
        Console.WriteLine("Cliente agregado correctamente.");
    }

    //  Agregar plato al menú
    public void AgregarPlato(Plato plato)
    {
        if (platos.Buscar(p => p.Codigo == plato.Codigo) != null)
        {
            Console.WriteLine("Ya existe un plato con ese código.");
            return;
        }

        platos.Agregar(plato);
        Console.WriteLine(" Plato agregado correctamente al menú.");
    }

    //  Crear pedido
    public void CrearPedido(Pedido pedido)
    {
        colaPedidos.Agregar(pedido);
        Console.WriteLine(" Pedido agregado a la cola de pedidos pendientes.");
    }

    //  Despachar pedido 
    public void DespacharPedido()
    {
        if (colaPedidos.EstaVacia())
        {
            Console.WriteLine(" No hay pedidos pendientes para despachar.");
            return;
        }

        Pedido pedido = colaPedidos.Primero();
        colaPedidos.Eliminar();
        pedido.Estado = "DESPACHADO";

        historialPedidos.AgregarElemento(pedido);

        Console.WriteLine("🚚 Pedido #" + pedido.IdPedido + " despachado correctamente.");
    }

    // Mostrar clientes
    public void ListarClientes()
    {
        if (clientes.Cabeza == null)
        {
            Console.WriteLine(" No hay clientes registrados.");
            return;
        }

        Nodo<Cliente> actual = clientes.Cabeza;
        while (actual != null)
        {
            actual.Valor.MostrarInformacion();
            actual = actual.Siguiente;
        }
    }

    // Mostrar menú (platos)
    public void ListarPlatos()
    {
        if (platos.Cabeza == null)
        {
            Console.WriteLine(" No hay platos registrados en el menú.");
            return;
        }

        Nodo<Plato> actual = platos.Cabeza;
        while (actual != null)
        {
            actual.Valor.MostrarInformacion();
            actual = actual.Siguiente;
        }
    }

    //  Mostrar pedidos pendientes
    public void MostrarPedidosPendientes()
    {
        if (colaPedidos.EstaVacia())
        {
            Console.WriteLine("No hay pedidos pendientes.");
            return;
        }

        Console.WriteLine(" Pedidos pendientes:");
        colaPedidos.Imprimir();
    }

    // Mostrar historial de pedidos (últimos despachados)
    public void MostrarHistorial()
    {
        Console.WriteLine("📦 Últimos pedidos despachados:");
        historialPedidos.ImprimirPila();
    }
}


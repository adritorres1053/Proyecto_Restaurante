using System;
using Listas;

namespace Proyecto_Restaurante;
public class Restaurante
{
    public int Nit { get; set; }
    public string Nombre { get; set; }
    public string Dueno { get; set; }
    public string Celular { get; set; }
    public string Direccion { get; set; }

    private ListaEnlazada<Cliente> clientes;
    private ListaEnlazada<Plato> platos;
    private ListaEnlazada<Pedido> pedidos;
    private Cola<Pedido> PedidosPendientes;
    private Pila<PlatoPedido> HistorialPlatos;

    private int idPedido = 1;
    private decimal ventasDelDia = 0;
    private DateTime fechaUltimaVenta = DateTime.Now.Date;

    public Restaurante(int nit, string nombre, string dueno, string celular, string direccion)
    {
        Nit = nit;
        Nombre = nombre;
        Dueno = dueno;
        Celular = celular;
        Direccion = direccion;

        clientes = new ListaEnlazada<Cliente>();
        platos = new ListaEnlazada<Plato>();
        pedidos = new ListaEnlazada<Pedido>();
        PedidosPendientes = new Cola<Pedido>();
        HistorialPlatos = new Pila<PlatoPedido>();
    
    }

    
    //--------------- CLIENTES ------------
    public Cliente BuscarClientePorCedula(string cedula)
    {
        Nodo<Cliente> actual = clientes.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Cedula == cedula)
                return actual.Valor;
            actual = actual.Siguiente;
        }
        return null;
    }

    public Cliente CrearCliente(string cedula, string nombre, string celular, string email)
    {
        if (celular.Length != 10)

        {
            Console.WriteLine("El número de celular debe tener 10 dígitos.");
            return null;
        }

        if (BuscarClientePorCedula(cedula) != null)
        {
            Console.WriteLine("Ya existe un cliente con esa cédula.");
            return null;
        }

        var cliente = new Cliente(cedula, nombre, celular, email);
        clientes.Agregar(cliente);
        return cliente;
    }

    public bool EditarCliente(string cedula, string nuevoNombre, string nuevoCelular, string nuevoEmail)
    {
        var cliente = BuscarClientePorCedula(cedula);
        if (cliente == null)
            return false;

        if (!string.IsNullOrWhiteSpace(nuevoNombre))
            cliente.Nombre = nuevoNombre;

        if (!string.IsNullOrWhiteSpace(nuevoCelular))
        {
        if (nuevoCelular.Length != 10)
            {
                Console.WriteLine("El número de celular debe tener 10 dígitos.");
            return false;
            }
            cliente.Celular = nuevoCelular;
        }


        if (!string.IsNullOrWhiteSpace(nuevoEmail))
            cliente.Email = nuevoEmail;
    
        return true;
    }
    public bool EliminarCliente(string cedula)
    {
        Nodo<Cliente> actual = clientes.Cabeza;
        Nodo<Cliente> anterior = null;

        while (actual != null)
        {
            if (actual.Valor.Cedula == cedula)
            {
                if (anterior == null)
                    clientes.EliminarPosicion(0);
                else
                    anterior.Siguiente = actual.Siguiente;
                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        return false;
    }

    public void ListarClientes()
    {
        Nodo<Cliente> actual = clientes.Cabeza;
        if (actual == null)
        {
            Console.WriteLine("No hay clientes registrados.");
            return;
        }

        while (actual != null)
        {
            Console.WriteLine(actual.Valor.ToString());
            actual = actual.Siguiente;
        }
    }


    //--------- PLATOS -------------

    public Plato BuscarPlatoPorCodigo(int codigo)
    {
        Nodo<Plato> actual = platos.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.Codigo == codigo)
                return actual.Valor;
            actual = actual.Siguiente;
        }
        return null;
    }
    public Plato CrearPlato(int codigo, string nombre, string descripcion, decimal precio)
    {
        var existente = BuscarPlatoPorCodigo(codigo);
        if (existente != null)
        {
            Console.WriteLine("Ya existe un plato con ese código.");
            return null;
        }

        if (precio <= 0)
        {
            Console.WriteLine("El precio debe ser mayor que cero.");
            return null;
        }

        var plato = new Plato(codigo, nombre, descripcion, precio);
        platos.Agregar(plato);
        return plato;
    }
    public bool EditarPlato(int codigo, string nuevoNombre, string nuevaDescripcion, decimal nuevoPrecio)
    {
        var plato = BuscarPlatoPorCodigo(codigo);
        if (plato == null)
            return false;

        if (!string.IsNullOrWhiteSpace(nuevoNombre))
            plato.Nombre = nuevoNombre;

        if (!string.IsNullOrWhiteSpace(nuevaDescripcion))
            plato.Descripcion = nuevaDescripcion;

        if (nuevoPrecio > 0)
            plato.Precio = nuevoPrecio;

        return true;
    }

    public bool EliminarPlato(int codigo)
    {
        Nodo<Plato> actual = platos.Cabeza;
        Nodo<Plato> anterior = null;

        while (actual != null)
        {
            if (actual.Valor.Codigo == codigo)
            {
                if (anterior == null)
                    platos.EliminarPosicion(0);
                else
                    anterior.Siguiente = actual.Siguiente;
                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        return false;
    }
    public void ListarPlatos()
    {
        Nodo<Plato> actual = platos.Cabeza;
        if (actual == null)
        {
            Console.WriteLine("No hay platos registrados.");
            return;
        }

        while (actual != null)
        {
            Console.WriteLine(actual.Valor.ToString());
            actual = actual.Siguiente;
        }
    }


    //------------- PEDIDOS --------------

    public Pedido BuscarPedidoPorId(int idPedido)
    {
        Nodo<Pedido> actual = pedidos.Cabeza;
        while (actual != null)
        {
            if (actual.Valor.IdPedido == idPedido)
                return actual.Valor;
            actual = actual.Siguiente;
        }
        return null;
    }

    public Pedido CrearPedido(string cedulaCliente, ListaEnlazada<PlatoPedido> listaPlatos)
    {
        var cliente = BuscarClientePorCedula(cedulaCliente);
        if (cliente == null)
        {
            Console.WriteLine("El cliente no existe.");
            return null;
        }

        decimal total = 0;
        Nodo<PlatoPedido> actual = listaPlatos.Cabeza;
        while (actual != null)
        {
            total += actual.Valor.Cantidad * actual.Valor.PrecioUnitario;
            actual = actual.Siguiente;
        }

        var pedido = new Pedido(idPedido++, int.Parse(cedulaCliente), total, DateTime.Now, "PENDIENTE", listaPlatos);
        Console.WriteLine($"Pedido creado correctamente. Total: ${total}");

        pedidos.Agregar(pedido);
        PedidosPendientes.Agregar(pedido);
        return pedido;
    }

    public bool EditarPedido(int idPedido, string nuevoEstado)
    {
        var pedido = BuscarPedidoPorId(idPedido);
        if (pedido == null)
            return false;

        if (!string.IsNullOrWhiteSpace(nuevoEstado))
            pedido.Estado = nuevoEstado;

        return true;
    }

    public bool EliminarPedido(int idPedido)
    {
        Nodo<Pedido> actual = pedidos.Cabeza;
        Nodo<Pedido> anterior = null;

        while (actual != null)
        {
            if (actual.Valor.IdPedido == idPedido)
            {
                if (anterior == null)
                    pedidos.EliminarPosicion(0);
                else
                    anterior.Siguiente = actual.Siguiente;
                return true;
            }
            anterior = actual;
            actual = actual.Siguiente;
        }
        return false;
    }

    public Pedido DespacharPedido()
    {
        if (PedidosPendientes.EstaVacia())
        {
            Console.WriteLine("No hay pedidos pendientes.");
            return null;
        }

        Pedido pedido = PedidosPendientes.Primero();
        PedidosPendientes.Eliminar();

        pedido.Estado = "DESPACHADO";

        if (DateTime.Now.Date != fechaUltimaVenta)
        {
            ventasDelDia = 0;
            fechaUltimaVenta = DateTime.Now.Date;
        }
        ventasDelDia += pedido.Total;

        Nodo<PlatoPedido> actual = pedido.ListaPlatos.Cabeza;
        while (actual != null)
        {
            HistorialPlatos.AgregarElemento(actual.Valor);
            actual = actual.Siguiente;
        }

        return pedido;
    }
    public void ListarPedidosPendientes()
    {
        Console.WriteLine("--- PEDIDOS PENDIENTES ---");
        PedidosPendientes.Imprimir();
    }

    public void MostrarHistorial()
    {
        Console.WriteLine("Historial de platos servidos:");
        HistorialPlatos.ImprimirPila();
    }

    //------------- VENTAS DEL DIA --------------
    public decimal ObtenerVentasDelDia()
    {
        if (DateTime.Now.Date != fechaUltimaVenta)
        {
            ventasDelDia = 0;
            fechaUltimaVenta = DateTime.Now.Date;
        }
        return ventasDelDia;
    }

    public void MostrarResumenRestaurante()
{
    Console.WriteLine("================================");
    Console.WriteLine("Resumen del restaurante:");
    Console.WriteLine($"Nombre: {Nombre}");
    Console.WriteLine($"Dueño: {Dueno}");
    Console.WriteLine($"Dirección: {Direccion}");
    Console.WriteLine($"Teléfono: {Celular}");

    int totalClientes = clientes != null ? clientes.ContarElementos() : 0;
    int totalPlatos = platos != null ? platos.ContarElementos() : 0;
    int totalPedidos = pedidos != null ? pedidos.ContarElementos() : 0;
    int totalPendientes = PedidosPendientes != null ? PedidosPendientes.ContarElementos() : 0;
    decimal totalVentas = ObtenerVentasDelDia();

    Console.WriteLine($"Clientes registrados: {totalClientes}");
    Console.WriteLine($"Platos registrados: {totalPlatos}");
    Console.WriteLine($"Pedidos totales: {totalPedidos}");
    Console.WriteLine($"Pedidos pendientes: {totalPendientes}");
    Console.WriteLine($"Ventas del día: ${totalVentas}");
    Console.WriteLine("================================");
}


}
    

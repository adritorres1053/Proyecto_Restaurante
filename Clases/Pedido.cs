namespace Proyecto_Restaurante;

using Listas; 
using System; 

public class Pedido
{
    private static int contador = 1; 
    private int idPedido;
    private string cedulaCliente;
    private ListaEnlazada<PlatoPedido> platos; 
    private decimal total;
    private DateTime fechaHora;
    private string estado; 

    public Pedido(string cedulaCliente)
    {
        this.idPedido = contador++;
        this.cedulaCliente = cedulaCliente;
        this.platos = new ListaEnlazada<PlatoPedido>();
        this.total = 0;
        this.fechaHora = DateTime.Now;
        this.estado = "PENDIENTE";
    }

    public int IdPedido
    {
        get { return this.idPedido; }
    }

    public string CedulaCliente
    {
        get { return this.cedulaCliente; }
    }

    public decimal Total
    {
        get { return this.total; }
    }

    public string Estado
    {
        get { return this.estado; }
        set { this.estado = value; }
    }

    public DateTime FechaHora
    {
        get { return this.fechaHora; }
    }

    public ListaEnlazada<PlatoPedido> Platos
    {
        get { return this.platos; }
    }

    public void AgregarPlato(PlatoPedido plato)
    {
        if (plato.Cantidad <= 0)
        {
            Console.WriteLine("La cantidad debe ser mayor que cero.");
            return;
        }

        this.platos.Agregar(plato);
        Console.WriteLine("Plato agregado al pedido.");
    }

    
    public void CalcularTotal()
    {
        decimal suma = 0;
        Nodo<PlatoPedido> actual = this.platos.Cabeza;

        while (actual != null)
        {
            suma += actual.Valor.PrecioUnitario * actual.Valor.Cantidad;
            actual = actual.Siguiente;
        }

        this.total = suma;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("PEDIDO #" + idPedido);
        Console.WriteLine("Cliente (Cédula): " + cedulaCliente);
        Console.WriteLine("Fecha y hora: " + fechaHora);
        Console.WriteLine("Estado: " + estado);
        Console.WriteLine("Platos incluidos:");
        
        if (platos.Cabeza == null)
        {
            Console.WriteLine(" No hay platos en este pedido.");
        }
        else
        {
            Nodo<PlatoPedido> actual = platos.Cabeza;
            while (actual != null)
            {
                actual.Valor.MostrarInformacion();
                actual = actual.Siguiente;
            }
        }

        Console.WriteLine("Total del pedido: $" + total);
        Console.WriteLine("----------------------------------");
    }
}


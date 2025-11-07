using Listas;

namespace Proyecto_Restaurante;
public class Pedido
{
    public int IdPedido { get; set; }
    public int CedulaCliente { get; set; }
    public decimal Total { get; set; }
    public DateTime Fecha { get; set; }
    public string Estado { get; set; }

    public ListaEnlazada<PlatoPedido> ListaPlatos { get; set; }
    public Pedido(int idpedido, int cedulacliente, decimal total, DateTime fecha, string estado, ListaEnlazada<PlatoPedido> listaplatos)
    {
        IdPedido = idpedido;
        CedulaCliente = cedulacliente;
        Total = total;
        Fecha = fecha;
        Estado = estado;
        ListaPlatos = listaplatos;
    }
    
    public override string ToString() => $"[{IdPedido}] {CedulaCliente}] {Total}] {Estado}";

}



namespace Proyecto_Restaurante;
using System;
public class PlatoPedido
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    public PlatoPedido(int codigo, string nombre, int cantidad, decimal precioUnitario)
    {
        Codigo = codigo;
        Nombre = nombre;
        Cantidad = cantidad;
        PrecioUnitario = precioUnitario;
     }

        public decimal Subtotal()
        {
            return PrecioUnitario * Cantidad;
        }

        public override string ToString()
        {
            return $"{Nombre} (x{Cantidad}) - ${Subtotal()}";
        }
    }

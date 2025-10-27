namespace Proyecto_Restaurante;

using System; 


public class PlatoPedido
{
    private string codigoPlato;
    private int cantidad;
    private decimal precioUnitario;

    public PlatoPedido(string codigoPlato, int cantidad, decimal precioUnitario)
    {
        this.codigoPlato = codigoPlato;
        this.cantidad = cantidad;
        this.precioUnitario = precioUnitario;
    }

    // Propiedad para el código del plato
    public string CodigoPlato
    {
        get { return this.codigoPlato; }
        set { this.codigoPlato = value; }
    }

    // Propiedad para la cantidad
    public int Cantidad
    {
        get { return this.cantidad; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("La cantidad debe ser mayor que cero.");
            }
            else
            {
                this.cantidad = value;
            }
        }
    }

    // Propiedad para el precio unitario
    public decimal PrecioUnitario
    {
        get { return this.precioUnitario; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("El precio unitario debe ser mayor que cero.");
            }
            else
            {
                this.precioUnitario = value;
            }
        }
    }

    
    public void MostrarInformacion()
    {
        Console.WriteLine("  - Código: " + codigoPlato + " | Cantidad: " + cantidad + " | Precio unitario: $" + precioUnitario);
    }
}

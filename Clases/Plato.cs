namespace Proyecto_Restaurante;
using System;
public class Plato
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }

    public Plato(int codigo, string nombre, string descripcion, decimal precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Descripcion = descripcion;
        Precio = precio;

    }

    public override string ToString() => $"[{Codigo}] {Nombre}] {Descripcion}] {Precio}";
 
}
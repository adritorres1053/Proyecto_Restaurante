namespace Proyecto_Restaurante;
using System;
public class Cliente
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public Cliente(string cedula, string nombre, string celular, string email)
    {
        Cedula = cedula;
        Nombre = nombre;
        Celular = celular;
        Email = email;
    }

    public override string ToString() => $"[{Cedula}] {Nombre}] {Celular}] {Email}";

}   
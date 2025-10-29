﻿using Proyecto_Restaurante;
using Listas;
using System;

class Program
{
    static Restaurante restaurante = null;

    static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("     SISTEMA DE GESTIÓN RESTAURANTE     ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Crear restaurante");
            Console.WriteLine("2. Agregar cliente");
            Console.WriteLine("3. Agregar plato al menú");
            Console.WriteLine("4. Crear pedido");
            Console.WriteLine("5. Despachar pedido");
            Console.WriteLine("6. Listar clientes");
            Console.WriteLine("7. Listar platos del menú");
            Console.WriteLine("8. Mostrar historial de pedidos");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione la opción deseada: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearRestaurante();
                    break;

                case "2":
                   AgregarCliente();
                    break;

                case "3":
                   AgregarPlato();
                    break;

                case "4":
                    CrearPedido();
                    break;

                case "5":
                    restaurante.DespacharPedido();
                    break;

                case "6":
                    restaurante.ListarClientes();
                    break;

                case "7":
                    restaurante.ListarPlatos();
                    break;

                case "8":
                    restaurante.MostrarHistorial();
                    break;

                case "9":
                    salir = true;
                    Console.WriteLine("Saliendo del sistema. ¡Hasta pronto!");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }

            Console.WriteLine(" Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static void CrearRestaurante()
    {
        Console.WriteLine("=== CREAR RESTAURANTE ===");
        Console.Write("NIT: ");
        string nit = Console.ReadLine();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Dueño: ");
        string dueno = Console.ReadLine();

        Console.Write("Celular (10 dígitos): ");
        string celular = Console.ReadLine();

        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        restaurante = new Restaurante(nit, nombre, dueno, celular, direccion);
        Console.WriteLine(" Restaurante creado correctamente.");
    }

    private static void AgregarCliente()
    {
        Console.WriteLine("=== AGREGAR CLIENTE ===");
        Console.Write("Cédula: ");
        string cedula = Console.ReadLine();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Celular: ");
        string celular = Console.ReadLine();

        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Cliente nuevo = new Cliente(cedula, nombre, celular, direccion, email);
        restaurante.AgregarCliente(nuevo);
        Console.WriteLine(" Cliente agregado con éxito.");
    }

    private static void AgregarPlato()
    {
        Console.WriteLine("=== AGREGAR PLATO AL MENÚ ===");
        Console.Write("Código del plato: ");
        string codigo = Console.ReadLine();

        Console.Write("Nombre del plato: ");
        string nombre = Console.ReadLine();

        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine();

        Console.Write("Precio: ");
        decimal.TryParse(Console.ReadLine(), out decimal precio);

        Plato nuevo = new Plato(codigo, nombre, descripcion, precio);
        restaurante.AgregarPlato(nuevo);
        Console.WriteLine("Plato agregado correctamente.");
    }

    private static void CrearPedido()
    {
        Console.WriteLine("=== CREAR PEDIDO ===");
        Console.Write("Ingrese la cédula del cliente: ");
        string cedula = Console.ReadLine();

        Pedido nuevoPedido = new Pedido(cedula);

        string continuar;
        do
        {
            Console.Write("Código del plato: ");
            string codigo = Console.ReadLine();

            Plato platoEncontrado = null;
            Nodo<Plato> nodoPlato = restaurante.Platos.Cabeza;

            while (nodoPlato != null)
            {
                if (nodoPlato.Valor.Codigo == codigo)
                {
                    platoEncontrado = nodoPlato.Valor;
                    break;
                }
                nodoPlato = nodoPlato.Siguiente;
            }

            if (platoEncontrado == null)
            {
                Console.WriteLine(" El plato no existe.");
            }
            else
            {
                Console.Write("Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                PlatoPedido detalle = new PlatoPedido(platoEncontrado.Codigo, cantidad, platoEncontrado.Precio);
                nuevoPedido.AgregarPlato(detalle);
            }

            Console.Write("¿Desea agregar otro plato? (s/n): ");
            continuar = Console.ReadLine().ToLower();

        } while (continuar == "s");

        nuevoPedido.CalcularTotal();
        restaurante.CrearPedido(nuevoPedido);
        Console.WriteLine(" Pedido creado exitosamente.");
    }

    private static bool VerificarRestaurante()
    {
        if (restaurante == null)
        {
            Console.WriteLine("Primero debe crear un restaurante antes de continuar.");
            return false;
        }
        return true;
    }
}

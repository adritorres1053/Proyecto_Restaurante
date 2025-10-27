﻿using Proyecto_Restaurante;
using Listas;

class Program
{
    static void Main()
    {
        Restaurante restaurante = null;
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("     🍽️ SISTEMA DE GESTIÓN RESTAURANTE     ");
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
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("⚠️ Opción inválida. Presione una tecla para continuar...");
                Console.ReadKey();
                continue;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    restaurante = CrearRestaurante();
                    break;

                case 2:
                    if (VerificarRestaurante(restaurante))
                        AgregarCliente(restaurante);
                    break;

                case 3:
                    if (VerificarRestaurante(restaurante))
                        AgregarPlato(restaurante);
                    break;

                case 4:
                    if (VerificarRestaurante(restaurante))
                        CrearPedido(restaurante);
                    break;

                case 5:
                    if (VerificarRestaurante(restaurante))
                        restaurante.DespacharPedido();
                    break;

                case 6:
                    if (VerificarRestaurante(restaurante))
                        restaurante.ListarClientes();
                    break;

                case 7:
                    if (VerificarRestaurante(restaurante))
                        restaurante.ListarPlatos();
                    break;

                case 8:
                    if (VerificarRestaurante(restaurante))
                        restaurante.MostrarHistorial();
                    break;

                case 9:
                    Console.WriteLine("👋 Saliendo del sistema. ¡Hasta pronto!");
                    break;

                default:
                    Console.WriteLine("⚠️ Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

        } while (opcion != 9);
    }

    // -----------------------------------------------
    // MÉTODOS AUXILIARES DEL MENÚ
    // -----------------------------------------------

    static Restaurante CrearRestaurante()
    {
        Console.WriteLine("🏢 CREAR RESTAURANTE");
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

        Restaurante nuevo = new Restaurante(nit, nombre, dueno, celular, direccion);
        Console.WriteLine("✅ Restaurante creado correctamente.");
        return nuevo;
    }

    static void AgregarCliente(Restaurante restaurante)
    {
        Console.WriteLine("👤 AGREGAR CLIENTE");
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
    }

    static void AgregarPlato(Restaurante restaurante)
    {
        Console.WriteLine("🍽️ AGREGAR PLATO AL MENÚ");
        Console.Write("Código del plato: ");
        string codigo = Console.ReadLine();

        Console.Write("Nombre del plato: ");
        string nombre = Console.ReadLine();

        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine();

        Console.Write("Precio: ");
        decimal precio;
        decimal.TryParse(Console.ReadLine(), out precio);

        Plato nuevo = new Plato(codigo, nombre, descripcion, precio);
        restaurante.AgregarPlato(nuevo);
    }

    static void CrearPedido(Restaurante restaurante)
    {
        Console.WriteLine("🧾 CREAR PEDIDO");
        Console.Write("Ingrese la cédula del cliente: ");
        string cedula = Console.ReadLine();

        Pedido nuevoPedido = new Pedido(cedula);

        string continuar;
        do
        {
            Console.Write("Código del plato: ");
            string codigo = Console.ReadLine();

            Plato plato = restaurante.Platos.Buscar(p => p.Codigo == codigo);
            if (plato == null)
            {
                Console.WriteLine("⚠️ El plato no existe.");
            }
            else
            {
                Console.Write("Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                PlatoPedido detalle = new PlatoPedido(plato.Codigo, cantidad, plato.Precio);
                nuevoPedido.AgregarPlato(detalle);
            }

            Console.Write("¿Desea agregar otro plato? (s/n): ");
            continuar = Console.ReadLine().ToLower();

        } while (continuar == "s");

        nuevoPedido.CalcularTotal();
        restaurante.CrearPedido(nuevoPedido);
    }

    static bool VerificarRestaurante(Restaurante restaurante)
    {
        if (restaurante == null)
        {
            Console.WriteLine("⚠️ Primero debe crear un restaurante.");
            return false;
        }
        return true;
    }
}


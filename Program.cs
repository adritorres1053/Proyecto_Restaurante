﻿using System;
using Listas;
using Proyecto_Restaurante;

ListaEnlazada<Restaurante> listaRestaurantes = new ListaEnlazada<Restaurante>();
Restaurante restauranteActual = null;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    MostrarMenuPrincipal();
    int opcion = LeerInt("Seleccione una opción: ");
    Console.WriteLine();

    switch (opcion)
    {
        case 1:
            MenuRestaurantes();
            break;
        case 2:
            if (VerificarRestaurante())
                MenuClientes();
            break;
        case 3:
            if (VerificarRestaurante())
                MenuPlatos();
            break;
        case 4:
            if (VerificarRestaurante())
                MenuPedidos();
            break;
        case 0:
            Salir();
            return;
        default:
            Aviso("Opción no válida.");
            break;
    }
}

// ---------------------- MENÚ PRINCIPAL -----------------------
void MostrarMenuPrincipal()
{
    Console.WriteLine("=====================================");
    Console.WriteLine("   SISTEMA DE GESTIÓN DE RESTAURANTE ");
    Console.WriteLine("=====================================");
    Console.WriteLine($"Restaurante actual: {(restauranteActual == null ? "(ninguno seleccionado)" : restauranteActual.Nombre)}");
    Console.WriteLine("1) Restaurantes");
    Console.WriteLine("2) Clientes");
    Console.WriteLine("3) Platos");
    Console.WriteLine("4) Pedidos");
    Console.WriteLine("0) Salir");
}

// ---------------------- MENÚ DE RESTAURANTES -----------------------
void MenuRestaurantes()
{
    while (true)
    {
        Console.WriteLine("--- MENÚ DE RESTAURANTES ---");
        Console.WriteLine("1) Crear restaurante");
        Console.WriteLine("2) Listar restaurantes");
        Console.WriteLine("3) Seleccionar restaurante");
        Console.WriteLine("4) Editar restaurante");
        Console.WriteLine("5) Eliminar restaurante");
        Console.WriteLine("6) Ver resumen del restaurante");
        Console.WriteLine("0) Volver al menú principal");

        int opcion = LeerInt("Seleccione una opción: ");
        Console.WriteLine();

        switch (opcion)
        {
            case 1:
                CrearRestaurante();
                break;
            case 2:
                ListarRestaurantes();
                break;
            case 3:
                SeleccionarRestaurante();
                break;
            case 4:
                EditarRestaurante();
                break;
            case 5:
                EliminarRestaurante();
                break;
            case 6:
                if (VerificarRestaurante())
                    restauranteActual.MostrarResumenRestaurante();
                break;
            case 0:
                return;
            default:
                Aviso("Opción no válida.");
                break;
        }
    }
}

// ---------------------- FUNCIONES DE RESTAURANTE -----------------------
void CrearRestaurante()
{
    int nit = LeerInt("Ingrese el NIT del restaurante: ");
    Nodo<Restaurante> actual = listaRestaurantes.Cabeza;
    while (actual != null)
    {
        if (actual.Valor.Nit == nit)
        {
            Aviso("Ya existe un restaurante con ese NIT. Intente con otro.");
            return;
        }
        actual = actual.Siguiente;
    }

    string nombre = LeerTextoNoVacio("Nombre: ");
    string dueno = LeerTextoNoVacio("Dueño: ");
    string celular = LeerTextoNoVacio("Celular: ");

    if (celular.Length != 10)
    {
        Aviso("El número de celular debe tener 10 dígitos.");
        return;
    }

    string direccion = LeerTextoNoVacio("Dirección: ");

    Restaurante nuevo = new Restaurante(nit, nombre, dueno, celular, direccion);
    listaRestaurantes.Agregar(nuevo);
    restauranteActual = nuevo;

    Console.WriteLine($"Restaurante '{nombre}' creado correctamente.");
}

void ListarRestaurantes()
{
    Nodo<Restaurante> actual = listaRestaurantes.Cabeza;
    if (actual == null)
    {
        Console.WriteLine("No hay restaurantes registrados.");
        return;
    }

    Console.WriteLine("--- LISTA DE RESTAURANTES ---");
    while (actual != null)
    {
        Console.WriteLine($"[{actual.Valor.Nit}] {actual.Valor.Nombre} - {actual.Valor.Direccion}");
        actual = actual.Siguiente;
    }
}

void SeleccionarRestaurante()
{
    if (listaRestaurantes.Cabeza == null)
    {
        Aviso("No hay restaurantes creados.");
        return;
    }

    int nit = LeerInt("Ingrese el NIT del restaurante a seleccionar: ");
    Nodo<Restaurante> actual = listaRestaurantes.Cabeza;

    while (actual != null)
    {
        if (actual.Valor.Nit == nit)
        {
            restauranteActual = actual.Valor;
            Perfecto($"Restaurante '{restauranteActual.Nombre}' seleccionado correctamente.");
            return;
        }
        actual = actual.Siguiente;
    }

    Aviso("No se encontró un restaurante con ese NIT.");
}

void EditarRestaurante()
{
    if (!VerificarRestaurante()) return;

    Console.WriteLine($"Editando restaurante: {restauranteActual.Nombre}");

    string nuevoNombre = LeerTextoOpcional("Nuevo nombre (Enter para omitir): ");
    string nuevoDueno = LeerTextoOpcional("Nuevo dueño (Enter para omitir): ");
    string nuevaDireccion = LeerTextoOpcional("Nueva dirección (Enter para omitir): ");
    string nuevoCelular = LeerTextoOpcional("Nuevo celular (Enter para omitir): ");

    if (!string.IsNullOrWhiteSpace(nuevoNombre))
        restauranteActual.Nombre = nuevoNombre;
    if (!string.IsNullOrWhiteSpace(nuevoDueno))
        restauranteActual.Dueno = nuevoDueno;
    if (!string.IsNullOrWhiteSpace(nuevaDireccion))
        restauranteActual.Direccion = nuevaDireccion;
    if (!string.IsNullOrWhiteSpace(nuevoCelular))
    {
        if (nuevoCelular.Length != 10)
        {
            Aviso("El número de celular debe tener exactamente 10 dígitos numéricos.");
            return;
        }
        restauranteActual.Celular = nuevoCelular;
    }

    Perfecto("Restaurante actualizado correctamente.");
}

void EliminarRestaurante()
{
    if (listaRestaurantes.Cabeza == null)
    {
        Aviso("No hay restaurantes para eliminar.");
        return;
    }

    int nit = LeerInt("Ingrese el NIT del restaurante a eliminar: ");
    Nodo<Restaurante> actual = listaRestaurantes.Cabeza;
    Nodo<Restaurante> anterior = null;

    while (actual != null)
    {
        if (actual.Valor.Nit == nit)
        {
            if (anterior == null)
                listaRestaurantes.EliminarPosicion(0);
            else
                anterior.Siguiente = actual.Siguiente;

            if (restauranteActual == actual.Valor)
                restauranteActual = null;

            Perfecto("Restaurante eliminado correctamente.");
            return;
        }
        anterior = actual;
        actual = actual.Siguiente;
    }

    Aviso("No se encontró un restaurante con ese NIT.");
}

//-----------MENÚ CLIENTES----------
void MenuClientes()
{
    while (true)
    {
        Console.WriteLine("----- MENÚ CLIENTES -----");
        Console.WriteLine("1) Crear Cliente");
        Console.WriteLine("2) Listar Clientes");
        Console.WriteLine("3) Editar Cliente");
        Console.WriteLine("4) Eliminar Cliente");
        Console.WriteLine("0) Volver");

        int opcion = LeerInt("Seleccione una opción: ");

        switch (opcion)
        {
            case 1:
                string cedula = LeerTextoNoVacio("Cédula: ");
                if (restauranteActual.BuscarClientePorCedula(cedula) != null)
                {
                    Aviso("Ya existe un cliente con esa cédula.");
                    break;
                }
                string nombre = LeerTextoNoVacio("Nombre: ");
                string celular = LeerTextoNoVacio("Celular: ");
                if (celular.Length != 10)
                {
                    Aviso("El número de celular debe tener 10 dígitos.");
                    break;
                }
                string email = LeerTextoNoVacio("Email: ");
                restauranteActual.CrearCliente(cedula, nombre, celular, email);
                Perfecto("Cliente creado correctamente.");
                break;

            case 2:
                restauranteActual.ListarClientes();
                break;

            case 3:
                string cedulaEdit = LeerTextoNoVacio("Cédula del cliente a editar: ");
                string nuevoNombre = LeerTextoOpcional("Nuevo nombre (Enter para omitir): ");
                string nuevoCel = LeerTextoOpcional("Nuevo celular (Enter para omitir): ");
                string nuevoEmail = LeerTextoOpcional("Nuevo email (Enter para omitir): ");
                if (restauranteActual.EditarCliente(cedulaEdit, nuevoNombre, nuevoCel, nuevoEmail))
                    Perfecto("Cliente actualizado correctamente.");
                else
                    Aviso("No se encontró el cliente.");
                break;

            case 4:
                string cedulaEliminar = LeerTextoNoVacio("Cédula del cliente a eliminar: ");
                if (restauranteActual.EliminarCliente(cedulaEliminar))
                    Perfecto("Cliente eliminado.");
                else
                    Aviso("No se encontró el cliente.");
                break;

            case 0:
                return;

            default:
                Aviso("Opción no válida.");
                break;
        }
    }
}

// ------------------ MENÚ PLATOS ------------------
void MenuPlatos()
{
    while (true)
    {
        Console.WriteLine("----- MENÚ DE PLATOS -----");
        Console.WriteLine("1) Crear plato");
        Console.WriteLine("2) Listar platos");
        Console.WriteLine("3) Editar plato");
        Console.WriteLine("4) Eliminar plato");
        Console.WriteLine("0) Volver");

        int opcion = LeerInt("Seleccione una opción: ");

        switch (opcion)
        {
            case 1:
                int codigo = LeerInt("Código del plato: ");
                if (restauranteActual.BuscarPlatoPorCodigo(codigo) != null)
                {
                    Aviso("Ya existe un plato con ese código.");
                    break;
                }
                string nombre = LeerTextoNoVacio("Nombre del plato: ");
                string descripcion = LeerTextoNoVacio("Descripción: ");
                decimal precio = LeerDecimal("Precio: ");
                restauranteActual.CrearPlato(codigo, nombre, descripcion, precio);
                Perfecto("Plato creado correctamente.");
                break;

            case 2:
                restauranteActual.ListarPlatos();
                break;

            case 3:
                int codigoEdit = LeerInt("Código del plato a editar: ");
                string nuevoNombre = LeerTextoOpcional("Nuevo nombre (Enter para omitir): ");
                string nuevaDesc = LeerTextoOpcional("Nueva descripción (Enter para omitir): ");
                decimal nuevoPrecio = LeerDecimal("Nuevo precio (0 para omitir): ");
                if (restauranteActual.EditarPlato(codigoEdit, nuevoNombre, nuevaDesc, nuevoPrecio))
                    Perfecto("Plato actualizado correctamente.");
                else
                    Aviso("No se encontró el plato.");
                break;

            case 4:
                int codigoEliminar = LeerInt("Código del plato a eliminar: ");
                if (restauranteActual.EliminarPlato(codigoEliminar))
                    Perfecto("Plato eliminado.");
                else
                    Aviso("No se encontró el plato.");
                break;

            case 0:
                return;

            default:
                Aviso("Opción no válida.");
                break;
        }
    }
}

// ------------------ MENÚ PEDIDOS ------------------
void MenuPedidos()
{
    while (true)
    {
        Console.WriteLine("----- MENÚ DE PEDIDOS -----");
        Console.WriteLine("1) Crear pedido");
        Console.WriteLine("2) Listar pedidos pendientes");
        Console.WriteLine("3) Despachar pedido");
        Console.WriteLine("4) Ver historial de platos servidos");
        Console.WriteLine("0) Volver");

        int opcion = LeerInt("Seleccione una opción: ");

        switch (opcion)
        {
            case 1:
                string cedula = LeerTextoNoVacio("Cédula del cliente: ");
                Cliente cliente = restauranteActual.BuscarClientePorCedula(cedula);
                if (cliente == null)
                {
                    Aviso("Cliente no encontrado.");
                    break;
                }

                ListaEnlazada<PlatoPedido> lista = new ListaEnlazada<PlatoPedido>();
                while (true)
                {
                    int codigoPlato = LeerInt("Código del plato: ");
                    Plato plato = restauranteActual.BuscarPlatoPorCodigo(codigoPlato);
                    if (plato == null)
                    {
                        Aviso("Plato no encontrado.");
                        continue;
                    }

                    int cantidad = LeerInt("Cantidad: ");
                    lista.Agregar(new PlatoPedido(codigoPlato, plato.Nombre, cantidad, plato.Precio));

                    string continuar = LeerTextoOpcional("¿Agregar otro plato? (s/n): ").ToLower();
                    if (continuar != "s") break;
                }

                restauranteActual.CrearPedido(cedula, lista);
                Perfecto("Pedido creado correctamente.");
                break;

            case 2:
                restauranteActual.ListarPedidosPendientes();
                break;

            case 3:
                restauranteActual.DespacharPedido();
                Perfecto("Pedido despachado correctamente.");
                break;

            case 4:
                restauranteActual.MostrarHistorial();
                break;

            case 0:
                return;

            default:
                Aviso("Opción no válida.");
                break;
        }
    }
}


// ---------------- FUNCIONES AUXILIARES ----------------
bool VerificarRestaurante()
{
    if (restauranteActual == null)
    {
        Aviso("Debe seleccionar o crear un restaurante primero.");
        return false;
    }
    return true;
}

int LeerInt(string texto)
{
    while (true)
    {
        Console.Write(texto);
        string t = Console.ReadLine();
        if (int.TryParse(t, out int n))
            return n;
        Aviso("Ingrese un número válido.");
    }
}

decimal LeerDecimal(string texto)
{
    while (true)
    {
        Console.Write(texto);
        string t = Console.ReadLine();
        if (decimal.TryParse(t, out decimal n))
            return n;
        Aviso("Ingrese un número válido.");
    }
}

string LeerTextoNoVacio(string texto)
{
    while (true)
    {
        Console.Write(texto);
        string s = (Console.ReadLine() ?? "").Trim();
        if (s.Length > 0) return s;
        Aviso("No puede estar vacío.");
    }
}

string LeerTextoOpcional(string texto)
{
    Console.Write(texto);
    return Console.ReadLine() ?? string.Empty;
}

void Aviso(string mensaje) => Console.WriteLine(mensaje);
void Perfecto(string mensaje) => Console.WriteLine(mensaje);
void Salir() => Console.WriteLine("¡Hasta luego!");

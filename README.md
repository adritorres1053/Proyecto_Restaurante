# Proyecto Restaurante
SISTEMA DE GESTIÓN DE RESTAURANTE EN CONSOLA (C#)
Proyecto Final — Estructuras de Datos

Asignatura: Estructuras de Datos
Lenguaje: C# (.NET 6 o superior)
Modalidad: Aplicativo de consola
Repositorio GitHub: (https://github.com/adritorres1053/Proyecto_Restaurante)

OBJETIVO GENERAL

Diseñar e implementar un sistema de gestión para un restaurante, desarrollado como aplicación de consola, que aplique estructuras de datos implementadas desde cero — listas enlazadas, colas y pilas — para administrar la información de restaurantes, clientes, platos y pedidos.

ESTRUCTURAS DE DATOS IMPLEMENTADAS
Estructura	Clase	Uso en el sistema
ListaEnlazada<T>	ListaEnlazada, Nodo	Maneja las colecciones de restaurantes, clientes, platos y pedidos
Cola<T>	Cola	Administra los pedidos pendientes 
Pila<T>	Pila	Guarda el historial de platos servidos

No se usaron colecciones de .NET (List, Queue, Stack, Dictionary, etc.) para la lógica central del sistema.

ESTRUCTURA DEL PROYECTO

Proyecto_Restaurante/
│
├── Listas/
│ ├── ListaEnlazada.cs
│ ├── Nodo.cs
│ ├── Pila.cs
│ └── Cola.cs
│
├── Proyecto_Restaurante/
│ ├── Restaurante.cs
│ ├── Cliente.cs
│ ├── Plato.cs
│ ├── Pedido.cs
│ └── PlatoPedido.cs
│
├── Program.cs
└── README.md

DESCRIPCIÓN FUNCIONAL

El sistema permite realizar la gestión completa de un restaurante desde consola.
Incluye menús navegables y validaciones de datos.

MENÚ PRINCIPAL

Restaurantes

Clientes

Platos

Pedidos

Salir

MÓDULOS DEL SISTEMA
1. RESTAURANTES

Permite crear, editar, listar, seleccionar y eliminar restaurantes.
Cada restaurante tiene su propio conjunto de clientes, platos y pedidos.

Datos:

NIT (único)

Nombre

Dueño

Celular (10 dígitos)

Dirección

2. CLIENTES

Permite registrar, editar, listar y eliminar clientes asociados al restaurante actual.

Datos:

Cédula (única)

Nombre

Celular (10 dígitos)

Email 

3. PLATOS

Permite administrar el menú del restaurante: agregar, editar, listar y eliminar platos.

Datos:

Código (único)

Nombre

Descripción

Precio (decimal > 0)

4. PEDIDOS

Gestión de pedidos de clientes:

Crear pedido con múltiples platos y cantidades.

Encolar pedido (FIFO).

Despachar pedidos (se sacan de la cola y pasan a estado DESPACHADO).

Ver historial de platos servidos (pila).

Consultar ganancias del día.

Reglas clave:

No se pueden despachar pedidos si la cola está vacía.

Al despachar un pedido se registra en el historial (pila).

Las ganancias del día se calculan con los pedidos despachados.

CÁLCULO DE GANANCIAS

El sistema mantiene el total de ventas del día (reinicia automáticamente cada día).
Método: ObtenerVentasDelDia()

ESTRUCTURAS DE VALIDACIÓN

Validación de datos vacíos.

Longitud de celular = 10 dígitos.

Precio > 0.

NIT, cédula y código de plato únicos.


EJEMPLO DE USO BÁSICO

Crear un restaurante.

Agregar clientes y platos.

Tomar un pedido seleccionando los platos del menú.

Ver la lista de pedidos pendientes.

Despachar pedidos.

Consultar el historial y las ganancias del día.

REQUERIMIENTOS TÉCNICOS

Lenguaje: C#
Versión: .NET 6 o superior
Ejecución:
dotnet run
Sistema operativo: Windows 10 o superior (portátil con dotnet SDK).

CUMPLIMIENTO DEL ENUNCIADO
Requisito del PDF	Implementado	Observación
Listas enlazadas, pilas y colas propias	Sí	Sin uso de colecciones de .NET
CRUD de restaurantes, clientes, platos	Sí	Con validaciones
Gestión de pedidos (FIFO)	Sí	Implementado con cola
Historial (LIFO)	Sí	Implementado con pila
Ganancias del día	Sí	Método ObtenerVentasDelDia()
Borrado seguro	Parcial	Puede mejorarse validando pedidos pendientes
Formato de email	Parcial	Puede agregarse regex
Menús navegables	Sí	Retorno entre menús implementado
Código en español	Sí	Cumple RNF-01
PRUEBAS MANUALES RECOMENDADAS

Crear un restaurante nuevo.

Registrar un cliente y verificar validaciones de celular.

Agregar varios platos.

Crear un pedido con varios platos.

Listar pedidos pendientes.

Despachar pedido y revisar historial.

Mostrar resumen del restaurante (ventas, clientes, pedidos).

AUTORES

(Adriana Torres )



REPOSITORIO Y CONTROL DE VERSIONES

Uso de GitHub con commits frecuentes y mensajes descriptivos en español.

using System; 

namespace Listas;

public class Cola<T>
{
    private Nodo<T> cabeza;
    private Nodo<T> cola;
    private int tamano;

    public Cola()
    {
        cabeza = null;
        cola = null;
        tamano = 0;
    }

    public void Agregar(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);
        if (EstaVacia())
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            cola.Siguiente = nuevoNodo;
            cola = nuevoNodo;
        }
        tamano++;
    }

    public void Eliminar()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("La cola está vacía.");
        }
        cabeza = cabeza.Siguiente;
        tamano--;
    }

    public T Primero()
    {
        if (EstaVacia())
        {
            throw new InvalidOperationException("La cola está vacía.");
        }
        return cabeza.Valor;
    }

    public int Tamano()
    {
        return tamano;
    }

    public bool EstaVacia()
    {
        return tamano == 0;
    }

    public void Imprimir()
    {
        if (EstaVacia())
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }

        Nodo<T> actual = cabeza;

        Console.Write("Cola: ");
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
        public int ContarElementos()
    {
    int contador = 0;
    Nodo<T> actual = cabeza;
    while (actual != null)
    {
        contador++;
        actual = actual.Siguiente;
        }
    return contador;
    }

}

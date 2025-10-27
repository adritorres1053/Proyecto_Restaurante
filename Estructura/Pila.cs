using System; // opcional, si usas Console.WriteLine

namespace Listas;

public class Pila<T>
{
    private Nodo<T> cima;
    private int tamano;

    public int Tamano
    {
        get { return this.tamano; }
    }

    public void AgregarElemento(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);

        if (cima == null)
        {
            cima = nuevoNodo;
        }
        else
        {
            nuevoNodo.Siguiente = cima;
            cima = nuevoNodo;
        }
        tamano++;
    }

    public void EliminarElemento()
    {
        if (cima != null)
        {
            tamano--;
            cima = cima.Siguiente;
        }
        else
        {
            Console.WriteLine("La pila está vacía.");
        }
    }

    public void ImprimirPila()
    {
        if (cima == null)
        {
            Console.WriteLine(" La pila está vacía.");
            return;
        }

        Nodo<T> nodoActual = cima;
        while (nodoActual != null)
        {
            Console.WriteLine(nodoActual.Valor + " ");
            nodoActual = nodoActual.Siguiente;
        }
        Console.WriteLine();
    }

    public void ImprimirAlReves()
    {
        if (cima == null)
        {
            Console.WriteLine("La pila está vacía.");
            return;
        }

        Pila<T> pilaAuxiliar = new Pila<T>();

        Nodo<T> actual = cima;
        while (actual != null)
        {
            pilaAuxiliar.AgregarElemento(actual.Valor);
            actual = actual.Siguiente;
        }

        pilaAuxiliar.ImprimirPila();
    }
}

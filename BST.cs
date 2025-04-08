public class BST
{
    public Nodo Raiz;

    public void Insertar(int valor)
    {
        Raiz = Insertar(Raiz, valor);
    }

    private Nodo Insertar(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izq = Insertar(nodo.Izq, valor);
        else if (valor > nodo.Valor)
            nodo.Derecha = Insertar(nodo.Derecha, valor);

        return nodo;
    }

    public bool Buscar(int valor)
    {
        return Buscar(Raiz, valor);
    }

    private bool Buscar(Nodo nodo, int valor)
    {
        if (nodo == null)
            return false;
        if (nodo.Valor == valor)
            return true;

        return valor < nodo.Valor ? Buscar(nodo.Izq, valor) : Buscar(nodo.Derecha, valor);
    }

    public void Eliminar(int valor)
    {
        Raiz = Eliminar(Raiz, valor);
    }

    private Nodo Eliminar(Nodo nodo, int valor)
    {
        if (nodo == null)
            return null;

        if (valor < nodo.Valor)
            nodo.Izq = Eliminar(nodo.Izq, valor);
        else if (valor > nodo.Valor)
            nodo.Derecha = Eliminar(nodo.Derecha, valor);
        else
        {
            // Caso con un hijo o sin hijos
            if (nodo.Izq == null)
                return nodo.Derecha;
            if (nodo.Derecha == null)
                return nodo.Izq;

            // Caso con dos hijos
            Nodo minimo = ObtenerMinimo(nodo.Derecha);
            nodo.Valor = minimo.Valor;
            nodo.Derecha = Eliminar(nodo.Derecha, minimo.Valor);
        }

        return nodo;
    }

    private Nodo ObtenerMinimo(Nodo nodo)
    {
        while (nodo.Izq != null)
            nodo = nodo.Izq;
        return nodo;
    }
}

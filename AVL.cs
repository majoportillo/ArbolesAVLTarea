public class AVL
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
        else
            return nodo; // Duplicados no permitidos

        // Actualizar altura
        nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.Izq), ObtenerAltura(nodo.Derecha));

        // Verificar balance y rotar si es necesario
        int balance = ObtenerBalance(nodo);

        // Izquierda Izquierda
        if (balance > 1 && valor < nodo.Izq.Valor)
            return RotarDerecha(nodo);

        // Derecha Derecha
        if (balance < -1 && valor > nodo.Derecha.Valor)
            return RotarIzquierda(nodo);

        // Izquierda Derecha
        if (balance > 1 && valor > nodo.Izq.Valor)
        {
            nodo.Izq = RotarIzquierda(nodo.Izq);
            return RotarDerecha(nodo);
        }

        // Derecha Izquierda
        if (balance < -1 && valor < nodo.Derecha.Valor)
        {
            nodo.Derecha = RotarDerecha(nodo.Derecha);
            return RotarIzquierda(nodo);
        }

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
            if (nodo.Izq == null || nodo.Derecha == null)
            {
                Nodo temp = nodo.Izq ?? nodo.Derecha;
                nodo = temp;
            }
            else
            {
                Nodo minimo = ObtenerMinimo(nodo.Derecha);
                nodo.Valor = minimo.Valor;
                nodo.Derecha = Eliminar(nodo.Derecha, minimo.Valor);
            }
        }

        if (nodo == null)
            return null;

        // Actualizar altura
        nodo.Altura = 1 + Math.Max(ObtenerAltura(nodo.Izq), ObtenerAltura(nodo.Derecha));

        // Balancear
        int balance = ObtenerBalance(nodo);

        // Casos de rebalanceo
        if (balance > 1 && ObtenerBalance(nodo.Izq) >= 0)
            return RotarDerecha(nodo);

        if (balance > 1 && ObtenerBalance(nodo.Izq) < 0)
        {
            nodo.Izq = RotarIzquierda(nodo.Izq);
            return RotarDerecha(nodo);
        }

        if (balance < -1 && ObtenerBalance(nodo.Derecha) <= 0)
            return RotarIzquierda(nodo);

        if (balance < -1 && ObtenerBalance(nodo.Derecha) > 0)
        {
            nodo.Derecha = RotarDerecha(nodo.Derecha);
            return RotarIzquierda(nodo);
        }

        return nodo;
    }

    private Nodo ObtenerMinimo(Nodo nodo)
    {
        while (nodo.Izq != null)
            nodo = nodo.Izq;
        return nodo;
    }

    private int ObtenerAltura(Nodo nodo)
    {
        return nodo == null ? 0 : nodo.Altura;
    }

    private int ObtenerBalance(Nodo nodo)
    {
        return nodo == null ? 0 : ObtenerAltura(nodo.Izq) - ObtenerAltura(nodo.Derecha);
    }

    private Nodo RotarDerecha(Nodo y)
    {
        Nodo x = y.Izq;
        Nodo T2 = x.Derecha;

        x.Derecha = y;
        y.Izq = T2;

        y.Altura = 1 + Math.Max(ObtenerAltura(y.Izq), ObtenerAltura(y.Derecha));
        x.Altura = 1 + Math.Max(ObtenerAltura(x.Izq), ObtenerAltura(x.Derecha));

        return x;
    }

    private Nodo RotarIzquierda(Nodo x)
    {
        Nodo y = x.Derecha;
        Nodo T2 = y.Izq;

        y.Izq = x;
        x.Derecha = T2;

        x.Altura = 1 + Math.Max(ObtenerAltura(x.Izq), ObtenerAltura(x.Derecha));
        y.Altura = 1 + Math.Max(ObtenerAltura(y.Izq), ObtenerAltura(y.Derecha));

        return y;
    }
}

public class Nodo
{
    public int Valor;
    public Nodo Izq;
    public Nodo Derecha;
    public int Altura; 

    public Nodo(int Valor)
    {
        this.Valor = Valor;
        Altura = 1; 
    }
}

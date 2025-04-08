public class Nodo
{
    public int Value;
    public Nodo Left;
    public Nodo Right;
    public int Height; // Solo útil para AVL

    public Nodo(int value)
    {
        Value = value;
        Height = 1; // para AVL, si usas BST no afecta
    }
}

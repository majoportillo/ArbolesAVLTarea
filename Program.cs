using System;

class Programa
{
    static void Main()
    {
        BST bst = new BST();
        AVL avl = new AVL();

        while (true)
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "4") break;

            Console.Write("Ingrese un número: ");
            int numero = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case "1":
                    bst.Insertar(numero);
                    avl.Insertar(numero);
                    Console.WriteLine("Insertado en BST y AVL.");
                    break;

                case "2":
                    bool enBst = bst.Buscar(numero);
                    bool enAvl = avl.Buscar(numero);
                    Console.WriteLine("BST: " + (enBst ? "Encontrado" : "No encontrado"));
                    Console.WriteLine("AVL: " + (enAvl ? "Encontrado" : "No encontrado"));
                    break;

                case "3":
                    bst.Eliminar(numero);
                    avl.Eliminar(numero);
                    Console.WriteLine("Eliminado de BST y AVL.");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        Console.WriteLine("Fin del programa.");
    }
}

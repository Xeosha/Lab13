using Lab_10lib;

namespace Lab13
{
    public class Program
    {
        public static void Main()
        {
            var tree1 = new NewBinaryTree<Goods>();
            var tree2 = new NewBinaryTree<Goods>();

            var journal1 = new Journal();
            var journal2 = new Journal();

            tree1.CollectionCountChanged += new CollectionHandler(journal1.CollectionCountChanged);
            tree1.CollectionReferenceChanged += new CollectionHandler(journal1.CollectionReferenceChanged);

            tree1.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);
            tree2.CollectionReferenceChanged += new CollectionHandler(journal2.CollectionReferenceChanged);

            var products = new Goods[5];
            products[0] = new Goods();
            products[1] = new MilkProduct();
            products[2] = new Toy();
            products[3] = new Product();
            products[4] = new Goods("1", 1, 1);

            tree1.Add(products);
            tree2.Add(products);

            tree1.Remove(products[4]);
            tree1.Remove(0);
            tree2.Remove(products[4]);
            tree2.Remove(0);

            var product = new Goods("0", 0, 0);

            tree1[0] = product;
            tree2[0] = product;

           


            Console.WriteLine(journal1 + "\n\n" + journal2); 
          

            Console.WriteLine("\tПервое дерево: ");
            tree1.PrintTree();
            Console.WriteLine();
            Console.WriteLine("\tВторое дерево: ");
            tree2.PrintTree();

            Console.ReadKey(true);
        }
    }
}
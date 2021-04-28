using System;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            BBST tree = new BBST(-3, 3, 9, 14, 15, 17, 20, 24, 26, 30, 6, 11, -9, 0, -18, -6, -1, 2, 4, 8, 10, 13);
            tree.printPreorder();

            tree.addItem(7);
            tree.printPreorder();

            tree.deleteItem(14);
            tree.printPreorder();

            tree.deleteItem(9);
            tree.printPreorder();

            tree.deleteItem(10);
            tree.printPreorder();
        }
    }
}

using System;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode tree = new TreeNode(15);
            tree.add(7);
            tree.add(24);
            tree.add(20);
            tree.add(30);
            tree.add(26);
            tree.add(17);
            tree.add(22);
            tree.add(5);
            tree.add(9);
            tree.add(12);
            //tree.add();
            tree.printPreorder();
        }
    }
}

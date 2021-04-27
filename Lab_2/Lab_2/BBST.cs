using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class BBST
    {
        private TreeNode root;

        public BBST()
        {
            root = null;
        }
        public BBST(params int[] data)
        {
            foreach (int i in data)
            {
                this.add(i);
            }
        }

        public bool IsEmpty()
        {
            return root == null;
        }
        public void add(int data)
        {
            if (this.IsEmpty())
            {
                TreeNode n = new TreeNode(data);
                root = n;
            }
            else
            {
                root.add(data);
            }
        }

        public void printPreorder()
        {
            if (this.IsEmpty())
                Console.WriteLine("Tree empty.\n\n");
            else
                root.printPreorder();
        }
    }
}

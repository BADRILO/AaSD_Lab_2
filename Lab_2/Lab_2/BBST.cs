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
                this.addNode(i);
            }
        }

        public bool IsEmpty()
        {
            return root == null;
        }
        public void addNode(int data)
        {
            void addNode_rec(TreeNode node, int data)
            {
                if (data < node.data)
                {
                    if (node.left == null)
                    {
                        TreeNode n = new TreeNode(data);
                        node.left = n;
                    }
                    else addNode_rec(node.left, data);
                }
                else
                {
                    if (node.right == null)
                    {
                        TreeNode n = new TreeNode(data);
                        node.right = n;
                    }
                    else addNode_rec(node.right, data);
                }

            }
            if (this.IsEmpty())
            {
                TreeNode n = new TreeNode(data);
                root = n;
            }
            else
            {
                addNode_rec(root, data);
            }
        }
        public void printPreorder()
        {
            static void rec(TreeNode node)
            {
                if (node == null) return;

                Console.WriteLine($"{node.data}  ");
                rec(node.left);
                rec(node.right);
            }
            if (this.IsEmpty())
            {
                Console.WriteLine("Tree is empty!!!");
            }
            else rec(root);
        }
    }
}

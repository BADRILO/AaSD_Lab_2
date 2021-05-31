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
                this.addItem(i);
            }
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public bool search(int data)
        {
            if (root.data == data)
            {
                return true;
            }
            else if (root.search(data) == null)
            {
                return false;
            }
            return true;
        }

        public int size()
        {
            return TreeNode.size(root);
        }

        public void addItem(int data)
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

        public void deleteItem(int data)
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Tree is empty\n\n");
            }
            else if (root.data == data)
            {
                if (root.left == null && root.right == null)
                {
                    root = null;
                }
                else if (root.left != null && root.right != null)
                {
                    if (root.right.left == null)
                    {
                        root.data = root.right.data;
                        root.right = root.right.right;
                    }
                    else
                    {
                        int findLeftmost(TreeNode node)
                        {
                            //нашли крайний левый узел
                            if (node.left.left == null)
                            {
                                root.data = node.left.data;
                                node.delete(node.left.data);

                                return node.checkBalance();
                            }

                            return node.checkBalance(l_H: findLeftmost(node.left));
                        }
                        findLeftmost(root.right);
                    }
                    root.checkBalance();
                }
                else
                {
                    if (root.left != null)
                    {
                        root = root.left;
                    }
                    else
                    {
                        root = root.right;
                    }
                }
            }
            else
            {
                root.delete(data);
            }
        }

        public void deleteDuplicates()
        {
            root.deleteDuplicates();
        }

        public void printPreorder()
        {
            if (this.IsEmpty())
                Console.WriteLine("Tree is empty.\n\n");
            else
            {
                root.printPreorder();
                Console.WriteLine("\n"); 
            }
        }

        public void printInorder()
        {
            if (this.IsEmpty())
                Console.WriteLine("Tree is empty.\n\n");
            else
            {
                root.printInorder();
                Console.WriteLine("\n");
            }
        }

        public void printPostorder()
        {
            if (this.IsEmpty())
                Console.WriteLine("Tree is empty.\n\n");
            else
            {
                root.printPostorder();
                Console.WriteLine("\n");
            }
        }
    }
}

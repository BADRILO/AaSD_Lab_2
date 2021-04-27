using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;

        public TreeNode() 
            : this(0) {}
        public TreeNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }

        public int add(int data) //добавление нового узла
        {
            if (data < this.data)
            {
                if (this.left == null) //добавление нового узла как листочка
                {
                    this.left = new TreeNode(data);
                    return this.getHeight();
                }
                else
                {
                    int left_H  = this.left.add(data);
                    int right_H = this.right.getHeight();

                    return this.checkBalance(left_H, right_H);
                }
            }
            else
            {
                if (this.right == null)
                {
                    this.right = new TreeNode(data);
                    return this.getHeight();
                }
                else
                {
                    int right_H = this.right.add(data);
                    int left_H  = this.left.getHeight();

                    return this.checkBalance(left_H, right_H);
                }
            }
        }

        public int checkBalance(int left_H, int right_H)
        {
            int differ = Math.Abs(left_H - right_H);


            Console.WriteLine($"Data of node: {this.data}");
            Console.WriteLine($"Balance Factor: {differ}");
            Console.WriteLine($"Left subtree: {left_H}");
            Console.WriteLine($"Right subtree: {right_H}\n");


            if (differ > 1)
            {
                Console.WriteLine("Tree is unbalanced!!!");
                return this.rebalance(left_H, right_H);
            }
            return Math.Max(left_H, right_H) + 1;
        }
        public int rebalance(int left_H, int right_H)
        {
            //малое левое вращение
            if (left_H < right_H && this.right.left.getHeight() <= this.right.right.getHeight())
            {
                int this_data = this.data;
                TreeNode this_l = this.left;
                TreeNode this_r_l = this.right.left;
                TreeNode this_r_r = this.right.right;

                this.data = this.right.data;
                this.right.data = this_data;

                this.left = this.right;
                this.right = this_r_r;
                this.left.left = this_l;
                this.left.right = this_r_l;

                return Math.Max(left_H, right_H);
            }
            else
                return 0;
        }

        public int getHeight()
        {
            if (this == null)
            {
                return 0;
            }
            else
            {
                int left_height = this.left == null ? 0 : this.left.getHeight();
                int right_height = this.right == null ? 0 : this.right.getHeight();

                return Math.Max(left_height, right_height) + 1;
            }
        }

        public void printPreorder()
        {
            if (this == null)
                return;

            Console.WriteLine(this.data);
            this.left?.printPreorder();
            this.right?.printPreorder();
        }
    }
}

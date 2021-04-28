using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    internal class TreeNode
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

        public void printPreorder()
        {
            if (this == null)
                return;

            Console.WriteLine(this.data);
            this.left?.printPreorder();
            this.right?.printPreorder();
        }

        public void printInorder()
        {
            if (this == null)
                return;

            this.left?.printInorder();
            Console.WriteLine(this.data);
            this.right?.printInorder();
        }

        public void printPostorder()
        {
            if (this == null)
                return;

            this.left?.printPostorder();
            this.right?.printPostorder();
            Console.WriteLine(this.data);
        }

        public int? search(int data) //возвращает данные если они были найдены
        {
            if (data < this.data)
            {
                if (this.left == null)
                {
                    return null;
                }
                else if (this.left.data == data)
                {
                    return data;
                }
                else
                {
                    return this.left.search(data);
                }
            }
            else
            {
                if (this.right == null)
                {
                    return null;
                }
                else if (this.right.data == data)
                {
                    return data;
                }
                else
                {
                    return this.right.search(data);
                }
            }
        }

        public int add(int data) //добавление нового узла
        {
            if (data < this.data) //входим в левое поддерево
            {
                if (this.left == null) //добавление нового узла как листочка
                {
                    this.left = new TreeNode(data);
                    return getHeight(this);
                }
                else  //движемся рекурсивно дальше по дереву
                {
                    int left_H  = this.left.add(data); 
                    return this.checkBalance(l_H: left_H);
                }
            }
            else //входим в правое поддерево
            {
                if (this.right == null)  //добавление нового узла как листочка
                {
                    this.right = new TreeNode(data);
                    return getHeight(this);
                }
                else  //движемся рекурсивно дальше по дереву
                {
                    int right_H = this.right.add(data);
                    return this.checkBalance(r_H: right_H);
                }
            }
        }

        public void delete(int data) 
        {
            if (this.search(data) == null)
            {
                Console.WriteLine("Item not exist\n\n");
            }
            else
            {
                this.delete_rec(data);
            }
        }

        private int delete_rec(int data) 
        {
            if (data < this.data)
            {
                //процесс удаления
                if (this.left.data == data) 
                {
                    //если удаляемый элемент имеет 2 предка
                    if (this.left.left != null && this.left.right != null)
                    {
                        if (this.left.right.left == null)
                        {
                            this.left.data = this.left.right.data;
                            this.left.right = this.left.right.right;
                        }
                        else
                        {
                            //ищем крайний левый узел в данном поддереве и...
                            //на обратном пути проверяем балансы
                            int findLeftmost(TreeNode node)
                            {
                                //нашли крайний левый узел
                                if (node.left.left == null) 
                                {
                                    this.left.data = node.left.data;
                                    node.delete_rec(node.left.data);

                                    return node.checkBalance();
                                }

                                return node.checkBalance(l_H: findLeftmost(node.left));
                            }
                            findLeftmost(this.left.right);
                        }
                        //в этом случае может случиться дисбаланс
                        this.left.checkBalance();
                    }
                    //если удаляемый элемент не имеет ни одного предка
                    else if (this.left.left == null && this.left.right == null)
                    {
                        this.left = null;
                    }
                    //если удаляемый элемент имеет 1 предка
                    else
                    {
                        if (this.left.left != null)
                        {
                            this.left = this.left.left;
                        }
                        else
                        {
                            this.left = this.left.right;
                        }
                    }
                    return this.checkBalance();
                }
                //двигаемся дальше
                else
                {
                    int l_H  = this.left.delete_rec(data);

                    return this.checkBalance(l_H: l_H);
                }
            }
            else
            {
                //процесс удаления
                if (this.right.data == data)
                {
                    //если удаляемый элемент имеет 2 предка
                    if (this.right.left != null && this.right.right != null)
                    {
                        if (this.right.right.left == null)
                        {
                            this.right.data = this.right.right.data;
                            this.right.right = this.right.right.right;
                        }
                        else
                        {
                            //ищем крайний левый узел в данном поддереве и...
                            //на обратном пути проверяем балансы
                            int findLeftmost(TreeNode node)
                            {
                                //нашли крайний левый узел
                                if (node.left.left == null)
                                {
                                    this.right.data = node.left.data;
                                    node.delete_rec(node.left.data);

                                    return node.checkBalance();
                                }

                                return node.checkBalance(l_H: findLeftmost(node.left));
                            }
                            findLeftmost(this.right.right);
                        }
                        //в этом случае может случиться дисбаланс
                        this.right.checkBalance();
                    }
                    //если удаляемый элемент не имеет ни одного предка
                    else if (this.right.left == null && this.right.right == null)
                    {
                        this.right = null;
                    }
                    //если удаляемый элемент имеет 1 предка
                    else
                    {
                        if (this.right.left != null)
                        {
                            this.right = this.right.left;
                        }
                        else
                        {
                            this.right = this.right.right;
                        }
                    }
                    return this.checkBalance();
                }
                //двигаемся дальше
                else
                {
                    int r_H = this.right.delete_rec(data);

                    return this.checkBalance(r_H: r_H);
                }
            }
        }

        static int getHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int left_height = getHeight(node.left);
                int right_height = getHeight(node.right);

                return Math.Max(left_height, right_height) + 1;
            }
        }

        public int checkBalance(int l_H = -1, int r_H = -1)
        {
            int left_H  = l_H == -1 ? getHeight(this.left)  : l_H;
            int right_H = r_H == -1 ? getHeight(this.right) : r_H;
            int differ  = Math.Abs(left_H - right_H);


            //Console.WriteLine($"Data of node: {this.data}");
            //Console.WriteLine($"Balance Factor: {differ}");
            //Console.WriteLine($"Left subtree: {left_H}");
            //Console.WriteLine($"Right subtree: {right_H}\n");


            if (differ > 1)
            {
                Console.WriteLine("Tree is unbalanced!!!\n\n");
                return this.rebalance(left_H, right_H);
            }
            return Math.Max(left_H, right_H) + 1;
        }

        private int rebalance(int left_H, int right_H)
        {
            //малое левое вращение
            if      (left_H < right_H && getHeight(this.right.left) <= getHeight(this.right.right))
            {
                this.left_rotation(); 
            }
            //большое левое вращение
            else if (left_H < right_H && getHeight(this.right.left) >  getHeight(this.right.right))
            {
                this.right_left_rotation();
            }
            //малое правое вращение
            else if (left_H > right_H && getHeight(this.left.left)  >= getHeight(this.left.right))
            {
                this.right_rotation();
            }
            //большое правое вращение
            else if (left_H > right_H && getHeight(this.left.left)  <  getHeight(this.left.right))
            {
                this.left_right_rotation();
            }

            return Math.Max(left_H, right_H);
        }

        private void left_rotation()
        {
            Console.WriteLine("Used left rotation\n\n");
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
        }

        private void right_rotation()
        {
            Console.WriteLine("Used right rotation\n\n");
            int this_data = this.data;
            TreeNode this_r = this.right;
            TreeNode this_l_l = this.left.left;
            TreeNode this_l_r = this.left.right;

            this.data = this.left.data;
            this.left.data = this_data;

            this.right = this.left;
            this.left = this_l_l;
            this.right.left = this_l_r;
            this.right.right = this_r;
        }

        private void left_right_rotation()
        {
            Console.WriteLine("Used left-right rotation\n\n");
            this.left.left_rotation();
            this.right_rotation();
        }

        private void right_left_rotation()
        {
            Console.WriteLine("Used right-left rotation\n\n");
            this.right.right_rotation();
            this.left_rotation();
        }
        
    }
}

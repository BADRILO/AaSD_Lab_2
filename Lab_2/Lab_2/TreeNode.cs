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
    }
}

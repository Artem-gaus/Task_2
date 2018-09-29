using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class BinaryTree
    {
        public Node Insert(Node root, int value)
        {
            if (root == null)
            {
                root = new Node();
                root.Value = value;
            }
            else if (value < root.Value)
                root.LeftNode = Insert(root.LeftNode, value);
            else
                root.RightNode = Insert(root.RightNode, value);

            return root;
        }
    }
}

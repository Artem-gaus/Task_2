using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class BinaryTree
    {
        public Node Insert(Node root, Student student)
        {
            if (root == null)
            {
                root = new Node();
                root.Student = student;
            }
            else if (student.TestResult < root.Student.TestResult)
                root.LeftNode = Insert(root.LeftNode, student);
            else
                root.RightNode = Insert(root.RightNode, student);

            return root;
        }
        public void RemoveTree(ref Node root)
        {
            if (root != null)
            {
                if (root.LeftNode != null)
                    RemoveTree(ref root.LeftNode);
                if (root.RightNode != null)
                    RemoveTree(ref root.RightNode);

                root = null;
            }
        }
    }
}

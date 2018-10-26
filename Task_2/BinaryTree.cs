using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class BinaryTree : IEnumerable<Node>
    {
        public delegate void MethodContainer();
        public event MethodContainer promoterDelete;
        public event MethodContainer promoterAdded;

        private Node root;
        public IEnumerator<Node> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                if (queue.Peek().LeftNode != null)
                {
                    queue.Enqueue(queue.Peek().LeftNode);
                }
                if (queue.Peek().RightNode != null)
                {
                    queue.Enqueue(queue.Peek().RightNode);
                }
                yield return queue.Dequeue();
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


        public Node Insert(Node root, Student student)
        {
            Node currentRoot = root;
            if (root == null)
            {
                root = new Node();
                root.Student = student;
            }
            else if (student.TestResult < root.Student.TestResult)
                root.LeftNode = Insert(root.LeftNode, student);
            else
                root.RightNode = Insert(root.RightNode, student);

            if (currentRoot != root)
                promoterAdded();

            this.root = root;
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

            promoterDelete();
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class BinaryTree : IEnumerable<Node<Student>>
    {
        public delegate void MethodContainer();
        public event MethodContainer promoterDelete;
        public event MethodContainer promoterAdded;

        private Node<Student> root;
        public IEnumerator<Node<Student>> GetEnumerator()
        {
            Queue<Node<Student>> queue = new Queue<Node<Student>>();
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


        public Node<Student> Insert(Node<Student> root, Student student)
        {
            Node<Student> currentRoot = root;
            if (root == null)
            {
                root = new Node<Student>();
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
        public void RemoveTree(ref Node<Student> root)
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

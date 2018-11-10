using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Part_1
{
    public class BinaryTree : IEnumerable<Node<Student>>
    {
        private Node<Student> root;
        private Student[] localStudentsArray;

        public delegate void MethodContainer();
        public event MethodContainer promoterDelete;
        public event MethodContainer promoterAdded;

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

        public Node<Student> AddItems(Node<Student> rootNode, Student[] students)
        {
            localStudentsArray = students;
            for (int i = 0; i < students.Length; i++)
            {
                rootNode = Insert(rootNode, students[i]);
            }
            return rootNode;
        }

        public void DisplaySortedStudents()
        {
            Array.Sort(localStudentsArray);
            Console.WriteLine("\nSorted students array by Test result");
            foreach (var item in localStudentsArray)
                Console.WriteLine(item.Name + " " + item.TestResult);
            Console.WriteLine("");
        }

        protected Node<Student> Insert(Node<Student> root, Student student)
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

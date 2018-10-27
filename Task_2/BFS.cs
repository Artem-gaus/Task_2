using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class BFS
    {
        private static string ResultListValue { set; get; }
        public void AcrossFirstSearch(Node<Student> root)
        {
            Across(root);
            Print();
        }
        private void Across(Node<Student> root)
        {
            Queue<Node<Student>> queue = new Queue<Node<Student>>();
            queue.Enqueue(root);
            ResultListValue += root.Student.Name.ToString() + Environment.NewLine
                    + root.Student.TestTitle.ToString() + Environment.NewLine
                    + root.Student.TestResult.ToString() + Environment.NewLine
                    + root.Student.Data.ToString() + Environment.NewLine
                    + Environment.NewLine;
            while (queue.Count != 0)
            {
                if (queue.Peek().LeftNode != null)
                {
                    ResultListValue += queue.Peek().LeftNode.Student.Name.ToString() + Environment.NewLine
                        + queue.Peek().LeftNode.Student.TestTitle.ToString() + Environment.NewLine
                        + queue.Peek().LeftNode.Student.TestResult.ToString() + Environment.NewLine
                        + queue.Peek().LeftNode.Student.Data.ToString() + Environment.NewLine
                        + Environment.NewLine;
                    queue.Enqueue(queue.Peek().LeftNode);
                }
                if (queue.Peek().RightNode != null)
                {
                    ResultListValue += queue.Peek().RightNode.Student.Name.ToString() + Environment.NewLine
                        + queue.Peek().RightNode.Student.TestTitle.ToString() + Environment.NewLine
                        + queue.Peek().RightNode.Student.TestResult.ToString() + Environment.NewLine
                        + queue.Peek().RightNode.Student.Data.ToString() + Environment.NewLine
                        + Environment.NewLine;
                    queue.Enqueue(queue.Peek().RightNode);
                }
                queue.Dequeue();
            }
        }
        private void Print() => Console.WriteLine(ResultListValue);
    }
}

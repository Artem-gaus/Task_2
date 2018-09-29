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
        public void AcrossFirstSearch(Node root)
        {
            Across(root);
            Print();
        }
        private void Across(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            ResultListValue += root.Value.ToString() + ",  ";
            while (queue.Count != 0)
            {
                if (queue.Peek().LeftNode != null)
                {
                    ResultListValue += queue.Peek().LeftNode.Value.ToString() + ",  ";
                    queue.Enqueue(queue.Peek().LeftNode);
                }
                if (queue.Peek().RightNode != null)
                {
                    ResultListValue += queue.Peek().RightNode.Value.ToString() + ",  ";
                    queue.Enqueue(queue.Peek().RightNode);
                }
                queue.Dequeue();
            }
        }
        private void Print() => Console.WriteLine(ResultListValue);
    }
}

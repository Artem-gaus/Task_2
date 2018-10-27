using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class DFS
    {
        //Perambulation in depth
        private static string ResultListValue { set; get; }
        public void DepthFirstSearch(Node<Student> root)
        {
            CLR(root);
            Print();
        }
        //Center Left Right
        private void CLR(Node<Student> root)
        {
            if (root != null)
            {
                ResultListValue += root.Student.Name.ToString() + Environment.NewLine
                    + root.Student.TestTitle.ToString() + Environment.NewLine
                    + root.Student.TestResult.ToString() + Environment.NewLine
                    + root.Student.Data.ToString() + Environment.NewLine
                    + Environment.NewLine;
                CLR(root.LeftNode);
                CLR(root.RightNode);
            }
        }
        private void Print() => Console.WriteLine(ResultListValue);
    }
}

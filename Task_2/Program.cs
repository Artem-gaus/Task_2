using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        //fist we going implement in this project
        //last step is add DLL lib and move there
        static void Main(string[] args)
        {
            Node root = null;
            BinaryTree tree = new BinaryTree();
            int[] fill = new int[] {10, 3, 15, 28, 4, -15, 2, 56 }; 

            for (int i = 0; i < fill.Length; i++)
            {
                root = tree.Insert(root, fill[i]);
            }

            Console.ReadKey();
        }
    }
}

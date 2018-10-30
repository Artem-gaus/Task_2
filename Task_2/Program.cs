using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<Student> root = null;
            BinaryTree tree = new BinaryTree();

            Subscriber subscriber = new Subscriber();
            tree.promoterAdded += subscriber.SpeakerAddition;
            tree.promoterDelete += subscriber.SpeakerRemoval;

            Student[] students = new Student[] {
                new Student { Name = "Tolik", TestResult = 150, TestTitle = "Science", Data = new DateTime(2018, 10, 15) },
                new Student { Name = "Andrey", TestResult = 160, TestTitle = "Tech science", Data = new DateTime(2018, 9, 4) },
                new Student { Name = "Slava", TestResult = 195, TestTitle = "Electronic", Data = new DateTime(2018, 10, 3) }
            };
            root = tree.AddItems(root, students);

            //use Sort array whith help implement IComparable<T>
            tree.DisplaySortedStudents();
            
            //we can use "foreach" loop
            foreach (Node<Student> item in tree)
            {
                Console.WriteLine("name: {0}", item.Student.Name);
            }

            DFS dfs = new DFS();
            dfs.DepthFirstSearch(root);

            BFS bfs = new BFS();
            bfs.AcrossFirstSearch(root);

            tree.RemoveTree(ref root);

            //Task_2
            //NamedIterator
            int[] testArray = new int[] { 1, 2, 3, 4, 5, 6 };
            ArrayWithAnyRangeIndex<int> MyArray = new ArrayWithAnyRangeIndex<int>(testArray);
            foreach (var item in MyArray.GetArrayBySetRange(2, 4))
            {
                Console.WriteLine(item + " ");
            }

            Console.ReadKey();
        }
    }
}

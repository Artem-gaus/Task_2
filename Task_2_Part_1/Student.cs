using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Part_1
{
    public class Student : IComparable<Student>
    {
        public string Name;
        public string TestTitle;
        public int TestResult;
        public DateTime Data;

        public int CompareTo(Student obj)
        {
            if (this.TestResult > obj.TestResult)
                return 1;
            if (this.TestResult < obj.TestResult)
                return -1;
            else
                return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1135In4thCabinetToPDF
{
    public class Student
    {
        public string FI { get; set; }
        public int HoursIn4th { get; set; }
        public int QuestionsCount  { get; set; }
        public int WorkCount { get; set; }
        public List<ForceMajoreXD> StudentForceMajoreXD { get; set; } = new List<ForceMajoreXD>();
    }
}

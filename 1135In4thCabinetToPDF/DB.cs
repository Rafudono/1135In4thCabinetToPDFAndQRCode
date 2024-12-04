using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1135In4thCabinetToPDF
{
    public class DB
    {
        public DB()
        {
            FillCollection();
        }
        public List<Student> Students { get; set; } = new List<Student>();
        private static DB instance;
        public static DB GetInstance()
        {
            if (instance == null)
            {
                instance = new DB();
            }
            return instance;
        }
        public void FillCollection()
        {
            string all = "Беляев Аркадий ;Борисов Дмитрий ;Ермолаева Мария ;Зяблицкий Олег ;Карагодина Ксения ;Киприн Евгений ;Ковтун Алексей ;Котов Владислав ;Кравцов Леонид ;Крылов Никита ;Кульбацкий Владислав ;Москвин Тимур ;Никитина Алёна ;Нуянцева Екатерина ;Охремчук Алина ;Протасова Виолетта ;Пыхтеев Святослав ;Рачок Никита ;Розина Мария ;Сайко Иван ;Сапогов Владимир ;Силин Сергей ;Ситников Иван ;Тимофеев Данил ;Федорова София ;Чуина Ульяна ;Шевченко Алексей";
            Random rn = new Random();
            foreach (string s in all.Split(" ;"))
            {
                Student student = new Student();
                student.FI = s;

                student.QuestionsCount = rn.Next(0, int.MaxValue);
                student.HoursIn4th = rn.Next(0, int.MaxValue);
                student.WorkCount = rn.Next(0, 100);
                Students.Add(student);
            }

        }
    }
}

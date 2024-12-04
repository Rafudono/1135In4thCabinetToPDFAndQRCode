using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1135In4thCabinetToPDF
{
    /// <summary>
    /// Логика взаимодействия для NewForceMajoreForStudentXD.xaml
    /// </summary>
    public partial class NewForceMajoreForStudentXD : Window, INotifyPropertyChanged
    {
        private ForceMajoreXD forceMajore = new ForceMajoreXD();

        public ForceMajoreXD ForceMajore
        {
            get => forceMajore; 
            set
            {
                forceMajore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ForceMajore)));
            }
        }
        public Student StudentOnPage { get; set; } = new Student();
        public NewForceMajoreForStudentXD(Student student)
        {
            InitializeComponent();
            StudentOnPage=student;
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void AddToDB(object sender, RoutedEventArgs e)
        {
            StudentOnPage.StudentForceMajoreXD.Add(ForceMajore);
            var pred=DB.GetInstance().Students.FindIndex(s=>s.FI == StudentOnPage.FI);
            DB.GetInstance().Students[pred] = StudentOnPage;
            Close();
        }
    }
}

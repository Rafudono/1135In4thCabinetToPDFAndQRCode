using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
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
    /// Логика взаимодействия для StudInfo.xaml
    /// </summary>
    public partial class StudInfo : Window, INotifyPropertyChanged
    {
        private Student infoStudent;

        public Student InfoStudent
        {
            get => infoStudent;
            set
            {
                infoStudent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InfoStudent)));
            }
        }
        public StudInfo(Student student)
        {
            InfoStudent=student;
            studIndex=DB.GetInstance().Students.FindIndex(s=>s.FI==student.FI);
            InitializeComponent();
            DataContext = this;
        }
        int studIndex;
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NewForce(object sender, RoutedEventArgs e)
        {
            NewForceMajoreForStudentXD tw = new NewForceMajoreForStudentXD(InfoStudent);
            tw.ShowDialog();
            InfoStudent = DB.GetInstance().Students[studIndex];
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            DB.GetInstance().Students[studIndex]=InfoStudent;
            Close();
            MessageBox.Show("Изменения вступили в силу!");
        }
    }
}

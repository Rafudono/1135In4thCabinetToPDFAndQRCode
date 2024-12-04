using Spire.Barcode;
using Spire.Doc;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Document = Spire.Doc.Document;
using System.Drawing;
namespace _1135In4thCabinetToPDF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Student selectedStudent;

        public MainWindow()
        {
            InitializeComponent();
            FillCollection();
            DataContext = this;
        }
        public List<Student> Students { get; set; }= DB.GetInstance().Students;
        public Student SelectedStudent { get => selectedStudent;
            set
            {
                selectedStudent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedStudent)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void FillCollection()
        {
            Students = DB.GetInstance().Students;
        }

        private void CheckInfo(object sender, MouseButtonEventArgs e)
        {
            StudInfo tw = new StudInfo(SelectedStudent);
            tw.ShowDialog();
            FillCollection();
        }

        private void NewPDFFile(object sender, RoutedEventArgs e)
        {
            
            Document document = new Document();
            var section = document.AddSection();
            section.PageSetup.PageSize = new System.Drawing.SizeF(300, 300);


            var p = document.Sections[0].AddParagraph();
            p.AppendText($"Студент {SelectedStudent.FI}");

            p = document.Sections[0].AddParagraph();
            p.AppendText($"Провел в 4ке {SelectedStudent.HoursIn4th} часов");
            document.Sections[0].AddParagraph();

            p = document.Sections[0].AddParagraph();
            var range = p.AppendText($"За это время он успел:");
            p = document.Sections[0].AddParagraph();
            p.AppendText($"Задать {SelectedStudent.QuestionsCount} вопросов и выполнить {SelectedStudent.WorkCount} работ!");
          

            p = document.Sections[0].AddParagraph();
            if (SelectedStudent.StudentForceMajoreXD.Count > 0)
            {
                p.AppendText($"А ещё с ним произошли следующие форс-мажоры))):");
                foreach (var item in SelectedStudent.StudentForceMajoreXD)
                {
                    p = document.Sections[0].AddParagraph();
                    p.AppendText($"{item.ForceDate.ToShortDateString()} {item.Description}");
                }
            }
            else p.AppendText($"А ещё с ним не произошло ни единого форс-мажора за всё время обучения!!!");
            document.Sections[0].AddParagraph();

            document.SaveToFile("newFile.pdf", FileFormat.PDF);
            var info = new ProcessStartInfo("explorer.exe");
            info.Arguments = Environment.CurrentDirectory + "\\newFile.pdf";
            Process.Start(info);
        }

        private void NewQRCode(object sender, RoutedEventArgs e)
        {
            BarcodeSettings settings = new BarcodeSettings();
            settings.Type = BarCodeType.QRCode;
            settings.Data = $"{SelectedStudent.FI} провёл {SelectedStudent.HoursIn4th} часов в 4ке";
            settings.Data2D = "what's that?";
            settings.QRCodeDataMode = QRCodeDataMode.AlphaNumber;
            settings.X = 1.0f;
            settings.QRCodeECL = QRCodeECL.H;
            BarCodeGenerator generator = new BarCodeGenerator(settings);
            System.Drawing.Image image = generator.GenerateImage();
            QRCodeImage tw = new QRCodeImage(image);
            tw.Show();
            image.Save("QRCode.png");
        }
    }
}
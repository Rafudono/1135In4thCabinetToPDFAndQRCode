using System;
using System.Collections.Generic;
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
using System.Drawing;

namespace _1135In4thCabinetToPDF
{
    /// <summary>
    /// Логика взаимодействия для QRCodeImage.xaml
    /// </summary>
    public partial class QRCodeImage : Window
    {
        public byte[] QRCode { get; set; }
        public QRCodeImage(System.Drawing.Image image)
        {
            InitializeComponent();
            ImageConverter conv = new ImageConverter();
            QRCode = (byte[])conv.ConvertTo(image, typeof(byte[]));
            DataContext = this;
        }
    }
}

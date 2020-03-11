using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 日志读取
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path;
        private string a;
        private string b;
        private string c;
        public MainWindow()
        {
            InitializeComponent();
            a = DateTime.Now.ToString();
            b = "操作员 1710243227_梁若为"; 
            path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
            AppendToFile(path, "\n文件打开\n" + a + b);
            this.Closing += MyClosing; //Closing 在窗口关闭之前引发，它提供一种机制，可以通过这种机制来阻止窗口关闭系统会向Closing 事件处理程序传递一个 CancelEventArgs e，该参数实现 Boolean Cancel 属性，将该属性设置为 true 可以阻止窗口关闭。

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppendToFile(path, "\n操作一\n" + a + b);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppendToFile(path, "\n操作二\n" + a + b);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppendToFile(path, "\n操作三\n" + a + b);
        }
        private void AppendToFile(string path, string str)
        {
            using (FileStream fs = File.OpenWrite(path))
            {
                Byte[] bytes = Encoding.UTF8.GetBytes(str);
                fs.Position = fs.Length;
                fs.Write(bytes, 0, bytes.Length);
            }
            
        }
        private void MyClosing(object o, System.ComponentModel.CancelEventArgs e)
        {
            AppendToFile(path, "\n文件关闭\r\n" + a + b);
        }

    }
}

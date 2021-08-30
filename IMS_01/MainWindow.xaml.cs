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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMS_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LabLoadClick(object sender, RoutedEventArgs e)
        {
            string hdr = ((MenuItem)sender).Header.ToString();
            string s = hdr.Substring(hdr.Length - 1);
            mainFrame.Source = new Uri("Lab_" + s + ".xaml", UriKind.Relative);
        }
    }
}

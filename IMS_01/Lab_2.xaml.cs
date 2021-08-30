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
using ZedGraph;

namespace IMS_01
{
    /// <summary>
    /// Логика взаимодействия для Lab_2.xaml
    /// </summary>
    public partial class Lab_2 : Page
    {
        ZedGraphControl zedGraphControl1;
        public class Data
        {
            public int I { get; }
            public double X { get; }
            public double Y { get; }
            public Data(int i, double x, double y)
            {
                I = i;
                X = x;
                Y = y;
            }
        }

        public Lab_2()
        {
            InitializeComponent();
            zedGraphControl1 = new ZedGraphControl();
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(tbA.Text);
                double b = Convert.ToDouble(tbB.Text);
                double k = Convert.ToDouble(tbK.Text);
                double c = Convert.ToDouble(tbC.Text);
                int n = Convert.ToInt32(tbN.Text);
                int all = 0, successful = 0;
                if (n < 1) throw new Exception("Количество меньше нуля");
                Random rnd = new Random();
                List<Data> data = new List<Data>();
                double[] ax = new double[200];
                double[] ay = new double[200];
                double? fmax = null;
                windowsFormsHost.Child = zedGraphControl1;
                zedGraphControl1.Width = zedGraphControl1.Height = 400;
                zedGraphControl1.GraphPane.CurveList.Clear();
                for (int i = 0; i < 200; i++)
                {
                    double x = (double)i / 200;
                    double z = (b - a) * x + a;
                    ax[i] = (double)i / 20;
                    ay[i] = k / ax[i] + c;
                    double f = k / z + c;
                    if (fmax == null || fmax < f) fmax = f;
                }
                for (int i = 0; i < n; i++)
                {
                    int integer = rnd.Next(0, 101);
                    double z = (double)integer / 100;
                    double x = (b - a) * z + a;
                    integer = rnd.Next(0, 101);
                    z = (double)integer / 100;
                    double y = (double)fmax * z;
                    data.Add(new Data(i + 1, x, y));
                    if (y <= k / x + c)
                    {
                        successful++;
                        zedGraphControl1.GraphPane.AddCurve("",
                            new double[1] { x }, new double[1] { y },
                            System.Drawing.Color.Magenta, SymbolType.Circle);
                    }
                    else
                    {
                        zedGraphControl1.GraphPane.AddCurve("",
                            new double[1] { x }, new double[1] { y },
                            System.Drawing.Color.LimeGreen, SymbolType.Circle);
                    }
                    all++;
                }
                textBlock.Text = "Вероятность: " + ((double)successful / all);
                dataGrid.ItemsSource = data;

                zedGraphControl1.GraphPane.AddCurve("",
                    ax, ay, System.Drawing.Color.Red, SymbolType.None);
                zedGraphControl1.GraphPane.AddCurve("",
                    new double[2] { a, a }, new double[2] { 0, (double)fmax },
                    System.Drawing.Color.Blue, SymbolType.None);
                zedGraphControl1.GraphPane.AddCurve("",
                    new double[2] { b, b }, new double[2] { 0, (double)fmax },
                    System.Drawing.Color.Blue, SymbolType.None);
                zedGraphControl1.GraphPane.AddCurve("",
                    new double[2] { a, b }, new double[2] { (double)fmax, (double)fmax },
                    System.Drawing.Color.Blue, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка:\n" + ex.Message);
            }
        }
    }
}

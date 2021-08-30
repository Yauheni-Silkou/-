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
    /// Логика взаимодействия для Lab_7.xaml
    /// </summary>
    public partial class Lab_7 : Page
    {
        double[,] mainArray;
        double[] column1, column2, column3, column4, column5, columnX;
        public Lab_7()
        {
            InitializeComponent();

        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainArray[0, 0] = column1[0] = Convert.ToDouble(textBox11);
                mainArray[0, 1] = column1[1] = Convert.ToDouble(textBox12);
                mainArray[0, 2] = column1[2] = Convert.ToDouble(textBox13);
                mainArray[0, 3] = column1[3] = Convert.ToDouble(textBox14);
                mainArray[0, 4] = column1[4] = Convert.ToDouble(textBox15);
                mainArray[1, 0] = column2[0] = Convert.ToDouble(textBox21);
                mainArray[1, 1] = column2[1] = Convert.ToDouble(textBox22);
                mainArray[1, 2] = column2[2] = Convert.ToDouble(textBox23);
                mainArray[1, 3] = column2[3] = Convert.ToDouble(textBox24);
                mainArray[1, 4] = column2[4] = Convert.ToDouble(textBox25);
                mainArray[2, 0] = column3[0] = Convert.ToDouble(textBox31);
                mainArray[2, 1] = column3[1] = Convert.ToDouble(textBox32);
                mainArray[2, 2] = column3[2] = Convert.ToDouble(textBox33);
                mainArray[2, 3] = column3[3] = Convert.ToDouble(textBox34);
                mainArray[2, 4] = column3[4] = Convert.ToDouble(textBox35);
                mainArray[3, 0] = column4[0] = Convert.ToDouble(textBox41);
                mainArray[3, 1] = column4[1] = Convert.ToDouble(textBox42);
                mainArray[3, 2] = column4[2] = Convert.ToDouble(textBox43);
                mainArray[3, 3] = column4[3] = Convert.ToDouble(textBox44);
                mainArray[3, 4] = column4[4] = Convert.ToDouble(textBox45);
                mainArray[4, 0] = column5[0] = Convert.ToDouble(textBox51);
                mainArray[4, 1] = column5[1] = Convert.ToDouble(textBox52);
                mainArray[4, 2] = column5[2] = Convert.ToDouble(textBox53);
                mainArray[4, 3] = column5[3] = Convert.ToDouble(textBox54);
                mainArray[4, 4] = column5[4] = Convert.ToDouble(textBox55);
            }
            catch { }
        }

        double[,] MultMatrix(double[,] matrixA, double[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
                throw new Exception("Количество столбцов первой матрицы должно совпадать с количеством строк второй матрицы");
            else
            {
                int m = matrixA.GetLength(0),
                    n = matrixA.GetLength(1),
                    q = matrixB.GetLength(1);
                double[,] matrixC = new double[m, q];
                for (int j = 0; j < m; j++)
                    for (int k = 0; k < q; k++)
                    {
                        double s = 0;
                        for (int i = 0; i < n; i++) s += matrixA[j, i] * matrixB[i, k];
                        matrixC[j, k] = s;
                    }
                return matrixC;
            }
        }

        double[,] TransparentMatrix(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            double[,] trmx = new double[n, m];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    trmx[j, i] = matrix[i, j];
                }
            return trmx;
        }
    }
}

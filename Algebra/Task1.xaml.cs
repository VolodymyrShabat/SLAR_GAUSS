using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Algebra
{
    /// <summary>
    /// Interaction logic for Task1.xaml
    /// </summary>
    public partial class Task1 : Window
    {
        public Task1()
        {
            InitializeComponent();
        }

        private Matrix matrix1;
        private Matrix matrix2;


        private void Generate1_Click(object sender, RoutedEventArgs e)
        {
            if (Box1_m.Text == "" || Box1_n.Text == "")
            {
                MessageBox.Show("Enter rows and columns");
            }
            else
            {
                matrix1 = new Matrix(int.Parse(Box1_n.Text), int.Parse(Box1_m.Text));
                matrix1.GenerateMatrix(0, 8);
                Grid1.Text = matrix1.ToString();
            }
            
        }

        private void Generate2_Click(object sender, RoutedEventArgs e)
        {
            if(Box1_m.Text=="" ||Box1_n.Text =="")
            {
                MessageBox.Show("Enter rows and columns");
            }
            else
            {
                matrix2 = new Matrix(int.Parse(Box2_n.Text), int.Parse(Box2_m.Text));
                matrix2.GenerateMatrix(0, 8);
                Grid2.Text = matrix2.ToString();
            }
            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(matrix1==null || matrix2 == null)
            {
                MessageBox.Show("Generate matrices!");
            }
            else
            {
                var result = matrix1 + matrix2;
                if(result==null)
                {
                    MessageBox.Show("Matrices must have equal amount of rows and columns");
                }
                else
                {
                    Grid3.Text = result.ToString();
                }
            }
        }

        private void Substract_Click(object sender, RoutedEventArgs e)
        {
            if (matrix1 == null || matrix2 == null)
            {
                MessageBox.Show("Generate matrices!");
            }
            else
            {
                var result = matrix1 - matrix2;
                if (result == null)
                {
                    MessageBox.Show("Matrices must have equal amount of rows and columns");
                }
                else
                {
                    Grid3.Text = result.ToString();
                }
            }
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            if (matrix1 == null || matrix2 == null)
            {
                MessageBox.Show("Generate matrixes!");
            }
            else
            {
                var result = matrix1 * matrix2;
                if (result == null)
                {
                    MessageBox.Show("Matrix1 n must == Matrix2 m");
                }
                else
                {
                    Grid3.Text = result.ToString();
                }
            }
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections;
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

namespace Algebra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Amount.Text== "Введіть дані" || Left.Text== "Введіть дані" || Right.Text== "Введіть дані")
            {
                MessageBox.Show("Input value!"); 
            }
            else
            {
                Matrix matrix = new Matrix(int.Parse(Amount.Text), int.Parse(Amount.Text) + 1);
                matrix.GenerateMatrix(int.Parse(Left.Text), int.Parse(Right.Text));
                SLAR slar = new SLAR(matrix);
                Test.Text = slar.GaussMethod();
            }
        }

        private void Button_Click_Read(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                String s = File.ReadAllText(openFileDialog.FileName).ToString().Replace("\r\n", "  ");
                string[] arr = s.Split("  ");
                string result;
                if (arr.Length==arr[0].Split(",").Length-1)
                {
                    Matrix matrix = new Matrix(arr.Length, arr.Length + 1);        
                    matrix.ReadFromArray(arr);
                    SLAR slar = new SLAR(matrix);
                    Test.Text = slar.GaussMethod();

                    var path = @"C:\Users\Volod\OneDrive\Рабочий стол\Answer.txt";
                    result = slar.Steps.ToString();
                    File.WriteAllText(path,string.Empty);
                    File.WriteAllText(path,result);
                }
                else
                {
                    MessageBox.Show("Wrong!");
                }
               
                

            }    
                
            
        }
    }
}

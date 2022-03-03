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

namespace ITParkWPF
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

        static double a, b, operation;

        public const int Add = 1;
        public const int Sub = 2;
        public const int Mul = 3;
        public const int Div = 4;
        public const int Sqr = 5;

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btn18_Click(object sender, RoutedEventArgs e)
        {
            txt1.Clear();
            lbl1.Content = "";
        }
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text == "0" || txt1.Text == null)
            {
                txt1.Text = "0";
            }
            else
                txt1.Text += 0;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text == "0")
            {
                txt1.Text = "1";
            }
            else
                txt1.Text += 1;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += 2;
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += 3;
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += 4;
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += 5;
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += 6;
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += 7;
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += 8;
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += 9;
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text += ".";
        }

        private void txt1_GotFocus()
        {
            a = double.Parse(txt1.Text);
            lbl1.Content = txt1.Text;
            txt1.Clear();
            txt1.Focus();
        }

        private void btn12_Click(object sender, RoutedEventArgs e)
        {
            b = double.Parse(txt1.Text);
            lbl1.Content += txt1.Text;
            switch (operation)
            {
                case Add:
                    {
                        double result = a + b;
                        lbl1.Content += ($"={txt1.Text = result.ToString()}");
                        txt1.Text = result.ToString();
                        break;
                    }

                case Sub:
                    {
                        double result = a - b;
                        lbl1.Content += ($"={txt1.Text = result.ToString()}");
                        txt1.Text = result.ToString();
                        break;
                    }

                case Mul:
                    {
                        double result = a * b;
                        lbl1.Content += ($"={txt1.Text = result.ToString()}");
                        txt1.Text = result.ToString();
                        break;
                    }

                case Div:
                    {
                        double result = a / b;
                        lbl1.Content += ($"={txt1.Text = result.ToString()}");
                        txt1.Text = result.ToString();
                        break;
                    }
                case Sqr:
                    {
                        double result = Math.Pow(a, b);
                        lbl1.Content += ($"={txt1.Text = result.ToString()}");
                        txt1.Text = result.ToString();
                        break;
                    }
            }
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            txt1_GotFocus();
            lbl1.Content += "+";
            operation = Add;
        }

        private void btn14_Click(object sender, RoutedEventArgs e)
        {
            txt1_GotFocus();
            lbl1.Content += "-";
            operation = Sub;
        }

        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            txt1_GotFocus();
            lbl1.Content += "*";
            operation = Mul;
        }
       
        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            txt1_GotFocus();
            lbl1.Content += "/";
            operation = Div;
        }

        private void btn19_Click(object sender, RoutedEventArgs e)
        {
            txt1_GotFocus();
            lbl1.Content += "^";
            operation = Sqr;
        }
        //Не смог реализовать кнопки:  "+/-",  ".",  "Backspace"
        //Также адекватное написание справа налево в TextBox и Label
    }
}

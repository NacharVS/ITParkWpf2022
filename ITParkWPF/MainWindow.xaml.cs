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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double a = 0;
        static double b = 0;
        static int z = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 1;
                Lbl.Content = a;
            }
            else
            {
                a = 1;
                Lbl.Content = a;
            }
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 2;
                Lbl.Content = a;
            }
            else
            {
                a = 2;
                Lbl.Content = a;
            }
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 3;
                Lbl.Content = a;
            }
            else
            {
                a = 3;
                Lbl.Content = a;
            }
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 4;
                Lbl.Content = a;
            }
            else
            {
                a = 4;
                Lbl.Content = a;
            }
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 5;
                Lbl.Content = a;
            }
            else
            {
                a = 5;
                Lbl.Content = a;
            }
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 6;
                Lbl.Content = a;
            }
            else
            {
                a = 6;
                Lbl.Content = a;
            }
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 7;
                Lbl.Content = a;
            }
            else
            {
                a = 7;
                Lbl.Content = a;
            }
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 8;
                Lbl.Content = a;
            }
            else
            {
                a = 8;
                Lbl.Content = a;
            }
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10 + 9;
                Lbl.Content = a;
            }
            else
            {
                a = 9;
                Lbl.Content = a;
            }
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (a != 0)
            {
                a = a * 10;
                Lbl.Content = a;
            }
            else
            {
                Lbl.Content = a;
            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (z == 0)
            {
                z = 1;
                if (b == 0)
                {
                    b = a;
                    a = 0;
                }
                else
                {
                    Result_Click(sender, e);
                }
            }
            else
            {
                Result_Click(sender, e);
                z = 1;
                if (b == 0)
                {
                    b = a;
                    a = 0;
                }
                else
                {
                    Result_Click(sender, e);
                }
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (z == 0)
            {
                z = 2;
                if (b == 0)
                {
                    b = a;
                    a = 0;
                }
                else
                {
                    Result_Click(sender, e);
                }
            }
            else
            {
                Result_Click(sender, e);
                z = 2;
                if (b == 0)
                {
                    b = a;
                    a = 0;
                }
                else
                {
                    Result_Click(sender, e);
                }
            }
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            if (z == 0)
            {
                z = 3;
                if (b == 0)
                {
                    b = a;
                    a = 0;
                }
                else
                {
                    Result_Click(sender, e);
                }
            }
            else
            {
                Result_Click(sender, e);
                z = 3;
                if (b == 0)
                {
                    b = a;
                    a = 0;
                }
                else
                {
                    Result_Click(sender, e);
                }
            }
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            if (z == 0)
            {
                z = 4;
                if (b == 0)
                {
                    b = a;
                    a = 0;
                }
                else if (a != 0)
                {
                    Result_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Division by zero is impossible!");
                }
            }
            else
            {
                Result_Click(sender, e);
                z = 4;
                if (b == 0)
                {
                    b = a;
                    a = 0;
                }
                else
                {
                    Result_Click(sender, e);
                }
            }
        }
        private void DEL_Click(object sender, RoutedEventArgs e)
        {
            Lbl.Content=0;
            a=0;
            b=0;
            z=0;
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
                switch (z)
                {
                    case 1: 
                   b = b + a;
                    Lbl.Content=b;
                    a=0;
                    break;
                    case 2: 
                    b = b - a;
                    Lbl.Content = b;
                    a = 0;
                    break;
                case 3: 
                    b = b * a;
                    Lbl.Content = b;
                    a = 0;
                    break;
                case 4:
                    if (a != 0)
                    {
                        b = b / a;
                        Lbl.Content = b;
                        a = 0;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Division by zero is impossible!");
                        break;
                    }
                default: 
                    Lbl.Content = 0;
                    break;
            }
            
        }
    }
}

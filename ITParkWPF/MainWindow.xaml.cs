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
        static double a = 0;
        static double b = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bigbtn_Click(object sender, RoutedEventArgs e)
        {
            //a = a + int.Parse(txt1.Text);
            lblMessage.Content = (int.Parse(txt1.Text) + int.Parse(txt2.Text)).ToString();
        }

        private void lbl1_MouseMove(object sender, MouseEventArgs e)
        {
            lbl1.IsEnabled = !lbl1.IsEnabled;
        }

        private void lbl1_MouseEnter(object sender, MouseEventArgs e)
        {
            lbl1.IsEnabled = !lbl1.IsEnabled;
        }

        private void txt1_GotFocus(object sender, RoutedEventArgs e)
        {
            txt1.Clear();
        }

        private void txt2_GotFocus(object sender, RoutedEventArgs e)
        {
            txt2.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblMessage.Content = (a + b).ToString();
        }

        private void txt1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt1.Text == "First Number")
                return;
            if (txt1.Text == "" || txt1.Text == null)
                return;
            a = double.Parse(txt1.Text);
        }

        private void txt2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt2.Text == "Second Number" || txt2.Text == "" || txt2.Text == null)
                return;
            b = double.Parse(txt2.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            lblMessage.Content = a - b;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lblMessage.Content = (a * b).ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(b == 0)
            {
                MessageBox.Show("Division by zero is impossible!");
                
            }
            else
            lblMessage.Content = (a / b).ToString();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (b == 0)
            {
                MessageBox.Show("Division by zero is impossible!");

            }
            else
                lblMessage.Content = (a / b).ToString();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            lblMessage.Content =  Math.Pow(a, b);
        }

        // Создать кнопочный калькулятор с действиями + - / * 
    }
}

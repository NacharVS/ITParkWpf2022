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

        static string label = "0";
        static string sign;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(label == "0")
            {
                label = "1";
                lblNumber.Content = label;
            }
            else
            {
                label = "1";
                lblNumber.Content += label;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (label == "0")
            {
                label = "2";
                lblNumber.Content = label;
            }
            else
            {
                label = "2";
                lblNumber.Content += label;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            sign = "+";
            a = Convert.ToInt32(lblNumber.Content);
            lblNumber.Content = "0";
            label = "0";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            switch (sign)
            {
                case "+":
                    b = Convert.ToInt32(lblNumber.Content);
                    a = a + b;
                    lblNumber.Content = a.ToString();
                    break;
                case "-":
                    b = a - Convert.ToInt32(lblNumber.Content);
                    lblNumber.Content = b.ToString();
                    break;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            sign = "-";
            a = Convert.ToInt32(lblNumber.Content);
            lblNumber.Content = "0";
            label = "0";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(lblNumber.Content) / 10 == 0)
            {
                lblNumber.Content = "0";
                label = "0";
            }
            else
            {
                lblNumber.Content = ((Convert.ToInt32(lblNumber.Content)) / 10).ToString();
            }
        }
    }
}

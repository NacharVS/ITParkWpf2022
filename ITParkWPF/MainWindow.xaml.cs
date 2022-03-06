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

        string bufLogin = "Login";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.AddProductToDatabase(txtName.Text, txtLogin.Text, txtEmail.Text, txtPhone.Text);
            listLogin.ItemsSource = User.GetUserList();
        }

        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (bufLogin != "Login")
            {
                return;
            }
            else
                txtLogin.Clear();
        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
        }

        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEmail.Clear();
        }

        private void txtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPhone.Clear();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            bufLogin = txtLogin.Text;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("Misha");
            list.Add("Sasha");
            list.Add("Dasha");
            list.Add("Serega");
            list.Add("Leha");
            listLogin.ItemsSource = list;

        }

        private void listLogin_Loaded(object sender, RoutedEventArgs e)
        {
            listLogin.ItemsSource = User.GetUserList();
        }

        private void listLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLogin.SelectedIndex == -1)
            {
                return;
            }
            else
            {

                txtName.Text = User.GetUser(listLogin.SelectedItem.ToString()).Name;
                txtLogin.Text = User.GetUser(listLogin.SelectedItem.ToString()).Login;
                txtEmail.Text = User.GetUser(listLogin.SelectedItem.ToString()).Email;
                txtPhone.Text = User.GetUser(listLogin.SelectedItem.ToString()).PhoneNumber;
            }
        }
    }
}

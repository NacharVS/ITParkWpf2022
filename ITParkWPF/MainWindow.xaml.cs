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
       string bufLogin = "Login";
        User user = new User("Login", "Name", "E-Mail", "Phone");
        public MainWindow()
        {
            InitializeComponent();
            
        }      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.AddToDB(txtLogin.Text, txtName1.Text, txtEmail.Text, txtPhone.Text);
            listLogin.ItemsSource = User.GetLoginList();
            MessageBox.Show($"User {txtLogin.Text} has registered");
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

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            bufLogin = txtLogin.Text;
        }

        private void txtLogin_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtLogin_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            User.ReplaceOne(txtLogin.Text, txtName1.Text, txtEmail.Text, txtPhone.Text, new User (txtLogin.Text, txtName1.Text, txtEmail.Text, txtPhone.Text));
            listLogin_Loaded(sender, e);
        }

        private void listLogin_Loaded(object sender, RoutedEventArgs e)
        {
            listLogin.ItemsSource = User.GetLoginList();
        }

        private void listLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listLogin.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                txtName1.Text = User.GetUser(listLogin.SelectedItem.ToString()).Name;
                txtLogin.Text = User.GetUser(listLogin.SelectedItem.ToString()).Login;
                txtEmail.Text = User.GetUser(listLogin.SelectedItem.ToString()).Email;
                txtPhone.Text = User.GetUser(listLogin.SelectedItem.ToString()).PhoneNumber;

            }
        }

        private void listLogin_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

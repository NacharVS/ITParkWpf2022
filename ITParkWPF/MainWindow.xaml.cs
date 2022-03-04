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
        User user = new User("Name", "Login", "E-mail", "Phone");
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            User.AddToDB(Nametxt.Text, Logintxt.Text, Emailtxt.Text, Phonetxt.Text);
            listLogin.ItemsSource = User.GetLoginList();
            MessageBox.Show($"User {Logintxt.Text} has registrated");

        }

        private void Logintxt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (bufLogin!="Login")
            {
                return;
            }
            else 
            Logintxt.Clear();   
        }

        private void Nametxt_GotFocus(object sender, RoutedEventArgs e)
        {
            Nametxt.Clear();
        }

        private void Emailtxt_GotFocus(object sender, RoutedEventArgs e)
        {
            Emailtxt.Clear();
        }

        private void Phonetxt_GotFocus(object sender, RoutedEventArgs e)
        {
            Phonetxt.Clear();
        }

        private void Logintxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            bufLogin = Logintxt.Text;
        }

        private void Logintxt_TextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User.UpdateUser(Nametxt.Text, new User(Nametxt.Text, Logintxt.Text, Emailtxt.Text, Phonetxt.Text));
        }

        private void listLogin_Loaded(object sender, RoutedEventArgs e)
        {

            listLogin.ItemsSource = User.GetLoginList();
        }

        private void listLogin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listLogin.SelectedIndex == -1)
            {
                return;
            }
            else
            {

                Nametxt.Text = User.GetUser(listLogin.SelectedItem.ToString()).Name;
                Logintxt.Text = User.GetUser(listLogin.SelectedItem.ToString()).Login;
                Emailtxt.Text = User.GetUser(listLogin.SelectedItem.ToString()).Email;
                Phonetxt.Text = User.GetUser(listLogin.SelectedItem.ToString()).PhoneNumber;
            }
        }



    }
}

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
        User user = new User("Name", "Login", "E-Mail", "Phone");

        string[] teamList = new string[5] { "#1", "#2", "#3", "#4", "#5" };
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
            cmbbox1.SelectedItem.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listLogin.SelectedItem == null)
                MessageBox.Show("Check user to update");
            else
            User.ReplaseUser(listLogin.SelectedItem.ToString(), new User(txtLogin.Text, txtName1.Text, txtEmail.Text, txtPhone.Text));
            listLogin.ItemsSource = User.GetLoginList();
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
                txtLogin.Text = User.GetUser(listLogin.SelectedItem.ToString()).Login;
                txtName1.Text = User.GetUser(listLogin.SelectedItem.ToString()).Name;
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<string> buffer = User.GetLoginList();
            if(cmbbox1.SelectedIndex == 1)
            {
                Random rnd = new Random();
                for (int i = 0; i < teamList.Length ; i++)
                {
                    teamList[i] = buffer[rnd.Next(0, buffer.Count)];
                    buffer.Remove(teamList[i]);
                }
                teammate1.Content = "#1 " + teamList[0];
                teammate2.Content = "#2 " + teamList[1];
                teammate3.Content = "#3 " + teamList[2];
                teammate4.Content = "#4 " + teamList[3];
                teammate5.Content = "#5 " + teamList[4];

            }
            if(cmbbox1.SelectedIndex == 2)
            {
                teammate1.Content = "#1 ";
                teammate2.Content = "#2 ";
                teammate3.Content = "#3 ";
                teammate4.Content = "#4 ";
                teammate5.Content = "#5 ";
            }
        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            teamListBox.ItemsSource = Team.GetTeamList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (teamListBox.Items.Contains(teamname.Text))
            {
                MessageBox.Show("Team alredy exists");
            }
            else
            {
                Team.AddTeamToDB(new Team(teamname.Text, teammate1.Content.ToString(), teammate2.Content.ToString(), teammate3.Content.ToString(), teammate4.Content.ToString(), teammate5.Content.ToString()));
                teamListBox.ItemsSource = Team.GetTeamList();
                teamname.Clear();
                teammate1.Content = "#1 ";
                teammate2.Content = "#2 ";
                teammate3.Content = "#3 ";
                teammate4.Content = "#4 ";
                teammate5.Content = "#5 ";
            }
     
        }

        private void teamListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teammate1.Content = Team.GetTeam(teamListBox.SelectedItem.ToString()).Teammate1;
            teammate2.Content = Team.GetTeam(teamListBox.SelectedItem.ToString()).Teammate2;
            teammate3.Content = Team.GetTeam(teamListBox.SelectedItem.ToString()).Teammate3;
            teammate4.Content = Team.GetTeam(teamListBox.SelectedItem.ToString()).Teammate4;
            teammate5.Content = Team.GetTeam(teamListBox.SelectedItem.ToString()).Teammate5;
        }
    }
}

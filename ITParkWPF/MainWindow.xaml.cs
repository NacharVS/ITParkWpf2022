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

        string [] teamList = new []{"#1", "#2", "#3", "#4", "#5"};

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
            //User.UpdateUser(Nametxt.Text, new User(Nametxt.Text, Logintxt.Text, Emailtxt.Text, Phonetxt.Text));
            if (listLogin.SelectedItem == null)
            {
                MessageBox.Show("Check user to update");
            }
            User.UpdateUser(listLogin.SelectedItem.ToString(), new User(Nametxt.Text, Logintxt.Text, Emailtxt.Text, Phonetxt.Text));
            listLogin.ItemsSource = User.GetLoginList();
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
        internal int click = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> buffer = User.GetLoginList();
            if (cmbbox1.SelectedIndex == 0) //add custom
            {
               //teammate1.Content = "#1 " + listLogin.SelectedItem.ToString();
                
                
              
                                
            }
            if (cmbbox1.SelectedIndex == 1) //clear one teammate
            {
                click++;
                if (click == 1)
                {
                    teammate5.Content = "#5 ";
                }
                if (click == 2)
                {
                    teammate4.Content = "#4 ";
                }
                if (click == 3)
                {
                    teammate3.Content = "#3 ";
                }
                if (click == 4)
                {
                    teammate2.Content = "#2 ";
                }
                if (click == 5)
                {
                    teammate1.Content = "#1 ";
                }
                if (click > 5)
                {
                    click = 0;
                }
            }
            if (cmbbox1.SelectedIndex ==2) //random select
            {
                Random rnd = new();
                for (int i = 0; i < teamList.Length; i++)
                {
                    teamList[i] = buffer[rnd.Next(0, buffer.Count)];      /*listLogin.Items[rnd.Next(0, listLogin.Items.Count)].ToString();*/
                    buffer.Remove(teamList[i]);

                }
                teammate1.Content = "#1 " + teamList[0];
                teammate2.Content = "#2 " + teamList[1];
                teammate3.Content = "#3 " + teamList[2];
                teammate4.Content = "#4 " + teamList[3];
                teammate5.Content = "#5 " + teamList[4];
            }
            if (cmbbox1.SelectedIndex == 3) //clear team
            {
                teammate1.Content = "#1 " ;
                teammate2.Content = "#2 " ;
                teammate3.Content = "#3 " ;
                teammate4.Content = "#4 " ;
                teammate5.Content = "#5 " ;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
                if (teamListBox.Items.Contains(teamname.Text))
                {
                MessageBox.Show("Team already exists");
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
            
                MessageBox.Show("Not enough teammate");
            

        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            teamListBox.ItemsSource = Team.GetTeamList();
        }

        private void teamListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team team = Team.GetTeam(teamListBox.SelectedItem.ToString());
            teammate1.Content = team.Teammate1;
            teammate2.Content = team.Teammate2;    
            teammate3.Content = team.Teammate3; 
            teammate4.Content = team.Teammate4;    
            teammate5.Content = team.Teammate5;    
            
        }

        
        

    }
}

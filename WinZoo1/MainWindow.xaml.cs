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
using WinZoo.DataBase.Workers;
namespace WinZoo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Worker myworker;
        private Forms.Menu_Caretaker menu_Caretaker;
        private Forms.Menu_Administrator menu_Administrator;
        private Forms.Menu_Veterinarian menu_Veterinarian;
        public MainWindow()
        {
            InitializeComponent();
            
            
            
        }

        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void minBottom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myworker = new Worker();
            if(myworker.Get_Human().Log_in(Convert.ToString(Login.Text), Convert.ToString(Password.Text)))
            {
                System.Windows.MessageBox.Show("ТУт");
                if (myworker.Get_Position() != "none") {
                    // Тут будуть форми!
                    myworker = new Worker(myworker.Get_Human());
                    if (myworker.Get_Position() == "Caretaker") 
                    { 
                        menu_Caretaker = new Forms.Menu_Caretaker(); 
                        menu_Caretaker.Show();
                        this.Close();
                    }
                    else if (myworker.Get_Position() == "Veterinarian") 
                    { 
                        menu_Veterinarian = new Forms.Menu_Veterinarian();
                        menu_Veterinarian.Show();
                        this.Close();
                    }
                    else if (myworker.Get_Position() == "Administrator") 
                    {
                        System.Windows.MessageBox.Show("ТУт не");
                        menu_Administrator = new Forms.Menu_Administrator();
                        menu_Administrator.Show();
                        this.Close();
                    }
                }
            }
            else
            {

            }
            //menu_Caretaker = new Forms.Menu_Caretaker();
            //menu_Caretaker.Show();
        }
    }
}

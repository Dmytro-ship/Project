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
using System.Windows.Shapes;
using WinZoo.DataBase.Workers;

namespace WinZoo.Forms
{
    /// <summary>
    /// Логика взаимодействия для Menu_Administrator.xaml
    /// </summary>
    public partial class Menu_Administrator : Window
    {
        private Administrator Admin;
        public Menu_Administrator()
        {
            InitializeComponent();
            Admin = new Administrator();
        }
    }
}

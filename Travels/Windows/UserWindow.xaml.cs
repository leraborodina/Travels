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
using Travels.Pages;

namespace Travels.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            UserFrame.Navigate(new UserMenuPage());
        }
        private void LogOut_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow signin = new MainWindow();
            signin.Show();
            this.Close();
        }
    }
}

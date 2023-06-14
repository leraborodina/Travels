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
using Travels.Entities;
using Travels.Pages;
using Travels.Windows;

namespace Travels
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUserAdmin = AppData.db.Users.FirstOrDefault(u => u.login == login_txt.Text && u.password == password_txt.Password && u.id_role == 1);
            var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.login == login_txt.Text && u.password == password_txt.Password && u.id_role == 2);
            if (CurrentUserAdmin != null)
            {   
                MenuWindow menu = new MenuWindow();
                menu.Show();
                this.Close();
            } else if (CurrentUser != null)
            {
                int userId = CurrentUser.id_user;
                App.IdUser = userId;
                UserWindow userWindow = new UserWindow();
                userWindow.Show();
                this.Close();
            }
            else if (login_txt.Text == "" || password_txt.Password == "")
            {
                MessageBox.Show("Заполните все пустые поля", "Поля пустые!");
            } else 
            {
                if (MessageBox.Show("Аккаунта с таким логином или паролем не существует!\nПройти регистрацию?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    RegistrationWindow regist = new RegistrationWindow();
                    regist.Show();
                    this.Close();
                }
                else
                {
                    string loginUser = login_txt.Text;
                    App.UserLogin = loginUser;
                    password_txt.Password = "";
                    login_txt.Focus();
                }
            }
        }

        private void Loginpage_close_button_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Registration_window_open(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

    }
}

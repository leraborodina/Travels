using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Travels.Entities;

namespace Travels.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Registrationpage_close_button_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Login_window_open(object sender, MouseButtonEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }

        public Boolean CheckPass()//проверка пароля на спец.символы
        {
            string password = password_txt.Password;
            if (password.Length > 5
                && password.Any(char.IsLetter)
                && password.Any(char.IsDigit)
                && password.Any(char.IsPunctuation)
                && password.Any(char.IsLower)
                && password.Any(char.IsUpper))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean CheckEmail()//проверка почты
        {
            string email = email_txt.Text;
            if (email.Contains("@") && email.Length > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void register_button_Click(object sender, RoutedEventArgs e)
        {
            string firstname = firstname_txt.Text;
            string lastname = lastname_txt.Text;
            string login = login_txt.Text;
            string password = password_txt.Password;
            string confpass = confpass_txt.Password;
            string email = email_txt.Text;

            {
                if (firstname_txt.Text == "" || lastname_txt.Text == "" || login_txt.Text == "" || password_txt.Password == "" || confpass_txt.Password == "" || email_txt.Text == "")
                {
                    MessageBox.Show("Поля пустые!", "Регистрация не завершена");
                }
                else if (AppData.db.Users.Count(u => u.login == login_txt.Text) > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже есть!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!(password_txt.Password == confpass_txt.Password))
                {
                    MessageBox.Show("Пароли не совпадают!\nВведите снова", "Регистрация не завершена");
                    password_txt.Password = "";
                    confpass_txt.Password = "";
                    password_txt.Focus();
                }
                else if (!CheckPass())
                {
                    MessageBox.Show("Пароль может содержать только символы a-z, A-Z, нижний и верхний регистр, знаки пунктуации, цифры\nВведите снова", "Регистрация не завершена");
                    password_txt.Password = "";
                    confpass_txt.Password = "";
                    password_txt.Focus();
                }
                else if (!CheckEmail())
                {
                    MessageBox.Show("Почта должна содержать @ и не менее 5 символов!");
                    email_txt.Text = "";
                    email_txt.Focus();
                }
                else
                {
                    Users user = new Users()
                    {
                        firstname = firstname_txt.Text,
                        lastname = lastname_txt.Text,
                        login = login_txt.Text,
                        password = password_txt.Password,
                        email = email_txt.Text,
                        id_role = 2
                    };
                    AppData.db.Users.Add(user);
                    AppData.db.SaveChanges();
                    MenuWindow userWindow = new MenuWindow();
                    userWindow.Show();
                    this.Close();
                }
            }
        }
    }
}

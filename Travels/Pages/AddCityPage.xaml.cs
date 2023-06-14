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

namespace Travels.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddCityPage.xaml
    /// </summary>
    public partial class AddCityPage : Page
    {
        public AddCityPage()
        {
            InitializeComponent();
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            if (CityTxt.Text != "")
            {
                Cities city = new Cities();
                city.city = CityTxt.Text;

                AppData.db.Cities.Add(city);
                AppData.db.SaveChanges();

                MessageBox.Show("Город успешно сохранен", "Успешно!", MessageBoxButton.OK);

                CityTxt.Text = "";
                CityTxt.Focus();
            }
            else
            {
                MessageBox.Show("Заполните пустые поля", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

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
    /// Логика взаимодействия для AdminCitiesPage.xaml
    /// </summary>
    public partial class AdminCitiesPage : Page
    {
        public AdminCitiesPage()
        {
            InitializeComponent();
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            CitiesGrid.ItemsSource = AppData.db.Cities.ToList();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCityPage());
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите сохранить изменения?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
            {
                CitiesGrid.ItemsSource = AppData.db.Cities.ToList();
                AppData.db.SaveChanges();
            }
            else if (MessageBox.Show("Вы действительно хотите сохранить изменения?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.No)
            {
                CitiesGrid.ItemsSource = AppData.db.Cities.ToList();
            }
        }

        private void Remove_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить город?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
            {
                var CurrentCity = CitiesGrid.SelectedItem as Cities;
                AppData.db.Cities.Remove(CurrentCity);
                AppData.db.SaveChanges();

                CitiesGrid.ItemsSource = AppData.db.Cities.ToList();
                MessageBox.Show("Категория успешно удалена", "", MessageBoxButton.OK);
            }
            else if (MessageBox.Show("Вы уверены, что хотите удалить город?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.No)
            {
                CitiesGrid.ItemsSource = AppData.db.Cities.ToList();
            }
            else
            {
                MessageBox.Show("Ошибка!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

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
    /// Логика взаимодействия для UserTravelPlacesPage.xaml
    /// </summary>
    public partial class UserTravelPlacesPage : Page
    {
        TravelPlaces pravel_places = new TravelPlaces();
        public UserTravelPlacesPage()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            int userId = App.IdUser;
            TravelPlacesList.ItemsSource = AppData.db.TravelPlaces.Where(u => u.Travel.id_user == userId).ToList();
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTravelPlacesPage());
        }

        private void Remove_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить путешествие?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentTravelPlaces = TravelPlacesList.SelectedItem as TravelPlaces;
                AppData.db.TravelPlaces.Remove(CurrentTravelPlaces);
                AppData.db.SaveChanges();

                int userId = App.IdUser;
                TravelPlacesList.ItemsSource = AppData.db.TravelPlaces.Where(u => u.Travel.id_user == userId).ToList();
                MessageBox.Show("Поездка успешно удалена", "Успешно!", MessageBoxButton.OK);
            }
        }
    }
}

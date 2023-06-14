using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddTravelPlacesPage.xaml
    /// </summary>
    public partial class AddTravelPlacesPage : Page
    {
        Travel travel = new Travel();
        public AddTravelPlacesPage()
        {
            InitializeComponent();
            int userId = App.IdUser;
            TravelCombobox.ItemsSource = AppData.db.Travel.Where(u => u.id_user == userId).ToList();
            PlaceCombobox.ItemsSource = AppData.db.Places.ToList();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (TravelCombobox.SelectedItem == null || PlaceCombobox.SelectedItem == null)
            {
                MessageBox.Show("Заполните пустые поля", "Пустые поля!", MessageBoxButton.OK);
            }
            else
            {
                TravelPlaces travelPlaces = new TravelPlaces();
                var CurrentPlace = PlaceCombobox.SelectedItem as Places;
                travelPlaces.id_place = CurrentPlace.id_place;

                var CurrentTravel = TravelCombobox.SelectedItem as Travel;
                travelPlaces.id_travel = CurrentTravel.id_trip;

                AppData.db.TravelPlaces.Add(travelPlaces);
                AppData.db.SaveChanges();

                MessageBox.Show("Путешествие успешно добавлено", "Поздравляем!", MessageBoxButton.OK);
            }
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

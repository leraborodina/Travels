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
using Travels.Windows;

namespace Travels.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserTripsPage.xaml
    /// </summary>
    public partial class UserTripsPage : Page
    {
        Travel travel = new Travel();
        public UserTripsPage()
        {
            InitializeComponent();
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UserTripsPageLoaded(object sender, RoutedEventArgs e)
        {
            int userId = App.IdUser;
            TravelsGrid.ItemsSource = AppData.db.Travel.Where(u => u.id_user == userId).ToList();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTravelPage());
        }

        private void Remove_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить поездку?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentTravel = TravelsGrid.SelectedItem as Travel;
                AppData.db.Travel.Remove(CurrentTravel);
                AppData.db.SaveChanges();

                int userId = App.IdUser;
                TravelsGrid.ItemsSource = AppData.db.Travel.Where(u => u.id_user == userId).ToList();
                MessageBox.Show("Поездка успешно удалена", "Успешно!", MessageBoxButton.OK);
            }
        }
    }
}

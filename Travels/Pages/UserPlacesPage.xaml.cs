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
    /// Логика взаимодействия для UserPlacesPage.xaml
    /// </summary>
    public partial class UserPlacesPage : Page
    {
        Places place = new Places();
        public UserPlacesPage()
        {
            InitializeComponent();
            PlacesListView.ItemsSource = AppData.db.Places.ToList();
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPlacePage());
        }

        private void Remove_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить место?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentPlace = PlacesListView.SelectedItem as Places;
                AppData.db.Places.Remove(CurrentPlace);
                AppData.db.SaveChanges();

                PlacesListView.ItemsSource = AppData.db.Places.ToList();
                MessageBox.Show("Место успешно удалено");
            }
        }
    }
}

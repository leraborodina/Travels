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
    /// Логика взаимодействия для AddPlacePage.xaml
    /// </summary>
    public partial class AddTravelPage : Page
    {
        Travel travel = new Travel();
        public AddTravelPage()
        {
            InitializeComponent();

            CategoryCombobox.ItemsSource = AppData.db.Categories.ToList();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if(CategoryCombobox.SelectedItem == null || trip_name.Text == "" || start_date.Text == "")
            {
                MessageBox.Show("Заполните пустые поля","Пустые поля!");
            }
            else
            {
                travel.trip_name = trip_name.Text;
                travel.id_user = App.IdUser;
                travel.start_date = start_date.Text;
                travel.end_date = end_date.Text;
                var CurrentCategory = CategoryCombobox.SelectedItem as Categories;
                travel.id_category = CurrentCategory.id_category;

                AppData.db.Travel.Add(travel);
                AppData.db.SaveChanges();
                trip_name.Text = "";
                start_date.Text = null; 
                end_date.Text = null;
                CategoryCombobox = null;
            }

        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

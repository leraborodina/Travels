using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для AdminCategoriesPage.xaml
    /// </summary>
    public partial class AdminCategoriesPage : Page
    {
        public AdminCategoriesPage()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            CategoriesGrid.ItemsSource = AppData.db.Categories.ToList();
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCategoryPage());
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите сохранить изменения?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
            {
                CategoriesGrid.ItemsSource = AppData.db.Categories.ToList();
                AppData.db.SaveChanges();
            }
            else if(MessageBox.Show("Вы действительно хотите сохранить изменения?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.No)
            {
                CategoriesGrid.ItemsSource = AppData.db.Categories.ToList();
            }
        }

        private void Remove_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить категорию?","Внимание!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.Yes)
            {
                var CurrentCategory = CategoriesGrid.SelectedItem as Categories;
                AppData.db.Categories.Remove(CurrentCategory);
                AppData.db.SaveChanges();

                CategoriesGrid.ItemsSource = AppData.db.Categories.ToList();
                MessageBox.Show("Категория успешно удалена", "", MessageBoxButton.OK);
            } else if(MessageBox.Show("Вы уверены, что хотите удалить категорию?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.None) == MessageBoxResult.No)
            {
                CategoriesGrid.ItemsSource = AppData.db.Categories.ToList();
            } else
            {
                MessageBox.Show("Ошибка!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

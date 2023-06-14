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
    /// Логика взаимодействия для AddCategoryPage.xaml
    /// </summary>
    public partial class AddCategoryPage : Page
    {
        public AddCategoryPage()
        {
            InitializeComponent();
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryTxt.Text != "")
            {
                Categories category = new Categories();
                category.category = CategoryTxt.Text;

                AppData.db.Categories.Add(category);
                AppData.db.SaveChanges();

                MessageBox.Show("Категория успешно сохранена", "Успешно!", MessageBoxButton.OK);

                CategoryTxt.Text = "";
                CategoryTxt.Focus();
            }
            else
            {
                MessageBox.Show("Заполните пустые поля","Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}

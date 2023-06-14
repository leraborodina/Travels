﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    public partial class AddPlacePage : Page
    {
        private byte[] img = null;

        public AddPlacePage()
        {
            InitializeComponent();
            City_Combobox.ItemsSource = AppData.db.Cities.ToList();
        }
        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog photo_img = new OpenFileDialog();
            photo_img.Multiselect = false;
            photo_img.Filter = "Image | *.png; *.jpg; *.jpeg";
            if(photo_img.ShowDialog() == true)
            {
                img = File.ReadAllBytes(photo_img.FileName);

                Image_photo.Source = new ImageSourceConverter().ConvertFrom(img) as ImageSource;
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlaceNameTxt.Text == "" || City_Combobox.SelectedItem == null)
            {
                MessageBox.Show("Заполните пустые поля", "Пустые поля!", MessageBoxButton.OK);
            } else
            {
                Places place = new Places();
                place.place_name = PlaceNameTxt.Text;
                var CurrentCity = City_Combobox.SelectedItem as Cities;
                place.id_city = CurrentCity.id_city;
                place.photo = img;

                AppData.db.Places.Add(place);
                AppData.db.SaveChanges();
                PlaceNameTxt.Text = "";
                City_Combobox = null;
                Image_photo = null;

                MessageBox.Show("Место успешно добавлено", "Успешно!", MessageBoxButton.OK);
            }
        }

        private void Back_button(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

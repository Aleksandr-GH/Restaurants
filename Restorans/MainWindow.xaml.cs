﻿using System;
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
using Newtonsoft;

namespace Restorans
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    OpenData openData;
        FoodPlace[] foodPlaces;
    public MainWindow()
    {
      InitializeComponent();
      openData = new OpenData("OpenData1.json");
      foodPlaces = openData.GetFoodPlaces();
      FillCollection(foodPlaces);
    }

    private void Check_Click(object sender, RoutedEventArgs e)
    {
            foodPlaces = CheckTags(openData.GetFoodPlaces());
            SearchTextBox.Text = null;

            FillCollection(foodPlaces);
    }

        private FoodPlace[] CheckTags(FoodPlace[] foodPlaces)
        {
            if (RestoransCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Ресторан")).ToArray();
            }
            if (RestoransCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Ресторан")).ToArray();
            }
            if (BarCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Бар")).ToArray();
            }
            if (BarCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Бар")).ToArray();
            }
            if (CafeCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Кафе")).ToArray();
            }
            if (CafeCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Кафе")).ToArray();
            }
            if (CafeteriaCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Кафетерий")).ToArray();
            }
            if (CafeteriaCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Кафетерий")).ToArray();
            }
            if (CanteenCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Столовая")).ToArray();
            }
            if (CanteenCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Столовая")).ToArray();
            }
            if (FastFoodCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Предприятие быстрого обслуживания")).ToArray();
            }
            if (FastFoodCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Предприятие быстрого обслуживания")).ToArray();
            }
            if (BuffetCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Буфет")).ToArray();
            }
            if (BuffetCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Буфет")).ToArray();
            }
            if (DinerCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("Закусочная")).ToArray();
            }
            if (DinerCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("Закусочная")).ToArray();
            }
            if (ShopCheck.IsChecked == true)
            {
                foodPlaces = foodPlaces.Union(openData.FindOnType("магазин (отдел кулинарии)")).ToArray();
            }
            if (ShopCheck.IsChecked != true)
            {
                foodPlaces = foodPlaces.Except(openData.FindOnType("магазин (отдел кулинарии)")).ToArray();
            }
            //if (SearchTextBox.Text.Length > 0)
            //{
            //    this.foodPlaces = openData.FindFoodPlaces(SearchTextBox.Text, foodPlaces);
            //}
            return foodPlaces;
        }

    public void FillCollection(FoodPlace[] collection)
    {
      MainLB.ItemsSource = collection;
    }

    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
            
            FillCollection(openData.FindFoodPlaces(SearchTextBox.Text, foodPlaces));
    }
  } 
}

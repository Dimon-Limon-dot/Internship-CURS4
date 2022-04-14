using PlatinumInform.Entities;
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

namespace PlatinumInform.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        Product prod;
        Departament departament;
        List<Product> SavedValues;
        public ProductPage()
        {
            InitializeComponent();
            lwProduct.ItemsSource = ConectDB.inform.Product.ToList();
            cbDep.ItemsSource = ConectDB.inform.Departament.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProd());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            prod = lwProduct.SelectedItem as Product;
            if (prod != null)
            {
                NavigationService.Navigate(new AddEditProd(prod));
            }
            else
            {
                MessageBox.Show("Выберите изделие для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prod = lwProduct.SelectedItem as Product;
                if (prod != null)
                {
                    if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ConectDB.inform.Product.Remove(prod);
                        ConectDB.inform.SaveChanges();
                        lwProduct.ItemsSource = ConectDB.inform.Product.ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите запись для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно удалить запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                ConectDB.inform = new RatepInformEntities();
            }        
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lwProduct.ItemsSource = ConectDB.inform.Product.ToList();
            SavedValues = ConectDB.inform.Product.ToList();
        }
        public static List<Product> FilterData(List<Product> data, string nameProduct = null, int numDep = -1)
        {
            List<Product> FilterValues = data;
            if (nameProduct != null)
            {
                FilterValues = FilterValues.Where(c => c.NameProduct.Contains(nameProduct)).ToList();
            }
            if (numDep != -1)
            {
                FilterValues = FilterValues.Where(c => c.NumDep == numDep).ToList();
            }
            if (FilterValues.Count() == 0)
            {
                MessageBox.Show("Запись не найдена!");
                return data;
            }
            return FilterValues;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            departament = (Departament)cbDep.SelectedItem;
            int numDep = departament == null ? -1 : departament.NumDep;
            lwProduct.ItemsSource = FilterData(SavedValues, tbSearch.Text, numDep);
        }
        private void cbDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            departament = (Departament)cbDep.SelectedItem;
            int numDep = departament == null ? -1 : departament.NumDep;
            lwProduct.ItemsSource = FilterData(SavedValues, tbSearch.Text, numDep);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";
            cbDep.SelectedIndex = -1;
        }
    }
}

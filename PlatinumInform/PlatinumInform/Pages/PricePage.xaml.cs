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
    /// Логика взаимодействия для PricePage.xaml
    /// </summary>
    public partial class PricePage : Page
    {
        Product detail;
        List<Price> SavedValues;
        public PricePage()
        {
            InitializeComponent();
            dgPrice.ItemsSource = ConectDB.inform.Price.ToList();
            cbProduct.ItemsSource = ConectDB.inform.Product.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPrice());
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Price price = dgPrice.SelectedItem as Price;
            if (price != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConectDB.inform.Price.Remove(price);
                    ConectDB.inform.SaveChanges();
                }          
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            dgPrice.ItemsSource = ConectDB.inform.Price.ToList();
        
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            cbProduct.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public static List<Price> FilterData(List<Price> data, int numProd = -1)
        {
            List<Price> FilterValues = data;
            if (numProd != -1)
            {
                FilterValues = FilterValues.Where(c => c.CodeProduct == numProd).ToList();
            }
            if (FilterValues.Count() == 0)
            {
                MessageBox.Show("Запись не найдена!");
                return data;
            }
            return FilterValues;
        }

        private void cbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            detail = (Product)cbProduct.SelectedItem;
            int numProd = detail == null ? -1 : detail.CodeProduct;
            dgPrice.ItemsSource = FilterData(SavedValues, numProd);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dgPrice.ItemsSource = ConectDB.inform.Price.ToList();
            SavedValues = ConectDB.inform.Price.ToList();
        }
    }
}

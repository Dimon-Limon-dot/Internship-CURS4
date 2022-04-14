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
    /// Логика взаимодействия для AddPrice.xaml
    /// </summary>
    public partial class AddPrice : Page
    {
        public AddPrice()
        {
            InitializeComponent();
            DateTime DateNow = DateTime.Today;
            cbDetail.ItemsSource = ConectDB.inform.Product.ToList();
            dpDateInsert.SelectedDate = DateNow;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Price price = new Price();
                int newId = ConectDB.inform.Price.Max(c => c.NumPP) + 1;
                price.NumPP = newId;
                price.DateInsert = dpDateInsert.SelectedDate.Value;
                price.CodeProduct = (cbDetail.SelectedItem as Product).CodeProduct;
                price.Cost = Convert.ToDecimal(tbCost.Text);
                price.NumContract = Convert.ToInt32(tbNumContract.Text);
                if (MessageBox.Show("Вы уверены, что хотите добавить новую запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConectDB.inform.Price.Add(price);
                    ConectDB.inform.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                NavigationService.GoBack();
            }
            catch (Exception)
            {
                MessageBox.Show("Введены некорректные данные или остались незаполненные поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void tbCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCost.Text != "")
            {
                int Cost = Convert.ToInt32(tbCost.Text);
                if (Cost <= 0)
                {
                    MessageBox.Show("Цена должна быть больше 0", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbCost.Text = null;
                }
            }
        }

        private void tbCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}

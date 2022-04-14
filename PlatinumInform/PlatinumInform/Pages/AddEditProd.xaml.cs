using Microsoft.Win32;
using PlatinumInform.Entities;
using System;
using System.Collections.Generic;
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

namespace PlatinumInform.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProd.xaml
    /// </summary>
    public partial class AddEditProd : Page
    {
        Product _product;
        bool Change;
        private byte[] mainImage;

        public AddEditProd()
        {
            InitializeComponent();
            Change = false;
            tbOrganization.IsEnabled = false;
            tbCharacteristic.IsEnabled = false;
            tbNumPP.IsEnabled = false;
            cbDepartament.ItemsSource = ConectDB.inform.Departament.ToList();
            int newSerialNum = ConectDB.inform.Product.Max(c => c.SerialNum) + 1;
            tbOrganization.Text = (1001).ToString();
            tbCharacteristic.Text = (40974).ToString();
            tbNumPP.Text = (newSerialNum).ToString();
            tbDetail.Text = null;
        }
        public AddEditProd(Product product)
        {
            InitializeComponent();
            Change = true;
            this.DataContext = product;
            imgPhoto.DataContext = product;
            _product = product;
            tbOrganization.IsEnabled = false;
            tbCharacteristic.IsEnabled = true;
            tbNumPP.IsEnabled = true;
            tbOrganization.Text = (product.CodeOrg).ToString();
            tbCharacteristic.Text = (product.CodeCharac).ToString();
            tbNumPP.Text = (product.SerialNum).ToString();
            tbDetail.Text = product.NameProduct;
            cbDepartament.ItemsSource = ConectDB.inform.Departament.ToList();
            cbDepartament.SelectedItem = product.Departament;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!Change)
            {
                try
                {
                    Product newProduct = new Product();
                    int newCodeDetail = ConectDB.inform.Product.Max(c => c.CodeProduct) + 1;
                    newProduct.CodeProduct = newCodeDetail;
                    newProduct.CodeOrg = Convert.ToInt32(tbOrganization.Text);
                    newProduct.CodeCharac = Convert.ToInt32(tbCharacteristic.Text);
                    newProduct.SerialNum = Convert.ToInt32(tbNumPP.Text);
                    newProduct.NameProduct = tbDetail.Text;
                    newProduct.NumDep = (cbDepartament.SelectedItem as Departament).NumDep;
                    newProduct.Photo = mainImage;
                    if (MessageBox.Show("Вы уверены, что хотите добавить новую запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ConectDB.inform.Product.Add(newProduct);
                        ConectDB.inform.SaveChanges();
                        MessageBox.Show("Данные успешно сохранены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.GoBack();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Введены некорректные данные или остались незаполненные поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                try
                {
                    Product product = ConectDB.inform.Product.FirstOrDefault(c => c.CodeProduct == _product.CodeProduct);
                    product.CodeOrg = Convert.ToInt32(tbOrganization.Text);
                    product.CodeCharac = Convert.ToInt32(tbCharacteristic.Text);
                    product.SerialNum = Convert.ToInt32(tbNumPP.Text);
                    product.NameProduct = tbDetail.Text;
                    product.NumDep = (cbDepartament.SelectedItem as Departament).NumDep;
                    if (mainImage != null)
                    {
                        product.Photo = mainImage;
                    }
                    if (MessageBox.Show("Вы уверены, что хотите изменить запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        ConectDB.inform.SaveChanges();
                        MessageBox.Show("Данные успешно изменены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.GoBack();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Введены некорректные данные или остались незаполненные поля!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void tbDetail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = (Char.IsDigit(e.Text, 0));
        }

        private void tbOrganization_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                mainImage = File.ReadAllBytes(ofd.FileName);
                imgPhoto.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(mainImage);
            }
        }
    }
}

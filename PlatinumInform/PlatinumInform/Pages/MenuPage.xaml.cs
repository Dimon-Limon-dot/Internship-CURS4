using PlatinumInform.Entities;
using PlatinumInform.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlatinumInform.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage());

            string Dir = $@"{Directory.GetCurrentDirectory()}\Фото\";
            foreach (var item in ConectDB.inform.Product.ToList())
            {
                if (File.Exists(Dir + item.SerialNum + ".png"))
                {
                    Bitmap bitmap = new Bitmap(Dir + item.SerialNum + ".png");
                    MemoryStream memoryStream = new MemoryStream();
                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                    Product prod = ConectDB.inform.Product.FirstOrDefault(c=>c.SerialNum == item.SerialNum);
                    prod.Photo = memoryStream.ToArray();
                    ConectDB.inform.SaveChanges();
                }
            }
        }

        private void btnPrice_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PricePage());
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportPage());
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutAppWindow about = new AboutAppWindow();
            about.ShowDialog();          
        }
    }
}

using PlatinumInform.Entities;
using PlatinumInform.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        public static string Encrypt(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string EncryptPassword = Encrypt(tbPassword.Password);
            try
            {
                Users users = ConectDB.inform.Users.Where(c => c.Login == tbLogin.Text && c.Password == EncryptPassword).FirstOrDefault();
                if (users != null)
                {
                    NavigationService.Navigate(new MenuPage());
                }
                else
                {
                    MessageBox.Show("Введен неправильно логин или пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при попытке подключения к базе. Повторите попытка входа позже", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
                  
        }
    }
}

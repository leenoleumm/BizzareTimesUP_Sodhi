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

namespace WpfApp1.Pages
{
    public partial class ChangePassPage : Page
    {
        public ChangePassPage()
        {
            InitializeComponent();
        }

        private void SavePass_Click(object sender, RoutedEventArgs e)
        {
            // 1. Проверка заполнения
            if (string.IsNullOrEmpty(TbLogin.Text) || string.IsNullOrEmpty(CurrentPasswordBox.Password)
                || string.IsNullOrEmpty(NewPasswordBox.Password) || string.IsNullOrEmpty(ConfirmPasswordBox.Password))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            // 2. Проверка совпадения новых паролей
            if (NewPasswordBox.Password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Новые пароли не совпадают!");
                return;
            }

            // 3. Проверка длины нового пароля
            if (NewPasswordBox.Password.Length < 6)
            {
                MessageBox.Show("Новый пароль должен содержать минимум 6 символов!");
                return;
            }

            try
            {
                using (var db = new DB_BizzareTimesEntities())
                {
                    // Ищем пользователя по email и СТАРОМУ паролю
                    // 1. Ищем пользователя по Email (без сравнения пароля в SQL)
                    var user = db.Users.FirstOrDefault(u => u.Email == TbLogin.Text);

                    // 2. Если пользователь не найден или хэш старого пароля не совпадает — выдаем ошибку
                    if (user == null || user.Password != AuthPage.GetHash(CurrentPasswordBox.Password))
                    {
                        MessageBox.Show("Неверный email или текущий пароль!");
                        return;
                    }

                    if (user == null)
                    {
                        MessageBox.Show("Неверный email или текущий пароль!");
                        return;
                    }

                    // Меняем на новый хэш
                    user.Password = AuthPage.GetHash(NewPasswordBox.Password);
                    db.SaveChanges();

                    MessageBox.Show("Пароль успешно изменён!");
                    NavigationService?.Navigate(new AuthPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }
    }
}
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
using System.Security.Cryptography;

namespace WpfApp1.Pages
{
    public partial class AuthPage : Page
    {
        public static int CurrentUserID = 0;

        private int failedAttempts = 0;

        public AuthPage()
        {
            InitializeComponent();
        }

        // Функция хэширования пароля (SHA1)
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password))
                    .Select(x => x.ToString("X2")));
            }
        }

        private void ButtonEnter_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxLogin.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите email и пароль!");
                return;
            }

            var hashedPassword = GetHash(PasswordBox.Password);

            try
            {
                using (var db = new DB_BizzareTimesEntities())
                {
                    var user = db.Users.AsNoTracking().FirstOrDefault(u =>
                        u.Email == TextBoxLogin.Text && u.Password == hashedPassword);

                    if (user == null)
                    {
                        failedAttempts++;
                        MessageBox.Show($"Пользователь не найден. Неудачных попыток: {failedAttempts} из 3.");

                        if (failedAttempts >= 3)
                        {
                            captcha.Visibility = Visibility.Visible;
                            captchaPanel.Visibility = Visibility.Visible;
                            CaptchaChange();
                        }
                        return;
                    }

                    MessageBox.Show($"Добро пожаловать, {user.Name}!");
                    CurrentUserID = user.ID;

                    if (user.Role == "ADMIN")
                    {
                        NavigationService?.Navigate(new AdminPage());
                    }
                    else
                    {
                        NavigationService?.Navigate(new UserPage());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД: " + ex.Message);
            }
        }

        // Генерация случайной капчи
        public void CaptchaChange()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var rnd = new Random();
            var sb = new StringBuilder();
            for (int i = 0; i < 6; i++) sb.Append(chars[rnd.Next(chars.Length)]);
            captcha.Text = sb.ToString();
            captchaInput.Clear();
        }

        // Проверка введенной капчи
        private void submitCaptcha_Click(object sender, RoutedEventArgs e)
        {
            if (captchaInput.Text != captcha.Text)
            {
                MessageBox.Show("Неверно введена капча!");
                CaptchaChange();
                return;
            }
            MessageBox.Show("Капча пройдена, попробуйте войти снова.");
            captcha.Visibility = Visibility.Hidden;
            captchaPanel.Visibility = Visibility.Hidden;
            failedAttempts = 0;
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegPage());
        }

        private void ButtonChangePassword_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ChangePassPage());
        }
    }
}
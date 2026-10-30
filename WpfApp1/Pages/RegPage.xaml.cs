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
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0; 
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxLog.Text) || string.IsNullOrEmpty(txtbxFIO.Text)
                || string.IsNullOrEmpty(passBxFrst.Password) || string.IsNullOrEmpty(passBxScnd.Password))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (passBxFrst.Password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов!");
                return;
            }

            bool hasEnglish = true;
            bool hasDigit = false;
            foreach (char c in passBxFrst.Password)
            {
                if (char.IsDigit(c)) hasDigit = true;
                else if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))) hasEnglish = false;
            }

            if (!hasEnglish) { MessageBox.Show("Пароль должен содержать только английские буквы и цифры!"); return; }
            if (!hasDigit) { MessageBox.Show("Пароль должен содержать хотя бы одну цифру!"); return; }

            if (passBxFrst.Password != passBxScnd.Password)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            try
            {
                using (var db = new DB_BizzareTimesEntities())
                {
                    if (db.Users.Any(u => u.Email == txtbxLog.Text))
                    {
                        MessageBox.Show("Пользователь с таким email уже существует!");
                        return;
                    }

                    var newUser = new User
                    {
                        Email = txtbxLog.Text,
                        Password = AuthPage.GetHash(passBxFrst.Password), 
                        Name = txtbxFIO.Text,
                        Role = comboBox.Text
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();

                    MessageBox.Show("Пользователь успешно зарегистрирован!");
                    NavigationService?.GoBack(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
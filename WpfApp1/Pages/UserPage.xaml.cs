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
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            LoadArticles();
        }

        private void LoadArticles()
        {
            using (var db = new DB_BizzareTimesEntities())
            {
                // Загружаем все статьи
                var articles = db.Articles.ToList();

                // Если в поле поиска есть текст — фильтруем по заголовку
                if (!string.IsNullOrWhiteSpace(SearchBox.Text))
                {
                    articles = articles.Where(a => a.Title.ToLower().Contains(SearchBox.Text.ToLower())).ToList();
                }

                // Сортируем по дате (новые сверху)
                ListArticles.ItemsSource = articles.OrderByDescending(a => a.CreatedAt).ToList();
            }
        }

        // Обработчик поиска (срабатывает при каждом вводе буквы)
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadArticles();
        }

        // Выход
        private void Logout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AuthPage());
        }

        private void ToggleTheme_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ThemeManager.ToggleTheme(Window.GetWindow(this));
        }
    }
}
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
    public partial class ArticlesTabPage : Page
    {
        public ArticlesTabPage()
        {
            InitializeComponent();
            DataGridArticles.ItemsSource = DB_BizzareTimesEntities.GetContext().Articles.ToList();
            this.IsVisibleChanged += Page_IsVisibleChanged;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DB_BizzareTimesEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridArticles.ItemsSource = DB_BizzareTimesEntities.GetContext().Articles.ToList();
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var articlesForRemoving = DataGridArticles.SelectedItems.Cast<Article>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {articlesForRemoving.Count()} записей?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    // Просто удаляем статьи. SQL Server сам удалит комментарии и лайки благодаря CASCADE.
                    DB_BizzareTimesEntities.GetContext().Articles.RemoveRange(articlesForRemoving);
                    DB_BizzareTimesEntities.GetContext().SaveChanges();

                    MessageBox.Show("Данные успешно удалены!");
                    DataGridArticles.ItemsSource = DB_BizzareTimesEntities.GetContext().Articles.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddEditArticlePage(null));
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            // Берем выделенную строку
            var selectedArticle = DataGridArticles.SelectedItem as Article;
            if (selectedArticle == null)
            {
                MessageBox.Show("Выберите статью для редактирования!");
                return;
            }
            NavigationService?.Navigate(new AddEditArticlePage(selectedArticle));
        }
    }
}
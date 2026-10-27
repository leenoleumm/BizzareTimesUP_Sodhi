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
    public partial class AddEditArticlePage : Page
    {
        private Article _currentArticle;

        public AddEditArticlePage(Article selectedArticle)
        {
            InitializeComponent();

            // Загружаем списки для ComboBox
            CbCategory.ItemsSource = DB_BizzareTimesEntities.GetContext().Categories.ToList();
            CbAuthor.ItemsSource = DB_BizzareTimesEntities.GetContext().Users.ToList();

            if (selectedArticle != null)
            {
                _currentArticle = selectedArticle;
                Title = "Редактирование статьи";
            }
            else
            {
                _currentArticle = new Article();
                Title = "Добавление статьи";
            }

            // Привязываем данные (если редактируем, поля заполнятся)
            DataContext = _currentArticle;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TbTitle.Text))
                errors.AppendLine("Укажите заголовок статьи!");
            if (string.IsNullOrWhiteSpace(TbContent.Text))
                errors.AppendLine("Введите текст статьи!");
            if (CbCategory.SelectedItem == null)
                errors.AppendLine("Выберите категорию!");
            if (CbAuthor.SelectedItem == null)
                errors.AppendLine("Выберите автора!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            // Записываем выбранные значения в объект
            _currentArticle.Title = TbTitle.Text;
            _currentArticle.Content = TbContent.Text;
            _currentArticle.CategoryID = ((Category)CbCategory.SelectedItem).ID;
            _currentArticle.AuthorID = ((User)CbAuthor.SelectedItem).ID;

            try
            {
                // Если ID == 0, значит это новая статья
                if (_currentArticle.ID == 0)
                {
                    _currentArticle.CreatedAt = DateTime.Now;
                    DB_BizzareTimesEntities.GetContext().Articles.Add(_currentArticle);
                }

                DB_BizzareTimesEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
                NavigationService?.GoBack(); // Возвращаемся к таблице
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}

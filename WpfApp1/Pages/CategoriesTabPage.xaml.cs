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
    public partial class CategoriesTabPage : Page
    {
        public CategoriesTabPage()
        {
            InitializeComponent();
            DataGridCategories.ItemsSource = DB_BizzareTimesEntities.GetContext().Categories.ToList();
            this.IsVisibleChanged += Page_IsVisibleChanged;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DB_BizzareTimesEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridCategories.ItemsSource = DB_BizzareTimesEntities.GetContext().Categories.ToList();
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var categoriesForRemoving = DataGridCategories.SelectedItems.Cast<Category>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {categoriesForRemoving.Count()} записей?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DB_BizzareTimesEntities.GetContext().Categories.RemoveRange(categoriesForRemoving);
                    DB_BizzareTimesEntities.GetContext().SaveChanges();

                    MessageBox.Show("Категории успешно удалены!");
                    DataGridCategories.ItemsSource = DB_BizzareTimesEntities.GetContext().Categories.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении (возможно, в категории есть статьи): " + ex.Message);
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AdminPage());
        }
    }
}
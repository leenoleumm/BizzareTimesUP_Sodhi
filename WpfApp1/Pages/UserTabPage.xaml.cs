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
    public partial class UsersTabPage : Page
    {
        public UsersTabPage()
        {
            InitializeComponent();
            DataGridUsers.ItemsSource = DB_BizzareTimesEntities.GetContext().Users.ToList();
            this.IsVisibleChanged += Page_IsVisibleChanged;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DB_BizzareTimesEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DataGridUsers.ItemsSource = DB_BizzareTimesEntities.GetContext().Users.ToList();
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DataGridUsers.SelectedItems.Cast<User>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {usersForRemoving.Count()} записей?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    if (usersForRemoving.Any(u => u.ID == AuthPage.CurrentUserID))
                    {
                        MessageBox.Show("Вы не можете удалить самого себя!");
                        return;
                    }

                    DB_BizzareTimesEntities.GetContext().Users.RemoveRange(usersForRemoving);
                    DB_BizzareTimesEntities.GetContext().SaveChanges();

                    MessageBox.Show("Пользователи успешно удалены!");
                    DataGridUsers.ItemsSource = DB_BizzareTimesEntities.GetContext().Users.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении (возможно, у пользователя есть статьи): " + ex.Message);
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AdminPage());
        }
    }
}

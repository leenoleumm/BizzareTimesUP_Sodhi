using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    public static class ThemeManager
    {
        public static bool IsDarkTheme { get; private set; } = false;

        public static void ToggleTheme(Window window = null)
        {
            IsDarkTheme = !IsDarkTheme;

            var uri = new Uri(IsDarkTheme ? "DarkTheme.xaml" : "Dictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            // Перекрашиваем фон окна
            if (window != null)
            {
                window.Background = IsDarkTheme ? new SolidColorBrush(Color.FromRgb(30, 30, 30)) : Brushes.White;

                // Перекрашиваем все Page внутри окна
                if (window.Content is Grid grid)
                {
                    foreach (var child in grid.Children)
                    {
                        if (child is Frame frame && frame.Content is Page page)
                        {
                            page.Background = IsDarkTheme ? new SolidColorBrush(Color.FromRgb(30, 30, 30)) : Brushes.White;
                        }
                    }
                }
            }
        }
    }
}
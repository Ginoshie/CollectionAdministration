using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CollectionAdministration_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.PreviewMouseLeftButtonDownEvent,
               new MouseButtonEventHandler(SelectivelyHandleMouseButton), true);
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.GotKeyboardFocusEvent,
              new RoutedEventHandler(SelectAllText), true);

            base.OnStartup(e);
        }

        private static void SelectivelyHandleMouseButton(object sender, MouseButtonEventArgs e)
        {
            TextBox textbox = (sender as TextBox);

            if (textbox == null || textbox.IsKeyboardFocusWithin)
            {
                return;
            }

            if (e.OriginalSource.GetType().Name == "TextBoxView")
            {
                e.Handled = true;

                textbox.Focus();
            }
        }

        private static void SelectAllText(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox textBox)
                textBox.SelectAll();
        }
    }
}

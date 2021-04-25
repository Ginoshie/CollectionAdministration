using System.Globalization;
using System.Windows;
using System.Windows.Markup;
using CollectionAdministration_WPF.ViewModel;

namespace CollectionAdministration_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Ensure the current culture passed into bindings 
            // is the OS culture. By default, WPF uses en-US 
            // as the culture, regardless of the system settings.
            FrameworkElement.LanguageProperty.OverrideMetadata(
              typeof(FrameworkElement),
              new FrameworkPropertyMetadata(
                  XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            InitializeComponent();

            var dataContext = new CollectionAdministrationViewModel();
            
            DataContext = dataContext;

            dataContext.GetSavedCounts.Execute(this);
        }
    }
}
